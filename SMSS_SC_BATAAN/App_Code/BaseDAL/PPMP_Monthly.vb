Imports System.Data


Namespace PPMP_Monthly

#Region "ppmp_hdr"

    Public Class t_ppmp_hdr
        Inherits BaseDLL.BaseDAL

        Private ippmp_monthly_hdr_ID As Long
        Public Property ppmp_monthly_hdr_ID() As Long
            Get
                Return ippmp_monthly_hdr_ID
            End Get
            Set(ByVal value As Long)
                ippmp_monthly_hdr_ID = value
            End Set
        End Property

        Private iCYear As Integer
        Public Property CYear() As Integer
            Get
                Return iCYear
            End Get
            Set(ByVal value As Integer)
                iCYear = value
            End Set
        End Property

        Private iRC_ID As Integer
        Public Property RC_ID() As Integer
            Get
                Return iRC_ID
            End Get
            Set(ByVal value As Integer)
                iRC_ID = value
            End Set
        End Property

        Private iFunction_ID As Integer
        Public Property Function_ID() As Integer
            Get
                Return iFunction_ID
            End Get
            Set(ByVal value As Integer)
                iFunction_ID = value
            End Set
        End Property

        Private iProgram_ID As Integer
        Public Property Program_ID() As Integer
            Get
                Return iProgram_ID
            End Get
            Set(ByVal value As Integer)
                iProgram_ID = value
            End Set
        End Property

        Private iProject_ID As Integer
        Public Property Project_ID() As Integer
            Get
                Return iProject_ID
            End Get
            Set(ByVal value As Integer)
                iProject_ID = value
            End Set
        End Property

        Private iGA_ID As Integer
        Public Property GA_ID() As Integer
            Get
                Return iGA_ID
            End Get
            Set(ByVal value As Integer)
                iGA_ID = value
            End Set
        End Property

        Private iBGA_ID As Integer
        Public Property BGA_ID() As Integer
            Get
                Return iBGA_ID
            End Get
            Set(ByVal value As Integer)
                iBGA_ID = value
            End Set
        End Property

        Private iReservedPercentage As Decimal
        Public Property ReservedPercentage() As Decimal
            Get
                Return iReservedPercentage
            End Get
            Set(ByVal value As Decimal)
                iReservedPercentage = value
            End Set
        End Property

        Private iReservedAmt As Decimal
        Public Property ReservedAmt() As Decimal
            Get
                Return iReservedAmt
            End Get
            Set(ByVal value As Decimal)
                iReservedAmt = value
            End Set
        End Property

        Private iProcurementMethod As Integer
        Public Property ProcurementMethod() As Integer
            Get
                Return iProcurementMethod
            End Get
            Set(ByVal value As Integer)
                iProcurementMethod = value
            End Set
        End Property

        Private iPreparedBy As Integer
        Public Property PreparedBy() As Integer
            Get
                Return iPreparedBy
            End Get
            Set(ByVal value As Integer)
                iPreparedBy = value
            End Set
        End Property

        Private iReviewdBy As Integer
        Public Property ReviewdBy() As Integer
            Get
                Return iReviewdBy
            End Get
            Set(ByVal value As Integer)
                iReviewdBy = value
            End Set
        End Property

        Private iApprovedBy As Integer
        Public Property ApprovedBy() As Integer
            Get
                Return iApprovedBy
            End Get
            Set(ByVal value As Integer)
                iApprovedBy = value
            End Set
        End Property

        Private iCheckedBy As Integer
        Public Property CheckedBy() As Integer
            Get
                Return iCheckedBy
            End Get
            Set(ByVal value As Integer)
                iCheckedBy = value
            End Set
        End Property

        Private iNotedBy As Integer
        Public Property NotedBy() As Integer
            Get
                Return iNotedBy
            End Get
            Set(ByVal value As Integer)
                iNotedBy = value
            End Set
        End Property

        Private iapp_id As Integer
        Public Property app_id() As Integer
            Get
                Return iapp_id
            End Get
            Set(ByVal value As Integer)
                iapp_id = value
            End Set
        End Property

        Private iisGoods As Boolean
        Public Property isGoods() As Boolean
            Get
                Return iisGoods
            End Get
            Set(ByVal value As Boolean)
                iisGoods = value
            End Set
        End Property

        Private iisFinal As Boolean
        Public Property isFinal() As Boolean
            Get
                Return iisFinal
            End Get
            Set(ByVal value As Boolean)
                iisFinal = value
            End Set
        End Property

        Private iisSupplemental As Boolean
        Public Property isSupplemental() As Boolean
            Get
                Return iisSupplemental
            End Get
            Set(ByVal value As Boolean)
                iisSupplemental = value
            End Set
        End Property

        Private iforRevision As Boolean
        Public Property forRevision() As Boolean
            Get
                Return iforRevision
            End Get
            Set(ByVal value As Boolean)
                iforRevision = value
            End Set
        End Property

        Private iUserID As String
        Public Property UserID() As String
            Get
                Return iUserID
            End Get
            Set(ByVal value As String)
                iUserID = value
            End Set
        End Property

        Private iisInfra As String
        Public Property isInfra() As String
            Get
                Return iisInfra
            End Get
            Set(ByVal value As String)
                iisInfra = value
            End Set
        End Property

        Public Function Save() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            conStr = objDerived.DbaseConnect
            objDerived.cmd.Parameters.AddWithValue("@ppmp_monthly_hdr_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@CYear", CYear)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
            objDerived.cmd.Parameters.AddWithValue("@Program_ID", Program_ID)
            objDerived.cmd.Parameters.AddWithValue("@Project_ID", Project_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
            objDerived.cmd.Parameters.AddWithValue("@BGA_ID", BGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@ReservedPercentage", ReservedPercentage)
            objDerived.cmd.Parameters.AddWithValue("@ReservedAmt", ReservedAmt)
            objDerived.cmd.Parameters.AddWithValue("@ProcurementMethod", ProcurementMethod)
            objDerived.cmd.Parameters.AddWithValue("@PreparedBy", PreparedBy)
            objDerived.cmd.Parameters.AddWithValue("@ReviewdBy", ReviewdBy)
            objDerived.cmd.Parameters.AddWithValue("@ApprovedBy", ApprovedBy)
            objDerived.cmd.Parameters.AddWithValue("@CheckedBy", CheckedBy)
            objDerived.cmd.Parameters.AddWithValue("@NotedBy", NotedBy)
            objDerived.cmd.Parameters.AddWithValue("@app_id", app_id)
            objDerived.cmd.Parameters.AddWithValue("@isGoods", isGoods)
            objDerived.cmd.Parameters.AddWithValue("@isFinal", isFinal)
            objDerived.cmd.Parameters.AddWithValue("@isSupplemental", isSupplemental)
            objDerived.cmd.Parameters.AddWithValue("@forRevision", forRevision)
            objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
            objDerived.cmd.Parameters.AddWithValue("@isInfra", isInfra)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_ppmp_monthly_hdr]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function Update() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            conStr = objDerived.DbaseConnect
            objDerived.cmd.Parameters.AddWithValue("@ppmp_monthly_hdr_ID", ppmp_monthly_hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@CYear", CYear)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
            objDerived.cmd.Parameters.AddWithValue("@Program_ID", Program_ID)
            objDerived.cmd.Parameters.AddWithValue("@Project_ID", Project_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
            objDerived.cmd.Parameters.AddWithValue("@BGA_ID", BGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@ReservedPercentage", ReservedPercentage)
            objDerived.cmd.Parameters.AddWithValue("@ReservedAmt", ReservedAmt)
            objDerived.cmd.Parameters.AddWithValue("@ProcurementMethod", ProcurementMethod)
            objDerived.cmd.Parameters.AddWithValue("@PreparedBy", PreparedBy)
            objDerived.cmd.Parameters.AddWithValue("@ReviewdBy", ReviewdBy)
            objDerived.cmd.Parameters.AddWithValue("@ApprovedBy", ApprovedBy)
            objDerived.cmd.Parameters.AddWithValue("@CheckedBy", CheckedBy)
            objDerived.cmd.Parameters.AddWithValue("@NotedBy", NotedBy)
            objDerived.cmd.Parameters.AddWithValue("@app_id", app_id)
            objDerived.cmd.Parameters.AddWithValue("@isGoods", isGoods)
            objDerived.cmd.Parameters.AddWithValue("@isFinal", isFinal)
            objDerived.cmd.Parameters.AddWithValue("@isSupplemental", isSupplemental)
            objDerived.cmd.Parameters.AddWithValue("@forRevision", forRevision)
            objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
            objDerived.cmd.Parameters.AddWithValue("@isInfra", isInfra)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_ppmp_monthly_hdr]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class
#End Region
#Region "ppmp_dtl"

    Public Class t_ppmp_dtl
        Inherits BaseDLL.BaseDAL

        Private ippmp_monthly_dtl_ID As Long
        Public Property ppmp_monthly_dtl_ID() As Long
            Get
                Return ippmp_monthly_dtl_ID
            End Get
            Set(ByVal value As Long)
                ippmp_monthly_dtl_ID = value
            End Set
        End Property

        Private ippmp_monthly_hdr_ID As Long
        Public Property ppmp_monthly_hdr_ID() As Long
            Get
                Return ippmp_monthly_hdr_ID
            End Get
            Set(ByVal value As Long)
                ippmp_monthly_hdr_ID = value
            End Set
        End Property

        Private iItem_ID As Long
        Public Property Item_ID() As Long
            Get
                Return iItem_ID
            End Get
            Set(ByVal value As Long)
                iItem_ID = value
            End Set
        End Property

        Private iUnitPrice As Decimal
        Public Property UnitPrice() As Decimal
            Get
                Return iUnitPrice
            End Get
            Set(ByVal value As Decimal)
                iUnitPrice = value
            End Set
        End Property

        Private iActualPrice As Decimal
        Public Property ActualPrice() As Decimal
            Get
                Return iActualPrice
            End Get
            Set(ByVal value As Decimal)
                iActualPrice = value
            End Set
        End Property

        Private iGenDescription As String
        Public Property GenDescription() As String
            Get
                Return iGenDescription
            End Get
            Set(ByVal value As String)
                iGenDescription = value
            End Set
        End Property

        Private iJan As Decimal
        Public Property Jan() As Decimal
            Get
                Return iJan
            End Get
            Set(ByVal value As Decimal)
                iJan = value
            End Set
        End Property
        Private iFeb As Decimal
        Public Property Feb() As Decimal
            Get
                Return iFeb
            End Get
            Set(ByVal value As Decimal)
                iFeb = value
            End Set
        End Property
        Private iMar As Decimal
        Public Property Mar() As Decimal
            Get
                Return iMar
            End Get
            Set(ByVal value As Decimal)
                iMar = value
            End Set
        End Property
        Private iApr As Decimal
        Public Property Apr() As Decimal
            Get
                Return iApr
            End Get
            Set(ByVal value As Decimal)
                iApr = value
            End Set
        End Property
        Private iMay As Decimal
        Public Property May() As Decimal
            Get
                Return iMay
            End Get
            Set(ByVal value As Decimal)
                iMay = value
            End Set
        End Property
        Private iJun As Decimal
        Public Property Jun() As Decimal
            Get
                Return iJun
            End Get
            Set(ByVal value As Decimal)
                iJun = value
            End Set
        End Property
        Private iJul As Decimal
        Public Property Jul() As Decimal
            Get
                Return iJul
            End Get
            Set(ByVal value As Decimal)
                iJul = value
            End Set
        End Property
        Private iAug As Decimal
        Public Property Aug() As Decimal
            Get
                Return iAug
            End Get
            Set(ByVal value As Decimal)
                iAug = value
            End Set
        End Property
        Private iSep As Decimal
        Public Property Sep() As Decimal
            Get
                Return iSep
            End Get
            Set(ByVal value As Decimal)
                iSep = value
            End Set
        End Property
        Private iOct As Decimal
        Public Property Oct() As Decimal
            Get
                Return iOct
            End Get
            Set(ByVal value As Decimal)
                iOct = value
            End Set
        End Property
        Private iNov As Decimal
        Public Property Nov() As Decimal
            Get
                Return iNov
            End Get
            Set(ByVal value As Decimal)
                iNov = value
            End Set
        End Property
        Private iDec As Decimal
        Public Property Dec() As Decimal
            Get
                Return iDec
            End Get
            Set(ByVal value As Decimal)
                iDec = value
            End Set
        End Property

        Private iTotal As Decimal
        Public Property Total() As Decimal
            Get
                Return iTotal
            End Get
            Set(ByVal value As Decimal)
                iTotal = value
            End Set
        End Property

        Private iReservedQty As Decimal
        Public Property ReservedQty() As Decimal
            Get
                Return iReservedQty
            End Get
            Set(ByVal value As Decimal)
                iReservedQty = value
            End Set
        End Property

        Private iReservedAmt As Decimal
        Public Property ReservedAmt() As Decimal
            Get
                Return iReservedAmt
            End Get
            Set(ByVal value As Decimal)
                iReservedAmt = value
            End Set
        End Property

        Private iUserID As String
        Public Property UserID() As String
            Get
                Return iUserID
            End Get
            Set(ByVal value As String)
                iUserID = value
            End Set
        End Property



        Public Function Save() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            conStr = objDerived.DbaseConnect
            objDerived.cmd.Parameters.AddWithValue("@ppmp_monthly_dtl_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@ppmp_monthly_hdr_ID", ppmp_monthly_hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice)
            objDerived.cmd.Parameters.AddWithValue("@ActualPrice", ActualPrice)
            objDerived.cmd.Parameters.AddWithValue("@GenDescription", GenDescription)
            objDerived.cmd.Parameters.AddWithValue("@Jan", Jan)
            objDerived.cmd.Parameters.AddWithValue("@Feb", Feb)
            objDerived.cmd.Parameters.AddWithValue("@Mar", Mar)
            objDerived.cmd.Parameters.AddWithValue("@Apr", Apr)
            objDerived.cmd.Parameters.AddWithValue("@May", May)
            objDerived.cmd.Parameters.AddWithValue("@Jun", Jun)
            objDerived.cmd.Parameters.AddWithValue("@Jul", Jul)
            objDerived.cmd.Parameters.AddWithValue("@Aug", Aug)
            objDerived.cmd.Parameters.AddWithValue("@Sep", Sep)
            objDerived.cmd.Parameters.AddWithValue("@Oct", Oct)
            objDerived.cmd.Parameters.AddWithValue("@Nov", Nov)
            objDerived.cmd.Parameters.AddWithValue("@Dec", Dec)
            objDerived.cmd.Parameters.AddWithValue("@Total", Total)
            objDerived.cmd.Parameters.AddWithValue("@ReservedQty", ReservedQty)
            objDerived.cmd.Parameters.AddWithValue("@ReservedAmt", ReservedAmt)
            objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_ppmp_monthly_dtl]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function


        Public Function Update() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            conStr = objDerived.DbaseConnect
            objDerived.cmd.Parameters.AddWithValue("@ppmp_monthly_dtl_ID", ppmp_monthly_dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@ppmp_monthly_hdr_ID", ppmp_monthly_hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice)
            objDerived.cmd.Parameters.AddWithValue("@ActualPrice", ActualPrice)
            objDerived.cmd.Parameters.AddWithValue("@GenDescription", GenDescription)
            objDerived.cmd.Parameters.AddWithValue("@Jan", Jan)
            objDerived.cmd.Parameters.AddWithValue("@Feb", Feb)
            objDerived.cmd.Parameters.AddWithValue("@Mar", Mar)
            objDerived.cmd.Parameters.AddWithValue("@Apr", Apr)
            objDerived.cmd.Parameters.AddWithValue("@May", May)
            objDerived.cmd.Parameters.AddWithValue("@Jun", Jun)
            objDerived.cmd.Parameters.AddWithValue("@Jul", Jul)
            objDerived.cmd.Parameters.AddWithValue("@Aug", Aug)
            objDerived.cmd.Parameters.AddWithValue("@Sep", Sep)
            objDerived.cmd.Parameters.AddWithValue("@Oct", Oct)
            objDerived.cmd.Parameters.AddWithValue("@Nov", Nov)
            objDerived.cmd.Parameters.AddWithValue("@Dec", Dec)
            objDerived.cmd.Parameters.AddWithValue("@Total", Total)
            objDerived.cmd.Parameters.AddWithValue("@ReservedQty", ReservedQty)
            objDerived.cmd.Parameters.AddWithValue("@ReservedAmt", ReservedAmt)
            objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_ppmp_monthly_dtl]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

#Region "ppmp_revision"

    Public Class t_ppmp_revision
        Inherits BaseDLL.BaseDAL

        Private ippmp_monthly_Revision_ID As Long
        Public Property ppmp_monthly_Revision_ID() As Long
            Get
                Return ippmp_monthly_Revision_ID
            End Get
            Set(ByVal value As Long)
                ippmp_monthly_Revision_ID = value
            End Set
        End Property

        Private ippmp_monthly_hdr_ID As Long
        Public Property ppmp_monthly_hdr_ID() As Long
            Get
                Return ippmp_monthly_hdr_ID
            End Get
            Set(ByVal value As Long)
                ippmp_monthly_hdr_ID = value
            End Set
        End Property

        Private iRevision_No As Integer
        Public Property Revision_No() As Integer
            Get
                Return iRevision_No
            End Get
            Set(ByVal value As Integer)
                iRevision_No = value
            End Set
        End Property

        Private iItem_ID As Long
        Public Property Item_ID() As Long
            Get
                Return iItem_ID
            End Get
            Set(ByVal value As Long)
                iItem_ID = value
            End Set
        End Property

        Private iUnitPrice As Decimal
        Public Property UnitPrice() As Decimal
            Get
                Return iUnitPrice
            End Get
            Set(ByVal value As Decimal)
                iUnitPrice = value
            End Set
        End Property

        Private iActualPrice As Decimal
        Public Property ActualPrice() As Decimal
            Get
                Return iActualPrice
            End Get
            Set(ByVal value As Decimal)
                iActualPrice = value
            End Set
        End Property

        Private iGenDescription As String
        Public Property GenDescription() As String
            Get
                Return iGenDescription
            End Get
            Set(ByVal value As String)
                iGenDescription = value
            End Set
        End Property



        Private iJan As Decimal
        Public Property Jan() As Decimal
            Get
                Return iJan
            End Get
            Set(ByVal value As Decimal)
                iJan = value
            End Set
        End Property

        Private iFeb As Decimal
        Public Property Feb() As Decimal
            Get
                Return iFeb
            End Get
            Set(ByVal value As Decimal)
                iFeb = value
            End Set
        End Property

        Private iMar As Decimal
        Public Property Mar() As Decimal
            Get
                Return iMar
            End Get
            Set(ByVal value As Decimal)
                iMar = value
            End Set
        End Property

        Private iApr As Decimal
        Public Property Apr() As Decimal
            Get
                Return iApr
            End Get
            Set(ByVal value As Decimal)
                iApr = value
            End Set
        End Property

        Private iMay As Decimal
        Public Property May() As Decimal
            Get
                Return iMay
            End Get
            Set(ByVal value As Decimal)
                iMay = value
            End Set
        End Property

        Private iJun As Decimal
        Public Property Jun() As Decimal
            Get
                Return iJun
            End Get
            Set(ByVal value As Decimal)
                iJun = value
            End Set
        End Property

        Private iJul As Decimal
        Public Property Jul() As Decimal
            Get
                Return iJul
            End Get
            Set(ByVal value As Decimal)
                iJul = value
            End Set
        End Property

        Private iAug As Decimal
        Public Property Aug() As Decimal
            Get
                Return iAug
            End Get
            Set(ByVal value As Decimal)
                iAug = value
            End Set
        End Property

        Private iSep As Decimal
        Public Property Sep() As Decimal
            Get
                Return iSep
            End Get
            Set(ByVal value As Decimal)
                iSep = value
            End Set
        End Property

        Private iOct As Decimal
        Public Property Oct() As Decimal
            Get
                Return iOct
            End Get
            Set(ByVal value As Decimal)
                iOct = value
            End Set
        End Property

        Private iNov As Decimal
        Public Property Nov() As Decimal
            Get
                Return iNov
            End Get
            Set(ByVal value As Decimal)
                iNov = value
            End Set
        End Property

        Private iDec As Decimal
        Public Property Dec() As Decimal
            Get
                Return iDec
            End Get
            Set(ByVal value As Decimal)
                iDec = value
            End Set
        End Property

        Private iTotal As Decimal
        Public Property Total() As Decimal
            Get
                Return iTotal
            End Get
            Set(ByVal value As Decimal)
                iTotal = value
            End Set
        End Property

        Private iReservedQty As Decimal
        Public Property ReservedQty() As Decimal
            Get
                Return iReservedQty
            End Get
            Set(ByVal value As Decimal)
                iReservedQty = value
            End Set
        End Property

        Private iReservedAmt As Decimal
        Public Property ReservedAmt() As Decimal
            Get
                Return iReservedAmt
            End Get
            Set(ByVal value As Decimal)
                iReservedAmt = value
            End Set
        End Property

        Private iUserID As String
        Public Property UserID() As String
            Get
                Return iUserID
            End Get
            Set(ByVal value As String)
                iUserID = value
            End Set
        End Property



        Public Function Save() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            conStr = objDerived.DbaseConnect
            objDerived.cmd.Parameters.AddWithValue("@ppmp_monthly_Revision_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@ppmp_monthly_hdr_ID", ppmp_monthly_hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Revision_No", Revision_No)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice)
            objDerived.cmd.Parameters.AddWithValue("@GenDescription", GenDescription)
            objDerived.cmd.Parameters.AddWithValue("@Jan", Jan)
            objDerived.cmd.Parameters.AddWithValue("@Feb", Feb)
            objDerived.cmd.Parameters.AddWithValue("@Mar", Mar)
            objDerived.cmd.Parameters.AddWithValue("@Apr", Apr)
            objDerived.cmd.Parameters.AddWithValue("@May", May)
            objDerived.cmd.Parameters.AddWithValue("@Jun", Jun)
            objDerived.cmd.Parameters.AddWithValue("@Jul", Jul)
            objDerived.cmd.Parameters.AddWithValue("@Aug", Aug)
            objDerived.cmd.Parameters.AddWithValue("@Sep", Sep)
            objDerived.cmd.Parameters.AddWithValue("@Oct", Oct)
            objDerived.cmd.Parameters.AddWithValue("@Nov", Nov)
            objDerived.cmd.Parameters.AddWithValue("@Dec", Dec)
            objDerived.cmd.Parameters.AddWithValue("@Total", Total)
            objDerived.cmd.Parameters.AddWithValue("@ReservedQty", ReservedQty)
            objDerived.cmd.Parameters.AddWithValue("@ReservedAmt", ReservedAmt)
            objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_PPMP_Monthly_Revision]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function


        Public Function Update() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            conStr = objDerived.DbaseConnect
            objDerived.cmd.Parameters.AddWithValue("@ppmp_monthly_Revision_ID", ppmp_monthly_Revision_ID)
            objDerived.cmd.Parameters.AddWithValue("@ppmp_monthly_hdr_ID", ppmp_monthly_hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Revision_No", Revision_No)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice)
            objDerived.cmd.Parameters.AddWithValue("@GenDescription", GenDescription)
            objDerived.cmd.Parameters.AddWithValue("@Jan", Jan)
            objDerived.cmd.Parameters.AddWithValue("@Feb", Feb)
            objDerived.cmd.Parameters.AddWithValue("@Mar", Mar)
            objDerived.cmd.Parameters.AddWithValue("@Apr", Apr)
            objDerived.cmd.Parameters.AddWithValue("@May", May)
            objDerived.cmd.Parameters.AddWithValue("@Jun", Jun)
            objDerived.cmd.Parameters.AddWithValue("@Jul", Jul)
            objDerived.cmd.Parameters.AddWithValue("@Aug", Aug)
            objDerived.cmd.Parameters.AddWithValue("@Sep", Sep)
            objDerived.cmd.Parameters.AddWithValue("@Oct", Oct)
            objDerived.cmd.Parameters.AddWithValue("@Nov", Nov)
            objDerived.cmd.Parameters.AddWithValue("@Dec", Dec)
            objDerived.cmd.Parameters.AddWithValue("@Total", Total)
            objDerived.cmd.Parameters.AddWithValue("@ReservedQty", ReservedQty)
            objDerived.cmd.Parameters.AddWithValue("@ReservedAmt", ReservedAmt)
            objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_PPMP_Monthly_Revision]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

End Namespace