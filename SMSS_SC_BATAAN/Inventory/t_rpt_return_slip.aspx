<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" 
CodeFile="t_rpt_return_slip.aspx.vb" Inherits="Inventory_t_rpt_return_slip" 
title="Property Return Slip" StylesheetTheme="SkinFile"  %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Contetnt1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
            frame.src = "t_rpt_return_slip.aspx?print=1&t=" + new Date().getTime();
        }
    </script>

    <iframe id="pdfPrintFrame" style="display:none; width:0; height:0; border:0;"></iframe>

    <div>
        <table width="1020px" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width:1%"></td>
                <td style="width:98%" align="left">
                    <table width="1000px" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="LinkBtnSelect">Back to previous page...</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:LinkButton ID="btnPrintReport" runat="server" CssClass="LinkBtnSelect" OnClientClick="PrintReport(); return false;">Print Report</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width:1%"></td>
            </tr>
            <tr>
                <td style="width:1%"></td>
                <td style="width:98%" align="center">
                    <div style="width: 1000px; background-color: #808080; text-align: center; vertical-align: middle">
                        <table width="100%">
                            <tr>
                                <td style="width:100%; height:10px"></td>
                            </tr>
                            <tr>
                                <td style="width:100%" align="center">
                                    <CR:CrystalReportViewer ID="ReturnSlipReports" runat="server"
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

                                    <CR:CrystalReportViewer ID="PRS_EndUser" runat="server"
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
                                        <Report FileName="PRS_v2.rpt">
                                        </Report>
                                    </CR:CrystalReportSource>
                                    <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                                        <Report FileName="rpt_Temp_PRS.rpt">
                                        </Report>
                                    </CR:CrystalReportSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:100%; height:10px"></td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width:1%"></td>
            </tr>
        </table>
    </div>
</asp:Content>