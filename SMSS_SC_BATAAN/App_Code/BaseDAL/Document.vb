Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class Document
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

    Private pDocument_Id As Long
    Public Property Document_Id() As Long
        Get
            Return pDocument_Id
        End Get
        Set(ByVal value As Long)
            pDocument_Id = value
        End Set
    End Property





    Private pIssuedAt_DTI As String
    Public Property IssuedAt_DTI() As String
        Get
            Return pIssuedAt_DTI
        End Get
        Set(ByVal value As String)
            pIssuedAt_DTI = value
        End Set
    End Property

    Private pDate_Issued_DTI As String
    Public Property Date_Issued_DTI() As String
        Get
            Return pDate_Issued_DTI
        End Get
        Set(ByVal value As String)
            pDate_Issued_DTI = value
        End Set
    End Property

    Private pValidity_DTI As String
    Public Property Validity_DTI() As String
        Get
            Return pValidity_DTI
        End Get
        Set(ByVal value As String)
            pValidity_DTI = value
        End Set
    End Property


    Private pIssuedAt_Tax As String
    Public Property IssuedAt_Tax() As String
        Get
            Return pIssuedAt_Tax
        End Get
        Set(ByVal value As String)
            pIssuedAt_Tax = value
        End Set
    End Property

    Private pDate_Issued_Tax As String
    Public Property Date_Issued_Tax() As String
        Get
            Return pDate_Issued_Tax
        End Get
        Set(ByVal value As String)
            pDate_Issued_Tax = value
        End Set
    End Property

    Private pValidity_Tax As String
    Public Property Validity_Tax() As String
        Get
            Return pValidity_Tax
        End Get
        Set(ByVal value As String)
            pValidity_Tax = value
        End Set
    End Property



    Private pIssuedAt_Sec As String
    Public Property IssuedAt_Sec() As String
        Get
            Return pIssuedAt_Sec
        End Get
        Set(ByVal value As String)
            pIssuedAt_Sec = value
        End Set
    End Property

    Private pDate_Issued_Sec As String
    Public Property Date_Issued_Sec() As String
        Get
            Return pDate_Issued_Sec
        End Get
        Set(ByVal value As String)
            pDate_Issued_Sec = value
        End Set
    End Property

    Private pValidity_Sec As String
    Public Property Validity_Sec() As String
        Get
            Return pValidity_Sec
        End Get
        Set(ByVal value As String)
            pValidity_Sec = value
        End Set
    End Property


    Private pIssuedAt_PG As String
    Public Property IssuedAt_PG() As String
        Get
            Return pIssuedAt_PG
        End Get
        Set(ByVal value As String)
            pIssuedAt_PG = value
        End Set
    End Property

    Private pDate_Issued_PG As String
    Public Property Date_Issued_PG() As String
        Get
            Return pDate_Issued_PG
        End Get
        Set(ByVal value As String)
            pDate_Issued_PG = value
        End Set
    End Property

    Private pValidity_PG As String
    Public Property Validity_PG() As String
        Get
            Return pValidity_PG
        End Get
        Set(ByVal value As String)
            pValidity_PG = value
        End Set
    End Property


    Private pIssuedAt_BP As String
    Public Property IssuedAt_BP() As String
        Get
            Return pIssuedAt_BP
        End Get
        Set(ByVal value As String)
            pIssuedAt_BP = value
        End Set
    End Property

    Private pDate_Issued_BP As String
    Public Property Date_Issued_BP() As String
        Get
            Return pDate_Issued_BP
        End Get
        Set(ByVal value As String)
            pDate_Issued_BP = value
        End Set
    End Property

    Private pValidity_BP As String
    Public Property Validity_BP() As String
        Get
            Return pValidity_BP
        End Get
        Set(ByVal value As String)
            pValidity_BP = value
        End Set
    End Property


    Private pIssuedAt_PCAB As String
    Public Property IssuedAt_PCAB() As String
        Get
            Return pIssuedAt_PCAB
        End Get
        Set(ByVal value As String)
            pIssuedAt_PCAB = value
        End Set
    End Property

    Private pDate_Issued_PCAB As String
    Public Property Date_Issued_PCAB() As String
        Get
            Return pDate_Issued_PCAB
        End Get
        Set(ByVal value As String)
            pDate_Issued_PCAB = value
        End Set
    End Property

    Private pValidity_PCAB As String
    Public Property Validity_PCAB() As String
        Get
            Return pValidity_PCAB
        End Get
        Set(ByVal value As String)
            pValidity_PCAB = value
        End Set
    End Property


    Private pIssuedAt_FDA As String
    Public Property IssuedAt_FDA() As String
        Get
            Return pIssuedAt_FDA
        End Get
        Set(ByVal value As String)
            pIssuedAt_FDA = value
        End Set
    End Property

    Private pDate_Issued_FDA As String
    Public Property Date_Issued_FDA() As String
        Get
            Return pDate_Issued_FDA
        End Get
        Set(ByVal value As String)
            pDate_Issued_FDA = value
        End Set
    End Property

    Private pValidity_FDA As String
    Public Property Validity_FDA() As String
        Get
            Return pValidity_FDA
        End Get
        Set(ByVal value As String)
            pValidity_FDA = value
        End Set
    End Property


    Private pDTI_No As String
    Public Property DTI_No() As String
        Get
            Return pDTI_No
        End Get
        Set(ByVal value As String)
            pDTI_No = value
        End Set
    End Property




    Private pTax_No As String
    Public Property Tax_No() As String
        Get
            Return pTax_No
        End Get
        Set(ByVal value As String)
            pTax_No = value
        End Set
    End Property

    Private pSec_no As String
    Public Property Sec_no() As String
        Get
            Return pSec_no
        End Get
        Set(ByVal value As String)
            pSec_no = value
        End Set
    End Property

    Private pPhilGEPS_no As String
    Public Property PhilGEPS_no() As String
        Get
            Return pPhilGEPS_no
        End Get
        Set(ByVal value As String)
            pPhilGEPS_no = value
        End Set
    End Property

    Private pBusinessPermit_no As String
    Public Property BusinessPermit_no() As String
        Get
            Return pBusinessPermit_no
        End Get
        Set(ByVal value As String)
            pBusinessPermit_no = value
        End Set
    End Property

    Private pPCAB_No As String
    Public Property PCAB_No() As String
        Get
            Return pPCAB_No
        End Get
        Set(ByVal value As String)
            pPCAB_No = value
        End Set
    End Property

    Private pFDA_No As String
    Public Property FDA_No() As String
        Get
            Return pFDA_No
        End Get
        Set(ByVal value As String)
            pFDA_No = value
        End Set
    End Property


#End Region



    Public Sub saveDocument()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@Document_Id", 0)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
        objDerived.cmd.Parameters.AddWithValue("@IssuedAt_DTI", IssuedAt_DTI)
        objDerived.cmd.Parameters.AddWithValue("@Date_Issued_DTI", Date_Issued_DTI)
        objDerived.cmd.Parameters.AddWithValue("@Validity_DTI", Validity_DTI)
        objDerived.cmd.Parameters.AddWithValue("@IssuedAt_Tax", IssuedAt_Tax)
        objDerived.cmd.Parameters.AddWithValue("@Date_Issued_Tax", Date_Issued_Tax)
        objDerived.cmd.Parameters.AddWithValue("@Validity_Tax", Validity_Tax)
        objDerived.cmd.Parameters.AddWithValue("@IssuedAt_Sec", IssuedAt_Sec)
        objDerived.cmd.Parameters.AddWithValue("@Date_Issued_Sec", Date_Issued_Sec)
        objDerived.cmd.Parameters.AddWithValue("@Validity_Sec", Validity_Sec)
        objDerived.cmd.Parameters.AddWithValue("@IssuedAt_PG", IssuedAt_PG)
        objDerived.cmd.Parameters.AddWithValue("@Date_Issued_PG", Date_Issued_PG)
        objDerived.cmd.Parameters.AddWithValue("@Validity_PG", Validity_PG)
        objDerived.cmd.Parameters.AddWithValue("@IssuedAt_BP", IssuedAt_BP)
        objDerived.cmd.Parameters.AddWithValue("@Date_Issued_BP", Date_Issued_BP)
        objDerived.cmd.Parameters.AddWithValue("@Validity_BP", Validity_BP)
        objDerived.cmd.Parameters.AddWithValue("@IssuedAt_PCAB", IssuedAt_PCAB)
        objDerived.cmd.Parameters.AddWithValue("@Date_Issued_PCAB", Date_Issued_PCAB)
        objDerived.cmd.Parameters.AddWithValue("@Validity_PCAB", Validity_PCAB)
        objDerived.cmd.Parameters.AddWithValue("@IssuedAt_FDA", IssuedAt_FDA)
        objDerived.cmd.Parameters.AddWithValue("@Date_Issued_FDA", Date_Issued_FDA)
        objDerived.cmd.Parameters.AddWithValue("@Validity_FDA", Validity_FDA)
        objDerived.cmd.Parameters.AddWithValue("@DTI_No", DTI_No)
        objDerived.cmd.Parameters.AddWithValue("@Tax_No", Tax_No)
        objDerived.cmd.Parameters.AddWithValue("@Sec_No", Sec_no)
        objDerived.cmd.Parameters.AddWithValue("@PhilGEPS_No", PhilGEPS_no)
        objDerived.cmd.Parameters.AddWithValue("@BusinessPermit_No", BusinessPermit_no)
        objDerived.cmd.Parameters.AddWithValue("@PCAB_No", PCAB_No)
        objDerived.cmd.Parameters.AddWithValue("@FDA_No", FDA_No)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "spSave_Documents_Details", CommandType.StoredProcedure, Nothing)

    End Sub


    Public Sub saveEDITDocument()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@Document_Id", Document_Id)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
        objDerived.cmd.Parameters.AddWithValue("@IssuedAt_DTI", IssuedAt_DTI)
        objDerived.cmd.Parameters.AddWithValue("@Date_Issued_DTI", Date_Issued_DTI)
        objDerived.cmd.Parameters.AddWithValue("@Validity_DTI", Validity_DTI)
        objDerived.cmd.Parameters.AddWithValue("@IssuedAt_Tax", IssuedAt_Tax)
        objDerived.cmd.Parameters.AddWithValue("@Date_Issued_Tax", Date_Issued_Tax)
        objDerived.cmd.Parameters.AddWithValue("@Validity_Tax", Validity_Tax)
        objDerived.cmd.Parameters.AddWithValue("@IssuedAt_Sec", IssuedAt_Sec)
        objDerived.cmd.Parameters.AddWithValue("@Date_Issued_Sec", Date_Issued_Sec)
        objDerived.cmd.Parameters.AddWithValue("@Validity_Sec", Validity_Sec)
        objDerived.cmd.Parameters.AddWithValue("@IssuedAt_PG", IssuedAt_PG)
        objDerived.cmd.Parameters.AddWithValue("@Date_Issued_PG", Date_Issued_PG)
        objDerived.cmd.Parameters.AddWithValue("@Validity_PG", Validity_PG)
        objDerived.cmd.Parameters.AddWithValue("@IssuedAt_BP", IssuedAt_BP)
        objDerived.cmd.Parameters.AddWithValue("@Date_Issued_BP", Date_Issued_BP)
        objDerived.cmd.Parameters.AddWithValue("@Validity_BP", Validity_BP)
        objDerived.cmd.Parameters.AddWithValue("@IssuedAt_PCAB", IssuedAt_PCAB)
        objDerived.cmd.Parameters.AddWithValue("@Date_Issued_PCAB", Date_Issued_PCAB)
        objDerived.cmd.Parameters.AddWithValue("@Validity_PCAB", Validity_PCAB)
        objDerived.cmd.Parameters.AddWithValue("@IssuedAt_FDA", IssuedAt_FDA)
        objDerived.cmd.Parameters.AddWithValue("@Date_Issued_FDA", Date_Issued_FDA)
        objDerived.cmd.Parameters.AddWithValue("@Validity_FDA", Validity_FDA)
        objDerived.cmd.Parameters.AddWithValue("@DTI_No", DTI_No)
        objDerived.cmd.Parameters.AddWithValue("@Tax_No", Tax_No)
        objDerived.cmd.Parameters.AddWithValue("@Sec_No", Sec_no)
        objDerived.cmd.Parameters.AddWithValue("@PhilGEPS_No", PhilGEPS_no)
        objDerived.cmd.Parameters.AddWithValue("@BusinessPermit_No", BusinessPermit_no)
        objDerived.cmd.Parameters.AddWithValue("@PCAB_No", PCAB_No)
        objDerived.cmd.Parameters.AddWithValue("@FDA_No", FDA_No)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "spSave_Documents_Details", CommandType.StoredProcedure, Nothing)

    End Sub

End Class
