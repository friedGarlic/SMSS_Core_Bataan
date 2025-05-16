Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.HtmlControls
Imports System.IO


Partial Class Inventory_Disposal_t_destruction
    Inherits System.Web.UI.Page

    Dim objDerived As New DerivedDal
    Dim objLedger As New t_PropertyLedger
    Dim Ledger_ID As New Integer
    Dim dtPropLedger As New DataTable
    Dim msg As New MsgeBox
    Dim obj As New AccessRule

    Dim hdr As New Destruction.Disposal_Destruction_hdr
    Dim dtl As New Destruction.Disposal_Destruction_Dtl

    Dim objDonationLedger As New ConsolidatedPropertySaving.TbDonation_Ledger
    Dim DonationLedger_ID As New Integer
    Dim dtDonationLedger As New DataTable

    Private objMREReturn As New MRE_Return
    Dim objStockLedger As New t_StockLedger

#Region "property"
    Private Property pNew() As DataTable
        Get
            Return CType(Session("pNew"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pNew") = value
        End Set
    End Property
    Private Property pbody() As DataTable
        Get
            Return CType(Session("pbody"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pbody") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtdate.Text = Date.Today.ToString("MM/dd/yyyy")

            rbChoice.SelectedItem.Value = 1
            LoadrbChoice()

        End If
    End Sub

    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As Date
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                item = CType(gvbody.Rows(i).Cells(1).Text, Date)
                Dim s As CheckBox = CType(Me.gvbody.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                End If
            Next
        Else
            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                Item = gvbody.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvbody.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
            Next
        End If
    End Sub

    Protected Sub btnSAVE_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtAccountOfficer.Text = "" Or txtAuthorizedBy.Text = "" Then
            req.Visible = True
            req2.Visible = True
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up necessary information.")
            Exit Sub
        End If

        req.Visible = False
        req2.Visible = False
        Try
            'Dim rc As Integer
            'For o As Integer = 0 To gvbody.Rows.Count - 1
            '    If CType(gvbody.Rows(o).FindControl("CheckBox1"), CheckBox).Checked = True Then
            '        rc = rc + 1
            '    End If
            'Next
            'If rc >= 1 Then

            hdr.Destruction_Date = txtdate.Text
            hdr.Accountable_Officer = txtAccountOfficer.Text
            hdr.AuthorizedBy = txtAuthorizedBy.Text
            hdr.Remarks = txtRemarks.Text
            hdr.IIRUPHdr_ID = gvNEW.SelectedDataKey(0)

            Dim hdrid As Long = hdr.save()

            Me.Session("TransID") = hdrid

            For i As Integer = 0 To pbody.Rows.Count - 1
                'If CType(gvbody.Rows(i).FindControl("CheckBox1"), CheckBox).Checked = True Then
                '====== Disposal_Donation_dtl
                dtl.Destruction_Hdr_ID = hdrid
                dtl.PropertyNo = pbody.Rows(i)("PropertyNo")
                dtl.Property_ID = pbody.Rows(i)("Property_ID")
                dtl.value = pbody.Rows(i)("val")
                dtl.Property_Date = pbody.Rows(i)("Property_Date")
                dtl.save()

                Dim qty As Integer = Val(objDerived.GetValue("SELECT AMS.Property.qty FROM AMS.Property INNER JOIN AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID WHERE     AMS.Property_Dtl.PropertyNo ='" & pbody.Rows(i)("PropertyNo") & "'", CommandType.Text))
                Dim balance As Integer = Val(objDerived.GetValue("exec AMS.getbalance '" & pbody.Rows(i)("PropertyNo") & "'", CommandType.Text))
                Dim issuance As Integer = Val(objDerived.GetValue("exec AMS.getIssuance '" & pbody.Rows(i)("PropertyNo") & "'", CommandType.Text))

                balance = Val(objDerived.GetValue("exec AMS.getbalance '" & pbody.Rows(i)("PropertyNo") & "'", CommandType.Text))
                issuance = Val(objDerived.GetValue("exec AMS.getIssuance '" & pbody.Rows(i)("PropertyNo") & "'", CommandType.Text))
                objDerived.GetRecords("Update AMS.Property set qty='" & IIf(qty = 0, 0, qty - 1) & "',Balance='" & IIf(balance = 0, 0, balance - 1) & "' where  Property_ID='" & pbody.Rows(i)("Property_ID") & "'", CommandType.Text)
                objDerived.GetRecords("Update AMS.Property_Dtl SET DisposeDate='" & txtdate.Text & "',Dispose ='True'  WHERE PropertyNo='" & pbody.Rows(i)("PropertyNo") & "'", CommandType.Text)

                'MRE_Returns
                objMREReturn.MRE_Dtl = 0
                objMREReturn.PropertyNo = pbody.Rows(i)("PropertyNo")
                objMREReturn.MRE_Date = txtdate.Text
                objMREReturn.Status = "Disposed"
                objMREReturn.Remarks = "Destroy"
                objMREReturn.Dispose = True
                objMREReturn.Repair = False
                objMREReturn.Inspection = False
                objMREReturn.deptid = 0
                objMREReturn.UpdateMREReturn()


                If pbody.Rows(i)("isDonated") = True Then
                    '==== Update Ledger Donations ==== 
                    dtDonationLedger = objDonationLedger.GetDataTable("Select DonationLedger_ID from AMS.TbDonation_Ledger", CommandType.Text)
                    With objDonationLedger
                        '.DonationLedger_ID = DonationLedger_ID
                        .PropertyNo = pbody.Rows(i)("PropertyNo")
                        .SerialNo = IIf(IsDBNull(pbody.Rows(i)("Barcode").ToString), 0, (pbody.Rows(i)("Barcode").ToString))
                        .Trans_Type = "Disposed as Destruction"
                        .Ref = ""
                        .AccountablePerson = txtAccountOfficer.Text
                        .Department = ""
                        .Position = ""
                        .AcceptedBy = ""
                        .InspectedBy = ""
                        .Item_ID = pbody.Rows(i)("Item_ID")

                        .DebitQty = "0"
                        .DebitUnit = "-"
                        .DebitCost = "0.00"

                        .CreditQty = 1
                        .CreditUnit = pbody.Rows(i)("Unit")
                        .CreditCost = CType(pbody.Rows(i)("Amount"), Decimal)

                        .BalanceQty = 0
                        .BalanceUnit = "-" 'objDerived.GetValue("SELECT AMS.m_Unit.Description FROM dbo.m_item INNER JOIN AMS.m_Unit ON dbo.m_item.Unit_ID = AMS.m_Unit.Unit_ID where Item_ID ='" & grListOfProperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                        .BalanceCost = CType(0, Decimal)
                        .dDate = txtdate.Text


                    End With
                    objDonationLedger.DonationLedger_ID = 0
                    objDonationLedger.save()

                Else
                    '==== Update Ledger ====
                    dtPropLedger = objLedger.GetDataTable("Select Ledger_ID from AMS.TbProperty_Ledger", CommandType.Text)
                    With objLedger
                        '.Ledger_ID = Ledger_ID
                        .PropertyNo = pbody.Rows(i)("PropertyNo")
                        .SerialNo = pbody.Rows(i)("Barcode") 'grListOfProperty.SelectedDataKey("SerialNo")
                        .dDate = txtdate.Text
                        .Trans_Type = "Disposed as Destruction"
                        .Ref = ""
                        .AccountablePerson = txtAccountOfficer.Text
                        .Department = ""
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

                        .Item_ID = pbody.Rows(i)("Item_ID")

                        .CreditQty = 1
                        .CreditUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & pbody.Rows(i)("Item_ID") & "'", CommandType.Text)
                        .CreditCost = CType(pbody.Rows(i)("Amount"), Decimal)

                        .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & pbody.Rows(i)("Item_ID") & "'", CommandType.Text)

                        Dim eQty As Integer
                        Dim eBalance As Decimal
                        Dim dtledger As New DataTable

                        dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & pbody.Rows(i)("Item_ID") & "'", CommandType.Text)
                        If dtledger.Rows.Count = 0 Then
                            eQty = 0
                            eBalance = 0.0
                        Else
                            eQty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & pbody.Rows(i)("Item_ID") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                            eBalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & pbody.Rows(i)("Item_ID") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                        End If

                        .BalanceQty = eQty - 1
                        .BalanceCost = CType(eBalance, Decimal) - CType(pbody.Rows(i)("Amount"), Decimal)
                    End With

                    objLedger.Ledger_ID = 0
                    objLedger.save()
                End If


                'End If

                'CType(gvbody.Rows(i).FindControl("CheckBox1"), CheckBox).Enabled = False
                'CType(gvbody.HeaderRow.FindControl("CheckBox2"), CheckBox).Enabled = False

            Next
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been succesfully saved.")


            txtdate.ReadOnly = True
            txtAccountOfficer.ReadOnly = True
            txtAuthorizedBy.ReadOnly = True
            txtRemarks.ReadOnly = True
            btnSAVE.Enabled = False
            btnPREVIEW.Enabled = True

            pNew = objDerived.GetDataTable("Select * from dbo.View_Disposal_Destruction", CommandType.Text)
            gvNEW.DataSource = pNew
            gvNEW.DataBind()

            'Else
            '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No records to save.")
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gvNEW_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtAccountOfficer.ReadOnly = False
        txtAuthorizedBy.ReadOnly = False
        txtRemarks.ReadOnly = False

        txtAccountOfficer.Text = ""
        txtAuthorizedBy.Text = ""
        txtRemarks.Text = ""

        pbody = Nothing
        gvbody.DataSource = pbody
        gvbody.DataBind()

        pbody = objDerived.GetDataTable("Exec [AMS].[sp_Destruction_dtl_report] '" & gvNEW.SelectedDataKey(0) & "'", CommandType.Text)
        gvbody.DataSource = pbody
        gvbody.DataBind()
    End Sub

    Protected Sub rbChoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadrbChoice()
    End Sub

    Protected Sub LoadrbChoice()
        If rbChoice.SelectedItem.Value = 1 Then
            Me.mvCategory.SetActiveView(Me.vwProperty)
            btnSave.visible = True
            btnSaveSupp.visible = False
            pNew = Nothing
            pNew = objDerived.GetDataTable("Select * from dbo.View_Disposal_Destruction", CommandType.Text)
            gvNEW.DataSource = pNew
            gvNEW.DataBind()

            pbody = Nothing
            gvbody.DataSource = pbody
            gvbody.DataBind()

        ElseIf rbChoice.SelectedItem.Value = 2 Then
            Me.mvCategory.SetActiveView(Me.vwSupply)
            btnSave.visible = False
            btnSaveSupp.visible = True

            'Dim dt1 As New DataTable
            'dt1 = objDerived.GetDataTable("", CommandType.Text)

            pNew = Nothing
            pNew = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Disposal_Destruction_IIRUS] WHERE Destruction_Hdr_ID = 0", CommandType.Text)
            grdSupply.DataSource = pNew
            grdSupply.DataBind()

            pbody = Nothing
            grdSupplyItems.DataSource = pbody
            grdSupplyItems.DataBind()

        End If
    End Sub

    Protected Sub grdSupply_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtAccountOfficer.ReadOnly = False
        txtAuthorizedBy.ReadOnly = False
        txtRemarks.ReadOnly = False

        txtAccountOfficer.Text = ""
        txtAuthorizedBy.Text = ""
        txtRemarks.Text = ""

        Session("IIRUS_ID") = grdSupply.SelectedDataKey("IIRUS_ID")

        pbody = Nothing
        pbody = objDerived.GetDataTable("SELECT * FROM dbo.View_IIRUS_DisposalItems WHERE IIRUS_ID = '" & Session("IIRUS_ID") & "'", CommandType.Text)
        grdSupplyItems.DataSource = pbody
        grdSupplyItems.DataBind()
    End Sub

    Protected Sub btnSaveSupp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtAccountOfficer.Text = "" Or txtAuthorizedBy.Text = "" Then
            req.Visible = True
            req2.Visible = True
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up necessary information.")
            Exit Sub
        End If

        req.Visible = False
        req2.Visible = False

        Try
            '=-= SAVE AMS.Disposal_Destruction_hdr
            With hdr
                .Destruction_Date = txtdate.Text
                .Accountable_Officer = txtAccountOfficer.Text
                .AuthorizedBy = txtAuthorizedBy.Text
                .Remarks = txtRemarks.Text
                .IIRUPHdr_ID = 0
            End With
            Dim hdrid As Long = hdr.save()

            objDerived.GetRecords("UPDATE AMS.Disposal_Destruction_hdr SET IIRUS_ID = '" & Session("IIRUS_ID") & "' WHERE Destruction_Hdr_ID = '" & hdrid & "'", CommandType.Text)

            '=-= SAVE AMS.Disposal_Destruction_Dtl
            For i As Integer = 0 To pbody.Rows.Count - 1
                With dtl
                    .Destruction_Hdr_ID = hdrid
                    .PropertyNo = 0
                    .Property_ID = 0
                    .value = pbody.Rows(i)("AppraisedVal")
                    .Property_Date = "01/01/1990"
                End With
                Dim dtlID As Long = dtl.save()

                objDerived.GetRecords("UPDATE AMS.Disposal_Destruction_Dtl SET StockID = '" & pbody.Rows(i)("StockID") & "', StockDate = '" & pbody.Rows(i)("StockDate") & "', Qty = '" & pbody.Rows(i)("Qty") & "' WHERE Destruction_Dtl_ID = '" & dtlID & "'", CommandType.Text)

                '=-= UPDATE SUPPLY LEDGER
                With objStockLedger
                    '.StockLedger_ID = StockLedger_ID
                    .StockID = pbody.Rows(i)("StockID")
                    .Trans_Type = "Disposed as Destruction"
                    .Ref = ""
                    .AccountablePerson = txtAccountOfficer.Text
                    .Department = ""
                    .Position = ""
                    .AcceptedBy = txtAuthorizedBy.Text
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
                    .Item_ID = pbody.Rows(i)("Item_ID")

                    .CreditQty = pbody.Rows(i)("Qty")
                    .CreditCost = pbody.Rows(i)("Cost")
                    .CreditUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & pbody.Rows(i)("Item_ID") & "'", CommandType.Text)

                    .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & pbody.Rows(i)("Item_ID") & "'", CommandType.Text)
                    .BalanceQty = 0
                    .BalanceCost = 0
                    .save()
                End With
            Next


            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            pNew = Nothing
            pNew = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Disposal_Destruction_IIRUS] WHERE Destruction_Hdr_ID = 0", CommandType.Text)
            grdSupply.DataSource = pNew
            grdSupply.DataBind()

            pbody = Nothing
            grdSupplyItems.DataSource = pbody
            grdSupplyItems.DataBind()

            txtAccountOfficer.Text = ""
            txtAuthorizedBy.Text = ""
            txtRemarks.Text = ""

        Catch ex As Exception
        End Try
    End Sub
End Class
