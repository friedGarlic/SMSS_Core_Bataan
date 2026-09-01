Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class t_pre_procurement_hdr
    Inherits BaseDLL.BaseDAL
#Region "properties"
    Private ppre_procurement_hdr_id As Long
    Public Property pre_procurement_hdr_id() As Long
        Get
            Return ppre_procurement_hdr_id
        End Get
        Set(ByVal value As Long)
            ppre_procurement_hdr_id = value
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

    Private pobr_evaluation_hdr_id As Long
    Public Property obr_evaluation_hdr_id() As Long
        Get
            Return pobr_evaluation_hdr_id
        End Get
        Set(ByVal value As Long)
            pobr_evaluation_hdr_id = value
        End Set
    End Property

    Private pproject_duration_day As Integer
    Public Property project_duration_day() As Integer
        Get
            Return pproject_duration_day
        End Get
        Set(ByVal value As Integer)
            pproject_duration_day = value
        End Set
    End Property

    Private pproject_duration_desc As String
    Public Property project_duration_desc() As String
        Get
            Return pproject_duration_desc
        End Get
        Set(ByVal value As String)
            pproject_duration_desc = value
        End Set
    End Property

    Private pproject_location As String
    Public Property project_location() As String
        Get
            Return pproject_location
        End Get
        Set(ByVal value As String)
            pproject_location = value
        End Set
    End Property

    Private pproject_reference_no As String
    Public Property project_reference_no() As String
        Get
            Return pproject_reference_no
        End Get
        Set(ByVal value As String)
            pproject_reference_no = value
        End Set
    End Property

    Private pITB_Number As String
    Public Property ITB_Number() As String
        Get
            Return pITB_Number
        End Get
        Set(ByVal value As String)
            pITB_Number = value
        End Set
    End Property

    Private pproject_name As String
    Public Property project_name() As String
        Get
            Return pproject_name
        End Get
        Set(ByVal value As String)
            pproject_name = value
        End Set
    End Property

    Private pABC As Decimal
    Public Property ABC() As Decimal
        Get
            Return pABC
        End Get
        Set(ByVal value As Decimal)
            pABC = value
        End Set
    End Property

    Private pbid_docs As Decimal
    Public Property bid_docs() As Decimal
        Get
            Return pbid_docs
        End Get
        Set(ByVal value As Decimal)
            pbid_docs = value
        End Set
    End Property

    Private pbid_security As Decimal
    Public Property bid_security() As Decimal
        Get
            Return pbid_security
        End Get
        Set(ByVal value As Decimal)
            pbid_security = value
        End Set
    End Property

    'Private padvertisement_from As DateTime
    'Public Property advertisement_from() As DateTime
    '    Get
    '        Return padvertisement_from
    '    End Get
    '    Set(ByVal value As DateTime)
    '        padvertisement_from = value
    '    End Set
    'End Property

    'Private padvertisement_to As DateTime
    'Public Property advertisement_to() As DateTime
    '    Get
    '        Return padvertisement_to
    '    End Get
    '    Set(ByVal value As DateTime)
    '        padvertisement_to = value
    '    End Set
    'End Property

    'Private padvertisement_venue As String
    'Public Property advertisement_venue() As String
    '    Get
    '        Return padvertisement_venue
    '    End Get
    '    Set(ByVal value As String)
    '        padvertisement_venue = value
    '    End Set
    'End Property

    'Private pissuance_from As DateTime
    'Public Property issuance_from() As DateTime
    '    Get
    '        Return pissuance_from
    '    End Get
    '    Set(ByVal value As DateTime)
    '        pissuance_from = value
    '    End Set
    'End Property

    'Private pissuance_to As DateTime
    'Public Property issuance_to() As DateTime
    '    Get
    '        Return pissuance_to
    '    End Get
    '    Set(ByVal value As DateTime)
    '        pissuance_to = value
    '    End Set
    'End Property

    'Private pissuance_venue As String
    'Public Property issuance_venue() As String
    '    Get
    '        Return pissuance_venue
    '    End Get
    '    Set(ByVal value As String)
    '        pissuance_venue = value
    '    End Set
    'End Property

    'Private psubmission_deadline As DateTime
    'Public Property submission_deadline() As DateTime
    '    Get
    '        Return psubmission_deadline
    '    End Get
    '    Set(ByVal value As DateTime)
    '        psubmission_deadline = value
    '    End Set
    'End Property

    'Private psubmission_venue As String
    'Public Property submission_venue() As String
    '    Get
    '        Return psubmission_venue
    '    End Get
    '    Set(ByVal value As String)
    '        psubmission_venue = value
    '    End Set
    'End Property

    Private popening_date As DateTime
    Public Property opening_date() As DateTime
        Get
            Return popening_date
        End Get
        Set(ByVal value As DateTime)
            popening_date = value
        End Set
    End Property


    Private popening_time As String
    Public Property opening_time() As String
        Get
            Return popening_time
        End Get
        Set(ByVal value As String)
            popening_time = value
        End Set
    End Property


    Private popening_venue As String
    Public Property opening_venue() As String
        Get
            Return popening_venue
        End Get
        Set(ByVal value As String)
            popening_venue = value
        End Set
    End Property

    Private pwithBid As Boolean
    Public Property withBid() As Boolean
        Get
            Return pwithBid
        End Get
        Set(ByVal value As Boolean)
            pwithBid = value
        End Set
    End Property

    Private pwithWinner As Boolean
    Public Property withWinner() As Boolean
        Get
            Return pwithWinner
        End Get
        Set(ByVal value As Boolean)
            pwithWinner = value
        End Set
    End Property

    Private pisRebid As Boolean
    Public Property isRebid() As Boolean
        Get
            Return pisRebid
        End Get
        Set(ByVal value As Boolean)
            pisRebid = value
        End Set
    End Property

    Private pwithPO As Boolean
    Public Property withPO() As Boolean
        Get
            Return pwithPO
        End Get
        Set(ByVal value As Boolean)
            pwithPO = value
        End Set
    End Property

    Private presolution_number As String
    Public Property resolution_number() As String
        Get
            Return presolution_number
        End Get
        Set(ByVal value As String)
            presolution_number = value
        End Set
    End Property

    Private premarks As String
    Public Property remarks() As String
        Get
            Return premarks
        End Get
        Set(ByVal value As String)
            premarks = value
        End Set
    End Property

    Private pmain_id As Long
    Public Property main_id() As Long
        Get
            Return pmain_id
        End Get
        Set(ByVal value As Long)
            pmain_id = value
        End Set
    End Property

    Private pBACC As String
    Public Property BACC() As String
        Get
            Return pBACC
        End Get
        Set(ByVal value As String)
            pBACC = value
        End Set
    End Property

    Private pBACVC As String
    Public Property BACVC() As String
        Get
            Return pBACVC
        End Get
        Set(ByVal value As String)
            pBACVC = value
        End Set
    End Property

    Private pBAC1 As String
    Public Property BAC1() As String
        Get
            Return pBAC1
        End Get
        Set(ByVal value As String)
            pBAC1 = value
        End Set
    End Property

    Private pBAC2 As String
    Public Property BAC2() As String
        Get
            Return pBAC2
        End Get
        Set(ByVal value As String)
            pBAC2 = value
        End Set
    End Property

    Private pBAC3 As String
    Public Property BAC3() As String
        Get
            Return pBAC3
        End Get
        Set(ByVal value As String)
            pBAC3 = value
        End Set
    End Property

    Private pTWGH As String
    Public Property TWGH() As String
        Get
            Return pTWGH
        End Get
        Set(ByVal value As String)
            pTWGH = value
        End Set
    End Property

    Private pTWGM As String
    Public Property TWGM() As String
        Get
            Return pTWGM
        End Get
        Set(ByVal value As String)
            pTWGM = value
        End Set
    End Property

    Private pENDUSER As String
    Public Property ENDUSER() As String
        Get
            Return pENDUSER
        End Get
        Set(ByVal value As String)
            pENDUSER = value
        End Set
    End Property

    Private pRepresentative1 As String
    Public Property Representative1() As String
        Get
            Return pRepresentative1
        End Get
        Set(ByVal value As String)
            pRepresentative1 = value
        End Set
    End Property

    Private pRepresentative2 As String
    Public Property Representative2() As String
        Get
            Return pRepresentative2
        End Get
        Set(ByVal value As String)
            pRepresentative2 = value
        End Set
    End Property



    Private pTransaction_type As Integer
    Public Property Transaction_type() As Integer
        Get
            Return pTransaction_type
        End Get
        Set(ByVal value As Integer)
            pTransaction_type = value
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

    Private pdeclarationDate As DateTime
    Public Property declarationDate() As DateTime
        Get
            Return pdeclarationDate
        End Get
        Set(ByVal value As DateTime)
            pdeclarationDate = value
        End Set
    End Property

    Private presolution_number_date As DateTime
    Public Property resolution_number_date() As DateTime
        Get
            Return presolution_number_date
        End Get
        Set(ByVal value As DateTime)
            presolution_number_date = value
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

    Private pwithNOA As Boolean
    Public Property withNOA() As Boolean
        Get
            Return pwithNOA
        End Get
        Set(ByVal value As Boolean)
            pwithNOA = value
        End Set
    End Property

    Private pwithNTP As Boolean
    Public Property withNTP() As Boolean
        Get
            Return pwithNTP
        End Get
        Set(ByVal value As Boolean)
            pwithNTP = value
        End Set
    End Property

    Private pdateNOA As DateTime
    Public Property dateNOA() As DateTime
        Get
            Return pdateNOA
        End Get
        Set(ByVal value As DateTime)
            pdateNOA = value
        End Set
    End Property

    Private pdateNTP As DateTime
    Public Property dateNTP() As DateTime
        Get
            Return pdateNTP
        End Get
        Set(ByVal value As DateTime)
            pdateNTP = value
        End Set
    End Property

    Private pisPublicInfra As Boolean
    Public Property isPublicInfra() As Boolean
        Get
            Return pisPublicInfra
        End Get
        Set(ByVal value As Boolean)
            pisPublicInfra = value
        End Set
    End Property

    Private pisStraight As Boolean
    Public Property isStraight() As Boolean
        Get
            Return pisStraight
        End Get
        Set(ByVal value As Boolean)
            pisStraight = value
        End Set
    End Property

#End Region



    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@pre_procurement_hdr_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@mode_of_procurement_id", mode_of_procurement_id)
        objDerived.cmd.Parameters.AddWithValue("@obr_evaluation_hdr_id", obr_evaluation_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@project_location", project_location)
        objDerived.cmd.Parameters.AddWithValue("@project_duration_day", project_duration_day)
        objDerived.cmd.Parameters.AddWithValue("@project_duration_desc", project_duration_desc)
        objDerived.cmd.Parameters.AddWithValue("@project_reference_no", project_reference_no)
        objDerived.cmd.Parameters.AddWithValue("@ITB_Number", ITB_Number)
        objDerived.cmd.Parameters.AddWithValue("@project_name", project_name)
        objDerived.cmd.Parameters.AddWithValue("@ABC", ABC)
        objDerived.cmd.Parameters.AddWithValue("@bid_docs", bid_docs)
        objDerived.cmd.Parameters.AddWithValue("@bid_security", bid_security)
        'objDerived.cmd.Parameters.AddWithValue("@advertisement_from", "") 
        'objDerived.cmd.Parameters.AddWithValue("@advertisement_to", "")
        'objDerived.cmd.Parameters.AddWithValue("@advertisement_venue", advertisement_venue)
        'objDerived.cmd.Parameters.AddWithValue("@issuance_from", "")
        'objDerived.cmd.Parameters.AddWithValue("@issuance_to", "")
        'objDerived.cmd.Parameters.AddWithValue("@issuance_venue", issuance_venue)
        'objDerived.cmd.Parameters.AddWithValue("@submission_deadline", "")
        ' objDerived.cmd.Parameters.AddWithValue("@submission_venue", submission_venue)
        objDerived.cmd.Parameters.AddWithValue("@opening_date", opening_date)
        objDerived.cmd.Parameters.AddWithValue("@opening_time", opening_time)
        objDerived.cmd.Parameters.AddWithValue("@opening_venue", opening_venue)
        objDerived.cmd.Parameters.AddWithValue("@withBid", withBid)
        objDerived.cmd.Parameters.AddWithValue("@withWinner", withWinner)
        objDerived.cmd.Parameters.AddWithValue("@isRebid", isRebid)
        objDerived.cmd.Parameters.AddWithValue("@withPO", withPO)
        'objDerived.cmd.Parameters.AddWithValue("@resolution_number", "")
        objDerived.cmd.Parameters.AddWithValue("@remarks", remarks)
        objDerived.cmd.Parameters.AddWithValue("@main_id", main_id)
        objDerived.cmd.Parameters.AddWithValue("@BACC", BACC)
        objDerived.cmd.Parameters.AddWithValue("@BACVC", BACVC)
        objDerived.cmd.Parameters.AddWithValue("@BAC1", BAC1)
        objDerived.cmd.Parameters.AddWithValue("@BAC2", BAC2)
        objDerived.cmd.Parameters.AddWithValue("@BAC3", BAC3)
        objDerived.cmd.Parameters.AddWithValue("@TWGH", TWGH)
        objDerived.cmd.Parameters.AddWithValue("@TWGM", TWGM)
        objDerived.cmd.Parameters.AddWithValue("@ENDUSER", ENDUSER)
        'objDerived.cmd.Parameters.AddWithValue("@Representative1", Representative1)
        'objDerived.cmd.Parameters.AddWithValue("@Representative2", Representative2)
        objDerived.cmd.Parameters.AddWithValue("@Transaction_type", Transaction_type)
        objDerived.cmd.Parameters.AddWithValue("@F_ID", F_ID)
        objDerived.cmd.Parameters.AddWithValue("@declarationDate", declarationDate)
        objDerived.cmd.Parameters.AddWithValue("@resolution_number_date", resolution_number_date)
        objDerived.cmd.Parameters.AddWithValue("@transaction_date", transaction_date)
        objDerived.cmd.Parameters.AddWithValue("@withNOA", withNOA)
        objDerived.cmd.Parameters.AddWithValue("@withNTP", withNTP)
        objDerived.cmd.Parameters.AddWithValue("@dateNOA", dateNOA)
        objDerived.cmd.Parameters.AddWithValue("@dateNTP", dateNTP)
        objDerived.cmd.Parameters.AddWithValue("@isPublicInfra", isPublicInfra)
        objDerived.cmd.Parameters.AddWithValue("@isStraight", isStraight)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_pre_procurement", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function update() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@pre_procurement_hdr_id", pre_procurement_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@mode_of_procurement_id", mode_of_procurement_id)
        objDerived.cmd.Parameters.AddWithValue("@obr_evaluation_hdr_id", obr_evaluation_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@project_location", project_location)
        objDerived.cmd.Parameters.AddWithValue("@project_duration_day", project_duration_day)
        objDerived.cmd.Parameters.AddWithValue("@project_duration_desc", project_duration_desc)
        objDerived.cmd.Parameters.AddWithValue("@project_reference_no", project_reference_no)
        objDerived.cmd.Parameters.AddWithValue("@ITB_Number", ITB_Number)
        objDerived.cmd.Parameters.AddWithValue("@project_name", project_name)
        objDerived.cmd.Parameters.AddWithValue("@ABC", ABC)
        objDerived.cmd.Parameters.AddWithValue("@bid_docs", bid_docs)
        objDerived.cmd.Parameters.AddWithValue("@bid_security", bid_security)
        'objDerived.cmd.Parameters.AddWithValue("@advertisement_from", "")
        'objDerived.cmd.Parameters.AddWithValue("@advertisement_to", "")
        'objDerived.cmd.Parameters.AddWithValue("@advertisement_venue", advertisement_venue)
        'objDerived.cmd.Parameters.AddWithValue("@issuance_from", "")
        'objDerived.cmd.Parameters.AddWithValue("@issuance_to", "")
        ' objDerived.cmd.Parameters.AddWithValue("@issuance_venue", issuance_venue)
        'objDerived.cmd.Parameters.AddWithValue("@submission_deadline", "")
        'objDerived.cmd.Parameters.AddWithValue("@submission_venue", submission_venue)
        objDerived.cmd.Parameters.AddWithValue("@opening_date", opening_date)
        objDerived.cmd.Parameters.AddWithValue("@opening_time", opening_time)
        objDerived.cmd.Parameters.AddWithValue("@opening_venue", opening_venue)
        objDerived.cmd.Parameters.AddWithValue("@withBid", withBid)
        objDerived.cmd.Parameters.AddWithValue("@withWinner", withWinner)
        objDerived.cmd.Parameters.AddWithValue("@isRebid", isRebid)
        objDerived.cmd.Parameters.AddWithValue("@withPO", withPO)
        'objDerived.cmd.Parameters.AddWithValue("@resolution_number", "")
        objDerived.cmd.Parameters.AddWithValue("@remarks", remarks)
        objDerived.cmd.Parameters.AddWithValue("@main_id", main_id)
        objDerived.cmd.Parameters.AddWithValue("@BACC", BACC)
        objDerived.cmd.Parameters.AddWithValue("@BACVC", BACVC)
        objDerived.cmd.Parameters.AddWithValue("@BAC1", BAC1)
        objDerived.cmd.Parameters.AddWithValue("@BAC2", BAC2)
        objDerived.cmd.Parameters.AddWithValue("@BAC3", BAC3)
        objDerived.cmd.Parameters.AddWithValue("@TWGH", TWGH)
        objDerived.cmd.Parameters.AddWithValue("@TWGM", TWGM)
        objDerived.cmd.Parameters.AddWithValue("@ENDUSER", ENDUSER)
        'objDerived.cmd.Parameters.AddWithValue("@Representative1", Representative1)
        'objDerived.cmd.Parameters.AddWithValue("@Representative2", Representative2)
        objDerived.cmd.Parameters.AddWithValue("@Transaction_type", Transaction_type)
        objDerived.cmd.Parameters.AddWithValue("@F_ID", F_ID)
        objDerived.cmd.Parameters.AddWithValue("@declarationDate", declarationDate)
        objDerived.cmd.Parameters.AddWithValue("@resolution_number_date", resolution_number_date)
        objDerived.cmd.Parameters.AddWithValue("@transaction_date", transaction_date)
        objDerived.cmd.Parameters.AddWithValue("@withNOA", withNOA)
        objDerived.cmd.Parameters.AddWithValue("@withNTP", withNTP)
        objDerived.cmd.Parameters.AddWithValue("@dateNOA", dateNOA)
        objDerived.cmd.Parameters.AddWithValue("@dateNTP", dateNTP)
        objDerived.cmd.Parameters.AddWithValue("@isPublicInfra", isPublicInfra)
        objDerived.cmd.Parameters.AddWithValue("@isStraight", isStraight)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_pre_procurement", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
