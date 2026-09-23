<%@ Page Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="rpt_Property_Acknowledgement_Receipt_Report.aspx.vb" 
    Inherits="Reports_and_Query_rpt_Property_Acknowledgement_Receipt_Report" 
    Title ="Property Acknowledgement Receipt" 
    StylesheetTheme="SkinFile"%>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

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
            frame.src = "rpt_Property_Acknowledgement_Receipt_Report.aspx?print=1&t=" + new Date().getTime();
        }
    </script>

    <iframe id="pdfPrintFrame" style="display:none; width:0; height:0; border:0;"></iframe>

    <div>
        <table width="1020px" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">PROPERTY ACKNOWLEDGEMENT RECEIPT</td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
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
                    <asp:RadioButtonList id="RadioButtonList1" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="1">Report Format 1</asp:ListItem>
                        <asp:ListItem Value="2">Report Format 2</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View1" runat="server">
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
                                                <Report FileName="rpt_Property_Acknowledgement_Receipt.rpt">
                                                </Report>
                                            </CR:CrystalReportSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 10px"></td>
                                    </tr>
                                </table>
                            </div>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <table width="100%">
                                <tr>
                                    <td class="column_LeftBold">
                                        Noted By : <asp:DropDownList ID="drpNotedBy" runat="server" CssClass="drpdownCSS" Width="200" AutoPostBack="true"></asp:DropDownList> Position : <asp:Label ID="lblPosition" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <div style="width: 1000px; background-color: #808080; text-align: center; vertical-align: middle">
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 100%; height: 10px"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100%" align="center">
                                                        <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server"
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
                                                        <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                                                            <Report FileName="rpt_Property_Acknowledgement_Receipt_v2.rpt">
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
                                </tr>
                            </table>
                        </asp:View>
                    </asp:MultiView>
                </td>
                <td style="width: 1%"></td>
            </tr>
        </table>
    </div>
</asp:Content>