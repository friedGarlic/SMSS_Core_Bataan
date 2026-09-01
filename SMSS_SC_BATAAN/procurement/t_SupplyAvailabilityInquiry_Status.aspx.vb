Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.WebControls.Label
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO

Partial Class procurement_t_SupplyAvailabilityInquiry_Status
    Inherits System.Web.UI.Page

    Private objDerived As New DerivedDal

#Region "property"
    Private Property pRC() As DataTable
        Get
            Return CType(Session("pRC"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRC") = value
        End Set

    End Property

    Private Property pFunction() As DataTable
        Get
            Return CType(Session("pFunction"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pFunction") = value
        End Set

    End Property

    Private Property pAccounts() As DataTable
        Get
            Return CType(Session("pAccounts"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pAccounts") = value
        End Set

    End Property
    Private Property pListitem() As DataTable
        Get
            Return CType(Session("pListitem"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pListitem") = value
        End Set

    End Property
    Private Property pItems() As DataTable
        Get
            Return CType(Session("pItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pItems") = value
        End Set
    End Property
    Private Property pemployee() As DataTable
        Get
            Return CType(Session("pemployee"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pemployee") = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                Try
                    txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

                    gvSAI.DataSource = Nothing
                    gvSAI.DataBind()
                    gvSAI_Items.DataSource = Nothing
                    gvSAI_Items.DataBind()

                    pRC = objDerived.GetDataTable("select * from [AMS].[Respcenter] where Function_ID = 86 and rc_id <> 48 and rc_id <> 49 order by rc_id ", CommandType.Text)
                    ddDepartment.DataSource = CType(pRC, DataTable)
                    ddDepartment.DataTextField = ("RespCenter")
                    ddDepartment.DataValueField = ("rc_id")
                    ddDepartment.DataBind()

                Catch ex As Exception
                End Try
            End If

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ddDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            ddDepartment.Enabled = False
            ddFunction.Enabled = True

            pFunction = objDerived.GetDataTable("select Office_id as Rc_id , Function_id,Function_desc from ams.vw_functions  where Office_id = " & ddDepartment.SelectedItem.Value & "", CommandType.Text)
            ddFunction.DataSource = pFunction
            ddFunction.DataTextField = ("Function_Desc")
            ddFunction.DataValueField = ("Function_ID")
            ddFunction.DataBind()

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ddFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddFunction.Enabled = False
        ddSupplyOfficer.Enabled = True
        RadioButtonList3.Enabled = True

        ddSupplyOfficer.DataSource = objDerived.GetDataTable("Exec dbo.sp_Signatories '" & 3 & "'", CommandType.Text)
        ddSupplyOfficer.DataTextField = ("full_name")
        ddSupplyOfficer.DataValueField = ("empid")
        ddSupplyOfficer.DataBind()

        Dim dtsai As New DataTable
        dtsai = objDerived.GetDataTable("Select * from dbo.View_SAI_for_confirmation where rc_id = '" & ddDepartment.SelectedItem.Value & "' and function_id = '" & ddFunction.SelectedItem.Value & "' and isConfirm = 'false' ORDER BY Sai_No", CommandType.Text)
        gvSAI.DataSource = dtsai
        gvSAI.DataBind()
    End Sub

    Protected Sub gvSAI_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim dtitems As New DataTable
            dtitems = objDerived.GetDataTable("Select * from dbo.View_SAI where Sai_Hdr_ID = '" & gvSAI.SelectedDataKey("Sai_Hdr_ID") & "'", CommandType.Text)
            gvSAI_Items.DataSource = dtitems
            gvSAI_Items.DataBind()

            If RadioButtonList3.SelectedIndex = 1 Then
                txtDate.Text = objDerived.GetValue("Select Date_Provided from AMS.TbSai_hdr where rc_id = '" & ddDepartment.SelectedItem.Value & "' and function_id = '" & ddFunction.SelectedItem.Value & "' and isConfirm = 'true' and Sai_Hdr_ID = '" & gvSAI.SelectedDataKey("Sai_Hdr_ID") & "'", CommandType.Text)
                ddSupplyOfficer.SelectedItem.Text = objDerived.GetValue("Select Providedby from AMS.TbSai_hdr where rc_id = '" & ddDepartment.SelectedItem.Value & "' and function_id = '" & ddFunction.SelectedItem.Value & "' and isConfirm = 'true' and Sai_Hdr_ID = '" & gvSAI.SelectedDataKey("Sai_Hdr_ID") & "'", CommandType.Text)

                txtDate.Enabled = False
                ddSupplyOfficer.Enabled = False

                For i As Integer = 0 To Me.gvSAI_Items.Rows.Count - 1
                    CType(gvSAI_Items.Rows(i).FindControl("txtAvailableQty"), TextBox).Enabled = False
                Next

                btnPreview.Enabled = True
                btnSAVE.Enabled = False
            End If

            gvSAI_Items.Columns(4).Visible = False


        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSAVE_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        btnSAVE.OnClientClick = "StartProgressBar();"

        If ddSupplyOfficer.SelectedValue = "Select" Then
            lblreq.Visible = True
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up required field.")
        Else

            objDerived.GetRecords("Update AMS.TbSai_Hdr set Providedby ='" & ddSupplyOfficer.SelectedItem.Text & "', Date_Provided = '" & txtDate.Text & "', isConfirm = 'True' where Sai_Hdr_ID ='" & gvSAI.SelectedDataKey("Sai_Hdr_ID") & "' ", CommandType.Text)

            For i As Integer = 0 To Me.gvSAI_Items.Rows.Count - 1
                Dim qty As TextBox
                qty = CType(gvSAI_Items.Rows(i).FindControl("txtAvailableQty"), TextBox)
                objDerived.GetRecords("Update AMS.TbSai_Dtl set AvailbleQty ='" & CType(qty.Text, Integer) & "' where item_ID ='" & gvSAI_Items.Rows(i).Cells(4).Text & "' and Sai_Hdr_ID ='" & gvSAI.SelectedDataKey("Sai_Hdr_ID") & "' ", CommandType.Text)
            Next

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")


            For i As Integer = 0 To Me.gvSAI_Items.Rows.Count - 1
                CType(gvSAI_Items.Rows(i).FindControl("txtAvailableQty"), TextBox).Enabled = False
            Next
            btnSAVE.Enabled = False
            btnPreview.Enabled = True
        End If
    End Sub

    Protected Sub ddSupplyOfficer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        btnSAVE.Enabled = True
    End Sub

    Protected Sub RadioButtonList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dtsai As New DataTable
        gvSAI_Items.DataSource = Nothing
        gvSAI_Items.DataBind()

        If RadioButtonList3.SelectedIndex = 0 Then
            dtsai = objDerived.GetDataTable("Select * from dbo.View_SAI_for_confirmation where rc_id = '" & ddDepartment.SelectedItem.Value & "' and function_id = '" & ddFunction.SelectedItem.Value & "' and isConfirm = 'false' ORDER BY Sai_No", CommandType.Text)
            gvSAI.DataSource = dtsai
            gvSAI.DataBind()

            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")
            txtDate.Enabled = True
            ddSupplyOfficer.Enabled = True
            ddSupplyOfficer.SelectedItem.Text = "Select"

            btnPreview.Enabled = False

        ElseIf RadioButtonList3.SelectedIndex = 1 Then
            dtsai = objDerived.GetDataTable("Select * from dbo.View_SAI_for_confirmation where rc_id = '" & ddDepartment.SelectedItem.Value & "' and function_id = '" & ddFunction.SelectedItem.Value & "' and isConfirm = 'true' ORDER BY Sai_No", CommandType.Text)
            gvSAI.DataSource = dtsai
            gvSAI.DataBind()

            ddSupplyOfficer.SelectedItem.Text = "Select"
            btnSAVE.Enabled = False
        End If
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("SAI") = "Status"
        Session("sai_hdr_id") = gvSAI.SelectedDataKey("Sai_Hdr_ID")
        Me.Page.Response.Redirect("~/Procurement/rpt_SAI_report.aspx")
    End Sub

    Protected Sub gvSAI_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtsai As New DataTable
        gvSAI_Items.DataSource = Nothing
        gvSAI_Items.DataBind()

        If RadioButtonList3.SelectedIndex = 0 Then
            dtsai = objDerived.GetDataTable("Select * from dbo.View_SAI_for_confirmation where rc_id = '" & ddDepartment.SelectedItem.Value & "' and function_id = '" & ddFunction.SelectedItem.Value & "' and isConfirm = 'false' ORDER BY Sai_No", CommandType.Text)
            gvSAI.PageIndex = e.NewPageIndex
            gvSAI.DataSource = dtsai
            gvSAI.DataBind()

            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")
            txtDate.Enabled = True
            ddSupplyOfficer.Enabled = True
            ddSupplyOfficer.SelectedItem.Text = "Select"

            btnPreview.Enabled = False

        ElseIf RadioButtonList3.SelectedIndex = 1 Then
            dtsai = objDerived.GetDataTable("Select * from dbo.View_SAI_for_confirmation where rc_id = '" & ddDepartment.SelectedItem.Value & "' and function_id = '" & ddFunction.SelectedItem.Value & "' and isConfirm = 'true' ORDER BY Sai_No", CommandType.Text)
            gvSAI.PageIndex = e.NewPageIndex
            gvSAI.DataSource = dtsai
            gvSAI.DataBind()

            ddSupplyOfficer.SelectedItem.Text = "Select"
            btnSAVE.Enabled = False
        End If
    End Sub

    Protected Sub gvSAI_Items_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Try

            Dim dtitems As New DataTable
            dtitems = objDerived.GetDataTable("Select * from dbo.View_SAI where Sai_Hdr_ID = '" & gvSAI.SelectedDataKey("Sai_Hdr_ID") & "'", CommandType.Text)
            gvSAI_Items.PageIndex = e.NewPageIndex
            gvSAI_Items.DataSource = dtitems
            gvSAI_Items.DataBind()

            If RadioButtonList3.SelectedIndex = 1 Then
                txtDate.Text = objDerived.GetValue("Select Date_Provided from AMS.TbSai_hdr where rc_id = '" & ddDepartment.SelectedItem.Value & "' and function_id = '" & ddFunction.SelectedItem.Value & "' and isConfirm = 'true' and Sai_Hdr_ID = '" & gvSAI.SelectedDataKey("Sai_Hdr_ID") & "'", CommandType.Text)
                ddSupplyOfficer.SelectedItem.Text = objDerived.GetValue("Select Providedby from AMS.TbSai_hdr where rc_id = '" & ddDepartment.SelectedItem.Value & "' and function_id = '" & ddFunction.SelectedItem.Value & "' and isConfirm = 'true' and Sai_Hdr_ID = '" & gvSAI.SelectedDataKey("Sai_Hdr_ID") & "'", CommandType.Text)

                txtDate.Enabled = False
                ddSupplyOfficer.Enabled = False

                For i As Integer = 0 To Me.gvSAI_Items.Rows.Count - 1
                    CType(gvSAI_Items.Rows(i).FindControl("txtAvailableQty"), TextBox).Enabled = False
                Next

                btnPreview.Enabled = True
                btnSAVE.Enabled = False
            End If

            gvSAI_Items.Columns(4).Visible = False

        Catch ex As Exception
        End Try
    End Sub
End Class
