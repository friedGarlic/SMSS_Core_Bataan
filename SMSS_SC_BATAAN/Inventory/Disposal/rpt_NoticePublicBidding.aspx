<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_NoticePublicBidding.aspx.vb" Inherits="Inventory_Disposal_rpt_NoticePublicBidding" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>NOTICE OF PUBLIC BIDDING</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
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
                frame.src = "rpt_NoticePublicBidding.aspx?print=1&t=" + new Date().getTime();
            }
        </script>

        <iframe id="pdfPrintFrame" style="display:none; width:0; height:0; border:0;"></iframe>

        <div title="Notice of Public Bidding">
            <table width="1020px" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 1%"></td>
                    <td style="width: 98%" class="PageTitle">NOTICE OF PUBLIC BIDDING</td>
                    <td style="width: 1%"></td>
                </tr>
                <tr>
                    <td style="width: 1%"></td>
                    <td style="width: 98%" align="left">
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
                <tr>
                    <td style="width: 1%"></td>
                    <td style="width: 98%" align="center">
                        <div style="width: 1000px; background-color: #808080; text-align: center; vertical-align: middle">
                            <table width="100%">
                                <tr>
                                    <td style="width: 100%; height: 10px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" align="center">
                                        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"
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
                                            <Report FileName="rpt_Notice_PubBidding.rpt">
                                            </Report>
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
            </table>
        </div>
    </form>
</body>
</html>