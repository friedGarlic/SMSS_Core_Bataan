Imports System
Imports System.Data
Partial Class Inventory_Disposal_Disposal_ReportEncoding
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal

    Private Sub Inventory_Disposal_Disposal_ReportEncoding_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Session("Report") = "Notice_COA"

        If Not Page.IsPostBack Then
            If Session("Report") = "NTP" Then
                lnkBack.Visible = False
                Dim dt As New DataTable
                dt = objDerived.GetDataTable("EXEC [AMS].[sp_Disposal_NTP_ReportEncoding] '" & Session("IsspHdr_ID") & "'", CommandType.Text)


                lblNTP_ISSPNo.Text = "ISSP NO. " + dt.Rows(0)("ISSP_No")
                lblNTP_Date.Text = dt.Rows(0)("NTP_Date")
                lblNTP_Rep.Text = dt.Rows(0)("ContactP")
                lblNTP_SuppName.Text = dt.Rows(0)("SuppName")
                lblNTP_Address.Text = dt.Rows(0)("Address1")
                lblNTP_Rep2.Text = dt.Rows(0)("ContactP")
                lblNTP_ApprovedBy.Text = dt.Rows(0)("ApprovedBy")
                lblNTP_ApprovedByPosition.Text = dt.Rows(0)("ApprovedBy_Pos")

                txtNTP_Content.Text = dt.Rows(0)("NTP_Content1") + vbCrLf + vbCrLf + dt.Rows(0)("NTP_Content2")

                mvDisposal.SetActiveView(Me.vwNTP)

            ElseIf Session("Report") = "Accntg" Then
                lnkBack.Visible = False

                Dim dt As New DataTable
                dt = objDerived.GetDataTable("EXEC [AMS].[sp_Disposal_Acctng_ReportEncoding] '" & Session("IsspHdr_ID") & "'", CommandType.Text)

                lblAccntng_Date.Text = CType(dt.Rows(0)("NTP_Date"), Date).ToShortDateString
                lblAccntng_CAO.Text = dt.Rows(0)("CAO")
                lblAccntng_COA_Pos.Text = dt.Rows(0)("CAO_Pos")
                lblAccntng_CAO2.Text = dt.Rows(0)("CAO")
                lblAccntng_GSO.Text = dt.Rows(0)("GSO")
                lblAccntng_GSO_Pos.Text = dt.Rows(0)("GSO_Pos")
                lblAccntng_ISSPNo.Text = "ISSP No. " + dt.Rows(0)("Issp_No")

                txtAccntng_Content.Text = dt.Rows(0)("Content1") + vbCrLf + vbCrLf + dt.Rows(0)("Content2") + vbCrLf + vbCrLf + dt.Rows(0)("Content3") + vbCrLf + vbCrLf + dt.Rows(0)("Content4")


                mvDisposal.SetActiveView(Me.vwAccntng)

            ElseIf Session("Report") = "Notice_COA" Then
                lnkBack.Visible = True
                txtCOA_Date.Text = Date.Today.ToShortDateString

                Dim dt As New DataTable
                dt = objDerived.GetDataTable("SELECT A.IsspHdr_ID, 'The Provincial Government of Cagayan will conduct public auction for the disposal of unserviceable properties on ' + DATENAME(WEEKDAY,A.AuctionDate) + ', ' + DATENAME(MONTH,A.AuctionDate) + ' '                       " &
                                               "         + Convert(VARCHAR(2), Day(a.AuctionDate)) + ', ' + CONVERT(VARCHAR(4),YEAR(A.AuctionDate)) + ' at ' + A.AuctionTime + ' at the ' + A.AuctionLocation + ' as per attached Invitation to Submit Sealed Proposal (ISSP) # '   " &
                                               "         + A.Issp_No AS P1, 'In this regard, we would like to request a representative from your office to observe the conduct of the aforementioned public action.' AS P2                                                          " &
                                               "         , 'Your interest on this matter would be very much appreciated. Thank you very much.' AS P3                                                                                                                                " &
                                               "         , (SELECT Full_Name FROM HRMS.view_signatory WHERE deptid = 123 AND division_Key = 86 AND isDeptHead = 'Yes') AS COA                                                                                                       " &
                                               "         , (SELECT position_desc FROM HRMS.view_signatory WHERE deptid = 123 AND division_Key = 86 AND isDeptHead = 'Yes') AS COA_Pos                                                                                               " &
                                               "         , (SELECT RC_Name FROM DBO.View_RespCenter_withFunctions WHERE RC_ID = 123 AND Function_ID = 86) AS RC_Name                                                                                                                " &
                                               "         , 'Tuguegarao City' AS LGU                                                                                                                                                                                                      " &
                                               "         , 'Very truly yours,' AS P4                                                                                                                                                                                                " &
                                               "         , (SELECT Full_Name FROM HRMS.view_signatory WHERE deptid = 4 AND division_Key = 86 AND isDeptHead = 'Yes') AS CAdmin                                                                                                      " &
                                               "         , (SELECT position_desc FROM HRMS.view_signatory WHERE deptid = 4 AND division_Key = 86 AND isDeptHead = 'Yes') AS CAdmin_Pos                                                                                              " &
                                               "     FROM AMS.tbl_ISSP_hdr AS A WHERE A.IsspHdr_ID = '" & Session("IsspHdr_ID") & "'", CommandType.Text)


                txtCOA_Content.Text = dt.Rows(0)("COA") + Environment.NewLine +
                                        dt.Rows(0)("COA_Pos") + Environment.NewLine +
                                        dt.Rows(0)("RC_Name") + Environment.NewLine +
                                        dt.Rows(0)("LGU") + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                        "Dear " + dt.Rows(0)("COA") + "," + Environment.NewLine + Environment.NewLine +
                                        dt.Rows(0)("P1") + Environment.NewLine + Environment.NewLine +
                                        dt.Rows(0)("P2") + Environment.NewLine + Environment.NewLine +
                                        dt.Rows(0)("P3") + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                        dt.Rows(0)("P4") + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                        dt.Rows(0)("CAdmin") + Environment.NewLine +
                                        dt.Rows(0)("CAdmin_Pos")

                mvDisposal.SetActiveView(Me.vwNoticeCOA)

            Else

            End If

        End If
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Private Sub btnNTP_Preview_Click(sender As Object, e As EventArgs) Handles btnNTP_Preview.Click

        objDerived.Execute("UPDATE AMS.tbl_ISSP_hdr SET NTP_Content = '" & replaceapostrophe(txtNTP_Content.Text) & "' WHERE IsspHdr_ID = '" & Session("IsspHdr_ID") & "'", CommandType.Text)

        Session("Report") = "NTP"
        btnNTP_Preview.Enabled = False
        Me.Page.Response.Redirect("~/MainReports/Disposal_Notices.aspx")
    End Sub



    Private Sub btnAccntng_Save_Click(sender As Object, e As EventArgs) Handles btnAccntng_Save.Click
        objDerived.Execute("UPDATE AMS.tbl_ISSP_hdr SET Accntng_Content = '" & replaceapostrophe(txtAccntng_Content.Text) & "' WHERE IsspHdr_ID = '" & Session("IsspHdr_ID") & "'", CommandType.Text)

        Session("Report") = "Accntg"
        btnAccntng_Save.Enabled = False
        Me.Page.Response.Redirect("~/MainReports/Disposal_Notices.aspx")
    End Sub

    Private Sub Inventory_Disposal_Disposal_ReportEncoding_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub btnSave_NoticeCOA_Click(sender As Object, e As EventArgs) Handles btnSave_NoticeCOA.Click
        Try

            Dim id As Integer = objDerived.GetValue("SELECT [disposal_notice_coa_id] FROM [AMS].[tbl_rpt_disposal_notice_coa] WHERE [IsspHdr_ID] = '" & Session("IsspHdr_ID") & "'", CommandType.Text)
            If id = 0 Then
                objDerived.Execute("INSERT INTO [AMS].[tbl_rpt_disposal_notice_coa] ([IsspHdr_ID],[notice_date],[rpt_content])          " &
                              " VALUES                                                                                                  " &
                              " ('" & Session("IsspHdr_ID") & "'                                                                        " &
                              " , '" & CType(txtCOA_Date.Text, Date) & "'                                                               " &
                              " , '" & replaceapostrophe(txtCOA_Content.Text) & "')", CommandType.Text)

            Else
                objDerived.Execute("UPDATE [AMS].[tbl_rpt_disposal_notice_coa] SET [notice_date] = '" & CType(txtCOA_Date.Text, Date) & "', [rpt_content] = '" & replaceapostrophe(txtCOA_Content.Text) & "' WHERE [disposal_notice_coa_id] = '" & id & "'", CommandType.Text)

            End If


            Me.Page.Response.Redirect("~/MainReports/Disposal_Notices.aspx")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click
        Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_ISSP_List.aspx")

    End Sub


End Class
