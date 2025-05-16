Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Namespace BOSS


#Region "Office"
    Public Class Office
        Inherits BaseDLL.BaseDAL

        Private pOffice_ID As Long
        Public Property Office_ID() As Long
            Get
                Return pOffice_ID
            End Get
            Set(ByVal value As Long)
                pOffice_ID = value
            End Set
        End Property

        Private pOffice_Name As String
        Public Property Office_Name() As String
            Get
                Return pOffice_Name
            End Get
            Set(ByVal value As String)
                pOffice_Name = value
            End Set
        End Property

        Private pOffice_Ab As String
        Public Property Office_Ab() As String
            Get
                Return pOffice_Ab
            End Get
            Set(ByVal value As String)
                pOffice_Ab = value
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


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            conStr = objDerived.DbaseConnect

            objDerived.cmd.Parameters.AddWithValue("@Office_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Office_Name", pOffice_Name)
            objDerived.cmd.Parameters.AddWithValue("@Office_Ab", pOffice_Ab)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.[BOS].[spSave_m_Office]", CommandType.StoredProcedure, Nothing)
            Return i

        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            conStr = objDerived.DbaseConnect

            objDerived.cmd.Parameters.AddWithValue("@Office_ID", Office_ID)
            objDerived.cmd.Parameters.AddWithValue("@Office_Name", pOffice_Name)
            objDerived.cmd.Parameters.AddWithValue("@Office_Ab", pOffice_Ab)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.[BOS].[spSave_m_Office]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function


        Public Function getOfficeID() As Long
            Me.cmd.Parameters.AddWithValue("office_name", pOffice_Name)
            Dim x As Long
            x = Me.GetValue("LnkdSrvrBOSS.GEOBOS.BOS.office_getID", CommandType.StoredProcedure)
            Return x
        End Function
    End Class
#End Region
#Region "Function"
    Public Class m_Function
        Inherits BaseDLL.BaseDAL

        Private pFunction_ID As Integer
        Public Property Function_ID() As Integer
            Get
                Return pFunction_ID
            End Get
            Set(ByVal value As Integer)
                pFunction_ID = value
            End Set
        End Property

        Private pFunction_Name As String
        Public Property Function_Name() As String
            Get
                Return pFunction_Desc
            End Get
            Set(ByVal value As String)
                pFunction_Name = value
            End Set
        End Property


        Private pFunction_Desc As String
        Public Property Function_Desc() As String
            Get
                Return pFunction_Desc
            End Get
            Set(ByVal value As String)
                pFunction_Desc = value
            End Set
        End Property

        Private pFunction_Abb As String
        Public Property Function_Abb() As String
            Get
                Return pFunction_Abb
            End Get
            Set(ByVal value As String)
                pFunction_Abb = value
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


        Public Function save_to_function() As Long
            Execute("[dbo].[spSave_m_Function]", CommandType.StoredProcedure)
        End Function

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long

            objDerived.cmd.Parameters.AddWithValue("@Function_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Function_Desc", pFunction_Desc)
            objDerived.cmd.Parameters.AddWithValue("@Function_Abb", pFunction_Abb)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.[dbo].[spSave_m_Function]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long

            objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_Desc", pFunction_Desc)
            objDerived.cmd.Parameters.AddWithValue("@Function_Abb", pFunction_Abb)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.[dbo].[spSave_m_Function]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class
#End Region
#Region "Function_per_Office"
    Public Class Function_per_Office
        Inherits BaseDLL.BaseDAL

        Private pFunc_per_Office_ID As Long
        Public Property Func_per_Office_ID() As Long
            Get
                Return pFunc_per_Office_ID
            End Get
            Set(ByVal value As Long)
                pFunc_per_Office_ID = value
            End Set
        End Property

        Private pOffice_ID As Long
        Public Property Office_ID() As Long
            Get
                Return pOffice_ID
            End Get
            Set(ByVal value As Long)
                pOffice_ID = value
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

        Private pOffice_Code As String
        Public Property Office_Code() As String
            Get
                Return pOffice_Code
            End Get
            Set(ByVal value As String)
                pOffice_Code = value
            End Set
        End Property

        Private pSector_ID As Long
        Public Property Sector_ID() As Long
            Get
                Return pSector_ID
            End Get
            Set(ByVal value As Long)
                pSector_ID = value
            End Set
        End Property

        Private pSubSector_ID As Long
        Public Property SubSector_ID() As Long
            Get
                Return pSubSector_ID
            End Get
            Set(ByVal value As Long)
                pSubSector_ID = value
            End Set
        End Property

        Private pF_ID As Long
        Public Property F_ID() As Long
            Get
                Return pF_ID
            End Get
            Set(ByVal value As Long)
                pF_ID = value
            End Set
        End Property

        Private pisBR As Boolean
        Public Property isBR() As Boolean
            Get
                Return pisBR
            End Get
            Set(ByVal value As Boolean)
                pisBR = value
            End Set
        End Property

        Private pisNationalOffice As Boolean
        Public Property isNationalOffice() As Boolean
            Get
                Return pisNationalOffice
            End Get
            Set(ByVal value As Boolean)
                pisNationalOffice = value
            End Set
        End Property

        Private pF_ID_Accntg As Integer
        Public Property F_ID_Accntg() As Integer
            Get
                Return pF_ID_Accntg
            End Get
            Set(ByVal value As Integer)
                pF_ID_Accntg = value
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


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long

            objDerived.cmd.Parameters.AddWithValue("@Func_per_Office_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Office_ID", pOffice_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
            objDerived.cmd.Parameters.AddWithValue("@Office_Code", pOffice_Code)
            objDerived.cmd.Parameters.AddWithValue("@Sector_ID", pSector_ID)
            objDerived.cmd.Parameters.AddWithValue("@SubSector_ID", pSubSector_ID)
            objDerived.cmd.Parameters.AddWithValue("@F_ID", pF_ID)
            objDerived.cmd.Parameters.AddWithValue("@isBR", pisBR)
            objDerived.cmd.Parameters.AddWithValue("@isNationalOffice", pisNationalOffice)
            objDerived.cmd.Parameters.AddWithValue("@F_ID_Accntg", F_ID_Accntg)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.BOS.spSave_m_Function_per_Office", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long

            objDerived.cmd.Parameters.AddWithValue("@Func_per_Office_ID", Func_per_Office_ID)
            objDerived.cmd.Parameters.AddWithValue("@Office_ID", pOffice_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
            objDerived.cmd.Parameters.AddWithValue("@Office_Code", pOffice_Code)
            objDerived.cmd.Parameters.AddWithValue("@Sector_ID", pSector_ID)
            objDerived.cmd.Parameters.AddWithValue("@SubSector_ID", pSubSector_ID)
            objDerived.cmd.Parameters.AddWithValue("@F_ID", pF_ID)
            objDerived.cmd.Parameters.AddWithValue("@isBR", pisBR)
            objDerived.cmd.Parameters.AddWithValue("@isNationalOffice", pisNationalOffice)
            objDerived.cmd.Parameters.AddWithValue("@F_ID_Accntg", F_ID_Accntg)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.BOS.spSave_m_Function_per_Office", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        '    Public Function save_to_function_per_office() As Long
        '        Me.cmd.Parameters.AddWithValue("@Func_per_Office_ID", 0)
        '        Me.cmd.Parameters.AddWithValue("@Office_ID", pOffice_ID)
        '        Me.cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
        '        Me.cmd.Parameters.AddWithValue("@Office_Code", pOffice_Code)
        '        Me.cmd.Parameters.AddWithValue("@Sector_ID", pSector_ID)
        '        Me.cmd.Parameters.AddWithValue("@SubSector_ID", pSubSector_ID)
        '        Me.cmd.Parameters.AddWithValue("@F_ID", pF_ID)
        '        Me.cmd.Parameters.AddWithValue("@isBR", pisBR)
        '        Me.cmd.Parameters.AddWithValue("@isNationalOffice", pisNationalOffice)
        '        Me.cmd.Parameters.AddWithValue("@F_ID_Accntg", F_ID_Accntg)
        '        Me.cmd.Parameters.AddWithValue("@UserID", pUserID)
        '        Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        '        Dim br As Integer
        '        If pisBR = False Then
        '            br = 0
        '        Else
        '            br = 1
        '        End If

        '        Execute("[GeoBOS].BOS.spSave_m_Function_per_Office", Data.CommandType.StoredProcedure)
        '    End Function

        '    Public Function update_function_per_office() As Long
        '        Me.cmd.Parameters.AddWithValue("@Func_per_Office_ID", pFunc_per_Office_ID)
        '        Me.cmd.Parameters.AddWithValue("@Office_ID", pOffice_ID)
        '        Me.cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
        '        Me.cmd.Parameters.AddWithValue("@Office_Code", pOffice_Code)
        '        Me.cmd.Parameters.AddWithValue("@Sector_ID", pSector_ID)
        '        Me.cmd.Parameters.AddWithValue("@SubSector_ID", pSubSector_ID)
        '        Me.cmd.Parameters.AddWithValue("@F_ID", pF_ID)
        '        Me.cmd.Parameters.AddWithValue("@isBR", pisBR)
        '        Me.cmd.Parameters.AddWithValue("@isNationalOffice", pisNationalOffice)
        '        Me.cmd.Parameters.AddWithValue("@F_ID_Accntg", F_ID_Accntg)
        '        Me.cmd.Parameters.AddWithValue("@UserID", pUserID)
        '        Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        '        Dim br As Integer
        '        If pisBR = False Then
        '            br = 0
        '        Else
        '            br = 1
        '        End If

        '        Execute("@CurrID", "[GeoBOS].BOS.spSave_m_Function_per_Office", Data.CommandType.StoredProcedure)
        '    End Function
    End Class

#End Region


#Region "Budget General Accounts"
    Public Class BudgetGenAccounts
        Inherits BaseDLL.BaseDAL

        Private pBGA_ID As Long
        Public Property BGA_ID() As Long
            Get
                Return pBGA_ID
            End Get
            Set(ByVal value As Long)
                pBGA_ID = value
            End Set
        End Property

        Private pBGA_Title As String
        Public Property BGA_Title() As String
            Get
                Return pBGA_Title
            End Get
            Set(ByVal value As String)
                pBGA_Title = value
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

        Private pBGA_No As String
        Public Property BGA_No() As String
            Get
                Return pBGA_No
            End Get
            Set(ByVal value As String)
                pBGA_No = value
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

        Private pTableName As String
        Public Property TableName() As String
            Get
                Return pTableName
            End Get
            Set(ByVal value As String)
                pTableName = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            conStr = objDerived.DbaseConnect

            objDerived.cmd.Parameters.AddWithValue("@BGA_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@BGA_Title", pBGA_Title)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@BGA_No", pBGA_No)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.[BOS].[spSave_BudgetGen_Accounts]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            conStr = objDerived.DbaseConnect

            objDerived.cmd.Parameters.AddWithValue("@BGA_ID", BGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@BGA_Title", pBGA_Title)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@BGA_No", pBGA_No)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.[BOS].[spSave_BudgetGen_Accounts]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class

#End Region
#Region "AccountClassAccounts"
    Public Class AccountClassAcounts
        Inherits BaseDLL.BaseDAL

        Private pAllotmentClassAccount_ID As Long
        Public Property AllotmentClassAccount_ID() As Long
            Get
                Return pAllotmentClassAccount_ID
            End Get
            Set(ByVal value As Long)
                pAllotmentClassAccount_ID = value
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

        Private pBGA_ID As Long
        Public Property BGA_ID() As Long
            Get
                Return pBGA_ID
            End Get
            Set(ByVal value As Long)
                pBGA_ID = value
            End Set
        End Property

        Private pAllotmentClass_ID As Long
        Public Property AllotmentClass_ID() As Long
            Get
                Return pAllotmentClass_ID
            End Get
            Set(ByVal value As Long)
                pAllotmentClass_ID = value
            End Set
        End Property

        Private pisReserved As Boolean
        Public Property isReserved() As Boolean
            Get
                Return pisReserved
            End Get
            Set(ByVal value As Boolean)
                pisReserved = value
            End Set
        End Property

        Private pReservedPercentage As Integer
        Public Property ReservedPercentage() As Integer
            Get
                Return pReservedPercentage
            End Get
            Set(ByVal value As Integer)
                pReservedPercentage = value
            End Set
        End Property

        Private pforFullRelease As Boolean
        Public Property forFullRelease() As Boolean
            Get
                Return pforFullRelease
            End Get
            Set(ByVal value As Boolean)
                pforFullRelease = value
            End Set
        End Property

        Private pisContinuing As Boolean
        Public Property isContinuing() As Boolean
            Get
                Return pisContinuing
            End Get
            Set(ByVal value As Boolean)
                pisContinuing = value
            End Set
        End Property

        Private pforOBRCashAdvance As Boolean
        Public Property forOBRCashAdvance() As Boolean
            Get
                Return pforOBRCashAdvance
            End Get
            Set(ByVal value As Boolean)
                pforOBRCashAdvance = value
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

        Private pTableName As String
        Public Property TableName() As String
            Get
                Return pTableName
            End Get
            Set(ByVal value As String)
                pTableName = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            conStr = objDerived.DbaseConnect

            objDerived.cmd.Parameters.AddWithValue("@AllotmentClassAccount_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
            objDerived.cmd.Parameters.AddWithValue("@isReserved", pisReserved)
            objDerived.cmd.Parameters.AddWithValue("@ReservedPercentage", pReservedPercentage)
            objDerived.cmd.Parameters.AddWithValue("@forFullRelease", pforFullRelease)
            objDerived.cmd.Parameters.AddWithValue("@isContinuing", pisContinuing)
            objDerived.cmd.Parameters.AddWithValue("@forOBRCashAdvance", pforOBRCashAdvance)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.[dbo].[spSave_M_AllotmentClassAccount]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
     
        Public Function update() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            conStr = objDerived.DbaseConnect

            objDerived.cmd.Parameters.AddWithValue("@AllotmentClassAccount_ID", AllotmentClassAccount_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
            objDerived.cmd.Parameters.AddWithValue("@isReserved", pisReserved)
            objDerived.cmd.Parameters.AddWithValue("@ReservedPercentage", pReservedPercentage)
            objDerived.cmd.Parameters.AddWithValue("@forFullRelease", pforFullRelease)
            objDerived.cmd.Parameters.AddWithValue("@isContinuing", pisContinuing)
            objDerived.cmd.Parameters.AddWithValue("@forOBRCashAdvance", pforOBRCashAdvance)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.[dbo].[spSave_M_AllotmentClassAccount]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

#Region "LBPF_3_Hdr"
    Public Class LBPF_3_Hdr
        Inherits BaseDLL.BaseDAL

        Private pLBPF_3_Hdr_ID As Long
        Public Property LBPF_3_Hdr_ID() As Long
            Get
                Return pLBPF_3_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pLBPF_3_Hdr_ID = value
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

        Private pAppropriationSource_ID As Long
        Public Property AppropriationSource_ID() As Long
            Get
                Return pAppropriationSource_ID
            End Get
            Set(ByVal value As Long)
                pAppropriationSource_ID = value
            End Set
        End Property

        Private pAdjustmentType_ID As Long
        Public Property AdjustmentType_ID() As Long
            Get
                Return pAdjustmentType_ID
            End Get
            Set(ByVal value As Long)
                pAdjustmentType_ID = value
            End Set
        End Property

        Private pF_ID As Long
        Public Property F_ID() As Long
            Get
                Return pF_ID
            End Get
            Set(ByVal value As Long)
                pF_ID = value
            End Set
        End Property

        Private pBudget_Year As Integer
        Public Property Budget_Year() As Integer
            Get
                Return pBudget_Year
            End Get
            Set(ByVal value As Integer)
                pBudget_Year = value
            End Set
        End Property

        Private pisApproved As Boolean
        Public Property isApproved() As Boolean
            Get
                Return pisApproved
            End Get
            Set(ByVal value As Boolean)
                pisApproved = value
            End Set
        End Property

        Private pisPosted As Boolean
        Public Property isPosted() As Boolean
            Get
                Return pisPosted
            End Get
            Set(ByVal value As Boolean)
                pisPosted = value
            End Set
        End Property

        Private pPreparedBy As Integer
        Public Property PreparedBy() As Integer
            Get
                Return pPreparedBy
            End Get
            Set(ByVal value As Integer)
                pPreparedBy = value
            End Set
        End Property

        Private pDatePrepared As DateTime
        Public Property DatePrepared() As DateTime
            Get
                Return pDatePrepared
            End Get
            Set(ByVal value As DateTime)
                pDatePrepared = value
            End Set
        End Property

        Private pReviewedBy As Integer
        Public Property ReviewedBy() As Integer
            Get
                Return pReviewedBy
            End Get
            Set(ByVal value As Integer)
                pReviewedBy = value
            End Set
        End Property

        Private pDateReviewed As DateTime
        Public Property DateReviewed() As DateTime
            Get
                Return pDateReviewed
            End Get
            Set(ByVal value As DateTime)
                pDateReviewed = value
            End Set
        End Property

        Private pApprovedBy As Integer
        Public Property ApprovedBy() As Integer
            Get
                Return pApprovedBy
            End Get
            Set(ByVal value As Integer)
                pApprovedBy = value
            End Set
        End Property

        Private pDateApproved As DateTime
        Public Property DateApproved() As DateTime
            Get
                Return pDateApproved
            End Get
            Set(ByVal value As DateTime)
                pDateApproved = value
            End Set
        End Property

        Private pisFinal As Boolean
        Public Property isFinal() As Boolean
            Get
                Return pisFinal
            End Get
            Set(ByVal value As Boolean)
                pisFinal = value
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

        Private pTableName As String
        Public Property TableName() As String
            Get
                Return pTableName
            End Get
            Set(ByVal value As String)
                pTableName = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Integer

            objDerived.cmd.Parameters.AddWithValue("@LBPF_3_Hdr_ID", 0) '
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", pRC_ID) '
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID) '
            objDerived.cmd.Parameters.AddWithValue("@Program_ID", pProgram_ID) '
            objDerived.cmd.Parameters.AddWithValue("@Project_ID", pProject_ID) '
            objDerived.cmd.Parameters.AddWithValue("@AppropriationSource_ID", pAppropriationSource_ID) '
            objDerived.cmd.Parameters.AddWithValue("@AdjustmentType_ID", pAdjustmentType_ID) '
            objDerived.cmd.Parameters.AddWithValue("@F_ID", pF_ID) '
            objDerived.cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year) '
            objDerived.cmd.Parameters.AddWithValue("@isApproved", pisApproved) '
            objDerived.cmd.Parameters.AddWithValue("@isPosted", pisPosted) '
            objDerived.cmd.Parameters.AddWithValue("@PreparedBy", pPreparedBy) '
            objDerived.cmd.Parameters.AddWithValue("@DatePrepared", pDatePrepared) '
            objDerived.cmd.Parameters.AddWithValue("@ReviewedBy", pReviewedBy) '
            objDerived.cmd.Parameters.AddWithValue("@DateReviewed", pDateReviewed) '
            objDerived.cmd.Parameters.AddWithValue("@ApprovedBy", pApprovedBy) '
            objDerived.cmd.Parameters.AddWithValue("@DateApproved", pDateApproved) '
            objDerived.cmd.Parameters.AddWithValue("isFinal", isFinal) '
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.[GeoBOS].BOS.spSave_LBPF_3_Hdr", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Integer

            objDerived.cmd.Parameters.AddWithValue("@LBPF_3_Hdr_ID", pLBPF_3_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
            objDerived.cmd.Parameters.AddWithValue("@Program_ID", pProgram_ID)
            objDerived.cmd.Parameters.AddWithValue("@Project_ID", pProject_ID)
            objDerived.cmd.Parameters.AddWithValue("@AppropriationSource_ID", pAppropriationSource_ID)
            objDerived.cmd.Parameters.AddWithValue("@AdjustmentType_ID", pAdjustmentType_ID)
            objDerived.cmd.Parameters.AddWithValue("@F_ID", pF_ID)
            objDerived.cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            objDerived.cmd.Parameters.AddWithValue("@isApproved", pisApproved)
            objDerived.cmd.Parameters.AddWithValue("@isPosted", pisPosted)
            objDerived.cmd.Parameters.AddWithValue("@PreparedBy", pPreparedBy)
            objDerived.cmd.Parameters.AddWithValue("@DatePrepared", pDatePrepared)
            objDerived.cmd.Parameters.AddWithValue("@ReviewedBy", pReviewedBy)
            objDerived.cmd.Parameters.AddWithValue("@DateReviewed", pDateReviewed)
            objDerived.cmd.Parameters.AddWithValue("@ApprovedBy", pApprovedBy)
            objDerived.cmd.Parameters.AddWithValue("@DateApproved", pDateApproved)
            objDerived.cmd.Parameters.AddWithValue("isFinal", isFinal)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.[GeoBOS].BOS.spSave_LBPF_3_Hdr", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region
#Region "LBPF_3_Dtl"
    Public Class LBPF_3_Dtl
        Inherits BaseDLL.BaseDAL

        Private pLBPF_3_Dtl_ID As Long
        Public Property LBPF_3_Dtl_ID() As Long
            Get
                Return pLBPF_3_Dtl_ID
            End Get
            Set(ByVal value As Long)
                pLBPF_3_Dtl_ID = value
            End Set
        End Property

        Private pLBPF_3_Hdr_ID As Long
        Public Property LBPF_3_Hdr_ID() As Long
            Get
                Return pLBPF_3_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pLBPF_3_Hdr_ID = value
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

        Private pBGA_ID As Long
        Public Property BGA_ID() As Long
            Get
                Return pBGA_ID
            End Get
            Set(ByVal value As Long)
                pBGA_ID = value
            End Set
        End Property

        Private pPastYear_Amount As Decimal
        Public Property PastYear_Amount() As Decimal
            Get
                Return pPastYear_Amount
            End Get
            Set(ByVal value As Decimal)
                pPastYear_Amount = value
            End Set
        End Property

        Private pCurrentYear_Amount As Decimal
        Public Property CurrentYear_Amount() As Decimal
            Get
                Return pCurrentYear_Amount
            End Get
            Set(ByVal value As Decimal)
                pCurrentYear_Amount = value
            End Set
        End Property

        Private pProposedAmount As Decimal
        Public Property ProposedAmount() As Decimal
            Get
                Return pProposedAmount
            End Get
            Set(ByVal value As Decimal)
                pProposedAmount = value
            End Set
        End Property

        Private pApprovedAmount As Decimal
        Public Property ApprovedAmount() As Decimal
            Get
                Return pApprovedAmount
            End Get
            Set(ByVal value As Decimal)
                pApprovedAmount = value
            End Set
        End Property

        Private pAllotmentClass_ID As Long
        Public Property AllotmentClass_ID() As Long
            Get
                Return pAllotmentClass_ID
            End Get
            Set(ByVal value As Long)
                pAllotmentClass_ID = value
            End Set
        End Property
        Private pApprovedFinal As Decimal
        Public Property ApprovedFinal() As Decimal
            Get
                Return pApprovedFinal
            End Get
            Set(ByVal value As Decimal)
                pApprovedFinal = value
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

        Private pTableName As String
        Public Property TableName() As String
            Get
                Return pTableName
            End Get
            Set(ByVal value As String)
                pTableName = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long

            objDerived.cmd.Parameters.AddWithValue("@LBPF_3_Dtl_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@LBPF_3_Hdr_ID", pLBPF_3_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@PastYear_Amount", pPastYear_Amount)
            objDerived.cmd.Parameters.AddWithValue("@CurrentYear_Amount", pCurrentYear_Amount)
            objDerived.cmd.Parameters.AddWithValue("@ProposedAmount", pProposedAmount)
            objDerived.cmd.Parameters.AddWithValue("@ApprovedAmount", pApprovedAmount)
            objDerived.cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
            objDerived.cmd.Parameters.AddWithValue("@ApprovedFinal", pApprovedFinal)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.[GeoBOS].BOS.spSave_LBPF_3_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long

            objDerived.cmd.Parameters.AddWithValue("@LBPF_3_Dtl_ID", pLBPF_3_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@LBPF_3_Hdr_ID", pLBPF_3_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@PastYear_Amount", pPastYear_Amount)
            objDerived.cmd.Parameters.AddWithValue("@CurrentYear_Amount", pCurrentYear_Amount)
            objDerived.cmd.Parameters.AddWithValue("@ProposedAmount", pProposedAmount)
            objDerived.cmd.Parameters.AddWithValue("@ApprovedAmount", pApprovedAmount)
            objDerived.cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
            objDerived.cmd.Parameters.AddWithValue("@ApprovedFinal", pApprovedFinal)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.[GeoBOS].BOS.spSave_LBPF_3_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

#Region "LBEF_2_Hdr"
    Public Class LBEF_2_Hdr
        Inherits BaseDLL.BaseDAL
        Private pLBEF_2_Hdr_ID As Long
        Public Property LBEF_2_Hdr_ID() As Long
            Get
                Return pLBEF_2_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pLBEF_2_Hdr_ID = value
            End Set
        End Property

        Private pARO_No As String
        Public Property ARO_No() As String
            Get
                Return pARO_No
            End Get
            Set(ByVal value As String)
                pARO_No = value
            End Set
        End Property

        Private pBudget_Year As Integer
        Public Property Budget_Year() As Integer
            Get
                Return pBudget_Year
            End Get
            Set(ByVal value As Integer)
                pBudget_Year = value
            End Set
        End Property

        Private pAppropriationSource_ID As Long
        Public Property AppropriationSource_ID() As Long
            Get
                Return pAppropriationSource_ID
            End Get
            Set(ByVal value As Long)
                pAppropriationSource_ID = value
            End Set
        End Property

        Private pAllotmentType_ID As Long
        Public Property AllotmentType_ID() As Long
            Get
                Return pAllotmentType_ID
            End Get
            Set(ByVal value As Long)
                pAllotmentType_ID = value
            End Set
        End Property

        Private pQuarter As Integer
        Public Property Quarter() As Integer
            Get
                Return pQuarter
            End Get
            Set(ByVal value As Integer)
                pQuarter = value
            End Set
        End Property

        Private pF_ID As Long
        Public Property F_ID() As Long
            Get
                Return pF_ID
            End Get
            Set(ByVal value As Long)
                pF_ID = value
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

        Private pDateIssued As DateTime
        Public Property DateIssued() As DateTime
            Get
                Return pDateIssued
            End Get
            Set(ByVal value As DateTime)
                pDateIssued = value
            End Set
        End Property

        Private pPurpose As String
        Public Property Purpose() As String
            Get
                Return pPurpose
            End Get
            Set(ByVal value As String)
                pPurpose = value
            End Set
        End Property

        Private pTotalAmount As Decimal
        Public Property TotalAmount() As Decimal
            Get
                Return pTotalAmount
            End Get
            Set(ByVal value As Decimal)
                pTotalAmount = value
            End Set
        End Property

        Private pAmountInWords As String
        Public Property AmountInWords() As String
            Get
                Return pAmountInWords
            End Get
            Set(ByVal value As String)
                pAmountInWords = value
            End Set
        End Property

        Private pNotes As String
        Public Property Notes() As String
            Get
                Return pNotes
            End Get
            Set(ByVal value As String)
                pNotes = value
            End Set
        End Property

        Private pSignatory1_ID As Integer
        Public Property Signatory1_ID() As Integer
            Get
                Return pSignatory1_ID
            End Get
            Set(ByVal value As Integer)
                pSignatory1_ID = value
            End Set
        End Property

        Private pDateSigned As DateTime
        Public Property DateSigned() As DateTime
            Get
                Return pDateSigned
            End Get
            Set(ByVal value As DateTime)
                pDateSigned = value
            End Set
        End Property

        Private pisApproved As Boolean
        Public Property isApproved() As Boolean
            Get
                Return pisApproved
            End Get
            Set(ByVal value As Boolean)
                pisApproved = value
            End Set
        End Property

        Private pSignatory2_ID As Integer
        Public Property Signatory2_ID() As Integer
            Get
                Return pSignatory2_ID
            End Get
            Set(ByVal value As Integer)
                pSignatory2_ID = value
            End Set
        End Property

        Private pSignatory3_ID As Integer
        Public Property Signatory3_ID() As Integer
            Get
                Return pSignatory3_ID
            End Get
            Set(ByVal value As Integer)
                pSignatory3_ID = value
            End Set
        End Property

        Private pPosition3 As String
        Public Property Position3() As String
            Get
                Return pPosition3
            End Get
            Set(ByVal value As String)
                pPosition3 = value
            End Set
        End Property

        Private pisContinuing As Boolean
        Public Property isContinuing() As Boolean
            Get
                Return pisContinuing
            End Get
            Set(ByVal value As Boolean)
                pisContinuing = value
            End Set
        End Property

        Private pisAdjustment As Boolean
        Public Property isAdjustment() As Boolean
            Get
                Return pisAdjustment
            End Get
            Set(ByVal value As Boolean)
                pisAdjustment = value
            End Set
        End Property

        Private pAdjustmentType_ID As Long
        Public Property AdjustmentType_ID() As Long
            Get
                Return pAdjustmentType_ID
            End Get
            Set(ByVal value As Long)
                pAdjustmentType_ID = value
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

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long

            objDerived.cmd.Parameters.AddWithValue("@LBEF_2_Hdr_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@ARO_No", pARO_No)
            objDerived.cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            objDerived.cmd.Parameters.AddWithValue("@AppropriationSource_ID", pAppropriationSource_ID)
            objDerived.cmd.Parameters.AddWithValue("@AllotmentType_ID", pAllotmentType_ID)
            objDerived.cmd.Parameters.AddWithValue("@Quarter", pQuarter)
            objDerived.cmd.Parameters.AddWithValue("@F_ID", pF_ID)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
            objDerived.cmd.Parameters.AddWithValue("@Program_ID", pProgram_ID)
            objDerived.cmd.Parameters.AddWithValue("@Project_ID", pProject_ID)
            objDerived.cmd.Parameters.AddWithValue("@DateIssued", pDateIssued)
            objDerived.cmd.Parameters.AddWithValue("@Purpose", pPurpose)
            objDerived.cmd.Parameters.AddWithValue("@TotalAmount", pTotalAmount)
            objDerived.cmd.Parameters.AddWithValue("@AmountInWords", pAmountInWords)
            objDerived.cmd.Parameters.AddWithValue("@Notes", pNotes)
            objDerived.cmd.Parameters.AddWithValue("@Signatory1_ID", pSignatory1_ID)
            objDerived.cmd.Parameters.AddWithValue("@DateSigned", pDateSigned)
            objDerived.cmd.Parameters.AddWithValue("@isApproved", pisApproved)
            objDerived.cmd.Parameters.AddWithValue("@Signatory2_ID", pSignatory2_ID)
            objDerived.cmd.Parameters.AddWithValue("@Signatory3_ID", pSignatory3_ID)
            objDerived.cmd.Parameters.AddWithValue("@Position3", pPosition3)
            objDerived.cmd.Parameters.AddWithValue("@isContinuing", pisContinuing)
            objDerived.cmd.Parameters.AddWithValue("@isAdjustment", pisAdjustment)
            objDerived.cmd.Parameters.AddWithValue("@AdjustmentType_ID", pAdjustmentType_ID)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.BOS.spSave_LBEF_2_Hdr", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long

            objDerived.cmd.Parameters.AddWithValue("@LBEF_2_Hdr_ID", pLBEF_2_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@ARO_No", pARO_No)
            objDerived.cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            objDerived.cmd.Parameters.AddWithValue("@AppropriationSource_ID", pAppropriationSource_ID)
            objDerived.cmd.Parameters.AddWithValue("@AllotmentType_ID", pAllotmentType_ID)
            objDerived.cmd.Parameters.AddWithValue("@Quarter", pQuarter)
            objDerived.cmd.Parameters.AddWithValue("@F_ID", pF_ID)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
            objDerived.cmd.Parameters.AddWithValue("@Program_ID", pProgram_ID)
            objDerived.cmd.Parameters.AddWithValue("@Project_ID", pProject_ID)
            objDerived.cmd.Parameters.AddWithValue("@DateIssued", pDateIssued)
            objDerived.cmd.Parameters.AddWithValue("@Purpose", pPurpose)
            objDerived.cmd.Parameters.AddWithValue("@TotalAmount", pTotalAmount)
            objDerived.cmd.Parameters.AddWithValue("@AmountInWords", pAmountInWords)
            objDerived.cmd.Parameters.AddWithValue("@Notes", pNotes)
            objDerived.cmd.Parameters.AddWithValue("@Signatory1_ID", pSignatory1_ID)
            objDerived.cmd.Parameters.AddWithValue("@DateSigned", pDateSigned)
            objDerived.cmd.Parameters.AddWithValue("@isApproved", pisApproved)
            objDerived.cmd.Parameters.AddWithValue("@Signatory2_ID", pSignatory2_ID)
            objDerived.cmd.Parameters.AddWithValue("@Signatory3_ID", pSignatory3_ID)
            objDerived.cmd.Parameters.AddWithValue("@Position3", pPosition3)
            objDerived.cmd.Parameters.AddWithValue("@isContinuing", pisContinuing)
            objDerived.cmd.Parameters.AddWithValue("@isAdjustment", pisAdjustment)
            objDerived.cmd.Parameters.AddWithValue("@AdjustmentType_ID", pAdjustmentType_ID)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.BOS.spSave_LBEF_2_Hdr", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region
#Region "LBEF_2_Dtl"
    Public Class LBEF_2_Dtl
        Inherits BaseDLL.BaseDAL

        Private pLBEF_2_Dtl_ID As Long
        Public Property LBEF_2_Dtl_ID() As Long
            Get
                Return pLBEF_2_Dtl_ID
            End Get
            Set(ByVal value As Long)
                pLBEF_2_Dtl_ID = value
            End Set
        End Property

        Private pLBEF_2_Hdr_ID As Long
        Public Property LBEF_2_Hdr_ID() As Long
            Get
                Return pLBEF_2_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pLBEF_2_Hdr_ID = value
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

        Private pBGA_ID As Long
        Public Property BGA_ID() As Long
            Get
                Return pBGA_ID
            End Get
            Set(ByVal value As Long)
                pBGA_ID = value
            End Set
        End Property

        Private pAllotmentClass_ID As Long
        Public Property AllotmentClass_ID() As Long
            Get
                Return pAllotmentClass_ID
            End Get
            Set(ByVal value As Long)
                pAllotmentClass_ID = value
            End Set
        End Property

        Private pAmount As Decimal
        Public Property Amount() As Decimal
            Get
                Return pAmount
            End Get
            Set(ByVal value As Decimal)
                pAmount = value
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


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long

            objDerived.cmd.Parameters.AddWithValue("@LBEF_2_Dtl_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@LBEF_2_Hdr_ID", pLBEF_2_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
            objDerived.cmd.Parameters.AddWithValue("@Amount", pAmount)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.BOS.spSave_LBEF_2_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long

            objDerived.cmd.Parameters.AddWithValue("@LBEF_2_Dtl_ID", pLBEF_2_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@LBEF_2_Hdr_ID", pLBEF_2_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
            objDerived.cmd.Parameters.AddWithValue("@Amount", pAmount)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.BOS.spSave_LBEF_2_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class
#End Region

#Region "m_Program"
    Public Class m_Program
        Inherits BaseDLL.BaseDAL

        Private pProgram_ID As Long
        Public Property Program_ID() As Long
            Get
                Return pProgram_ID
            End Get
            Set(ByVal value As Long)
                pProgram_ID = value
            End Set
        End Property

        Private pProgram_Name As String
        Public Property Program_Name() As String
            Get
                Return pProgram_Name
            End Get
            Set(ByVal value As String)
                pProgram_Name = value
            End Set
        End Property

        Private pProgram_Code As String
        Public Property Program_Code() As String
            Get
                Return pProgram_Code
            End Get
            Set(ByVal value As String)
                pProgram_Code = value
            End Set
        End Property

        Private pSector_ID As Long
        Public Property Sector_ID() As Long
            Get
                Return pSector_ID
            End Get
            Set(ByVal value As Long)
                pSector_ID = value
            End Set
        End Property

        Private pSubSector_ID As Integer
        Public Property SubSector_ID() As Integer
            Get
                Return pSubSector_ID
            End Get
            Set(ByVal value As Integer)
                pSubSector_ID = value
            End Set
        End Property

        Private pF_ID As Long
        Public Property F_ID() As Long
            Get
                Return pF_ID
            End Get
            Set(ByVal value As Long)
                pF_ID = value
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

        Private pGA_ID As Long
        Public Property GA_ID() As Long
            Get
                Return pGA_ID
            End Get
            Set(ByVal value As Long)
                pGA_ID = value
            End Set
        End Property

        Private pExpectedOutputs As String
        Public Property ExpectedOutputs() As String
            Get
                Return pExpectedOutputs
            End Get
            Set(ByVal value As String)
                pExpectedOutputs = value
            End Set
        End Property

        Private pStartDate As DateTime
        Public Property StartDate() As DateTime
            Get
                Return pStartDate
            End Get
            Set(ByVal value As DateTime)
                pStartDate = value
            End Set
        End Property

        Private pCompletionDate As DateTime
        Public Property CompletionDate() As DateTime
            Get
                Return pCompletionDate
            End Get
            Set(ByVal value As DateTime)
                pCompletionDate = value
            End Set
        End Property

        Private pObjectives As String
        Public Property Objectives() As String
            Get
                Return pObjectives
            End Get
            Set(ByVal value As String)
                pObjectives = value
            End Set
        End Property

        Private pBudget_Year As String
        Public Property Budget_Year() As String
            Get
                Return pBudget_Year
            End Get
            Set(ByVal value As String)
                pBudget_Year = value
            End Set
        End Property

        Private pfundingsource_id As Long
        Public Property fundingsource_id() As Long
            Get
                Return pfundingsource_id
            End Get
            Set(ByVal value As Long)
                pfundingsource_id = value
            End Set
        End Property

        Private pstatus As String
        Public Property status() As String
            Get
                Return pstatus
            End Get
            Set(ByVal value As String)
                pstatus = value
            End Set
        End Property

        Private pPS As Decimal
        Public Property PS() As Decimal
            Get
                Return pPS
            End Get
            Set(ByVal value As Decimal)
                pPS = value
            End Set
        End Property

        Private pMOOE As Decimal
        Public Property MOOE() As Decimal
            Get
                Return pMOOE
            End Get
            Set(ByVal value As Decimal)
                pMOOE = value
            End Set
        End Property

        Private pCO As Decimal
        Public Property CO() As Decimal
            Get
                Return pCO
            End Get
            Set(ByVal value As Decimal)
                pCO = value
            End Set
        End Property

        Private pTotalCost As Decimal
        Public Property TotalCost() As Decimal
            Get
                Return pTotalCost
            End Get
            Set(ByVal value As Decimal)
                pTotalCost = value
            End Set
        End Property

        Private pisGAD As Boolean
        Public Property isGAD() As Boolean
            Get
                Return pisGAD
            End Get
            Set(ByVal value As Boolean)
                pisGAD = value
            End Set
        End Property

        Private pTargetBeneficiaries As String
        Public Property TargetBeneficiaries() As String
            Get
                Return pTargetBeneficiaries
            End Get
            Set(ByVal value As String)
                pTargetBeneficiaries = value
            End Set
        End Property

        Private pPerformanceInd As String
        Public Property PerformanceInd() As String
            Get
                Return pPerformanceInd
            End Get
            Set(ByVal value As String)
                pPerformanceInd = value
            End Set
        End Property

        Private pProgramSeq As Long
        Public Property ProgramSeq() As Long
            Get
                Return pProgramSeq
            End Get
            Set(ByVal value As Long)
                pProgramSeq = value
            End Set
        End Property

        Private pOtherOffices As String
        Public Property OtherOffices() As String
            Get
                Return pOtherOffices
            End Get
            Set(ByVal value As String)
                pOtherOffices = value
            End Set
        End Property

        Private pAIP_SubReport_ID As Long
        Public Property AIP_SubReport_ID() As Long
            Get
                Return pAIP_SubReport_ID
            End Get
            Set(ByVal value As Long)
                pAIP_SubReport_ID = value
            End Set
        End Property

        Private pOFE As Decimal
        Public Property OFE() As Decimal
            Get
                Return pOFE
            End Get
            Set(ByVal value As Decimal)
                pOFE = value
            End Set
        End Property
        Private pPrevprog_ID As Long
        Public Property Prevprog_ID() As Long
            Get
                Return pPrevprog_ID
            End Get
            Set(ByVal value As Long)
                pPrevprog_ID = value
            End Set
        End Property

        Private pisInfra As Boolean
        Public Property isInfra() As Boolean
            Get
                Return pisInfra
            End Get
            Set(ByVal value As Boolean)
                pisInfra = value
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

        Private pTableName As String
        Public Property TableName() As String
            Get
                Return pTableName
            End Get
            Set(ByVal value As String)
                pTableName = value
            End Set
        End Property

        Private pTrush_Fund_Description As String
        Public Property Trush_Fund_Description() As String
            Get
                Return pTrush_Fund_Description
            End Get
            Set(ByVal value As String)
                pTrush_Fund_Description = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Program_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Program_Name", pProgram_Name)
            objDerived.cmd.Parameters.AddWithValue("@Program_Code", pProgram_Code)
            objDerived.cmd.Parameters.AddWithValue("@Sector_ID", pSector_ID)
            objDerived.cmd.Parameters.AddWithValue("@SubSector_ID", pSubSector_ID)
            objDerived.cmd.Parameters.AddWithValue("@F_ID", pF_ID)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@ExpectedOutputs", pExpectedOutputs)
            objDerived.cmd.Parameters.AddWithValue("@StartDate", pStartDate)
            objDerived.cmd.Parameters.AddWithValue("@CompletionDate", pCompletionDate)
            objDerived.cmd.Parameters.AddWithValue("@Objectives", pObjectives)
            objDerived.cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            objDerived.cmd.Parameters.AddWithValue("@fundingsource_id", pfundingsource_id)
            objDerived.cmd.Parameters.AddWithValue("@status", pstatus)
            objDerived.cmd.Parameters.AddWithValue("@PS", pPS)
            objDerived.cmd.Parameters.AddWithValue("@MOOE", pMOOE)
            objDerived.cmd.Parameters.AddWithValue("@CO", pCO)
            objDerived.cmd.Parameters.AddWithValue("@OFE", pOFE)
            objDerived.cmd.Parameters.AddWithValue("@TotalCost", pTotalCost)
            objDerived.cmd.Parameters.AddWithValue("@isGAD", pisGAD)
            objDerived.cmd.Parameters.AddWithValue("@TargetBeneficiaries", pTargetBeneficiaries)
            objDerived.cmd.Parameters.AddWithValue("@PerformanceInd", pPerformanceInd)
            objDerived.cmd.Parameters.AddWithValue("@ProgramSeq", pProgramSeq)
            objDerived.cmd.Parameters.AddWithValue("@OtherOffices", pOtherOffices)
            objDerived.cmd.Parameters.AddWithValue("@AIP_SubReport_ID", pAIP_SubReport_ID)
            objDerived.cmd.Parameters.AddWithValue("@Prevprog_ID", pPrevprog_ID)
            objDerived.cmd.Parameters.AddWithValue("@isInfra", pisInfra)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)
            objDerived.cmd.Parameters.AddWithValue("@Trush_Fund_Description", pTrush_Fund_Description)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.dbo.spSave_m_Program", CommandType.StoredProcedure, Nothing)
            Return i
        End Function


        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Program_ID", pProgram_ID)
            objDerived.cmd.Parameters.AddWithValue("@Program_Name", pProgram_Name)
            objDerived.cmd.Parameters.AddWithValue("@Program_Code", pProgram_Code)
            objDerived.cmd.Parameters.AddWithValue("@Sector_ID", pSector_ID)
            objDerived.cmd.Parameters.AddWithValue("@SubSector_ID", pSubSector_ID)
            objDerived.cmd.Parameters.AddWithValue("@F_ID", pF_ID)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@ExpectedOutputs", pExpectedOutputs)
            objDerived.cmd.Parameters.AddWithValue("@StartDate", pStartDate)
            objDerived.cmd.Parameters.AddWithValue("@CompletionDate", pCompletionDate)
            objDerived.cmd.Parameters.AddWithValue("@Objectives", pObjectives)
            objDerived.cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            objDerived.cmd.Parameters.AddWithValue("@fundingsource_id", pfundingsource_id)
            objDerived.cmd.Parameters.AddWithValue("@status", pstatus)
            objDerived.cmd.Parameters.AddWithValue("@PS", pPS)
            objDerived.cmd.Parameters.AddWithValue("@MOOE", pMOOE)
            objDerived.cmd.Parameters.AddWithValue("@CO", pCO)
            objDerived.cmd.Parameters.AddWithValue("@OFE", pOFE)
            objDerived.cmd.Parameters.AddWithValue("@TotalCost", pTotalCost)
            objDerived.cmd.Parameters.AddWithValue("@isGAD", pisGAD)
            objDerived.cmd.Parameters.AddWithValue("@TargetBeneficiaries", pTargetBeneficiaries)
            objDerived.cmd.Parameters.AddWithValue("@PerformanceInd", pPerformanceInd)
            objDerived.cmd.Parameters.AddWithValue("@ProgramSeq", pProgramSeq)
            objDerived.cmd.Parameters.AddWithValue("@OtherOffices", pOtherOffices)
            objDerived.cmd.Parameters.AddWithValue("@AIP_SubReport_ID", pAIP_SubReport_ID)
            objDerived.cmd.Parameters.AddWithValue("@Prevprog_ID", pPrevprog_ID)
            objDerived.cmd.Parameters.AddWithValue("@isInfra", pisInfra)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)
            objDerived.cmd.Parameters.AddWithValue("@Trush_Fund_Description", pTrush_Fund_Description)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.dbo.spSave_m_Program", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class
#End Region
#Region "m_Project"
    Public Class m_Project
        Inherits BaseDLL.BaseDAL

        Private pProject_ID As Long
        Public Property Project_ID() As Long
            Get
                Return pProject_ID
            End Get
            Set(ByVal value As Long)
                pProject_ID = value
            End Set
        End Property
        Private pMajorProjID As Long
        Public Property MajorProjID() As Long
            Get
                Return pMajorProjID
            End Get
            Set(ByVal value As Long)
                pMajorProjID = value
            End Set
        End Property
        Private pProject_Name As String
        Public Property Project_Name() As String
            Get
                Return pProject_Name
            End Get
            Set(ByVal value As String)
                pProject_Name = value
            End Set
        End Property

        Private pProject_Code As String
        Public Property Project_Code() As String
            Get
                Return pProject_Code
            End Get
            Set(ByVal value As String)
                pProject_Code = value
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

        Private pGA_ID As Long
        Public Property GA_ID() As Long
            Get
                Return pGA_ID
            End Get
            Set(ByVal value As Long)
                pGA_ID = value
            End Set
        End Property

        Private pStartDate As DateTime
        Public Property StartDate() As DateTime
            Get
                Return pStartDate
            End Get
            Set(ByVal value As DateTime)
                pStartDate = value
            End Set
        End Property

        Private pCompletionDate As DateTime
        Public Property CompletionDate() As DateTime
            Get
                Return pCompletionDate
            End Get
            Set(ByVal value As DateTime)
                pCompletionDate = value
            End Set
        End Property

        Private pExpectedOutputs As String
        Public Property ExpectedOutputs() As String
            Get
                Return pExpectedOutputs
            End Get
            Set(ByVal value As String)
                pExpectedOutputs = value
            End Set
        End Property

        Private pTotalCost As Decimal
        Public Property TotalCost() As Decimal
            Get
                Return pTotalCost
            End Get
            Set(ByVal value As Decimal)
                pTotalCost = value
            End Set
        End Property

        Private pisActivity As Boolean
        Public Property isActivity() As Boolean
            Get
                Return pisActivity
            End Get
            Set(ByVal value As Boolean)
                pisActivity = value
            End Set
        End Property

        Private pisProject As Boolean
        Public Property isProject() As Boolean
            Get
                Return pisProject
            End Get
            Set(ByVal value As Boolean)
                pisProject = value
            End Set
        End Property

        Private pPS As Decimal
        Public Property PS() As Decimal
            Get
                Return pPS
            End Get
            Set(ByVal value As Decimal)
                pPS = value
            End Set
        End Property

        Private pMOOE As Decimal
        Public Property MOOE() As Decimal
            Get
                Return pMOOE
            End Get
            Set(ByVal value As Decimal)
                pMOOE = value
            End Set
        End Property

        Private pCO As Decimal
        Public Property CO() As Decimal
            Get
                Return pCO
            End Get
            Set(ByVal value As Decimal)
                pCO = value
            End Set
        End Property

        Private pstatus As String
        Public Property status() As String
            Get
                Return pstatus
            End Get
            Set(ByVal value As String)
                pstatus = value
            End Set
        End Property

        Private pObjectives As String
        Public Property Objectives() As String
            Get
                Return pObjectives
            End Get
            Set(ByVal value As String)
                pObjectives = value
            End Set
        End Property

        Private pProjectSeq As Long
        Public Property ProjectSeq() As Long
            Get
                Return pProjectSeq
            End Get
            Set(ByVal value As Long)
                pProjectSeq = value
            End Set
        End Property

        Private pOtherOffices As String
        Public Property OtherOffices() As String
            Get
                Return pOtherOffices
            End Get
            Set(ByVal value As String)
                pOtherOffices = value
            End Set
        End Property

        Private pOFE As Decimal
        Public Property OFE() As Decimal
            Get
                Return pOFE
            End Get
            Set(ByVal value As Decimal)
                pOFE = value
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
        Private pisSC As Boolean
        Public Property isSC() As Boolean
            Get
                Return pisSC
            End Get
            Set(ByVal value As Boolean)
                pisSC = value
            End Set
        End Property

        Private pisSubmit As Boolean
        Public Property isSubmit() As Boolean
            Get
                Return pisSubmit
            End Get
            Set(ByVal value As Boolean)
                pisSubmit = value
            End Set
        End Property

        Private pisfinal As Boolean
        Public Property isfinal() As Boolean
            Get
                Return pisfinal
            End Get
            Set(ByVal value As Boolean)
                pisfinal = value
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

        Private pTableName As String
        Public Property TableName() As String
            Get
                Return pTableName
            End Get
            Set(ByVal value As String)
                pTableName = value
            End Set
        End Property

        Private pisInfraActivity As Boolean
        Public Property isInfraActivity() As Boolean
            Get
                Return pisInfraActivity
            End Get
            Set(ByVal value As Boolean)
                pisInfraActivity = value
            End Set
        End Property
        Private pTrush_Fund_Description As String
        Public Property Trush_Fund_Description() As String
            Get
                Return pTrush_Fund_Description
            End Get
            Set(ByVal value As String)
                pTrush_Fund_Description = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long

            objDerived.cmd.Parameters.AddWithValue("@Project_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@MajorProjID", pMajorProjID)
            objDerived.cmd.Parameters.AddWithValue("@Project_Name", pProject_Name)
            objDerived.cmd.Parameters.AddWithValue("@Project_Code", pProject_Code)
            objDerived.cmd.Parameters.AddWithValue("@Program_ID", pProgram_ID)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@StartDate", pStartDate)
            objDerived.cmd.Parameters.AddWithValue("@CompletionDate", pCompletionDate)
            objDerived.cmd.Parameters.AddWithValue("@ExpectedOutputs", pExpectedOutputs)
            objDerived.cmd.Parameters.AddWithValue("@TotalCost", pTotalCost)
            objDerived.cmd.Parameters.AddWithValue("@isActivity", pisActivity)
            objDerived.cmd.Parameters.AddWithValue("@isProject", pisProject)
            objDerived.cmd.Parameters.AddWithValue("@PS", pPS)
            objDerived.cmd.Parameters.AddWithValue("@MOOE", pMOOE)
            objDerived.cmd.Parameters.AddWithValue("@CO", pCO)
            objDerived.cmd.Parameters.AddWithValue("@OFE", pOFE)
            objDerived.cmd.Parameters.AddWithValue("@status", pstatus)
            objDerived.cmd.Parameters.AddWithValue("@Objectives", pObjectives)
            objDerived.cmd.Parameters.AddWithValue("@ProjectSeq", pProjectSeq)
            objDerived.cmd.Parameters.AddWithValue("@OtherOffices", pOtherOffices)
            objDerived.cmd.Parameters.AddWithValue("@Location", pLocation)
            objDerived.cmd.Parameters.AddWithValue("@isSC", pisSC)
            objDerived.cmd.Parameters.AddWithValue("@isSubmit", pisSubmit)
            objDerived.cmd.Parameters.AddWithValue("@isfinal", pisfinal)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)
            objDerived.cmd.Parameters.AddWithValue("@isInfraActivity", isInfraActivity)
            objDerived.cmd.Parameters.AddWithValue("@Trush_Fund_Description", pTrush_Fund_Description)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.dbo.spSave_m_Project", CommandType.StoredProcedure, Nothing)
            Return i
        End Function


        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long

            objDerived.cmd.Parameters.AddWithValue("@Project_ID", pProject_ID)
            objDerived.cmd.Parameters.AddWithValue("@MajorProjID", pMajorProjID)
            objDerived.cmd.Parameters.AddWithValue("@Project_Name", pProject_Name)
            objDerived.cmd.Parameters.AddWithValue("@Project_Code", pProject_Code)
            objDerived.cmd.Parameters.AddWithValue("@Program_ID", pProgram_ID)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@StartDate", pStartDate)
            objDerived.cmd.Parameters.AddWithValue("@CompletionDate", pCompletionDate)
            objDerived.cmd.Parameters.AddWithValue("@ExpectedOutputs", pExpectedOutputs)
            objDerived.cmd.Parameters.AddWithValue("@TotalCost", pTotalCost)
            objDerived.cmd.Parameters.AddWithValue("@isActivity", pisActivity)
            objDerived.cmd.Parameters.AddWithValue("@isProject", pisProject)
            objDerived.cmd.Parameters.AddWithValue("@PS", pPS)
            objDerived.cmd.Parameters.AddWithValue("@MOOE", pMOOE)
            objDerived.cmd.Parameters.AddWithValue("@CO", pCO)
            objDerived.cmd.Parameters.AddWithValue("@OFE", pOFE)
            objDerived.cmd.Parameters.AddWithValue("@status", pstatus)
            objDerived.cmd.Parameters.AddWithValue("@Objectives", pObjectives)
            objDerived.cmd.Parameters.AddWithValue("@ProjectSeq", pProjectSeq)
            objDerived.cmd.Parameters.AddWithValue("@OtherOffices", pOtherOffices)
            objDerived.cmd.Parameters.AddWithValue("@Location", pLocation)
            objDerived.cmd.Parameters.AddWithValue("@isSC", pisSC)
            objDerived.cmd.Parameters.AddWithValue("@isSubmit", pisSubmit)
            objDerived.cmd.Parameters.AddWithValue("@isfinal", pisfinal)
            objDerived.cmd.Parameters.AddWithValue("@UserID", pUserID)
            objDerived.cmd.Parameters.AddWithValue("@Trush_Fund_Description", pTrush_Fund_Description)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.dbo.spSave_m_Project", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

End Namespace


