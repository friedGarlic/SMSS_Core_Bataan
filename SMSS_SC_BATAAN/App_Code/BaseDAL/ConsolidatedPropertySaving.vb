Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Namespace ConsolidatedPropertySaving
    'LAND
#Region "TbLand_DTL"

    Public Class TBLand_Details
        Inherits BaseDLL.BaseDAL

        Private pLandId As Long
        Public Property LandId() As Long
            Get
                Return pLandId
            End Get
            Set(ByVal value As Long)
                pLandId = value
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
        Private pLguCode As String
        Public Property LguCode() As String
            Get
                Return pLguCode
            End Get
            Set(ByVal value As String)
                pLguCode = value
            End Set
        End Property
        Private pSectionNo As String
        Public Property SectionNo() As String
            Get
                Return pSectionNo
            End Get
            Set(ByVal value As String)
                pSectionNo = value
            End Set
        End Property
        Private pPIN As String
        Public Property PIN() As String
            Get
                Return pPIN
            End Get
            Set(ByVal value As String)
                pPIN = value
            End Set
        End Property
        Private pTDN As String
        Public Property TDN() As String
            Get
                Return pTDN
            End Get
            Set(ByVal value As String)
                pTDN = value
            End Set
        End Property
        Private pDistrictCode As String
        Public Property DistrictCode() As String
            Get
                Return pDistrictCode
            End Get
            Set(ByVal value As String)
                pDistrictCode = value
            End Set
        End Property

        Private pParcelNo As String
        Public Property ParcelNo() As String
            Get
                Return pParcelNo
            End Get
            Set(ByVal value As String)
                pParcelNo = value
            End Set
        End Property

        Private pARP As String
        Public Property ARP() As String
            Get
                Return pARP
            End Get
            Set(ByVal value As String)
                pARP = value
            End Set
        End Property

        Private pCityMunCode As String
        Public Property CityMunCode() As String
            Get
                Return pCityMunCode
            End Get
            Set(ByVal value As String)
                pCityMunCode = value
            End Set
        End Property
        Private pSeriesNo As String
        Public Property SeriesNo() As String
            Get
                Return pSeriesNo
            End Get
            Set(ByVal value As String)
                pSeriesNo = value
            End Set
        End Property
        Private pRevYear As String
        Public Property RevYear() As String
            Get
                Return pRevYear
            End Get
            Set(ByVal value As String)
                pRevYear = value
            End Set
        End Property
        Private pBarangayCode As String
        Public Property BarangayCode() As String
            Get
                Return pBarangayCode
            End Get
            Set(ByVal value As String)
                pBarangayCode = value
            End Set
        End Property
        Private pRPTIN As String
        Public Property RPTIN() As String
            Get
                Return pRPTIN
            End Get
            Set(ByVal value As String)
                pRPTIN = value
            End Set
        End Property
        Private pDepreciationRate As String
        Public Property DepreciationRate() As String
            Get
                Return pDepreciationRate
            End Get
            Set(ByVal value As String)
                pDepreciationRate = value
            End Set
        End Property
        Private pDepreciationValue As Decimal
        Public Property DepreciationValue() As Decimal
            Get
                Return pDepreciationValue
            End Get
            Set(ByVal value As Decimal)
                pDepreciationValue = value
            End Set
        End Property
        Private pLotNo As String
        Public Property LotNo() As String
            Get
                Return pLotNo
            End Get
            Set(ByVal value As String)
                pLotNo = value
            End Set
        End Property

        Private pBlkNo As String
        Public Property BlkNo() As String
            Get
                Return pBlkNo
            End Get
            Set(ByVal value As String)
                pBlkNo = value
            End Set
        End Property
        Private pStreetName As String
        Public Property StreetName() As String
            Get
                Return pStreetName
            End Get
            Set(ByVal value As String)
                pStreetName = value
            End Set
        End Property
        Private pSubdivision As String
        Public Property Subdivision() As String
            Get
                Return pSubdivision
            End Get
            Set(ByVal value As String)
                pSubdivision = value
            End Set
        End Property

        Private pPhaseNo As String
        Public Property PhaseNo() As String
            Get
                Return pPhaseNo
            End Get
            Set(ByVal value As String)
                pPhaseNo = value
            End Set
        End Property
        Private pPurok As String
        Public Property Purok() As String
            Get
                Return pPurok
            End Get
            Set(ByVal value As String)
                pPurok = value
            End Set
        End Property

        Private pSitio As String
        Public Property Sitio() As String
            Get
                Return pSitio
            End Get
            Set(ByVal value As String)
                pSitio = value
            End Set
        End Property

        Private pBarangay As String
        Public Property Barangay() As String
            Get
                Return pBarangay
            End Get
            Set(ByVal value As String)
                pBarangay = value
            End Set
        End Property

        Private pDistrict As String
        Public Property District() As String
            Get
                Return pDistrict
            End Get
            Set(ByVal value As String)
                pDistrict = value
            End Set
        End Property
        Private pCityMunicipal As String
        Public Property CityMunicipal() As String
            Get
                Return pCityMunicipal
            End Get
            Set(ByVal value As String)
                pCityMunicipal = value
            End Set
        End Property

        Private pProvince As String
        Public Property Province() As String
            Get
                Return pProvince
            End Get
            Set(ByVal value As String)
                pProvince = value
            End Set
        End Property

        Private pRegion As String
        Public Property Region() As String
            Get
                Return pRegion
            End Get
            Set(ByVal value As String)
                pRegion = value
            End Set
        End Property
        Private pZipCode As String
        Public Property ZipCode() As String
            Get
                Return pZipCode
            End Get
            Set(ByVal value As String)
                pZipCode = value
            End Set
        End Property
        Private pClassification As String
        Public Property Classification() As String
            Get
                Return pClassification
            End Get
            Set(ByVal value As String)
                pClassification = value
            End Set
        End Property
        Private pSubClass As String
        Public Property SubClass() As String
            Get
                Return pSubClass
            End Get
            Set(ByVal value As String)
                pSubClass = value
            End Set
        End Property
        Private pLandUse As String
        Public Property LandUse() As String
            Get
                Return pLandUse
            End Get
            Set(ByVal value As String)
                pLandUse = value
            End Set
        End Property
        Private pStatus_1 As String
        Public Property Status_1() As String
            Get
                Return pStatus_1
            End Get
            Set(ByVal value As String)
                pStatus_1 = value
            End Set
        End Property
        Private pTaxable As String
        Public Property Taxable() As String
            Get
                Return pTaxable
            End Get
            Set(ByVal value As String)
                pTaxable = value
            End Set
        End Property
        Private pArea As String
        Public Property Area() As String
            Get
                Return pArea
            End Get
            Set(ByVal value As String)
                pArea = value
            End Set
        End Property
        Private pStatus_2 As String
        Public Property Status_2() As String
            Get
                Return pStatus_2
            End Get
            Set(ByVal value As String)
                pStatus_2 = value
            End Set
        End Property

        Private pAssessedValue As Decimal
        Public Property AssessedValue() As Decimal
            Get
                Return pAssessedValue
            End Get
            Set(ByVal value As Decimal)
                pAssessedValue = value
            End Set
        End Property
        Private pAssessedDate As Date
        Public Property AssessedDate() As Date
            Get
                Return pAssessedDate
            End Get
            Set(ByVal value As Date)
                pAssessedDate = value
            End Set
        End Property
        Private pAVAmountWords As String
        Public Property AVAmountWords() As String
            Get
                Return pAVAmountWords
            End Get
            Set(ByVal value As String)
                pAVAmountWords = value
            End Set
        End Property

        Private pMarketValue As Decimal
        Public Property MarketValue() As Decimal
            Get
                Return pMarketValue
            End Get
            Set(ByVal value As Decimal)
                pMarketValue = value
            End Set
        End Property
        Private pMarketDate As Date
        Public Property MarketDate() As Date
            Get
                Return pMarketDate
            End Get
            Set(ByVal value As Date)
                pMarketDate = value
            End Set
        End Property
        Private pMVAmountWords As String
        Public Property MVAmountWords() As String
            Get
                Return pMVAmountWords
            End Get
            Set(ByVal value As String)
                pMVAmountWords = value
            End Set
        End Property

        Private pUnitValue As Decimal
        Public Property UnitValue() As Decimal
            Get
                Return pUnitValue
            End Get
            Set(ByVal value As Decimal)
                pUnitValue = value
            End Set
        End Property
        Private pUnitDate As Date
        Public Property UnitDate() As Date
            Get
                Return pUnitDate
            End Get
            Set(ByVal value As Date)
                pUnitDate = value
            End Set
        End Property

        Private pAssessmentLevel As String
        Public Property AssessmentLevel() As String
            Get
                Return pAssessmentLevel
            End Get
            Set(ByVal value As String)
                pAssessmentLevel = value
            End Set
        End Property

        Private pStatus_AIR As String
        Public Property Status_AIR() As String
            Get
                Return pStatus_AIR
            End Get
            Set(ByVal value As String)
                pStatus_AIR = value
            End Set
        End Property '

        Private pReceived_ID As Long
        Public Property Received_ID() As Long
            Get
                Return pReceived_ID
            End Get
            Set(ByVal value As Long)
                pReceived_ID = value
            End Set
        End Property

        Private pTaxDeclarationNo As String
        Public Property TaxDeclarationNo() As String
            Get
                Return pTaxDeclarationNo
            End Get
            Set(ByVal value As String)
                pTaxDeclarationNo = value
            End Set
        End Property

        Private pAcqMode As String
        Public Property AcqMode() As String
            Get
                Return pAcqMode
            End Get
            Set(ByVal value As String)
                pAcqMode = value
            End Set
        End Property

        Private pFullAddress As String
        Public Property FullAddress() As String
            Get
                Return pFullAddress
            End Get
            Set(ByVal value As String)
                pFullAddress = value
            End Set
        End Property

        Private pBarangay1 As String
        Public Property Barangay1() As String
            Get
                Return pBarangay1
            End Get
            Set(ByVal value As String)
                pBarangay1 = value
            End Set
        End Property

        Private pArea1 As String
        Public Property Area1() As String
            Get
                Return pArea1
            End Get
            Set(ByVal value As String)
                pArea1 = value
            End Set
        End Property

        Private pMarketValue1 As Decimal
        Public Property MarketValue1() As Decimal
            Get
                Return pMarketValue1
            End Get
            Set(ByVal value As Decimal)
                pMarketValue1 = value
            End Set
        End Property

        Private pAVAmount As Decimal
        Public Property AVAmount() As Decimal
            Get
                Return pAVAmount
            End Get
            Set(ByVal value As Decimal)
                pAVAmount = value
            End Set
        End Property


        Private pMVAmount As Decimal
        Public Property MVAmount() As Decimal
            Get
                Return pMarketValue
            End Get
            Set(ByVal value As Decimal)
                pMVAmount = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@LandId", 0)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@LguCode ", LguCode)
            objDerived.cmd.Parameters.AddWithValue("@SectionNo", SectionNo)
            objDerived.cmd.Parameters.AddWithValue("@PIN ", PIN)
            objDerived.cmd.Parameters.AddWithValue("@TDN ", TDN)
            objDerived.cmd.Parameters.AddWithValue("@DistrictCode", DistrictCode)
            objDerived.cmd.Parameters.AddWithValue("@ParcelNo ", ParcelNo)
            objDerived.cmd.Parameters.AddWithValue("@ARP ", ARP)
            objDerived.cmd.Parameters.AddWithValue("@CityMunCode", CityMunCode)
            objDerived.cmd.Parameters.AddWithValue("@SeriesNo ", SeriesNo)
            objDerived.cmd.Parameters.AddWithValue("@RevYear", RevYear)
            objDerived.cmd.Parameters.AddWithValue("@BarangayCode", BarangayCode)
            objDerived.cmd.Parameters.AddWithValue("@RPTIN", RPTIN)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate ", DepreciationRate)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", DepreciationValue)
            objDerived.cmd.Parameters.AddWithValue("@LotNo ", LotNo)
            objDerived.cmd.Parameters.AddWithValue("@BlkNo ", BlkNo)
            objDerived.cmd.Parameters.AddWithValue("@StreetName ", StreetName)
            objDerived.cmd.Parameters.AddWithValue("@Subdivision ", Subdivision)
            objDerived.cmd.Parameters.AddWithValue("@PhaseNo ", PhaseNo)
            objDerived.cmd.Parameters.AddWithValue("@Purok ", Purok)
            objDerived.cmd.Parameters.AddWithValue("@Sitio", Sitio)
            objDerived.cmd.Parameters.AddWithValue("@Barangay ", Barangay)
            objDerived.cmd.Parameters.AddWithValue("@District ", District)
            objDerived.cmd.Parameters.AddWithValue("@CityMunicipal ", CityMunicipal)
            objDerived.cmd.Parameters.AddWithValue("@Province", Province)
            objDerived.cmd.Parameters.AddWithValue("@Region", Region)
            objDerived.cmd.Parameters.AddWithValue("@ZipCode", ZipCode)
            objDerived.cmd.Parameters.AddWithValue("@Classification ", Classification)
            objDerived.cmd.Parameters.AddWithValue("@SubClass", SubClass)
            objDerived.cmd.Parameters.AddWithValue("@LandUse ", LandUse)
            objDerived.cmd.Parameters.AddWithValue("@Status_1 ", Status_1)
            objDerived.cmd.Parameters.AddWithValue("@Taxable", Taxable)
            objDerived.cmd.Parameters.AddWithValue("@Area", Area)
            objDerived.cmd.Parameters.AddWithValue("@Status_2 ", Status_2)
            objDerived.cmd.Parameters.AddWithValue("@AssessedValue", AssessedValue)
            objDerived.cmd.Parameters.AddWithValue("@AssessedDate ", AssessedDate)
            objDerived.cmd.Parameters.AddWithValue("@AVAmountWords", AVAmountWords)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue ", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@MarketDate", MarketDate)
            objDerived.cmd.Parameters.AddWithValue("@MVAmountWords", MVAmountWords)
            objDerived.cmd.Parameters.AddWithValue("@UnitValue", UnitValue)
            objDerived.cmd.Parameters.AddWithValue("@UnitDate", UnitDate)
            objDerived.cmd.Parameters.AddWithValue("@AssessmentLevel", AssessmentLevel)
            objDerived.cmd.Parameters.AddWithValue("@Status_AIR", Status_AIR)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@TaxDeclarationNo", TaxDeclarationNo)
            objDerived.cmd.Parameters.AddWithValue("@FullAddress", FullAddress)
            objDerived.cmd.Parameters.AddWithValue("@Barangay1 ", Barangay1)
            objDerived.cmd.Parameters.AddWithValue("@Area1", Area1)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue1", MarketValue1)
            objDerived.cmd.Parameters.AddWithValue("@AVAmount", AVAmount)
            objDerived.cmd.Parameters.AddWithValue("@MVAmount", MVAmount)
            objDerived.cmd.Parameters.AddWithValue("@AcqMode", AcqMode)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbLand_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@LandId", LandId)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@LguCode ", LguCode)
            objDerived.cmd.Parameters.AddWithValue("@SectionNo", SectionNo)
            objDerived.cmd.Parameters.AddWithValue("@PIN ", PIN)
            objDerived.cmd.Parameters.AddWithValue("@TDN ", TDN)
            objDerived.cmd.Parameters.AddWithValue("@DistrictCode", DistrictCode)
            objDerived.cmd.Parameters.AddWithValue("@ParcelNo ", ParcelNo)
            objDerived.cmd.Parameters.AddWithValue("@ARP ", ARP)
            objDerived.cmd.Parameters.AddWithValue("@CityMunCode", CityMunCode)
            objDerived.cmd.Parameters.AddWithValue("@SeriesNo ", SeriesNo)
            objDerived.cmd.Parameters.AddWithValue("@RevYear", RevYear)
            objDerived.cmd.Parameters.AddWithValue("@BarangayCode", BarangayCode)
            objDerived.cmd.Parameters.AddWithValue("@RPTIN", RPTIN)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate ", DepreciationRate)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", DepreciationValue)
            objDerived.cmd.Parameters.AddWithValue("@LotNo ", LotNo)
            objDerived.cmd.Parameters.AddWithValue("@BlkNo ", BlkNo)
            objDerived.cmd.Parameters.AddWithValue("@StreetName ", StreetName)
            objDerived.cmd.Parameters.AddWithValue("@Subdivision ", Subdivision)
            objDerived.cmd.Parameters.AddWithValue("@PhaseNo ", PhaseNo)
            objDerived.cmd.Parameters.AddWithValue("@Purok ", Purok)
            objDerived.cmd.Parameters.AddWithValue("@Sitio", Sitio)
            objDerived.cmd.Parameters.AddWithValue("@Barangay ", Barangay)
            objDerived.cmd.Parameters.AddWithValue("@District ", District)
            objDerived.cmd.Parameters.AddWithValue("@CityMunicipal ", CityMunicipal)
            objDerived.cmd.Parameters.AddWithValue("@Province", Province)
            objDerived.cmd.Parameters.AddWithValue("@Region", Region)
            objDerived.cmd.Parameters.AddWithValue("@ZipCode", ZipCode)
            objDerived.cmd.Parameters.AddWithValue("@Classification ", Classification)
            objDerived.cmd.Parameters.AddWithValue("@SubClass", SubClass)
            objDerived.cmd.Parameters.AddWithValue("@LandUse ", LandUse)
            objDerived.cmd.Parameters.AddWithValue("@Status_1 ", Status_1)
            objDerived.cmd.Parameters.AddWithValue("@Taxable", Taxable)
            objDerived.cmd.Parameters.AddWithValue("@Area", Area)
            objDerived.cmd.Parameters.AddWithValue("@Status_2 ", Status_2)
            objDerived.cmd.Parameters.AddWithValue("@AssessedValue", AssessedValue)
            objDerived.cmd.Parameters.AddWithValue("@AssessedDate ", AssessedDate)
            objDerived.cmd.Parameters.AddWithValue("@AVAmountWords", AVAmountWords)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue ", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@MarketDate", MarketDate)
            objDerived.cmd.Parameters.AddWithValue("@MVAmountWords", MVAmountWords)
            objDerived.cmd.Parameters.AddWithValue("@UnitValue", UnitValue)
            objDerived.cmd.Parameters.AddWithValue("@UnitDate", UnitDate)
            objDerived.cmd.Parameters.AddWithValue("@AssessmentLevel", AssessmentLevel)
            objDerived.cmd.Parameters.AddWithValue("@Status_AIR", Status_AIR)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@TaxDeclarationNo", TaxDeclarationNo)
            objDerived.cmd.Parameters.AddWithValue("@AcqMode", AcqMode)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbLand_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class




#End Region
#Region "TB_LandDescription"

    Public Class TB_Landdescription
        Inherits BaseDLL.BaseDAL

        Private pTechDescriptionId As Long
        Public Property TechDescriptionId() As Long
            Get
                Return pTechDescriptionId
            End Get
            Set(ByVal value As Long)
                pTechDescriptionId = value
            End Set
        End Property

        Private pLandId As Long
        Public Property LandId() As Long
            Get
                Return pLandId
            End Get
            Set(ByVal value As Long)
                pLandId = value
            End Set
        End Property

        Private pOctNo As String
        Public Property OctNo() As String
            Get
                Return pOctNo
            End Get
            Set(ByVal value As String)
                pOctNo = value
            End Set
        End Property

        Private pTctNo As String
        Public Property TctNo() As String
            Get
                Return pTctNo
            End Get
            Set(ByVal value As String)
                pTctNo = value
            End Set
        End Property

        Private piDate As Date
        Public Property iDate() As Date
            Get
                Return piDate
            End Get
            Set(ByVal value As Date)
                piDate = value
            End Set
        End Property

        Private pDateRegistered As Date
        Public Property DateRegistered() As Date
            Get
                Return pDateRegistered
            End Get
            Set(ByVal value As Date)
                pDateRegistered = value
            End Set
        End Property


        Private pCadastralNo As String
        Public Property CadastralNo() As String
            Get
                Return pCadastralNo
            End Get
            Set(ByVal value As String)
                pCadastralNo = value
            End Set
        End Property

        Private pBrgyBounderyMonu As String
        Public Property BrgyBounderyMonu() As String
            Get
                Return pBrgyBounderyMonu
            End Get
            Set(ByVal value As String)
                pBrgyBounderyMonu = value
            End Set
        End Property

        Private pNorth As String
        Public Property North() As String
            Get
                Return pNorth
            End Get
            Set(ByVal value As String)
                pNorth = value
            End Set
        End Property

        Private pEast As String
        Public Property East() As String
            Get
                Return pEast
            End Get
            Set(ByVal value As String)
                pEast = value
            End Set
        End Property

        Private pSouth As String
        Public Property South() As String
            Get
                Return pSouth
            End Get
            Set(ByVal value As String)
                pSouth = value
            End Set
        End Property


        Private pWest As String
        Public Property West() As String
            Get
                Return pWest
            End Get
            Set(ByVal value As String)
                pWest = value
            End Set
        End Property


        Private pStartingPt As String
        Public Property StartingPt() As String
            Get
                Return pStartingPt
            End Get
            Set(ByVal value As String)
                pStartingPt = value
            End Set
        End Property

        Private pEndingPt As String
        Public Property EndingPt() As String
            Get
                Return pEndingPt
            End Get
            Set(ByVal value As String)
                pEndingPt = value
            End Set
        End Property

        Private pNS As String
        Public Property NS() As String
            Get
                Return pNS
            End Get
            Set(ByVal value As String)
                pNS = value
            End Set
        End Property

        Private pNS1 As String
        Public Property NS1() As String
            Get
                Return pNS1
            End Get
            Set(ByVal value As String)
                pNS1 = value
            End Set
        End Property

        Private pNS2 As String
        Public Property NS2() As String
            Get
                Return pNS2
            End Get
            Set(ByVal value As String)
                pNS2 = value
            End Set
        End Property

        Private pWE As String
        Public Property WE() As String
            Get
                Return pWE
            End Get
            Set(ByVal value As String)
                pWE = value
            End Set
        End Property

        Private pmDistance As String
        Public Property mDistance() As String
            Get
                Return pmDistance
            End Get
            Set(ByVal value As String)
                pmDistance = value
            End Set
        End Property
        Public Function save() As Long

            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@TechDescriptionId", 0)
            objDerived.cmd.Parameters.AddWithValue("@LandId", LandId)
            objDerived.cmd.Parameters.AddWithValue("@OctNo", OctNo)
            objDerived.cmd.Parameters.AddWithValue("@TctNo", TctNo)
            objDerived.cmd.Parameters.AddWithValue("@iDate", iDate)
            objDerived.cmd.Parameters.AddWithValue("@DateRegistered", DateRegistered)
            objDerived.cmd.Parameters.AddWithValue("@CadastralNo", CadastralNo)
            objDerived.cmd.Parameters.AddWithValue("@BrgyBounderyMonu", BrgyBounderyMonu)
            objDerived.cmd.Parameters.AddWithValue("@North", North)
            objDerived.cmd.Parameters.AddWithValue("@East", East)
            objDerived.cmd.Parameters.AddWithValue("@South", South)
            objDerived.cmd.Parameters.AddWithValue("@West", West)
            objDerived.cmd.Parameters.AddWithValue("@StartingPt", StartingPt)
            objDerived.cmd.Parameters.AddWithValue("@EndingPt", EndingPt)
            objDerived.cmd.Parameters.AddWithValue("@NS", NS)
            objDerived.cmd.Parameters.AddWithValue("@NS1", NS1)
            objDerived.cmd.Parameters.AddWithValue("@NS2", NS2)
            objDerived.cmd.Parameters.AddWithValue("@WE", WE)
            objDerived.cmd.Parameters.AddWithValue("@mDistance", mDistance)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbLand_TechDescription", CommandType.StoredProcedure, Nothing)
            Return i

        End Function
        Public Function update() As Long

            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@TechDescriptionId", TechDescriptionId)
            objDerived.cmd.Parameters.AddWithValue("@LandId", LandId)
            objDerived.cmd.Parameters.AddWithValue("@OctNo", OctNo)
            objDerived.cmd.Parameters.AddWithValue("@TctNo", TctNo)
            objDerived.cmd.Parameters.AddWithValue("@iDate", iDate)
            objDerived.cmd.Parameters.AddWithValue("@DateRegistered", DateRegistered)
            objDerived.cmd.Parameters.AddWithValue("@CadastralNo", CadastralNo)
            objDerived.cmd.Parameters.AddWithValue("@BrgyBounderyMonu", BrgyBounderyMonu)
            objDerived.cmd.Parameters.AddWithValue("@North", North)
            objDerived.cmd.Parameters.AddWithValue("@East", East)
            objDerived.cmd.Parameters.AddWithValue("@South", South)
            objDerived.cmd.Parameters.AddWithValue("@West", West)
            objDerived.cmd.Parameters.AddWithValue("@StartingPt", StartingPt)
            objDerived.cmd.Parameters.AddWithValue("@EndingPt", EndingPt)
            objDerived.cmd.Parameters.AddWithValue("@NS", NS)
            objDerived.cmd.Parameters.AddWithValue("@NS1", NS1)
            objDerived.cmd.Parameters.AddWithValue("@NS2", NS2)
            objDerived.cmd.Parameters.AddWithValue("@WE", WE)
            objDerived.cmd.Parameters.AddWithValue("@mDistance", mDistance)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbLand_TechDescription", CommandType.StoredProcedure, Nothing)
            Return i

        End Function
    End Class


#End Region
#Region "TbLand_LandDocu"
    Public Class TbLand_LandDocu
        Inherits BaseDLL.BaseDAL

        Private pLandDocuId As Long
        Public Property LandDocuId() As Long
            Get
                Return pLandDocuId
            End Get
            Set(ByVal value As Long)
                pLandDocuId = value
            End Set
        End Property

        Private pLandId As Long
        Public Property LandId() As Long
            Get
                Return pLandId
            End Get
            Set(ByVal value As Long)
                pLandId = value
            End Set
        End Property

        Private pIdentityNo As Integer
        Public Property IdentityNo() As Integer
            Get
                Return pIdentityNo
            End Get
            Set(ByVal value As Integer)
                pIdentityNo = value
            End Set
        End Property

        Private pAgency As String
        Public Property Agency() As String
            Get
                Return pAgency
            End Get
            Set(ByVal value As String)
                pAgency = value
            End Set
        End Property

        Private pImagefile As Byte()
        Public Property Imagefile() As Byte()
            Get
                Return pImagefile
            End Get
            Set(ByVal value As Byte())
                pImagefile = value
            End Set
        End Property

        Private pDocumentName As String
        Public Property DocumentName() As String
            Get
                Return pDocumentName
            End Get
            Set(ByVal value As String)
                pDocumentName = value
            End Set
        End Property

        Private pDocumentNo As String
        Public Property DocumentNo() As String
            Get
                Return pDocumentNo
            End Get
            Set(ByVal value As String)
                pDocumentNo = value
            End Set
        End Property

        Private pValidatedBy As String
        Public Property ValidatedBy() As String
            Get
                Return pValidatedBy
            End Get
            Set(ByVal value As String)
                pValidatedBy = value
            End Set
        End Property

        Private pDateValidated As Date
        Public Property DateValidated() As Date
            Get
                Return pDateValidated
            End Get
            Set(ByVal value As Date)
                pDateValidated = value
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
        Private pTableName As String
        Public Property TableName() As String
            Get
                Return pTableName
            End Get
            Set(ByVal value As String)
                pTableName = value
            End Set
        End Property

        Public Function SaveImage() As Long

            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@LandDocuId", 0)
            objDerived.cmd.Parameters.AddWithValue("@LandId", LandId)
            objDerived.cmd.Parameters.AddWithValue("@IdentityNo", IdentityNo)
            objDerived.cmd.Parameters.AddWithValue("@Agency", Agency)
            objDerived.cmd.Parameters.AddWithValue("@ImageFile", Imagefile)
            objDerived.cmd.Parameters.AddWithValue("@DocumentName", DocumentName)
            objDerived.cmd.Parameters.AddWithValue("@DocumentNo", DocumentNo)
            objDerived.cmd.Parameters.AddWithValue("@ValidatedBy", ValidatedBy)
            objDerived.cmd.Parameters.AddWithValue("@DateValidated", DateValidated)
            objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
            objDerived.cmd.Parameters.AddWithValue("@TableName", TableName)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbLand_LandDocu", CommandType.StoredProcedure, Nothing)
            Return i

        End Function
        Public Function UpdateImage() As Long

            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@LandDocuId", LandDocuId)
            objDerived.cmd.Parameters.AddWithValue("@LandId", LandId)
            objDerived.cmd.Parameters.AddWithValue("@IdentityNo", IdentityNo)
            objDerived.cmd.Parameters.AddWithValue("@Agency", Agency)
            objDerived.cmd.Parameters.AddWithValue("@ImageFile", Imagefile)
            objDerived.cmd.Parameters.AddWithValue("@DocumentName", DocumentName)
            objDerived.cmd.Parameters.AddWithValue("@DocumentNo", DocumentNo)
            objDerived.cmd.Parameters.AddWithValue("@ValidatedBy", ValidatedBy)
            objDerived.cmd.Parameters.AddWithValue("@DateValidated", DateValidated)
            objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
            objDerived.cmd.Parameters.AddWithValue("@TableName", TableName)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbLand_LandDocu", CommandType.StoredProcedure, Nothing)
            Return i

        End Function
    End Class



#End Region
#Region "TbLand_OwnerHistory"
    Public Class TbLand_OwnerHistory
        Inherits BaseDLL.BaseDAL

        Private pOwnershipId As Long
        Public Property OwnershipId() As Long
            Get
                Return pOwnershipId
            End Get
            Set(ByVal value As Long)
                pOwnershipId = value
            End Set
        End Property

        Private pLandId As Long
        Public Property LandId() As Long
            Get
                Return pLandId
            End Get
            Set(ByVal value As Long)
                pLandId = value
            End Set
        End Property

        Private pYear As Date
        Public Property Year() As Date
            Get
                Return pYear
            End Get
            Set(ByVal value As Date)
                pYear = value
            End Set
        End Property

        Private pOwnerName As String
        Public Property OwnerName() As String
            Get
                Return pOwnerName
            End Get
            Set(ByVal value As String)
                pOwnerName = value
            End Set
        End Property


        Private pOwnerType As String
        Public Property OwnerType() As String
            Get
                Return pOwnerType
            End Get
            Set(ByVal value As String)
                pOwnerType = value
            End Set
        End Property

        Private pAddress As String
        Public Property Address() As String
            Get
                Return pAddress
            End Get
            Set(ByVal value As String)
                pAddress = value
            End Set
        End Property

        Private pTypeAcquisition As String
        Public Property TypeAcquisition() As String
            Get
                Return pTypeAcquisition
            End Get
            Set(ByVal value As String)
                pTypeAcquisition = value
            End Set
        End Property

        Private pCorporationName As String
        Public Property CorporationName() As String
            Get
                Return pCorporationName
            End Get
            Set(ByVal value As String)
                pCorporationName = value
            End Set
        End Property

        Private pCorporationAddress As String
        Public Property CorporationAddress() As String
            Get
                Return pCorporationAddress
            End Get
            Set(ByVal value As String)
                pCorporationAddress = value
            End Set
        End Property

        Private pTelephoneNo As String
        Public Property TelephoneNo() As String
            Get
                Return pTelephoneNo
            End Get
            Set(ByVal value As String)
                pTelephoneNo = value
            End Set
        End Property

        Private pCellphoneNo As String
        Public Property CellphoneNo() As String
            Get
                Return pCellphoneNo
            End Get
            Set(ByVal value As String)
                pCellphoneNo = value
            End Set
        End Property

        Private pEmailAddress As String
        Public Property EmailAddress() As String
            Get
                Return pEmailAddress
            End Get
            Set(ByVal value As String)
                pEmailAddress = value
            End Set
        End Property

        Private pChairman As String
        Public Property Chairman() As String
            Get
                Return pChairman
            End Get
            Set(ByVal value As String)
                pChairman = value
            End Set
        End Property

        Private pViceChairman As String
        Public Property ViceChairman() As String
            Get
                Return pViceChairman
            End Get
            Set(ByVal value As String)
                pViceChairman = value
            End Set
        End Property

        Private pPresident As String
        Public Property President() As String
            Get
                Return pPresident
            End Get
            Set(ByVal value As String)
                pPresident = value
            End Set
        End Property

        Private pSeniorVicePresident As String
        Public Property SeniorVicePresident() As String
            Get
                Return pSeniorVicePresident
            End Get
            Set(ByVal value As String)
                pSeniorVicePresident = value
            End Set
        End Property

        Private pVicePresident As String
        Public Property VicePresident() As String
            Get
                Return pVicePresident
            End Get
            Set(ByVal value As String)
                pVicePresident = value
            End Set
        End Property

        Private pAssistantVicePresident As String
        Public Property AssistantVicePresident() As String
            Get
                Return pAssistantVicePresident
            End Get
            Set(ByVal value As String)
                pAssistantVicePresident = value
            End Set
        End Property


        Private pCorporateSecretary As String
        Public Property CorporateSecretary() As String
            Get
                Return pCorporateSecretary
            End Get
            Set(ByVal value As String)
                pCorporateSecretary = value
            End Set
        End Property
        Public Function save() As Long

            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@OwnershipId", 0)
            objDerived.cmd.Parameters.AddWithValue("@LandId", LandId)
            objDerived.cmd.Parameters.AddWithValue("@Year", Year)
            objDerived.cmd.Parameters.AddWithValue("@OwnerName", OwnerName)
            objDerived.cmd.Parameters.AddWithValue("@OwnerType", OwnerType)
            objDerived.cmd.Parameters.AddWithValue("@Address", Address)
            objDerived.cmd.Parameters.AddWithValue("@TypeAcquisition", TypeAcquisition)
            objDerived.cmd.Parameters.AddWithValue("@CorporationName", CorporationName)
            objDerived.cmd.Parameters.AddWithValue("@CorporationAddress", CorporationAddress)
            objDerived.cmd.Parameters.AddWithValue("@TelephoneNo", TelephoneNo)
            objDerived.cmd.Parameters.AddWithValue("@CellphoneNo", CellphoneNo)
            objDerived.cmd.Parameters.AddWithValue("@EmailAddress", EmailAddress)
            objDerived.cmd.Parameters.AddWithValue("@Chairman", Chairman)
            objDerived.cmd.Parameters.AddWithValue("@ViceChairman", ViceChairman)
            objDerived.cmd.Parameters.AddWithValue("@President", President)
            objDerived.cmd.Parameters.AddWithValue("@SeniorVicePresident", SeniorVicePresident)
            objDerived.cmd.Parameters.AddWithValue("@VicePresident", VicePresident)
            objDerived.cmd.Parameters.AddWithValue("@AssistantVicePresident", AssistantVicePresident)
            objDerived.cmd.Parameters.AddWithValue("@CorporateSecretary", CorporateSecretary)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbLand_OwnerHistory", CommandType.StoredProcedure, Nothing)
            Return i

        End Function
        Public Function update() As Long

            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@OwnershipId", OwnershipId)
            objDerived.cmd.Parameters.AddWithValue("@LandId", LandId)
            objDerived.cmd.Parameters.AddWithValue("@Year", Year)
            objDerived.cmd.Parameters.AddWithValue("@OwnerName", OwnerName)
            objDerived.cmd.Parameters.AddWithValue("@OwnerType", OwnerType)
            objDerived.cmd.Parameters.AddWithValue("@Address", Address)
            objDerived.cmd.Parameters.AddWithValue("@TypeAcquisition", TypeAcquisition)
            objDerived.cmd.Parameters.AddWithValue("@CorporationName", CorporationName)
            objDerived.cmd.Parameters.AddWithValue("@CorporationAddress", CorporationAddress)
            objDerived.cmd.Parameters.AddWithValue("@TelephoneNo", TelephoneNo)
            objDerived.cmd.Parameters.AddWithValue("@CellphoneNo", CellphoneNo)
            objDerived.cmd.Parameters.AddWithValue("@EmailAddress", EmailAddress)
            objDerived.cmd.Parameters.AddWithValue("@Chairman", Chairman)
            objDerived.cmd.Parameters.AddWithValue("@ViceChairman", ViceChairman)
            objDerived.cmd.Parameters.AddWithValue("@President", President)
            objDerived.cmd.Parameters.AddWithValue("@SeniorVicePresident", SeniorVicePresident)
            objDerived.cmd.Parameters.AddWithValue("@VicePresident", VicePresident)
            objDerived.cmd.Parameters.AddWithValue("@AssistantVicePresident", AssistantVicePresident)
            objDerived.cmd.Parameters.AddWithValue("@CorporateSecretary", CorporateSecretary)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbLand_OwnerHistory", CommandType.StoredProcedure, Nothing)
            Return i

        End Function

    End Class
#End Region
#Region "TbLand_Valuation"
    Public Class TbLand_Valuation
        Inherits BaseDLL.BaseDAL

        Private pValuationId As Long
        Public Property ValuationId() As Long
            Get
                Return pValuationId
            End Get
            Set(ByVal value As Long)
                pValuationId = value
            End Set
        End Property

        Private pLandId As Long
        Public Property LandId() As Long
            Get
                Return pLandId
            End Get
            Set(ByVal value As Long)
                pLandId = value
            End Set
        End Property

        Private pClassification As String
        Public Property Classification() As String
            Get
                Return pClassification
            End Get
            Set(ByVal value As String)
                pClassification = value
            End Set
        End Property

        Private pSubClassification As String
        Public Property SubClassification() As String
            Get
                Return pSubClassification
            End Get
            Set(ByVal value As String)
                pSubClassification = value
            End Set
        End Property

        Private pArea As String
        Public Property Area() As String
            Get
                Return pArea
            End Get
            Set(ByVal value As String)
                pArea = value
            End Set
        End Property

        Private pUnit As String
        Public Property Unit() As String
            Get
                Return pUnit
            End Get
            Set(ByVal value As String)
                pUnit = value
            End Set
        End Property

        Private pUnitValue As String
        Public Property UnitValue() As String
            Get
                Return pUnitValue
            End Get
            Set(ByVal value As String)
                pUnitValue = value
            End Set
        End Property

        Private pBaseMarketValue As String
        Public Property BaseMarketValue() As String
            Get
                Return pBaseMarketValue
            End Get
            Set(ByVal value As String)
                pBaseMarketValue = value
            End Set
        End Property

        Private pTaxable As String
        Public Property Taxable() As String
            Get
                Return pTaxable
            End Get
            Set(ByVal value As String)
                pTaxable = value
            End Set
        End Property

        Private pAdjustments As String
        Public Property Adjustments() As String
            Get
                Return pAdjustments
            End Get
            Set(ByVal value As String)
                pAdjustments = value
            End Set
        End Property

        Private pAdjustedMarketValue As Decimal
        Public Property AdjustedMarketValue() As Decimal
            Get
                Return pAdjustedMarketValue
            End Get
            Set(ByVal value As Decimal)
                pAdjustedMarketValue = value
            End Set
        End Property

        Private pStrip As String
        Public Property Strip() As String
            Get
                Return pStrip
            End Get
            Set(ByVal value As String)
                pStrip = value
            End Set
        End Property

        Private pAdjUnitValue As String
        Public Property AdjUnitValue() As String
            Get
                Return pAdjUnitValue
            End Get
            Set(ByVal value As String)
                pAdjUnitValue = value
            End Set
        End Property
        Public Function save() As Long

            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@ValuationId", 0)
            objDerived.cmd.Parameters.AddWithValue("@LandId", LandId)
            objDerived.cmd.Parameters.AddWithValue("@Classification", Classification)
            objDerived.cmd.Parameters.AddWithValue("@SubClassification", SubClassification)
            objDerived.cmd.Parameters.AddWithValue("@Area", Area)
            objDerived.cmd.Parameters.AddWithValue("@Unit", Unit)
            objDerived.cmd.Parameters.AddWithValue("@UnitValue", UnitValue)
            objDerived.cmd.Parameters.AddWithValue("@BaseMarketValue", BaseMarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Taxable", Taxable)
            objDerived.cmd.Parameters.AddWithValue("@Adjustments", Adjustments)
            objDerived.cmd.Parameters.AddWithValue("@AdjustedMarketValue", AdjustedMarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Strip", Strip)
            objDerived.cmd.Parameters.AddWithValue("@AdjUnitValue", AdjUnitValue)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbLand_Valuation", CommandType.StoredProcedure, Nothing)
            Return i

        End Function
        Public Function update() As Long

            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@ValuationId", ValuationId)
            objDerived.cmd.Parameters.AddWithValue("@LandId", LandId)
            objDerived.cmd.Parameters.AddWithValue("@Classification", Classification)
            objDerived.cmd.Parameters.AddWithValue("@SubClassification", SubClassification)
            objDerived.cmd.Parameters.AddWithValue("@Area", Area)
            objDerived.cmd.Parameters.AddWithValue("@Unit", Unit)
            objDerived.cmd.Parameters.AddWithValue("@UnitValue", UnitValue)
            objDerived.cmd.Parameters.AddWithValue("@BaseMarketValue", BaseMarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Taxable", Taxable)
            objDerived.cmd.Parameters.AddWithValue("@Adjustments", Adjustments)
            objDerived.cmd.Parameters.AddWithValue("@AdjustedMarketValue", AdjustedMarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Strip", Strip)
            objDerived.cmd.Parameters.AddWithValue("@AdjUnitValue", AdjUnitValue)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbLand_Valuation", CommandType.StoredProcedure, Nothing)
            Return i

        End Function













    End Class
#End Region
#Region "TbLand_Improvements"
    Public Class TbLand_Improvements
        Inherits BaseDLL.BaseDAL


        Private pImprovementId As Long
        Public Property ImprovementId() As Long
            Get
                Return pImprovementId
            End Get
            Set(ByVal value As Long)
                pImprovementId = value
            End Set
        End Property

        Private pLandId As Long
        Public Property LandId() As Long
            Get
                Return pLandId
            End Get
            Set(ByVal value As Long)
                pLandId = value
            End Set
        End Property

        Private pkind As String
        Public Property kind() As String
            Get
                Return pkind
            End Get
            Set(ByVal value As String)
                pkind = value
            End Set
        End Property


        Private pQty As String
        Public Property Qty() As String
            Get
                Return pQty
            End Get
            Set(ByVal value As String)
                pQty = value
            End Set
        End Property

        Private pUnitValue As String
        Public Property UnitValue() As String
            Get
                Return pUnitValue
            End Get
            Set(ByVal value As String)
                pUnitValue = value
            End Set
        End Property

        Private pBaseMarketValue As String
        Public Property BaseMarketValue() As String
            Get
                Return pBaseMarketValue
            End Get
            Set(ByVal value As String)
                pBaseMarketValue = value
            End Set
        End Property

        Private pTaxable As String
        Public Property Taxable() As String
            Get
                Return pTaxable
            End Get
            Set(ByVal value As String)
                pTaxable = value
            End Set
        End Property

        Private pSubClass As String
        Public Property SubClass() As String
            Get
                Return pSubClass
            End Get
            Set(ByVal value As String)
                pSubClass = value
            End Set
        End Property

        Private pType As String
        Public Property Type() As String
            Get
                Return pType
            End Get
            Set(ByVal value As String)
                pType = value
            End Set
        End Property

        Private pAssessmentLevel As String
        Public Property AssessmentLevel() As String
            Get
                Return pAssessmentLevel
            End Get
            Set(ByVal value As String)
                pAssessmentLevel = value
            End Set
        End Property

        Private pActualUse As String
        Public Property ActualUse() As String
            Get
                Return pActualUse
            End Get
            Set(ByVal value As String)
                pActualUse = value
            End Set
        End Property

        Private pLandImprovement As String
        Public Property LandImprovement() As String
            Get
                Return pLandImprovement
            End Get
            Set(ByVal value As String)
                pLandImprovement = value
            End Set
        End Property
        Public Function save() As Long

            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@ImprovementId", 0)
            objDerived.cmd.Parameters.AddWithValue("@LandId", LandId)
            objDerived.cmd.Parameters.AddWithValue("@kind", kind)
            objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
            objDerived.cmd.Parameters.AddWithValue("@UnitValue", UnitValue)
            objDerived.cmd.Parameters.AddWithValue("@BaseMarketValue", BaseMarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Taxable", Taxable)
            objDerived.cmd.Parameters.AddWithValue("@SubClass", SubClass)
            objDerived.cmd.Parameters.AddWithValue("@Type", Type)
            objDerived.cmd.Parameters.AddWithValue("@AssessmentLevel", AssessmentLevel)
            objDerived.cmd.Parameters.AddWithValue("@ActualUse", ActualUse)
            objDerived.cmd.Parameters.AddWithValue("@LandImprovement", LandImprovement)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbLand_Improvements", CommandType.StoredProcedure, Nothing)
            Return i

        End Function
        Public Function uodate() As Long

            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@ImprovementId", ImprovementId)
            objDerived.cmd.Parameters.AddWithValue("@LandId", LandId)
            objDerived.cmd.Parameters.AddWithValue("@kind", kind)
            objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
            objDerived.cmd.Parameters.AddWithValue("@UnitValue", UnitValue)
            objDerived.cmd.Parameters.AddWithValue("@BaseMarketValue", BaseMarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Taxable", Taxable)
            objDerived.cmd.Parameters.AddWithValue("@SubClass", SubClass)
            objDerived.cmd.Parameters.AddWithValue("@Type", Type)
            objDerived.cmd.Parameters.AddWithValue("@AssessmentLevel", AssessmentLevel)
            objDerived.cmd.Parameters.AddWithValue("@ActualUse", ActualUse)
            objDerived.cmd.Parameters.AddWithValue("@LandImprovement", LandImprovement)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbLand_Improvements", CommandType.StoredProcedure, Nothing)
            Return i

        End Function

























    End Class
#End Region
#Region "TbLand_PropertyHistory"
    Public Class TbLand_PropertyHistory
        Inherits BaseDLL.BaseDAL


        Private pPropertyHistoryId As Long
        Public Property PropertyHistoryId() As Long
            Get
                Return pPropertyHistoryId
            End Get
            Set(ByVal value As Long)
                pPropertyHistoryId = value
            End Set
        End Property


        Private pLandId As Long
        Public Property LandId() As Long
            Get
                Return pLandId
            End Get
            Set(ByVal value As Long)
                pLandId = value
            End Set
        End Property

        Private pPreviousOwner As String
        Public Property PreviousOwner() As String
            Get
                Return pPreviousOwner
            End Get
            Set(ByVal value As String)
                pPreviousOwner = value
            End Set
        End Property

        Private pCancelledTdn As String
        Public Property CancelledTdn() As String
            Get
                Return pCancelledTdn
            End Get
            Set(ByVal value As String)
                pCancelledTdn = value
            End Set
        End Property

        Private pIsMigrated As String
        Public Property IsMigrated() As String
            Get
                Return pIsMigrated
            End Get
            Set(ByVal value As String)
                pIsMigrated = value
            End Set
        End Property

        Private pPinBackup As String
        Public Property PinBackup() As String
            Get
                Return pPinBackup
            End Get
            Set(ByVal value As String)
                pPinBackup = value
            End Set
        End Property

        Private pCsDatemigrated As Date
        Public Property CsDatemigrated() As Date
            Get
                Return pCsDatemigrated
            End Get
            Set(ByVal value As Date)
                pCsDatemigrated = value
            End Set
        End Property

        Private pPreviousTdnid As String
        Public Property PreviousTdnid() As String
            Get
                Return pPreviousTdnid
            End Get
            Set(ByVal value As String)
                pPreviousTdnid = value
            End Set
        End Property

        Private pIsFromTransaction As String
        Public Property IsFromTransaction() As String
            Get
                Return pIsFromTransaction
            End Get
            Set(ByVal value As String)
                pIsFromTransaction = value
            End Set
        End Property

        Private pEncodedBy As String
        Public Property EncodedBy() As String
            Get
                Return pEncodedBy
            End Get
            Set(ByVal value As String)
                pEncodedBy = value
            End Set
        End Property


        Private pLastUpdatedBy As String
        Public Property LastUpdatedBy() As String
            Get
                Return pLastUpdatedBy
            End Get
            Set(ByVal value As String)
                pLastUpdatedBy = value
            End Set
        End Property

        Private pDateLastUpdated As Date
        Public Property DateLastUpdated() As Date
            Get
                Return pDateLastUpdated
            End Get
            Set(ByVal value As Date)
                pDateLastUpdated = value
            End Set
        End Property

        Private pCancelledBy As String
        Public Property CancelledBy() As String
            Get
                Return pCancelledBy
            End Get
            Set(ByVal value As String)
                pCancelledBy = value
            End Set
        End Property


        Private pOtherPreviousPin As String
        Public Property OtherPreviousPin() As String
            Get
                Return pOtherPreviousPin
            End Get
            Set(ByVal value As String)
                pOtherPreviousPin = value
            End Set
        End Property

        Private pOtherPreviousTdn As String
        Public Property OtherPreviousTdn() As String
            Get
                Return pOtherPreviousTdn
            End Get
            Set(ByVal value As String)
                pOtherPreviousTdn = value
            End Set
        End Property


        Private pStartYear As String
        Public Property StartYear() As String
            Get
                Return pStartYear
            End Get
            Set(ByVal value As String)
                pStartYear = value
            End Set
        End Property

        Private pDateRegistration As Date
        Public Property DateRegistration() As Date
            Get
                Return pDateRegistration
            End Get
            Set(ByVal value As Date)
                pDateRegistration = value
            End Set
        End Property

        Private pTotalAssessedValue As String
        Public Property TotalAssessedValue() As String
            Get
                Return pTotalAssessedValue
            End Get
            Set(ByVal value As String)
                pTotalAssessedValue = value
            End Set
        End Property


        Private pRecordingPerson As String
        Public Property RecordingPerson() As String
            Get
                Return pRecordingPerson
            End Get
            Set(ByVal value As String)
                pRecordingPerson = value
            End Set
        End Property

        Private pEndYear As String
        Public Property EndYear() As String
            Get
                Return pEndYear
            End Get
            Set(ByVal value As String)
                pEndYear = value
            End Set
        End Property

        Private pDateCancelled As Date
        Public Property DateCancelled() As Date
            Get
                Return pDateCancelled
            End Get
            Set(ByVal value As Date)
                pDateCancelled = value
            End Set
        End Property


        Private pTotalMarketValue As String
        Public Property TotalMarketValue() As String
            Get
                Return pTotalMarketValue
            End Get
            Set(ByVal value As String)
                pTotalMarketValue = value
            End Set
        End Property

        Private pDateRecorded As String
        Public Property DateRecorded() As String
            Get
                Return pDateRecorded
            End Get
            Set(ByVal value As String)
                pDateRecorded = value
            End Set
        End Property
        Public Function save() As Long

            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@PropertyHistoryId", 0)
            objDerived.cmd.Parameters.AddWithValue("@LandId", LandId)
            objDerived.cmd.Parameters.AddWithValue("@PreviousOwner", PreviousOwner)
            objDerived.cmd.Parameters.AddWithValue("@CancelledTdn ", CancelledTdn)
            objDerived.cmd.Parameters.AddWithValue("@IsMigrated", IsMigrated)
            objDerived.cmd.Parameters.AddWithValue("@PinBackup", PinBackup)
            objDerived.cmd.Parameters.AddWithValue("@CsDatemigrated", CsDatemigrated)
            objDerived.cmd.Parameters.AddWithValue("@PreviousTdnid", PreviousTdnid)
            objDerived.cmd.Parameters.AddWithValue("@IsFromTransaction", IsFromTransaction)
            objDerived.cmd.Parameters.AddWithValue("@EncodedBy", EncodedBy)
            objDerived.cmd.Parameters.AddWithValue("@LastUpdatedBy ", LastUpdatedBy)
            objDerived.cmd.Parameters.AddWithValue("@DateLastUpdated", DateLastUpdated)
            objDerived.cmd.Parameters.AddWithValue("@CancelledBy", CancelledBy)
            objDerived.cmd.Parameters.AddWithValue("@OtherPreviousPin", OtherPreviousPin)
            objDerived.cmd.Parameters.AddWithValue("@OtherPreviousTdn", OtherPreviousTdn)
            objDerived.cmd.Parameters.AddWithValue("@StartYear", StartYear)
            objDerived.cmd.Parameters.AddWithValue("@DateRegistration", DateRegistration)
            objDerived.cmd.Parameters.AddWithValue("@TotalAssessedValue", TotalAssessedValue)
            objDerived.cmd.Parameters.AddWithValue("@RecordingPerson", RecordingPerson)
            objDerived.cmd.Parameters.AddWithValue("@EndYear", EndYear)
            objDerived.cmd.Parameters.AddWithValue("@DateCancelled", DateCancelled)
            objDerived.cmd.Parameters.AddWithValue("@TotalMarketValue ", TotalMarketValue)
            objDerived.cmd.Parameters.AddWithValue("@DateRecorded", DateRecorded)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbLand_PropertyHistory", CommandType.StoredProcedure, Nothing)
            Return i

        End Function
        Public Function update() As Long

            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@PropertyHistoryId", PropertyHistoryId)
            objDerived.cmd.Parameters.AddWithValue("@LandId", LandId)
            objDerived.cmd.Parameters.AddWithValue("@PreviousOwner", PreviousOwner)
            objDerived.cmd.Parameters.AddWithValue("@CancelledTdn ", CancelledTdn)
            objDerived.cmd.Parameters.AddWithValue("@IsMigrated", IsMigrated)
            objDerived.cmd.Parameters.AddWithValue("@PinBackup", PinBackup)
            objDerived.cmd.Parameters.AddWithValue("@CsDatemigrated", CsDatemigrated)
            objDerived.cmd.Parameters.AddWithValue("@PreviousTdnid", PreviousTdnid)
            objDerived.cmd.Parameters.AddWithValue("@IsFromTransaction", IsFromTransaction)
            objDerived.cmd.Parameters.AddWithValue("@EncodedBy", EncodedBy)
            objDerived.cmd.Parameters.AddWithValue("@LastUpdatedBy ", LastUpdatedBy)
            objDerived.cmd.Parameters.AddWithValue("@DateLastUpdated", DateLastUpdated)
            objDerived.cmd.Parameters.AddWithValue("@CancelledBy", CancelledBy)
            objDerived.cmd.Parameters.AddWithValue("@OtherPreviousPin", OtherPreviousPin)
            objDerived.cmd.Parameters.AddWithValue("@OtherPreviousTdn", OtherPreviousTdn)
            objDerived.cmd.Parameters.AddWithValue("@StartYear", StartYear)
            objDerived.cmd.Parameters.AddWithValue("@DateRegistration", DateRegistration)
            objDerived.cmd.Parameters.AddWithValue("@TotalAssessedValue", TotalAssessedValue)
            objDerived.cmd.Parameters.AddWithValue("@RecordingPerson", RecordingPerson)
            objDerived.cmd.Parameters.AddWithValue("@EndYear", EndYear)
            objDerived.cmd.Parameters.AddWithValue("@DateCancelled", DateCancelled)
            objDerived.cmd.Parameters.AddWithValue("@TotalMarketValue ", TotalMarketValue)
            objDerived.cmd.Parameters.AddWithValue("@DateRecorded", DateRecorded)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbLand_PropertyHistory", CommandType.StoredProcedure, Nothing)
            Return i

        End Function




































































    End Class
#End Region

    'BUILDING
#Region "TbBuilding_Dtl"

    Public Class TBBuilding_Details
        Inherits BaseDLL.BaseDAL

        Private pBuildingId As Long
        Public Property BuildingId() As Long
            Get
                Return pBuildingId
            End Get
            Set(ByVal value As Long)
                pBuildingId = value
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

        Private pBuildingControlNo As String
        Public Property BuildingControlNo() As String
            Get
                Return pBuildingControlNo
            End Get
            Set(ByVal value As String)
                pBuildingControlNo = value
            End Set
        End Property

        Private pBuildingCode As String
        Public Property BuildingCode() As String
            Get
                Return pBuildingCode
            End Get
            Set(ByVal value As String)
                pBuildingCode = value
            End Set
        End Property

        Private pBuildingName As String
        Public Property BuildingName() As String
            Get
                Return pBuildingName
            End Get
            Set(ByVal value As String)
                pBuildingName = value
            End Set
        End Property

        Private pAddress As String
        Public Property Address() As String
            Get
                Return pAddress
            End Get
            Set(ByVal value As String)
                pAddress = value
            End Set
        End Property

        Private pPostalCode As String
        Public Property PostalCode() As String
            Get
                Return pPostalCode
            End Get
            Set(ByVal value As String)
                pPostalCode = value
            End Set
        End Property

        Private pBuildingDepreciationRate As Decimal
        Public Property BuildingDepreciationRate() As Decimal
            Get
                Return pBuildingDepreciationRate
            End Get
            Set(ByVal value As Decimal)
                pBuildingDepreciationRate = value
            End Set
        End Property

        Private pBuildingUse As String
        Public Property BuildingUse() As String
            Get
                Return pBuildingUse
            End Get
            Set(ByVal value As String)
                pBuildingUse = value
            End Set
        End Property

        Private pBuildingOccupancy As String
        Public Property BuildingOccupancy() As String
            Get
                Return pBuildingOccupancy
            End Get
            Set(ByVal value As String)
                pBuildingOccupancy = value
            End Set
        End Property

        Private pNumberFloors As String
        Public Property NumberFloors() As String
            Get
                Return pNumberFloors
            End Get
            Set(ByVal value As String)
                pNumberFloors = value
            End Set
        End Property

        Private pAvgAreaFloor As String
        Public Property AvgAreaFloor() As String
            Get
                Return pAvgAreaFloor
            End Get
            Set(ByVal value As String)
                pAvgAreaFloor = value
            End Set
        End Property

        Private pCostPerArea As String
        Public Property CostPerArea() As String
            Get
                Return pCostPerArea
            End Get
            Set(ByVal value As String)
                pCostPerArea = value
            End Set
        End Property

        Private pBuildingDepreciationValue As Decimal
        Public Property BuildingDepreciationValue() As Decimal
            Get
                Return pBuildingDepreciationValue
            End Get
            Set(ByVal value As Decimal)
                pBuildingDepreciationValue = value
            End Set
        End Property

        Private pDateTaken As Date
        Public Property DateTaken() As Date
            Get
                Return pDateTaken
            End Get
            Set(ByVal value As Date)
                pDateTaken = value
            End Set
        End Property

        Private pUploadedBy As String
        Public Property UploadedBy() As String
            Get
                Return pUploadedBy
            End Get
            Set(ByVal value As String)
                pUploadedBy = value
            End Set
        End Property

        Private pPosition As String
        Public Property Position() As String
            Get
                Return pPosition
            End Get
            Set(ByVal value As String)
                pPosition = value
            End Set
        End Property

        Private pMarketValue As Decimal
        Public Property MarketValue() As Decimal
            Get
                Return pMarketValue
            End Get
            Set(ByVal value As Decimal)
                pMarketValue = value
            End Set
        End Property

        Private pStatus_AIR As String
        Public Property Status_AIR() As String
            Get
                Return pStatus_AIR
            End Get
            Set(ByVal value As String)
                pStatus_AIR = value
            End Set
        End Property

        Private pReceived_ID As String
        Public Property Received_ID() As String
            Get
                Return pReceived_ID
            End Get
            Set(ByVal value As String)
                pReceived_ID = value
            End Set
        End Property

        Private pBarangay As String
        Public Property Barangay() As String
            Get
                Return pBarangay
            End Get
            Set(ByVal value As String)
                pBarangay = value
            End Set
        End Property


        Private pArea As String
        Public Property Area() As String
            Get
                Return pArea
            End Get
            Set(ByVal value As String)
                pArea = value
            End Set
        End Property

        Private pTaxDeclarationNo As String
        Public Property TaxDeclarationNo() As String
            Get
                Return pTaxDeclarationNo
            End Get
            Set(ByVal value As String)
                pTaxDeclarationNo = value
            End Set
        End Property

        Private pNoofYears As Long
        Public Property NoofYears() As Long
            Get
                Return pNoofYears
            End Get
            Set(ByVal value As Long)
                pNoofYears = value
            End Set
        End Property

        Private pUsefulLife As Long
        Public Property UsefulLife() As Long
            Get
                Return pUsefulLife
            End Get
            Set(ByVal value As Long)
                pUsefulLife = value
            End Set
        End Property

        Private pSalvageValue As Long
        Public Property SalvageValue() As Long
            Get
                Return pSalvageValue
            End Get
            Set(ByVal value As Long)
                pSalvageValue = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@BuildingId", 0)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@BuildingControlNo", BuildingControlNo)
            objDerived.cmd.Parameters.AddWithValue("@BuildingCode", BuildingCode)
            objDerived.cmd.Parameters.AddWithValue("@BuildingName", BuildingName)
            objDerived.cmd.Parameters.AddWithValue("@Address", Address)
            objDerived.cmd.Parameters.AddWithValue("@PostalCode", PostalCode)
            objDerived.cmd.Parameters.AddWithValue("@BuildingDepreciationRate", BuildingDepreciationRate)
            objDerived.cmd.Parameters.AddWithValue("@BuildingUse", BuildingUse)
            objDerived.cmd.Parameters.AddWithValue("@BuildingOccupancy", BuildingOccupancy)
            objDerived.cmd.Parameters.AddWithValue("@NumberFloors", NumberFloors)
            objDerived.cmd.Parameters.AddWithValue("@AvgAreaFloor", AvgAreaFloor)
            objDerived.cmd.Parameters.AddWithValue("@CostPerArea", CostPerArea)
            objDerived.cmd.Parameters.AddWithValue("@BuildingDepreciationValue", BuildingDepreciationValue)
            'objDerived.cmd.Parameters.AddWithValue("@DateTaken", DateTaken)
            'objDerived.cmd.Parameters.AddWithValue("@UploadedBy", UploadedBy)
            'objDerived.cmd.Parameters.AddWithValue("@Position", Position)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Status_AIR", Status_AIR)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@Barangay", Barangay)
            objDerived.cmd.Parameters.AddWithValue("@Area", Area)
            objDerived.cmd.Parameters.AddWithValue("@TaxDeclarationNo", TaxDeclarationNo)
            objDerived.cmd.Parameters.AddWithValue("@NoofYears", NoofYears)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", UsefulLife)
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", SalvageValue)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbBuilding_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@BuildingId", BuildingId)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@BuildingControlNo", BuildingControlNo)
            objDerived.cmd.Parameters.AddWithValue("@BuildingCode", BuildingCode)
            objDerived.cmd.Parameters.AddWithValue("@BuildingName", BuildingName)
            objDerived.cmd.Parameters.AddWithValue("@Address", Address)
            objDerived.cmd.Parameters.AddWithValue("@PostalCode", PostalCode)
            objDerived.cmd.Parameters.AddWithValue("@BuildingDepreciationRate", BuildingDepreciationRate)
            objDerived.cmd.Parameters.AddWithValue("@BuildingUse", BuildingUse)
            objDerived.cmd.Parameters.AddWithValue("@BuildingOccupancy", BuildingOccupancy)
            objDerived.cmd.Parameters.AddWithValue("@NumberFloors", NumberFloors)
            objDerived.cmd.Parameters.AddWithValue("@AvgAreaFloor", AvgAreaFloor)
            objDerived.cmd.Parameters.AddWithValue("@CostPerArea", CostPerArea)
            objDerived.cmd.Parameters.AddWithValue("@BuildingDepreciationValue", BuildingDepreciationValue)
            'objDerived.cmd.Parameters.AddWithValue("@DateTaken", DateTaken)
            'objDerived.cmd.Parameters.AddWithValue("@UploadedBy", UploadedBy)
            'objDerived.cmd.Parameters.AddWithValue("@Position", Position)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Status_AIR", Status_AIR)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbBuilding_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class


#End Region
#Region "TbBuilding_ConstructionDtl"
    Public Class TbBuilding_ConstructionDtl
        Inherits BaseDLL.BaseDAL


        Private pBuildingConstructionDetailId As Long
        Public Property BuildingConstructionDetailId() As Long
            Get
                Return pBuildingConstructionDetailId
            End Get
            Set(ByVal value As Long)
                pBuildingConstructionDetailId = value
            End Set
        End Property

        Private pBuildingId As Long
        Public Property BuildingId() As Long
            Get
                Return pBuildingId
            End Get
            Set(ByVal value As Long)
                pBuildingId = value
            End Set
        End Property


        Private pConstructionType As String
        Public Property ConstructionType() As String
            Get
                Return pConstructionType
            End Get
            Set(ByVal value As String)
                pConstructionType = value
            End Set
        End Property

        Private pBuildingDateStarted As Date
        Public Property BuildingDateStarted() As Date
            Get
                Return pBuildingDateStarted
            End Get
            Set(ByVal value As Date)
                pBuildingDateStarted = value
            End Set
        End Property

        Private pBuildingDateCompletion As Date
        Public Property BuildingDateCompletion() As Date
            Get
                Return pBuildingDateCompletion
            End Get
            Set(ByVal value As Date)
                pBuildingDateCompletion = value
            End Set
        End Property

        Private pBuildingProjectCost As String
        Public Property BuildingProjectCost() As String
            Get
                Return pBuildingProjectCost
            End Get
            Set(ByVal value As String)
                pBuildingProjectCost = value
            End Set
        End Property

        Private pBuildingPermitNo As String
        Public Property BuildingPermitNo() As String
            Get
                Return pBuildingPermitNo
            End Get
            Set(ByVal value As String)
                pBuildingPermitNo = value
            End Set
        End Property

        Private pDateApplication As Date
        Public Property DateApplication() As Date
            Get
                Return pDateApplication
            End Get
            Set(ByVal value As Date)
                pDateApplication = value
            End Set
        End Property

        Private pBuildingDateIssued As Date
        Public Property BuildingDateIssued() As Date
            Get
                Return pBuildingDateIssued
            End Get
            Set(ByVal value As Date)
                pBuildingDateIssued = value
            End Set
        End Property

        Private pBuildingRemarks As String
        Public Property BuildingRemarks() As String
            Get
                Return pBuildingRemarks
            End Get
            Set(ByVal value As String)
                pBuildingRemarks = value
            End Set
        End Property

        Private pProfessionalContractor As String
        Public Property ProfessionalContractor() As String
            Get
                Return pProfessionalContractor
            End Get
            Set(ByVal value As String)
                pProfessionalContractor = value
            End Set
        End Property

        Private pProfessionalName As String
        Public Property ProfessionalName() As String
            Get
                Return pProfessionalName
            End Get
            Set(ByVal value As String)
                pProfessionalName = value
            End Set
        End Property

        Private pProfessionalAddress As String
        Public Property ProfessionalAddress() As String
            Get
                Return pProfessionalAddress
            End Get
            Set(ByVal value As String)
                pProfessionalAddress = value
            End Set
        End Property

        Private pProfessionalTeleNo As String
        Public Property ProfessionalTeleNo() As String
            Get
                Return pProfessionalTeleNo
            End Get
            Set(ByVal value As String)
                pProfessionalTeleNo = value
            End Set
        End Property

        Private pProfessionalCellNo As String
        Public Property ProfessionalCellNo() As String

            Get
                Return pProfessionalCellNo
            End Get
            Set(ByVal value As String)
                pProfessionalCellNo = value
            End Set
        End Property

        Private pProfessionalEmailAddress As String
        Public Property ProfessionalEmailAddress() As String
            Get
                Return pProfessionalEmailAddress
            End Get
            Set(ByVal value As String)
                pProfessionalEmailAddress = value
            End Set
        End Property

        Private pProfessionalPrcNo As String
        Public Property ProfessionalPrcNo() As String
            Get
                Return pProfessionalPrcNo
            End Get
            Set(ByVal value As String)
                pProfessionalPrcNo = value
            End Set
        End Property

        Private pProfessionalPtrNo As String
        Public Property ProfessionalPtrNo() As String
            Get
                Return pProfessionalPtrNo
            End Get
            Set(ByVal value As String)
                pProfessionalPtrNo = value
            End Set
        End Property

        Private pProfessionalValidity As String
        Public Property ProfessionalValidity() As String
            Get
                Return pProfessionalValidity
            End Get
            Set(ByVal value As String)
                pProfessionalValidity = value
            End Set
        End Property

        Private pProfessionalDateIssued As String
        Public Property ProfessionalDateIssued() As String
            Get
                Return pProfessionalDateIssued
            End Get
            Set(ByVal value As String)
                pProfessionalDateIssued = value
            End Set
        End Property
        Public Function save() As Long

            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@BuildingConstructionDetailId", 0)
            objDerived.cmd.Parameters.AddWithValue("@BuildingId", BuildingId)
            objDerived.cmd.Parameters.AddWithValue("@ConstructionType", ConstructionType)
            objDerived.cmd.Parameters.AddWithValue("@BuildingDateStarted", BuildingDateStarted)
            objDerived.cmd.Parameters.AddWithValue("@BuildingDateCompletion", BuildingDateCompletion)
            objDerived.cmd.Parameters.AddWithValue("@BuildingProjectCost", BuildingProjectCost)
            objDerived.cmd.Parameters.AddWithValue("@BuildingPermitNo", BuildingPermitNo)
            objDerived.cmd.Parameters.AddWithValue("@DateApplication", DateApplication)
            objDerived.cmd.Parameters.AddWithValue("@BuildingDateIssued", BuildingDateIssued)
            objDerived.cmd.Parameters.AddWithValue("@BuildingRemarks", BuildingRemarks)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalContractor", ProfessionalContractor)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalName", ProfessionalName)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalAddress", ProfessionalAddress)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalTeleNo", ProfessionalTeleNo)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalCellNo", ProfessionalCellNo)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalEmailAddress", ProfessionalEmailAddress)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalPrcNo", ProfessionalPrcNo)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalPtrNo", ProfessionalPtrNo)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalValidity", ProfessionalValidity)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalDateIssued", ProfessionalDateIssued)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbBuilding_ConstructionDtl", CommandType.StoredProcedure, Nothing)
            Return i

        End Function

        Public Function update() As Long

            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@BuildingConstructionDetailId", BuildingConstructionDetailId)
            objDerived.cmd.Parameters.AddWithValue("@BuildingId", BuildingId)
            objDerived.cmd.Parameters.AddWithValue("@ConstructionType", ConstructionType)
            objDerived.cmd.Parameters.AddWithValue("@BuildingDateStarted", BuildingDateStarted)
            objDerived.cmd.Parameters.AddWithValue("@BuildingDateCompletion", BuildingDateCompletion)
            objDerived.cmd.Parameters.AddWithValue("@BuildingProjectCost", BuildingProjectCost)
            objDerived.cmd.Parameters.AddWithValue("@BuildingPermitNo", BuildingPermitNo)
            objDerived.cmd.Parameters.AddWithValue("@DateApplication", DateApplication)
            objDerived.cmd.Parameters.AddWithValue("@BuildingDateIssued", BuildingDateIssued)
            objDerived.cmd.Parameters.AddWithValue("@BuildingRemarks", BuildingRemarks)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalContractor", ProfessionalContractor)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalName", ProfessionalName)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalAddress", ProfessionalAddress)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalTeleNo", ProfessionalTeleNo)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalCellNo", ProfessionalCellNo)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalEmailAddress", ProfessionalEmailAddress)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalPrcNo", ProfessionalPrcNo)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalPtrNo", ProfessionalPtrNo)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalValidity", ProfessionalValidity)
            objDerived.cmd.Parameters.AddWithValue("@ProfessionalDateIssued", ProfessionalDateIssued)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbBuilding_ConstructionDtl", CommandType.StoredProcedure, Nothing)
            Return i

        End Function







































    End Class
#End Region
#Region "TbBuilding_Information"
    Public Class TbBuilding_Information
        Inherits BaseDLL.BaseDAL

        Private pBuildingInfoId As Long
        Public Property BuildingInfoId() As Long
            Get
                Return pBuildingInfoId
            End Get
            Set(ByVal value As Long)
                pBuildingInfoId = value
            End Set
        End Property

        Private pBuildingId As Long
        Public Property BuildingId() As Long
            Get
                Return pBuildingId
            End Get
            Set(ByVal value As Long)
                pBuildingId = value
            End Set
        End Property

        Private pRealPropertyPin As String
        Public Property RealPropertyPin() As String
            Get
                Return pRealPropertyPin
            End Get
            Set(ByVal value As String)
                pRealPropertyPin = value
            End Set
        End Property

        Private pPropertyCode As String
        Public Property PropertyCode() As String
            Get
                Return pPropertyCode
            End Get
            Set(ByVal value As String)
                pPropertyCode = value
            End Set
        End Property

        Private pAccountCode As String
        Public Property AccountCode() As String
            Get
                Return pAccountCode
            End Get
            Set(ByVal value As String)
                pAccountCode = value
            End Set
        End Property

        Private pOccupancyCount As Integer
        Public Property OccupancyCount() As Integer
            Get
                Return pOccupancyCount
            End Get
            Set(ByVal value As Integer)
                pOccupancyCount = value
            End Set
        End Property

        Private pMaxBldgOccupancy As Integer
        Public Property MaxBldgOccupancy() As Integer
            Get
                Return pMaxBldgOccupancy
            End Get
            Set(ByVal value As Integer)
                pMaxBldgOccupancy = value
            End Set
        End Property

        Private pEntityHandleUniqueId As String
        Public Property EntityHandleUniqueId() As String
            Get
                Return pEntityHandleUniqueId
            End Get
            Set(ByVal value As String)
                pEntityHandleUniqueId = value
            End Set
        End Property


        Private pEfficiencyRate As String
        Public Property EfficiencyRate() As String
            Get
                Return pEfficiencyRate
            End Get
            Set(ByVal value As String)
                pEfficiencyRate = value
            End Set
        End Property

        Private pRuRatio As String
        Public Property RuRatio() As String
            Get
                Return pRuRatio
            End Get
            Set(ByVal value As String)
                pRuRatio = value
            End Set
        End Property

        Private pComments As String
        Public Property Comments() As String
            Get
                Return pComments
            End Get
            Set(ByVal value As String)
                pComments = value
            End Set
        End Property

        Private pExtGrossArea As String
        Public Property ExtGrossArea() As String
            Get
                Return pExtGrossArea
            End Get
            Set(ByVal value As String)
                pExtGrossArea = value
            End Set
        End Property

        Private pIntGrossArea As String
        Public Property IntGrossArea() As String
            Get
                Return pIntGrossArea
            End Get
            Set(ByVal value As String)
                pIntGrossArea = value
            End Set
        End Property

        Private pExtWallArea As String
        Public Property ExtWallArea() As String
            Get
                Return pExtWallArea
            End Get
            Set(ByVal value As String)
                pExtWallArea = value
            End Set
        End Property

        Private pAvgAreaEmp As String
        Public Property AvgAreaEmp() As String
            Get
                Return pAvgAreaEmp
            End Get
            Set(ByVal value As String)
                pAvgAreaEmp = value
            End Set
        End Property

        Private pUsableArea As String
        Public Property UsableArea() As String
            Get
                Return pUsableArea
            End Get
            Set(ByVal value As String)
                pUsableArea = value
            End Set
        End Property

        Private pRemainingArea As String
        Public Property RemainingArea() As String
            Get
                Return pRemainingArea
            End Get
            Set(ByVal value As String)
                pRemainingArea = value
            End Set
        End Property

        Private pRentableArea As String
        Public Property RentableArea() As String
            Get
                Return pRentableArea
            End Get
            Set(ByVal value As String)
                pRentableArea = value
            End Set
        End Property

        Private pGroupBldgCommonArea As String
        Public Property GroupBldgCommonArea() As String
            Get
                Return pGroupBldgCommonArea
            End Get
            Set(ByVal value As String)
                pGroupBldgCommonArea = value
            End Set
        End Property

        Private pNonOccuCommonArea As String
        Public Property NonOccuCommonArea() As String
            Get
                Return pNonOccuCommonArea
            End Get
            Set(ByVal value As String)
                pNonOccuCommonArea = value
            End Set
        End Property

        Private pOccuBldgCommonArea As String
        Public Property OccuBldgCommonArea() As String
            Get
                Return pOccuBldgCommonArea
            End Get
            Set(ByVal value As String)
                pOccuBldgCommonArea = value
            End Set
        End Property

        Private pRoomBldgCommonArea As String
        Public Property RoomBldgCommonArea() As String
            Get
                Return pRoomBldgCommonArea
            End Get
            Set(ByVal value As String)
                pRoomBldgCommonArea = value
            End Set
        End Property

        Private pServiceBldgCommonArea As String
        Public Property ServiceBldgCommonArea() As String
            Get
                Return pServiceBldgCommonArea
            End Get
            Set(ByVal value As String)
                pServiceBldgCommonArea = value
            End Set
        End Property

        Private pServiceArea As String
        Public Property ServiceArea() As String
            Get
                Return pServiceArea
            End Get
            Set(ByVal value As String)
                pServiceArea = value
            End Set
        End Property

        Private pSuiteArea As String
        Public Property SuiteArea() As String
            Get
                Return pSuiteArea
            End Get
            Set(ByVal value As String)
                pSuiteArea = value
            End Set
        End Property


        Private pTotalEmpDeptArea As String
        Public Property TotalEmpDeptArea() As String
            Get
                Return pTotalEmpDeptArea
            End Get
            Set(ByVal value As String)
                pTotalEmpDeptArea = value
            End Set
        End Property

        Private pTotalGroupArea As String
        Public Property TotalGroupArea() As String
            Get
                Return pTotalGroupArea
            End Get
            Set(ByVal value As String)
                pTotalGroupArea = value
            End Set
        End Property


        Private pTotalGroupCommonArea As String
        Public Property TotalGroupCommonArea() As String
            Get
                Return pTotalGroupCommonArea
            End Get
            Set(ByVal value As String)
                pTotalGroupCommonArea = value
            End Set
        End Property

        Private pTotalGroupDeptArea As String
        Public Property TotalGroupDeptArea() As String
            Get
                Return pTotalGroupDeptArea
            End Get
            Set(ByVal value As String)
                pTotalGroupDeptArea = value
            End Set
        End Property

        Private pTotalLeaseNegotiatedArea As String
        Public Property TotalLeaseNegotiatedArea() As String
            Get
                Return pTotalLeaseNegotiatedArea
            End Get
            Set(ByVal value As String)
                pTotalLeaseNegotiatedArea = value
            End Set
        End Property

        Private pTotalNonOccupArea As String
        Public Property TotalNonOccupArea() As String
            Get
                Return pTotalNonOccupArea
            End Get
            Set(ByVal value As String)
                pTotalNonOccupArea = value
            End Set
        End Property

        Private pTotalNonOccupCommonArea As String
        Public Property TotalNonOccupCommonArea() As String
            Get
                Return pTotalNonOccupCommonArea
            End Get
            Set(ByVal value As String)
                pTotalNonOccupCommonArea = value
            End Set
        End Property

        Private pTotalNonOccupDeptArea As String
        Public Property TotalNonOccupDeptArea() As String
            Get
                Return pTotalNonOccupDeptArea
            End Get
            Set(ByVal value As String)
                pTotalNonOccupDeptArea = value
            End Set
        End Property

        Private pTotalOccupArea As String
        Public Property TotalOccupArea() As String
            Get
                Return pTotalOccupArea
            End Get
            Set(ByVal value As String)
                pTotalOccupArea = value
            End Set
        End Property

        Private pTotalOccupCommonArea As String
        Public Property TotalOccupCommonArea() As String
            Get
                Return pTotalOccupCommonArea
            End Get
            Set(ByVal value As String)
                pTotalOccupCommonArea = value
            End Set
        End Property


        Private pTotalOccupDeptArea As String
        Public Property TotalOccupDeptArea() As String
            Get
                Return pTotalOccupDeptArea
            End Get
            Set(ByVal value As String)
                pTotalOccupDeptArea = value
            End Set
        End Property

        Private pTotalRoomArea As String
        Public Property TotalRoomArea() As String
            Get
                Return pTotalRoomArea
            End Get
            Set(ByVal value As String)
                pTotalRoomArea = value
            End Set
        End Property

        Private pTotalRoomCommonArea As String
        Public Property TotalRoomCommonArea() As String
            Get
                Return pTotalRoomCommonArea
            End Get
            Set(ByVal value As String)
                pTotalRoomCommonArea = value
            End Set
        End Property

        Private pTotalRoomDeptArea As String
        Public Property TotalRoomDeptArea() As String
            Get
                Return pTotalRoomDeptArea
            End Get
            Set(ByVal value As String)
                pTotalRoomDeptArea = value
            End Set
        End Property

        Private pVertPenArea As String
        Public Property VertPenArea() As String
            Get
                Return pVertPenArea
            End Get
            Set(ByVal value As String)
                pVertPenArea = value
            End Set
        End Property

        Private pValueMarket As Decimal
        Public Property ValueMarket() As Decimal
            Get
                Return pValueMarket
            End Get
            Set(ByVal value As Decimal)
                pValueMarket = value
            End Set
        End Property

        Private pValueBook As Decimal
        Public Property ValueBook() As Decimal
            Get
                Return pValueBook
            End Get
            Set(ByVal value As Decimal)
                pValueBook = value
            End Set
        End Property


        Private pIncomeTotal As Decimal
        Public Property IncomeTotal() As Decimal
            Get
                Return pIncomeTotal
            End Get
            Set(ByVal value As Decimal)
                pIncomeTotal = value
            End Set
        End Property

        Private pExpenseOtherTotal As Decimal
        Public Property ExpenseOtherTotal() As Decimal
            Get
                Return pExpenseOtherTotal
            End Get
            Set(ByVal value As Decimal)
                pExpenseOtherTotal = value
            End Set
        End Property

        Private pExpenseOperTotal As Decimal
        Public Property ExpenseOperTotal() As Decimal
            Get
                Return pExpenseOperTotal
            End Get
            Set(ByVal value As Decimal)
                pExpenseOperTotal = value
            End Set
        End Property

        Private pExpenseTaxTotal As Decimal
        Public Property ExpenseTaxTotal() As Decimal
            Get
                Return pExpenseTaxTotal
            End Get
            Set(ByVal value As Decimal)
                pExpenseTaxTotal = value
            End Set
        End Property

        Private pExpenseUtilityTotal As Decimal
        Public Property ExpenseUtilityTotal() As Decimal
            Get
                Return pExpenseUtilityTotal
            End Get
            Set(ByVal value As Decimal)
                pExpenseUtilityTotal = value
            End Set
        End Property





























    End Class
#End Region

    'EQUIPMENTS
#Region "TbEquipment_Dtl"

    Public Class TbEquipment_Details
        Inherits BaseDLL.BaseDAL

        Private pEquipmentId As Long
        Public Property EquipmentId() As Long
            Get
                Return pEquipmentId
            End Get
            Set(ByVal value As Long)
                pEquipmentId = value
            End Set
        End Property

        Private pEquipInfoId As Long
        Public Property EquipInfoId() As Long
            Get
                Return pEquipInfoId
            End Get
            Set(ByVal value As Long)
                pEquipInfoId = value
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

        Private pWarehouseID As Long
        Public Property WarehouseID() As Long
            Get
                Return pWarehouseID
            End Get
            Set(ByVal value As Long)
                pWarehouseID = value
            End Set
        End Property

        Private pMarketValue As Decimal
        Public Property MarketValue() As Decimal
            Get
                Return pMarketValue
            End Get
            Set(ByVal value As Decimal)
                pMarketValue = value
            End Set
        End Property

        Private pCondition As String
        Public Property Condition() As String
            Get
                Return pCondition
            End Get
            Set(ByVal value As String)
                pCondition = value
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

        Private pBuildingId As Long
        Public Property BuildingId() As Long
            Get
                Return pBuildingId
            End Get
            Set(ByVal value As Long)
                pBuildingId = value
            End Set
        End Property

        Private pMaintenanceContractor As String
        Public Property MaintenanceContractor() As String
            Get
                Return pMaintenanceContractor
            End Get
            Set(ByVal value As String)
                pMaintenanceContractor = value
            End Set
        End Property

        Private pMaintenanceContactPerson As String
        Public Property MaintenanceContactPerson() As String
            Get
                Return pMaintenanceContactPerson
            End Get
            Set(ByVal value As String)
                pMaintenanceContactPerson = value
            End Set
        End Property

        Private pMaintenanceContactNo As String
        Public Property MaintenanceContactNo() As String
            Get
                Return pMaintenanceContactNo
            End Get
            Set(ByVal value As String)
                pMaintenanceContactNo = value
            End Set
        End Property

        Private pBay As String
        Public Property Bay() As String
            Get
                Return pBay
            End Get
            Set(ByVal value As String)
                pBay = value
            End Set
        End Property

        Private pColumn As String
        Public Property Column() As String
            Get
                Return pColumn
            End Get
            Set(ByVal value As String)
                pColumn = value
            End Set
        End Property

        Private pFloor As String
        Public Property Floor() As String
            Get
                Return pFloor
            End Get
            Set(ByVal value As String)
                pFloor = value
            End Set
        End Property

        Private pRoom As String
        Public Property Room() As String
            Get
                Return pRoom
            End Get
            Set(ByVal value As String)
                pRoom = value
            End Set
        End Property

        Private pShelves As String
        Public Property Shelves() As String
            Get
                Return pShelves
            End Get
            Set(ByVal value As String)
                pShelves = value
            End Set
        End Property

        Private pRack As String
        Public Property Rack() As String
            Get
                Return pRack
            End Get
            Set(ByVal value As String)
                pRack = value
            End Set
        End Property

        Private pBin As String
        Public Property Bin() As String
            Get
                Return pBin
            End Get
            Set(ByVal value As String)
                pBin = value
            End Set
        End Property

        Private pProperty_ID As Long
        Public Property Property_ID() As Long
            Get
                Return pProperty_ID
            End Get
            Set(ByVal value As Long)
                pProperty_ID = value
            End Set
        End Property



        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@EquipmentId", 0)
            objDerived.cmd.Parameters.AddWithValue("@EquipInfoId", EquipInfoId)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Condition", Condition)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@warehouseid", WarehouseID)
            objDerived.cmd.Parameters.AddWithValue("@BuildingId", BuildingId)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContractor", MaintenanceContractor)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactPerson", MaintenanceContactPerson)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactNo", MaintenanceContactNo)

            objDerived.cmd.Parameters.AddWithValue("@Bay", Bay)
            objDerived.cmd.Parameters.AddWithValue("@Column", Column)
            objDerived.cmd.Parameters.AddWithValue("@Floor", Floor)
            objDerived.cmd.Parameters.AddWithValue("@Room", Room)
            objDerived.cmd.Parameters.AddWithValue("@Shelves", Shelves)
            objDerived.cmd.Parameters.AddWithValue("@Rack", Rack)
            objDerived.cmd.Parameters.AddWithValue("@Bin", Bin)
            objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbEquipment_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@EquipmentId", EquipmentId)
            objDerived.cmd.Parameters.AddWithValue("@EquipInfoId", EquipInfoId)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Condition", Condition)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbEquipment_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class


#End Region
#Region "TbEquipment_Info"

    Public Class TbEquipment_Info
        Inherits BaseDLL.BaseDAL

        Private pEquipInfoId As Long
        Public Property EquipInfoId() As Long
            Get
                Return pEquipInfoId
            End Get
            Set(ByVal value As Long)
                pEquipInfoId = value
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

        Private pIsAccepted As Boolean
        Public Property IsAccepted() As Boolean
            Get
                Return pIsAccepted
            End Get
            Set(ByVal value As Boolean)
                pIsAccepted = value
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

        Private pSerialNo As String
        Public Property SerialNo() As String
            Get
                Return pSerialNo
            End Get
            Set(ByVal value As String)
                pSerialNo = value
            End Set
        End Property


        Private pName As String
        Public Property Name() As String
            Get
                Return pName
            End Get
            Set(ByVal value As String)
                pName = value
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

        Private pPowerInput As String
        Public Property PowerInput() As String
            Get
                Return pPowerInput
            End Get
            Set(ByVal value As String)
                pPowerInput = value
            End Set
        End Property

        Private pDepreciationRate As String
        Public Property DepreciationRate() As String
            Get
                Return pDepreciationRate
            End Get
            Set(ByVal value As String)
                pDepreciationRate = value
            End Set
        End Property

        Private pDimension As String
        Public Property Dimension() As String
            Get
                Return pDimension
            End Get
            Set(ByVal value As String)
                pDimension = value
            End Set
        End Property

        Private pAreaCapacity As String
        Public Property AreaCapacity() As String
            Get
                Return pAreaCapacity
            End Get
            Set(ByVal value As String)
                pAreaCapacity = value
            End Set
        End Property

        Private pModel As String
        Public Property Model() As String
            Get
                Return pModel
            End Get
            Set(ByVal value As String)
                pModel = value
            End Set
        End Property

        Private pWarranty As String
        Public Property Warranty() As String
            Get
                Return pWarranty
            End Get
            Set(ByVal value As String)
                pWarranty = value
            End Set
        End Property

        Private pDepreciationValue As Decimal
        Public Property DepreciationValue() As Decimal
            Get
                Return pDepreciationValue
            End Get
            Set(ByVal value As Decimal)
                pDepreciationValue = value
            End Set
        End Property

        Private pSpecification As String
        Public Property Specification() As String
            Get
                Return pSpecification
            End Get
            Set(ByVal value As String)
                pSpecification = value
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

        Private pFloorLocation As String
        Public Property FloorLocation() As String
            Get
                Return pFloorLocation
            End Get
            Set(ByVal value As String)
                pFloorLocation = value
            End Set
        End Property

        Private pRoomLocation As String
        Public Property RoomLocation() As String
            Get
                Return pRoomLocation
            End Get
            Set(ByVal value As String)
                pRoomLocation = value
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

        Private pAccountablePerson As String
        Public Property AccountablePerson() As String
            Get
                Return pAccountablePerson
            End Get
            Set(ByVal value As String)
                pAccountablePerson = value
            End Set
        End Property


        Private pSalvageValue As Decimal
        Public Property SalvageValue() As Decimal
            Get
                Return pSalvageValue
            End Get
            Set(ByVal value As Decimal)
                pSalvageValue = value
            End Set
        End Property


        Private pProjectName As String
        Public Property ProjectName() As String
            Get
                Return pProjectName
            End Get
            Set(ByVal value As String)
                pProjectName = value
            End Set
        End Property

        Private pInfrastructureID As String
        Public Property InfrastructureID() As String
            Get
                Return pInfrastructureID
            End Get
            Set(ByVal value As String)
                pInfrastructureID = value
            End Set
        End Property
        Private pInfrastructureName As String
        Public Property InfrastructureName() As String
            Get
                Return pInfrastructureName
            End Get
            Set(ByVal value As String)
                pInfrastructureName = value
            End Set
        End Property
        Private pInfrastructureClassification As String
        Public Property InfrastructureClassification() As String
            Get
                Return pInfrastructureClassification
            End Get
            Set(ByVal value As String)
                pInfrastructureClassification = value
            End Set
        End Property
        Private pInfrastructureType As String
        Public Property InfrastructureType() As String
            Get
                Return pInfrastructureType
            End Get
            Set(ByVal value As String)
                pInfrastructureType = value
            End Set
        End Property

        Private pInfrastructureFromStreet As String
        Public Property InfrastructureFromStreet() As String
            Get
                Return pInfrastructureFromStreet
            End Get
            Set(ByVal value As String)
                pInfrastructureFromStreet = value
            End Set
        End Property

        Private pInfrastructureToStreet As String
        Public Property InfrastructureToStreet() As String
            Get
                Return pInfrastructureToStreet
            End Get
            Set(ByVal value As String)
                pInfrastructureToStreet = value
            End Set
        End Property

        Private pInfrastructureSegmentLock As String
        Public Property InfrastructureSegmentLock() As String
            Get
                Return pInfrastructureSegmentLock
            End Get
            Set(ByVal value As String)
                pInfrastructureSegmentLock = value
            End Set
        End Property

        Private pInfrastructureLocation As String
        Public Property InfrastructureLocation() As String
            Get
                Return pInfrastructureLocation
            End Get
            Set(ByVal value As String)
                pInfrastructureLocation = value
            End Set
        End Property

        Private pInfrastructureLength As String
        Public Property InfrastructureLength() As String
            Get
                Return pInfrastructureLength
            End Get
            Set(ByVal value As String)
                pInfrastructureLength = value
            End Set
        End Property

        Private pInfrastructureNoofLanes As String
        Public Property InfrastructureNoofLanes() As String
            Get
                Return pInfrastructureNoofLanes
            End Get
            Set(ByVal value As String)
                pInfrastructureNoofLanes = value
            End Set
        End Property

        Private pInfrastructureWidth As String
        Public Property InfrastructureWidth() As String
            Get
                Return pInfrastructureWidth
            End Get
            Set(ByVal value As String)
                pInfrastructureWidth = value
            End Set
        End Property

        Private pInfrastructureLaneLength As String
        Public Property InfrastructureLaneLength() As String
            Get
                Return pInfrastructureLaneLength
            End Get
            Set(ByVal value As String)
                pInfrastructureLaneLength = value
            End Set
        End Property

        Private pInfrastructureLaneWidth As String
        Public Property InfrastructureLaneWidth() As String
            Get
                Return pInfrastructureLaneWidth
            End Get
            Set(ByVal value As String)
                pInfrastructureLaneWidth = value
            End Set
        End Property

        Private pInfrastructureTrafficDirection As String
        Public Property InfrastructureTrafficDirection() As String
            Get
                Return pInfrastructureTrafficDirection
            End Get
            Set(ByVal value As String)
                pInfrastructureTrafficDirection = value
            End Set
        End Property

        Private pInfrastructureTrafficVolume As String
        Public Property InfrastructureTrafficVolume() As String
            Get
                Return pInfrastructureTrafficVolume
            End Get
            Set(ByVal value As String)
                pInfrastructureTrafficVolume = value
            End Set
        End Property

        Private pInfrastructureTrafficDate As String
        Public Property InfrastructureTrafficDate() As String
            Get
                Return pInfrastructureTrafficDate
            End Get
            Set(ByVal value As String)
                pInfrastructureTrafficDate = value
            End Set
        End Property

        Private pInfrastructureSpeedLimit As String
        Public Property InfrastructureSpeedLimit() As String
            Get
                Return pInfrastructureSpeedLimit
            End Get
            Set(ByVal value As String)
                pInfrastructureSpeedLimit = value
            End Set
        End Property

        Private pInfrastructureElevation As String
        Public Property InfrastructureElevation() As String
            Get
                Return pInfrastructureElevation
            End Get
            Set(ByVal value As String)
                pInfrastructureElevation = value
            End Set
        End Property

        Private pInfrastructureSurfaceType As String
        Public Property InfrastructureSurfaceType() As String
            Get
                Return pInfrastructureSurfaceType
            End Get
            Set(ByVal value As String)
                pInfrastructureSurfaceType = value
            End Set
        End Property

        Private pInfrastructureSurfaceCondition As String
        Public Property InfrastructureSurfaceCondition() As String
            Get
                Return pInfrastructureSurfaceCondition
            End Get
            Set(ByVal value As String)
                pInfrastructureSurfaceCondition = value
            End Set
        End Property

        Private pLeftLfromAddress As String
        Public Property LeftLfromAddress() As String
            Get
                Return pLeftLfromAddress
            End Get
            Set(ByVal value As String)
                pLeftLfromAddress = value
            End Set
        End Property

        Private pLeftLtoAddress As String
        Public Property LeftLtoAddress() As String
            Get
                Return pLeftLtoAddress
            End Get
            Set(ByVal value As String)
                pLeftLtoAddress = value
            End Set
        End Property

        Private pLeftNWshldrWidth As String
        Public Property LeftNWshldrWidth() As String
            Get
                Return pLeftNWshldrWidth
            End Get
            Set(ByVal value As String)
                pLeftNWshldrWidth = value
            End Set
        End Property

        Private pRightRfromAddress As String
        Public Property RightRfromAddress() As String
            Get
                Return pRightRfromAddress
            End Get
            Set(ByVal value As String)
                pRightRfromAddress = value
            End Set
        End Property

        Private pRightRtoAddress As String
        Public Property RightRtoAddress() As String
            Get
                Return pRightRtoAddress
            End Get
            Set(ByVal value As String)
                pRightRtoAddress = value
            End Set
        End Property

        Private pRightSEshldrWidth As String
        Public Property RightSEshldrWidth() As String
            Get
                Return pRightSEshldrWidth
            End Get
            Set(ByVal value As String)
                pRightSEshldrWidth = value
            End Set
        End Property

        Private pInfrastructureNumber As String
        Public Property InfrastructureNumber() As String
            Get
                Return pInfrastructureNumber
            End Get
            Set(ByVal value As String)
                pInfrastructureNumber = value
            End Set
        End Property

        Private pInfrastructureRoutseSignPrefix As String
        Public Property InfrastructureRoutseSignPrefix() As String
            Get
                Return pInfrastructureRoutseSignPrefix
            End Get
            Set(ByVal value As String)
                pInfrastructureRoutseSignPrefix = value
            End Set
        End Property

        Private pInfrastructureRouteNo As String
        Public Property InfrastructureRouteNo() As String
            Get
                Return pInfrastructureRouteNo
            End Get
            Set(ByVal value As String)
                pInfrastructureRouteNo = value
            End Set
        End Property

        Private pInfrastructureFeaturedIntersection As String
        Public Property InfrastructureFeaturedIntersection() As String
            Get
                Return pInfrastructureFeaturedIntersection
            End Get
            Set(ByVal value As String)
                pInfrastructureFeaturedIntersection = value
            End Set
        End Property

        Private pInfrastructureMilePoint As String
        Public Property InfrastructureMilePoint() As String
            Get
                Return pInfrastructureMilePoint
            End Get
            Set(ByVal value As String)
                pInfrastructureMilePoint = value
            End Set
        End Property

        Private pInfrastructureBorderStructNo As String
        Public Property InfrastructureBorderStructNo() As String
            Get
                Return pInfrastructureBorderStructNo
            End Get
            Set(ByVal value As String)
                pInfrastructureBorderStructNo = value
            End Set
        End Property

        Private pInfrastructureRoadNo As String
        Public Property InfrastructureRoadNo() As String
            Get
                Return pInfrastructureRoadNo
            End Get
            Set(ByVal value As String)
                pInfrastructureRoadNo = value
            End Set
        End Property

        Private pInfrastructureNameofRiver As String
        Public Property InfrastructureNameofRiver() As String
            Get
                Return pInfrastructureNameofRiver
            End Get
            Set(ByVal value As String)
                pInfrastructureNameofRiver = value
            End Set
        End Property

        Private pInfrastructureReferencePost As String
        Public Property InfrastructureReferencePost() As String
            Get
                Return pInfrastructureReferencePost
            End Get
            Set(ByVal value As String)
                pInfrastructureReferencePost = value
            End Set
        End Property

        Private pInfrastructureEndReferencePost As String
        Public Property InfrastructureEndReferencePost() As String
            Get
                Return pInfrastructureEndReferencePost
            End Get
            Set(ByVal value As String)
                pInfrastructureEndReferencePost = value
            End Set
        End Property

        Private pInfrastructureStartPosition As String
        Public Property InfrastructureStartPosition() As String
            Get
                Return pInfrastructureStartPosition
            End Get
            Set(ByVal value As String)
                pInfrastructureStartPosition = value
            End Set
        End Property

        Private pInfrastructureCurrentPosition As String
        Public Property InfrastructureCurrentPosition() As String
            Get
                Return pInfrastructureCurrentPosition
            End Get
            Set(ByVal value As String)
                pInfrastructureCurrentPosition = value
            End Set
        End Property

        Private pClassification As String
        Public Property Classification() As String
            Get
                Return pClassification
            End Get
            Set(ByVal value As String)
                pClassification = value
            End Set
        End Property

        Private pClassificationCode As String
        Public Property ClassificationCode() As String
            Get
                Return pClassificationCode
            End Get
            Set(ByVal value As String)
                pClassificationCode = value
            End Set
        End Property

        Private pTitle As String
        Public Property Title() As String
            Get
                Return pTitle
            End Get
            Set(ByVal value As String)
                pTitle = value
            End Set
        End Property

        Private pPublicationDate As String
        Public Property PublicationDate() As String
            Get
                Return pPublicationDate
            End Get
            Set(ByVal value As String)
                pPublicationDate = value
            End Set
        End Property


        Private pbPrice As String
        Public Property bPrice() As String
            Get
                Return pbPrice
            End Get
            Set(ByVal value As String)
                pbPrice = value
            End Set
        End Property

        Private pISBN As String
        Public Property ISBN() As String
            Get
                Return pISBN
            End Get
            Set(ByVal value As String)
                pISBN = value
            End Set
        End Property


        Private pAuthor As String
        Public Property Author() As String
            Get
                Return pAuthor
            End Get
            Set(ByVal value As String)
                pAuthor = value
            End Set
        End Property

        Private pNoYears As Long
        Public Property NoYears() As Long
            Get
                Return pNoYears
            End Get
            Set(ByVal value As Long)
                pNoYears = value
            End Set
        End Property

        Private pUsefulLife As Long
        Public Property UsefulLife() As Long
            Get
                Return pUsefulLife
            End Get
            Set(ByVal value As Long)
                pUsefulLife = value
            End Set
        End Property


        Private pmanufacturer As String
        Public Property manufacturer() As String
            Get
                Return pmanufacturer
            End Get
            Set(ByVal value As String)
                pmanufacturer = value
            End Set
        End Property



        Private pcaliber As String
        Public Property caliber() As String
            Get
                Return pcaliber
            End Get
            Set(ByVal value As String)
                pcaliber = value
            End Set
        End Property

        Private pbarrel As String
        Public Property barrel() As String
            Get
                Return pbarrel
            End Get
            Set(ByVal value As String)
                pbarrel = value
            End Set
        End Property

        Private pframe As String
        Public Property frame() As String
            Get
                Return pframe
            End Get
            Set(ByVal value As String)
                pframe = value
            End Set
        End Property

        Private pcolor As String
        Public Property color() As String
            Get
                Return pcolor
            End Get
            Set(ByVal value As String)
                pcolor = value
            End Set
        End Property

        Private pcapacity As String
        Public Property capacity() As String
            Get
                Return pcapacity
            End Get
            Set(ByVal value As String)
                pcapacity = value
            End Set
        End Property

        Private psights As String
        Public Property sights() As String
            Get
                Return psights
            End Get
            Set(ByVal value As String)
                psights = value
            End Set
        End Property


        Private pProperty_ID As Long
        Public Property Property_ID() As Long
            Get
                Return pProperty_ID
            End Get
            Set(ByVal value As Long)
                pProperty_ID = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@EquipInfoId", 0)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@IsAccepted", IsAccepted)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@Name", Name)
            objDerived.cmd.Parameters.AddWithValue("@Description", Description)
            objDerived.cmd.Parameters.AddWithValue("@PowerInput", PowerInput)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", DepreciationRate)
            objDerived.cmd.Parameters.AddWithValue("@Dimension", Dimension)
            objDerived.cmd.Parameters.AddWithValue("@AreaCapacity", AreaCapacity)
            objDerived.cmd.Parameters.AddWithValue("@Model", Model)
            objDerived.cmd.Parameters.AddWithValue("@Warranty", Warranty)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", DepreciationValue)
            objDerived.cmd.Parameters.AddWithValue("@Specification", Specification)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@FloorLocation", FloorLocation)
            objDerived.cmd.Parameters.AddWithValue("@RoomLocation", RoomLocation)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
            objDerived.cmd.Parameters.AddWithValue("@AccountablePerson", AccountablePerson)
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", SalvageValue)
            objDerived.cmd.Parameters.AddWithValue("@ProjectName", ProjectName)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureID", InfrastructureID)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureName", InfrastructureName)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureClassification", InfrastructureClassification)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureType", InfrastructureType)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureFromStreet", InfrastructureFromStreet)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureToStreet ", InfrastructureToStreet)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSegmentLock", InfrastructureSegmentLock)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLocation", InfrastructureLocation)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLength", InfrastructureLength)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureNoofLanes", InfrastructureNoofLanes)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureWidth", InfrastructureWidth)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLaneLength", InfrastructureLaneLength)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLaneWidth", InfrastructureLaneWidth)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureTrafficDirection", InfrastructureTrafficDirection)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureTrafficVolume", InfrastructureTrafficVolume)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureTrafficDate", InfrastructureTrafficDate)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSpeedLimit", InfrastructureSpeedLimit)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureElevation", InfrastructureElevation)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSurfaceType", InfrastructureSurfaceType)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSurfaceCondition", InfrastructureSurfaceCondition)
            objDerived.cmd.Parameters.AddWithValue("@LeftLfromAddress", LeftLfromAddress)
            objDerived.cmd.Parameters.AddWithValue("@LeftLtoAddress", LeftLtoAddress)
            objDerived.cmd.Parameters.AddWithValue("@LeftNWshldrWidth", LeftNWshldrWidth)
            objDerived.cmd.Parameters.AddWithValue("@RightRfromAddress", RightRfromAddress)
            objDerived.cmd.Parameters.AddWithValue("@RightRtoAddress", RightRtoAddress)
            objDerived.cmd.Parameters.AddWithValue("@RightSEshldrWidth", RightSEshldrWidth)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureNumber", InfrastructureNumber)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureRoutseSignPrefix", InfrastructureRoutseSignPrefix)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureRouteNo", InfrastructureRouteNo)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureFeaturedIntersection", InfrastructureFeaturedIntersection)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureMilePoint", InfrastructureMilePoint)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureBorderStructNo", InfrastructureBorderStructNo)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureRoadNo", InfrastructureRoadNo)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureNameofRiver", InfrastructureNameofRiver)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureReferencePost", InfrastructureReferencePost)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureEndReferencePost", InfrastructureEndReferencePost)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureStartPosition", InfrastructureStartPosition)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureCurrentPosition", InfrastructureCurrentPosition)
            objDerived.cmd.Parameters.AddWithValue("@Classification", Classification)
            objDerived.cmd.Parameters.AddWithValue("@ClassificationCode", ClassificationCode)
            objDerived.cmd.Parameters.AddWithValue("@Title", Title)
            objDerived.cmd.Parameters.AddWithValue("@PublicationDate", PublicationDate)
            objDerived.cmd.Parameters.AddWithValue("@bPrice", bPrice)
            objDerived.cmd.Parameters.AddWithValue("@ISBN", ISBN)
            objDerived.cmd.Parameters.AddWithValue("@Author", Author)
            objDerived.cmd.Parameters.AddWithValue("@NoYears", NoYears)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", UsefulLife)
            objDerived.cmd.Parameters.AddWithValue("@manufacturer", manufacturer)
            objDerived.cmd.Parameters.AddWithValue("@caliber", caliber)
            objDerived.cmd.Parameters.AddWithValue("@barrel", barrel)
            objDerived.cmd.Parameters.AddWithValue("@frame", frame)
            objDerived.cmd.Parameters.AddWithValue("@color", color)
            objDerived.cmd.Parameters.AddWithValue("@capacity", capacity)
            objDerived.cmd.Parameters.AddWithValue("@sights", sights)
            objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)


            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbEquipment_Info", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@EquipInfoId", EquipInfoId)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@IsAccepted", IsAccepted)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@Name", Name)
            objDerived.cmd.Parameters.AddWithValue("@Description", Description)
            objDerived.cmd.Parameters.AddWithValue("@PowerInput", PowerInput)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", DepreciationRate)
            objDerived.cmd.Parameters.AddWithValue("@Dimension", Dimension)
            objDerived.cmd.Parameters.AddWithValue("@AreaCapacity", AreaCapacity)
            objDerived.cmd.Parameters.AddWithValue("@Model", Model)
            objDerived.cmd.Parameters.AddWithValue("@Warranty", Warranty)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", DepreciationValue)
            objDerived.cmd.Parameters.AddWithValue("@Specification", Specification)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@FloorLocation", FloorLocation)
            objDerived.cmd.Parameters.AddWithValue("@RoomLocation", RoomLocation)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
            objDerived.cmd.Parameters.AddWithValue("@AccountablePerson", AccountablePerson)
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", SalvageValue)
            objDerived.cmd.Parameters.AddWithValue("@ProjectName", ProjectName)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureID", InfrastructureID)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureName", InfrastructureName)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureClassification", InfrastructureClassification)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureType", InfrastructureType)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureFromStreet", InfrastructureFromStreet)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureToStreet ", InfrastructureToStreet)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSegmentLock", InfrastructureSegmentLock)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLocation", InfrastructureLocation)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLength", InfrastructureLength)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureNoofLanes", InfrastructureNoofLanes)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureWidth", InfrastructureWidth)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLaneLength", InfrastructureLaneLength)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLaneWidth", InfrastructureLaneWidth)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureTrafficDirection", InfrastructureTrafficDirection)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureTrafficVolume", InfrastructureTrafficVolume)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureTrafficDate", InfrastructureTrafficDate)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSpeedLimit", InfrastructureSpeedLimit)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureElevation", InfrastructureElevation)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSurfaceType", InfrastructureSurfaceType)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSurfaceCondition", InfrastructureSurfaceCondition)

            objDerived.cmd.Parameters.AddWithValue("@LeftLfromAddress", LeftLfromAddress)
            objDerived.cmd.Parameters.AddWithValue("@LeftLtoAddress", LeftLtoAddress)
            objDerived.cmd.Parameters.AddWithValue("@LeftNWshldrWidth", LeftNWshldrWidth)
            objDerived.cmd.Parameters.AddWithValue("@RightRfromAddress", RightRfromAddress)
            objDerived.cmd.Parameters.AddWithValue("@RightRtoAddress", RightRtoAddress)
            objDerived.cmd.Parameters.AddWithValue("@RightSEshldrWidth", RightSEshldrWidth)
            objDerived.cmd.Parameters.AddWithValue("@Classification", Classification)
            objDerived.cmd.Parameters.AddWithValue("@ClassificationCode", ClassificationCode)
            objDerived.cmd.Parameters.AddWithValue("@Title", Title)
            objDerived.cmd.Parameters.AddWithValue("@PublicationDate", PublicationDate)
            objDerived.cmd.Parameters.AddWithValue("@bPrice", bPrice)
            objDerived.cmd.Parameters.AddWithValue("@ISBN", ISBN)
            objDerived.cmd.Parameters.AddWithValue("@Author", Author)
            objDerived.cmd.Parameters.AddWithValue("@NoYears", NoYears)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", UsefulLife)

            objDerived.cmd.Parameters.AddWithValue("@manufacturer", manufacturer)
            objDerived.cmd.Parameters.AddWithValue("@caliber", caliber)
            objDerived.cmd.Parameters.AddWithValue("@barrel", barrel)
            objDerived.cmd.Parameters.AddWithValue("@frame", frame)
            objDerived.cmd.Parameters.AddWithValue("@color", color)
            objDerived.cmd.Parameters.AddWithValue("@capacity", capacity)
            objDerived.cmd.Parameters.AddWithValue("@sights", sights)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbEquipment_Info", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class


#End Region

    'OTHERS
#Region "TbOthers_Info"

    Public Class TbOthers_Info
        Inherits BaseDLL.BaseDAL

        Private pOthersInfoId As Long
        Public Property OthersInfoId() As Long
            Get
                Return pOthersInfoId
            End Get
            Set(ByVal value As Long)
                pOthersInfoId = value
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

        Private pIsAccepted As Boolean
        Public Property IsAccepted() As Boolean
            Get
                Return pIsAccepted
            End Get
            Set(ByVal value As Boolean)
                pIsAccepted = value
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

        Private pSerialNo As String
        Public Property SerialNo() As String
            Get
                Return pSerialNo
            End Get
            Set(ByVal value As String)
                pSerialNo = value
            End Set
        End Property

        Private pName As String
        Public Property Name() As String
            Get
                Return pName
            End Get
            Set(ByVal value As String)
                pName = value
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

        Private pPowerInput As String
        Public Property PowerInput() As String
            Get
                Return pPowerInput
            End Get
            Set(ByVal value As String)
                pPowerInput = value
            End Set
        End Property

        Private pDepreciationRate As String
        Public Property DepreciationRate() As String
            Get
                Return pDepreciationRate
            End Get
            Set(ByVal value As String)
                pDepreciationRate = value
            End Set
        End Property

        Private pDimension As String
        Public Property Dimension() As String
            Get
                Return pDimension
            End Get
            Set(ByVal value As String)
                pDimension = value
            End Set
        End Property

        Private pAreaCapacity As String
        Public Property AreaCapacity() As String
            Get
                Return pAreaCapacity
            End Get
            Set(ByVal value As String)
                pAreaCapacity = value
            End Set
        End Property

        Private pModel As String
        Public Property Model() As String
            Get
                Return pModel
            End Get
            Set(ByVal value As String)
                pModel = value
            End Set
        End Property

        Private pWarranty As String
        Public Property Warranty() As String
            Get
                Return pWarranty
            End Get
            Set(ByVal value As String)
                pWarranty = value
            End Set
        End Property

        Private pDepreciationValue As Decimal
        Public Property DepreciationValue() As Decimal
            Get
                Return pDepreciationValue
            End Get
            Set(ByVal value As Decimal)
                pDepreciationValue = value
            End Set
        End Property

        Private pSpecification As String
        Public Property Specification() As String
            Get
                Return pSpecification
            End Get
            Set(ByVal value As String)
                pSpecification = value
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

        Private pFloorLocation As String
        Public Property FloorLocation() As String
            Get
                Return pFloorLocation
            End Get
            Set(ByVal value As String)
                pFloorLocation = value
            End Set
        End Property

        Private pRoomLocation As String
        Public Property RoomLocation() As String
            Get
                Return pRoomLocation
            End Get
            Set(ByVal value As String)
                pRoomLocation = value
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

        Private pAccountablePerson As String
        Public Property AccountablePerson() As String
            Get
                Return pAccountablePerson
            End Get
            Set(ByVal value As String)
                pAccountablePerson = value
            End Set
        End Property

        Private pSalvageValue As Decimal
        Public Property SalvageValue() As Decimal
            Get
                Return pSalvageValue
            End Get
            Set(ByVal value As Decimal)
                pSalvageValue = value
            End Set
        End Property

        Private pProjectName As String
        Public Property ProjectName() As String
            Get
                Return pProjectName
            End Get
            Set(ByVal value As String)
                pProjectName = value
            End Set
        End Property

        Private pInfrastructureID As String
        Public Property InfrastructureID() As String
            Get
                Return pInfrastructureID
            End Get
            Set(ByVal value As String)
                pInfrastructureID = value
            End Set
        End Property

        Private pInfrastructureName As String
        Public Property InfrastructureName() As String
            Get
                Return pInfrastructureName
            End Get
            Set(ByVal value As String)
                pInfrastructureName = value
            End Set
        End Property

        Private pInfrastructureClassification As String
        Public Property InfrastructureClassification() As String
            Get
                Return pInfrastructureClassification
            End Get
            Set(ByVal value As String)
                pInfrastructureClassification = value
            End Set
        End Property

        Private pInfrastructureType As String
        Public Property InfrastructureType() As String
            Get
                Return pInfrastructureType
            End Get
            Set(ByVal value As String)
                pInfrastructureType = value
            End Set
        End Property

        Private pInfrastructureFromStreet As String
        Public Property InfrastructureFromStreet() As String
            Get
                Return pInfrastructureFromStreet
            End Get
            Set(ByVal value As String)
                pInfrastructureFromStreet = value
            End Set
        End Property

        Private pInfrastructureToStreet As String
        Public Property InfrastructureToStreet() As String
            Get
                Return pInfrastructureToStreet
            End Get
            Set(ByVal value As String)
                pInfrastructureToStreet = value
            End Set
        End Property

        Private pInfrastructureSegmentLock As String
        Public Property InfrastructureSegmentLock() As String
            Get
                Return pInfrastructureSegmentLock
            End Get
            Set(ByVal value As String)
                pInfrastructureSegmentLock = value
            End Set
        End Property

        Private pInfrastructureLocation As String
        Public Property InfrastructureLocation() As String
            Get
                Return pInfrastructureLocation
            End Get
            Set(ByVal value As String)
                pInfrastructureLocation = value
            End Set
        End Property

        Private pInfrastructureLength As String
        Public Property InfrastructureLength() As String
            Get
                Return pInfrastructureLength
            End Get
            Set(ByVal value As String)
                pInfrastructureLength = value
            End Set
        End Property

        Private pInfrastructureNoofLanes As String
        Public Property InfrastructureNoofLanes() As String
            Get
                Return pInfrastructureNoofLanes
            End Get
            Set(ByVal value As String)
                pInfrastructureNoofLanes = value
            End Set
        End Property

        Private pInfrastructureWidth As String
        Public Property InfrastructureWidth() As String
            Get
                Return pInfrastructureWidth
            End Get
            Set(ByVal value As String)
                pInfrastructureWidth = value
            End Set
        End Property

        Private pInfrastructureLaneLength As String
        Public Property InfrastructureLaneLength() As String
            Get
                Return pInfrastructureLaneLength
            End Get
            Set(ByVal value As String)
                pInfrastructureLaneLength = value
            End Set
        End Property

        Private pInfrastructureLaneWidth As String
        Public Property InfrastructureLaneWidth() As String
            Get
                Return pInfrastructureLaneWidth
            End Get
            Set(ByVal value As String)
                pInfrastructureLaneWidth = value
            End Set
        End Property

        Private pInfrastructureTrafficDirection As String
        Public Property InfrastructureTrafficDirection() As String
            Get
                Return pInfrastructureTrafficDirection
            End Get
            Set(ByVal value As String)
                pInfrastructureTrafficDirection = value
            End Set
        End Property

        Private pInfrastructureTrafficVolume As String
        Public Property InfrastructureTrafficVolume() As String
            Get
                Return pInfrastructureTrafficVolume
            End Get
            Set(ByVal value As String)
                pInfrastructureTrafficVolume = value
            End Set
        End Property

        Private pInfrastructureTrafficDate As String
        Public Property InfrastructureTrafficDate() As String
            Get
                Return pInfrastructureTrafficDate
            End Get
            Set(ByVal value As String)
                pInfrastructureTrafficDate = value
            End Set
        End Property

        Private pInfrastructureSpeedLimit As String
        Public Property InfrastructureSpeedLimit() As String
            Get
                Return pInfrastructureSpeedLimit
            End Get
            Set(ByVal value As String)
                pInfrastructureSpeedLimit = value
            End Set
        End Property

        Private pInfrastructureElevation As String
        Public Property InfrastructureElevation() As String
            Get
                Return pInfrastructureElevation
            End Get
            Set(ByVal value As String)
                pInfrastructureElevation = value
            End Set
        End Property

        Private pInfrastructureSurfaceType As String
        Public Property InfrastructureSurfaceType() As String
            Get
                Return pInfrastructureSurfaceType
            End Get
            Set(ByVal value As String)
                pInfrastructureSurfaceType = value
            End Set
        End Property

        Private pInfrastructureSurfaceCondition As String
        Public Property InfrastructureSurfaceCondition() As String
            Get
                Return pInfrastructureSurfaceCondition
            End Get
            Set(ByVal value As String)
                pInfrastructureSurfaceCondition = value
            End Set
        End Property

        Private pLeftLfromAddress As String
        Public Property LeftLfromAddress() As String
            Get
                Return pLeftLfromAddress
            End Get
            Set(ByVal value As String)
                pLeftLfromAddress = value
            End Set
        End Property

        Private pLeftLtoAddress As String
        Public Property LeftLtoAddress() As String
            Get
                Return pLeftLtoAddress
            End Get
            Set(ByVal value As String)
                pLeftLtoAddress = value
            End Set
        End Property

        Private pLeftNWshldrWidth As String
        Public Property LeftNWshldrWidth() As String
            Get
                Return pLeftNWshldrWidth
            End Get
            Set(ByVal value As String)
                pLeftNWshldrWidth = value
            End Set
        End Property

        Private pRightRfromAddress As String
        Public Property RightRfromAddress() As String
            Get
                Return pRightRfromAddress
            End Get
            Set(ByVal value As String)
                pRightRfromAddress = value
            End Set
        End Property

        Private pRightRtoAddress As String
        Public Property RightRtoAddress() As String
            Get
                Return pRightRtoAddress
            End Get
            Set(ByVal value As String)
                pRightRtoAddress = value
            End Set
        End Property

        Private pRightSEshldrWidth As String
        Public Property RightSEshldrWidth() As String
            Get
                Return pRightSEshldrWidth
            End Get
            Set(ByVal value As String)
                pRightSEshldrWidth = value
            End Set
        End Property

        Private pInfrastructureNumber As String
        Public Property InfrastructureNumber() As String
            Get
                Return pInfrastructureNumber
            End Get
            Set(ByVal value As String)
                pInfrastructureNumber = value
            End Set
        End Property

        Private pInfrastructureRoutseSignPrefix As String
        Public Property InfrastructureRoutseSignPrefix() As String
            Get
                Return pInfrastructureRoutseSignPrefix
            End Get
            Set(ByVal value As String)
                pInfrastructureRoutseSignPrefix = value
            End Set
        End Property

        Private pInfrastructureRouteNo As String
        Public Property InfrastructureRouteNo() As String
            Get
                Return pInfrastructureRouteNo
            End Get
            Set(ByVal value As String)
                pInfrastructureRouteNo = value
            End Set
        End Property

        Private pInfrastructureFeaturedIntersection As String
        Public Property InfrastructureFeaturedIntersection() As String
            Get
                Return pInfrastructureFeaturedIntersection
            End Get
            Set(ByVal value As String)
                pInfrastructureFeaturedIntersection = value
            End Set
        End Property

        Private pInfrastructureMilePoint As String
        Public Property InfrastructureMilePoint() As String
            Get
                Return pInfrastructureMilePoint
            End Get
            Set(ByVal value As String)
                pInfrastructureMilePoint = value
            End Set
        End Property

        Private pInfrastructureBorderStructNo As String
        Public Property InfrastructureBorderStructNo() As String
            Get
                Return pInfrastructureBorderStructNo
            End Get
            Set(ByVal value As String)
                pInfrastructureBorderStructNo = value
            End Set
        End Property

        Private pInfrastructureRoadNo As String
        Public Property InfrastructureRoadNo() As String
            Get
                Return pInfrastructureRoadNo
            End Get
            Set(ByVal value As String)
                pInfrastructureRoadNo = value
            End Set
        End Property

        Private pInfrastructureNameofRiver As String
        Public Property InfrastructureNameofRiver() As String
            Get
                Return pInfrastructureNameofRiver
            End Get
            Set(ByVal value As String)
                pInfrastructureNameofRiver = value
            End Set
        End Property

        Private pInfrastructureReferencePost As String
        Public Property InfrastructureReferencePost() As String
            Get
                Return pInfrastructureReferencePost
            End Get
            Set(ByVal value As String)
                pInfrastructureReferencePost = value
            End Set
        End Property

        Private pInfrastructureEndReferencePost As String
        Public Property InfrastructureEndReferencePost() As String
            Get
                Return pInfrastructureEndReferencePost
            End Get
            Set(ByVal value As String)
                pInfrastructureEndReferencePost = value
            End Set
        End Property

        Private pInfrastructureStartPosition As String
        Public Property InfrastructureStartPosition() As String
            Get
                Return pInfrastructureStartPosition
            End Get
            Set(ByVal value As String)
                pInfrastructureStartPosition = value
            End Set
        End Property

        Private pInfrastructureCurrentPosition As String
        Public Property InfrastructureCurrentPosition() As String
            Get
                Return pInfrastructureCurrentPosition
            End Get
            Set(ByVal value As String)
                pInfrastructureCurrentPosition = value
            End Set
        End Property

        Private pClassification As String
        Public Property Classification() As String
            Get
                Return pClassification
            End Get
            Set(ByVal value As String)
                pClassification = value
            End Set
        End Property

        Private pClassificationCode As String
        Public Property ClassificationCode() As String
            Get
                Return pClassificationCode
            End Get
            Set(ByVal value As String)
                pClassificationCode = value
            End Set
        End Property

        Private pTitle As String
        Public Property Title() As String
            Get
                Return pTitle
            End Get
            Set(ByVal value As String)
                pTitle = value
            End Set
        End Property

        Private pPublicationDate As String
        Public Property PublicationDate() As String
            Get
                Return pPublicationDate
            End Get
            Set(ByVal value As String)
                pPublicationDate = value
            End Set
        End Property

        Private pbPrice As String
        Public Property bPrice() As String
            Get
                Return pbPrice
            End Get
            Set(ByVal value As String)
                pbPrice = value
            End Set
        End Property

        Private pISBN As String
        Public Property ISBN() As String
            Get
                Return pISBN
            End Get
            Set(ByVal value As String)
                pISBN = value
            End Set
        End Property

        Private pAuthor As String
        Public Property Author() As String
            Get
                Return pAuthor
            End Get
            Set(ByVal value As String)
                pAuthor = value
            End Set
        End Property

        Private pNoYears As Long
        Public Property NoYears() As Long
            Get
                Return pNoYears
            End Get
            Set(ByVal value As Long)
                pNoYears = value
            End Set
        End Property

        Private pUsefulLife As Long
        Public Property UsefulLife() As Long
            Get
                Return pUsefulLife
            End Get
            Set(ByVal value As Long)
                pUsefulLife = value
            End Set
        End Property

        Private pmanufacturer As String
        Public Property manufacturer() As String
            Get
                Return pmanufacturer
            End Get
            Set(ByVal value As String)
                pmanufacturer = value
            End Set
        End Property

        Private pcaliber As String
        Public Property caliber() As String
            Get
                Return pcaliber
            End Get
            Set(ByVal value As String)
                pcaliber = value
            End Set
        End Property

        Private pbarrel As String
        Public Property barrel() As String
            Get
                Return pbarrel
            End Get
            Set(ByVal value As String)
                pbarrel = value
            End Set
        End Property

        Private pframe As String
        Public Property frame() As String
            Get
                Return pframe
            End Get
            Set(ByVal value As String)
                pframe = value
            End Set
        End Property

        Private pcolor As String
        Public Property color() As String
            Get
                Return pcolor
            End Get
            Set(ByVal value As String)
                pcolor = value
            End Set
        End Property

        Private pcapacity As String
        Public Property capacity() As String
            Get
                Return pcapacity
            End Get
            Set(ByVal value As String)
                pcapacity = value
            End Set
        End Property

        Private psights As String
        Public Property sights() As String
            Get
                Return psights
            End Get
            Set(ByVal value As String)
                psights = value
            End Set
        End Property

        Private pProperty_ID As Long
        Public Property Property_ID() As Long
            Get
                Return pProperty_ID
            End Get
            Set(ByVal value As Long)
                pProperty_ID = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long

            objDerived.cmd.Parameters.AddWithValue("@OthersInfoId", 0)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@IsAccepted", IsAccepted)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@Name", Name)
            objDerived.cmd.Parameters.AddWithValue("@Description", Description)
            objDerived.cmd.Parameters.AddWithValue("@PowerInput", PowerInput)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", DepreciationRate)
            objDerived.cmd.Parameters.AddWithValue("@Dimension", Dimension)
            objDerived.cmd.Parameters.AddWithValue("@AreaCapacity", AreaCapacity)
            objDerived.cmd.Parameters.AddWithValue("@Model", Model)
            objDerived.cmd.Parameters.AddWithValue("@Warranty", Warranty)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", DepreciationValue)
            objDerived.cmd.Parameters.AddWithValue("@Specification", Specification)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@FloorLocation", FloorLocation)
            objDerived.cmd.Parameters.AddWithValue("@RoomLocation", RoomLocation)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
            objDerived.cmd.Parameters.AddWithValue("@AccountablePerson", AccountablePerson)
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", SalvageValue)
            objDerived.cmd.Parameters.AddWithValue("@ProjectName", ProjectName)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureID", InfrastructureID)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureName", InfrastructureName)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureClassification", InfrastructureClassification)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureType", InfrastructureType)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureFromStreet", InfrastructureFromStreet)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureToStreet", InfrastructureToStreet) ' fixed trailing space
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSegmentLock", InfrastructureSegmentLock)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLocation", InfrastructureLocation)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLength", InfrastructureLength)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureNoofLanes", InfrastructureNoofLanes)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureWidth", InfrastructureWidth)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLaneLength", InfrastructureLaneLength)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLaneWidth", InfrastructureLaneWidth)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureTrafficDirection", InfrastructureTrafficDirection)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureTrafficVolume", InfrastructureTrafficVolume)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureTrafficDate", InfrastructureTrafficDate)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSpeedLimit", InfrastructureSpeedLimit)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureElevation", InfrastructureElevation)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSurfaceType", InfrastructureSurfaceType)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSurfaceCondition", InfrastructureSurfaceCondition)
            objDerived.cmd.Parameters.AddWithValue("@LeftLfromAddress", LeftLfromAddress)
            objDerived.cmd.Parameters.AddWithValue("@LeftLtoAddress", LeftLtoAddress)
            objDerived.cmd.Parameters.AddWithValue("@LeftNWshldrWidth", LeftNWshldrWidth)
            objDerived.cmd.Parameters.AddWithValue("@RightRfromAddress", RightRfromAddress)
            objDerived.cmd.Parameters.AddWithValue("@RightRtoAddress", RightRtoAddress)
            objDerived.cmd.Parameters.AddWithValue("@RightSEshldrWidth", RightSEshldrWidth)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureNumber", InfrastructureNumber)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureRoutseSignPrefix", InfrastructureRoutseSignPrefix)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureRouteNo", InfrastructureRouteNo)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureFeaturedIntersection", InfrastructureFeaturedIntersection)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureMilePoint", InfrastructureMilePoint)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureBorderStructNo", InfrastructureBorderStructNo)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureRoadNo", InfrastructureRoadNo)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureNameofRiver", InfrastructureNameofRiver)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureReferencePost", InfrastructureReferencePost)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureEndReferencePost", InfrastructureEndReferencePost)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureStartPosition", InfrastructureStartPosition)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureCurrentPosition", InfrastructureCurrentPosition)
            objDerived.cmd.Parameters.AddWithValue("@Classification", Classification)
            objDerived.cmd.Parameters.AddWithValue("@ClassificationCode", ClassificationCode)
            objDerived.cmd.Parameters.AddWithValue("@Title", Title)
            objDerived.cmd.Parameters.AddWithValue("@PublicationDate", PublicationDate)
            objDerived.cmd.Parameters.AddWithValue("@bPrice", bPrice)
            objDerived.cmd.Parameters.AddWithValue("@ISBN", ISBN)
            objDerived.cmd.Parameters.AddWithValue("@Author", Author)
            objDerived.cmd.Parameters.AddWithValue("@NoYears", NoYears)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", UsefulLife)
            objDerived.cmd.Parameters.AddWithValue("@manufacturer", manufacturer)
            objDerived.cmd.Parameters.AddWithValue("@caliber", caliber)
            objDerived.cmd.Parameters.AddWithValue("@barrel", barrel)
            objDerived.cmd.Parameters.AddWithValue("@frame", frame)
            objDerived.cmd.Parameters.AddWithValue("@color", color)
            objDerived.cmd.Parameters.AddWithValue("@capacity", capacity)
            objDerived.cmd.Parameters.AddWithValue("@sights", sights)
            objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbOthers_Info", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long

            objDerived.cmd.Parameters.AddWithValue("@OthersInfoId", OthersInfoId)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@IsAccepted", IsAccepted)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@Name", Name)
            objDerived.cmd.Parameters.AddWithValue("@Description", Description)
            objDerived.cmd.Parameters.AddWithValue("@PowerInput", PowerInput)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", DepreciationRate)
            objDerived.cmd.Parameters.AddWithValue("@Dimension", Dimension)
            objDerived.cmd.Parameters.AddWithValue("@AreaCapacity", AreaCapacity)
            objDerived.cmd.Parameters.AddWithValue("@Model", Model)
            objDerived.cmd.Parameters.AddWithValue("@Warranty", Warranty)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", DepreciationValue)
            objDerived.cmd.Parameters.AddWithValue("@Specification", Specification)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@FloorLocation", FloorLocation)
            objDerived.cmd.Parameters.AddWithValue("@RoomLocation", RoomLocation)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
            objDerived.cmd.Parameters.AddWithValue("@AccountablePerson", AccountablePerson)
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", SalvageValue)
            objDerived.cmd.Parameters.AddWithValue("@ProjectName", ProjectName)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureID", InfrastructureID)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureName", InfrastructureName)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureClassification", InfrastructureClassification)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureType", InfrastructureType)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureFromStreet", InfrastructureFromStreet)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureToStreet", InfrastructureToStreet) ' fixed trailing space
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSegmentLock", InfrastructureSegmentLock)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLocation", InfrastructureLocation)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLength", InfrastructureLength)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureNoofLanes", InfrastructureNoofLanes)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureWidth", InfrastructureWidth)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLaneLength", InfrastructureLaneLength)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLaneWidth", InfrastructureLaneWidth)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureTrafficDirection", InfrastructureTrafficDirection)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureTrafficVolume", InfrastructureTrafficVolume)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureTrafficDate", InfrastructureTrafficDate)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSpeedLimit", InfrastructureSpeedLimit)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureElevation", InfrastructureElevation)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSurfaceType", InfrastructureSurfaceType)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSurfaceCondition", InfrastructureSurfaceCondition)
            objDerived.cmd.Parameters.AddWithValue("@LeftLfromAddress", LeftLfromAddress)
            objDerived.cmd.Parameters.AddWithValue("@LeftLtoAddress", LeftLtoAddress)
            objDerived.cmd.Parameters.AddWithValue("@LeftNWshldrWidth", LeftNWshldrWidth)
            objDerived.cmd.Parameters.AddWithValue("@RightRfromAddress", RightRfromAddress)
            objDerived.cmd.Parameters.AddWithValue("@RightRtoAddress", RightRtoAddress)
            objDerived.cmd.Parameters.AddWithValue("@RightSEshldrWidth", RightSEshldrWidth)
            objDerived.cmd.Parameters.AddWithValue("@Classification", Classification)
            objDerived.cmd.Parameters.AddWithValue("@ClassificationCode", ClassificationCode)
            objDerived.cmd.Parameters.AddWithValue("@Title", Title)
            objDerived.cmd.Parameters.AddWithValue("@PublicationDate", PublicationDate)
            objDerived.cmd.Parameters.AddWithValue("@bPrice", bPrice)
            objDerived.cmd.Parameters.AddWithValue("@ISBN", ISBN)
            objDerived.cmd.Parameters.AddWithValue("@Author", Author)
            objDerived.cmd.Parameters.AddWithValue("@NoYears", NoYears)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", UsefulLife)
            objDerived.cmd.Parameters.AddWithValue("@manufacturer", manufacturer)
            objDerived.cmd.Parameters.AddWithValue("@caliber", caliber)
            objDerived.cmd.Parameters.AddWithValue("@barrel", barrel)
            objDerived.cmd.Parameters.AddWithValue("@frame", frame)
            objDerived.cmd.Parameters.AddWithValue("@color", color)
            objDerived.cmd.Parameters.AddWithValue("@capacity", capacity)
            objDerived.cmd.Parameters.AddWithValue("@sights", sights)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbOthers_Info", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class

#End Region

#Region "TbOthers_Dtl"

    Public Class TbOthers_Details
        Inherits BaseDLL.BaseDAL

        Private pOthersId As Long
        Public Property OthersId() As Long
            Get
                Return pOthersId
            End Get
            Set(ByVal value As Long)
                pOthersId = value
            End Set
        End Property

        Private pOthersInfoId As Long
        Public Property OthersInfoId() As Long
            Get
                Return pOthersInfoId
            End Get
            Set(ByVal value As Long)
                pOthersInfoId = value
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

        Private pWarehouseID As Long
        Public Property WarehouseID() As Long
            Get
                Return pWarehouseID
            End Get
            Set(ByVal value As Long)
                pWarehouseID = value
            End Set
        End Property

        Private pMarketValue As Decimal
        Public Property MarketValue() As Decimal
            Get
                Return pMarketValue
            End Get
            Set(ByVal value As Decimal)
                pMarketValue = value
            End Set
        End Property

        Private pCondition As String
        Public Property Condition() As String
            Get
                Return pCondition
            End Get
            Set(ByVal value As String)
                pCondition = value
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

        Private pBuildingId As Long
        Public Property BuildingId() As Long
            Get
                Return pBuildingId
            End Get
            Set(ByVal value As Long)
                pBuildingId = value
            End Set
        End Property

        Private pMaintenanceContractor As String
        Public Property MaintenanceContractor() As String
            Get
                Return pMaintenanceContractor
            End Get
            Set(ByVal value As String)
                pMaintenanceContractor = value
            End Set
        End Property

        Private pMaintenanceContactPerson As String
        Public Property MaintenanceContactPerson() As String
            Get
                Return pMaintenanceContactPerson
            End Get
            Set(ByVal value As String)
                pMaintenanceContactPerson = value
            End Set
        End Property

        Private pMaintenanceContactNo As String
        Public Property MaintenanceContactNo() As String
            Get
                Return pMaintenanceContactNo
            End Get
            Set(ByVal value As String)
                pMaintenanceContactNo = value
            End Set
        End Property

        Private pBay As String
        Public Property Bay() As String
            Get
                Return pBay
            End Get
            Set(ByVal value As String)
                pBay = value
            End Set
        End Property

        Private pColumn As String
        Public Property Column() As String
            Get
                Return pColumn
            End Get
            Set(ByVal value As String)
                pColumn = value
            End Set
        End Property

        Private pFloor As String
        Public Property Floor() As String
            Get
                Return pFloor
            End Get
            Set(ByVal value As String)
                pFloor = value
            End Set
        End Property

        Private pRoom As String
        Public Property Room() As String
            Get
                Return pRoom
            End Get
            Set(ByVal value As String)
                pRoom = value
            End Set
        End Property

        Private pShelves As String
        Public Property Shelves() As String
            Get
                Return pShelves
            End Get
            Set(ByVal value As String)
                pShelves = value
            End Set
        End Property

        Private pRack As String
        Public Property Rack() As String
            Get
                Return pRack
            End Get
            Set(ByVal value As String)
                pRack = value
            End Set
        End Property

        Private pBin As String
        Public Property Bin() As String
            Get
                Return pBin
            End Get
            Set(ByVal value As String)
                pBin = value
            End Set
        End Property

        Private pProperty_ID As Long
        Public Property Property_ID() As Long
            Get
                Return pProperty_ID
            End Get
            Set(ByVal value As Long)
                pProperty_ID = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long

            objDerived.cmd.Parameters.AddWithValue("@OthersId", 0)
            objDerived.cmd.Parameters.AddWithValue("@OthersInfoId", OthersInfoId)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Condition", Condition)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@warehouseid", WarehouseID)
            objDerived.cmd.Parameters.AddWithValue("@BuildingId", BuildingId)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContractor", MaintenanceContractor)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactPerson", MaintenanceContactPerson)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactNo", MaintenanceContactNo)

            objDerived.cmd.Parameters.AddWithValue("@Bay", Bay)
            objDerived.cmd.Parameters.AddWithValue("@Column", Column)
            objDerived.cmd.Parameters.AddWithValue("@Floor", Floor)
            objDerived.cmd.Parameters.AddWithValue("@Room", Room)
            objDerived.cmd.Parameters.AddWithValue("@Shelves", Shelves)
            objDerived.cmd.Parameters.AddWithValue("@Rack", Rack)
            objDerived.cmd.Parameters.AddWithValue("@Bin", Bin)
            objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbOthers_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long

            objDerived.cmd.Parameters.AddWithValue("@OthersId", OthersId)
            objDerived.cmd.Parameters.AddWithValue("@OthersInfoId", OthersInfoId)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Condition", Condition)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@warehouseid", WarehouseID)
            objDerived.cmd.Parameters.AddWithValue("@BuildingId", BuildingId)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContractor", MaintenanceContractor)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactPerson", MaintenanceContactPerson)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactNo", MaintenanceContactNo)

            objDerived.cmd.Parameters.AddWithValue("@Bay", Bay)
            objDerived.cmd.Parameters.AddWithValue("@Column", Column)
            objDerived.cmd.Parameters.AddWithValue("@Floor", Floor)
            objDerived.cmd.Parameters.AddWithValue("@Room", Room)
            objDerived.cmd.Parameters.AddWithValue("@Shelves", Shelves)
            objDerived.cmd.Parameters.AddWithValue("@Rack", Rack)
            objDerived.cmd.Parameters.AddWithValue("@Bin", Bin)
            objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbOthers_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class

#End Region



    'FURNITURE
#Region "TbFurniture_Info"

    Public Class TbFurniture_Info
        Inherits BaseDLL.BaseDAL

        Private pFurnitureInfoId As Long
        Public Property FurnitureInfoId() As Long
            Get
                Return pFurnitureInfoId
            End Get
            Set(ByVal value As Long)
                pFurnitureInfoId = value
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

        Private pIsAccepted As Boolean
        Public Property IsAccepted() As Boolean
            Get
                Return pIsAccepted
            End Get
            Set(ByVal value As Boolean)
                pIsAccepted = value
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

        Private pSerialNo As String
        Public Property SerialNo() As String
            Get
                Return pSerialNo
            End Get
            Set(ByVal value As String)
                pSerialNo = value
            End Set
        End Property


        Private pName As String
        Public Property Name() As String
            Get
                Return pName
            End Get
            Set(ByVal value As String)
                pName = value
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

        Private pDepreciationRate As String
        Public Property DepreciationRate() As String
            Get
                Return pDepreciationRate
            End Get
            Set(ByVal value As String)
                pDepreciationRate = value
            End Set
        End Property

        Private pDimension As String
        Public Property Dimension() As String
            Get
                Return pDimension
            End Get
            Set(ByVal value As String)
                pDimension = value
            End Set
        End Property

        Private pAreaCapacity As String
        Public Property AreaCapacity() As String
            Get
                Return pAreaCapacity
            End Get
            Set(ByVal value As String)
                pAreaCapacity = value
            End Set
        End Property

        Private pModel As String
        Public Property Model() As String
            Get
                Return pModel
            End Get
            Set(ByVal value As String)
                pModel = value
            End Set
        End Property

        Private pWarranty As String
        Public Property Warranty() As String
            Get
                Return pWarranty
            End Get
            Set(ByVal value As String)
                pWarranty = value
            End Set
        End Property

        Private pDepreciationValue As Decimal
        Public Property DepreciationValue() As Decimal
            Get
                Return pDepreciationValue
            End Get
            Set(ByVal value As Decimal)
                pDepreciationValue = value
            End Set
        End Property

        Private pSpecification As String
        Public Property Specification() As String
            Get
                Return pSpecification
            End Get
            Set(ByVal value As String)
                pSpecification = value
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

        Private pFloorLocation As String
        Public Property FloorLocation() As String
            Get
                Return pFloorLocation
            End Get
            Set(ByVal value As String)
                pFloorLocation = value
            End Set
        End Property

        Private pRoomLocation As String
        Public Property RoomLocation() As String
            Get
                Return pRoomLocation
            End Get
            Set(ByVal value As String)
                pRoomLocation = value
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

        Private pAccountablePerson As String
        Public Property AccountablePerson() As String
            Get
                Return pAccountablePerson
            End Get
            Set(ByVal value As String)
                pAccountablePerson = value
            End Set
        End Property
        Private pSalvageValue As Decimal
        Public Property SalvalgeValue() As Decimal
            Get
                Return pSalvageValue
            End Get
            Set(ByVal value As Decimal)
                pSalvageValue = value
            End Set
        End Property



        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@FurnitureInfoId", 0)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@IsAccepted", IsAccepted)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@Name", Name)
            objDerived.cmd.Parameters.AddWithValue("@Description", Description)
            objDerived.cmd.Parameters.AddWithValue("@Dimension", Dimension)
            objDerived.cmd.Parameters.AddWithValue("@AreaCapacity", AreaCapacity)
            objDerived.cmd.Parameters.AddWithValue("@Model", Model)
            objDerived.cmd.Parameters.AddWithValue("@Warranty", Warranty)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", DepreciationRate)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", DepreciationValue)
            objDerived.cmd.Parameters.AddWithValue("@Specification", Specification)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@FloorLocation", FloorLocation)
            objDerived.cmd.Parameters.AddWithValue("@RoomLocation", RoomLocation)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
            objDerived.cmd.Parameters.AddWithValue("@AccountablePerson", AccountablePerson)
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", SalvalgeValue)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbFurniture_Info", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@FurnitureInfoId", FurnitureInfoId)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@IsAccepted", IsAccepted)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@Name", Name)
            objDerived.cmd.Parameters.AddWithValue("@Description", Description)
            objDerived.cmd.Parameters.AddWithValue("@Dimension", Dimension)
            objDerived.cmd.Parameters.AddWithValue("@AreaCapacity", AreaCapacity)
            objDerived.cmd.Parameters.AddWithValue("@Model", Model)
            objDerived.cmd.Parameters.AddWithValue("@Warranty", Warranty)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", DepreciationRate)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", DepreciationValue)
            objDerived.cmd.Parameters.AddWithValue("@Specification", Specification)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@FloorLocation", FloorLocation)
            objDerived.cmd.Parameters.AddWithValue("@RoomLocation", RoomLocation)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
            objDerived.cmd.Parameters.AddWithValue("@AccountablePerson", AccountablePerson)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbFurniture_Info", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class


#End Region
#Region "TbFurniture_Dtl"

    Public Class TbFurniture_Dtl
        Inherits BaseDLL.BaseDAL

        Private pFurnitureId As Long
        Public Property FurnitureId() As Long
            Get
                Return pFurnitureId
            End Get
            Set(ByVal value As Long)
                pFurnitureId = value
            End Set
        End Property

        Private pFurnitureInfoId As Long
        Public Property FurnitureInfoId() As Long
            Get
                Return pFurnitureInfoId
            End Get
            Set(ByVal value As Long)
                pFurnitureInfoId = value
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

        Private pMarketValue As Decimal
        Public Property MarketValue() As Decimal
            Get
                Return pMarketValue
            End Get
            Set(ByVal value As Decimal)
                pMarketValue = value
            End Set
        End Property

        Private pCondition As String
        Public Property Condition() As String
            Get
                Return pCondition
            End Get
            Set(ByVal value As String)
                pCondition = value
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


        Private pPowerInput As String
        Public Property PowerInput() As String
            Get
                Return pPowerInput
            End Get
            Set(ByVal value As String)
                pPowerInput = value
            End Set
        End Property

        Private pBuildingId As Long
        Public Property BuildingId() As Long
            Get
                Return pBuildingId
            End Get
            Set(ByVal value As Long)
                pBuildingId = value
            End Set
        End Property

        Private pMaintenanceContractor As String
        Public Property MaintenanceContractor() As String
            Get
                Return pMaintenanceContractor
            End Get
            Set(ByVal value As String)
                pMaintenanceContractor = value
            End Set
        End Property

        Private pMaintenanceContactPerson As String
        Public Property MaintenanceContactPerson() As String
            Get
                Return pMaintenanceContactPerson
            End Get
            Set(ByVal value As String)
                pMaintenanceContactPerson = value
            End Set
        End Property

        Private pMaintenanceContactNo As String
        Public Property MaintenanceContactNo() As String
            Get
                Return pMaintenanceContactNo
            End Get
            Set(ByVal value As String)
                pMaintenanceContactNo = value
            End Set
        End Property

        Private pNoYears As Long
        Public Property NoYears() As Long
            Get
                Return pNoYears
            End Get
            Set(ByVal value As Long)
                pNoYears = value
            End Set
        End Property

        Private pUsefulLife As Long
        Public Property UsefulLife() As Long
            Get
                Return pUsefulLife
            End Get
            Set(ByVal value As Long)
                pUsefulLife = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@FurnitureId", 0)
            objDerived.cmd.Parameters.AddWithValue("@FurnitureInfoId", FurnitureInfoId)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Condition", Condition)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@PowerInput", PowerInput)
            objDerived.cmd.Parameters.AddWithValue("@BuildingId", BuildingId)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContractor", MaintenanceContractor)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactPerson", MaintenanceContactPerson)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactNo", MaintenanceContactNo)
            objDerived.cmd.Parameters.AddWithValue("@NoYears", NoYears)
            objDerived.cmd.Parameters.AddWithValue("@UsefuleLife", UsefulLife)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbFurniture_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@FurnitureId", FurnitureId)
            objDerived.cmd.Parameters.AddWithValue("@FurnitureInfoId", FurnitureInfoId)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Condition", Condition)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@PowerInput", PowerInput)
            objDerived.cmd.Parameters.AddWithValue("@BuildingId", BuildingId)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContractor", MaintenanceContractor)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactPerson", MaintenanceContactPerson)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactNo", MaintenanceContactNo)
            objDerived.cmd.Parameters.AddWithValue("@NoYears", NoYears)
            objDerived.cmd.Parameters.AddWithValue("@UsefuleLife", UsefulLife)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbFurniture_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class


#End Region

    'MACHINERIES
#Region "TbMachinery_Information"

    Public Class TbMachinery_Information
        Inherits BaseDLL.BaseDAL

        Private pMachineryInfoId As Long
        Public Property MachineryInfoId() As Long
            Get
                Return pMachineryInfoId
            End Get
            Set(ByVal value As Long)
                pMachineryInfoId = value
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

        Private pIsAccepted As Boolean
        Public Property IsAccepted() As Boolean
            Get
                Return pIsAccepted
            End Get
            Set(ByVal value As Boolean)
                pIsAccepted = value
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

        Private pSerialNo As String
        Public Property SerialNo() As String
            Get
                Return pSerialNo
            End Get
            Set(ByVal value As String)
                pSerialNo = value
            End Set
        End Property

        Private pBrandModel As String
        Public Property BrandModel() As String
            Get
                Return pBrandModel
            End Get
            Set(ByVal value As String)
                pBrandModel = value
            End Set
        End Property

        Private pAreaCapacity As String
        Public Property AreaCapacity() As String
            Get
                Return pAreaCapacity
            End Get
            Set(ByVal value As String)
                pAreaCapacity = value
            End Set
        End Property


        Private pWarranty As String
        Public Property Warranty() As String
            Get
                Return pWarranty
            End Get
            Set(ByVal value As String)
                pWarranty = value
            End Set
        End Property
        Private pMachineDesc As String
        Public Property MachineDesc() As String
            Get
                Return pMachineDesc
            End Get
            Set(ByVal value As String)
                pMachineDesc = value
            End Set
        End Property

        Private pMachineLocation As String
        Public Property MachineLocation() As String
            Get
                Return pMachineLocation
            End Get
            Set(ByVal value As String)
                pMachineLocation = value
            End Set
        End Property

        Private pNoPassengers As String
        Public Property NoPassengers() As String
            Get
                Return pNoPassengers
            End Get
            Set(ByVal value As String)
                pNoPassengers = value
            End Set
        End Property

        Private pServiceFloors As String
        Public Property ServiceFloors() As String
            Get
                Return pServiceFloors
            End Get
            Set(ByVal value As String)
                pServiceFloors = value
            End Set
        End Property

        Private pMachineUnitNo As String
        Public Property MachineUnitNo() As String
            Get
                Return pMachineUnitNo
            End Get
            Set(ByVal value As String)
                pMachineUnitNo = value
            End Set
        End Property

        Private pWorkingLoad As String
        Public Property WorkingLoad() As String
            Get
                Return pWorkingLoad
            End Get
            Set(ByVal value As String)
                pWorkingLoad = value
            End Set
        End Property

        Private pRatedSpeed As String
        Public Property RatedSpeed() As String
            Get
                Return pRatedSpeed
            End Get
            Set(ByVal value As String)
                pRatedSpeed = value
            End Set
        End Property

        Private pCarDimensions As String
        Public Property CarDimensions() As String
            Get
                Return pCarDimensions
            End Get
            Set(ByVal value As String)
                pCarDimensions = value
            End Set
        End Property

        Private pDepreciationRate As String
        Public Property DepreciationRate() As String
            Get
                Return pDepreciationRate
            End Get
            Set(ByVal value As String)
                pDepreciationRate = value
            End Set
        End Property

        Private pDepreciationValue As String
        Public Property DepreciationValue() As String
            Get
                Return pDepreciationValue
            End Get
            Set(ByVal value As String)
                pDepreciationValue = value
            End Set
        End Property


        Private pSalvageValue As String
        Public Property SalvageValue() As String
            Get
                Return pSalvageValue
            End Get
            Set(ByVal value As String)
                pSalvageValue = value
            End Set
        End Property
        Private pMechinePermitNo As String
        Public Property MechinePermitNo() As String
            Get
                Return pMechinePermitNo
            End Get
            Set(ByVal value As String)
                pMechinePermitNo = value
            End Set
        End Property

        Private pDateOperate As Date
        Public Property DateOperate() As Date
            Get
                Return pDateOperate
            End Get
            Set(ByVal value As Date)
                pDateOperate = value
            End Set
        End Property

        Private pDateIssued As Date
        Public Property DateIssued() As Date
            Get
                Return pDateIssued
            End Get
            Set(ByVal value As Date)
                pDateIssued = value
            End Set
        End Property

        Private pDateInspected As Date
        Public Property DateInspected() As Date
            Get
                Return pDateInspected
            End Get
            Set(ByVal value As Date)
                pDateInspected = value
            End Set
        End Property

        Private pInspectedBy As String
        Public Property InspectedBy() As String
            Get
                Return pInspectedBy
            End Get
            Set(ByVal value As String)
                pInspectedBy = value
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

        Private pDateTaken As Date
        Public Property DateTaken() As Date
            Get
                Return pDateTaken
            End Get
            Set(ByVal value As Date)
                pDateTaken = value
            End Set
        End Property

        Private pUploadedBy As String
        Public Property UploadedBy() As String
            Get
                Return pUploadedBy
            End Get
            Set(ByVal value As String)
                pUploadedBy = value
            End Set
        End Property

        Private pPosition As String
        Public Property Position() As String
            Get
                Return pPosition
            End Get
            Set(ByVal value As String)
                pPosition = value
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

        Private pItem_ID As Long
        Public Property Item_ID() As Long
            Get
                Return pItem_ID
            End Get
            Set(ByVal value As Long)
                pItem_ID = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@MachineryInfoId", 0)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@IsAccepted", IsAccepted)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@BrandModel", BrandModel)
            objDerived.cmd.Parameters.AddWithValue("@MachineDesc", MachineDesc)
            objDerived.cmd.Parameters.AddWithValue("@MachineLocation", MachineLocation)
            objDerived.cmd.Parameters.AddWithValue("@NoPassengers", NoPassengers)
            objDerived.cmd.Parameters.AddWithValue("@ServiceFloors", ServiceFloors)
            objDerived.cmd.Parameters.AddWithValue("@MachineUnitNo", MachineUnitNo)
            objDerived.cmd.Parameters.AddWithValue("@WorkingLoad", WorkingLoad)
            objDerived.cmd.Parameters.AddWithValue("@RatedSpeed", RatedSpeed)
            objDerived.cmd.Parameters.AddWithValue("@CarDimensions", CarDimensions)
            objDerived.cmd.Parameters.AddWithValue("@MechinePermitNo", MechinePermitNo)
            objDerived.cmd.Parameters.AddWithValue("@DateOperate", DateOperate)
            objDerived.cmd.Parameters.AddWithValue("@DateIssued", DateIssued)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", DepreciationRate)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", DepreciationValue)
            objDerived.cmd.Parameters.AddWithValue("@DateInspected", DateInspected)
            objDerived.cmd.Parameters.AddWithValue("@InspectedBy", InspectedBy)
            objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@AreaCapacity", AreaCapacity)
            objDerived.cmd.Parameters.AddWithValue("@Warranty", Warranty)
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", SalvageValue)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)

            'objDerived.cmd.Parameters.AddWithValue("@UploadedBy", UploadedBy)
            'objDerived.cmd.Parameters.AddWithValue("@Position", Position)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbMachinery_Information", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@MachineryInfoId", MachineryInfoId)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@IsAccepted", IsAccepted)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@BrandModel", BrandModel)
            objDerived.cmd.Parameters.AddWithValue("@MachineDesc", MachineDesc)
            objDerived.cmd.Parameters.AddWithValue("@MachineLocation", MachineLocation)
            objDerived.cmd.Parameters.AddWithValue("@NoPassengers", NoPassengers)
            objDerived.cmd.Parameters.AddWithValue("@ServiceFloors", ServiceFloors)
            objDerived.cmd.Parameters.AddWithValue("@MachineUnitNo", MachineUnitNo)
            objDerived.cmd.Parameters.AddWithValue("@WorkingLoad", WorkingLoad)
            objDerived.cmd.Parameters.AddWithValue("@RatedSpeed", RatedSpeed)
            objDerived.cmd.Parameters.AddWithValue("@CarDimensions", CarDimensions)
            objDerived.cmd.Parameters.AddWithValue("@MechinePermitNo", MechinePermitNo)
            objDerived.cmd.Parameters.AddWithValue("@DateOperate", DateOperate)
            objDerived.cmd.Parameters.AddWithValue("@DateIssued", DateIssued)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", DepreciationRate)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", DepreciationValue)
            objDerived.cmd.Parameters.AddWithValue("@DateInspected", DateInspected)
            objDerived.cmd.Parameters.AddWithValue("@InspectedBy", InspectedBy)
            objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            'objDerived.cmd.Parameters.AddWithValue("@DateTaken", DateTaken)
            'objDerived.cmd.Parameters.AddWithValue("@UploadedBy", UploadedBy)
            'objDerived.cmd.Parameters.AddWithValue("@Position", Position)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbMachinery_Information", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region
#Region "TbMachinery_Dtl"

    Public Class TbMachinery_Dtl
        Inherits BaseDLL.BaseDAL

        Private pMachineryId As Long
        Public Property MachineryId() As Long
            Get
                Return pMachineryId
            End Get
            Set(ByVal value As Long)
                pMachineryId = value
            End Set
        End Property

        Private pMachineryInfoId As Long
        Public Property MachineryInfoId() As Long
            Get
                Return pMachineryInfoId
            End Get
            Set(ByVal value As Long)
                pMachineryInfoId = value
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


        Private pbuildingid As Long
        Public Property buildingid() As Long
            Get
                Return pbuildingid
            End Get
            Set(ByVal value As Long)
                pbuildingid = value
            End Set
        End Property

        Private pNoYears As Long
        Public Property NoYears() As Long
            Get
                Return pNoYears
            End Get
            Set(ByVal value As Long)
                pNoYears = value
            End Set
        End Property


        Private pUsefulLife As Long
        Public Property UsefulLife() As Long
            Get
                Return pUsefulLife
            End Get
            Set(ByVal value As Long)
                pUsefulLife = value
            End Set
        End Property


        Private pMarketValue As Decimal
        Public Property MarketValue() As Decimal
            Get
                Return pMarketValue
            End Get
            Set(ByVal value As Decimal)
                pMarketValue = value
            End Set
        End Property

        Private pCondition As String
        Public Property Condition() As String
            Get
                Return pCondition
            End Get
            Set(ByVal value As String)
                pCondition = value
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


        Private pMachineName As String
        Public Property MachineName() As String
            Get
                Return pMachineName
            End Get
            Set(ByVal value As String)
                pMachineName = value
            End Set
        End Property


        Private pMaintenanceContractor As String
        Public Property MaintenanceContractor() As String
            Get
                Return pMaintenanceContractor
            End Get
            Set(ByVal value As String)
                pMaintenanceContractor = value
            End Set
        End Property


        Private pMaintenanceContactPerson As String
        Public Property MaintenanceContactPerson() As String
            Get
                Return pMaintenanceContactPerson
            End Get
            Set(ByVal value As String)
                pMaintenanceContactPerson = value
            End Set
        End Property


        Private pMaintenanceContactNo As String
        Public Property MaintenanceContactNo() As String
            Get
                Return pMaintenanceContactNo
            End Get
            Set(ByVal value As String)
                pMaintenanceContactNo = value
            End Set
        End Property

        Private pPowerInput As String
        Public Property PowerInput() As String
            Get
                Return pPowerInput
            End Get
            Set(ByVal value As String)
                pPowerInput = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@MachineryId", 0)
            objDerived.cmd.Parameters.AddWithValue("@MachineryInfoId", MachineryInfoId)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Condition", Condition)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@MachineName", MachineName)
            objDerived.cmd.Parameters.AddWithValue("@PowerInput", PowerInput)
            objDerived.cmd.Parameters.AddWithValue("@buildingid", buildingid)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContractor", MaintenanceContractor)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactPerson", MaintenanceContactPerson)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactNo", MaintenanceContactNo)
            objDerived.cmd.Parameters.AddWithValue("@NoYears", NoYears)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", UsefulLife)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbMachinery_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@MachineryId", MachineryId)
            objDerived.cmd.Parameters.AddWithValue("@MachineryInfoId", MachineryInfoId)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Condition", Condition)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@MachineName", MachineName)
            objDerived.cmd.Parameters.AddWithValue("@PowerInput", PowerInput)
            objDerived.cmd.Parameters.AddWithValue("@buildingid", buildingid)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContractor", MaintenanceContractor)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactPerson", MaintenanceContactPerson)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactNo", MaintenanceContactNo)
            objDerived.cmd.Parameters.AddWithValue("@NoYears", NoYears)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", UsefulLife)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbMachinery_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

    'TRANSPORTATION
#Region "TbMotor_Info"

    Public Class TbMotor_Info
        Inherits BaseDLL.BaseDAL

        Private pMotor_InfoId As Long
        Public Property Motor_InfoId() As Long
            Get
                Return pMotor_InfoId
            End Get
            Set(ByVal value As Long)
                pMotor_InfoId = value
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

        Private pIsAccepted As Boolean
        Public Property IsAccepted() As Boolean
            Get
                Return pIsAccepted
            End Get
            Set(ByVal value As Boolean)
                pIsAccepted = value
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

        'Private pSerialNo As String
        'Public Property SerialNo() As String
        '    Get
        '        Return pSerialNo
        '    End Get
        '    Set(ByVal value As String)
        '        pSerialNo = value
        '    End Set
        'End Property


        Private pName As String
        Public Property Name() As String
            Get
                Return pName
            End Get
            Set(ByVal value As String)
                pName = value
            End Set
        End Property

        Private pPlateNo As String
        Public Property PlateNo() As String
            Get
                Return pPlateNo
            End Get
            Set(ByVal value As String)
                pPlateNo = value
            End Set
        End Property

        Private pMotorNo As String
        Public Property MotorNo() As String
            Get
                Return pMotorNo
            End Get
            Set(ByVal value As String)
                pMotorNo = value
            End Set
        End Property

        Private pModel As String
        Public Property Model() As String
            Get
                Return pModel
            End Get
            Set(ByVal value As String)
                pModel = value
            End Set
        End Property

        Private pChasisNo As String
        Public Property ChasisNo() As String
            Get
                Return pChasisNo
            End Get
            Set(ByVal value As String)
                pChasisNo = value
            End Set
        End Property

        Private pVehicleColor As String
        Public Property VehicleColor() As String
            Get
                Return pVehicleColor
            End Get
            Set(ByVal value As String)
                pVehicleColor = value
            End Set
        End Property

        Private pWheelsCapacity As String
        Public Property WheelsCapacity() As String
            Get
                Return pWheelsCapacity
            End Get
            Set(ByVal value As String)
                pWheelsCapacity = value
            End Set
        End Property

        Private pGrossWeight As String
        Public Property GrossWeight() As String
            Get
                Return pGrossWeight
            End Get
            Set(ByVal value As String)
                pGrossWeight = value
            End Set
        End Property

        Private pSeats As String
        Public Property Seats() As String
            Get
                Return pSeats
            End Get
            Set(ByVal value As String)
                pSeats = value
            End Set
        End Property

        Private pWarranty As String
        Public Property Warranty() As String
            Get
                Return pWarranty
            End Get
            Set(ByVal value As String)
                pWarranty = value
            End Set
        End Property

        Private pVehicleOwner As String
        Public Property VehicleOwner() As String
            Get
                Return pVehicleOwner
            End Get
            Set(ByVal value As String)
                pVehicleOwner = value
            End Set
        End Property

        Private pDeclaredName As String
        Public Property DeclaredName() As String
            Get
                Return pDeclaredName
            End Get
            Set(ByVal value As String)
                pDeclaredName = value
            End Set
        End Property

        Private pBeneficialUser As String
        Public Property BeneficialUser() As String
            Get
                Return pBeneficialUser
            End Get
            Set(ByVal value As String)
                pBeneficialUser = value
            End Set
        End Property

        Private pVehicleSpecification As String
        Public Property VehicleSpecification() As String
            Get
                Return pVehicleSpecification
            End Get
            Set(ByVal value As String)
                pVehicleSpecification = value
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

        Private pVehicleDesc As String
        Public Property VehicleDesc() As String
            Get
                Return pVehicleDesc
            End Get
            Set(ByVal value As String)
                pVehicleDesc = value
            End Set
        End Property

        Private pVehicleMake As String
        Public Property VehicleMake() As String
            Get
                Return pVehicleMake
            End Get
            Set(ByVal value As String)
                pVehicleMake = value
            End Set
        End Property

        Private pVehicleType As String
        Public Property VehicleType() As String
            Get
                Return pVehicleType
            End Get
            Set(ByVal value As String)
                pVehicleType = value
            End Set
        End Property

        Private pPowerInput As String
        Public Property PowerInput() As String
            Get
                Return pPowerInput
            End Get
            Set(ByVal value As String)
                pPowerInput = value
            End Set
        End Property

        Private pMVfileNo As String
        Public Property MVfileNo() As String
            Get
                Return pMVfileNo
            End Get
            Set(ByVal value As String)
                pMVfileNo = value
            End Set
        End Property


        Private pConSticker As String
        Public Property ConSticker() As String
            Get
                Return pConSticker
            End Get
            Set(ByVal value As String)
                pConSticker = value
            End Set
        End Property


        Private pDepRate As Long
        Public Property DepRate() As Long
            Get
                Return pDepRate
            End Get
            Set(ByVal value As Long)
                pDepRate = value
            End Set
        End Property

        Private pDepValue As Long
        Public Property DepValue() As Long
            Get
                Return pDepValue
            End Get
            Set(ByVal value As Long)
                pDepValue = value
            End Set
        End Property

        Private pNoofYears As Long
        Public Property NoofYears() As Long
            Get
                Return pNoofYears
            End Get
            Set(ByVal value As Long)
                pNoofYears = value
            End Set
        End Property

        Private pUsefulLife As Long
        Public Property UsefulLife() As Long
            Get
                Return pUsefulLife
            End Get
            Set(ByVal value As Long)
                pUsefulLife = value
            End Set
        End Property

        Private pSalvageValue As Long
        Public Property SalvageValue() As Long
            Get
                Return pSalvageValue
            End Get
            Set(ByVal value As Long)
                pSalvageValue = value
            End Set
        End Property

        Private pMMSI As String
        Public Property MMSI() As String
            Get
                Return pMMSI
            End Get
            Set(ByVal value As String)
                pMMSI = value
            End Set
        End Property

        Private pCallSign As String
        Public Property CallSign() As String
            Get
                Return pCallSign
            End Get
            Set(ByVal value As String)
                pCallSign = value
            End Set
        End Property

        Private pIMOno As String
        Public Property IMOno() As String
            Get
                Return pIMOno
            End Get
            Set(ByVal value As String)
                pIMOno = value
            End Set
        End Property

        Private pHullMaterial As String
        Public Property HullMaterial() As String
            Get
                Return pHullMaterial
            End Get
            Set(ByVal value As String)
                pHullMaterial = value
            End Set
        End Property

        Private pNoofMast As String
        Public Property NoofMast() As String
            Get
                Return pNoofMast
            End Get
            Set(ByVal value As String)
                pNoofMast = value
            End Set
        End Property


        Private pNoofDecks As String
        Public Property NoofDecks() As String
            Get
                Return pNoofDecks
            End Get
            Set(ByVal value As String)
                pNoofDecks = value
            End Set
        End Property

        Private pNoofEngine As String
        Public Property NoofEngine() As String
            Get
                Return pNoofEngine
            End Get
            Set(ByVal value As String)
                pNoofEngine = value
            End Set
        End Property

        Private pMainEngine As String
        Public Property MainEngine() As String
            Get
                Return pMainEngine
            End Get
            Set(ByVal value As String)
                pMainEngine = value
            End Set
        End Property

        Private pHorsePower As String
        Public Property HorsePower() As String
            Get
                Return pHorsePower
            End Get
            Set(ByVal value As String)
                pHorsePower = value
            End Set
        End Property

        Private pGrt As String
        Public Property Grt() As String
            Get
                Return pGrt
            End Get
            Set(ByVal value As String)
                pGrt = value
            End Set
        End Property

        Private pNrt As String
        Public Property Nrt() As String
            Get
                Return pNrt
            End Get
            Set(ByVal value As String)
                pNrt = value
            End Set
        End Property

        Private pLoa As String
        Public Property Loa() As String
            Get
                Return pLoa
            End Get
            Set(ByVal value As String)
                pLoa = value
            End Set
        End Property

        Private pBreadth As String
        Public Property Breadth() As String
            Get
                Return pBreadth
            End Get
            Set(ByVal value As String)
                pBreadth = value
            End Set
        End Property

        Private pCarryingCapacity As String
        Public Property CarryingCapacity() As String
            Get
                Return pCarryingCapacity
            End Get
            Set(ByVal value As String)
                pCarryingCapacity = value
            End Set
        End Property



        Private pCsNo As String
        Public Property CsNo() As String
            Get
                Return pCsNo
            End Get
            Set(ByVal value As String)
                pCsNo = value
            End Set
        End Property


        Private pEngineNo As String
        Public Property EngineNo() As String
            Get
                Return pEngineNo
            End Get
            Set(ByVal value As String)
                pEngineNo = value
            End Set
        End Property



        Private pDisplacement As String
        Public Property Displacement() As String
            Get
                Return pDisplacement
            End Get
            Set(ByVal value As String)
                pDisplacement = value
            End Set
        End Property


        Private pMotorWeight As String
        Public Property MotorWeight() As String
            Get
                Return pMotorWeight
            End Get
            Set(ByVal value As String)
                pMotorWeight = value
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

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Motor_InfoId", 0)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@IsAccepted", IsAccepted)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            'objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@Name", Name)
            objDerived.cmd.Parameters.AddWithValue("@PlateNo", PlateNo)
            objDerived.cmd.Parameters.AddWithValue("@MotorNo", MotorNo)
            objDerived.cmd.Parameters.AddWithValue("@Model", Model)
            objDerived.cmd.Parameters.AddWithValue("@ChasisNo", ChasisNo)
            objDerived.cmd.Parameters.AddWithValue("@VehicleColor", VehicleColor)
            objDerived.cmd.Parameters.AddWithValue("@WheelsCapacity", WheelsCapacity)
            objDerived.cmd.Parameters.AddWithValue("@GrossWeight", GrossWeight)
            objDerived.cmd.Parameters.AddWithValue("@Seats", Seats)
            objDerived.cmd.Parameters.AddWithValue("@Warranty", Warranty)
            objDerived.cmd.Parameters.AddWithValue("@VehicleOwner", VehicleOwner)
            objDerived.cmd.Parameters.AddWithValue("@DeclaredName", DeclaredName)
            objDerived.cmd.Parameters.AddWithValue("@BeneficialUser", BeneficialUser)
            objDerived.cmd.Parameters.AddWithValue("@VehicleSpecification", VehicleSpecification)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@VehicleDesc", VehicleDesc)
            objDerived.cmd.Parameters.AddWithValue("@VehicleMake", VehicleMake)
            objDerived.cmd.Parameters.AddWithValue("@VehicleType", VehicleType)
            objDerived.cmd.Parameters.AddWithValue("@PowerInput", PowerInput)
            objDerived.cmd.Parameters.AddWithValue("@MVfileNo", MVfileNo)
            objDerived.cmd.Parameters.AddWithValue("@ConSticker", ConSticker)
            objDerived.cmd.Parameters.AddWithValue("@DepRate", DepRate)
            objDerived.cmd.Parameters.AddWithValue("@DepValue", DepValue)
            objDerived.cmd.Parameters.AddWithValue("@NoofYears", NoofYears)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", UsefulLife)
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", SalvageValue)
            objDerived.cmd.Parameters.AddWithValue("@MMSI", MMSI)
            objDerived.cmd.Parameters.AddWithValue("@CallSign", CallSign)
            objDerived.cmd.Parameters.AddWithValue("@IMOno", IMOno)
            objDerived.cmd.Parameters.AddWithValue("@HullMaterial", HullMaterial)
            objDerived.cmd.Parameters.AddWithValue("@NoofMast", NoofMast)
            objDerived.cmd.Parameters.AddWithValue("@NoofDecks", NoofDecks)
            objDerived.cmd.Parameters.AddWithValue("@NoofEngine", NoofEngine)
            objDerived.cmd.Parameters.AddWithValue("@MainEngine", MainEngine)
            objDerived.cmd.Parameters.AddWithValue("@HorsePower", HorsePower)
            objDerived.cmd.Parameters.AddWithValue("@Grt", Grt)
            objDerived.cmd.Parameters.AddWithValue("@Nrt", Nrt)
            objDerived.cmd.Parameters.AddWithValue("@Loa", Loa)
            objDerived.cmd.Parameters.AddWithValue("@Breadth", Breadth)
            objDerived.cmd.Parameters.AddWithValue("@CarryingCapacity", CarryingCapacity)

            objDerived.cmd.Parameters.AddWithValue("@CsNo", CsNo)
            objDerived.cmd.Parameters.AddWithValue("@EngineNo", EngineNo)
            objDerived.cmd.Parameters.AddWithValue("@Displacement", Displacement)
            objDerived.cmd.Parameters.AddWithValue("@MotorWeight", MotorWeight)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)


            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbMotor_Info", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Motor_InfoId", Motor_InfoId)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@IsAccepted", IsAccepted)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            'objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@Name", Name)
            objDerived.cmd.Parameters.AddWithValue("@PlateNo", PlateNo)
            objDerived.cmd.Parameters.AddWithValue("@MotorNo", MotorNo)
            objDerived.cmd.Parameters.AddWithValue("@Model", Model)
            objDerived.cmd.Parameters.AddWithValue("@ChasisNo", ChasisNo)
            objDerived.cmd.Parameters.AddWithValue("@VehicleColor", VehicleColor)
            objDerived.cmd.Parameters.AddWithValue("@WheelsCapacity", WheelsCapacity)
            objDerived.cmd.Parameters.AddWithValue("@GrossWeight", GrossWeight)
            objDerived.cmd.Parameters.AddWithValue("@Seats", Seats)
            objDerived.cmd.Parameters.AddWithValue("@Warranty", Warranty)
            objDerived.cmd.Parameters.AddWithValue("@VehicleOwner", VehicleOwner)
            objDerived.cmd.Parameters.AddWithValue("@DeclaredName", DeclaredName)
            objDerived.cmd.Parameters.AddWithValue("@BeneficialUser", BeneficialUser)
            objDerived.cmd.Parameters.AddWithValue("@VehicleSpecification", VehicleSpecification)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@VehicleDesc", VehicleDesc)
            objDerived.cmd.Parameters.AddWithValue("@VehicleMake", VehicleMake)
            objDerived.cmd.Parameters.AddWithValue("@VehicleType", VehicleType)
            objDerived.cmd.Parameters.AddWithValue("@PowerInput", PowerInput)
            objDerived.cmd.Parameters.AddWithValue("@MVfileNo", MVfileNo)
            objDerived.cmd.Parameters.AddWithValue("@ConSticker", ConSticker)
            objDerived.cmd.Parameters.AddWithValue("@DepRate", DepRate)
            objDerived.cmd.Parameters.AddWithValue("@DepValue", DepValue)
            objDerived.cmd.Parameters.AddWithValue("@NoofYears", NoofYears)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", UsefulLife)
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", SalvageValue)
            objDerived.cmd.Parameters.AddWithValue("@MMSI", MMSI)
            objDerived.cmd.Parameters.AddWithValue("@CallSign", CallSign)
            objDerived.cmd.Parameters.AddWithValue("@IMOno", IMOno)
            objDerived.cmd.Parameters.AddWithValue("@HullMaterial", HullMaterial)
            objDerived.cmd.Parameters.AddWithValue("@NoofMast", NoofMast)
            objDerived.cmd.Parameters.AddWithValue("@NoofDecks", NoofDecks)
            objDerived.cmd.Parameters.AddWithValue("@NoofEngine", NoofEngine)
            objDerived.cmd.Parameters.AddWithValue("@MainEngine", MainEngine)
            objDerived.cmd.Parameters.AddWithValue("@HorsePower", HorsePower)
            objDerived.cmd.Parameters.AddWithValue("@Grt", Grt)
            objDerived.cmd.Parameters.AddWithValue("@Nrt", Nrt)
            objDerived.cmd.Parameters.AddWithValue("@Loa", Loa)
            objDerived.cmd.Parameters.AddWithValue("@Breadth", Breadth)
            objDerived.cmd.Parameters.AddWithValue("@CarryingCapacity", CarryingCapacity)

            objDerived.cmd.Parameters.AddWithValue("@CsNo", CsNo)
            objDerived.cmd.Parameters.AddWithValue("@EngineNo", EngineNo)
            objDerived.cmd.Parameters.AddWithValue("@Displacement", Displacement)
            objDerived.cmd.Parameters.AddWithValue("@MotorWeight", MotorWeight)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbMotor_Info", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class


#End Region
#Region "TbMotor_Dtl"

    Public Class TbMotor_Dtl
        Inherits BaseDLL.BaseDAL

        Private pMotorID As Long
        Public Property MotorID() As Long
            Get
                Return pMotorID
            End Get
            Set(ByVal value As Long)
                pMotorID = value
            End Set
        End Property

        Private pMotor_InfoId As Long
        Public Property Motor_InfoId() As Long
            Get
                Return pMotor_InfoId
            End Get
            Set(ByVal value As Long)
                pMotor_InfoId = value
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

        Private pMarketValue As Decimal
        Public Property MarketValue() As Decimal
            Get
                Return pMarketValue
            End Get
            Set(ByVal value As Decimal)
                pMarketValue = value
            End Set
        End Property

        Private pCondition As String
        Public Property Condition() As String
            Get
                Return pCondition
            End Get
            Set(ByVal value As String)
                pCondition = value
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

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@MotorID", MotorID)
            objDerived.cmd.Parameters.AddWithValue("@Motor_InfoId", Motor_InfoId)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Condition", Condition)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbMotor_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@MotorID", MotorID)
            objDerived.cmd.Parameters.AddWithValue("@Motor_InfoId", Motor_InfoId)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Condition", Condition)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbMotor_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

    'PropertySerial
#Region "PropSerial"

    Public Class PropSerial
        Inherits BaseDLL.BaseDAL

        Private pItem_Serial_ID As Long
        Public Property Item_Serial_ID() As Long
            Get
                Return pItem_Serial_ID
            End Get
            Set(ByVal value As Long)
                pItem_Serial_ID = value
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

        Private pCondition As String
        Public Property Condition() As String
            Get
                Return pCondition
            End Get
            Set(ByVal value As String)
                pCondition = value
            End Set
        End Property

        Private pDatePurchased As Date
        Public Property DatePurchased() As Date
            Get
                Return pDatePurchased
            End Get
            Set(ByVal value As Date)
                pDatePurchased = value
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

        Private pSerialNo As String
        Public Property SerialNo() As String
            Get
                Return pSerialNo
            End Get
            Set(ByVal value As String)
                pSerialNo = value
            End Set
        End Property

        Private pMarketValue As Integer
        Public Property MarketValue() As Integer
            Get
                Return pMarketValue
            End Get
            Set(ByVal value As Integer)
                pMarketValue = value
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


        Private pProperty_Dtl_ID As Long
        Public Property Property_Dtl_ID() As Long
            Get
                Return pProperty_Dtl_ID
            End Get
            Set(ByVal value As Long)
                pProperty_Dtl_ID = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Item_Serial_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@DatePurchased", DatePurchased)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
            objDerived.cmd.Parameters.AddWithValue("@Condition", Condition)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbPropertySerial", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Item_Serial_ID", Item_Serial_ID)
            objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@DatePurchased", DatePurchased)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
            objDerived.cmd.Parameters.AddWithValue("@Condition", Condition)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbPropertySerial", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

    'Ambulance
#Region "TbAmbulance_Dtl"

    Public Class TbAmbulance_Dtl
        Inherits BaseDLL.BaseDAL

        Private pAmbulance_ID As Long
        Public Property Ambulance_ID() As Long
            Get
                Return pAmbulance_ID
            End Get
            Set(ByVal value As Long)
                pAmbulance_ID = value
            End Set
        End Property

        Private pAmbulance_InfoId As Long
        Public Property Ambulance_InfoId() As Long
            Get
                Return pAmbulance_InfoId
            End Get
            Set(ByVal value As Long)
                pAmbulance_InfoId = value
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

        Private pMarketValue As Decimal
        Public Property MarketValue() As Decimal
            Get
                Return pMarketValue
            End Get
            Set(ByVal value As Decimal)
                pMarketValue = value
            End Set
        End Property

        Private pCondition As String
        Public Property Condition() As String
            Get
                Return pCondition
            End Get
            Set(ByVal value As String)
                pCondition = value
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


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Ambulance_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Ambulance_InfoId", Ambulance_InfoId)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Condition", Condition)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbAmbulance_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Ambulance_ID", Ambulance_ID)
            objDerived.cmd.Parameters.AddWithValue("@Ambulance_InfoId", Ambulance_InfoId)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@Condition", Condition)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbAmbulance_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region
#Region "TbAmbulance_Info"

    Public Class TbAmbulance_Info
        Inherits BaseDLL.BaseDAL

        Private pAmbulance_InfoId As Long
        Public Property Ambulance_InfoId() As Long
            Get
                Return pAmbulance_InfoId
            End Get
            Set(ByVal value As Long)
                pAmbulance_InfoId = value
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

        Private pIsAccepted As Boolean
        Public Property IsAccepted() As Boolean
            Get
                Return pIsAccepted
            End Get
            Set(ByVal value As Boolean)
                pIsAccepted = value
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

        Private pLocation As String
        Public Property Location() As String
            Get
                Return pLocation
            End Get
            Set(ByVal value As String)
                pLocation = value
            End Set
        End Property

        Private pBrand As String
        Public Property Brand() As String
            Get
                Return pBrand
            End Get
            Set(ByVal value As String)
                pBrand = value
            End Set
        End Property

        Private pModel As String
        Public Property Model() As String
            Get
                Return pModel
            End Get
            Set(ByVal value As String)
                pModel = value
            End Set
        End Property

        Private pArea As String
        Public Property Area() As String
            Get
                Return pArea
            End Get
            Set(ByVal value As String)
                pArea = value
            End Set
        End Property

        Private pPlateNo As String
        Public Property PlateNo() As String
            Get
                Return pPlateNo
            End Get
            Set(ByVal value As String)
                pPlateNo = value
            End Set
        End Property

        Private pseat As Integer
        Public Property seat() As Integer
            Get
                Return pseat
            End Get
            Set(ByVal value As Integer)
                pseat = value
            End Set
        End Property

        Private pColor As String
        Public Property Color() As String
            Get
                Return pColor
            End Get
            Set(ByVal value As String)
                pColor = value
            End Set
        End Property

        Private pEquipments As String
        Public Property Equipments() As String
            Get
                Return pEquipments
            End Get
            Set(ByVal value As String)
                pEquipments = value
            End Set
        End Property




        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Ambulance_InfoId", 0)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@IsAccepted", IsAccepted)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Brand", Brand)
            objDerived.cmd.Parameters.AddWithValue("@Model", Model)
            objDerived.cmd.Parameters.AddWithValue("@Area", Area)
            objDerived.cmd.Parameters.AddWithValue("@PlateNo", PlateNo)
            objDerived.cmd.Parameters.AddWithValue("@Seat", seat)
            objDerived.cmd.Parameters.AddWithValue("@Color", Color)
            objDerived.cmd.Parameters.AddWithValue("@Equipments", Equipments)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbAmbulance_Info", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Ambulance_InfoId", Ambulance_InfoId)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@IsAccepted", IsAccepted)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Brand", Brand)
            objDerived.cmd.Parameters.AddWithValue("@Model", Model)
            objDerived.cmd.Parameters.AddWithValue("@Area", Area)
            objDerived.cmd.Parameters.AddWithValue("@PlateNo", PlateNo)
            objDerived.cmd.Parameters.AddWithValue("@Seat", seat)
            objDerived.cmd.Parameters.AddWithValue("@Color", Color)
            objDerived.cmd.Parameters.AddWithValue("@Equipments", Equipments)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbAmbulance_Info", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

    'Donations
#Region "TbDonation_Hdr"

    Public Class TbDonation_Hdr
        Inherits BaseDLL.BaseDAL

        Private pDonationHDR_ID As Long
        Public Property DonationHDR_ID() As Long
            Get
                Return pDonationHDR_ID
            End Get
            Set(ByVal value As Long)
                pDonationHDR_ID = value
            End Set
        End Property

        Private pReferenceNo As String
        Public Property ReferenceNo() As String
            Get
                Return pReferenceNo
            End Get
            Set(ByVal value As String)
                pReferenceNo = value
            End Set
        End Property

        Private pProperty_ID As Long
        Public Property Property_ID() As Long
            Get
                Return pProperty_ID
            End Get
            Set(ByVal value As Long)
                pProperty_ID = value
            End Set
        End Property

        Private pAcceptedBy As String
        Public Property AcceptedBy() As String
            Get
                Return pAcceptedBy
            End Get
            Set(ByVal value As String)
                pAcceptedBy = value
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


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@DonationHDR_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@ReferenceNo", ReferenceNo)
            objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)
            objDerived.cmd.Parameters.AddWithValue("@AcceptedBy", AcceptedBy)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbDonation_Hdr", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@DonationHDR_ID", DonationHDR_ID)
            objDerived.cmd.Parameters.AddWithValue("@ReferenceNo", ReferenceNo)
            objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)
            objDerived.cmd.Parameters.AddWithValue("@AcceptedBy", AcceptedBy)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbDonation_Hdr", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region
#Region "TbDonations"

    Public Class TbDonations
        Inherits BaseDLL.BaseDAL

        Private pDonation_ID As Long
        Public Property Donation_ID() As Long
            Get
                Return pDonation_ID
            End Get
            Set(ByVal value As Long)
                pDonation_ID = value
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

        Private pItem_ID As Long
        Public Property Item_ID() As Long
            Get
                Return pItem_ID
            End Get
            Set(ByVal value As Long)
                pItem_ID = value
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

        Private pSerialNo As String
        Public Property SerialNo() As String
            Get
                Return pSerialNo
            End Get
            Set(ByVal value As String)
                pSerialNo = value
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

        Private pDonationType As String
        Public Property DonationType() As String
            Get
                Return pDonationType
            End Get
            Set(ByVal value As String)
                pDonationType = value
            End Set
        End Property

        Private pDonorName As String
        Public Property DonorName() As String
            Get
                Return pDonorName
            End Get
            Set(ByVal value As String)
                pDonorName = value
            End Set
        End Property

        Private pAddress As String
        Public Property Address() As String
            Get
                Return pAddress
            End Get
            Set(ByVal value As String)
                pAddress = value
            End Set
        End Property

        Private pTelephoneNo As String
        Public Property TelephoneNo() As String
            Get
                Return pTelephoneNo
            End Get
            Set(ByVal value As String)
                pTelephoneNo = value
            End Set
        End Property

        Private pEmail As String
        Public Property Email() As String
            Get
                Return pEmail
            End Get
            Set(ByVal value As String)
                pEmail = value
            End Set
        End Property

        Private pDepreciationRate As Decimal
        Public Property DepreciationRate() As Decimal
            Get
                Return pDepreciationRate
            End Get
            Set(ByVal value As Decimal)
                pDepreciationRate = value
            End Set
        End Property

        Private pDepreciationValue As Decimal
        Public Property DepreciationValue() As Decimal
            Get
                Return pDepreciationValue
            End Get
            Set(ByVal value As Decimal)
                pDepreciationValue = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Donation_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@BrandName", BrandName)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@Storage", Storage)
            objDerived.cmd.Parameters.AddWithValue("@DonationType", DonationType)
            objDerived.cmd.Parameters.AddWithValue("@DonorName", DonorName)
            objDerived.cmd.Parameters.AddWithValue("@Address", Address)
            objDerived.cmd.Parameters.AddWithValue("@TelephoneNo", TelephoneNo)
            objDerived.cmd.Parameters.AddWithValue("@Email", Email)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", DepreciationRate)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", DepreciationValue)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbDonations", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Donation_ID", Donation_ID)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@BrandName", BrandName)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@Storage", Storage)
            objDerived.cmd.Parameters.AddWithValue("@DonationType", DonationType)
            objDerived.cmd.Parameters.AddWithValue("@DonorName", DonorName)
            objDerived.cmd.Parameters.AddWithValue("@Address", Address)
            objDerived.cmd.Parameters.AddWithValue("@TelephoneNo", TelephoneNo)
            objDerived.cmd.Parameters.AddWithValue("@Email", Email)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", DepreciationRate)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", DepreciationValue)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbDonations", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region
#Region "TbDonation_Ledger"

    Public Class TbDonation_Ledger
        Inherits BaseDLL.BaseDAL

        Private pDonationLedger_ID As Long
        Public Property DonationLedger_ID() As Long
            Get
                Return pDonationLedger_ID
            End Get
            Set(ByVal value As Long)
                pDonationLedger_ID = value
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

        Private pSerialNo As String
        Public Property SerialNo() As String
            Get
                Return pSerialNo
            End Get
            Set(ByVal value As String)
                pSerialNo = value
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

        Private pdDate As Date
        Public Property dDate() As Date
            Get
                Return pdDate
            End Get
            Set(ByVal value As Date)
                pdDate = value
            End Set
        End Property

        Private pTrans_Type As String
        Public Property Trans_Type() As String
            Get
                Return pTrans_Type
            End Get
            Set(ByVal value As String)
                pTrans_Type = value
            End Set
        End Property

        Private pRef As String
        Public Property Ref() As String
            Get
                Return pRef
            End Get
            Set(ByVal value As String)
                pRef = value
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

        Private pDepartment As String
        Public Property Department() As String
            Get
                Return pDepartment
            End Get
            Set(ByVal value As String)
                pDepartment = value
            End Set
        End Property

        Private pPosition As String
        Public Property Position() As String
            Get
                Return pPosition
            End Get
            Set(ByVal value As String)
                pPosition = value
            End Set
        End Property

        Private pAcceptedBy As String
        Public Property AcceptedBy() As String
            Get
                Return pAcceptedBy
            End Get
            Set(ByVal value As String)
                pAcceptedBy = value
            End Set
        End Property

        Private pInspectedBy As String
        Public Property InspectedBy() As String
            Get
                Return pInspectedBy
            End Get
            Set(ByVal value As String)
                pInspectedBy = value
            End Set
        End Property

        Private pDebitQty As Integer
        Public Property DebitQty() As Integer
            Get
                Return pDebitQty
            End Get
            Set(ByVal value As Integer)
                pDebitQty = value
            End Set
        End Property

        Private pDebitUnit As String
        Public Property DebitUnit() As String
            Get
                Return pDebitUnit
            End Get
            Set(ByVal value As String)
                pDebitUnit = value
            End Set
        End Property

        Private pDebitCost As Decimal
        Public Property DebitCost() As Decimal
            Get
                Return pDebitCost
            End Get
            Set(ByVal value As Decimal)
                pDebitCost = value
            End Set
        End Property

        Private pCreditQty As Integer
        Public Property CreditQty() As Integer
            Get
                Return pCreditQty
            End Get
            Set(ByVal value As Integer)
                pCreditQty = value
            End Set
        End Property

        Private pCreditUnit As String
        Public Property CreditUnit() As String
            Get
                Return pCreditUnit
            End Get
            Set(ByVal value As String)
                pCreditUnit = value
            End Set
        End Property

        Private pCreditCost As Decimal
        Public Property CreditCost() As Decimal
            Get
                Return pCreditCost
            End Get
            Set(ByVal value As Decimal)
                pCreditCost = value
            End Set
        End Property

        Private pBalanceQty As Integer
        Public Property BalanceQty() As Integer
            Get
                Return pBalanceQty
            End Get
            Set(ByVal value As Integer)
                pBalanceQty = value
            End Set
        End Property

        Private pBalanceUnit As String
        Public Property BalanceUnit() As String
            Get
                Return pBalanceUnit
            End Get
            Set(ByVal value As String)
                pBalanceUnit = value
            End Set
        End Property

        Private pBalanceCost As Decimal
        Public Property BalanceCost() As Decimal
            Get
                Return pBalanceCost
            End Get
            Set(ByVal value As Decimal)
                pBalanceCost = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@DonationLedger_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@dDate", dDate)
            objDerived.cmd.Parameters.AddWithValue("@Trans_Type", Trans_Type)
            objDerived.cmd.Parameters.AddWithValue("@Ref", Ref)
            objDerived.cmd.Parameters.AddWithValue("@AccountablePerson", AccountablePerson)
            objDerived.cmd.Parameters.AddWithValue("@Department", Department)
            objDerived.cmd.Parameters.AddWithValue("@Position", Position)
            objDerived.cmd.Parameters.AddWithValue("@AcceptedBy", AcceptedBy)
            objDerived.cmd.Parameters.AddWithValue("@InspectedBy", InspectedBy)
            objDerived.cmd.Parameters.AddWithValue("@DebitQty", DebitQty)
            objDerived.cmd.Parameters.AddWithValue("@DebitUnit", DebitUnit)
            objDerived.cmd.Parameters.AddWithValue("@DebitCost", DebitCost)
            objDerived.cmd.Parameters.AddWithValue("@CreditQty", CreditQty)
            objDerived.cmd.Parameters.AddWithValue("@CreditUnit", CreditUnit)
            objDerived.cmd.Parameters.AddWithValue("@CreditCost", CreditCost)
            objDerived.cmd.Parameters.AddWithValue("@BalanceQty", BalanceQty)
            objDerived.cmd.Parameters.AddWithValue("@BalanceUnit", BalanceUnit)
            objDerived.cmd.Parameters.AddWithValue("@BalanceCost", BalanceCost)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[Save_TbDonation_Ledger]", CommandType.StoredProcedure, Nothing)
        End Function
    End Class
#End Region

    'Intangible
#Region "TBIntangibleAsset_Info"
    Public Class TBIntangibleAsset_Info
        Inherits BaseDLL.BaseDAL

        Private pAIRDtl_ID As Long
        Public Property AIRDtl_ID() As Long
            Get
                Return pAIRDtl_ID
            End Get
            Set(ByVal value As Long)
                pAIRDtl_ID = value
            End Set
        End Property

        Private pIsAccepted As Boolean
        Public Property IsAccepted() As Boolean
            Get
                Return pIsAccepted
            End Get
            Set(ByVal value As Boolean)
                pIsAccepted = value
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

        Private pReceived_ID As Long
        Public Property Received_ID() As Long
            Get
                Return pReceived_ID
            End Get
            Set(ByVal value As Long)
                pReceived_ID = value
            End Set
        End Property

        Private pReceived_Dtl_ID As Long
        Public Property Received_Dtl_ID() As Long
            Get
                Return pReceived_Dtl_ID
            End Get
            Set(ByVal value As Long)
                pReceived_Dtl_ID = value
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

        Private pBrand As String
        Public Property Brand() As String
            Get
                Return pBrand
            End Get
            Set(ByVal value As String)
                pBrand = value
            End Set
        End Property

        Private pTitle As String
        Public Property Title() As String
            Get
                Return pTitle
            End Get
            Set(ByVal value As String)
                pTitle = value
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

        Private pNoofdisc As String
        Public Property Noofdisc() As String
            Get
                Return pNoofdisc
            End Get
            Set(ByVal value As String)
                pNoofdisc = value
            End Set
        End Property

        Private pModel As String
        Public Property Model() As String
            Get
                Return pModel
            End Get
            Set(ByVal value As String)
                pModel = value
            End Set
        End Property

        Private pLicenceDuration As String
        Public Property LicenceDuration() As String
            Get
                Return pLicenceDuration
            End Get
            Set(ByVal value As String)
                pLicenceDuration = value
            End Set
        End Property

        Private pDepreciationRate As String
        Public Property DepreciationRate() As String
            Get
                Return pDepreciationRate
            End Get
            Set(ByVal value As String)
                pDepreciationRate = value
            End Set
        End Property

        Private pNoofYears As String
        Public Property NoofYears() As String
            Get
                Return pNoofYears
            End Get
            Set(ByVal value As String)
                pNoofYears = value
            End Set
        End Property
        Private pUsefullife As String
        Public Property Usefullife() As String
            Get
                Return pUsefullife
            End Get
            Set(ByVal value As String)
                pUsefullife = value
            End Set
        End Property
        Private pSubClassificationID As Long
        Public Property SubClassificationID() As Long
            Get
                Return pSubClassificationID
            End Get
            Set(ByVal value As Long)
                pSubClassificationID = value
            End Set
        End Property

        Private pIntangibleAssetInfoId As Long
        Public Property IntangibleAssetInfoId() As Long
            Get
                Return pIntangibleAssetInfoId
            End Get
            Set(ByVal value As Long)
                pIntangibleAssetInfoId = value
            End Set
        End Property



        Private pProperty_ID As Long
        Public Property Property_ID() As Long
            Get
                Return pProperty_ID
            End Get
            Set(ByVal value As Long)
                pProperty_ID = value
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

        Private pRemarks As String
        Public Property Remarks() As String
            Get
                Return pRemarks
            End Get
            Set(ByVal value As String)
                pRemarks = value
            End Set
        End Property

        Private pUnit_ID As Long
        Public Property Unit_ID() As Long
            Get
                Return pUnit_ID
            End Get
            Set(ByVal value As Long)
                pUnit_ID = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@IsAccepted", IsAccepted)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", pProperty_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@Received_Dtl_ID", Received_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Brand", Brand)
            objDerived.cmd.Parameters.AddWithValue("@Title", Title)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@Noofdisc", Noofdisc)
            objDerived.cmd.Parameters.AddWithValue("@Model", Model)
            objDerived.cmd.Parameters.AddWithValue("@LicenceDuration", LicenceDuration)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", DepreciationRate)
            objDerived.cmd.Parameters.AddWithValue("@NoofYears", NoofYears)
            objDerived.cmd.Parameters.AddWithValue("@Usefullife", Usefullife)
            objDerived.cmd.Parameters.AddWithValue("@SubClassificationID", SubClassificationID)

            objDerived.cmd.Parameters.AddWithValue("@Property_ID", If(pProperty_ID = 0, CType(DBNull.Value, Object), pProperty_ID))
            objDerived.cmd.Parameters.AddWithValue("@Description", If(String.IsNullOrWhiteSpace(pDescription), CType(DBNull.Value, Object), pDescription))
            objDerived.cmd.Parameters.AddWithValue("@Remarks", If(String.IsNullOrWhiteSpace(pRemarks), CType(DBNull.Value, Object), pRemarks))
            objDerived.cmd.Parameters.AddWithValue("@Unit_ID", If(pUnit_ID = 0, CType(DBNull.Value, Object), pUnit_ID))


            objDerived.cmd.Parameters.AddWithValue("@SaveUpdateStatus", "SAVE")
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.spSave_TBIntangibleAsset_Info", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function Update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@IntangibleAssetInfoId", IntangibleAssetInfoId)
            objDerived.cmd.Parameters.AddWithValue("@Brand", Brand)
            objDerived.cmd.Parameters.AddWithValue("@Title", Title)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@Noofdisc", Noofdisc)
            objDerived.cmd.Parameters.AddWithValue("@Model", Model)
            objDerived.cmd.Parameters.AddWithValue("@LicenceDuration", LicenceDuration)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", DepreciationRate)
            objDerived.cmd.Parameters.AddWithValue("@NoofYears", NoofYears)
            objDerived.cmd.Parameters.AddWithValue("@Usefullife", Usefullife)

            'objDerived.cmd.Parameters.AddWithValue("@Property_ID", If(pProperty_ID = 0, CType(DBNull.Value, Object), pProperty_ID))
            objDerived.cmd.Parameters.AddWithValue("@Description", If(String.IsNullOrWhiteSpace(pDescription), CType(DBNull.Value, Object), pDescription))
            objDerived.cmd.Parameters.AddWithValue("@Remarks", If(String.IsNullOrWhiteSpace(pRemarks), CType(DBNull.Value, Object), pRemarks))
            objDerived.cmd.Parameters.AddWithValue("@Unit_ID", If(pUnit_ID = 0, CType(DBNull.Value, Object), pUnit_ID))



            objDerived.cmd.Parameters.AddWithValue("@SaveUpdateStatus", "UPDATE")
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.spSave_TBIntangibleAsset_Info", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region
#Region "TBIntangibleAsset_Dtl"
    Public Class TBIntangibleAsset_Dtl
        Inherits BaseDLL.BaseDAL

        Private pIntangibleAssetInfoId As Long
        Public Property IntangibleAssetInfoId() As Long
            Get
                Return pIntangibleAssetInfoId
            End Get
            Set(ByVal value As Long)
                pIntangibleAssetInfoId = value
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

        Private pAcqCost As Long
        Public Property AcqCost() As Long
            Get
                Return pAcqCost
            End Get
            Set(ByVal value As Long)
                pAcqCost = value
            End Set
        End Property


        Private pDepreciatedValue As Decimal
        Public Property DepreciatedValue() As Decimal
            Get
                Return pDepreciatedValue
            End Get
            Set(ByVal value As Decimal)
                pDepreciatedValue = value
            End Set
        End Property

        Private pMarketValue As Decimal
        Public Property MarketValue() As Decimal
            Get
                Return pMarketValue
            End Get
            Set(ByVal value As Decimal)
                pMarketValue = value
            End Set
        End Property

        Private pSalvageValue As Decimal
        Public Property SalvageValue() As Decimal
            Get
                Return pSalvageValue
            End Get
            Set(ByVal value As Decimal)
                pSalvageValue = value
            End Set
        End Property

        Private pWarehouseID As Decimal
        Public Property WarehouseID() As Decimal
            Get
                Return pWarehouseID
            End Get
            Set(ByVal value As Decimal)
                pWarehouseID = value
            End Set
        End Property

        Private pBay As String
        Public Property Bay() As String
            Get
                Return pBay
            End Get
            Set(ByVal value As String)
                pBay = value
            End Set
        End Property

        Private pColumn As String
        Public Property Column() As String
            Get
                Return pColumn
            End Get
            Set(ByVal value As String)
                pColumn = value
            End Set
        End Property
        Private pFloor As String
        Public Property Floor() As String
            Get
                Return pFloor
            End Get
            Set(ByVal value As String)
                pFloor = value
            End Set
        End Property
        Private pRoom As String
        Public Property Room() As String
            Get
                Return pRoom
            End Get
            Set(ByVal value As String)
                pRoom = value
            End Set
        End Property
        Private pShelves As String
        Public Property Shelves() As String
            Get
                Return pShelves
            End Get
            Set(ByVal value As String)
                pShelves = value
            End Set
        End Property
        Private pRack As String
        Public Property Rack() As String
            Get
                Return pRack
            End Get
            Set(ByVal value As String)
                pRack = value
            End Set
        End Property
        Private pBin As String
        Public Property Bin() As String
            Get
                Return pBin
            End Get
            Set(ByVal value As String)
                pBin = value
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

        Private pIntangibleAssetID As Long
        Public Property IntangibleAssetID() As Long
            Get
                Return pIntangibleAssetID
            End Get
            Set(ByVal value As Long)
                pIntangibleAssetID = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@IntangibleAssetInfoId", IntangibleAssetInfoId)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@AcqCost", AcqCost)
            objDerived.cmd.Parameters.AddWithValue("@DepreciatedValue", DepreciatedValue)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", SalvageValue)
            objDerived.cmd.Parameters.AddWithValue("@WarehouseID", WarehouseID)
            objDerived.cmd.Parameters.AddWithValue("@Bay", Bay)
            objDerived.cmd.Parameters.AddWithValue("@Column", Column)
            objDerived.cmd.Parameters.AddWithValue("@Floor", Floor)
            objDerived.cmd.Parameters.AddWithValue("@Room", Room)
            objDerived.cmd.Parameters.AddWithValue("@Shelves", Shelves)
            objDerived.cmd.Parameters.AddWithValue("@Rack", Rack)
            objDerived.cmd.Parameters.AddWithValue("@Bin", Bin)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@SaveUpdateStatus", "SAVE")

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.spSave_TBIntangibleAsset_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@IntangibleAssetID", IntangibleAssetID)
            objDerived.cmd.Parameters.AddWithValue("@AcqCost", AcqCost)
            objDerived.cmd.Parameters.AddWithValue("@DepreciatedValue", DepreciatedValue)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", MarketValue)
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", SalvageValue)
            objDerived.cmd.Parameters.AddWithValue("@WarehouseID", WarehouseID)
            objDerived.cmd.Parameters.AddWithValue("@Bay", Bay)
            objDerived.cmd.Parameters.AddWithValue("@Column", Column)
            objDerived.cmd.Parameters.AddWithValue("@Floor", Floor)
            objDerived.cmd.Parameters.AddWithValue("@Room", Room)
            objDerived.cmd.Parameters.AddWithValue("@Shelves", Shelves)
            objDerived.cmd.Parameters.AddWithValue("@Rack", Rack)
            objDerived.cmd.Parameters.AddWithValue("@Bin", Bin)
            objDerived.cmd.Parameters.AddWithValue("@SaveUpdateStatus", "UPDATE")

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.spSave_TBIntangibleAsset_Dtl", CommandType.StoredProcedure, Nothing)


            Return i
        End Function
    End Class
#End Region


    'TRANSPORTATION
#Region "TbMotor_Info_Acceptance"

    Public Class TbMotor_Info_Acceptance
        Inherits BaseDLL.BaseDAL

        Private pMotor_InfoId As Long
        Public Property Motor_InfoId() As Long
            Get
                Return pMotor_InfoId
            End Get
            Set(ByVal value As Long)
                pMotor_InfoId = value
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

        Private pIsAccepted As Boolean
        Public Property IsAccepted() As Boolean
            Get
                Return pIsAccepted
            End Get
            Set(ByVal value As Boolean)
                pIsAccepted = value
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

        'Private pSerialNo As String
        'Public Property SerialNo() As String
        '    Get
        '        Return pSerialNo
        '    End Get
        '    Set(ByVal value As String)
        '        pSerialNo = value
        '    End Set
        'End Property


        Private pName As String
        Public Property Name() As String
            Get
                Return pName
            End Get
            Set(ByVal value As String)
                pName = value
            End Set
        End Property

        Private pPlateNo As String
        Public Property PlateNo() As String
            Get
                Return pPlateNo
            End Get
            Set(ByVal value As String)
                pPlateNo = value
            End Set
        End Property

        Private pMotorNo As String
        Public Property MotorNo() As String
            Get
                Return pMotorNo
            End Get
            Set(ByVal value As String)
                pMotorNo = value
            End Set
        End Property

        Private pModel As String
        Public Property Model() As String
            Get
                Return pModel
            End Get
            Set(ByVal value As String)
                pModel = value
            End Set
        End Property

        Private pChasisNo As String
        Public Property ChasisNo() As String
            Get
                Return pChasisNo
            End Get
            Set(ByVal value As String)
                pChasisNo = value
            End Set
        End Property

        Private pVehicleColor As String
        Public Property VehicleColor() As String
            Get
                Return pVehicleColor
            End Get
            Set(ByVal value As String)
                pVehicleColor = value
            End Set
        End Property

        Private pWheelsCapacity As String
        Public Property WheelsCapacity() As String
            Get
                Return pWheelsCapacity
            End Get
            Set(ByVal value As String)
                pWheelsCapacity = value
            End Set
        End Property

        Private pGrossWeight As String
        Public Property GrossWeight() As String
            Get
                Return pGrossWeight
            End Get
            Set(ByVal value As String)
                pGrossWeight = value
            End Set
        End Property

        Private pSeats As String
        Public Property Seats() As String
            Get
                Return pSeats
            End Get
            Set(ByVal value As String)
                pSeats = value
            End Set
        End Property

        Private pWarranty As String
        Public Property Warranty() As String
            Get
                Return pWarranty
            End Get
            Set(ByVal value As String)
                pWarranty = value
            End Set
        End Property

        Private pVehicleOwner As String
        Public Property VehicleOwner() As String
            Get
                Return pVehicleOwner
            End Get
            Set(ByVal value As String)
                pVehicleOwner = value
            End Set
        End Property

        Private pDeclaredName As String
        Public Property DeclaredName() As String
            Get
                Return pDeclaredName
            End Get
            Set(ByVal value As String)
                pDeclaredName = value
            End Set
        End Property

        Private pBeneficialUser As String
        Public Property BeneficialUser() As String
            Get
                Return pBeneficialUser
            End Get
            Set(ByVal value As String)
                pBeneficialUser = value
            End Set
        End Property

        Private pVehicleSpecification As String
        Public Property VehicleSpecification() As String
            Get
                Return pVehicleSpecification
            End Get
            Set(ByVal value As String)
                pVehicleSpecification = value
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

        Private pVehicleDesc As String
        Public Property VehicleDesc() As String
            Get
                Return pVehicleDesc
            End Get
            Set(ByVal value As String)
                pVehicleDesc = value
            End Set
        End Property

        Private pVehicleMake As String
        Public Property VehicleMake() As String
            Get
                Return pVehicleMake
            End Get
            Set(ByVal value As String)
                pVehicleMake = value
            End Set
        End Property

        Private pVehicleType As String
        Public Property VehicleType() As String
            Get
                Return pVehicleType
            End Get
            Set(ByVal value As String)
                pVehicleType = value
            End Set
        End Property

        Private pPowerInput As String
        Public Property PowerInput() As String
            Get
                Return pPowerInput
            End Get
            Set(ByVal value As String)
                pPowerInput = value
            End Set
        End Property

        Private pMVfileNo As String
        Public Property MVfileNo() As String
            Get
                Return pMVfileNo
            End Get
            Set(ByVal value As String)
                pMVfileNo = value
            End Set
        End Property


        Private pConSticker As String
        Public Property ConSticker() As String
            Get
                Return pConSticker
            End Get
            Set(ByVal value As String)
                pConSticker = value
            End Set
        End Property


        Private pDepRate As Long
        Public Property DepRate() As Long
            Get
                Return pDepRate
            End Get
            Set(ByVal value As Long)
                pDepRate = value
            End Set
        End Property

        Private pDepValue As Long
        Public Property DepValue() As Long
            Get
                Return pDepValue
            End Get
            Set(ByVal value As Long)
                pDepValue = value
            End Set
        End Property

        Private pNoofYears As Long
        Public Property NoofYears() As Long
            Get
                Return pNoofYears
            End Get
            Set(ByVal value As Long)
                pNoofYears = value
            End Set
        End Property

        Private pUsefulLife As Long
        Public Property UsefulLife() As Long
            Get
                Return pUsefulLife
            End Get
            Set(ByVal value As Long)
                pUsefulLife = value
            End Set
        End Property

        Private pSalvageValue As Long
        Public Property SalvageValue() As Long
            Get
                Return pSalvageValue
            End Get
            Set(ByVal value As Long)
                pSalvageValue = value
            End Set
        End Property

        Private pMMSI As String
        Public Property MMSI() As String
            Get
                Return pMMSI
            End Get
            Set(ByVal value As String)
                pMMSI = value
            End Set
        End Property

        Private pCallSign As String
        Public Property CallSign() As String
            Get
                Return pCallSign
            End Get
            Set(ByVal value As String)
                pCallSign = value
            End Set
        End Property

        Private pIMOno As String
        Public Property IMOno() As String
            Get
                Return pIMOno
            End Get
            Set(ByVal value As String)
                pIMOno = value
            End Set
        End Property

        Private pHullMaterial As String
        Public Property HullMaterial() As String
            Get
                Return pHullMaterial
            End Get
            Set(ByVal value As String)
                pHullMaterial = value
            End Set
        End Property

        Private pNoofMast As String
        Public Property NoofMast() As String
            Get
                Return pNoofMast
            End Get
            Set(ByVal value As String)
                pNoofMast = value
            End Set
        End Property


        Private pNoofDecks As String
        Public Property NoofDecks() As String
            Get
                Return pNoofDecks
            End Get
            Set(ByVal value As String)
                pNoofDecks = value
            End Set
        End Property

        Private pNoofEngine As String
        Public Property NoofEngine() As String
            Get
                Return pNoofEngine
            End Get
            Set(ByVal value As String)
                pNoofEngine = value
            End Set
        End Property

        Private pMainEngine As String
        Public Property MainEngine() As String
            Get
                Return pMainEngine
            End Get
            Set(ByVal value As String)
                pMainEngine = value
            End Set
        End Property

        Private pHorsePower As String
        Public Property HorsePower() As String
            Get
                Return pHorsePower
            End Get
            Set(ByVal value As String)
                pHorsePower = value
            End Set
        End Property

        Private pGrt As String
        Public Property Grt() As String
            Get
                Return pGrt
            End Get
            Set(ByVal value As String)
                pGrt = value
            End Set
        End Property

        Private pNrt As String
        Public Property Nrt() As String
            Get
                Return pNrt
            End Get
            Set(ByVal value As String)
                pNrt = value
            End Set
        End Property

        Private pLoa As String
        Public Property Loa() As String
            Get
                Return pLoa
            End Get
            Set(ByVal value As String)
                pLoa = value
            End Set
        End Property

        Private pBreadth As String
        Public Property Breadth() As String
            Get
                Return pBreadth
            End Get
            Set(ByVal value As String)
                pBreadth = value
            End Set
        End Property

        Private pCarryingCapacity As String
        Public Property CarryingCapacity() As String
            Get
                Return pCarryingCapacity
            End Get
            Set(ByVal value As String)
                pCarryingCapacity = value
            End Set
        End Property



        Private pCsNo As String
        Public Property CsNo() As String
            Get
                Return pCsNo
            End Get
            Set(ByVal value As String)
                pCsNo = value
            End Set
        End Property


        Private pEngineNo As String
        Public Property EngineNo() As String
            Get
                Return pEngineNo
            End Get
            Set(ByVal value As String)
                pEngineNo = value
            End Set
        End Property



        Private pDisplacement As String
        Public Property Displacement() As String
            Get
                Return pDisplacement
            End Get
            Set(ByVal value As String)
                pDisplacement = value
            End Set
        End Property



        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Motor_InfoId", 0)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@IsAccepted", IsAccepted)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            'objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@Name", Name)
            objDerived.cmd.Parameters.AddWithValue("@PlateNo", PlateNo)
            objDerived.cmd.Parameters.AddWithValue("@MotorNo", MotorNo)
            objDerived.cmd.Parameters.AddWithValue("@Model", Model)
            objDerived.cmd.Parameters.AddWithValue("@ChasisNo", ChasisNo)
            objDerived.cmd.Parameters.AddWithValue("@VehicleColor", VehicleColor)
            objDerived.cmd.Parameters.AddWithValue("@WheelsCapacity", WheelsCapacity)
            objDerived.cmd.Parameters.AddWithValue("@GrossWeight", GrossWeight)
            objDerived.cmd.Parameters.AddWithValue("@Seats", Seats)
            objDerived.cmd.Parameters.AddWithValue("@Warranty", Warranty)
            objDerived.cmd.Parameters.AddWithValue("@VehicleOwner", VehicleOwner)
            objDerived.cmd.Parameters.AddWithValue("@DeclaredName", DeclaredName)
            objDerived.cmd.Parameters.AddWithValue("@BeneficialUser", BeneficialUser)
            objDerived.cmd.Parameters.AddWithValue("@VehicleSpecification", VehicleSpecification)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@VehicleDesc", VehicleDesc)
            objDerived.cmd.Parameters.AddWithValue("@VehicleMake", VehicleMake)
            objDerived.cmd.Parameters.AddWithValue("@VehicleType", VehicleType)
            objDerived.cmd.Parameters.AddWithValue("@PowerInput", PowerInput)
            objDerived.cmd.Parameters.AddWithValue("@MVfileNo", MVfileNo)
            objDerived.cmd.Parameters.AddWithValue("@ConSticker", ConSticker)
            objDerived.cmd.Parameters.AddWithValue("@DepRate", DepRate)
            objDerived.cmd.Parameters.AddWithValue("@DepValue", DepValue)
            objDerived.cmd.Parameters.AddWithValue("@NoofYears", NoofYears)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", UsefulLife)
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", SalvageValue)
            objDerived.cmd.Parameters.AddWithValue("@MMSI", MMSI)
            objDerived.cmd.Parameters.AddWithValue("@CallSign", CallSign)
            objDerived.cmd.Parameters.AddWithValue("@IMOno", IMOno)
            objDerived.cmd.Parameters.AddWithValue("@HullMaterial", HullMaterial)
            objDerived.cmd.Parameters.AddWithValue("@NoofMast", NoofMast)
            objDerived.cmd.Parameters.AddWithValue("@NoofDecks", NoofDecks)
            objDerived.cmd.Parameters.AddWithValue("@NoofEngine", NoofEngine)
            objDerived.cmd.Parameters.AddWithValue("@MainEngine", MainEngine)
            objDerived.cmd.Parameters.AddWithValue("@HorsePower", HorsePower)
            objDerived.cmd.Parameters.AddWithValue("@Grt", Grt)
            objDerived.cmd.Parameters.AddWithValue("@Nrt", Nrt)
            objDerived.cmd.Parameters.AddWithValue("@Loa", Loa)
            objDerived.cmd.Parameters.AddWithValue("@Breadth", Breadth)
            objDerived.cmd.Parameters.AddWithValue("@CarryingCapacity", CarryingCapacity)

            objDerived.cmd.Parameters.AddWithValue("@CsNo", CsNo)
            objDerived.cmd.Parameters.AddWithValue("@EngineNo", EngineNo)
            objDerived.cmd.Parameters.AddWithValue("@Displacement", Displacement)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbMotor_Info_Acceptance", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Motor_InfoId", Motor_InfoId)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@IsAccepted", IsAccepted)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            'objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
            objDerived.cmd.Parameters.AddWithValue("@Name", Name)
            objDerived.cmd.Parameters.AddWithValue("@PlateNo", PlateNo)
            objDerived.cmd.Parameters.AddWithValue("@MotorNo", MotorNo)
            objDerived.cmd.Parameters.AddWithValue("@Model", Model)
            objDerived.cmd.Parameters.AddWithValue("@ChasisNo", ChasisNo)
            objDerived.cmd.Parameters.AddWithValue("@VehicleColor", VehicleColor)
            objDerived.cmd.Parameters.AddWithValue("@WheelsCapacity", WheelsCapacity)
            objDerived.cmd.Parameters.AddWithValue("@GrossWeight", GrossWeight)
            objDerived.cmd.Parameters.AddWithValue("@Seats", Seats)
            objDerived.cmd.Parameters.AddWithValue("@Warranty", Warranty)
            objDerived.cmd.Parameters.AddWithValue("@VehicleOwner", VehicleOwner)
            objDerived.cmd.Parameters.AddWithValue("@DeclaredName", DeclaredName)
            objDerived.cmd.Parameters.AddWithValue("@BeneficialUser", BeneficialUser)
            objDerived.cmd.Parameters.AddWithValue("@VehicleSpecification", VehicleSpecification)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@VehicleDesc", VehicleDesc)
            objDerived.cmd.Parameters.AddWithValue("@VehicleMake", VehicleMake)
            objDerived.cmd.Parameters.AddWithValue("@VehicleType", VehicleType)
            objDerived.cmd.Parameters.AddWithValue("@PowerInput", PowerInput)
            objDerived.cmd.Parameters.AddWithValue("@MVfileNo", MVfileNo)
            objDerived.cmd.Parameters.AddWithValue("@ConSticker", ConSticker)
            objDerived.cmd.Parameters.AddWithValue("@DepRate", DepRate)
            objDerived.cmd.Parameters.AddWithValue("@DepValue", DepValue)
            objDerived.cmd.Parameters.AddWithValue("@NoofYears", NoofYears)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", UsefulLife)
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", SalvageValue)
            objDerived.cmd.Parameters.AddWithValue("@MMSI", MMSI)
            objDerived.cmd.Parameters.AddWithValue("@CallSign", CallSign)
            objDerived.cmd.Parameters.AddWithValue("@IMOno", IMOno)
            objDerived.cmd.Parameters.AddWithValue("@HullMaterial", HullMaterial)
            objDerived.cmd.Parameters.AddWithValue("@NoofMast", NoofMast)
            objDerived.cmd.Parameters.AddWithValue("@NoofDecks", NoofDecks)
            objDerived.cmd.Parameters.AddWithValue("@NoofEngine", NoofEngine)
            objDerived.cmd.Parameters.AddWithValue("@MainEngine", MainEngine)
            objDerived.cmd.Parameters.AddWithValue("@HorsePower", HorsePower)
            objDerived.cmd.Parameters.AddWithValue("@Grt", Grt)
            objDerived.cmd.Parameters.AddWithValue("@Nrt", Nrt)
            objDerived.cmd.Parameters.AddWithValue("@Loa", Loa)
            objDerived.cmd.Parameters.AddWithValue("@Breadth", Breadth)
            objDerived.cmd.Parameters.AddWithValue("@CarryingCapacity", CarryingCapacity)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbMotor_Info_Acceptance", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class


#End Region

    'LIVESTOCK

#Region "LIVESTOCK INFO AND DTL"
    Public Class TbLivestock_Information
        Inherits BaseDLL.BaseDAL

        Private pLivestockInfoId As Long
        Public Property LivestockInfoId() As Long
            Get
                Return pLivestockInfoId
            End Get
            Set(ByVal value As Long)
                pLivestockInfoId = value
            End Set
        End Property

        Private pPropDtl_ID As Long
        Public Property PropDtl_ID() As Long
            Get
                Return pPropDtl_ID
            End Get
            Set(ByVal value As Long)
                pPropDtl_ID = value
            End Set
        End Property

        Private pSubClassification_ID As Long
        Public Property SubClassification_ID() As Long
            Get
                Return pSubClassification_ID
            End Get
            Set(ByVal value As Long)
                pSubClassification_ID = value
            End Set
        End Property

        Private pBreed_ID As Long
        Public Property Breed_ID() As Long
            Get
                Return pBreed_ID
            End Get
            Set(ByVal value As Long)
                pBreed_ID = value
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

        Private pQuantity As Integer
        Public Property Quantity() As Integer
            Get
                Return pQuantity
            End Get
            Set(ByVal value As Integer)
                pQuantity = value
            End Set
        End Property

        Private pSourceOfLivestock As String
        Public Property SourceOfLivestock() As String
            Get
                Return pSourceOfLivestock
            End Get
            Set(ByVal value As String)
                pSourceOfLivestock = value
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

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            ' Add input parameters
            objDerived.cmd.Parameters.AddWithValue("@PropDtl_ID", PropDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@SubClassification_ID", SubClassification_ID)
            objDerived.cmd.Parameters.AddWithValue("@Breed_ID", Breed_ID)
            objDerived.cmd.Parameters.AddWithValue("@Description", Description)
            objDerived.cmd.Parameters.AddWithValue("@Quantity", Quantity)
            objDerived.cmd.Parameters.AddWithValue("@SourceOfLivestock", SourceOfLivestock)
            objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)

            ' Add output parameter for CurrID
            Dim param As New SqlParameter("@LivestockInfoId", SqlDbType.BigInt)
            param.Direction = ParameterDirection.Output
            objDerived.cmd.Parameters.Add(param)

            ' Execute the stored procedure
            objDerived.Execute("AMS.Save_TbLivestock_Information", CommandType.StoredProcedure)

            ' Return the newly generated ID
            Return Convert.ToInt64(param.Value)
        End Function


        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            ' Add input parameters
            objDerived.cmd.Parameters.AddWithValue("@LivestockInfoId", LivestockInfoId) ' This would be the existing record ID
            objDerived.cmd.Parameters.AddWithValue("@PropDtl_ID", PropDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@SubClassification_ID", SubClassification_ID)
            objDerived.cmd.Parameters.AddWithValue("@Breed_ID", Breed_ID)
            objDerived.cmd.Parameters.AddWithValue("@Description", Description)
            objDerived.cmd.Parameters.AddWithValue("@Quantity", Quantity)
            objDerived.cmd.Parameters.AddWithValue("@SourceOfLivestock", SourceOfLivestock)
            objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)

            ' Execute the update procedure (you would need a different stored procedure for updating)
            objDerived.Execute("AMS.Update_TbLivestock_Information", CommandType.StoredProcedure)

            ' Return the ID of the updated record or -1 for failure
            Return LivestockInfoId ' Or return some other indicator for success/failure
        End Function

    End Class

#End Region

End Namespace
