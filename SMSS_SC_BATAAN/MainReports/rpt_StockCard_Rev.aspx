<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rpt_StockCard_Rev.aspx.vb" Inherits="MainReports_rpt_StockCard_Rev" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript">
        function PrintReport() {
            var frame = document.getElementById("pdfPrintFrame");
            if (!frame) {
                alert("Print frame not found.");
                return;
            }

            // Reset any previous handler so we do not trigger print twice.
            frame.onload = null;

            frame.onload = function () {
                // Small delay so the PDF viewer finishes initializing
                // before we ask it to print.
                setTimeout(function () {
                    try {
                        frame.contentWindow.focus();
                        frame.contentWindow.print();
                    } catch (e) {
                        alert("Could not open the print dialog automatically. The report will be shown so you can print it manually.");
                        frame.style.display = "block";
                        frame.style.width = "100%";
                        frame.style.height = "900px";
                    }
                }, 800);
            };

            // Cache-buster so the browser always reloads the PDF fresh.
            frame.src = "rpt_StockCard_Rev.aspx?print=1&t=" + new Date().getTime();
        }
    </script>

    <iframe id="pdfPrintFrame" style="display:none; width:0; height:0; border:0;"></iframe>

    <div>
        <table width="1020px" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">STOCK CARD REPORT
                </td>
                <td style="width: 1%"></td>
            </tr>

            <!-- ===== Block A: Back button ===== -->
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="column_Left">
                    <table width="1000px" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="lnkBackPrevious" runat="server" Font-Underline="true" CssClass="LinkBtnSelect" Text="Back To Previous Page ...">
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 1%"></td>
            </tr>

            <tr>
                <td colspan="3" style="height:10px;"></td>
            </tr>

            <!-- ===== Block C: Print button — ALWAYS directly above Block D ===== -->
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="column_Center">
                    <table width="1000px" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="right">
                                <asp:LinkButton ID="btnPrintReport" runat="server" CssClass="LinkBtnSelect" OnClientClick="PrintReport(); return false;">Print Report</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 1%"></td>
            </tr>

            <!-- ===== Block D: Report viewer container ===== -->
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="column_Center">
                    <div style="width: 1000px; background-color: #808080; text-align: center; vertical-align: middle">
                        <table width="100%">
                            <tr>
                                <td style="width: 100%; height: 10px"></td>
                            </tr>
                            <tr>
                                <td style="width: 100%" align="center">
                                    <CR:CrystalReportViewer ID="StockCardReport" runat="server"
                                        AutoDataBind="true"
                                        HasToggleGroupTreeButton="False"
                                        HasCrystalLogo="False"
                                        HasSearchButton="False"
                                        HasDrilldownTabs="False"
                                        BestFitPage="False"
                                        BackColor="#ffffff"
                                        Height="930px"
                                        Width="980px"
                                        BorderStyle="Solid"
                                        BorderColor="#2977dc"
                                        BorderWidth="1px"
                                        ToolPanelView="None"
                                        HasGroupTree="False"
                                        HasPrintButton="False" />
                                  
                                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">       
                                        <Report FileName="~\Records\rpt_StockCard_v2.rpt"></Report>
                                    </CR:CrystalReportSource>

                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100%; height: 10px"></td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%; height: 10px"></td>
                <td style="width: 1%"></td>
            </tr>
        </table>
    </div>

    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>