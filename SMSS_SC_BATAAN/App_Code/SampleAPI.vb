Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net



Public Class SampleAPI
#Region "Properties"
    Private pTotalRecords As Integer
    Public Property TotalRecords() As Integer
        Get
            Return pTotalRecords
        End Get
        Set(ByVal value As Integer)
            pTotalRecords = value
        End Set
    End Property
#End Region

End Class
Public Class SearchingViewModel

    Private pListSearching As SampleAPI
    Public Property ListSearching As SampleAPI
        Get
            Return pListSearching
        End Get

        Set(value As SampleAPI)
            pListSearching = value
        End Set
    End Property

    Private ppager As Pager
    Public Property pager As Pager
        Get
        End Get
        Set(value As Pager)
            ppager = value
        End Set
    End Property

End Class


Public Class Pager

    Private pTotalItems As Integer
    Public Property TotalItems() As Integer
        Get
        End Get
        Set(value As Integer)
            pTotalItems = value
        End Set
    End Property

    Private pCurrentPage As Integer
    Public Property CurrentPage() As Integer
        Get
        End Get
        Set(value As Integer)
            pCurrentPage = value
        End Set
    End Property

    Private pTotalPages As Integer
    Public Property TotalPages() As Integer
        Get
        End Get
        Set(value As Integer)
            pTotalPages = value
        End Set
    End Property

    Private pStartPage As Integer
    Public Property StartPage() As Integer
        Get
        End Get
        Set(value As Integer)
            pStartPage = value
        End Set
    End Property

    Private pEndPage As Integer
    Public Property EndPage() As Integer
        Get
        End Get
        Set(value As Integer)
            pEndPage = value
        End Set
    End Property

    Private pItemShowStart As Integer
    Public Property ItemShowStart() As Integer
        Get
        End Get
        Set(value As Integer)
            pItemShowStart = value
        End Set
    End Property


    Private pItemShowEnd As Integer
    Public Property ItemShowEnd() As Integer
        Get
        End Get
        Set(value As Integer)
            pItemShowEnd = value
        End Set
    End Property



    Public Sub Pager(ByVal totalItems As Integer, ByVal page As Integer?, ByVal pageSize As Integer)
        Dim _totalPages As Integer = Math.Ceiling(totalItems / pageSize)
        Dim _currentPage As Integer = 1
        If IsDBNull(page) Then
            _currentPage = 1
        Else
            _currentPage = page
        End If
        Dim _startPage As Integer = _currentPage - 5
        Dim _endPage As Integer = _currentPage + 4

        If (_startPage <= 0) Then
            _endPage -= (_startPage - 1)
            _startPage = 1
        ElseIf (_endPage > _totalPages) Then
            _endPage = _totalPages
            If (_endPage > 10) Then
                _startPage = _endPage - 9
            End If
        End If
        totalItems = totalItems
        CurrentPage = _currentPage
        pageSize = pageSize
        TotalPages = _totalPages
        StartPage = _startPage
        EndPage = _endPage

        If (totalItems = 0) Then
            ItemShowStart = 0
            ItemShowEnd = 0
        Else
            ItemShowStart = (_currentPage * 10) - 9
            If (CurrentPage = EndPage Or StartPage = EndPage) Then
                ItemShowEnd = totalItems
            Else
                If (CurrentPage <> EndPage) Then
                    ItemShowEnd = (_currentPage * 10)
                End If
            End If
        End If


    End Sub



End Class

Public Class UserInfoDTO

    Private pEmployeeUser As EmployeeUserDTO
    Public Property EmployeeUser As EmployeeUserDTO
        Get
            EmployeeUser = pEmployeeUser
        End Get
        Set(value As EmployeeUserDTO)
            pEmployeeUser = value
        End Set

    End Property


    Private pEmployeeImage As EmployeeImageDTO
    Public Property EmployeeImage As EmployeeImageDTO
        Get
            EmployeeImage = pEmployeeImage
        End Get
        Set(value As EmployeeImageDTO)
            pEmployeeImage = value
        End Set
    End Property

    Private pEmployeeInfo As refEmployeeDTO
    Public Property EmployeeInfo As refEmployeeDTO
        Get
            EmployeeInfo = pEmployeeInfo
        End Get
        Set(value As refEmployeeDTO)
            pEmployeeInfo = value
        End Set

    End Property

    Private pMemberShip As MembershipAPI
    Public Property Membership As MembershipAPI
        Get
            Membership = pMemberShip
        End Get
        Set(value As MembershipAPI)
            pMemberShip = value
        End Set

    End Property



End Class




Public Class refEmployeeDTO

    Private pEmployeeId As Integer
    Public Property EmployeeId As Integer
        Get
            EmployeeId = pEmployeeId
        End Get
        Set(value As Integer)
            pEmployeeId = value
        End Set

    End Property

    Private pEmployeeCode As String
    Public Property EmployeeCode As String
        Get
            EmployeeCode = pEmployeeCode
        End Get
        Set(value As String)
            pEmployeeCode = value
        End Set
    End Property

    Private pFirstName As String
    Public Property FirstName As String
        Get
            FirstName = pFirstName
        End Get
        Set(value As String)
            pFirstName = value
        End Set
    End Property

    Private pMiddleName As String
    Public Property MiddleName As String
        Get
            MiddleName = pMiddleName
        End Get
        Set(value As String)
            pMiddleName = value
        End Set
    End Property


    Private pLastName As String
    Public Property LastName As String
        Get
            LastName = pLastName
        End Get
        Set(value As String)
            pLastName = value
        End Set
    End Property

    Private pExtension As String
    Public Property Extension As String
        Get
            Extension = pExtension
        End Get
        Set(value As String)
            pExtension = value
        End Set
    End Property

    Private pEmployeeName As String
    Public Property EmployeeName As String
        Get
            EmployeeName = pEmployeeName
        End Get
        Set(value As String)
            pEmployeeName = value
        End Set
    End Property

    Private pProfessionId As Short
    Public Property ProfessionId As Short
        Get
            ProfessionId = pProfessionId
        End Get
        Set(value As Short)
            pProfessionId = value
        End Set
    End Property

    Private pDesignationId As Short
    Public Property DesignationId As Short
        Get
            DesignationId = pDesignationId
        End Get
        Set(value As Short)
            pDesignationId = value
        End Set
    End Property

    Private pPhysicianTypeId As Short
    Public Property PhysicianTypeId As Short
        Get
            PhysicianTypeId = pPhysicianTypeId
        End Get
        Set(value As Short)
            pPhysicianTypeId = value
        End Set
    End Property

    Private pEmploymentStatusId As Short
    Public Property EmploymentStatusId As Short
        Get
            EmploymentStatusId = pEmploymentStatusId
        End Get
        Set(value As Short)
            pEmploymentStatusId = value
        End Set
    End Property

    Private pLicenseNo As String
    Public Property LicenseNo As String
        Get
            LicenseNo = pLicenseNo
        End Get
        Set(value As String)
            pLicenseNo = value
        End Set
    End Property
    Private pEmail As String
    Public Property Email As String
        Get
            Email = pEmail
        End Get
        Set(value As String)
            pEmail = value
        End Set
    End Property
    Private pContactNo As String
    Public Property ContactNo As String
        Get
            ContactNo = pContactNo
        End Get
        Set(value As String)
            pContactNo = value
        End Set
    End Property

    Private pPosition As String
    Public Property Position As String
        Get
            Position = pPosition
        End Get
        Set(value As String)
            pPosition = value
        End Set
    End Property

    Private pDepartment As String
    Public Property Department As String
        Get
            Department = pDepartment
        End Get
        Set(value As String)
            pDepartment = value
        End Set
    End Property
    Private pDivision As String
    Public Property Division As String
        Get
            Division = pDivision
        End Get
        Set(value As String)
            pDivision = value
        End Set
    End Property



End Class

Public Class EmployeeUserDTO

    Private pEmployeeUserId As Integer
    Public Property EmployeeUserId As Integer
        Get
            EmployeeUserId = pEmployeeUserId
        End Get
        Set(value As Integer)
            pEmployeeUserId = value
        End Set
    End Property

    Private pEmployeeId As Integer
    Public Property EmployeeId As Integer
        Get
            EmployeeId = pEmployeeId
        End Get
        Set(value As Integer)
            pEmployeeId = value
        End Set
    End Property

    Private pUserId As Guid
    Public Property UserId As Guid
        Get
            UserId = pUserId
        End Get
        Set(value As Guid)
            pUserId = value
        End Set
    End Property

End Class



Public Class EmployeeImageDTO
    Private pEmpImageID As Integer
    Public Property EmpImageID As Integer
        Get
            EmpImageID = pEmpImageID
        End Get
        Set(value As Integer)
            pEmpImageID = value
        End Set
    End Property

    Private pEmpImage As Byte()
    Public Property EmpImage As String
        Get
            Return System.Text.Encoding.Unicode.GetString(pEmpImage)
        End Get
        Set(ByVal value As String)
            pEmpImage = System.Text.Encoding.Unicode.GetBytes(value)
        End Set
    End Property


    'Private mImage As Image    'Public Property EmpImage As Image    '    Get    '        Return mImage    '    End Get    '    Set(value As Image)    '        mImage = value    '    End Set
    'End Property




    Private pEmpoyeeId As Integer
    Public Property EmpoyeeId As Integer
        Get
            EmpoyeeId = pEmpoyeeId
        End Get
        Set(value As Integer)
            pEmpoyeeId = value
        End Set
    End Property

End Class


Public Class MembershipAPI

    Private pApplicationId As String
    Public Property ApplicationId As String
        Get
            ApplicationId = pApplicationId
        End Get
        Set(value As String)
            pApplicationId = value
        End Set
    End Property

    Private pComment As String
    Public Property Comment As String
        Get
            Comment = pComment
        End Get
        Set(value As String)
            pComment = value
        End Set
    End Property

    Private pCreateDate As String
    Public Property CreateDate As String
        Get
            CreateDate = pCreateDate
        End Get
        Set(value As String)
            pCreateDate = value
        End Set
    End Property

    Private pEmail As String
    Public Property Email As String
        Get
            Email = pEmail
        End Get
        Set(value As String)
            pEmail = value
        End Set
    End Property

    Private pFailedPasswordAnswerAttemptCount As String
    Public Property FailedPasswordAnswerAttemptCount As String
        Get
            FailedPasswordAnswerAttemptCount = pFailedPasswordAnswerAttemptCount
        End Get
        Set(value As String)
            pFailedPasswordAnswerAttemptCount = value
        End Set
    End Property

    Private pFailedPasswordAnswerAttemptWindowStart As String
    Public Property FailedPasswordAnswerAttemptWindowStart As String
        Get
            FailedPasswordAnswerAttemptWindowStart = pFailedPasswordAnswerAttemptWindowStart
        End Get
        Set(value As String)
            pFailedPasswordAnswerAttemptWindowStart = value
        End Set
    End Property


    Private pFailedPasswordAttemptCount As String
    Public Property FailedPasswordAttemptCount As String
        Get
            FailedPasswordAttemptCount = pFailedPasswordAttemptCount
        End Get
        Set(value As String)
            pFailedPasswordAttemptCount = value
        End Set
    End Property

    Private pFailedPasswordAttemptWindowStart As String
    Public Property FailedPasswordAttemptWindowStart As String
        Get
            FailedPasswordAttemptWindowStart = pFailedPasswordAttemptWindowStart
        End Get
        Set(value As String)
            pFailedPasswordAttemptWindowStart = value
        End Set
    End Property



    Private pIsApproved As String
    Public Property IsApproved As String
        Get
            IsApproved = pIsApproved
        End Get
        Set(value As String)
            pIsApproved = value
        End Set
    End Property


    Private pIsLockedOut As String
    Public Property IsLockedOut As String
        Get
            IsLockedOut = pIsLockedOut
        End Get
        Set(value As String)
            pIsLockedOut = value
        End Set
    End Property

    Private pLastLockoutDate As String
    Public Property LastLockoutDate As String
        Get
            LastLockoutDate = pLastLockoutDate
        End Get
        Set(value As String)
            pLastLockoutDate = value
        End Set
    End Property

    Private pLastLoginDate As String
    Public Property LastLoginDate As String
        Get
            LastLoginDate = pLastLoginDate
        End Get
        Set(value As String)
            pLastLoginDate = value
        End Set
    End Property

    Private pLastPasswordChangedDate As String
    Public Property LastPasswordChangedDate As String
        Get
            LastPasswordChangedDate = pLastPasswordChangedDate
        End Get
        Set(value As String)
            pLastPasswordChangedDate = value
        End Set
    End Property

    Private pLoweredEmail As String
    Public Property LoweredEmail As String
        Get
            LoweredEmail = pLoweredEmail
        End Get
        Set(value As String)
            pLoweredEmail = value
        End Set
    End Property


    Private pMobilePIN As String
    Public Property MobilePIN As String
        Get
            MobilePIN = pMobilePIN
        End Get
        Set(value As String)
            pMobilePIN = value
        End Set
    End Property


    Private pPassword As String
    Public Property Password As String
        Get
            Password = pPassword
        End Get
        Set(value As String)
            pPassword = value
        End Set
    End Property

    Private pPasswordAnswer As String
    Public Property PasswordAnswer As String
        Get
            PasswordAnswer = pPasswordAnswer
        End Get
        Set(value As String)
            pPasswordAnswer = value
        End Set
    End Property

    Private pPasswordFormat As String
    Public Property PasswordFormat As String
        Get
            PasswordFormat = pPasswordFormat
        End Get
        Set(value As String)
            pPasswordFormat = value
        End Set
    End Property


    Private pPasswordQuestion As String
    Public Property PasswordQuestion As String
        Get
            PasswordQuestion = pPasswordQuestion

        End Get
        Set(value As String)
            pPasswordQuestion = value
        End Set
    End Property


    Private pPasswordSalt As String
    Public Property PasswordSalt As String
        Get
            PasswordSalt = pPasswordSalt
        End Get
        Set(value As String)
            pPasswordSalt = value
        End Set
    End Property

    Private pUserId As String
    Public Property UserId As String
        Get
            UserId = pUserId
        End Get
        Set(value As String)
            pUserId = value
        End Set
    End Property


















End Class
