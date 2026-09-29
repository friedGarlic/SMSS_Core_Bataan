Imports System.Data
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class rpt_order_of_payment
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument

    Private Sub rpt_order_of_payment_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Session("Page") = "ISSP_List" Then

            If Not IsPostBack Then

                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_order_of_payment.rpt"))
                rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                rpt.SetParameterValue("@SuppName", Me.Session("SuppName"))
                rpt.SetParameterValue("@Amount", CType(Me.Session("op1_Amt"), Decimal))
                Session("OrderOfPayment_Report") = rpt

            Else

                rpt = CType(Session("OrderOfPayment_Report"), ReportDocument)

                If rpt Is Nothing Then

                    rpt = New ReportDocument()
                    rpt.Load(Server.MapPath("rpt_order_of_payment.rpt"))
                    rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                    rpt.SetParameterValue("@SuppName", Me.Session("SuppName"))
                    rpt.SetParameterValue("@Amount", CType(Me.Session("op1_Amt"), Decimal))
                    Session("OrderOfPayment_Report") = rpt

                End If

            End If

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.OrderPaymentReports.ReportSource = rpt

        ElseIf Session("Page") = "Auction" Then

            If Not IsPostBack Then

                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_order_of_payment.rpt"))
                rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                rpt.SetParameterValue("@SuppName", Me.Session("SuppName"))
                rpt.SetParameterValue("@Amount", CType(Me.Session("Amount"), Decimal))
                Session("OrderOfPayment_Report") = rpt

            Else

                rpt = CType(Session("OrderOfPayment_Report"), ReportDocument)

                If rpt Is Nothing Then

                    rpt = New ReportDocument()
                    rpt.Load(Server.MapPath("rpt_order_of_payment.rpt"))
                    rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                    rpt.SetParameterValue("@SuppName", Me.Session("SuppName"))
                    rpt.SetParameterValue("@Amount", CType(Me.Session("Amount"), Decimal))
                    Session("OrderOfPayment_Report") = rpt

                End If

            End If

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.OrderPaymentReports.ReportSource = rpt

        ElseIf Session("Page") = "NOA" Then

            If Not IsPostBack Then

                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_order_of_payment.rpt"))
                rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                rpt.SetParameterValue("@SuppName", Me.Session("SuppName"))
                rpt.SetParameterValue("@Amount", CType(Me.Session("Amount"), Decimal))
                Session("OrderOfPayment_Report") = rpt

            Else

                rpt = CType(Session("OrderOfPayment_Report"), ReportDocument)

                If rpt Is Nothing Then

                    rpt = New ReportDocument()
                    rpt.Load(Server.MapPath("rpt_order_of_payment.rpt"))
                    rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                    rpt.SetParameterValue("@SuppName", Me.Session("SuppName"))
                    rpt.SetParameterValue("@Amount", CType(Me.Session("Amount"), Decimal))
                    Session("OrderOfPayment_Report") = rpt

                End If

            End If

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.OrderPaymentReports.ReportSource = rpt

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' When the page is opened with ?print=1, export the report that is
        ' already in Session to PDF and stream it straight to the browser.
        ' This replaces the normal HTML output so the report opens in the
        ' browser's PDF viewer, ready to print, with all pages included.
        If Request.QueryString("print") = "1" Then

            Dim rptPrint As ReportDocument = CType(Session("OrderOfPayment_Report"), ReportDocument)

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect("~/Inventory/disposal/Disposal_ISSP_List.aspx")
                Return
            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "OrderOfPayment")

            Me.Page.Response.End()

        End If

    End Sub

    Private Sub rpt_order_of_payment_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click
        If Session("Page") = "ISSP_List" Then
            Me.Page.Response.Redirect("~/Inventory/disposal/Disposal_ISSP_List.aspx")

        ElseIf Session("Page") = "Quotation" Then
            Me.Page.Response.Redirect("~/Inventory/disposal/Disposal_Quotation.aspx")

        ElseIf Session("Page") = "NOA" Then
            Me.Page.Response.Redirect("~/Inventory/disposal/Disposal_Notice.aspx")

        End If
    End Sub

End Class