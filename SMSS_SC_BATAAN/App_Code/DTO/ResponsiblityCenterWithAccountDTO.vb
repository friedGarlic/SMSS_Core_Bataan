Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms


Public Class ResponsiblityCenterWithAccountDTO
    Inherits BaseDLL.BaseDAL

    Private _rcid As Integer
    Public Property ResponsibiltyCenter() As Integer
        Get
            Return _rcid
        End Get
        Set(ByVal value As Integer)
            _rcid = value
        End Set
    End Property


    Private _rcname As String
    Public Property ResponsibilityCenterName() As String
        Get
            Return _rcname
        End Get
        Set(ByVal value As String)
            _rcname = value
        End Set
    End Property

    Private _funct_id_per_office As Integer
    Public Property Function_Id_per_Office() As Integer
        Get
            Return _funct_id_per_office
        End Get
        Set(ByVal value As Integer)
            _funct_id_per_office = value
        End Set
    End Property

    Private _cy As Integer
    Public Property Current_year() As Integer
        Get
            Return _cy
        End Get
        Set(ByVal value As Integer)
            _cy = value
        End Set
    End Property

    Private _gatitle As String
    Public Property GeneralAccounttitle() As String
        Get
            Return _gatitle
        End Get
        Set(ByVal value As String)
            _gatitle = value
        End Set
    End Property

    Private _status As Boolean
    Public Property Status() As Boolean
        Get
            Return _status
        End Get
        Set(ByVal value As Boolean)
            _status = value
        End Set
    End Property

    Private _enable As Boolean
    Public Property Enable() As Boolean
        Get
            Return _enable
        End Get
        Set(ByVal value As Boolean)
            _enable = value
        End Set
    End Property

    Private _isforrevision As Boolean
    Public Property Isforrevision() As Boolean
        Get
            Return _isforrevision
        End Get
        Set(ByVal value As Boolean)
            _isforrevision = value
        End Set
    End Property

    Private _fid As Integer
    Public Property Function_Id() As Integer
        Get
            Return _fid
        End Get
        Set(ByVal value As Integer)
            _fid = value
        End Set
    End Property

    Private _progId As Integer
    Public Property ProgramId() As Integer
        Get
            Return _progId
        End Get
        Set(ByVal value As Integer)
            _progId = value
        End Set
    End Property


    Private _projId As Integer
    Public Property ProjectID() As Integer
        Get
            Return _projId
        End Get
        Set(ByVal value As Integer)
            _projId = value
        End Set
    End Property


    Private _bgatitle As String
    Public Property BgaTitle() As String
        Get
            Return _bgatitle
        End Get
        Set(ByVal value As String)
            _bgatitle = value
        End Set
    End Property


    Private _gaid As Integer
    Public Property Ga_id() As Integer
        Get
            Return _gaid
        End Get
        Set(ByVal value As Integer)
            _gaid = value
        End Set
    End Property

    Private _bgaid As Integer
    Public Property BgaID() As Integer
        Get
            Return _bgaid
        End Get
        Set(ByVal value As Integer)
            _bgaid = value
        End Set
    End Property

    Private _isrepair As Integer
    Public Property IsRepair() As Integer
        Get
            Return _isrepair
        End Get
        Set(ByVal value As Integer)
            _isrepair = value
        End Set
    End Property








End Class
Public Class ResponsiblityCenterWithAccountDTOlist
    Inherits List(Of ResponsiblityCenterWithAccountDTO)

End Class



