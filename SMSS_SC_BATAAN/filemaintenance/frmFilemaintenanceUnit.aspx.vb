Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class File_Maintenance_frmFilemaintenanceUnit
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Dim hdr As New unit_hdr
    Dim dtl As New unit_dtl
    Dim hdrid As Long
#Region "property"
    Private Property pUnitHdr() As DataTable
        Get
            Return CType(Session("pUnitHdr"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pUnitHdr") = value
        End Set
    End Property
    Private Property punit() As DataTable
        Get
            Return CType(Session("punit"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("punit") = value
        End Set
    End Property
#End Region

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbwith.CheckedChanged
        If cbwith.Checked = True Then
            'Panel1.Visible = False
            ddsubunit.SelectedIndex = 0
            txtvalue.Text = 0
            txtsubdetail.Text = 0
            txtvalue.Text = 0
        Else
            'Panel1.Visible = False
            txtsubdetail.Text = 1
            txtvalue.Text = 1
        End If
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'obj.GetAccessRight(Me.Session("@UserName"), Page)

        'If obj.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        'End If
        If Not Page.IsPostBack Then
            pUnitHdr = objDerived.GetDataTable("SELECT     Unit_hdr_id, Description FROM AMS.m_unit_hdr order by Description", CommandType.Text)
            ddunit.DataSource = pUnitHdr
            ddunit.DataTextField = "Description"
            ddunit.DataValueField = "Unit_hdr_id"
            ddunit.DataBind()

            ddsubunit.DataSource = pUnitHdr
            ddsubunit.DataTextField = "Description"
            ddsubunit.DataValueField = "Unit_hdr_id"
            ddsubunit.DataBind()

            txtDescription.Text = ""
            txtDescription.ReadOnly = True

            'Panel1.Visible = False
            txtsubdetail.Text = 1
            txtvalue.Text = 1
            punit = objDerived.GetDataTable("SELECT Unit_hdr_id, Description, Unit_hdr_id2, value  FROM AMS.m_Unit ORDER BY Description", CommandType.Text)
            gvunit.DataSource = punit
            gvunit.DataBind()

            Session("Search") = 0
            tbSubUnit.Visible = False

            txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")


        End If
    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            If ddunit.SelectedIndex = 1 Then

                hdr.Description = txtDescription.Text
                hdrid = hdr.save()
                If cbwith.Checked = True Then
                    dtl.Unit_hdr_id = hdrid
                    dtl.Description = txtDescription.Text + " (" + txtvalue.Text + ")" + ddsubunit.SelectedItem.Text
                    dtl.Unit_hdr_id2 = ddsubunit.SelectedItem.Value
                    dtl.value = txtvalue.Text
                    dtl.save()
                    save()

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been succesfully saved.")

                Else
                    If verify1() = False Then
                        dtl.Unit_hdr_id = hdrid
                        dtl.Description = txtDescription.Text
                        'dtl.Unit_hdr_id2 = ddsubunit.SelectedItem.Value
                        dtl.value = 1
                        dtl.save()
                        save()

                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been succesfully saved.")

                    Else
                        msg.UserMsgBox("Record is already existing", Me, False)
                    End If

                End If

            Else
                ' If cbwith.Checked = True Then
                If verify() = False Then
                    dtl.Unit_hdr_id = ddunit.SelectedItem.Value
                    dtl.Description = ddunit.SelectedItem.Text + " (" + txtvalue.Text + ")" + ddsubunit.SelectedItem.Text
                    dtl.Unit_hdr_id2 = ddsubunit.SelectedItem.Value
                    dtl.value = txtvalue.Text
                    dtl.save()
                    save()

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been succesfully saved.")

                Else
                    msg.UserMsgBox("Record is already existing", Me, False)
                End If
            End If


            punit = objDerived.GetDataTable("SELECT Unit_hdr_id, Description, Unit_hdr_id2, value  FROM AMS.m_Unit ORDER BY Description", CommandType.Text)
            gvunit.DataSource = punit
            gvunit.DataBind()
        Catch ex As Exception
        End Try
    End Sub


    Public Sub save()
        ddsubunit.Enabled = False
        ddunit.Enabled = False
        txtDescription.Enabled = False
        txtvalue.Enabled = False
        cbwith.Enabled = False

        punit = objDerived.GetDataTable("SELECT     TOP (100) PERCENT Unit_hdr_id, Description, Unit_hdr_id2, value  FROM AMS.m_Unit ORDER BY Description", CommandType.Text)
        gvunit.DataSource = punit
        gvunit.DataBind()
    End Sub

    Protected Sub ddsubunit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddsubunit.SelectedIndexChanged
        txtsubdetail.Text = ddsubunit.SelectedItem.Value
    End Sub

    Protected Sub ddunit_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddunit.SelectedIndexChanged
        If ddunit.SelectedIndex = 1 Then

            txtDescription.Text = ""
            txtDescription.ReadOnly = False
            txtDescription.Visible = True

            lblUnit.Visible = True
            cbwith.Checked = False
            cbwith.Enabled = True
            'Panel1.Visible = False
            txtsubdetail.Text = 1
            txtvalue.Text = 1

        ElseIf ddunit.SelectedIndex = 0 Then

            txtDescription.Text = ""
            txtDescription.ReadOnly = True
            txtDescription.Visible = False

            cbwith.Checked = False
            cbwith.Enabled = True

            lblUnit.Visible = False
            'Panel1.Visible = False
            txtsubdetail.Text = 1
            txtvalue.Text = 1
        Else

            txtDescription.Text = ddsubunit.SelectedItem.Value
            txtDescription.ReadOnly = True
            txtDescription.Visible = False

            cbwith.Checked = True
            cbwith.Enabled = False

            lblUnit.Visible = False
            'Panel1.Visible = False
            ddsubunit.SelectedIndex = 0
            txtvalue.Text = 0
            txtsubdetail.Text = 0
            txtvalue.Text = 0
        End If
    End Sub

 
    Protected Sub txtDescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescription.TextChanged

    End Sub

    Protected Sub txtvalue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvalue.TextChanged

    End Sub


    Public Function verify() As Boolean
        Dim myview As DataView
        myview = CType(punit, DataTable).DefaultView
        myview.RowFilter = "Unit_hdr_id ='" & ddunit.SelectedItem.Value & "' and Unit_hdr_id2='" & ddsubunit.SelectedItem.Value & "' and value='" & txtvalue.Text & "'"
        If myview.Count <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function verify1() As Boolean
        Dim myview As DataView
        myview = CType(punit, DataTable).DefaultView
        myview.RowFilter = "Description ='" & txtDescription.Text & "'"
        If myview.Count <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub gvunit_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvunit.PageIndexChanging

        If Session("Search") = 1 Then
            Dim myview As DataView
            myview = punit.DefaultView
            myview.RowFilter = "Description like '%" & replaceapostrophe(txtSearch.Text.ToString) & "%'"
            gvunit.PageIndex = e.NewPageIndex
            gvunit.DataSource = myview
            gvunit.DataBind()
            gvunit.SelectedIndex = -1

        ElseIf Session("Search") = 0 Then
            gvunit.PageIndex = e.NewPageIndex
            gvunit.DataSource = punit
            gvunit.DataBind()
            gvunit.SelectedIndex = -1
        End If
   


    End Sub

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Me.Page.Response.Redirect("~/filemaintenance/frmFilemaintenanceUnit.aspx")
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = punit.DefaultView
        myview.RowFilter = "Description like '%" & replaceapostrophe(txtSearch.Text.ToString) & "%'"
        gvunit.DataSource = myview
        gvunit.DataBind()

        Session("Search") = 1
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

End Class
