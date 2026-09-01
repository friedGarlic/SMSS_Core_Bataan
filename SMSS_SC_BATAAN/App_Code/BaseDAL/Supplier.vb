Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class Supplier
    Inherits BaseDLL.BaseDAL

#Region "Property"
    Private pSupplier_Id As Long
    Public Property Supplier_Id() As Long
        Get
            Return pSupplier_Id
        End Get
        Set(ByVal value As Long)
            pSupplier_Id = value
        End Set
    End Property

    Private pSuppCode As String
    Public Property SuppCode() As String
        Get
            Return pSuppCode
        End Get
        Set(ByVal value As String)
            pSuppCode = value
        End Set
    End Property

    Private pSuppName As String
    Public Property SuppName() As String
        Get
            Return pSuppName
        End Get
        Set(ByVal value As String)
            pSuppName = value
        End Set
    End Property

    Private pAddress1 As String
    Public Property Address1() As String
        Get
            Return pAddress1
        End Get
        Set(ByVal value As String)
            pAddress1 = value
        End Set
    End Property

    Private pOfficeno As String
    Public Property Officeno() As String
        Get
            Return pOfficeno
        End Get
        Set(ByVal value As String)
            pOfficeno = value
        End Set
    End Property

    Private pFaxno As String
    Public Property Faxno() As String
        Get
            Return pFaxno
        End Get
        Set(ByVal value As String)
            pFaxno = value
        End Set
    End Property

    Private pContactP As String
    Public Property ContactP() As String
        Get
            Return pContactP
        End Get
        Set(ByVal value As String)
            pContactP = value
        End Set
    End Property

    Private pTIN As String
    Public Property TIN() As String
        Get
            Return pTIN
        End Get
        Set(ByVal value As String)
            pTIN = value
        End Set
    End Property

    Private pTaxType As String
    Public Property TaxType() As String
        Get
            Return pTaxType
        End Get
        Set(ByVal value As String)
            pTaxType = value
        End Set
    End Property

    Private pAddress2 As String
    Public Property Address2() As String
        Get
            Return pAddress2
        End Get
        Set(ByVal value As String)
            pAddress2 = value
        End Set
    End Property

    Private pcontactno As String
    Public Property contactno() As String
        Get
            Return pcontactno
        End Get
        Set(ByVal value As String)
            pcontactno = value
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

    Private pUserId As Integer
    Public Property UserId() As Integer
        Get
            Return pUserId
        End Get
        Set(ByVal value As Integer)
            pUserId = value
        End Set
    End Property

    Private pAccreditationNo As String
    Public Property AccreditationNo() As String
        Get
            Return pAccreditationNo
        End Get
        Set(ByVal value As String)
            pAccreditationNo = value
        End Set
    End Property

    Private pDateAccreditation As Date
    Public Property DateAccreditation() As Date
        Get
            Return pDateAccreditation
        End Get
        Set(ByVal value As Date)
            pDateAccreditation = value
        End Set
    End Property

    Private pvalidUntil As Date
    Public Property validUntil() As Date
        Get
            Return pvalidUntil
        End Get
        Set(ByVal value As Date)
            pvalidUntil = value
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

    Private pMOA As String
    Public Property MOA() As String
        Get
            Return pMOA
        End Get
        Set(ByVal value As String)
            pMOA = value
        End Set
    End Property

    Private pProductService As String
    Public Property ProductService() As String
        Get
            Return pProductService
        End Get
        Set(ByVal value As String)
            pProductService = value
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
    Private pCEmailAdd As String
    Public Property CEmailAdd() As String
        Get
            Return pCEmailAdd
        End Get
        Set(ByVal value As String)
            pCEmailAdd = value
        End Set
    End Property

    Private pCAddress As String
    Public Property CAddress() As String
        Get
            Return pCAddress
        End Get
        Set(ByVal value As String)
            pCAddress = value
        End Set
    End Property
    Private pCMobileNum As String
    Public Property CMobileNum() As String
        Get
            Return pCMobileNum
        End Get
        Set(ByVal value As String)
            pCMobileNum = value
        End Set

    End Property

    Private pCBdate As String
    Public Property CBdate() As String
        Get
            Return pCBdate
        End Get
        Set(ByVal value As String)
            pCBdate = value
        End Set
    End Property

    Private pCFullName As String
    Public Property CFullName() As String
        Get
            Return pCFullName
        End Get
        Set(ByVal value As String)
            pCFullName = value
        End Set
    End Property
    Private pCAge As String
    Public Property CAge() As String
        Get
            Return pCAge
        End Get
        Set(ByVal value As String)
            pCAge = value
        End Set
    End Property
    Private pCGender As String
    Public Property CGender() As String
        Get
            Return pCGender
        End Get
        Set(ByVal value As String)
            pCGender = value
        End Set
    End Property
    Private pCNationality As String
    Public Property CNationality() As String
        Get
            Return pCNationality
        End Get
        Set(ByVal value As String)
            pCNationality = value
        End Set
    End Property

    Private pAttachedFile As String
    Public Property AttachedFile() As String
        Get
            Return pAttachedFile
        End Get
        Set(ByVal value As String)
            pAttachedFile = value
        End Set
    End Property

    Private pAttachedF As Byte()
    Public Property AttachedF() As Byte()
        Get
            Return pAttachedF
        End Get
        Set(ByVal value As Byte())
            pAttachedF = value
        End Set
    End Property

    Private pCPAttachedFile As String
    Public Property CPAttachedFile() As String
        Get
            Return pCPAttachedFile
        End Get
        Set(ByVal value As String)
            pCPAttachedFile = value
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

    Private pCPAttachedF As Byte()
    Public Property CPAttachedF() As Byte()
        Get
            Return pCPAttachedF
        End Get
        Set(ByVal value As Byte())
            pCPAttachedF = value
        End Set
    End Property



    Private pFullnameOwner As String
    Public Property FullnameOwner() As String
        Get
            Return pFullnameOwner
        End Get
        Set(ByVal value As String)
            pFullnameOwner = value
        End Set
    End Property

    Private pAddressOwner As String
    Public Property AddressOwner() As String
        Get
            Return pAddressOwner
        End Get
        Set(ByVal value As String)
            pAddressOwner = value
        End Set
    End Property

    Private pMobileNoOwner As String
    Public Property MobileNoOwner() As String
        Get
            Return pMobileNoOwner
        End Get
        Set(ByVal value As String)
            pMobileNoOwner = value
        End Set
    End Property

    Private pEmailAddressOwner As String
    Public Property EmailAddressOwner() As String
        Get
            Return pEmailAddressOwner
        End Get
        Set(ByVal value As String)
            pEmailAddressOwner = value
        End Set
    End Property

    Private pAttachedFileOwner As String
    Public Property AttachedFileOwner() As String
        Get
            Return pAttachedFileOwner
        End Get
        Set(ByVal value As String)
            pAttachedFileOwner = value
        End Set
    End Property


    Private pAttachedFOwner As Byte()
    Public Property AttachedFOwner() As Byte()
        Get
            Return pAttachedFOwner
        End Get
        Set(ByVal value As Byte())
            pAttachedFOwner = value
        End Set
    End Property



#End Region



    Public Sub saveSupplier()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", 0)
        ' objDerived.cmd.Parameters.AddWithValue("@SuppCode", SuppCode)
        objDerived.cmd.Parameters.AddWithValue("@SuppName", SuppName)
        objDerived.cmd.Parameters.AddWithValue("@Address1", Address1)
        objDerived.cmd.Parameters.AddWithValue("@Officeno", Officeno)
        objDerived.cmd.Parameters.AddWithValue("@Faxno", Faxno)
        objDerived.cmd.Parameters.AddWithValue("@ContactP", ContactP)
        objDerived.cmd.Parameters.AddWithValue("@TIN", TIN)
        objDerived.cmd.Parameters.AddWithValue("@TaxType", TaxType)
        objDerived.cmd.Parameters.AddWithValue("@Address2", Address2)
        objDerived.cmd.Parameters.AddWithValue("@contactno", contactno)
        objDerived.cmd.Parameters.AddWithValue("@deptid", deptid)
        objDerived.cmd.Parameters.AddWithValue("@UserId", UserId)
        objDerived.cmd.Parameters.AddWithValue("@AccreditationNo", AccreditationNo)
        objDerived.cmd.Parameters.AddWithValue("@DateAccreditation", DateAccreditation)
        objDerived.cmd.Parameters.AddWithValue("@validUntil", validUntil)
        objDerived.cmd.Parameters.AddWithValue("@ApprovedBy", ApprovedBy)
        objDerived.cmd.Parameters.AddWithValue("@MOA", MOA)
        objDerived.cmd.Parameters.AddWithValue("@ProductService", ProductService)
        objDerived.cmd.Parameters.AddWithValue("@EmailAddress", EmailAddress)
        objDerived.cmd.Parameters.AddWithValue("@CBdate", CBdate)
        objDerived.cmd.Parameters.AddWithValue("@CAge", CAge)
        objDerived.cmd.Parameters.AddWithValue("@CGender", CGender)
        objDerived.cmd.Parameters.AddWithValue("@CNationality", CNationality)
        objDerived.cmd.Parameters.AddWithValue("@AttachedFile", AttachedFile)
        objDerived.cmd.Parameters.AddWithValue("@AttachedF", AttachedF)
        objDerived.cmd.Parameters.AddWithValue("@CPAttachedFile", CPAttachedFile)
        objDerived.cmd.Parameters.AddWithValue("@CPAttachedF", CPAttachedF)

        objDerived.cmd.Parameters.AddWithValue("@FullnameOwner", FullnameOwner)
        objDerived.cmd.Parameters.AddWithValue("@AddressOwner", AddressOwner)
        objDerived.cmd.Parameters.AddWithValue("@MobileNoOwner", MobileNoOwner)
        objDerived.cmd.Parameters.AddWithValue("@EmailAddressOwner", EmailAddressOwner)
        objDerived.cmd.Parameters.AddWithValue("@AttachedFileOwner", AttachedFileOwner)
        objDerived.cmd.Parameters.AddWithValue("@AttachedFOwner", AttachedFOwner)


        objDerived.cmd.Parameters.AddWithValue("@Position", Position)

        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "spSave_Supplier", CommandType.StoredProcedure, Nothing)

    End Sub


    Public Sub saveEDITSupplier()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
        'objDerived.cmd.Parameters.AddWithValue("@SuppCode", SuppCode)
        objDerived.cmd.Parameters.AddWithValue("@SuppName", SuppName)
        objDerived.cmd.Parameters.AddWithValue("@Address1", Address1)
        objDerived.cmd.Parameters.AddWithValue("@Officeno", Officeno)
        objDerived.cmd.Parameters.AddWithValue("@Faxno", Faxno)
        objDerived.cmd.Parameters.AddWithValue("@ContactP", ContactP)
        objDerived.cmd.Parameters.AddWithValue("@TIN", TIN)
        objDerived.cmd.Parameters.AddWithValue("@TaxType", TaxType)
        objDerived.cmd.Parameters.AddWithValue("@Address2", Address2)
        objDerived.cmd.Parameters.AddWithValue("@contactno", contactno)
        objDerived.cmd.Parameters.AddWithValue("@deptid", deptid)
        objDerived.cmd.Parameters.AddWithValue("@UserId", UserId)
        objDerived.cmd.Parameters.AddWithValue("@AccreditationNo", AccreditationNo)
        objDerived.cmd.Parameters.AddWithValue("@DateAccreditation", DateAccreditation)
        objDerived.cmd.Parameters.AddWithValue("@validUntil", validUntil)
        objDerived.cmd.Parameters.AddWithValue("@ApprovedBy", ApprovedBy)
        objDerived.cmd.Parameters.AddWithValue("@MOA", MOA)
        objDerived.cmd.Parameters.AddWithValue("@ProductService", ProductService)
        objDerived.cmd.Parameters.AddWithValue("@EmailAddress", EmailAddress)
        objDerived.cmd.Parameters.AddWithValue("@CBdate", CBdate)
        objDerived.cmd.Parameters.AddWithValue("@CAge", CAge)
        objDerived.cmd.Parameters.AddWithValue("@CGender", CGender)
        objDerived.cmd.Parameters.AddWithValue("@CNationality", CNationality)
        objDerived.cmd.Parameters.AddWithValue("@AttachedFile", AttachedFile)
        objDerived.cmd.Parameters.AddWithValue("@AttachedF", AttachedF)
        objDerived.cmd.Parameters.AddWithValue("@CPAttachedFile", CPAttachedFile)
        objDerived.cmd.Parameters.AddWithValue("@CPAttachedF", CPAttachedF)

        objDerived.cmd.Parameters.AddWithValue("@FullnameOwner", FullnameOwner)
        objDerived.cmd.Parameters.AddWithValue("@AddressOwner", AddressOwner)
        objDerived.cmd.Parameters.AddWithValue("@MobileNoOwner", MobileNoOwner)
        objDerived.cmd.Parameters.AddWithValue("@EmailAddressOwner", EmailAddressOwner)
        objDerived.cmd.Parameters.AddWithValue("@AttachedFileOwner", AttachedFileOwner)
        objDerived.cmd.Parameters.AddWithValue("@AttachedFOwner", AttachedFOwner)

        objDerived.cmd.Parameters.AddWithValue("@Position", Position)

        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "spSave_Supplier", CommandType.StoredProcedure, Nothing)

    End Sub

End Class
