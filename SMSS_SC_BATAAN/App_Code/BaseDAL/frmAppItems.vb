Imports System
Imports Microsoft.VisualBasic

Public Class frmAppItems
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pItem_ID As Integer
    Public Property Item_ID() As Integer
        Get
            Return pItem_ID
        End Get
        Set(ByVal value As Integer)
            pItem_ID = value
        End Set
    End Property

    Private pItem_Code As String
    Public Property Item_Code() As String
        Get
            Return pItem_Code
        End Get
        Set(ByVal value As String)
            pItem_Code = value
        End Set
    End Property

    Private pItem_Desc As String
    Public Property Item_Desc() As String
        Get
            Return pItem_Desc
        End Get
        Set(ByVal value As String)
            pItem_Desc = value
        End Set
    End Property

    Private pUnit_ID As Integer
    Public Property Unit_ID() As Integer
        Get
            Return pUnit_ID
        End Get
        Set(ByVal value As Integer)
            pUnit_ID = value
        End Set
    End Property

    Private pTA_ID As Integer
    Public Property TA_ID() As Integer
        Get
            Return pTA_ID
        End Get
        Set(ByVal value As Integer)
            pTA_ID = value
        End Set
    End Property

    Private pUseful_Life As String
    Public Property Useful_Life() As String
        Get
            Return pUseful_Life
        End Get
        Set(ByVal value As String)
            pUseful_Life = value
        End Set
    End Property

    Private pAccount_ID As Integer
    Public Property Account_ID() As Integer
        Get
            Return pAccount_ID
        End Get
        Set(ByVal value As Integer)
            pAccount_ID = value
        End Set
    End Property

    Private pClass_ID As Integer
    Public Property Class_ID() As Integer
        Get
            Return pClass_ID
        End Get
        Set(ByVal value As Integer)
            pClass_ID = value
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

    Private pEcon_life As Integer
    Public Property Econ_life() As Integer
        Get
            Return pEcon_life
        End Get
        Set(ByVal value As Integer)
            pEcon_life = value
        End Set
    End Property

    Private pPRDtl_ID As Integer
    Public Property PRDtl_ID() As Integer
        Get
            Return pPRDtl_ID
        End Get
        Set(ByVal value As Integer)
            pPRDtl_ID = value
        End Set
    End Property

    Private pGA_no As Integer
    Public Property GA_no() As Integer
        Get
            Return pGA_no
        End Get
        Set(ByVal value As Integer)
            pGA_no = value
        End Set
    End Property




#End Region
    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.cmd.Parameters.AddWithValue("@Item_ID", 0)
            Me.cmd.Parameters.AddWithValue("@Item_Code", "")
            Me.cmd.Parameters.AddWithValue("@Item_Desc", "")
            Me.cmd.Parameters.AddWithValue("@Unit_ID", 0)
            Me.cmd.Parameters.AddWithValue("@TA_ID", 0)
            Me.cmd.Parameters.AddWithValue("@Useful_Life", "")
            Me.cmd.Parameters.AddWithValue("@Account_ID", 0)
            Me.cmd.Parameters.AddWithValue("@Class_ID", 0)
            Me.cmd.Parameters.AddWithValue("@Status", "")
            Me.cmd.Parameters.AddWithValue("@Econ_life", 0)
            Me.cmd.Parameters.AddWithValue("@PRDtl_ID", 0)
            Me.cmd.Parameters.AddWithValue("@GA_no", "")


        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    'Public Sub savePayrollInfo()
    '    Dim objDerived As New DerivedDal
    '    conStr = objDerived.DbaseConnect

    '    cmd.Parameters.AddWithValue("@empid", empid)
    '    cmd.Parameters.AddWithValue("@empstat_key", empstat_key)
    '    cmd.Parameters.AddWithValue("@empclass_key", empclass_key)
    '    cmd.Parameters.AddWithValue("@emptimetype_key", emptimetype_key)
    '    cmd.Parameters.AddWithValue("@job_grade_key", job_grade_key)
    '    cmd.Parameters.AddWithValue("@personexem_key", personexem_key)
    '    cmd.Parameters.AddWithValue("@paytype_key", paytype_key)
    '    'cmd.Parameters.AddWithValue("@payloc_key", payloc_key)
    '    cmd.Parameters.AddWithValue("@position_key", position_key)
    '    cmd.Parameters.AddWithValue("@cc_key", cc_key)
    '    cmd.Parameters.AddWithValue("@monthly_rate", monthly_rate)
    '    cmd.Parameters.AddWithValue("@daily_rate", daily_rate)
    '    cmd.Parameters.AddWithValue("@hourly_rate", hourly_rate)
    '    cmd.Parameters.AddWithValue("@tin", tin)
    '    cmd.Parameters.AddWithValue("@sss_gsis_no", sss_gsis_no)
    '    cmd.Parameters.AddWithValue("@hdmf_no", hdmf_no)
    '    cmd.Parameters.AddWithValue("@philhealth_no", philhealth_no)
    '    cmd.Parameters.AddWithValue("@bank_acctno", bank_acctno)
    '    cmd.Parameters.AddWithValue("@deptid", deptid)
    '    cmd.Parameters.AddWithValue("@division_key", division_key)
    '    cmd.Parameters.AddWithValue("@section_id", section_id)
    '    cmd.Parameters.AddWithValue("@shift_key", shift_key)
    '    'cmd.Parameters.AddWithValue("@plantilla_no", "")
    '    ' cmd.Parameters.AddWithValue("@supervisor", 0)
    '    cmd.Parameters.AddWithValue("@item_new", item_new)
    '    cmd.Parameters.AddWithValue("@item_old", item_old)
    '    cmd.Parameters.Add("@CurrID", Data.SqlDbType.BigInt).Direction = Data.ParameterDirection.Output
    '    Execute("@CurrID", "HRMS.spSave_pay_m_emp_payroll_info", Data.CommandType.StoredProcedure)

    'End Sub
    'Public Sub addPayrollInfo()
    '    Dim objDerived As New DerivedDal
    '    conStr = objDerived.DbaseConnect

    '    cmd.Parameters.AddWithValue("@empid", empid)
    '    cmd.Parameters.AddWithValue("@empstat_key", empstat_key)
    '    cmd.Parameters.AddWithValue("@empclass_key", empclass_key)
    '    cmd.Parameters.AddWithValue("@emptimetype_key", emptimetype_key)
    '    cmd.Parameters.AddWithValue("@job_grade_key", job_grade_key)
    '    cmd.Parameters.AddWithValue("@personexem_key", personexem_key)
    '    cmd.Parameters.AddWithValue("@paytype_key", paytype_key)
    '    'cmd.Parameters.AddWithValue("@payloc_key", payloc_key)
    '    cmd.Parameters.AddWithValue("@position_key", position_key)
    '    cmd.Parameters.AddWithValue("@cc_key", cc_key)
    '    cmd.Parameters.AddWithValue("@monthly_rate", monthly_rate)
    '    cmd.Parameters.AddWithValue("@daily_rate", daily_rate)
    '    cmd.Parameters.AddWithValue("@hourly_rate", hourly_rate)
    '    cmd.Parameters.AddWithValue("@tin", tin)
    '    cmd.Parameters.AddWithValue("@sss_gsis_no", sss_gsis_no)
    '    cmd.Parameters.AddWithValue("@hdmf_no", hdmf_no)
    '    cmd.Parameters.AddWithValue("@philhealth_no", philhealth_no)
    '    cmd.Parameters.AddWithValue("@bank_acctno", bank_acctno)
    '    cmd.Parameters.AddWithValue("@deptid", deptid)
    '    cmd.Parameters.AddWithValue("@division_key", division_key)
    '    cmd.Parameters.AddWithValue("@section_id", section_id)
    '    cmd.Parameters.AddWithValue("@shift_key", shift_key)
    '    'cmd.Parameters.AddWithValue("@plantilla_no", "")
    '    ' cmd.Parameters.AddWithValue("@supervisor", 0)
    '    cmd.Parameters.AddWithValue("@item_new", item_new)
    '    cmd.Parameters.AddWithValue("@item_old", item_old)
    '    cmd.Parameters.Add("@CurrID", Data.SqlDbType.BigInt).Direction = Data.ParameterDirection.Output
    '    Execute("@CurrID", "HRMS.spSave_NewEmp_Payroll_info", Data.CommandType.StoredProcedure)

    'End Sub
    'Public Sub addHRANPayrollInfo()
    '    Dim objDerived As New DerivedDal
    '    conStr = objDerived.DbaseConnect

    '    cmd.Parameters.AddWithValue("@empid", empid)
    '    cmd.Parameters.AddWithValue("@empstat_key", empstat_key)
    '    cmd.Parameters.AddWithValue("@job_grade_key", job_grade_key)
    '    cmd.Parameters.AddWithValue("@position_key", position_key)
    '    cmd.Parameters.AddWithValue("@monthly_rate", monthly_rate)
    '    cmd.Parameters.AddWithValue("@daily_rate", daily_rate)
    '    cmd.Parameters.AddWithValue("@hourly_rate", hourly_rate)
    '    cmd.Parameters.AddWithValue("@deptid", deptid)
    '    cmd.Parameters.AddWithValue("@division_key", division_key)
    '    cmd.Parameters.AddWithValue("@section_id", section_id)
    '    cmd.Parameters.Add("@CurrID", Data.SqlDbType.BigInt).Direction = Data.ParameterDirection.Output
    '    Execute("@CurrID", "HRMS.spSave_HRANpay_m_emp_payroll_info", Data.CommandType.StoredProcedure)
    'End Sub
End Class
