Imports Microsoft.VisualBasic
Imports System.Data
Imports System

Namespace BaseClassesint



#Region "Office"
    Public Class Office
        Inherits bBaseDAL

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

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.Office_ID = IIf(IsDBNull(rd("Office_ID")), 0, rd("Office_ID"))
                    Me.Office_Name = IIf(IsDBNull(rd("Office_Name")), "", rd("Office_Name"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub save_office()
            Me.cmd.Parameters.AddWithValue("@Office_ID", 0)
            Me.cmd.Parameters.AddWithValue("@Office_Name", pOffice_Name)

            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].[BOS].[spSave_m_Office]", CommandType.StoredProcedure)
        End Sub

        Public Sub update_office()
            Me.cmd.Parameters.AddWithValue("@Office_ID", pOffice_ID)
            Me.cmd.Parameters.AddWithValue("@Office_Name", pOffice_Name)

            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].[BOS].[spSave_m_Office]", CommandType.StoredProcedure)
        End Sub

        Public Function getOfficeID() As Long
            Me.cmd.Parameters.AddWithValue("office_name", pOffice_Name)
            Dim x As Long
            x = Me.GetValue("[GeoBOS].BOS.office_getID", CommandType.StoredProcedure)
            Return x
        End Function
    End Class
#End Region

#Region "Function"
    Public Class m_Function
        Inherits bBaseDAL

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

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.Function_ID = IIf(IsDBNull(rd("Function_ID")), 0, rd("Function_ID"))
                    Me.Function_Desc = IIf(IsDBNull(rd("Function_Desc")), "", rd("Function_Desc"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Function save_to_function() As Long
            Me.cmd.Parameters.AddWithValue("@Function_ID", 0)
            Me.cmd.Parameters.AddWithValue("@Function_Desc", pFunction_Desc)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].[dbo].[spSave_m_Function]", CommandType.StoredProcedure)
        End Function

        Public Function update_function() As Long
            Me.cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
            Me.cmd.Parameters.AddWithValue("@Function_Desc", pFunction_Desc)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].[dbo].[spSave_m_Function]", CommandType.StoredProcedure)
        End Function
    End Class
#End Region

#Region "Function_per_Office"
    Public Class Function_per_Office
        Inherits bBaseDAL

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

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.Func_per_Office_ID = IIf(IsDBNull(rd("Func_per_Office_ID")), 0, rd("Func_per_Office_ID"))
                    Me.Office_ID = IIf(IsDBNull(rd("Office_ID")), 0, rd("Office_ID"))
                    Me.Function_ID = IIf(IsDBNull(rd("Function_ID")), 0, rd("Function_ID"))
                    Me.Office_Code = IIf(IsDBNull(rd("Office_Code")), "", rd("Office_Code"))
                    Me.Sector_ID = IIf(IsDBNull(rd("Sector_ID")), 0, rd("Sector_ID"))
                    Me.SubSector_ID = IIf(IsDBNull(rd("SubSector_ID")), 0, rd("SubSector_ID"))
                    Me.F_ID = IIf(IsDBNull(rd("F_ID")), 0, rd("F_ID"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Function save_to_function_per_office() As Long
            Me.cmd.Parameters.AddWithValue("@Func_per_Office_ID", 0)
            Me.cmd.Parameters.AddWithValue("@Office_ID", pOffice_ID)
            Me.cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
            Me.cmd.Parameters.AddWithValue("@Office_Code", pOffice_Code)
            Me.cmd.Parameters.AddWithValue("@Sector_ID", pSector_ID)
            Me.cmd.Parameters.AddWithValue("@SubSector_ID", pSubSector_ID)
            Me.cmd.Parameters.AddWithValue("@F_ID", pF_ID)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].[dbo].[spSave_m_Function_per_Office]", CommandType.StoredProcedure)
        End Function

        Public Function update_function_per_office() As Long
            Me.cmd.Parameters.AddWithValue("@Func_per_Office_ID", pFunc_per_Office_ID)
            Me.cmd.Parameters.AddWithValue("@Office_ID", pOffice_ID)
            Me.cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
            Me.cmd.Parameters.AddWithValue("@Office_Code", pOffice_Code)
            Me.cmd.Parameters.AddWithValue("@Sector_ID", pSector_ID)
            Me.cmd.Parameters.AddWithValue("@SubSector_ID", pSubSector_ID)
            Me.cmd.Parameters.AddWithValue("@F_ID", pF_ID)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("@CurrID", "[GeoBOS].[dbo].[spSave_m_Function_per_Office]", Data.CommandType.StoredProcedure)
        End Function
    End Class

#End Region

#Region "m_Project"
    Public Class m_Project
        Inherits bBaseDAL

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


        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    With Me
                        .Project_ID = IIf(IsDBNull(rd("Project_ID")), 0, rd("Project_ID"))
                        .MajorProjID = IIf(IsDBNull(rd("MajorProjID")), 0, rd("MajorProjID"))
                        .Project_Name = IIf(IsDBNull(rd("Project_Name")), "", rd("Project_Name"))
                        .Project_Code = IIf(IsDBNull(rd("Project_Code")), "", rd("Project_Code"))
                        .Program_ID = IIf(IsDBNull(rd("Program_ID")), 0, rd("Program_ID"))
                        .RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
                        .Function_ID = IIf(IsDBNull(rd("Function_ID")), 0, rd("Function_ID"))
                        .GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                        .StartDate = IIf(IsDBNull(rd("StartDate")), "", rd("StartDate"))
                        .CompletionDate = IIf(IsDBNull(rd("CompletionDate")), "", rd("CompletionDate"))
                        .ExpectedOutputs = IIf(IsDBNull(rd("ExpectedOutputs")), "", rd("ExpectedOutputs"))
                        .TotalCost = IIf(IsDBNull(rd("TotalCost")), 0.0, rd("TotalCost"))
                        .isActivity = IIf(IsDBNull(rd("isActivity")), 0, rd("isActivity"))
                        .isProject = IIf(IsDBNull(rd("isProject")), 0, rd("isProject"))
                        .PS = IIf(IsDBNull(rd("PS")), 0.0, rd("PS"))
                        .MOOE = IIf(IsDBNull(rd("MOOE")), 0.0, rd("MOOE"))
                        .CO = IIf(IsDBNull(rd("CO")), 0.0, rd("CO"))
                        .CO = IIf(IsDBNull(rd("OFE")), 0.0, rd("OFE"))
                        .status = IIf(IsDBNull(rd("status")), "", rd("status"))
                        .Objectives = IIf(IsDBNull(rd("Objectives")), "", rd("Objectives"))
                        .ProjectSeq = IIf(IsDBNull(rd("ProjectSeq")), 0, rd("ProjectSeq"))
                        .OtherOffices = IIf(IsDBNull(rd("OtherOffices")), "", rd("OtherOffices"))
                        .Location = IIf(IsDBNull(rd("Location")), "", rd("Location"))
                        .isSC = IIf(IsDBNull(rd("isSC")), 0, rd("isSC"))
                        .isSubmit = IIf(IsDBNull(rd("isSubmit")), 0, rd("isSubmit"))
                        .isfinal = IIf(IsDBNull(rd("isfinal")), 0, rd("isfinal"))
                        .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
                        .TableName = IIf(IsDBNull(rd("TableName")), "", rd("TableName"))
                    End With
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub saveProject()
            With Me
                .cmd.Parameters.AddWithValue("@Project_ID", 0)
                .cmd.Parameters.AddWithValue("@MajorProjID", pMajorProjID)
                .cmd.Parameters.AddWithValue("@Project_Name", pProject_Name)
                .cmd.Parameters.AddWithValue("@Project_Code", pProject_Code)
                .cmd.Parameters.AddWithValue("@Program_ID", pProgram_ID)
                .cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
                .cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
                .cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
                .cmd.Parameters.AddWithValue("@StartDate", pStartDate)
                .cmd.Parameters.AddWithValue("@CompletionDate", pCompletionDate)
                .cmd.Parameters.AddWithValue("@ExpectedOutputs", pExpectedOutputs)
                .cmd.Parameters.AddWithValue("@TotalCost", pTotalCost)
                .cmd.Parameters.AddWithValue("@isActivity", pisActivity)
                .cmd.Parameters.AddWithValue("@isProject", pisProject)
                .cmd.Parameters.AddWithValue("@PS", pPS)
                .cmd.Parameters.AddWithValue("@MOOE", pMOOE)
                .cmd.Parameters.AddWithValue("@CO", pCO)
                .cmd.Parameters.AddWithValue("@OFE", pOFE)
                .cmd.Parameters.AddWithValue("@status", pstatus)
                .cmd.Parameters.AddWithValue("@Objectives", pObjectives)
                .cmd.Parameters.AddWithValue("@ProjectSeq", pProjectSeq)
                .cmd.Parameters.AddWithValue("@OtherOffices", pOtherOffices)
                .cmd.Parameters.AddWithValue("@Location", pLocation)
                .cmd.Parameters.AddWithValue("@isSC", pisSC)
                .cmd.Parameters.AddWithValue("@isSubmit", pisSubmit)
                .cmd.Parameters.AddWithValue("@isfinal", pisfinal)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                cmd.Parameters.AddWithValue("@TableName", pTableName)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("[GeoBOS].dbo.spSave_m_Project", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub updateProject()
            With Me
                .cmd.Parameters.AddWithValue("@Project_ID", pProject_ID)
                .cmd.Parameters.AddWithValue("@MajorProjId", pMajorProjID)
                .cmd.Parameters.AddWithValue("@Project_Name", pProject_Name)
                .cmd.Parameters.AddWithValue("@Project_Code", pProject_Code)
                .cmd.Parameters.AddWithValue("@Program_ID", pProgram_ID)
                .cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
                .cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
                .cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
                .cmd.Parameters.AddWithValue("@StartDate", pStartDate)
                .cmd.Parameters.AddWithValue("@CompletionDate", pCompletionDate)
                .cmd.Parameters.AddWithValue("@ExpectedOutputs", pExpectedOutputs)
                .cmd.Parameters.AddWithValue("@TotalCost", pTotalCost)
                .cmd.Parameters.AddWithValue("@isActivity", pisActivity)
                .cmd.Parameters.AddWithValue("@isProject", pisProject)
                .cmd.Parameters.AddWithValue("@PS", pPS)
                .cmd.Parameters.AddWithValue("@MOOE", pMOOE)
                .cmd.Parameters.AddWithValue("@CO", pCO)
                .cmd.Parameters.AddWithValue("@OFE", pOFE)
                .cmd.Parameters.AddWithValue("@status", pstatus)
                .cmd.Parameters.AddWithValue("@Objectives", pObjectives)
                .cmd.Parameters.AddWithValue("@ProjectSeq", pProjectSeq)
                .cmd.Parameters.AddWithValue("@OtherOffices", pOtherOffices)
                .cmd.Parameters.AddWithValue("@Location", pLocation)
                .cmd.Parameters.AddWithValue("@isSC", pisSC)
                .cmd.Parameters.AddWithValue("@isSubmit", pisSubmit)
                .cmd.Parameters.AddWithValue("@isfinal", pisfinal)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                .cmd.Parameters.AddWithValue("@TableName", pTableName)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("@CurrID", "[GeoBOS].dbo.spSave_m_Project", Data.CommandType.StoredProcedure)
        End Sub

        Public Function getProjList(ByVal budgetYear As String, ByVal ProgName As String) As DataTable
            Me.cmd.Parameters.AddWithValue("ProgName", ProgName)
            Me.cmd.Parameters.AddWithValue("BY", budgetYear)
            Dim x As DataTable
            x = Me.GetDataTable("[GeoBOS].BOS.project_GetList", CommandType.StoredProcedure)
            Return x
        End Function

        Public Function getProjID() As DataTable
            Me.cmd.Parameters.AddWithValue("Proj_Name", pProject_Name)
            Dim x As New DataTable
            x = Me.GetDataTable("[GeoBOS].BOS.project_getID", CommandType.StoredProcedure)
            Return x
        End Function

    End Class
#End Region

#Region "Appropriation Source"

    Public Class AppropriationSource
        Inherits bBaseDAL

        Private pAppropriationSource_ID As Long
        Public Property AppropriationSource_ID() As Long
            Get
                Return pAppropriationSource_ID
            End Get
            Set(ByVal value As Long)
                pAppropriationSource_ID = value
            End Set
        End Property

        Private pAppropriationSource_Desc As String
        Public Property AppropriationSource_Desc() As String
            Get
                Return pAppropriationSource_Desc
            End Get
            Set(ByVal value As String)
                pAppropriationSource_Desc = value
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

        Private pAppropriationType_ID As Long
        Public Property AppropriationType_ID() As Long
            Get
                Return pAppropriationType_ID
            End Get
            Set(ByVal value As Long)
                pAppropriationType_ID = value
            End Set
        End Property


        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.AppropriationSource_ID = IIf(IsDBNull(rd("AppropriationSource_ID")), 0, rd("AppropriationSource_ID"))
                    Me.AppropriationSource_Desc = IIf(IsDBNull(rd("AppropriationSource_Desc")), "", rd("AppropriationSource_Desc"))
                    Me.Budget_Year = IIf(IsDBNull(rd("Budget_Year")), "", rd("Budget_Year"))
                    Me.AppropriationType_ID = IIf(IsDBNull(rd("AppropriationType_ID")), 0, rd("AppropriationType_ID"))

                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Function save_app_source() As Long

            Me.cmd.Parameters.AddWithValue("@AppropriationSource_ID", 0)
            Me.cmd.Parameters.AddWithValue("@AppropriationSource_Desc", pAppropriationSource_Desc)
            Me.cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            Me.cmd.Parameters.AddWithValue("@AppropriationType_ID", pAppropriationType_ID)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].[BOS].[spSave_m_AppropriationSource]", CommandType.StoredProcedure)

        End Function

        Public Function update_app_source() As Long

            Me.cmd.Parameters.AddWithValue("@AppropriationSource_ID", pAppropriationSource_ID)
            Me.cmd.Parameters.AddWithValue("@AppropriationSource_Desc", pAppropriationSource_Desc)
            Me.cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            Me.cmd.Parameters.AddWithValue("@AppropriationType_ID", pAppropriationType_ID)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].[BOS].[spSave_m_AppropriationSource]", CommandType.StoredProcedure)

        End Function

    End Class


#End Region

#Region "AccountClassAccounts"
    Public Class AccountClassAcounts
        Inherits bBaseDAL

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

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.AllotmentClassAccount_ID = IIf(IsDBNull(rd("AllotmentClassAccount_ID")), 0, rd("AllotmentClassAccount_ID"))
                    Me.GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                    Me.BGA_ID = IIf(IsDBNull(rd("BGA_ID")), 0, rd("BGA_ID"))
                    Me.AllotmentClass_ID = IIf(IsDBNull(rd("AllotmentClass_ID")), 0, rd("AllotmentClass_ID"))
                    Me.isReserved = IIf(IsDBNull(rd("isReserved")), 0, rd("isReserved"))
                    Me.ReservedPercentage = IIf(IsDBNull(rd("ReservedPercentage")), 0, rd("ReservedPercentage"))
                    Me.forFullRelease = IIf(IsDBNull(rd("forFullRelease")), 0, rd("forFullRelease"))
                    Me.isContinuing = IIf(IsDBNull(rd("isContinuing")), 0, rd("isContinuing"))
                End While
            Catch ex As Exception
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Function save_to_AllotmentclassAccount() As Long
            Me.cmd.Parameters.AddWithValue("@AllotmentClassAccount_ID", 0)
            Me.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            Me.cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            Me.cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
            Me.cmd.Parameters.AddWithValue("@isReserved", pisReserved)
            Me.cmd.Parameters.AddWithValue("@ReservedPercentage", pReservedPercentage)
            Me.cmd.Parameters.AddWithValue("@forFullRelease", pforFullRelease)
            Me.cmd.Parameters.AddWithValue("@isContinuing", pisContinuing)

            Execute("[GeoBOS].[dbo].[spSave_M_AllotmentClassAccount]", Data.CommandType.StoredProcedure)
        End Function

        Public Function update_allotmentclassaccounts() As Long
            Me.cmd.Parameters.AddWithValue("@AllotmentClassAccount_ID", pAllotmentClassAccount_ID)
            Me.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            Me.cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            Me.cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
            Me.cmd.Parameters.AddWithValue("@isReserved", pisReserved)
            Me.cmd.Parameters.AddWithValue("@ReservedPercentage", pReservedPercentage)
            Me.cmd.Parameters.AddWithValue("@forFullRelease", pforFullRelease)
            Me.cmd.Parameters.AddWithValue("@isContinuing", pisContinuing)

            Execute("[GeoBOS].[dbo].[spSave_M_AllotmentClassAccount]", Data.CommandType.StoredProcedure)
        End Function
    End Class
#End Region

#Region "Budget General Accounts"

    Public Class BudgetGenAccounts
        Inherits bBaseDAL

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

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.BGA_ID = IIf(IsDBNull(rd("BGA_ID")), 0, rd("BGA_ID"))
                    Me.BGA_Title = IIf(IsDBNull(rd("BGA_Title")), "", rd("BGA_Title"))
                    Me.GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                    Me.BGA_No = IIf(IsDBNull(rd("BGA_No")), "", rd("BGA_No"))
                End While
            Catch ex As Exception
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Function save_to_BudgetGenAccounts() As Long
            Me.cmd.Parameters.AddWithValue("@BGA_ID", 0)
            Me.cmd.Parameters.AddWithValue("@BGA_Title", pBGA_Title)
            Me.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            Me.cmd.Parameters.AddWithValue("@BGA_No", pBGA_No)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].[bos].[spSave_BudgetGen_Accounts]", Data.CommandType.StoredProcedure)
        End Function

        Public Function update_BudgetGenAccounts() As Long
            Me.cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            Me.cmd.Parameters.AddWithValue("@BGA_Title", pBGA_Title)
            Me.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            Me.cmd.Parameters.AddWithValue("@BGA_No", pBGA_No)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].[bos].[spSave_BudgetGen_Accounts]", Data.CommandType.StoredProcedure)
        End Function
    End Class

#End Region

#Region "AddAdvice"
    Public Class AddAdvice
        Inherits bBaseDAL
        Private pAdvice_No_ID As Integer
        Public Property Advice_No_ID() As Integer
            Get
                Return pAdvice_No_ID
            End Get
            Set(ByVal value As Integer)
                pAdvice_No_ID = value
            End Set
        End Property

        Private pAdvice_No As String
        Public Property Advice_No() As String
            Get
                Return pAdvice_No
            End Get
            Set(ByVal value As String)
                pAdvice_No = value
            End Set
        End Property

        Private pAdvice_Date As DateTime
        Public Property Advice_Date() As DateTime
            Get
                Return pAdvice_Date
            End Get
            Set(ByVal value As DateTime)
                pAdvice_Date = value
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

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.Advice_No_ID = IIf(IsDBNull(rd("Advice_No_ID")), 0, rd("Advice_No_ID"))
                    Me.Advice_No = IIf(IsDBNull(rd("Advice_No")), "", rd("Advice_No"))
                    Me.Advice_Date = IIf(IsDBNull(rd("Advice_Date")), "", rd("Advice_Date"))
                    Me.Remarks = IIf(IsDBNull(rd("Remarks")), "", rd("Remarks"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub
        Public Sub AddAdviceSave()
            Me.cmd.Parameters.AddWithValue("@Advice_No_ID", 0)
            Me.cmd.Parameters.AddWithValue("@Advice_No", Advice_No)
            Me.cmd.Parameters.AddWithValue("@Advice_Date", Advice_Date)
            Me.cmd.Parameters.AddWithValue("@Remarks", Remarks)
            Execute("[GeoBOS].[BOS].[spSave_AddAdviceMaintenance]", Data.CommandType.StoredProcedure)

        End Sub
    End Class
#End Region

#Region "Allotment Class"

    Public Class allotmentClass
        Inherits bBaseDAL

        Private pAllotmentClass_ID As Integer
        Public Property AllotmentClass_ID() As Integer
            Get
                Return pAllotmentClass_ID
            End Get
            Set(ByVal value As Integer)
                pAllotmentClass_ID = value
            End Set
        End Property

        Private pAllotmentClass_Code As Integer
        Public Property AllotmentClass_Code() As Integer
            Get
                Return pAllotmentClass_Code
            End Get
            Set(ByVal value As Integer)
                pAllotmentClass_Code = value
            End Set
        End Property

        Private pAllotmentClass As String
        Public Property AllotmentClass() As String
            Get
                Return pAllotmentClass
            End Get
            Set(ByVal value As String)
                pAllotmentClass = value
            End Set
        End Property

        Public Overrides Sub FillEntity()

            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.AllotmentClass_ID = IIf(IsDBNull(rd("AllotmentClass_ID")), 0, rd("AllotmentClass_ID"))
                    Me.AllotmentClass_Code = IIf(IsDBNull(rd("AllotmentClass_Code")), 0, rd("AllotmentClass_Code"))
                    Me.AllotmentClass = IIf(IsDBNull(rd("AllotmentClass")), "", rd("AllotmentClass"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try

        End Sub
    End Class

#End Region

#Region "PersonnelSchedule_DTL"
    Public Class PersonnelSchedule_DTL
        Inherits bBaseDAL
        Private pLBPF_4_Dtl_ID As Long
        Public Property LBPF_4_Dtl_ID() As Long
            Get
                Return pLBPF_4_Dtl_ID
            End Get
            Set(ByVal value As Long)
                pLBPF_4_Dtl_ID = value
            End Set
        End Property

        Private pLBPF_4_Hdr_ID As Long
        Public Property LBPF_4_Hdr_ID() As Long
            Get
                Return pLBPF_4_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pLBPF_4_Hdr_ID = value
            End Set
        End Property

        Private pCurrentSG As String
        Public Property CurrentSG() As String
            Get
                Return pCurrentSG
            End Get
            Set(ByVal value As String)
                pCurrentSG = value
            End Set
        End Property

        Private pCurrentAmount As Decimal
        Public Property CurrentAmount() As Decimal
            Get
                Return pCurrentAmount
            End Get
            Set(ByVal value As Decimal)
                pCurrentAmount = value
            End Set
        End Property


        Private pProposedSG As String
        Public Property ProposedSG() As String
            Get
                Return pProposedSG
            End Get
            Set(ByVal value As String)
                pProposedSG = value
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

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.LBPF_4_Dtl_ID = IIf(IsDBNull(rd("LBPF_4_Dtl_ID")), 0, rd("LBPF_4_Dtl_ID"))
                    Me.LBPF_4_Hdr_ID = IIf(IsDBNull(rd("LBPF_4_Hdr_ID")), 0, rd("LBPF_4_Hdr_ID"))
                    Me.ProposedSG = IIf(IsDBNull(rd("CurrentSG")), "", rd("CurrentSG"))
                    Me.ProposedAmount = IIf(IsDBNull(rd("CurrentAmount")), 0.0, rd("CurrentAmount"))
                    Me.ProposedSG = IIf(IsDBNull(rd("ProposedSG")), "", rd("ProposedSG"))
                    Me.ProposedAmount = IIf(IsDBNull(rd("ProposedAmount")), 0.0, rd("ProposedAmount"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub
    End Class
#End Region

#Region "PersonnelSchedule_HDR"
    Public Class PersonnelSchedule_HDR
        Inherits bBaseDAL
        Private pLBPF_4_Hdr_ID As Long
        Public Property LBPF_4_Hdr_ID() As Long
            Get
                Return pLBPF_4_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pLBPF_4_Hdr_ID = value
            End Set
        End Property

        Private pdeptID As Integer
        Public Property deptID() As Integer
            Get
                Return pdeptID
            End Get
            Set(ByVal value As Integer)
                pdeptID = value
            End Set
        End Property

        Private pdivKey As Integer
        Public Property divKey() As Integer
            Get
                Return pdivKey
            End Get
            Set(ByVal value As Integer)
                pdivKey = value
            End Set
        End Property

        Private pplan_year As Integer
        Public Property plan_year() As Integer
            Get
                Return pplan_year
            End Get
            Set(ByVal value As Integer)
                pplan_year = value
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

        Private pPreparedByID As Integer
        Public Property PreparedByID() As Integer
            Get
                Return pPreparedByID
            End Get
            Set(ByVal value As Integer)
                pPreparedByID = value
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

        Private pReviewedByID As Integer
        Public Property ReviewedByID() As Integer
            Get
                Return pReviewedByID
            End Get
            Set(ByVal value As Integer)
                pReviewedByID = value
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

        Private pApprovedByID As Integer
        Public Property ApprovedByID() As Integer
            Get
                Return pApprovedByID
            End Get
            Set(ByVal value As Integer)
                pApprovedByID = value
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

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.LBPF_4_Hdr_ID = IIf(IsDBNull(rd("LBPF_4_Hdr_ID")), 0, rd("LBPF_4_Hdr_ID"))
                    Me.deptID = IIf(IsDBNull(rd("deptID")), 0, rd("deptID"))
                    Me.divKey = IIf(IsDBNull(rd("divKey")), 0, rd("divKey"))
                    Me.plan_year = IIf(IsDBNull(rd("plan_year")), "", rd("plan_year"))
                    Me.isApproved = IIf(IsDBNull(rd("isApproved")), 0, rd("isApproved"))
                    Me.isPosted = IIf(IsDBNull(rd("isPosted")), 0, rd("isPosted"))
                    Me.PreparedByID = IIf(IsDBNull(rd("PreparedByID")), 0, rd("PreparedByID"))
                    Me.DatePrepared = IIf(IsDBNull(rd("DatePrepared")), "", rd("DatePrepared"))
                    Me.ReviewedByID = IIf(IsDBNull(rd("ReviewedByID")), 0, rd("ReviewedByID"))
                    Me.DateReviewed = IIf(IsDBNull(rd("DateReviewed")), "", rd("DateReviewed"))
                    Me.ApprovedByID = IIf(IsDBNull(rd("ApprovedByID")), 0, rd("ApprovedByID"))
                    Me.DateApproved = IIf(IsDBNull(rd("DateApproved")), "", rd("DateApproved"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub
    End Class
#End Region

#Region "m_Program"
    Public Class m_Program
        Inherits bBaseDAL

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


        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    With Me
                        .Program_ID = IIf(IsDBNull(rd("Program_ID")), 0, rd("Program_ID"))
                        .Program_Name = IIf(IsDBNull(rd("Program_Name")), "", rd("Program_Name"))
                        .Program_Code = IIf(IsDBNull(rd("Program_Code")), "", rd("Program_Code"))
                        .Sector_ID = IIf(IsDBNull(rd("Sector_ID")), 0, rd("Sector_ID"))
                        .SubSector_ID = IIf(IsDBNull(rd("SubSector_ID")), 0, rd("SubSector_ID"))
                        .F_ID = IIf(IsDBNull(rd("F_ID")), 0, rd("F_ID"))
                        .RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
                        .Function_ID = IIf(IsDBNull(rd("Function_ID")), 0, rd("Function_ID"))
                        .GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                        .ExpectedOutputs = IIf(IsDBNull(rd("ExpectedOutputs")), "", rd("ExpectedOutputs"))
                        .StartDate = IIf(IsDBNull(rd("StartDate")), "", rd("StartDate"))
                        .CompletionDate = IIf(IsDBNull(rd("CompletionDate")), "", rd("CompletionDate"))
                        .Objectives = IIf(IsDBNull(rd("Objectives")), "", rd("Objectives"))
                        .Budget_Year = IIf(IsDBNull(rd("Budget_Year")), "", rd("Budget_Year"))
                        .fundingsource_id = IIf(IsDBNull(rd("fundingsource_id")), 0, rd("fundingsource_id"))
                        .status = IIf(IsDBNull(rd("status")), "", rd("status"))
                        .PS = IIf(IsDBNull(rd("PS")), 0.0, rd("PS"))
                        .MOOE = IIf(IsDBNull(rd("MOOE")), 0.0, rd("MOOE"))
                        .CO = IIf(IsDBNull(rd("CO")), 0.0, rd("CO"))
                        .OFE = IIf(IsDBNull(rd("OFE")), 0.0, rd("OFE"))
                        .TotalCost = IIf(IsDBNull(rd("TotalCost")), 0.0, rd("TotalCost"))
                        .isGAD = IIf(IsDBNull(rd("isGAD")), 0, rd("isGAD"))
                        .TargetBeneficiaries = IIf(IsDBNull(rd("TargetBeneficiaries")), "", rd("TargetBeneficiaries"))
                        .PerformanceInd = IIf(IsDBNull(rd("PerformanceInd")), "", rd("PerformanceInd"))
                        .ProgramSeq = IIf(IsDBNull(rd("ProgramSeq")), 0, rd("ProgramSeq"))
                        .OtherOffices = IIf(IsDBNull(rd("OtherOffices")), "", rd("OtherOffices"))
                        .AIP_SubReport_ID = IIf(IsDBNull(rd("AIP_SubReport_ID")), 0, rd("AIP_SubReport_ID"))
                        .Prevprog_ID = IIf(IsDBNull(rd("Prevprog_ID")), 0, rd("Prevprog_ID"))
                        .isInfra = IIf(IsDBNull(rd("isInfra")), 0, rd("isInfra"))
                        .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
                        .TableName = IIf(IsDBNull(rd("TableName")), "", rd("TableName"))
                    End With
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub saveProgram()
            With Me
                .cmd.Parameters.AddWithValue("@Program_ID", 0)
                .cmd.Parameters.AddWithValue("@Program_Name", pProgram_Name)
                .cmd.Parameters.AddWithValue("@Program_Code", pProgram_Code)
                .cmd.Parameters.AddWithValue("@Sector_ID", pSector_ID)
                .cmd.Parameters.AddWithValue("@SubSector_ID", pSubSector_ID)
                .cmd.Parameters.AddWithValue("@F_ID", pF_ID)
                .cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
                .cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
                .cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
                .cmd.Parameters.AddWithValue("@ExpectedOutputs", pExpectedOutputs)
                .cmd.Parameters.AddWithValue("@StartDate", pStartDate)
                .cmd.Parameters.AddWithValue("@CompletionDate", pCompletionDate)
                .cmd.Parameters.AddWithValue("@Objectives", pObjectives)
                .cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
                .cmd.Parameters.AddWithValue("@fundingsource_id", pfundingsource_id)
                .cmd.Parameters.AddWithValue("@status", pstatus)
                .cmd.Parameters.AddWithValue("@PS", pPS)
                .cmd.Parameters.AddWithValue("@MOOE", pMOOE)
                .cmd.Parameters.AddWithValue("@CO", pCO)
                .cmd.Parameters.AddWithValue("@OFE", pOFE)
                .cmd.Parameters.AddWithValue("@TotalCost", pTotalCost)
                .cmd.Parameters.AddWithValue("@isGAD", pisGAD)
                .cmd.Parameters.AddWithValue("@TargetBeneficiaries", pTargetBeneficiaries)
                .cmd.Parameters.AddWithValue("@PerformanceInd", pPerformanceInd)
                .cmd.Parameters.AddWithValue("@ProgramSeq", pProgramSeq)
                .cmd.Parameters.AddWithValue("@OtherOffices", pOtherOffices)
                .cmd.Parameters.AddWithValue("@AIP_SubReport_ID", pAIP_SubReport_ID)
                .cmd.Parameters.AddWithValue("@Prevprog_ID", pPrevprog_ID)
                .cmd.Parameters.AddWithValue("@isInfra", pisInfra)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                .cmd.Parameters.AddWithValue("@TableName", pTableName)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With
            Execute("[GeoBOS].dbo.spSave_m_Program", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub updateProgram()
            With Me
                .cmd.Parameters.AddWithValue("@Program_ID", pProgram_ID)
                .cmd.Parameters.AddWithValue("@Program_Name", pProgram_Name)
                .cmd.Parameters.AddWithValue("@Program_Code", pProgram_Code)
                .cmd.Parameters.AddWithValue("@Sector_ID", pSector_ID)
                .cmd.Parameters.AddWithValue("@SubSector_ID", pSubSector_ID)
                .cmd.Parameters.AddWithValue("@F_ID", pF_ID)
                .cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
                .cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
                .cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
                .cmd.Parameters.AddWithValue("@ExpectedOutputs", pExpectedOutputs)
                .cmd.Parameters.AddWithValue("@StartDate", pStartDate)
                .cmd.Parameters.AddWithValue("@CompletionDate", pCompletionDate)
                .cmd.Parameters.AddWithValue("@Objectives", pObjectives)
                .cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
                .cmd.Parameters.AddWithValue("@fundingsource_id", pfundingsource_id)
                .cmd.Parameters.AddWithValue("@status", pstatus)
                .cmd.Parameters.AddWithValue("@PS", pPS)
                .cmd.Parameters.AddWithValue("@MOOE", pMOOE)
                .cmd.Parameters.AddWithValue("@CO", pCO)
                .cmd.Parameters.AddWithValue("@OFE", pOFE)
                .cmd.Parameters.AddWithValue("@TotalCost", pTotalCost)
                .cmd.Parameters.AddWithValue("@isGAD", pisGAD)
                .cmd.Parameters.AddWithValue("@TargetBeneficiaries", pTargetBeneficiaries)
                .cmd.Parameters.AddWithValue("@PerformanceInd", pPerformanceInd)
                .cmd.Parameters.AddWithValue("@ProgramSeq", pProgramSeq)
                .cmd.Parameters.AddWithValue("@OtherOffices", pOtherOffices)
                .cmd.Parameters.AddWithValue("@AIP_SubReport_ID", pAIP_SubReport_ID)
                .cmd.Parameters.AddWithValue("@Prevprog_ID", pPrevprog_ID)
                .cmd.Parameters.AddWithValue("@isInfra", pisInfra)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                .cmd.Parameters.AddWithValue("@TableName", pTableName)

                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("@CurrID", "[GeoBOS].dbo.spSave_m_Program", Data.CommandType.StoredProcedure)
        End Sub

        Public Function selectInfo() As DataTable
            Me.cmd.Parameters.AddWithValue("Program_Name", pProgram_Name)
            Dim x As New DataTable
            x = Me.GetDataTable("[GeoBOS].BOS.program_searchInfo", CommandType.StoredProcedure)
            Return x
        End Function
    End Class
#End Region

#Region "Funding_Source"
    Public Class m_FundingSource
        Inherits bBaseDAL

        Private pfundingsource_ID As Long
        Public Property fundingsource_ID() As Long
            Get
                Return pfundingsource_ID
            End Get
            Set(ByVal value As Long)
                pfundingsource_ID = value
            End Set
        End Property

        Private pfundingsource_desc As String
        Public Property fundingsource_desc() As String
            Get
                Return pfundingsource_desc
            End Get
            Set(ByVal value As String)
                pfundingsource_desc = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()

                End While
            Catch ex As Exception
                Me.fundingsource_ID = IIf(IsDBNull(rd("fundingsource_ID")), 0, rd("fundingsource_ID"))
                Me.fundingsource_desc = IIf(IsDBNull(rd("fundingsource_desc")), "", rd("fundingsource_desc"))
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Function getFundingSourceID() As Long
            Me.cmd.Parameters.AddWithValue("fundingSource_desc", pfundingsource_desc)
            Dim x As Long
            x = Me.GetValue("[GeoBOS].BOS.fundingSource_getID", CommandType.StoredProcedure)
            Return x
        End Function
    End Class
#End Region

#Region "AIPstatmsg"
    Public Class AIPstatmsg
        Inherits bBaseDAL

        Private pstatcode As String
        Public Property statcode() As String
            Get
                Return pstatcode
            End Get
            Set(ByVal value As String)
                pstatcode = value
            End Set
        End Property

        Private pstatmsg As String
        Public Property statmsg() As String
            Get
                Return pstatmsg
            End Get
            Set(ByVal value As String)
                pstatmsg = value
            End Set
        End Property


        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()

                End While
            Catch ex As Exception
                Me.statcode = IIf(IsDBNull(rd("statcode")), "", rd("statcode"))
                Me.statmsg = IIf(IsDBNull(rd("statmsg")), "", rd("statmsg"))
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub
    End Class
#End Region

#Region "AIPsignatories"
    Public Class m_AIPsignatories
        Inherits bBaseDAL

        Private paip_id As Long
        Public Property aip_id() As Long
            Get
                Return paip_id
            End Get
            Set(ByVal value As Long)
                paip_id = value
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

        Private ppreparedbyID As Long
        Public Property preparedbyID() As Long
            Get
                Return ppreparedbyID
            End Get
            Set(ByVal value As Long)
                ppreparedbyID = value
            End Set
        End Property

        Private previewedbyID As Long
        Public Property reviewedbyID() As Long
            Get
                Return previewedbyID
            End Get
            Set(ByVal value As Long)
                previewedbyID = value
            End Set
        End Property

        Private papprovedbyID As Long
        Public Property approvedbyID() As Long
            Get
                Return papprovedbyID
            End Get
            Set(ByVal value As Long)
                papprovedbyID = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()

                End While
            Catch ex As Exception
                Me.aip_id = IIf(IsDBNull(rd("aip_id")), 0, rd("aip_id"))
                Me.Budget_Year = IIf(IsDBNull(rd("Budget_Year")), "", rd("Budget_Year"))
                Me.preparedbyID = IIf(IsDBNull(rd("preparedbyID")), 0, rd("preparedbyID"))
                Me.reviewedbyID = IIf(IsDBNull(rd("reviewedbyID")), 0, rd("reviewedbyID"))
                Me.approvedbyID = IIf(IsDBNull(rd("approvedbyID")), 0, rd("approvedbyID"))
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub saveAIPsignatories()
            Me.cmd.Parameters.AddWithValue("@aip_id", 0)
            Me.cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            Me.cmd.Parameters.AddWithValue("@preparedbyID", ppreparedbyID)
            Me.cmd.Parameters.AddWithValue("@reviewedbyID", previewedbyID)
            Me.cmd.Parameters.AddWithValue("@approvedbyID", papprovedbyID)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].BOS.spSave_m_AIPsignatories", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub updateAIPsignatories()
            Me.cmd.Parameters.AddWithValue("@aip_id", paip_id)
            Me.cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            Me.cmd.Parameters.AddWithValue("@preparedbyID", ppreparedbyID)
            Me.cmd.Parameters.AddWithValue("@reviewedbyID", previewedbyID)
            Me.cmd.Parameters.AddWithValue("@approvedbyID", papprovedbyID)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].BOS.spSave_m_AIPsignatories", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region
#Region "m_functionalStatements"
    Public Class m_functionalStatements
        Inherits bBaseDAL

        Private pfs_id As Long
        Public Property fs_id() As Long
            Get
                Return pfs_id
            End Get
            Set(ByVal value As Long)
                pfs_id = value
            End Set
        End Property

        Private pfs As String
        Public Property fs() As String
            Get
                Return pfs
            End Get
            Set(ByVal value As String)
                pfs = value
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

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()

                End While
            Catch ex As Exception
                Me.fs_id = IIf(IsDBNull(rd("fs_id")), 0, rd("fs_id"))
                Me.fs = IIf(IsDBNull(rd("fs")), "", rd("fs"))
                Me.UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub saveFS()
            Me.cmd.Parameters.AddWithValue("@fs_id", 0)
            Me.cmd.Parameters.AddWithValue("@fs", pfs)
            Me.cmd.Parameters.AddWithValue("@UserID", pUserID)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].[BOS].[spSave_m_functionalStatement]", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub updateFS()
            Me.cmd.Parameters.AddWithValue("@fs_id", pfs_id)
            Me.cmd.Parameters.AddWithValue("@fs", pfs)
            Me.cmd.Parameters.AddWithValue("@UserID", pUserID)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("@CurrID", "[GeoBOS].[BOS].[spSave_m_functionalStatement]", Data.CommandType.StoredProcedure)
        End Sub

        Public Function checkFS() As Long
            Me.cmd.Parameters.AddWithValue("fs", pfs)
            Dim x As Long
            x = Me.GetValue("[GeoBOS].BOS.LBPF5_checkFS", CommandType.StoredProcedure)
            Return x
        End Function
    End Class
#End Region

#Region "LBPF5_objectives"
    Public Class m_objective
        Inherits bBaseDAL

        Private pobj_id As Long
        Public Property obj_id() As Long
            Get
                Return pobj_id
            End Get
            Set(ByVal value As Long)
                pobj_id = value
            End Set
        End Property

        Private pobj As String
        Public Property obj() As String
            Get
                Return pobj
            End Get
            Set(ByVal value As String)
                pobj = value
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

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()

                End While
            Catch ex As Exception
                Me.obj_id = IIf(IsDBNull(rd("obj_id")), 0, rd("obj_id"))
                Me.obj = IIf(IsDBNull(rd("obj")), "", rd("obj"))
                Me.UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub saveObj()
            Me.cmd.Parameters.AddWithValue("@obj_id", 0)
            Me.cmd.Parameters.AddWithValue("@obj", pobj)
            Me.cmd.Parameters.AddWithValue("@UserID", pUserID)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].BOS.spSave_m_Objective", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub updateObj()
            Me.cmd.Parameters.AddWithValue("@obj_id", pobj_id)
            Me.cmd.Parameters.AddWithValue("@obj", pobj)
            Me.cmd.Parameters.AddWithValue("@UserID", pUserID)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("@CurrID", "[GeoBOS].BOS.spSave_m_Objective", Data.CommandType.StoredProcedure)
        End Sub

        Public Function checkObj() As Long
            Me.cmd.Parameters.AddWithValue("obj", pobj)
            Dim x As Long
            x = Me.GetValue("[GeoBOS].BOS.LBPF5_checkObj", CommandType.StoredProcedure)
            Return x
        End Function
    End Class
#End Region

#Region "LBPF_5_fs"
    Public Class LBPF_5_fs
        Inherits bBaseDAL

        Private pLBPF_5_fs_ID As Long
        Public Property LBPF_5_fs_ID() As Long
            Get
                Return pLBPF_5_fs_ID
            End Get
            Set(ByVal value As Long)
                pLBPF_5_fs_ID = value
            End Set
        End Property

        Private pLBPF_5_Hdr_ID As Long
        Public Property LBPF_5_Hdr_ID() As Long
            Get
                Return pLBPF_5_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pLBPF_5_Hdr_ID = value
            End Set
        End Property

        Private pfs_id As Long
        Public Property fs_id() As Long
            Get
                Return pfs_id
            End Get
            Set(ByVal value As Long)
                pfs_id = value
            End Set
        End Property

        Private pdeptID As Long
        Public Property deptID() As Long
            Get
                Return pdeptID
            End Get
            Set(ByVal value As Long)
                pdeptID = value
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

        Public Overrides Sub FillEntity()
            Try
                With Me
                    .LBPF_5_fs_ID = IIf(IsDBNull(rd("LBPF_5_fs_ID")), 0, rd("LBPF_5_fs_ID"))
                    .LBPF_5_Hdr_ID = IIf(IsDBNull(rd("LBPF_5_Hdr_ID")), 0, rd("LBPF_5_Hdr_ID"))
                    .fs_id = IIf(IsDBNull(rd("fs_id")), 0, rd("fs_id"))
                    .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
                End With
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub save()
            With Me
                .cmd.Parameters.AddWithValue("@LBPF_5_fs_ID", 0)
                .cmd.Parameters.AddWithValue("@LBPF_5_Hdr_ID", pLBPF_5_Hdr_ID)
                .cmd.Parameters.AddWithValue("@fs_id", pfs_id)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("[GeoBOS].dbo.spSave_LBPF_5_fs", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub update()
            With Me
                .cmd.Parameters.AddWithValue("@LBPF_5_fs_ID", pLBPF_5_fs_ID)
                .cmd.Parameters.AddWithValue("@LBPF_5_Hdr_ID", pLBPF_5_Hdr_ID)
                .cmd.Parameters.AddWithValue("@fs_id", pfs_id)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("@CurrID", "[GeoBOS].dbo.spSave_LBPF_5_fs", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "LBPF_5_obj"
    Public Class LBPF_5_obj
        Inherits bBaseDAL

        Private pLBPF_5_obj_id As Long
        Public Property LBPF_5_obj_id() As Long
            Get
                Return pLBPF_5_obj_id
            End Get
            Set(ByVal value As Long)
                pLBPF_5_obj_id = value
            End Set
        End Property

        Private pLBPF_5_Hdr_ID As Long
        Public Property LBPF_5_Hdr_ID() As Long
            Get
                Return pLBPF_5_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pLBPF_5_Hdr_ID = value
            End Set
        End Property

        Private pobj_id As Long
        Public Property obj_id() As Long
            Get
                Return pobj_id
            End Get
            Set(ByVal value As Long)
                pobj_id = value
            End Set
        End Property

        Private pdeptID As Long
        Public Property deptID() As Long
            Get
                Return pdeptID
            End Get
            Set(ByVal value As Long)
                pdeptID = value
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

        Public Overrides Sub FillEntity()
            Try
                With Me
                    .LBPF_5_obj_id = IIf(IsDBNull(rd("LBPF_5_obj_id")), 0, rd("LBPF_5_obj_id"))
                    .LBPF_5_Hdr_ID = IIf(IsDBNull(rd("LBPF_5_Hdr_ID")), 0, rd("LBPF_5_Hdr_ID"))
                    .obj_id = IIf(IsDBNull(rd("obj_id")), 0, rd("obj_id"))
                    .deptID = IIf(IsDBNull(rd("deptID")), 0, rd("deptID"))
                    .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
                End With
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub save()
            With Me
                .cmd.Parameters.AddWithValue("@LBPF_5_obj_id", 0)
                .cmd.Parameters.AddWithValue("@LBPF_5_Hdr_ID", pLBPF_5_Hdr_ID)
                .cmd.Parameters.AddWithValue("@obj_id", pobj_id)
                .cmd.Parameters.AddWithValue("@deptID", pdeptID)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("[GeoBOS].dbo.spSave_LBPF_5_obj", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub update()
            With Me
                .cmd.Parameters.AddWithValue("@LBPF_5_obj_id", pLBPF_5_obj_id)
                .cmd.Parameters.AddWithValue("@LBPF_5_Hdr_ID", pLBPF_5_Hdr_ID)
                .cmd.Parameters.AddWithValue("@obj_id", pobj_id)
                .cmd.Parameters.AddWithValue("@deptID", pdeptID)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("@CurrID", "[GeoBOS].dbo.spSave_LBPF_5_obj", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "LBPF5_Hdr"
    Public Class LBPF_5_Hdr
        Inherits bBaseDAL

        Private pLBPF_5_Hdr_ID As Long
        Public Property LBPF_5_Hdr_ID() As Long
            Get
                Return pLBPF_5_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pLBPF_5_Hdr_ID = value
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

        Private pPreparedby_ID As Integer
        Public Property Preparedby_ID() As Integer
            Get
                Return pPreparedby_ID
            End Get
            Set(ByVal value As Integer)
                pPreparedby_ID = value
            End Set
        End Property

        Private pReviewedby_ID As Integer
        Public Property Reviewedby_ID() As Integer
            Get
                Return pReviewedby_ID
            End Get
            Set(ByVal value As Integer)
                pReviewedby_ID = value
            End Set
        End Property

        Private pApprovedby_ID As Integer
        Public Property Approvedby_ID() As Integer
            Get
                Return pApprovedby_ID
            End Get
            Set(ByVal value As Integer)
                pApprovedby_ID = value
            End Set
        End Property

        Private pDeptID As Long
        Public Property DeptID() As Long
            Get
                Return pDeptID
            End Get
            Set(ByVal value As Long)
                pDeptID = value
            End Set
        End Property

        Private pFunctionID As Long
        Public Property FunctionID() As Long
            Get
                Return pFunctionID
            End Get
            Set(ByVal value As Long)
                pFunctionID = value
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

        Public Overrides Sub FillEntity()
            Try
                'fill entity statements here
                With Me
                    .LBPF_5_Hdr_ID = IIf(IsDBNull(rd("LBPF_5_Hdr_ID")), 0, rd("LBPF_5_Hdr_ID"))
                    .Budget_Year = IIf(IsDBNull(rd("Budget_Year")), "", rd("Budget_Year"))
                    .Preparedby_ID = IIf(IsDBNull(rd("Preparedby_ID")), 0, rd("Preparedby_ID"))
                    .Reviewedby_ID = IIf(IsDBNull(rd("Reviewedby_ID")), 0, rd("Reviewedby_ID"))
                    .Approvedby_ID = IIf(IsDBNull(rd("Approvedby_ID")), 0, rd("Approvedby_ID"))
                    .DeptID = IIf(IsDBNull(rd("DeptID")), 0, rd("DeptID"))
                    .FunctionID = IIf(IsDBNull(rd("FunctionID")), 0, rd("FunctionID"))
                    .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
                End With
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub saveLPF5Hdr()
            With Me
                .cmd.Parameters.AddWithValue("@LBPF_5_Hdr_ID", 0)
                .cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
                .cmd.Parameters.AddWithValue("@Preparedby_ID", pPreparedby_ID)
                .cmd.Parameters.AddWithValue("@Reviewedby_ID", pReviewedby_ID)
                .cmd.Parameters.AddWithValue("@Approvedby_ID", pApprovedby_ID)
                .cmd.Parameters.AddWithValue("@DeptID", pDeptID)
                .cmd.Parameters.AddWithValue("@FunctionID", pFunctionID)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("[GeoBOS].dbo.spSave_LBPF_5_Hdr", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub updateLPF5Hdr()
            With Me
                .cmd.Parameters.AddWithValue("@LBPF_5_Hdr_ID", pLBPF_5_Hdr_ID)
                .cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
                .cmd.Parameters.AddWithValue("@Preparedby_ID", pPreparedby_ID)
                .cmd.Parameters.AddWithValue("@Reviewedby_ID", pReviewedby_ID)
                .cmd.Parameters.AddWithValue("@Approvedby_ID", pApprovedby_ID)
                .cmd.Parameters.AddWithValue("@DeptID", pDeptID)
                .cmd.Parameters.AddWithValue("@FunctionID", pFunctionID)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("@CurrID", "[GeoBOS].dbo.spSave_LBPF_5_Hdr", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "LBPF5_dtl"
    Public Class LBPF_5_dtl
        Inherits bBaseDAL

        Private pLBPF_5_Dtl_ID As Long
        Public Property LBPF_5_Dtl_ID() As Long
            Get
                Return pLBPF_5_Dtl_ID
            End Get
            Set(ByVal value As Long)
                pLBPF_5_Dtl_ID = value
            End Set
        End Property

        Private pLBPF_5_Hdr_ID As Long
        Public Property LBPF_5_Hdr_ID() As Long
            Get
                Return pLBPF_5_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pLBPF_5_Hdr_ID = value
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

        Private pAnnualTargets As String
        Public Property AnnualTargets() As String
            Get
                Return pAnnualTargets
            End Get
            Set(ByVal value As String)
                pAnnualTargets = value
            End Set
        End Property

        Private prefCode As String
        Public Property refCode() As String
            Get
                Return prefCode
            End Get
            Set(ByVal value As String)
                prefCode = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.LBPF_5_Dtl_ID = IIf(IsDBNull(rd("LBPF_5_Dtl_ID")), 0, rd("LBPF_5_Dtl_ID"))
                    Me.LBPF_5_Hdr_ID = IIf(IsDBNull(rd("LBPF_5_Hdr_ID")), 0, rd("LBPF_5_Hdr_ID"))
                    Me.PerformanceInd = IIf(IsDBNull(rd("PerformanceInd")), "", rd("PerformanceInd"))
                    Me.AnnualTargets = IIf(IsDBNull(rd("AnnualTargets")), "", rd("AnnualTargets"))
                    Me.refCode = IIf(IsDBNull(rd("refCode")), "", rd("refCode"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub saveLPF5Dtl()
            Me.cmd.Parameters.AddWithValue("@LBPF_5_Dtl_ID", 0)
            Me.cmd.Parameters.AddWithValue("@LBPF_5_Hdr_ID", pLBPF_5_Hdr_ID)
            Me.cmd.Parameters.AddWithValue("@PerformanceInd", pPerformanceInd)
            Me.cmd.Parameters.AddWithValue("@AnnualTargets", pAnnualTargets)
            Me.cmd.Parameters.AddWithValue("@refCode", prefCode)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].BOS.spSave_LBPF_5_Dtl", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub updateLPF5Dtl()
            Me.cmd.Parameters.AddWithValue("@LBPF_5_Dtl_ID", pLBPF_5_Dtl_ID)
            Me.cmd.Parameters.AddWithValue("@LBPF_5_Hdr_ID", pLBPF_5_Hdr_ID)
            Me.cmd.Parameters.AddWithValue("@PerformanceInd", pPerformanceInd)
            Me.cmd.Parameters.AddWithValue("@AnnualTargets", pAnnualTargets)
            Me.cmd.Parameters.AddWithValue("@refCode", prefCode)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("@CurrID", "[GeoBOS].BOS.spSave_LBPF_5_Dtl", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "LBPF6_Hdr"
    Public Class LBPF6_Hdr
        Inherits bBaseDAL
        Private pLBPF_6_Hdr_ID As Long
        Public Property LBPF_6_Hdr_ID() As Long
            Get
                Return pLBPF_6_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pLBPF_6_Hdr_ID = value
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

        Private pF_ID As Long
        Public Property F_ID() As Long
            Get
                Return pF_ID
            End Get
            Set(ByVal value As Long)
                pF_ID = value
            End Set
        End Property

        Private pCertifiedBy As Integer
        Public Property CertifiedBy() As Integer
            Get
                Return pCertifiedBy
            End Get
            Set(ByVal value As Integer)
                pCertifiedBy = value
            End Set
        End Property

        Private pNotedBy As Integer
        Public Property NotedBy() As Integer
            Get
                Return pNotedBy
            End Get
            Set(ByVal value As Integer)
                pNotedBy = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.LBPF_6_Hdr_ID = IIf(IsDBNull(rd("LBPF_6_Hdr_ID")), 0, rd("LBPF_6_Hdr_ID"))
                    Me.Budget_Year = IIf(IsDBNull(rd("Budget_Year")), "", rd("Budget_Year"))
                    Me.F_ID = IIf(IsDBNull(rd("F_ID")), 0, rd("F_ID"))
                    Me.CertifiedBy = IIf(IsDBNull(rd("CertifiedBy")), 0, rd("CertifiedBy"))
                    Me.NotedBy = IIf(IsDBNull(rd("NotedBy")), 0, rd("NotedBy"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub saveLBPF6()
            Me.cmd.Parameters.AddWithValue("@LBPF_6_Hdr_ID", 0)
            Me.cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            Me.cmd.Parameters.AddWithValue("@F_ID", pF_ID)
            Me.cmd.Parameters.AddWithValue("@CertifiedBy", pCertifiedBy)
            Me.cmd.Parameters.AddWithValue("@NotedBy", pNotedBy)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].BOS.spSave_LBPF_6_Hdr", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub updateLBPF6()
            Me.cmd.Parameters.AddWithValue("@LBPF_6_Hdr_ID", pLBPF_6_Hdr_ID)
            Me.cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            Me.cmd.Parameters.AddWithValue("@F_ID", pF_ID)
            Me.cmd.Parameters.AddWithValue("@CertifiedBy", pCertifiedBy)
            Me.cmd.Parameters.AddWithValue("@NotedBy", pNotedBy)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("@CurrID", "[GeoBOS].BOS.spSave_LBPF_6_Hdr", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "LBPF6_Dtl"
    Public Class LBPF6_Dtl
        Inherits bBaseDAL

        Private pLBPF_6_Dtl_ID As Long
        Public Property LBPF_6_Dtl_ID() As Long
            Get
                Return pLBPF_6_Dtl_ID
            End Get
            Set(ByVal value As Long)
                pLBPF_6_Dtl_ID = value
            End Set
        End Property

        Private pLBPF_6_Hdr_ID As Long
        Public Property LBPF_6_Hdr_ID() As Long
            Get
                Return pLBPF_6_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pLBPF_6_Hdr_ID = value
            End Set
        End Property

        Private pCredit_ID As Long
        Public Property Credit_ID() As Long
            Get
                Return pCredit_ID
            End Get
            Set(ByVal value As Long)
                pCredit_ID = value
            End Set
        End Property

        Private pPrevious_AmountPaid As Decimal
        Public Property Previous_AmountPaid() As Decimal
            Get
                Return pPrevious_AmountPaid
            End Get
            Set(ByVal value As Decimal)
                pPrevious_AmountPaid = value
            End Set
        End Property

        Private pPrevious_Interest As Decimal
        Public Property Previous_Interest() As Decimal
            Get
                Return pPrevious_Interest
            End Get
            Set(ByVal value As Decimal)
                pPrevious_Interest = value
            End Set
        End Property

        Private pAmountDue As Decimal
        Public Property AmountDue() As Decimal
            Get
                Return pAmountDue
            End Get
            Set(ByVal value As Decimal)
                pAmountDue = value
            End Set
        End Property

        Private pDue_Interest As Decimal
        Public Property Due_Interest() As Decimal
            Get
                Return pDue_Interest
            End Get
            Set(ByVal value As Decimal)
                pDue_Interest = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.LBPF_6_Dtl_ID = IIf(IsDBNull(rd("LBPF_6_Dtl_ID")), 0, rd("LBPF_6_Dtl_ID"))
                    Me.LBPF_6_Hdr_ID = IIf(IsDBNull(rd("LBPF_6_Hdr_ID")), 0, rd("LBPF_6_Hdr_ID"))
                    Me.Credit_ID = IIf(IsDBNull(rd("Credit_ID")), 0, rd("Credit_ID"))
                    Me.Previous_AmountPaid = IIf(IsDBNull(rd("Previous_AmountPaid")), 0.0, rd("Previous_AmountPaid"))
                    Me.Previous_Interest = IIf(IsDBNull(rd("Previous_Interest")), 0.0, rd("Previous_Interest"))
                    Me.AmountDue = IIf(IsDBNull(rd("AmountDue")), 0.0, rd("AmountDue"))
                    Me.Due_Interest = IIf(IsDBNull(rd("Due_Interest")), 0.0, rd("Due_Interest"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub saveLBPF6()
            Me.cmd.Parameters.AddWithValue("@LBPF_6_Dtl_ID", 0)
            Me.cmd.Parameters.AddWithValue("@LBPF_6_Hdr_ID", LBPF_6_Hdr_ID)
            Me.cmd.Parameters.AddWithValue("@Credit_ID", pCredit_ID)
            Me.cmd.Parameters.AddWithValue("@Previous_AmountPaid", pPrevious_AmountPaid)
            Me.cmd.Parameters.AddWithValue("@Previous_Interest", pPrevious_Interest)
            Me.cmd.Parameters.AddWithValue("@AmountDue", pAmountDue)
            Me.cmd.Parameters.AddWithValue("@Due_Interest", pDue_Interest)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].BOS.spSave_LBPF_6_Dtl", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub updateLBPF6()
            Me.cmd.Parameters.AddWithValue("@LBPF_6_Dtl_ID", pLBPF_6_Dtl_ID)
            Me.cmd.Parameters.AddWithValue("@LBPF_6_Hdr_ID", LBPF_6_Hdr_ID)
            Me.cmd.Parameters.AddWithValue("@Credit_ID", pCredit_ID)
            Me.cmd.Parameters.AddWithValue("@Previous_AmountPaid", pPrevious_AmountPaid)
            Me.cmd.Parameters.AddWithValue("@Previous_Interest", pPrevious_Interest)
            Me.cmd.Parameters.AddWithValue("@AmountDue", pAmountDue)
            Me.cmd.Parameters.AddWithValue("@Due_Interest", pDue_Interest)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("@CurrID", "[GeoBOS].BOS.spSave_LBPF_6_Dtl", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "Credit"
    Public Class Credit
        Inherits bBaseDAL

        Private pCredit_ID As Long
        Public Property Credit_ID() As Long
            Get
                Return pCredit_ID
            End Get
            Set(ByVal value As Long)
                pCredit_ID = value
            End Set
        End Property

        Private pCreditor_ID As Long
        Public Property Creditor_ID() As Long
            Get
                Return pCreditor_ID
            End Get
            Set(ByVal value As Long)
                pCreditor_ID = value
            End Set
        End Property

        Private pDate_Contracted As DateTime
        Public Property Date_Contracted() As DateTime
            Get
                Return pDate_Contracted
            End Get
            Set(ByVal value As DateTime)
                pDate_Contracted = value
            End Set
        End Property

        Private pTerm As Int32
        Public Property Term() As Int32
            Get
                Return pTerm
            End Get
            Set(ByVal value As Int32)
                pTerm = value
            End Set
        End Property

        Private pPrincipal_Amount As Decimal
        Public Property Principal_Amount() As Decimal
            Get
                Return pPrincipal_Amount
            End Get
            Set(ByVal value As Decimal)
                pPrincipal_Amount = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.Credit_ID = IIf(IsDBNull(rd("Credit_ID")), 0, rd("Credit_ID"))
                    Me.Creditor_ID = IIf(IsDBNull(rd("Creditor_ID")), 0, rd("Creditor_ID"))
                    Me.Date_Contracted = IIf(IsDBNull(rd("Date_Contracted")), "", rd("Date_Contracted"))
                    Me.Term = IIf(IsDBNull(rd("Term")), "", rd("Term"))
                    Me.Principal_Amount = IIf(IsDBNull(rd("Principal_Amount")), 0.0, rd("Principal_Amount"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub saveCredit()
            Me.cmd.Parameters.AddWithValue("@Credit_ID", 0)
            Me.cmd.Parameters.AddWithValue("@Creditor_ID", pCreditor_ID)
            Me.cmd.Parameters.AddWithValue("@Date_Contracted", pDate_Contracted)
            Me.cmd.Parameters.AddWithValue("@Term", pTerm)
            Me.cmd.Parameters.AddWithValue("@Principal_Amount", pPrincipal_Amount)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].BOS.spSave_m_Credit", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub updateCredit()
            Me.cmd.Parameters.AddWithValue("@Credit_ID", pCredit_ID)
            Me.cmd.Parameters.AddWithValue("@Creditor_ID", pCreditor_ID)
            Me.cmd.Parameters.AddWithValue("@Date_Contracted", pDate_Contracted)
            Me.cmd.Parameters.AddWithValue("@Term", pTerm)
            Me.cmd.Parameters.AddWithValue("@Principal_Amount", pPrincipal_Amount)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("@CurrID", "[GeoBOS].BOS.spSave_m_Credit", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "Creditor"
    Public Class Creditor
        Inherits bBaseDAL

        Private pCreditor_ID As Long
        Public Property Creditor_ID() As Long
            Get
                Return pCreditor_ID
            End Get
            Set(ByVal value As Long)
                pCreditor_ID = value
            End Set
        End Property

        Private pCreditor_Name As String
        Public Property Creditor_Name() As String
            Get
                Return pCreditor_Name
            End Get
            Set(ByVal value As String)
                pCreditor_Name = value
            End Set
        End Property

        Private pCreditor_Address As String
        Public Property Creditor_Address() As String
            Get
                Return pCreditor_Address
            End Get
            Set(ByVal value As String)
                pCreditor_Address = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.Creditor_ID = IIf(IsDBNull(rd("Creditor_ID")), 0, rd("Creditor_ID"))
                    Me.Creditor_Name = IIf(IsDBNull(rd("Creditor_Name")), "", rd("Creditor_Name"))
                    Me.Creditor_Address = IIf(IsDBNull(rd("Creditor_Address")), "", rd("Creditor_Address"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub saveCreditor()
            Me.cmd.Parameters.AddWithValue("@Creditor_ID", 0)
            Me.cmd.Parameters.AddWithValue("@Creditor_Name", pCreditor_Name)
            Me.cmd.Parameters.AddWithValue("@Creditor_Address", pCreditor_Address)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].BOS.spSave_m_Creditor", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub updateCreditor()
            Me.cmd.Parameters.AddWithValue("@Creditor_ID", pCreditor_ID)
            Me.cmd.Parameters.AddWithValue("@Creditor_Name", pCreditor_Name)
            Me.cmd.Parameters.AddWithValue("@Creditor_Address", pCreditor_Address)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("@CurrID", "[GeoBOS].BOS.spSave_m_Creditor", Data.CommandType.StoredProcedure)
        End Sub

        Public Function checkCreditor() As Integer
            Me.cmd.Parameters.AddWithValue("@Creditor_Name", pCreditor_Name)

            Dim c As Integer
            c = GetValue("[GeoBOS].BOS.checkIfCreditorExists", Data.CommandType.StoredProcedure)
            Return c
        End Function
    End Class
#End Region

#Region "Sector"
    Public Class sector
        Inherits bBaseDAL

        Private pSector_ID As Long
        Public Property Sector_ID() As Long
            Get
                Return pSector_ID
            End Get
            Set(ByVal value As Long)
                pSector_ID = value
            End Set
        End Property

        Private pSector_Desc As String
        Public Property Sector_Desc() As String
            Get
                Return pSector_Desc
            End Get
            Set(ByVal value As String)
                pSector_Desc = value
            End Set
        End Property

        Private pSector_Code As String
        Public Property Sector_Code() As String
            Get
                Return pSector_Code
            End Get
            Set(ByVal value As String)
                pSector_Code = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.Sector_ID = IIf(IsDBNull(rd("Sector_ID")), 0, rd("Sector_ID"))
                    Me.Sector_Desc = IIf(IsDBNull(rd("Sector_Desc")), "", rd("Sector_Desc"))
                    Me.Sector_Code = IIf(IsDBNull(rd("Sector_Code")), "", rd("Sector_Code"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Function save_sector() As Long
            Me.cmd.Parameters.AddWithValue("@Sector_ID", 0)
            Me.cmd.Parameters.AddWithValue("@Sector_Desc", pSector_Desc)
            Me.cmd.Parameters.AddWithValue("@Sector_Code", pSector_Code)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].[BOS].[spSave_m_Sector]", CommandType.StoredProcedure)
        End Function

        Public Function update_sector() As Long
            Me.cmd.Parameters.AddWithValue("@Sector_ID", pSector_ID)
            Me.cmd.Parameters.AddWithValue("@Sector_Desc", pSector_Desc)
            Me.cmd.Parameters.AddWithValue("@Sector_Code", pSector_Code)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].[BOS].[spSave_m_Sector]", CommandType.StoredProcedure)
        End Function
    End Class
#End Region

#Region "SubSector"

    Public Class SubSector
        Inherits bBaseDAL

        Private pSubSector_ID As Long
        Public Property SubSector_ID() As Long
            Get
                Return pSubSector_ID
            End Get
            Set(ByVal value As Long)
                pSubSector_ID = value
            End Set
        End Property

        Private pSubSector_Name As String
        Public Property SubSector_Name() As String
            Get
                Return pSubSector_Name
            End Get
            Set(ByVal value As String)
                pSubSector_Name = value
            End Set
        End Property

        Private pSubSector_Code As String
        Public Property SubSector_Code() As String
            Get
                Return pSubSector_Code
            End Get
            Set(ByVal value As String)
                pSubSector_Code = value
            End Set
        End Property

        Private pSector_ID As String
        Public Property Sector_ID() As String
            Get
                Return pSector_ID
            End Get
            Set(ByVal value As String)
                pSector_ID = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.SubSector_ID = IIf(IsDBNull(rd("SubSector_ID")), 0, rd("SubSector_ID"))
                    Me.SubSector_Name = IIf(IsDBNull(rd("SubSector_Name")), "", rd("SubSector_Name"))
                    Me.SubSector_Code = IIf(IsDBNull(rd("SubSector_Code")), "", rd("SubSector_Code"))
                    Me.Sector_ID = IIf(IsDBNull(rd("Sector_ID")), "", rd("Sector_ID"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Function save_subsector() As Long
            Me.cmd.Parameters.AddWithValue("@SubSector_ID", 0)
            Me.cmd.Parameters.AddWithValue("@SubSector_Name", pSubSector_Name)
            Me.cmd.Parameters.AddWithValue("@SubSector_Code", pSubSector_Code)
            Me.cmd.Parameters.AddWithValue("@Sector_ID", pSector_ID)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].[BOS].[ spSave_m_SubSector]", CommandType.StoredProcedure)
        End Function

        Public Function update_subsector() As Long
            Me.cmd.Parameters.AddWithValue("@SubSector_ID", pSubSector_ID)
            Me.cmd.Parameters.AddWithValue("@SubSector_Name", pSubSector_Name)
            Me.cmd.Parameters.AddWithValue("@SubSector_Code", pSubSector_Code)
            Me.cmd.Parameters.AddWithValue("@Sector_ID", pSector_ID)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].[BOS].[ spSave_m_SubSector]", CommandType.StoredProcedure)
        End Function
    End Class

#End Region

#Region "Project"

    Public Class project
        Inherits bBaseDAL

        Private pProject_ID As Long
        Public Property Project_ID() As Long
            Get
                Return pProject_ID
            End Get
            Set(ByVal value As Long)
                pProject_ID = value
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

        Private pSector_ID As Integer
        Public Property Sector_ID() As Integer
            Get
                Return pSector_ID
            End Get
            Set(ByVal value As Integer)
                pSector_ID = value
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


        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.Project_ID = IIf(IsDBNull(rd("Project_ID")), 0, rd("Project_ID"))
                    Me.Project_Name = IIf(IsDBNull(rd("Project_Name")), "", rd("Project_Name"))
                    Me.Project_Code = IIf(IsDBNull(rd("Project_Code")), "", rd("Project_Code"))
                    Me.Sector_ID = IIf(IsDBNull(rd("Sector_ID")), 0, rd("Sector_ID"))
                    Me.F_ID = IIf(IsDBNull(rd("F_ID")), 0, rd("F_ID"))

                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Function save_to_project() As Long

            Me.cmd.Parameters.AddWithValue("@Project_ID", 0)
            Me.cmd.Parameters.AddWithValue("@Project_Name", pProject_Name)
            Me.cmd.Parameters.AddWithValue("@Project_Code", pProject_Code)
            Me.cmd.Parameters.AddWithValue("@Sector_ID", pSector_ID)
            Me.cmd.Parameters.AddWithValue("@F_ID", pF_ID)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].[BOS].[spSave_m_Project]", CommandType.StoredProcedure)

        End Function

        Public Function update_project() As Long

            Me.cmd.Parameters.AddWithValue("@Project_ID", pProject_ID)
            Me.cmd.Parameters.AddWithValue("@Project_Name", pProject_Name)
            Me.cmd.Parameters.AddWithValue("@Project_Code", pProject_Code)
            Me.cmd.Parameters.AddWithValue("@Sector_ID", pSector_ID)
            Me.cmd.Parameters.AddWithValue("@F_ID", pF_ID)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].[BOS].[spSave_m_Project]", CommandType.StoredProcedure)

        End Function

    End Class
#End Region

#Region "Signatory"
    Public Class Signatory
        Inherits bBaseDAL

        Private pSignatory_ID As Long
        Public Property Signatory_ID() As Long
            Get
                Return pSignatory_ID
            End Get
            Set(ByVal value As Long)
                pSignatory_ID = value
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

        Private pdivision_key As Integer
        Public Property division_key() As Integer
            Get
                Return pdivision_key
            End Get
            Set(ByVal value As Integer)
                pdivision_key = value
            End Set
        End Property

        Private pisDeptHead As Boolean
        Public Property isDeptHead() As Boolean
            Get
                Return pisDeptHead
            End Get
            Set(ByVal value As Boolean)
                pisDeptHead = value
            End Set
        End Property

        Private pempsig_ID As Long
        Public Property empsig_ID() As Long
            Get
                Return pempsig_ID
            End Get
            Set(ByVal value As Long)
                pempsig_ID = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.Signatory_ID = IIf(IsDBNull(rd("Signatory_ID")), 0, rd("Signatory_ID"))
                    Me.deptid = IIf(IsDBNull(rd("deptid")), 0, rd("deptid"))
                    Me.division_key = IIf(IsDBNull(rd("division_key")), 0, rd("division_key"))
                    Me.isDeptHead = IIf(IsDBNull(rd("isDeptHead")), 0, rd("isDeptHead"))
                    Me.empsig_ID = IIf(IsDBNull(rd("empsig_ID")), 0, rd("empsig_ID"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Function save_to_signatory() As Long
            With Me
                .cmd.Parameters.AddWithValue("@Signatory_ID", 0)
                .cmd.Parameters.AddWithValue("@deptid", pdeptid)
                .cmd.Parameters.AddWithValue("@division_key", pdivision_key)
                .cmd.Parameters.AddWithValue("@isDeptHead", pisDeptHead)
                .cmd.Parameters.AddWithValue("@empsig_ID", pempsig_ID)
            End With
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].[BOS].[spSave_m_Signatory]", CommandType.StoredProcedure)
        End Function

        Public Function update_signatory() As Long
            With Me
                .cmd.Parameters.AddWithValue("@Signatory_ID", pSignatory_ID)
                .cmd.Parameters.AddWithValue("@deptid", pdeptid)
                .cmd.Parameters.AddWithValue("@division_key", pdivision_key)
                .cmd.Parameters.AddWithValue("@isDeptHead", pisDeptHead)
                .cmd.Parameters.AddWithValue("@empsig_ID", pempsig_ID)
            End With
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[GeoBOS].[BOS].[spSave_m_Signatory]", CommandType.StoredProcedure)
        End Function
    End Class
#End Region

#Region "BA_OR_3_Template"
    Public Class BA_OR_3_Template
        Inherits bBaseDAL

        Private pid As Integer
        Public Property id() As Integer
            Get
                Return pid
            End Get
            Set(ByVal value As Integer)
                pid = value
            End Set
        End Property

        Private ph1 As String
        Public Property h1() As String
            Get
                Return ph1
            End Get
            Set(ByVal value As String)
                ph1 = value
            End Set
        End Property

        Private ph2 As String
        Public Property h2() As String
            Get
                Return ph2
            End Get
            Set(ByVal value As String)
                ph2 = value
            End Set
        End Property

        Private ps1 As String
        Public Property s1() As String
            Get
                Return ps1
            End Get
            Set(ByVal value As String)
                ps1 = value
            End Set
        End Property

        Private ps2 As String
        Public Property s2() As String
            Get
                Return ps2
            End Get
            Set(ByVal value As String)
                ps2 = value
            End Set
        End Property

        Private ps3 As String
        Public Property s3() As String
            Get
                Return ps3
            End Get
            Set(ByVal value As String)
                ps3 = value
            End Set
        End Property

        Private ps4 As String
        Public Property s4() As String
            Get
                Return ps4
            End Get
            Set(ByVal value As String)
                ps4 = value
            End Set
        End Property

        Private penacted As String
        Public Property enacted() As String
            Get
                Return penacted
            End Get
            Set(ByVal value As String)
                penacted = value
            End Set
        End Property

        Private pcertify As String
        Public Property certify() As String
            Get
                Return pcertify
            End Get
            Set(ByVal value As String)
                pcertify = value
            End Set
        End Property

        Private pOrdinanceNo As String
        Public Property OrdinanceNo() As String
            Get
                Return pOrdinanceNo
            End Get
            Set(ByVal value As String)
                pOrdinanceNo = value
            End Set
        End Property

        Private pSeriesOf As Integer
        Public Property SeriesOf() As Integer
            Get
                Return pSeriesOf
            End Get
            Set(ByVal value As Integer)
                pSeriesOf = value
            End Set
        End Property

        Private pSangSec As String
        Public Property SangSec() As String
            Get
                Return pSangSec
            End Get
            Set(ByVal value As String)
                pSangSec = value
            End Set
        End Property

        Private pPresOfcr As String
        Public Property PresOfcr() As String
            Get
                Return pPresOfcr
            End Get
            Set(ByVal value As String)
                pPresOfcr = value
            End Set
        End Property

        Private pLCE As String
        Public Property LCE() As String
            Get
                Return pLCE
            End Get
            Set(ByVal value As String)
                pLCE = value
            End Set
        End Property

        Private pApprovalDate As String
        Public Property ApprovalDate() As String
            Get
                Return pApprovalDate
            End Get
            Set(ByVal value As String)
                pApprovalDate = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.id = IIf(IsDBNull(rd("id")), 0, rd("id"))
                    Me.h1 = IIf(IsDBNull(rd("h1")), "", rd("h1"))
                    Me.h2 = IIf(IsDBNull(rd("h2")), "", rd("h2"))
                    Me.s1 = IIf(IsDBNull(rd("s1")), "", rd("s1"))
                    Me.s2 = IIf(IsDBNull(rd("s2")), "", rd("s2"))
                    Me.s3 = IIf(IsDBNull(rd("s3")), "", rd("s3"))
                    Me.s4 = IIf(IsDBNull(rd("s4")), "", rd("s4"))
                    Me.enacted = IIf(IsDBNull(rd("enacted")), "", rd("enacted"))
                    Me.certify = IIf(IsDBNull(rd("certify")), "", rd("certify"))
                    Me.OrdinanceNo = IIf(IsDBNull(rd("OrdinanceNo")), "", rd("OrdinanceNo"))
                    Me.SeriesOf = IIf(IsDBNull(rd("SeriesOf")), 0, rd("SeriesOf"))
                    Me.SangSec = IIf(IsDBNull(rd("SangSec")), "", rd("SangSec"))
                    Me.PresOfcr = IIf(IsDBNull(rd("PresOfcr")), "", rd("PresOfcr"))
                    Me.LCE = IIf(IsDBNull(rd("LCE")), "", rd("LCE"))
                    Me.ApprovalDate = IIf(IsDBNull(rd("ApprovalDate")), "", rd("ApprovalDate"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub updateTemplate()
            Me.cmd.Parameters.AddWithValue("@id", pid)
            Me.cmd.Parameters.AddWithValue("@h1", ph1)
            Me.cmd.Parameters.AddWithValue("@h2", ph2)
            Me.cmd.Parameters.AddWithValue("@s1", ps1)
            Me.cmd.Parameters.AddWithValue("@s2", ps2)
            Me.cmd.Parameters.AddWithValue("@s3", ps3)
            Me.cmd.Parameters.AddWithValue("@s4", ps4)
            Me.cmd.Parameters.AddWithValue("@enacted", penacted)
            Me.cmd.Parameters.AddWithValue("@certify", pcertify)
            Me.cmd.Parameters.AddWithValue("@OrdinanceNo", pOrdinanceNo)
            Me.cmd.Parameters.AddWithValue("@SeriesOf", pSeriesOf)
            Me.cmd.Parameters.AddWithValue("@SangSec", pSangSec)
            Me.cmd.Parameters.AddWithValue("@PresOfcr", pPresOfcr)
            Me.cmd.Parameters.AddWithValue("@LCE", pLCE)
            Me.cmd.Parameters.AddWithValue("@ApprovalDate", pApprovalDate)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            Execute("[GeoBOS].BOS.spSave_BA_OR_3_Template", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region


#Region "LBPF_7_Hdr"
    Public Class LBPF_7_Hdr
        Inherits bBaseDAL

        Private pLBPF_7_Hdr_ID As Long
        Public Property LBPF_7_Hdr_ID() As Long
            Get
                Return pLBPF_7_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pLBPF_7_Hdr_ID = value
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

        Private psig1 As String
        Public Property sig1() As String
            Get
                Return psig1
            End Get
            Set(ByVal value As String)
                psig1 = value
            End Set
        End Property

        Private psig2 As String
        Public Property sig2() As String
            Get
                Return psig2
            End Get
            Set(ByVal value As String)
                psig2 = value
            End Set
        End Property

        Private psig3 As String
        Public Property sig3() As String
            Get
                Return psig3
            End Get
            Set(ByVal value As String)
                psig3 = value
            End Set
        End Property

        Private psig4 As String
        Public Property sig4() As String
            Get
                Return psig4
            End Get
            Set(ByVal value As String)
                psig4 = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.LBPF_7_Hdr_ID = IIf(IsDBNull(rd("LBPF_7_Hdr_ID")), 0, rd("LBPF_7_Hdr_ID"))
                    Me.Budget_Year = IIf(IsDBNull(rd("Budget_Year")), "", rd("Budget_Year"))
                    Me.sig1 = IIf(IsDBNull(rd("sig1")), "", rd("sig1"))
                    Me.sig2 = IIf(IsDBNull(rd("sig2")), "", rd("sig2"))
                    Me.sig3 = IIf(IsDBNull(rd("sig3")), "", rd("sig3"))
                    Me.sig4 = IIf(IsDBNull(rd("sig4")), "", rd("sig4"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub updateHdr()
            Me.cmd.Parameters.AddWithValue("@LBPF_7_Hdr_ID", pLBPF_7_Hdr_ID)
            Me.cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            Me.cmd.Parameters.AddWithValue("@sig1", psig1)
            Me.cmd.Parameters.AddWithValue("@sig2", psig2)
            Me.cmd.Parameters.AddWithValue("@sig3", psig3)
            Me.cmd.Parameters.AddWithValue("@sig4", psig4)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            Execute("@CurrID", "[GeoBOS].BOS.spSave_LBPF_7_Hdr", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub saveHdr()
            Me.cmd.Parameters.AddWithValue("@LBPF_7_Hdr_ID", 0)
            Me.cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            Me.cmd.Parameters.AddWithValue("@sig1", psig1)
            Me.cmd.Parameters.AddWithValue("@sig2", psig2)
            Me.cmd.Parameters.AddWithValue("@sig3", psig3)
            Me.cmd.Parameters.AddWithValue("@sig4", psig4)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            Execute("[GeoBOS].BOS.spSave_LBPF_7_Hdr", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "LBPF_7_Dtl"
    Public Class LBPF_7_Dtl
        Inherits bBaseDAL

        Private pLBPF_7_Dtl_ID As Long
        Public Property LBPF_7_Dtl_ID() As Long
            Get
                Return pLBPF_7_Dtl_ID
            End Get
            Set(ByVal value As Long)
                pLBPF_7_Dtl_ID = value
            End Set
        End Property

        Private pLBPF_7_Hdr_ID As Long
        Public Property LBPF_7_Hdr_ID() As Long
            Get
                Return pLBPF_7_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pLBPF_7_Hdr_ID = value
            End Set
        End Property

        Private psco_id As Long
        Public Property sco_id() As Long
            Get
                Return psco_id
            End Get
            Set(ByVal value As Long)
                psco_id = value
            End Set
        End Property

        Private pbr_id As Long
        Public Property br_id() As Long
            Get
                Return pbr_id
            End Get
            Set(ByVal value As Long)
                pbr_id = value
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

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.LBPF_7_Dtl_ID = IIf(IsDBNull(rd("LBPF_7_Dtl_ID")), 0, rd("LBPF_7_Dtl_ID"))
                    Me.LBPF_7_Hdr_ID = IIf(IsDBNull(rd("LBPF_7_Hdr_ID")), 0, rd("LBPF_7_Hdr_ID"))
                    Me.sco_id = IIf(IsDBNull(rd("sco_id")), 0, rd("sco_id"))
                    Me.br_id = IIf(IsDBNull(rd("br_id")), 0, rd("br_id"))
                    Me.Amount = IIf(IsDBNull(rd("Amount")), 0.0, rd("Amount"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub updateHdr()
            Me.cmd.Parameters.AddWithValue("@LBPF_7_Dtl_ID", pLBPF_7_Dtl_ID)
            Me.cmd.Parameters.AddWithValue("@LBPF_7_Hdr_ID", pLBPF_7_Hdr_ID)
            Me.cmd.Parameters.AddWithValue("@sco_id", psco_id)
            Me.cmd.Parameters.AddWithValue("@br_id", br_id)
            Me.cmd.Parameters.AddWithValue("@Amount", pAmount)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            Execute("@CurrID", "[GeoBOS].BOS.spSave_LBPF_7_Dtl", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub saveHdr()
            Me.cmd.Parameters.AddWithValue("@LBPF_7_Dtl_ID", 0)
            Me.cmd.Parameters.AddWithValue("@LBPF_7_Hdr_ID", pLBPF_7_Hdr_ID)
            Me.cmd.Parameters.AddWithValue("@sco_id", psco_id)
            Me.cmd.Parameters.AddWithValue("@br_id", br_id)
            Me.cmd.Parameters.AddWithValue("@Amount", pAmount)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            Execute("[GeoBOS].BOS.spSave_LBPF_7_Dtl", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "m_SCO"
    Public Class m_SCO
        Inherits bBaseDAL

        Private psco_id As Long
        Public Property sco_id() As Long
            Get
                Return psco_id
            End Get
            Set(ByVal value As Long)
                psco_id = value
            End Set
        End Property

        Private psco_desc As String
        Public Property sco_desc() As String
            Get
                Return psco_desc
            End Get
            Set(ByVal value As String)
                psco_desc = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.cmd.Parameters.AddWithValue("@sco_id", 0)
                    Me.cmd.Parameters.AddWithValue("@sco_desc", "")
                    Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub updateHdr()
            Me.cmd.Parameters.AddWithValue("@sco_id", psco_id)
            Me.cmd.Parameters.AddWithValue("@sco_desc", psco_desc)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            Execute("@CurrID", "[GeoBOS].BOS.spSave_m_SCO", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub saveHdr()
            Me.cmd.Parameters.AddWithValue("@sco_id", 0)
            Me.cmd.Parameters.AddWithValue("@sco_desc", psco_desc)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            Execute("[GeoBOS].BOS.spSave_m_SCO", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "m_BR"
    Public Class m_BR
        Inherits bBaseDAL

        Private pbr_id As Long
        Public Property br_id() As Long
            Get
                Return pbr_id
            End Get
            Set(ByVal value As Long)
                pbr_id = value
            End Set
        End Property

        Private pbr_desc As String
        Public Property br_desc() As String
            Get
                Return pbr_desc
            End Get
            Set(ByVal value As String)
                pbr_desc = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.br_id = IIf(IsDBNull(rd("br_id")), 0, rd("br_id"))
                    Me.br_desc = IIf(IsDBNull(rd("br_desc")), "", rd("br_desc"))
                    Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub updateHdr()
            Me.cmd.Parameters.AddWithValue("@br_id", pbr_id)
            Me.cmd.Parameters.AddWithValue("@br_desc", pbr_desc)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            Execute("@CurrID", "[GeoBOS].BOS.spSave_m_BR", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub saveHdr()
            Me.cmd.Parameters.AddWithValue("@br_id", 0)
            Me.cmd.Parameters.AddWithValue("@br_desc", pbr_desc)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            Execute("[GeoBOS].BOS.spSave_m_BR", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "LBRF_1A"
    Public Class LBRF_1A
        Inherits bBaseDAL

        Private pBudgetYear As Integer
        Public Property BudgetYear() As Integer
            Get
                Return pBudgetYear
            End Get
            Set(ByVal value As Integer)
                pBudgetYear = value
            End Set
        End Property

        Private pcbA As Boolean
        Public Property cbA() As Boolean
            Get
                Return pcbA
            End Get
            Set(ByVal value As Boolean)
                pcbA = value
            End Set
        End Property

        Private pcbA1 As Boolean
        Public Property cbA1() As Boolean
            Get
                Return pcbA1
            End Get
            Set(ByVal value As Boolean)
                pcbA1 = value
            End Set
        End Property

        Private pcbB As Boolean
        Public Property cbB() As Boolean
            Get
                Return pcbB
            End Get
            Set(ByVal value As Boolean)
                pcbB = value
            End Set
        End Property

        Private pcbB1 As Boolean
        Public Property cbB1() As Boolean
            Get
                Return pcbB1
            End Get
            Set(ByVal value As Boolean)
                pcbB1 = value
            End Set
        End Property

        Private pcbC As Boolean
        Public Property cbC() As Boolean
            Get
                Return pcbC
            End Get
            Set(ByVal value As Boolean)
                pcbC = value
            End Set
        End Property

        Private pcbC1 As Boolean
        Public Property cbC1() As Boolean
            Get
                Return pcbC1
            End Get
            Set(ByVal value As Boolean)
                pcbC1 = value
            End Set
        End Property

        Private pcbC2 As Boolean
        Public Property cbC2() As Boolean
            Get
                Return pcbC2
            End Get
            Set(ByVal value As Boolean)
                pcbC2 = value
            End Set
        End Property

        Private pcbC3 As Boolean
        Public Property cbC3() As Boolean
            Get
                Return pcbC3
            End Get
            Set(ByVal value As Boolean)
                pcbC3 = value
            End Set
        End Property

        Private pcbD As Boolean
        Public Property cbD() As Boolean
            Get
                Return pcbD
            End Get
            Set(ByVal value As Boolean)
                pcbD = value
            End Set
        End Property

        Private pcbD1 As Boolean
        Public Property cbD1() As Boolean
            Get
                Return pcbD1
            End Get
            Set(ByVal value As Boolean)
                pcbD1 = value
            End Set
        End Property

        Private pcbD2 As Boolean
        Public Property cbD2() As Boolean
            Get
                Return pcbD2
            End Get
            Set(ByVal value As Boolean)
                pcbD2 = value
            End Set
        End Property

        Private pcbE As Boolean
        Public Property cbE() As Boolean
            Get
                Return pcbE
            End Get
            Set(ByVal value As Boolean)
                pcbE = value
            End Set
        End Property

        Private pcbE1 As Boolean
        Public Property cbE1() As Boolean
            Get
                Return pcbE1
            End Get
            Set(ByVal value As Boolean)
                pcbE1 = value
            End Set
        End Property

        Private pcbE2 As Boolean
        Public Property cbE2() As Boolean
            Get
                Return pcbE2
            End Get
            Set(ByVal value As Boolean)
                pcbE2 = value
            End Set
        End Property

        Private pcbF As Boolean
        Public Property cbF() As Boolean
            Get
                Return pcbF
            End Get
            Set(ByVal value As Boolean)
                pcbF = value
            End Set
        End Property

        Private pcbF1 As Boolean
        Public Property cbF1() As Boolean
            Get
                Return pcbF1
            End Get
            Set(ByVal value As Boolean)
                pcbF1 = value
            End Set
        End Property

        Private pcbF2 As Boolean
        Public Property cbF2() As Boolean
            Get
                Return pcbF2
            End Get
            Set(ByVal value As Boolean)
                pcbF2 = value
            End Set
        End Property

        Private pcbG As Boolean
        Public Property cbG() As Boolean
            Get
                Return pcbG
            End Get
            Set(ByVal value As Boolean)
                pcbG = value
            End Set
        End Property

        Private pcbG1 As Boolean
        Public Property cbG1() As Boolean
            Get
                Return pcbG1
            End Get
            Set(ByVal value As Boolean)
                pcbG1 = value
            End Set
        End Property

        Private pcbH As Boolean
        Public Property cbH() As Boolean
            Get
                Return pcbH
            End Get
            Set(ByVal value As Boolean)
                pcbH = value
            End Set
        End Property

        Private pcbH1 As Boolean
        Public Property cbH1() As Boolean
            Get
                Return pcbH1
            End Get
            Set(ByVal value As Boolean)
                pcbH1 = value
            End Set
        End Property

        Private pcbH2 As Boolean
        Public Property cbH2() As Boolean
            Get
                Return pcbH2
            End Get
            Set(ByVal value As Boolean)
                pcbH2 = value
            End Set
        End Property

        Private prem1 As String
        Public Property rem1() As String
            Get
                Return prem1
            End Get
            Set(ByVal value As String)
                prem1 = value
            End Set
        End Property

        Private prem2 As String
        Public Property rem2() As String
            Get
                Return prem2
            End Get
            Set(ByVal value As String)
                prem2 = value
            End Set
        End Property

        Private prem3 As String
        Public Property rem3() As String
            Get
                Return prem3
            End Get
            Set(ByVal value As String)
                prem3 = value
            End Set
        End Property

        Private prem4 As String
        Public Property rem4() As String
            Get
                Return prem4
            End Get
            Set(ByVal value As String)
                prem4 = value
            End Set
        End Property

        Private prem5 As String
        Public Property rem5() As String
            Get
                Return prem5
            End Get
            Set(ByVal value As String)
                prem5 = value
            End Set
        End Property

        Private prem6 As String
        Public Property rem6() As String
            Get
                Return prem6
            End Get
            Set(ByVal value As String)
                prem6 = value
            End Set
        End Property

        Private prem7 As String
        Public Property rem7() As String
            Get
                Return prem7
            End Get
            Set(ByVal value As String)
                prem7 = value
            End Set
        End Property

        Private prem8 As String
        Public Property rem8() As String
            Get
                Return prem8
            End Get
            Set(ByVal value As String)
                prem8 = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.BudgetYear = IIf(IsDBNull(rd("BudgetYear")), 0, rd("BudgetYear"))
                    Me.cbA = IIf(IsDBNull(rd("cbA")), 0, rd("cbA"))
                    Me.cbA1 = IIf(IsDBNull(rd("cbA1")), 0, rd("cbA1"))
                    Me.cbB = IIf(IsDBNull(rd("cbB")), 0, rd("cbB"))
                    Me.cbB1 = IIf(IsDBNull(rd("cbB1")), 0, rd("cbB1"))
                    Me.cbC = IIf(IsDBNull(rd("cbC")), 0, rd("cbC"))
                    Me.cbC1 = IIf(IsDBNull(rd("cbC1")), 0, rd("cbC1"))
                    Me.cbC2 = IIf(IsDBNull(rd("cbC2")), 0, rd("cbC2"))
                    Me.cbC3 = IIf(IsDBNull(rd("cbC3")), 0, rd("cbC3"))
                    Me.cbD = IIf(IsDBNull(rd("cbD")), 0, rd("cbD"))
                    Me.cbD1 = IIf(IsDBNull(rd("cbD1")), 0, rd("cbD1"))
                    Me.cbD2 = IIf(IsDBNull(rd("cbD2")), 0, rd("cbD2"))
                    Me.cbE = IIf(IsDBNull(rd("cbE")), 0, rd("cbE"))
                    Me.cbE1 = IIf(IsDBNull(rd("cbE1")), 0, rd("cbE1"))
                    Me.cbE2 = IIf(IsDBNull(rd("cbE2")), 0, rd("cbE2"))
                    Me.cbF = IIf(IsDBNull(rd("cbF")), 0, rd("cbF"))
                    Me.cbF1 = IIf(IsDBNull(rd("cbF1")), 0, rd("cbF1"))
                    Me.cbF2 = IIf(IsDBNull(rd("cbF2")), 0, rd("cbF2"))
                    Me.cbG = IIf(IsDBNull(rd("cbG")), 0, rd("cbG"))
                    Me.cbG1 = IIf(IsDBNull(rd("cbG1")), 0, rd("cbG1"))
                    Me.cbH = IIf(IsDBNull(rd("cbH")), 0, rd("cbH"))
                    Me.cbH1 = IIf(IsDBNull(rd("cbH1")), 0, rd("cbH1"))
                    Me.cbH2 = IIf(IsDBNull(rd("cbH2")), 0, rd("cbH2"))
                    Me.rem1 = IIf(IsDBNull(rd("rem1")), "", rd("rem1"))
                    Me.rem2 = IIf(IsDBNull(rd("rem2")), "", rd("rem2"))
                    Me.rem3 = IIf(IsDBNull(rd("rem3")), "", rd("rem3"))
                    Me.rem4 = IIf(IsDBNull(rd("rem4")), "", rd("rem4"))
                    Me.rem5 = IIf(IsDBNull(rd("rem5")), "", rd("rem5"))
                    Me.rem6 = IIf(IsDBNull(rd("rem6")), "", rd("rem6"))
                    Me.rem7 = IIf(IsDBNull(rd("rem7")), "", rd("rem7"))
                    Me.rem8 = IIf(IsDBNull(rd("rem8")), "", rd("rem8"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub update()
            Me.cmd.Parameters.AddWithValue("@BudgetYear", pBudgetYear)
            Me.cmd.Parameters.AddWithValue("@cbA", pcbA)
            Me.cmd.Parameters.AddWithValue("@cbA1", pcbA1)
            Me.cmd.Parameters.AddWithValue("@cbB", pcbB)
            Me.cmd.Parameters.AddWithValue("@cbB1", pcbB1)
            Me.cmd.Parameters.AddWithValue("@cbC", pcbC)
            Me.cmd.Parameters.AddWithValue("@cbC1", pcbC1)
            Me.cmd.Parameters.AddWithValue("@cbC2", pcbC2)
            Me.cmd.Parameters.AddWithValue("@cbC3", pcbC3)
            Me.cmd.Parameters.AddWithValue("@cbD", pcbD)
            Me.cmd.Parameters.AddWithValue("@cbD1", pcbD1)
            Me.cmd.Parameters.AddWithValue("@cbD2", pcbD2)
            Me.cmd.Parameters.AddWithValue("@cbE", pcbE)
            Me.cmd.Parameters.AddWithValue("@cbE1", pcbE1)
            Me.cmd.Parameters.AddWithValue("@cbE2", pcbE2)
            Me.cmd.Parameters.AddWithValue("@cbF", pcbF)
            Me.cmd.Parameters.AddWithValue("@cbF1", pcbF1)
            Me.cmd.Parameters.AddWithValue("@cbF2", pcbF2)
            Me.cmd.Parameters.AddWithValue("@cbG", pcbG)
            Me.cmd.Parameters.AddWithValue("@cbG1", pcbG1)
            Me.cmd.Parameters.AddWithValue("@cbH", pcbH)
            Me.cmd.Parameters.AddWithValue("@cbH1", pcbH1)
            Me.cmd.Parameters.AddWithValue("@cbH2", pcbH2)
            Me.cmd.Parameters.AddWithValue("@rem1", prem1)
            Me.cmd.Parameters.AddWithValue("@rem2", prem2)
            Me.cmd.Parameters.AddWithValue("@rem3", prem3)
            Me.cmd.Parameters.AddWithValue("@rem4", prem4)
            Me.cmd.Parameters.AddWithValue("@rem5", prem5)
            Me.cmd.Parameters.AddWithValue("@rem6", prem6)
            Me.cmd.Parameters.AddWithValue("@rem7", prem7)
            Me.cmd.Parameters.AddWithValue("@rem8", prem8)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            Execute("@CurrID", "[GeoBOS].BOS.spSave_LBRF_1A", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub save()
            Me.cmd.Parameters.AddWithValue("@BudgetYear", pBudgetYear)
            Me.cmd.Parameters.AddWithValue("@cbA", pcbA)
            Me.cmd.Parameters.AddWithValue("@cbA1", pcbA1)
            Me.cmd.Parameters.AddWithValue("@cbB", pcbB)
            Me.cmd.Parameters.AddWithValue("@cbB1", pcbB1)
            Me.cmd.Parameters.AddWithValue("@cbC", pcbC)
            Me.cmd.Parameters.AddWithValue("@cbC1", pcbC1)
            Me.cmd.Parameters.AddWithValue("@cbC2", pcbC2)
            Me.cmd.Parameters.AddWithValue("@cbC3", pcbC3)
            Me.cmd.Parameters.AddWithValue("@cbD", pcbD)
            Me.cmd.Parameters.AddWithValue("@cbD1", pcbD1)
            Me.cmd.Parameters.AddWithValue("@cbD2", pcbD2)
            Me.cmd.Parameters.AddWithValue("@cbE", pcbE)
            Me.cmd.Parameters.AddWithValue("@cbE1", pcbE1)
            Me.cmd.Parameters.AddWithValue("@cbE2", pcbE2)
            Me.cmd.Parameters.AddWithValue("@cbF", pcbF)
            Me.cmd.Parameters.AddWithValue("@cbF1", pcbF1)
            Me.cmd.Parameters.AddWithValue("@cbF2", pcbF2)
            Me.cmd.Parameters.AddWithValue("@cbG", pcbG)
            Me.cmd.Parameters.AddWithValue("@cbG1", pcbG1)
            Me.cmd.Parameters.AddWithValue("@cbH", pcbH)
            Me.cmd.Parameters.AddWithValue("@cbH1", pcbH1)
            Me.cmd.Parameters.AddWithValue("@cbH2", pcbH2)
            Me.cmd.Parameters.AddWithValue("@rem1", prem1)
            Me.cmd.Parameters.AddWithValue("@rem2", prem2)
            Me.cmd.Parameters.AddWithValue("@rem3", prem3)
            Me.cmd.Parameters.AddWithValue("@rem4", prem4)
            Me.cmd.Parameters.AddWithValue("@rem5", prem5)
            Me.cmd.Parameters.AddWithValue("@rem6", prem6)
            Me.cmd.Parameters.AddWithValue("@rem7", prem7)
            Me.cmd.Parameters.AddWithValue("@rem8", prem8)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            Execute("[GeoBOS].BOS.spSave_LBRF_1A", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "LBRF_1B"
    Public Class LBRF_1B
        Inherits bBaseDAL

        Private pBudgetYear As Integer
        Public Property BudgetYear() As Integer
            Get
                Return pBudgetYear
            End Get
            Set(ByVal value As Integer)
                pBudgetYear = value
            End Set
        End Property

        Private pcbA As Boolean
        Public Property cbA() As Boolean
            Get
                Return pcbA
            End Get
            Set(ByVal value As Boolean)
                pcbA = value
            End Set
        End Property

        Private pcbA1 As Boolean
        Public Property cbA1() As Boolean
            Get
                Return pcbA1
            End Get
            Set(ByVal value As Boolean)
                pcbA1 = value
            End Set
        End Property

        Private pcbB As Boolean
        Public Property cbB() As Boolean
            Get
                Return pcbB
            End Get
            Set(ByVal value As Boolean)
                pcbB = value
            End Set
        End Property

        Private pcbB1 As Boolean
        Public Property cbB1() As Boolean
            Get
                Return pcbB1
            End Get
            Set(ByVal value As Boolean)
                pcbB1 = value
            End Set
        End Property

        Private pcbC As Boolean
        Public Property cbC() As Boolean
            Get
                Return pcbC
            End Get
            Set(ByVal value As Boolean)
                pcbC = value
            End Set
        End Property

        Private pcbC1 As Boolean
        Public Property cbC1() As Boolean
            Get
                Return pcbC1
            End Get
            Set(ByVal value As Boolean)
                pcbC1 = value
            End Set
        End Property

        Private pcbC2 As Boolean
        Public Property cbC2() As Boolean
            Get
                Return pcbC2
            End Get
            Set(ByVal value As Boolean)
                pcbC2 = value
            End Set
        End Property

        Private pcbC3 As Boolean
        Public Property cbC3() As Boolean
            Get
                Return pcbC3
            End Get
            Set(ByVal value As Boolean)
                pcbC3 = value
            End Set
        End Property

        Private pcbD As Boolean
        Public Property cbD() As Boolean
            Get
                Return pcbD
            End Get
            Set(ByVal value As Boolean)
                pcbD = value
            End Set
        End Property

        Private pcbD1 As Boolean
        Public Property cbD1() As Boolean
            Get
                Return pcbD1
            End Get
            Set(ByVal value As Boolean)
                pcbD1 = value
            End Set
        End Property

        Private pcbD2 As Boolean
        Public Property cbD2() As Boolean
            Get
                Return pcbD2
            End Get
            Set(ByVal value As Boolean)
                pcbD2 = value
            End Set
        End Property

        Private pcbE As Boolean
        Public Property cbE() As Boolean
            Get
                Return pcbE
            End Get
            Set(ByVal value As Boolean)
                pcbE = value
            End Set
        End Property

        Private pcbE1 As Boolean
        Public Property cbE1() As Boolean
            Get
                Return pcbE1
            End Get
            Set(ByVal value As Boolean)
                pcbE1 = value
            End Set
        End Property

        Private pcbF As Boolean
        Public Property cbF() As Boolean
            Get
                Return pcbF
            End Get
            Set(ByVal value As Boolean)
                pcbF = value
            End Set
        End Property

        Private pcbF1 As Boolean
        Public Property cbF1() As Boolean
            Get
                Return pcbF1
            End Get
            Set(ByVal value As Boolean)
                pcbF1 = value
            End Set
        End Property

        Private pcbF2 As Boolean
        Public Property cbF2() As Boolean
            Get
                Return pcbF2
            End Get
            Set(ByVal value As Boolean)
                pcbF2 = value
            End Set
        End Property

        Private pcbF3 As Boolean
        Public Property cbF3() As Boolean
            Get
                Return pcbF3
            End Get
            Set(ByVal value As Boolean)
                pcbF3 = value
            End Set
        End Property

        Private pcbG As Boolean
        Public Property cbG() As Boolean
            Get
                Return pcbG
            End Get
            Set(ByVal value As Boolean)
                pcbG = value
            End Set
        End Property

        Private pcbG1 As Boolean
        Public Property cbG1() As Boolean
            Get
                Return pcbG1
            End Get
            Set(ByVal value As Boolean)
                pcbG1 = value
            End Set
        End Property

        Private pcbH As Boolean
        Public Property cbH() As Boolean
            Get
                Return pcbH
            End Get
            Set(ByVal value As Boolean)
                pcbH = value
            End Set
        End Property

        Private pcbH1 As Boolean
        Public Property cbH1() As Boolean
            Get
                Return pcbH1
            End Get
            Set(ByVal value As Boolean)
                pcbH1 = value
            End Set
        End Property

        Private pcbH2 As Boolean
        Public Property cbH2() As Boolean
            Get
                Return pcbH2
            End Get
            Set(ByVal value As Boolean)
                pcbH2 = value
            End Set
        End Property

        Private prem1 As String
        Public Property rem1() As String
            Get
                Return prem1
            End Get
            Set(ByVal value As String)
                prem1 = value
            End Set
        End Property

        Private prem2 As String
        Public Property rem2() As String
            Get
                Return prem2
            End Get
            Set(ByVal value As String)
                prem2 = value
            End Set
        End Property

        Private prem3 As String
        Public Property rem3() As String
            Get
                Return prem3
            End Get
            Set(ByVal value As String)
                prem3 = value
            End Set
        End Property

        Private prem4 As String
        Public Property rem4() As String
            Get
                Return prem4
            End Get
            Set(ByVal value As String)
                prem4 = value
            End Set
        End Property

        Private prem5 As String
        Public Property rem5() As String
            Get
                Return prem5
            End Get
            Set(ByVal value As String)
                prem5 = value
            End Set
        End Property

        Private prem6 As String
        Public Property rem6() As String
            Get
                Return prem6
            End Get
            Set(ByVal value As String)
                prem6 = value
            End Set
        End Property

        Private prem7 As String
        Public Property rem7() As String
            Get
                Return prem7
            End Get
            Set(ByVal value As String)
                prem7 = value
            End Set
        End Property

        Private prem8 As String
        Public Property rem8() As String
            Get
                Return prem8
            End Get
            Set(ByVal value As String)
                prem8 = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.BudgetYear = IIf(IsDBNull(rd("BudgetYear")), 0, rd("BudgetYear"))
                    Me.cbA = IIf(IsDBNull(rd("cbA")), 0, rd("cbA"))
                    Me.cbA1 = IIf(IsDBNull(rd("cbA1")), 0, rd("cbA1"))
                    Me.cbB = IIf(IsDBNull(rd("cbB")), 0, rd("cbB"))
                    Me.cbB1 = IIf(IsDBNull(rd("cbB1")), 0, rd("cbB1"))
                    Me.cbC = IIf(IsDBNull(rd("cbC")), 0, rd("cbC"))
                    Me.cbC1 = IIf(IsDBNull(rd("cbC1")), 0, rd("cbC1"))
                    Me.cbC2 = IIf(IsDBNull(rd("cbC2")), 0, rd("cbC2"))
                    Me.cbC3 = IIf(IsDBNull(rd("cbC3")), 0, rd("cbC3"))
                    Me.cbD = IIf(IsDBNull(rd("cbD")), 0, rd("cbD"))
                    Me.cbD1 = IIf(IsDBNull(rd("cbD1")), 0, rd("cbD1"))
                    Me.cbD2 = IIf(IsDBNull(rd("cbD2")), 0, rd("cbD2"))
                    Me.cbE = IIf(IsDBNull(rd("cbE")), 0, rd("cbE"))
                    Me.cbE1 = IIf(IsDBNull(rd("cbE1")), 0, rd("cbE1"))
                    Me.cbF = IIf(IsDBNull(rd("cbF")), 0, rd("cbF"))
                    Me.cbF1 = IIf(IsDBNull(rd("cbF1")), 0, rd("cbF1"))
                    Me.cbF2 = IIf(IsDBNull(rd("cbF2")), 0, rd("cbF2"))
                    Me.cbF3 = IIf(IsDBNull(rd("cbF3")), 0, rd("cbF3"))
                    Me.cbG = IIf(IsDBNull(rd("cbG")), 0, rd("cbG"))
                    Me.cbG1 = IIf(IsDBNull(rd("cbG1")), 0, rd("cbG1"))
                    Me.cbH = IIf(IsDBNull(rd("cbH")), 0, rd("cbH"))
                    Me.cbH1 = IIf(IsDBNull(rd("cbH1")), 0, rd("cbH1"))
                    Me.cbH2 = IIf(IsDBNull(rd("cbH2")), 0, rd("cbH2"))
                    Me.rem1 = IIf(IsDBNull(rd("rem1")), "", rd("rem1"))
                    Me.rem2 = IIf(IsDBNull(rd("rem2")), "", rd("rem2"))
                    Me.rem3 = IIf(IsDBNull(rd("rem3")), "", rd("rem3"))
                    Me.rem4 = IIf(IsDBNull(rd("rem4")), "", rd("rem4"))
                    Me.rem5 = IIf(IsDBNull(rd("rem5")), "", rd("rem5"))
                    Me.rem6 = IIf(IsDBNull(rd("rem6")), "", rd("rem6"))
                    Me.rem7 = IIf(IsDBNull(rd("rem7")), "", rd("rem7"))
                    Me.rem8 = IIf(IsDBNull(rd("rem8")), "", rd("rem8"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub update()
            Me.cmd.Parameters.AddWithValue("@BudgetYear", pBudgetYear)
            Me.cmd.Parameters.AddWithValue("@cbA", pcbA)
            Me.cmd.Parameters.AddWithValue("@cbA1", pcbA1)
            Me.cmd.Parameters.AddWithValue("@cbB", pcbB)
            Me.cmd.Parameters.AddWithValue("@cbB1", pcbB1)
            Me.cmd.Parameters.AddWithValue("@cbC", pcbC)
            Me.cmd.Parameters.AddWithValue("@cbC1", pcbC1)
            Me.cmd.Parameters.AddWithValue("@cbC2", pcbC2)
            Me.cmd.Parameters.AddWithValue("@cbC3", pcbC3)
            Me.cmd.Parameters.AddWithValue("@cbD", pcbD)
            Me.cmd.Parameters.AddWithValue("@cbD1", pcbD1)
            Me.cmd.Parameters.AddWithValue("@cbD2", pcbD2)
            Me.cmd.Parameters.AddWithValue("@cbE", pcbE)
            Me.cmd.Parameters.AddWithValue("@cbE1", pcbE1)
            Me.cmd.Parameters.AddWithValue("@cbF", pcbF)
            Me.cmd.Parameters.AddWithValue("@cbF1", pcbF1)
            Me.cmd.Parameters.AddWithValue("@cbF2", pcbF2)
            Me.cmd.Parameters.AddWithValue("@cbF3", pcbF3)
            Me.cmd.Parameters.AddWithValue("@cbG", pcbG)
            Me.cmd.Parameters.AddWithValue("@cbG1", pcbG1)
            Me.cmd.Parameters.AddWithValue("@cbH", pcbH)
            Me.cmd.Parameters.AddWithValue("@cbH1", pcbH1)
            Me.cmd.Parameters.AddWithValue("@cbH2", pcbH2)
            Me.cmd.Parameters.AddWithValue("@rem1", prem1)
            Me.cmd.Parameters.AddWithValue("@rem2", prem2)
            Me.cmd.Parameters.AddWithValue("@rem3", prem3)
            Me.cmd.Parameters.AddWithValue("@rem4", prem4)
            Me.cmd.Parameters.AddWithValue("@rem5", prem5)
            Me.cmd.Parameters.AddWithValue("@rem6", prem6)
            Me.cmd.Parameters.AddWithValue("@rem7", prem7)
            Me.cmd.Parameters.AddWithValue("@rem8", prem8)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            Execute("@CurrID", "[GeoBOS].BOS.spSave_LBRF_1B", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub save()
            Me.cmd.Parameters.AddWithValue("@BudgetYear", pBudgetYear)
            Me.cmd.Parameters.AddWithValue("@cbA", pcbA)
            Me.cmd.Parameters.AddWithValue("@cbA1", pcbA1)
            Me.cmd.Parameters.AddWithValue("@cbB", pcbB)
            Me.cmd.Parameters.AddWithValue("@cbB1", pcbB1)
            Me.cmd.Parameters.AddWithValue("@cbC", pcbC)
            Me.cmd.Parameters.AddWithValue("@cbC1", pcbC1)
            Me.cmd.Parameters.AddWithValue("@cbC2", pcbC2)
            Me.cmd.Parameters.AddWithValue("@cbC3", pcbC3)
            Me.cmd.Parameters.AddWithValue("@cbD", pcbD)
            Me.cmd.Parameters.AddWithValue("@cbD1", pcbD1)
            Me.cmd.Parameters.AddWithValue("@cbD2", pcbD2)
            Me.cmd.Parameters.AddWithValue("@cbE", pcbE)
            Me.cmd.Parameters.AddWithValue("@cbE1", pcbE1)
            Me.cmd.Parameters.AddWithValue("@cbF", pcbF)
            Me.cmd.Parameters.AddWithValue("@cbF1", pcbF1)
            Me.cmd.Parameters.AddWithValue("@cbF2", pcbF2)
            Me.cmd.Parameters.AddWithValue("@cbF3", pcbF3)
            Me.cmd.Parameters.AddWithValue("@cbG", pcbG)
            Me.cmd.Parameters.AddWithValue("@cbG1", pcbG1)
            Me.cmd.Parameters.AddWithValue("@cbH", pcbH)
            Me.cmd.Parameters.AddWithValue("@cbH1", pcbH1)
            Me.cmd.Parameters.AddWithValue("@cbH2", pcbH2)
            Me.cmd.Parameters.AddWithValue("@rem1", prem1)
            Me.cmd.Parameters.AddWithValue("@rem2", prem2)
            Me.cmd.Parameters.AddWithValue("@rem3", prem3)
            Me.cmd.Parameters.AddWithValue("@rem4", prem4)
            Me.cmd.Parameters.AddWithValue("@rem5", prem5)
            Me.cmd.Parameters.AddWithValue("@rem6", prem6)
            Me.cmd.Parameters.AddWithValue("@rem7", prem7)
            Me.cmd.Parameters.AddWithValue("@rem8", prem8)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            Execute("[GeoBOS].BOS.spSave_LBRF_1B", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "LBPF_3_Hdr"
    Public Class LBPF_3_Hdr
        Inherits bBaseDAL

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


        Public Overrides Sub FillEntity()
            Try
                'fill entity statements here
                With Me
                    .LBPF_3_Hdr_ID = IIf(IsDBNull(rd("LBPF_3_Hdr_ID")), 0, rd("LBPF_3_Hdr_ID"))
                    .RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
                    .Function_ID = IIf(IsDBNull(rd("Function_ID")), 0, rd("Function_ID"))
                    .Program_ID = IIf(IsDBNull(rd("Program_ID")), 0, rd("Program_ID"))
                    .Project_ID = IIf(IsDBNull(rd("Project_ID")), 0, rd("Project_ID"))
                    .AppropriationSource_ID = IIf(IsDBNull(rd("AppropriationSource_ID")), 0, rd("AppropriationSource_ID"))
                    .AdjustmentType_ID = IIf(IsDBNull(rd("AdjustmentType_ID")), 0, rd("AdjustmentType_ID"))
                    .F_ID = IIf(IsDBNull(rd("F_ID")), 0, rd("F_ID"))
                    .Budget_Year = IIf(IsDBNull(rd("Budget_Year")), "", rd("Budget_Year"))
                    .isApproved = IIf(IsDBNull(rd("isApproved")), 0, rd("isApproved"))
                    .isPosted = IIf(IsDBNull(rd("isPosted")), 0, rd("isPosted"))
                    .PreparedBy = IIf(IsDBNull(rd("PreparedBy")), 0, rd("PreparedBy"))
                    .DatePrepared = IIf(IsDBNull(rd("DatePrepared")), "", rd("DatePrepared"))
                    .ReviewedBy = IIf(IsDBNull(rd("ReviewedBy")), 0, rd("ReviewedBy"))
                    .DateReviewed = IIf(IsDBNull(rd("DateReviewed")), "", rd("DateReviewed"))
                    .ApprovedBy = IIf(IsDBNull(rd("ApprovedBy")), 0, rd("ApprovedBy"))
                    .DateApproved = IIf(IsDBNull(rd("DateApproved")), "", rd("DateApproved"))
                    .isFinal = IIf(IsDBNull(rd("isFinal")), 0, rd("isFinal"))
                    .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
                    '  .TableName = IIf(IsDBNull(rd("TableName")), "", rd("TableName"))
                End With
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub save()
            With Me
                .cmd.Parameters.AddWithValue("@LBPF_3_Hdr_ID", 0)
                .cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
                .cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
                .cmd.Parameters.AddWithValue("@Program_ID", pProgram_ID)
                .cmd.Parameters.AddWithValue("@Project_ID", pProject_ID)
                .cmd.Parameters.AddWithValue("@AppropriationSource_ID", pAppropriationSource_ID)
                .cmd.Parameters.AddWithValue("@AdjustmentType_ID", pAdjustmentType_ID)
                .cmd.Parameters.AddWithValue("@F_ID", pF_ID)
                .cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
                .cmd.Parameters.AddWithValue("@isApproved", pisApproved)
                .cmd.Parameters.AddWithValue("@isPosted", pisPosted)
                .cmd.Parameters.AddWithValue("@PreparedBy", pPreparedBy)
                .cmd.Parameters.AddWithValue("@DatePrepared", pDatePrepared)
                .cmd.Parameters.AddWithValue("@ReviewedBy", pReviewedBy)
                .cmd.Parameters.AddWithValue("@DateReviewed", pDateReviewed)
                .cmd.Parameters.AddWithValue("@ApprovedBy", pApprovedBy)
                .cmd.Parameters.AddWithValue("@DateApproved", pDateApproved)
                .cmd.Parameters.AddWithValue("isFinal", isFinal)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                ' .cmd.Parameters.AddWithValue("@TableName", pTableName)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("[GeoBOS].BOS.spSave_LBPF_3_Hdr", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub update()
            With Me
                .cmd.Parameters.AddWithValue("@LBPF_3_Hdr_ID", pLBPF_3_Hdr_ID)
                .cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
                .cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
                .cmd.Parameters.AddWithValue("@Program_ID", pProgram_ID)
                .cmd.Parameters.AddWithValue("@Project_ID", pProject_ID)
                .cmd.Parameters.AddWithValue("@AppropriationSource_ID", pAppropriationSource_ID)
                .cmd.Parameters.AddWithValue("@AdjustmentType_ID", pAdjustmentType_ID)
                .cmd.Parameters.AddWithValue("@F_ID", pF_ID)
                .cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
                .cmd.Parameters.AddWithValue("@isApproved", pisApproved)
                .cmd.Parameters.AddWithValue("@isPosted", pisPosted)
                .cmd.Parameters.AddWithValue("@PreparedBy", pPreparedBy)
                .cmd.Parameters.AddWithValue("@DatePrepared", pDatePrepared)
                .cmd.Parameters.AddWithValue("@ReviewedBy", pReviewedBy)
                .cmd.Parameters.AddWithValue("@DateReviewed", pDateReviewed)
                .cmd.Parameters.AddWithValue("@ApprovedBy", pApprovedBy)
                .cmd.Parameters.AddWithValue("@DateApproved", pDateApproved)
                .cmd.Parameters.AddWithValue("@isFinal", pisFinal)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                '  .cmd.Parameters.AddWithValue("@TableName", pTableName)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("@CurrID", "[GeoBOS].BOS.spSave_LBPF_3_Hdr", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "LBPF_3_Dtl"
    Public Class LBPF_3_Dtl
        Inherits bBaseDAL

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

        Public Overrides Sub FillEntity()
            Try
                'fill entity statements here
                With Me
                    .LBPF_3_Dtl_ID = IIf(IsDBNull(rd("LBPF_3_Dtl_ID")), 0, rd("LBPF_3_Dtl_ID"))
                    .LBPF_3_Hdr_ID = IIf(IsDBNull(rd("LBPF_3_Hdr_ID")), 0, rd("LBPF_3_Hdr_ID"))
                    .GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                    .BGA_ID = IIf(IsDBNull(rd("BGA_ID")), 0, rd("BGA_ID"))
                    .PastYear_Amount = IIf(IsDBNull(rd("PastYear_Amount")), 0.0, rd("PastYear_Amount"))
                    .CurrentYear_Amount = IIf(IsDBNull(rd("CurrentYear_Amount")), 0.0, rd("CurrentYear_Amount"))
                    .ProposedAmount = IIf(IsDBNull(rd("ProposedAmount")), 0.0, rd("ProposedAmount"))
                    .ApprovedAmount = IIf(IsDBNull(rd("ApprovedAmount")), 0.0, rd("ApprovedAmount"))
                    .AllotmentClass_ID = IIf(IsDBNull(rd("AllotmentClass_ID")), 0, rd("AllotmentClass_ID"))
                    .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
                    '  .TableName = IIf(IsDBNull(rd("TableName")), "", rd("TableName"))
                End With
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub save()
            With Me
                .cmd.Parameters.AddWithValue("@LBPF_3_Dtl_ID", 0)
                .cmd.Parameters.AddWithValue("@LBPF_3_Hdr_ID", pLBPF_3_Hdr_ID)
                .cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
                .cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
                .cmd.Parameters.AddWithValue("@PastYear_Amount", pPastYear_Amount)
                .cmd.Parameters.AddWithValue("@CurrentYear_Amount", pCurrentYear_Amount)
                .cmd.Parameters.AddWithValue("@ProposedAmount", pProposedAmount)
                .cmd.Parameters.AddWithValue("@ApprovedAmount", pApprovedAmount)
                .cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                '    .cmd.Parameters.AddWithValue("@TableName", pTableName)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("[GeoBOS].BOS.spSave_LBPF_3_Dtl", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub update()
            With Me
                .cmd.Parameters.AddWithValue("@LBPF_3_Dtl_ID", pLBPF_3_Dtl_ID)
                .cmd.Parameters.AddWithValue("@LBPF_3_Hdr_ID", pLBPF_3_Hdr_ID)
                .cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
                .cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
                .cmd.Parameters.AddWithValue("@PastYear_Amount", pPastYear_Amount)
                .cmd.Parameters.AddWithValue("@CurrentYear_Amount", pCurrentYear_Amount)
                .cmd.Parameters.AddWithValue("@ProposedAmount", pProposedAmount)
                .cmd.Parameters.AddWithValue("@ApprovedAmount", pApprovedAmount)
                .cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                '   .cmd.Parameters.AddWithValue("@TableName", pTableName)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("@CurrID", "[GeoBOS].BOS.spSave_LBPF_3_Dtl", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "m_Emp_Signatory"
    Public Class m_Emp_Signatory
        Inherits bBaseDAL

        Private pempsig_id As Long
        Public Property empsig_id() As Long
            Get
                Return pempsig_id
            End Get
            Set(ByVal value As Long)
                pempsig_id = value
            End Set
        End Property

        Private pposition_id As Long
        Public Property position_id() As Long
            Get
                Return pposition_id
            End Get
            Set(ByVal value As Long)
                pposition_id = value
            End Set
        End Property

        Private pempid As Long
        Public Property empid() As Long
            Get
                Return pempid
            End Get
            Set(ByVal value As Long)
                pempid = value
            End Set
        End Property

        Private pfull_name As String
        Public Property full_name() As String
            Get
                Return pfull_name
            End Get
            Set(ByVal value As String)
                pfull_name = value
            End Set
        End Property

        Private peffectivity_date As DateTime
        Public Property effectivity_date() As DateTime
            Get
                Return peffectivity_date
            End Get
            Set(ByVal value As DateTime)
                peffectivity_date = value
            End Set
        End Property

        Private pposition_desc As String
        Public Property position_desc() As String
            Get
                Return pposition_desc
            End Get
            Set(ByVal value As String)
                pposition_desc = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                With Me
                    .empsig_id = IIf(IsDBNull(rd("empsig_id")), 0, rd("empsig_id"))
                    .position_id = IIf(IsDBNull(rd("position_id")), 0, rd("position_id"))
                    .empid = IIf(IsDBNull(rd("empid")), 0, rd("empid"))
                    .full_name = IIf(IsDBNull(rd("full_name")), "", rd("full_name"))
                    .effectivity_date = IIf(IsDBNull(rd("effectivity_date")), "", rd("effectivity_date"))
                    .position_desc = IIf(IsDBNull(rd("position_desc")), "", rd("position_desc"))
                End With
                'fill entity statements here
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub save()
            With Me
                .cmd.Parameters.AddWithValue("@empsig_id", 0)
                .cmd.Parameters.AddWithValue("@position_id", pposition_id)
                .cmd.Parameters.AddWithValue("@empid", pempid)
                .cmd.Parameters.AddWithValue("@full_name", pfull_name)
                .cmd.Parameters.AddWithValue("@effectivity_date", peffectivity_date)
                .cmd.Parameters.AddWithValue("@position_desc", pposition_desc)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("[GeoBOS].dbo.spSave_m_Emp_Signatory", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub update()
            With Me
                .cmd.Parameters.AddWithValue("@empsig_id", pempsig_id)
                .cmd.Parameters.AddWithValue("@position_id", pposition_id)
                .cmd.Parameters.AddWithValue("@empid", pempid)
                .cmd.Parameters.AddWithValue("@full_name", pfull_name)
                .cmd.Parameters.AddWithValue("@effectivity_date", peffectivity_date)
                .cmd.Parameters.AddWithValue("@position_desc", pposition_desc)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("@CurrID", "[GeoBOS].dbo.spSave_m_Emp_Signatory", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "obr_evaluation_hdr"
    Public Class t_obr_evaluation_hdr

        Inherits bBaseDAL

        Private pobr_evaluation_hdr_id As Long
        Public Property obr_evaluation_hdr_id() As Long
            Get
                Return pobr_evaluation_hdr_id
            End Get
            Set(ByVal value As Long)
                pobr_evaluation_hdr_id = value
            End Set
        End Property

        Private pmode_of_procurement_id As Integer
        Public Property mode_of_procurement_id() As Integer
            Get
                Return pmode_of_procurement_id
            End Get
            Set(ByVal value As Integer)
                pmode_of_procurement_id = value
            End Set
        End Property

        Private ptransaction_date As DateTime
        Public Property transaction_date() As DateTime
            Get
                Return ptransaction_date
            End Get
            Set(ByVal value As DateTime)
                ptransaction_date = value
            End Set
        End Property

        Private presolution_mode_of_procurement As String
        Public Property resolution_mode_of_procurement() As String
            Get
                Return presolution_mode_of_procurement
            End Get
            Set(ByVal value As String)
                presolution_mode_of_procurement = value
            End Set
        End Property

        Private pwithPreProcurement As Boolean
        Public Property withPreProcurement() As Boolean
            Get
                Return pwithPreProcurement
            End Get
            Set(ByVal value As Boolean)
                pwithPreProcurement = value
            End Set
        End Property

        Private pdatePreProcurement As DateTime
        Public Property datePreProcurement() As DateTime
            Get
                Return pdatePreProcurement
            End Get
            Set(ByVal value As DateTime)
                pdatePreProcurement = value
            End Set
        End Property
        Private pvenue As String
        Public Property venue() As String
            Get
                Return pvenue
            End Get
            Set(ByVal value As String)
                pvenue = value
            End Set
        End Property
        Private pisbyLot As Boolean
        Public Property isbyLot() As Boolean
            Get
                Return pisbyLot
            End Get
            Set(ByVal value As Boolean)
                pisbyLot = value
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


        Public Overrides Sub FillEntity()

        End Sub

        Public Function save() As Long

            Dim i As Long
            cmd.Parameters.AddWithValue("@obr_evaluation_hdr_id", 0)
            cmd.Parameters.AddWithValue("@mode_of_procurement_id", mode_of_procurement_id)
            cmd.Parameters.AddWithValue("@transaction_date", transaction_date)
            cmd.Parameters.AddWithValue("@resolution_mode_of_procurement", resolution_mode_of_procurement)
            cmd.Parameters.AddWithValue("@withPreProcurement", withPreProcurement)
            cmd.Parameters.AddWithValue("@datePreProcurement", datePreProcurement)
            'objDerived.cmd.Parameters.AddWithValue("@venue", venue)
            cmd.Parameters.AddWithValue("@isbyLot", isbyLot)
            cmd.Parameters.AddWithValue("@F_ID", F_ID)
            cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = Execute("@CurrID", "geofmssms.AMS.spSave_obr_evaluation_hdr", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class


#End Region

#Region "obr_evaluation_dtl"
    Public Class t_obr_evaluation_dtl
        Inherits bBaseDAL

        Private pobr_evaluation_dtl_id As Long
        Public Property obr_evaluation_dtl_id() As Long
            Get
                Return pobr_evaluation_dtl_id
            End Get
            Set(ByVal value As Long)
                pobr_evaluation_dtl_id = value
            End Set
        End Property

        Private pobr_evaluation_hdr_id As Long
        Public Property obr_evaluation_hdr_id() As Long
            Get
                Return pobr_evaluation_hdr_id
            End Get
            Set(ByVal value As Long)
                pobr_evaluation_hdr_id = value
            End Set
        End Property

        Private pwithPreProcurement As Boolean
        Public Property withPreProcurement() As Boolean
            Get
                Return pwithPreProcurement
            End Get
            Set(ByVal value As Boolean)
                pwithPreProcurement = value
            End Set
        End Property

        Private pprhdr_id As Long
        Public Property prhdr_id() As Long
            Get
                Return pprhdr_id
            End Get
            Set(ByVal value As Long)
                pprhdr_id = value
            End Set
        End Property


        Public Overrides Sub FillEntity()

        End Sub


        Public Function save() As Long

            Dim i As Long
            cmd.Parameters.AddWithValue("@obr_evaluation_dtl_id", 0)
            cmd.Parameters.AddWithValue("@obr_evaluation_hdr_id", obr_evaluation_hdr_id)
            cmd.Parameters.AddWithValue("@withPreProcurement", withPreProcurement)
            cmd.Parameters.AddWithValue("@prhdr_id", prhdr_id)
            cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = Execute("@CurrID", "geofmssms.AMS.spSave_obr_evaluation_dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class

#End Region

#Region "LBEF_2_Hdr"
    Public Class LBEF_2_Hdr
        Inherits bBaseDAL

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

        Public Overrides Sub FillEntity()
            Try
                'fill entity statements here
                With Me
                    .LBEF_2_Hdr_ID = IIf(IsDBNull(rd("LBEF_2_Hdr_ID")), 0, rd("LBEF_2_Hdr_ID"))
                    .ARO_No = IIf(IsDBNull(rd("ARO_No")), "", rd("ARO_No"))
                    .Budget_Year = IIf(IsDBNull(rd("Budget_Year")), "", rd("Budget_Year"))
                    .AppropriationSource_ID = IIf(IsDBNull(rd("AppropriationSource_ID")), 0, rd("AppropriationSource_ID"))
                    .AllotmentType_ID = IIf(IsDBNull(rd("AllotmentType_ID")), 0, rd("AllotmentType_ID"))
                    .Quarter = IIf(IsDBNull(rd("Quarter")), 0, rd("Quarter"))
                    .F_ID = IIf(IsDBNull(rd("F_ID")), 0, rd("F_ID"))
                    .RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
                    .Function_ID = IIf(IsDBNull(rd("Function_ID")), 0, rd("Function_ID"))
                    .Program_ID = IIf(IsDBNull(rd("Program_ID")), 0, rd("Program_ID"))
                    .Project_ID = IIf(IsDBNull(rd("Project_ID")), 0, rd("Project_ID"))
                    .DateIssued = IIf(IsDBNull(rd("DateIssued")), "", rd("DateIssued"))
                    .Purpose = IIf(IsDBNull(rd("Purpose")), "", rd("Purpose"))
                    .TotalAmount = IIf(IsDBNull(rd("TotalAmount")), 0.0, rd("TotalAmount"))
                    .AmountInWords = IIf(IsDBNull(rd("AmountInWords")), "", rd("AmountInWords"))
                    .Notes = IIf(IsDBNull(rd("Notes")), "", rd("Notes"))
                    .Signatory1_ID = IIf(IsDBNull(rd("Signatory1_ID")), 0, rd("Signatory1_ID"))
                    .DateSigned = IIf(IsDBNull(rd("DateSigned")), "", rd("DateSigned"))
                End With
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub save()
            With Me
                .cmd.Parameters.AddWithValue("@LBEF_2_Hdr_ID", 0)
                .cmd.Parameters.AddWithValue("@ARO_No", pARO_No)
                .cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
                .cmd.Parameters.AddWithValue("@AppropriationSource_ID", pAppropriationSource_ID)
                .cmd.Parameters.AddWithValue("@AllotmentType_ID", pAllotmentType_ID)
                .cmd.Parameters.AddWithValue("@Quarter", pQuarter)
                .cmd.Parameters.AddWithValue("@F_ID", pF_ID)
                .cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
                .cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
                .cmd.Parameters.AddWithValue("@Program_ID", pProgram_ID)
                .cmd.Parameters.AddWithValue("@Project_ID", pProject_ID)
                .cmd.Parameters.AddWithValue("@DateIssued", pDateIssued)
                .cmd.Parameters.AddWithValue("@Purpose", pPurpose)
                .cmd.Parameters.AddWithValue("@TotalAmount", pTotalAmount)
                .cmd.Parameters.AddWithValue("@AmountInWords", pAmountInWords)
                .cmd.Parameters.AddWithValue("@Notes", pNotes)
                .cmd.Parameters.AddWithValue("@Signatory1_ID", pSignatory1_ID)
                .cmd.Parameters.AddWithValue("@DateSigned", pDateSigned)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("[GeoBOS].BOS.spSave_LBEF_2_Hdr", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub update()
            With Me
                .cmd.Parameters.AddWithValue("@LBEF_2_Hdr_ID", pLBEF_2_Hdr_ID)
                .cmd.Parameters.AddWithValue("@ARO_No", pARO_No)
                .cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
                .cmd.Parameters.AddWithValue("@AppropriationSource_ID", pAppropriationSource_ID)
                .cmd.Parameters.AddWithValue("@AllotmentType_ID", pAllotmentType_ID)
                .cmd.Parameters.AddWithValue("@Quarter", pQuarter)
                .cmd.Parameters.AddWithValue("@F_ID", pF_ID)
                .cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
                .cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
                .cmd.Parameters.AddWithValue("@Program_ID", pProgram_ID)
                .cmd.Parameters.AddWithValue("@Project_ID", pProject_ID)
                .cmd.Parameters.AddWithValue("@DateIssued", pDateIssued)
                .cmd.Parameters.AddWithValue("@Purpose", pPurpose)
                .cmd.Parameters.AddWithValue("@TotalAmount", pTotalAmount)
                .cmd.Parameters.AddWithValue("@AmountInWords", pAmountInWords)
                .cmd.Parameters.AddWithValue("@Notes", pNotes)
                .cmd.Parameters.AddWithValue("@Signatory1_ID", pSignatory1_ID)
                .cmd.Parameters.AddWithValue("@DateSigned", pDateSigned)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("@CurrID", "[GeoBOS].BOS.spSave_LBEF_2_Hdr", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "LBEF_2_Dtl"
    Public Class LBEF_2_Dtl
        Inherits bBaseDAL

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

        Public Overrides Sub FillEntity()
            Try
                'fill entity statements here
                With Me
                    .LBEF_2_Dtl_ID = IIf(IsDBNull(rd("LBEF_2_Dtl_ID")), 0, rd("LBEF_2_Dtl_ID"))
                    .LBEF_2_Hdr_ID = IIf(IsDBNull(rd("LBEF_2_Hdr_ID")), 0, rd("LBEF_2_Hdr_ID"))
                    .GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                    .BGA_ID = IIf(IsDBNull(rd("BGA_ID")), 0, rd("BGA_ID"))
                    .AllotmentClass_ID = IIf(IsDBNull(rd("AllotmentClass_ID")), 0, rd("AllotmentClass_ID"))
                    .Amount = IIf(IsDBNull(rd("Amount")), 0.0, rd("Amount"))
                End With
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub save()
            With Me
                .cmd.Parameters.AddWithValue("@LBEF_2_Dtl_ID", 0)
                .cmd.Parameters.AddWithValue("@LBEF_2_Hdr_ID", pLBEF_2_Hdr_ID)
                .cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
                .cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
                .cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
                .cmd.Parameters.AddWithValue("@Amount", pAmount)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("[GeoBOS].BOS.spSave_LBEF_2_Dtl", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub update()
            With Me
                .cmd.Parameters.AddWithValue("@LBEF_2_Dtl_ID", pLBEF_2_Dtl_ID)
                .cmd.Parameters.AddWithValue("@LBEF_2_Hdr_ID", pLBEF_2_Hdr_ID)
                .cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
                .cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
                .cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
                .cmd.Parameters.AddWithValue("@Amount", pAmount)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("@CurrID", "[GeoBOS].BOS.spSave_LBEF_2_Dtl", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "AIP_Records"
    Public Class AIP_Records
        Inherits bBaseDAL

        Private pAIP_ID As Long
        Public Property AIP_ID() As Long
            Get
                Return pAIP_ID
            End Get
            Set(ByVal value As Long)
                pAIP_ID = value
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

        Private pisFinal As Boolean
        Public Property isFinal() As Boolean
            Get
                Return pisFinal
            End Get
            Set(ByVal value As Boolean)
                pisFinal = value
            End Set
        End Property

        Private pPreparedByID As Long
        Public Property PreparedByID() As Long
            Get
                Return pPreparedByID
            End Get
            Set(ByVal value As Long)
                pPreparedByID = value
            End Set
        End Property

        Private pReviewedByID As Long
        Public Property ReviewedByID() As Long
            Get
                Return pReviewedByID
            End Get
            Set(ByVal value As Long)
                pReviewedByID = value
            End Set
        End Property

        Private pApprovedByID As Long
        Public Property ApprovedByID() As Long
            Get
                Return pApprovedByID
            End Get
            Set(ByVal value As Long)
                pApprovedByID = value
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

        Private pDateReviewed As DateTime
        Public Property DateReviewed() As DateTime
            Get
                Return pDateReviewed
            End Get
            Set(ByVal value As DateTime)
                pDateReviewed = value
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

        Private pUserID As String
        Public Property UserID() As String
            Get
                Return pUserID
            End Get
            Set(ByVal value As String)
                pUserID = value
            End Set
        End Property
        Public Overrides Sub FillEntity()
            Try
                'fill entity statements here
                With Me
                    .AIP_ID = IIf(IsDBNull(rd("AIP_ID")), 0, rd("AIP_ID"))
                    .Budget_Year = IIf(IsDBNull(rd("Budget_Year")), 0, rd("Budget_Year"))
                    .isFinal = IIf(IsDBNull(rd("isFinal")), 0, rd("isFinal"))
                    .PreparedByID = IIf(IsDBNull(rd("PreparedByID")), 0, rd("PreparedByID"))
                    .ReviewedByID = IIf(IsDBNull(rd("ReviewedByID")), 0, rd("ReviewedByID"))
                    .ApprovedByID = IIf(IsDBNull(rd("ApprovedByID")), 0, rd("ApprovedByID"))
                    .DatePrepared = IIf(IsDBNull(rd("DatePrepared")), "", rd("DatePrepared"))
                    .DateReviewed = IIf(IsDBNull(rd("DateReviewed")), "", rd("DateReviewed"))
                    .DateApproved = IIf(IsDBNull(rd("DateApproved")), "", rd("DateApproved"))
                    .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
                End With
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub saveAIPRecords()
            With Me
                .cmd.Parameters.AddWithValue("@AIP_ID", 0)
                .cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
                .cmd.Parameters.AddWithValue("@isFinal", pisFinal)
                .cmd.Parameters.AddWithValue("@PreparedByID", pPreparedByID)
                .cmd.Parameters.AddWithValue("@ReviewedByID", pReviewedByID)
                .cmd.Parameters.AddWithValue("@ApprovedByID", pApprovedByID)
                .cmd.Parameters.AddWithValue("@DatePrepared", pDatePrepared)
                .cmd.Parameters.AddWithValue("@DateReviewed", pDateReviewed)
                .cmd.Parameters.AddWithValue("@DateApproved", pDateApproved)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("geobos.dbo.spSave_AIP_Records", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub updateAIPRecords()
            With Me
                .cmd.Parameters.AddWithValue("@AIP_ID", pAIP_ID)
                .cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
                .cmd.Parameters.AddWithValue("@isFinal", pisFinal)
                .cmd.Parameters.AddWithValue("@PreparedByID", pPreparedByID)
                .cmd.Parameters.AddWithValue("@ReviewedByID", pReviewedByID)
                .cmd.Parameters.AddWithValue("@ApprovedByID", pApprovedByID)
                .cmd.Parameters.AddWithValue("@DatePrepared", pDatePrepared)
                .cmd.Parameters.AddWithValue("@DateReviewed", pDateReviewed)
                .cmd.Parameters.AddWithValue("@DateApproved", pDateApproved)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("@CurrID", "geobos.dbo.spSave_AIP_Records", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "Format---Name"
    Public Class FormatName
        Inherits bBaseDAL



        Public Overrides Sub FillEntity()
            Try
                'fill entity statements here
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub save()


            Execute("[GeoBOS].dbo.spSave_b_ApprovedAppropriations_Hdr", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub update()


            Execute("@CurrID", "[GeoBOS].dbo.spSave_b_ApprovedAppropriations_Hdr", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "LastProgram"
    Public Class LastProgram
        Inherits bBaseDAL

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

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    With Me
                        .Program_ID = IIf(IsDBNull(rd("Program_ID")), 0, rd("Program_ID"))
                        .Program_Name = IIf(IsDBNull(rd("Program_Name")), "", rd("Program_Name"))
                        .Program_Code = IIf(IsDBNull(rd("Program_Code")), "", rd("Program_Code"))
                        .Sector_ID = IIf(IsDBNull(rd("Sector_ID")), 0, rd("Sector_ID"))
                        .SubSector_ID = IIf(IsDBNull(rd("SubSector_ID")), 0, rd("SubSector_ID"))
                        .F_ID = IIf(IsDBNull(rd("F_ID")), 0, rd("F_ID"))
                        .RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
                        .Function_ID = IIf(IsDBNull(rd("Function_ID")), 0, rd("Function_ID"))
                        .GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                        .ExpectedOutputs = IIf(IsDBNull(rd("ExpectedOutputs")), "", rd("ExpectedOutputs"))
                        .StartDate = IIf(IsDBNull(rd("StartDate")), "", rd("StartDate"))
                        .CompletionDate = IIf(IsDBNull(rd("CompletionDate")), "", rd("CompletionDate"))
                        .Objectives = IIf(IsDBNull(rd("Objectives")), "", rd("Objectives"))
                        .Budget_Year = IIf(IsDBNull(rd("Budget_Year")), "", rd("Budget_Year"))
                        .fundingsource_id = IIf(IsDBNull(rd("fundingsource_id")), 0, rd("fundingsource_id"))
                        .status = IIf(IsDBNull(rd("status")), "", rd("status"))
                        .PS = IIf(IsDBNull(rd("PS")), 0.0, rd("PS"))
                        .MOOE = IIf(IsDBNull(rd("MOOE")), 0.0, rd("MOOE"))
                        .CO = IIf(IsDBNull(rd("CO")), 0.0, rd("CO"))
                        .OFE = IIf(IsDBNull(rd("OFE")), 0.0, rd("OFE"))
                        .TotalCost = IIf(IsDBNull(rd("TotalCost")), 0.0, rd("TotalCost"))
                        .isGAD = IIf(IsDBNull(rd("isGAD")), 0, rd("isGAD"))
                        .TargetBeneficiaries = IIf(IsDBNull(rd("TargetBeneficiaries")), "", rd("TargetBeneficiaries"))
                        .PerformanceInd = IIf(IsDBNull(rd("PerformanceInd")), "", rd("PerformanceInd"))
                        .ProgramSeq = IIf(IsDBNull(rd("ProgramSeq")), 0, rd("ProgramSeq"))
                        .OtherOffices = IIf(IsDBNull(rd("OtherOffices")), "", rd("OtherOffices"))
                        .AIP_SubReport_ID = IIf(IsDBNull(rd("AIP_SubReport_ID")), 0, rd("AIP_SubReport_ID"))
                        .Prevprog_ID = IIf(IsDBNull(rd("prevprog_id")), 0, rd("prevprog_id"))
                        .isInfra = IIf(IsDBNull(rd("isInfra")), 0, rd("isInfra"))
                        .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
                    End With
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

    End Class
#End Region

#Region "LastProject"
    Public Class LastProject
        Inherits bBaseDAL

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

        Private pPrevproj_ID As Long
        Public Property Prevproj_ID() As Long
            Get
                Return pPrevproj_ID
            End Get
            Set(ByVal value As Long)
                pPrevproj_ID = value
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

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    With Me
                        .Project_ID = IIf(IsDBNull(rd("Project_ID")), 0, rd("Project_ID"))
                        .MajorProjID = IIf(IsDBNull(rd("MajorProjID")), 0, rd("MajorProjID"))
                        .Project_Name = IIf(IsDBNull(rd("Project_Name")), "", rd("Project_Name"))
                        .Project_Code = IIf(IsDBNull(rd("Project_Code")), "", rd("Project_Code"))
                        .Program_ID = IIf(IsDBNull(rd("Program_ID")), 0, rd("Program_ID"))
                        .RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
                        .Function_ID = IIf(IsDBNull(rd("Function_ID")), 0, rd("Function_ID"))
                        .GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                        .StartDate = IIf(IsDBNull(rd("StartDate")), "", rd("StartDate"))
                        .CompletionDate = IIf(IsDBNull(rd("CompletionDate")), "", rd("CompletionDate"))
                        .ExpectedOutputs = IIf(IsDBNull(rd("ExpectedOutputs")), "", rd("ExpectedOutputs"))
                        .TotalCost = IIf(IsDBNull(rd("TotalCost")), 0.0, rd("TotalCost"))
                        .isActivity = IIf(IsDBNull(rd("isActivity")), 0, rd("isActivity"))
                        .isProject = IIf(IsDBNull(rd("isProject")), 0, rd("isProject"))
                        .PS = IIf(IsDBNull(rd("PS")), 0.0, rd("PS"))
                        .MOOE = IIf(IsDBNull(rd("MOOE")), 0.0, rd("MOOE"))
                        .CO = IIf(IsDBNull(rd("CO")), 0.0, rd("CO"))
                        .CO = IIf(IsDBNull(rd("OFE")), 0.0, rd("OFE"))
                        .status = IIf(IsDBNull(rd("status")), "", rd("status"))
                        .Objectives = IIf(IsDBNull(rd("Objectives")), "", rd("Objectives"))
                        .ProjectSeq = IIf(IsDBNull(rd("ProjectSeq")), 0, rd("ProjectSeq"))
                        .OtherOffices = IIf(IsDBNull(rd("OtherOffices")), "", rd("OtherOffices"))
                        .Prevproj_ID = IIf(IsDBNull(rd("prevproj_id")), 0, rd("prevproj_id"))
                        .Location = IIf(IsDBNull(rd("Location")), "", rd("Location"))
                        .isSC = IIf(IsDBNull(rd("isSC")), 0, rd("isSC"))
                        .isSubmit = IIf(IsDBNull(rd("isSubmit")), 0, rd("isSubmit"))
                        .isfinal = IIf(IsDBNull(rd("isfinal")), 0, rd("isfinal"))
                        .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
                    End With
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub
    End Class
#End Region

#Region "m_StraightContract"
    Public Class m_StraightContract
        Inherits bBaseDAL

        Private pSC_ID As Long
        Public Property SC_ID() As Long
            Get
                Return pSC_ID
            End Get
            Set(ByVal value As Long)
                pSC_ID = value
            End Set
        End Property
        Private pproject_id As Long
        Public Property project_id() As Long
            Get
                Return pproject_id
            End Get
            Set(ByVal value As Long)
                pproject_id = value
            End Set
        End Property

        Private pPreparedBy As String
        Public Property PreparedBy() As String
            Get
                Return pPreparedBy
            End Get
            Set(ByVal value As String)
                pPreparedBy = value
            End Set
        End Property

        Private pRecommendedBy As String
        Public Property RecommendedBy() As String
            Get
                Return pRecommendedBy
            End Get
            Set(ByVal value As String)
                pRecommendedBy = value
            End Set
        End Property
        Private pApprovedBy As String
        Public Property ApprovedBy() As String
            Get
                Return pApprovedBy
            End Get
            Set(ByVal value As String)
                pApprovedBy = value
            End Set
        End Property
        'Private pisSubmit As Boolean
        'Public Property issubmit() As Boolean
        '    Get
        '        Return pisSubmit
        '    End Get
        '    Set(ByVal value As Boolean)
        '        pisSubmit = value
        '    End Set
        'End Property

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

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    With Me
                        .SC_ID = IIf(IsDBNull(rd("SC_ID")), 0, rd("SC_ID"))
                        .project_id = IIf(IsDBNull(rd("project_id")), 0, rd("project_id"))
                        .PreparedBy = IIf(IsDBNull(rd("PreparedBy")), "", rd("PreparedBy"))
                        .RecommendedBy = IIf(IsDBNull(rd("RecommendedBy")), "", rd("RecommendedBy"))
                        .ApprovedBy = IIf(IsDBNull(rd("ApprovedBy")), "", rd("ApprovedBy"))
                        '.issubmit = IIf(IsDBNull(rd("issubmit")), 0, rd("issubmit"))
                        .isfinal = IIf(IsDBNull(rd("isfinal")), 0, rd("isfinal"))
                        .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
                        .TableName = IIf(IsDBNull(rd("TableName")), "", rd("TableName"))
                    End With
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub saveSC()
            With Me
                .cmd.Parameters.AddWithValue("@SC_ID", 0)
                .cmd.Parameters.AddWithValue("@project_id", pproject_id)
                .cmd.Parameters.AddWithValue("@PreparedBy", pPreparedBy)
                .cmd.Parameters.AddWithValue("@RecommendedBy", pRecommendedBy)
                .cmd.Parameters.AddWithValue("@ApprovedBy", pApprovedBy)
                '.cmd.Parameters.AddWithValue("@issubmit", pisSubmit)
                .cmd.Parameters.AddWithValue("@isfinal", pisfinal)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                .cmd.Parameters.AddWithValue("@TableName", pTableName)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("[GeoBOS].dbo.spSave_m_StraightContract", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub updateSC()
            With Me
                .cmd.Parameters.AddWithValue("@SC_ID", pSC_ID)
                .cmd.Parameters.AddWithValue("@project_id", pproject_id)
                .cmd.Parameters.AddWithValue("@PreparedBy", pPreparedBy)
                .cmd.Parameters.AddWithValue("@RecommendedBy", pRecommendedBy)
                .cmd.Parameters.AddWithValue("@ApprovedBy", pApprovedBy)
                '.cmd.Parameters.AddWithValue("@issubmit", pisSubmit)
                .cmd.Parameters.AddWithValue("@isfinal", pisfinal)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                .cmd.Parameters.AddWithValue("@TableName", pTableName)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("@CurrID", "[GeoBOS].dbo.spSave_m_StraightContract", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region

#Region "m_StraightContract_Dtl"
    Public Class m_StraightContract_Dtl
        Inherits bBaseDAL

        Private pSCdtl_ID As Long
        Public Property SCdtl_ID() As Long
            Get
                Return pSCdtl_ID
            End Get
            Set(ByVal value As Long)
                pSCdtl_ID = value
            End Set
        End Property
        Private pSC_ID As Long
        Public Property SC_ID() As Long
            Get
                Return pSC_ID
            End Get
            Set(ByVal value As Long)
                pSC_ID = value
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

        Private pallotmentclass_ID As Integer
        Public Property allotmentclass_ID() As Integer
            Get
                Return pallotmentclass_ID
            End Get
            Set(ByVal value As Integer)
                pallotmentclass_ID = value
            End Set
        End Property
        Private pModeOfAcq As String
        Public Property ModeOfAcq() As String
            Get
                Return pModeOfAcq
            End Get
            Set(ByVal value As String)
                pModeOfAcq = value
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

        Private pQuarter1 As Decimal
        Public Property Quarter1() As Decimal
            Get
                Return pQuarter1
            End Get
            Set(ByVal value As Decimal)
                pQuarter1 = value
            End Set
        End Property

        Private pQuarter2 As Decimal
        Public Property Quarter2() As Decimal
            Get
                Return pQuarter2
            End Get
            Set(ByVal value As Decimal)
                pQuarter2 = value
            End Set
        End Property

        Private pQuarter3 As Decimal
        Public Property Quarter3() As Decimal
            Get
                Return pQuarter3
            End Get
            Set(ByVal value As Decimal)
                pQuarter3 = value
            End Set
        End Property
        Private pQuarter4 As Decimal
        Public Property Quarter4() As Decimal
            Get
                Return pQuarter4
            End Get
            Set(ByVal value As Decimal)
                pQuarter4 = value
            End Set
        End Property
        '---
        Private pQuarter1App As Decimal
        Public Property Quarter1App() As Decimal
            Get
                Return pQuarter1App
            End Get
            Set(ByVal value As Decimal)
                pQuarter1App = value
            End Set
        End Property

        Private pQuarter2App As Decimal
        Public Property Quarter2App() As Decimal
            Get
                Return pQuarter2App
            End Get
            Set(ByVal value As Decimal)
                pQuarter2App = value
            End Set
        End Property

        Private pQuarter3App As Decimal
        Public Property Quarter3App() As Decimal
            Get
                Return pQuarter3App
            End Get
            Set(ByVal value As Decimal)
                pQuarter3App = value
            End Set
        End Property
        Private pQuarter4App As Decimal
        Public Property Quarter4App() As Decimal
            Get
                Return pQuarter4App
            End Get
            Set(ByVal value As Decimal)
                pQuarter4App = value
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
        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    With Me
                        .SCdtl_ID = IIf(IsDBNull(rd("SCdtl_ID")), 0, rd("SCdtl_ID"))
                        .SC_ID = IIf(IsDBNull(rd("SC_ID")), 0, rd("SC_ID"))
                        .GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                        .BGA_ID = IIf(IsDBNull(rd("BGA_ID")), 0, rd("BGA_ID"))
                        .allotmentclass_ID = IIf(IsDBNull(rd("allotmentclass_ID")), 0, rd("allotmentclass_ID"))
                        .ModeOfAcq = IIf(IsDBNull(rd("ModeOfAcq")), "", rd("ModeOfAcq"))
                        .Area = IIf(IsDBNull(rd("Area")), "", rd("Area"))
                        .Unit = IIf(IsDBNull(rd("Unit")), "", rd("Unit"))
                        .Quarter1 = IIf(IsDBNull(rd("Quarter1")), 0.0, rd("Quarter1"))
                        .Quarter2 = IIf(IsDBNull(rd("Quarter2")), 0.0, rd("Quarter2"))
                        .Quarter3 = IIf(IsDBNull(rd("Quarter3")), 0.0, rd("Quarter3"))
                        .Quarter4 = IIf(IsDBNull(rd("Quarter4")), 0.0, rd("Quarter4"))
                        .Quarter1App = IIf(IsDBNull(rd("Quarter1App")), 0.0, rd("Quarter1App"))
                        .Quarter2App = IIf(IsDBNull(rd("Quarter2App")), 0.0, rd("Quarter2App"))
                        .Quarter3App = IIf(IsDBNull(rd("Quarter3App")), 0.0, rd("Quarter3App"))
                        .Quarter4App = IIf(IsDBNull(rd("Quarter4App")), 0.0, rd("Quarter4App"))
                        .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
                        .TableName = IIf(IsDBNull(rd("TableName")), "", rd("TableName"))
                    End With
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub saveSC_Dtl()
            With Me
                .cmd.Parameters.AddWithValue("SCdtl_ID", 0)
                .cmd.Parameters.AddWithValue("@SC_ID", pSC_ID)
                .cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
                .cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
                .cmd.Parameters.AddWithValue("@allotmentclass_ID", pallotmentclass_ID)
                .cmd.Parameters.AddWithValue("@ModeOfAcq", pModeOfAcq)
                .cmd.Parameters.AddWithValue("@Area", pArea)
                .cmd.Parameters.AddWithValue("@Unit", pUnit)
                .cmd.Parameters.AddWithValue("@Quarter1", pQuarter1)
                .cmd.Parameters.AddWithValue("@Quarter2", pQuarter2)
                .cmd.Parameters.AddWithValue("@Quarter3", pQuarter3)
                .cmd.Parameters.AddWithValue("@Quarter4", pQuarter4)
                .cmd.Parameters.AddWithValue("@Quarter1App", pQuarter1App)
                .cmd.Parameters.AddWithValue("@Quarter2App", pQuarter2App)
                .cmd.Parameters.AddWithValue("@Quarter3App", pQuarter3App)
                .cmd.Parameters.AddWithValue("@Quarter4App", pQuarter4App)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                .cmd.Parameters.AddWithValue("@TableName", pTableName)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("[GeoBOS].dbo.spSave_m_StraightContract_Dtl", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub updateSC_Dtl()
            With Me
                .cmd.Parameters.AddWithValue("SCdtl_ID", pSCdtl_ID)
                .cmd.Parameters.AddWithValue("@SC_ID", pSC_ID)
                .cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
                .cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
                .cmd.Parameters.AddWithValue("@allotmentclass_ID", pallotmentclass_ID)
                .cmd.Parameters.AddWithValue("@ModeOfAcq", pModeOfAcq)
                .cmd.Parameters.AddWithValue("@Area", pArea)
                .cmd.Parameters.AddWithValue("@Unit", pUnit)
                .cmd.Parameters.AddWithValue("@Quarter1", pQuarter1)
                .cmd.Parameters.AddWithValue("@Quarter2", pQuarter2)
                .cmd.Parameters.AddWithValue("@Quarter3", pQuarter3)
                .cmd.Parameters.AddWithValue("@Quarter4", pQuarter4)
                .cmd.Parameters.AddWithValue("@Quarter1App", pQuarter1App)
                .cmd.Parameters.AddWithValue("@Quarter2App", pQuarter2App)
                .cmd.Parameters.AddWithValue("@Quarter3App", pQuarter3App)
                .cmd.Parameters.AddWithValue("@Quarter4App", pQuarter4App)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                .cmd.Parameters.AddWithValue("@TableName", pTableName)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("@CurrID", "[GeoBOS].dbo.spSave_m_StraightContract_Dtl", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub updateSC_Dtlrevise()
            With Me
                .cmd.Parameters.AddWithValue("SCdtl_ID", pSCdtl_ID)
                .cmd.Parameters.AddWithValue("@SC_ID", pSC_ID)
                .cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
                .cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
                .cmd.Parameters.AddWithValue("@allotmentclass_ID", pallotmentclass_ID)
                .cmd.Parameters.AddWithValue("@ModeOfAcq", pModeOfAcq)
                .cmd.Parameters.AddWithValue("@Area", pArea)
                .cmd.Parameters.AddWithValue("@Unit", pUnit)
                .cmd.Parameters.AddWithValue("@Quarter1App", pQuarter1App)
                .cmd.Parameters.AddWithValue("@Quarter2App", pQuarter2App)
                .cmd.Parameters.AddWithValue("@Quarter3App", pQuarter3App)
                .cmd.Parameters.AddWithValue("@Quarter4App", pQuarter4App)
                .cmd.Parameters.AddWithValue("@UserID", pUserID)
                .cmd.Parameters.AddWithValue("@TableName", pTableName)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("@CurrID", "[GeoBOS].dbo.[spSave_m_StraightContract_DtlRevise]", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region
End Namespace