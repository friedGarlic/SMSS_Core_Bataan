<%@ Page Title="Disposal Notices" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Disposal_Notices.aspx.vb"
    Inherits="MainReports_Disposal_Notice" StylesheetTheme="SkinFile" %>

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
            frame.src = "Disposal_Notices.aspx?print=1&t=" + new Date().getTime();
        }
    </script>

    <iframe id="pdfPrintFrame" style="display:none; width:0; height:0; border:0;"></iframe>

    <div>
        <table width="1020px" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">DISPOSAL REPORTS
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <table width="1000px" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left">
                                <asp:LinkButton runat="server" ID="lnkBack" CssClass="LinkBtnSelect" Text="Back to previous page ..."></asp:LinkButton>
                            </td>
                        </tr>
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
                    <asp:Panel runat="server" ID="pnlDate" Visible="false" Width="100%">
                        <span class="column_RightBold">Date :</span>
                        &nbsp;<asp:TextBox runat="server" ID="txtDate" CssClass="txtbox_Date" Width="12%" MaxLength="10"></asp:TextBox>
                        &nbsp;<asp:Button runat="server" ID="btnPreview_Conspicuous" Width="12%" Text="Preview" CssClass="CSButton" />
                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtDate" PopupButtonID="txtDate" PopupPosition="TopLeft"></cc1:CalendarExtender>
                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtDate" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                    </asp:Panel>
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

                                    <CR:CrystalReportViewer ID="Disposal_NOA" runat="server"
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
                                    <CR:CrystalReportSource ID="Crystalreportsource1" runat="server">
                                        <Report FileName="rpt_Disposal_NOA.rpt"></Report>
                                    </CR:CrystalReportSource>

                                    <CR:CrystalReportViewer ID="Disposal_NTP" runat="server"
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
                                    <CR:CrystalReportSource ID="Crystalreportsource2" runat="server">
                                        <Report FileName="rpt_Disposal_NTP.rpt"></Report>
                                    </CR:CrystalReportSource>

                                    <CR:CrystalReportViewer ID="Disposal_Accntng" runat="server"
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
                                    <CR:CrystalReportSource ID="Crystalreportsource3" runat="server">
                                        <Report FileName="rpt_Disposal_Accntng.rpt"></Report>
                                    </CR:CrystalReportSource>

                                    <CR:CrystalReportViewer ID="DisposalWMR" runat="server"
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
                                    <CR:CrystalReportSource ID="Crystalreportsource4" runat="server">
                                        <Report FileName="rpt_WasteMaterialReport_v2.rpt"></Report>
                                    </CR:CrystalReportSource>

                                    <CR:CrystalReportViewer ID="DisposalChecklist" runat="server"
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
                                    <CR:CrystalReportSource ID="Crystalreportsource5" runat="server">
                                        <Report FileName="rpt_checklistunserviceableppe.rpt"></Report>
                                    </CR:CrystalReportSource>

                                    <CR:CrystalReportViewer ID="DisposalChecklist_OE" runat="server"
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
                                    <CR:CrystalReportSource ID="Crystalreportsource7" runat="server">
                                        <Report FileName="rpt_checklistunserviceable_OE.rpt"></Report>
                                    </CR:CrystalReportSource>

                                    <CR:CrystalReportViewer ID="Disposal_AppraisalReport" runat="server"
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
                                    <CR:CrystalReportSource ID="Crystalreportsource6" runat="server">
                                        <Report FileName="rpt_Disposal_Appraisal.rpt"></Report>
                                    </CR:CrystalReportSource>

                                    <CR:CrystalReportViewer ID="Disposal_NoticeCOA" runat="server"
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
                                    <CR:CrystalReportSource ID="Crystalreportsource8" runat="server">
                                        <Report FileName="rpt_Disposal_NoticeCOA.rpt"></Report>
                                    </CR:CrystalReportSource>

                                    <CR:CrystalReportViewer ID="Disposal_NoticeConspicuous" runat="server"
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
                                    <CR:CrystalReportSource ID="Crystalreportsource9" runat="server">
                                        <Report FileName="rpt_Disposal_NoticeConspicuous.rpt"></Report>
                                    </CR:CrystalReportSource>

                                    <CR:CrystalReportViewer ID="Disposal_SummaryWMR" runat="server"
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
                                    <CR:CrystalReportSource ID="Crystalreportsource10" runat="server">
                                        <Report FileName="rpt_Summary_WMR.rpt"></Report>
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
                <td style="width: 98%"></td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%"></td>
                <td style="width: 1%"></td>
            </tr>
        </table>
    </div>

</asp:Content>