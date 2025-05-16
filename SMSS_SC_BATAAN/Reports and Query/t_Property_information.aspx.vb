Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class t_Property_information
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim obj As New AccessRule
#Region "Property"


    Private Property pHistory() As DataTable
        Get
            Return CType(Session("pHistory"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pHistory") = value
        End Set
    End Property

#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)

            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If
            TXTBARCODE.Attributes.Add("OnFocus", "this.select()")
            TXTBARCODE.Attributes.Add("OnClick", "this.select()")
            TXTBARCODE.Focus()
            pHistory = Nothing
            gvbody.DataSource = pHistory
            gvbody.DataBind()
        End If
        'TXTBARCODE.Focus()
        TXTBARCODE.Focus()
    End Sub

    'Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    Try
    '        TXTBARCODE.Focus()
    '        pInfo = objDerived.GetDataTable("exec  ams.propertyinfo '" & TXTBARCODE.Text & "'", CommandType.Text)
    '        pInfoDetail = objDerived.GetDataTable("exec ams.propertyinfodetail'" & TXTBARCODE.Text & "'", CommandType.Text)
    '        txtpropertynum.Text = pInfo.Rows(0)("PropertyNo")
    '        TXTDESCRIPTION.Text = pInfo.Rows(0)("Item_Desc")
    '        'txtrespcenter.Text = pInfo.Rows(0)("")
    '        txtcost.Text = FormatNumber(pInfo.Rows(0)("Cost"), 2)
    '        txtdate.Text = pInfo.Rows(0)("Property_Date")
    '        ' txtperson.Text = pInfo.Rows(0)("")
    '        Label2.Visible = False

    '    Catch ex As Exception
    '        If TXTBARCODE.Text <> "" Then
    '            Label2.Visible = True
    '        End If
    '        txtpropertynum.Text = ""
    '        TXTDESCRIPTION.Text = ""
    '        txtrespcenter.Text = ""
    '        txtcost.Text = ""
    '        txtdate.Text = ""
    '        txtperson.Text = ""
    '        TXTBARCODE.Focus()
    '    End Try

    'End Sub

    Protected Sub TXTBARCODE_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBARCODE.TextChanged
        Try

            TXTBARCODE.Focus()
            pHistory = objDerived.GetDataTable("exec  AMS.PropertyHistory  '" & TXTBARCODE.Text & "'", CommandType.Text)
            gvbody.DataSource = pHistory
            gvbody.DataBind()

            'Dim row As Integer = pHistory.Rows.Count - 1
            txtpropertynum.Text = pHistory.Rows(0)("PropertyNo")
            TXTDESCRIPTION.Text = pHistory.Rows(0)("Item_Desc")
            txtcost.Text = FormatNumber(pHistory.Rows(0)("Cost"), 2)
            txtdatePurchased.Text = pHistory.Rows(pHistory.Rows.Count - 1)("date")
            txtrespcenter.Text = pHistory.Rows(pHistory.Rows.Count - 1)("RC_Name")
            txtFunction.Text = pHistory.Rows(pHistory.Rows.Count - 1)("Function_Desc")

            'txtperson.Text = pInfo.Rows(0)("")
            Label2.Visible = False
            If pHistory.Rows.Count > 0 Then
                txtperson.Text = pHistory.Rows(0)("fullname")
                txtdate.Text = pHistory.Rows(0)("date")
            End If
            'TXTBARCODE.Text = ""
            'TXTBARCODE.Focus()
            'TXTBARCODE.Text = ""
        Catch ex As Exception
            If TXTBARCODE.Text <> "" Then
                Label2.Visible = True
            End If
            txtpropertynum.Text = ""
            TXTDESCRIPTION.Text = ""
            txtrespcenter.Text = ""
            txtcost.Text = ""
            txtdate.Text = ""
            txtperson.Text = ""
            txtFunction.Text = ""
            TXTBARCODE.Text = ""

            TXTBARCODE.Focus()
            TXTBARCODE.Text = ""

        End Try
    End Sub
End Class
