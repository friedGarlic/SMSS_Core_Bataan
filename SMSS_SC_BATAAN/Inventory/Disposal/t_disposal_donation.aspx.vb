Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.HtmlControls
Imports System.IO

Partial Class t_disposal_donation

    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim hdr As New Disposal_Donation_hdr
    Dim dtl As New Disposal_Donation_dtl
    Dim msg As New MsgeBox
    Dim obj As New AccessRule

    Dim objLedger As New t_PropertyLedger
    Dim Ledger_ID As New Integer
    Dim dtPropLedger As New DataTable

    Dim objDonationLedger As New ConsolidatedPropertySaving.TbDonation_Ledger
    Dim DonationLedger_ID As New Integer
    Dim dtDonationLedger As New DataTable

    Private objMREReturn As New MRE_Return
    Dim objStockLedger As New t_StockLedger
    Dim StockLedger_ID As New Integer
    Dim dtStockLedger As New DataTable


#Region "property"

    Private Property pNew() As DataTable
        Get
            Return CType(Session("pNew"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pNew") = value
        End Set
    End Property

    Private Property dtIIRUS() As DataTable
        Get
            Return CType(Session("dtIIRUS"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtIIRUS") = value
        End Set
    End Property

    Private Property dtIIRUS_Dtl() As DataTable
        Get
            Return CType(Session("dtIIRUS_Dtl"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtIIRUS_Dtl") = value
        End Set
    End Property

    Private Property pBody() As DataTable
        Get
            Return CType(Session("pBody"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBody") = value
        End Set
    End Property

    Private Property dtSupp() As DataTable
        Get
            Return CType(Session("dtSupp"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtSupp") = value
        End Set
    End Property

    Private Property pOPen() As DataTable
        Get
            Return CType(Session("pOPen"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pOPen") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        obj.GetAccessRight(Me.Session("@UserName"), Page)

        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            pBody = Nothing
            gvbody.DataSource = pBody
            gvbody.DataBind()

            txtdate.Text = Date.Today.ToString("MM/dd/yyyy")
            btnnew.Enabled = True
            btnopen.Enabled = True
            btnsave.Enabled = False
            'txtTo.Enabled = False
            'txtRAO.Enabled = False
            'txtBy.Enabled = False
            btnpreview.Enabled = False

            lblRAO.Visible = False
            lblBy.Visible = False

            rbChoice.SelectedItem.Value = 1
            LoadrbChoice()

        End If
    End Sub
    Protected Sub gvNEW_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvNEW.SelectedIndexChanged
        Try
            pBody = Nothing
            pBody = objDerived.GetDataTable("exec ams.donation_dtl_report '" & gvNEW.SelectedDataKey(0) & "'", CommandType.Text)
            gvbody.DataSource = pBody
            gvbody.DataBind()

            txtdate.Text = Date.Today.ToString("MM/dd/yyyy")

            Me.Session("TransID") = gvNEW.SelectedDataKey(0)
            btnnew.Enabled = True
            btnopen.Enabled = True
            btnsave.Enabled = True
            btnpreview.Enabled = False

            txtTo.Text = ""
            txtRAO.Text = ""
            txtBy.Text = ""
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            If txtRAO.Text = "" Or txtBy.Text = "" Then
                lblRAO.Visible = True
                lblBy.Visible = True

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up required fields.")

                Exit Sub
            End If

            If rbChoice.SelectedItem.Value = 1 Then
                '=-= PROPERTIES

                'Session("chckbox") = 0
                'For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                '    Dim c As CheckBox = CType(Me.gvbody.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                '    If c.Checked = True Then
                '        Session("chckbox") = 1
                '    End If
                'Next

                'If Session("chckbox") = 0 Then
                '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select property from the grid.")
                '    Exit Sub
                'End If

                lblRAO.Visible = False
                lblBy.Visible = False

                'Dim rc As Integer
                'For o As Integer = 0 To gvbody.Rows.Count - 1
                '    If CType(gvbody.Rows(o).FindControl("CheckBox1"), CheckBox).Checked = True Then
                '        rc = rc + 1
                '    End If
                'Next
                'If rc >= 1 Then
                hdr.Disposa_date = txtdate.Text
                hdr.IIRUPHdr_ID = gvNEW.SelectedDataKey(0)
                hdr.TransTo = txtTo.Text
                hdr.RAO = txtRAO.Text
                hdr.AuthorizedBy = txtBy.Text
                Dim hdrid As Long = hdr.save()

                Me.Session("TransID") = hdrid

                For i As Integer = 0 To pBody.Rows.Count - 1
                    'If CType(gvbody.Rows(i).FindControl("CheckBox1"), CheckBox).Checked = True Then
                    'Disposal_Donation_dtl
                    dtl.Disposal_Donation_hdr_id = hdrid
                    dtl.PropertyNo = pBody.Rows(i)("PropertyNo")
                    dtl.Property_ID = pBody.Rows(i)("Property_ID")
                    dtl.value = pBody.Rows(i)("val")
                    dtl.Property_Date = pBody.Rows(i)("Property_Date")
                    dtl.save()

                    Dim qty As Integer = Val(objDerived.GetValue("SELECT AMS.Property.qty FROM AMS.Property INNER JOIN AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID WHERE     AMS.Property_Dtl.PropertyNo ='" & pBody.Rows(i)("PropertyNo") & "'", CommandType.Text))
                    Dim balance As Integer = Val(objDerived.GetValue("exec AMS.getbalance '" & pBody.Rows(i)("PropertyNo") & "'", CommandType.Text))
                    Dim issuance As Integer = Val(objDerived.GetValue("exec AMS.getIssuance '" & pBody.Rows(i)("PropertyNo") & "'", CommandType.Text))

                    balance = Val(objDerived.GetValue("exec AMS.getbalance '" & pBody.Rows(i)("PropertyNo") & "'", CommandType.Text))
                    issuance = Val(objDerived.GetValue("exec AMS.getIssuance '" & pBody.Rows(i)("PropertyNo") & "'", CommandType.Text))
                    objDerived.GetRecords("Update AMS.Property set qty='" & IIf(qty = 0, 0, qty - 1) & "',Balance='" & IIf(balance = 0, 0, balance - 1) & "' where  Property_ID='" & pBody.Rows(i)("Property_ID") & "'", CommandType.Text)
                    objDerived.GetRecords("Update AMS.Property_Dtl SET DisposeDate='" & txtdate.Text & "',Dispose ='True'  WHERE PropertyNo='" & pBody.Rows(i)("PropertyNo") & "'", CommandType.Text)

                    'MRE_Returns
                    objMREReturn.MRE_Dtl = 0
                    objMREReturn.PropertyNo = pBody.Rows(i)("PropertyNo")
                    objMREReturn.MRE_Date = txtdate.Text
                    objMREReturn.Status = "Disposed"
                    objMREReturn.Remarks = "Donated"
                    objMREReturn.Dispose = True
                    objMREReturn.Repair = False
                    objMREReturn.Inspection = False
                    objMREReturn.deptid = 0
                    objMREReturn.UpdateMREReturn()


                    If pBody.Rows(i)("isDonated") = True Then
                        '==== Update Ledger Donations ==== 
                        dtDonationLedger = objDonationLedger.GetDataTable("Select DonationLedger_ID from AMS.TbDonation_Ledger", CommandType.Text)
                        With objDonationLedger
                            '.DonationLedger_ID = DonationLedger_ID
                            .PropertyNo = pBody.Rows(i)("PropertyNo")
                            .SerialNo = IIf(IsDBNull(pBody.Rows(i)("Barcode").ToString), 0, (pBody.Rows(i)("Barcode").ToString)) 'pBody.Rows(i)("Barcode")
                            .Trans_Type = "Disposed as Donated"
                            .Ref = ""
                            .AccountablePerson = txtRAO.Text
                            .Department = txtTo.Text
                            .Position = ""
                            .AcceptedBy = ""
                            .InspectedBy = ""
                            .Item_ID = pBody.Rows(i)("Item_ID")

                            .DebitQty = "0"
                            .DebitUnit = "-"
                            .DebitCost = "0.00"

                            .CreditQty = 1
                            .CreditUnit = pBody.Rows(i)("Unit")
                            .CreditCost = CType(pBody.Rows(i)("Amount"), Decimal)

                            .BalanceQty = 0
                            .BalanceUnit = "-" 'objDerived.GetValue("SELECT AMS.m_Unit.Description FROM dbo.m_item INNER JOIN AMS.m_Unit ON dbo.m_item.Unit_ID = AMS.m_Unit.Unit_ID where Item_ID ='" & grListOfProperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                            .BalanceCost = CType(0, Decimal)
                            .dDate = txtdate.Text


                        End With
                        objDonationLedger.DonationLedger_ID = 0
                        objDonationLedger.save()

                    Else
                        '==== Update Ledger Properties ====
                        dtPropLedger = objLedger.GetDataTable("Select Ledger_ID from AMS.TbProperty_Ledger", CommandType.Text)
                        With objLedger
                            '.Ledger_ID = Ledger_ID
                            .PropertyNo = pBody.Rows(i)("PropertyNo")
                            .SerialNo = pBody.Rows(i)("Barcode") 'grListOfProperty.SelectedDataKey("SerialNo")
                            .dDate = txtdate.Text
                            .Trans_Type = "Disposed as Donated"
                            .Ref = ""
                            .AccountablePerson = txtRAO.Text
                            .Department = txtTo.Text
                            .Position = ""
                            .AcceptedBy = ""
                            .InspectedBy = ""
                            .DebitQty = "0"
                            .DebitUnit = "-"
                            .DebitCost = "0.00"
                            '.CreditQty = ""
                            '.CreditUnit = ""
                            '.CreditCost = ""
                            '.BalanceQty = ""
                            '.BalanceUnit = ""
                            '.BalanceCost = ""

                            .Item_ID = pBody.Rows(i)("Item_ID")

                            .CreditQty = 1
                            .CreditUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & pBody.Rows(i)("Item_ID") & "'", CommandType.Text)
                            .CreditCost = CType(pBody.Rows(i)("Amount"), Decimal)

                            .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & pBody.Rows(i)("Item_ID") & "'", CommandType.Text)

                            Dim eQty As Integer
                            Dim eBalance As Decimal
                            Dim dtledger As New DataTable

                            dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & pBody.Rows(i)("Item_ID") & "'", CommandType.Text)
                            If dtledger.Rows.Count = 0 Then
                                eQty = 0
                                eBalance = 0.0
                            Else
                                eQty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & pBody.Rows(i)("Item_ID") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                                eBalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & pBody.Rows(i)("Item_ID") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                            End If

                            .BalanceQty = eQty - 1
                            .BalanceCost = CType(eBalance, Decimal) - CType(pBody.Rows(i)("Amount"), Decimal)
                        End With

                        objLedger.Ledger_ID = 0
                        objLedger.save()
                    End If

                    'End If

                    'CType(gvbody.Rows(i).FindControl("CheckBox1"), CheckBox).Enabled = False
                    'CType(gvbody.HeaderRow.FindControl("CheckBox2"), CheckBox).Enabled = False

                Next

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been succesfully saved.")

                txtTo.Text = ""
                txtRAO.Text = ""
                txtBy.Text = ""

                txtdate.ReadOnly = True
                btnnew.Enabled = True
                btnopen.Enabled = True
                btnsave.Enabled = False
                txtBy.ReadOnly = True
                txtRAO.ReadOnly = True
                txtTo.ReadOnly = True
                btnpreview.Enabled = True

                LoadrbChoice()


                'Else
                '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No records to save")
                'End If


            ElseIf rbChoice.SelectedItem.Value = 2 Then
                '=-= SUPPLIES
                'Session("chckbox") = 0
                'For i As Integer = 0 To Me.grdSuppDtl.Rows.Count - 1
                '    If CType(grdSuppDtl.Rows(i).FindControl("cbSupp"), CheckBox).Checked = True Then
                '        Session("chckbox") = 1
                '    End If
                'Next

                'If Session("chckbox") = 0 Then
                '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select property from the grid.")
                '    Exit Sub
                'End If

                '=-= SAVE DISPOSAL DONATION HEADER
                With hdr
                    .Disposa_date = txtdate.Text
                    .TransTo = txtTo.Text
                    .RAO = txtRAO.Text
                    .AuthorizedBy = txtBy.Text
                End With
                Dim hdrid As Long = hdr.save()

                objDerived.GetRecords("UPDATE AMS.Disposal_Donation_hdr SET IIRUS_ID = '" & Session("IIRUS_ID") & "' WHERE Disposal_Donation_hdr_id = '" & hdrid & "'", CommandType.Text)

                For i As Integer = 0 To Me.grdSuppDtl.Rows.Count - 1
                    'If CType(grdSuppDtl.Rows(i).FindControl("cbSupp"), CheckBox).Checked = True Then
                    '=-= SAVE DISPOSAL_DONATION DETAIL
                    With dtl
                        .Disposal_Donation_hdr_id = hdrid
                        .value = dtSupp.Rows(i)("AppraisedVal")
                    End With
                    Dim dtlID As Long = dtl.save()

                    objDerived.GetRecords("UPDATE AMS.Disposal_Donation_dtl SET StockDate = '" & dtSupp.Rows(i)("StockDate") & "', StockID = '" & dtSupp.Rows(i)("StockID") & "', Qty = '" & dtSupp.Rows(i)("Qty") & "' WHERE Disposal_Donation_dtl_id = '" & dtlID & "'", CommandType.Text)

                    '=-= UPDATE SUPPLY LEDGER
                    With objStockLedger
                        '.StockLedger_ID = StockLedger_ID
                        .StockID = dtSupp.Rows(i)("StockID")
                        .Trans_Type = "Disposed as Donation"
                        .Ref = ""
                        .AccountablePerson = txtBy.Text
                        .Department = txtTo.Text
                        .Position = ""
                        .AcceptedBy = txtRAO.Text
                        .InspectedBy = ""
                        .DebitQty = "0"
                        .DebitUnit = "-"
                        .DebitCost = "0.00"
                        '.CreditQty = ""
                        '.CreditUnit = ""
                        '.CreditCost = ""
                        '.BalanceQty = ""
                        '.BalanceUnit = ""
                        '.BalanceCost = ""

                        .dDate = txtdate.Text
                        .Item_ID = dtSupp.Rows(i)("item_id")

                        .CreditQty = dtSupp.Rows(i)("qty")
                        .CreditCost = dtSupp.Rows(i)("Cost")
                        .CreditUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & dtSupp.Rows(i)("item_id") & "'", CommandType.Text)

                        .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & dtSupp.Rows(i)("item_id") & "'", CommandType.Text)
                        .BalanceQty = 0
                        .BalanceCost = 0
                    End With

                    objStockLedger.save()
                    'End If
                Next

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been succesfully saved.")

                txtTo.Text = ""
                txtRAO.Text = ""
                txtBy.Text = ""

                dtIIRUS = objDerived.GetDataTable("EXEC [AMS].[sp_IIRUS_DonationList]", CommandType.Text)
                grdSupply.DataSource = dtIIRUS
                grdSupply.DataBind()

                dtIIRUS_Dtl = Nothing
                grdSuppDtl.DataSource = dtIIRUS_Dtl
                grdSuppDtl.DataBind()
            End If

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub btnpreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnpreview.Click
        Me.Page.Response.Redirect("~/Inventory/Disposal/t_rpt_donation.aspx")
    End Sub

    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                'item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvbody.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                End If
            Next
        Else
            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                'item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvbody.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
            Next
        End If
    End Sub
    Protected Sub gvNEW_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvNEW.PageIndexChanging
        Me.gvNEW.DataSource = CType(pNew, DataTable)
        Me.gvNEW.DataBind()
        gvNEW.SelectedIndex = -1
    End Sub
    Protected Sub gvbody_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvbody.PageIndexChanging

    End Sub

    Protected Sub btnnew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnew.Click

    End Sub
    Protected Sub gvbody_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To Me.gvbody.Rows.Count - 1
            Dim c As CheckBox = CType(Me.gvbody.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            If c.Checked = True Then
                txtTo.Enabled = True
                txtRAO.Enabled = True
                txtBy.Enabled = True
            End If
        Next

    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To Me.gvbody.Rows.Count - 1
            Dim c As CheckBox = CType(Me.gvbody.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            If c.Checked = True Then
                txtTo.Enabled = True
                txtRAO.Enabled = True
                txtBy.Enabled = True
            End If
        Next
    End Sub

    Protected Sub rbChoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadrbChoice()
    End Sub

    Protected Sub LoadrbChoice()
        If rbChoice.SelectedItem.Value = 1 Then
            Me.mvCategory.SetActiveView(Me.vwProperty)

            pNew = objDerived.GetDataTable("select * from ams.donationew", CommandType.Text)
            gvNEW.DataSource = pNew
            gvNEW.DataBind()

            pBody = Nothing
            gvbody.DataSource = pBody
            gvbody.DataBind()

            btnsave.Enabled = False


        ElseIf rbChoice.SelectedItem.Value = 2 Then
            Me.mvCategory.SetActiveView(Me.vwSupply)

            dtIIRUS = objDerived.GetDataTable("EXEC [AMS].[sp_IIRUS_DonationList]", CommandType.Text)
            grdSupply.DataSource = dtIIRUS
            grdSupply.DataBind()

            dtIIRUS_Dtl = Nothing
            grdSuppDtl.DataSource = dtIIRUS_Dtl
            grdSuppDtl.DataBind()

            btnsave.Enabled = False

        End If
    End Sub

    Protected Sub grdSupply_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Session("IIRUS_ID") = grdSupply.SelectedDataKey("IIRUS_ID")

            dtSupp = Nothing
            dtSupp = objDerived.GetDataTable("SELECT * FROM [dbo].[View_IIRUS_DisposalItems] WHERE IIRUS_ID = '" & Session("IIRUS_ID") & "' AND Disposal_id = 4 ", CommandType.Text)
            grdSuppDtl.DataSource = dtSupp
            grdSuppDtl.DataBind()

            txtdate.Text = Date.Today.ToString("MM/dd/yyyy")
            txtTo.Text = ""
            txtRAO.Text = ""
            txtBy.Text = ""

            btnsave.Enabled = True

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub cbAllSupp_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.grdSuppDtl.Rows.Count - 1

                Dim s As CheckBox = CType(Me.grdSuppDtl.Rows(i).Cells(0).FindControl("cbSupp"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                End If
            Next
        Else
            For i As Integer = 0 To Me.grdSuppDtl.Rows.Count - 1
                Dim s As CheckBox = CType(Me.grdSuppDtl.Rows(i).Cells(0).FindControl("cbSupp"), CheckBox)
                s.Checked = False
            Next
        End If
    End Sub

    Protected Sub cbSupp_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To Me.grdSuppDtl.Rows.Count - 1
            Dim c As CheckBox = CType(Me.grdSuppDtl.Rows(i).Cells(0).FindControl("cbSupp"), CheckBox)
            If c.Checked = True Then
                txtTo.Enabled = True
                txtRAO.Enabled = True
                txtBy.Enabled = True
            End If
        Next
    End Sub
End Class
