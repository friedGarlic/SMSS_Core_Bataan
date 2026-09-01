<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Infra_Reports.aspx.vb"
    Inherits="bidding_Bidding_Infra_Infra_Reports" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">INFRASTRUCTURE REPORTS
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <asp:LinkButton runat="server" ID="lnkBack" CssClass="LinkBtnSelect" Text="Back to Previous Page ..."></asp:LinkButton>
                </td>
                <td style="width: 1%"></td>
            </tr>

            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <asp:Panel runat="server" ID="pnlAbstractReport" Visible="false">
                        <span class="column_RightBold">Abstract Report :</span>
                        &nbsp;<asp:DropDownList runat="server" ID="drpAbstractReport" CssClass="drpdownCSS" Width="100px" AutoPostBack="true">
                            <asp:ListItem Value="1" Text="As Read" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="2" Text="As Calculated"></asp:ListItem>
                        </asp:DropDownList>
                    </asp:Panel>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <div runat="server" id="divAbstract" style="width: 100%; background-color: #808080; text-align: center; vertical-align: middle" visible="false">
                        <table width="100%">
                            <tr>
                                <td style="width: 100%; height: 10px"></td>
                            </tr>
                            <tr>
                                <td style="width: 100%" align="center">

                                    <CR:CrystalReportViewer ID="InfrastructureReports" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False" HasSearchButton="False"
                                        HasDrilldownTabs="False"  BestFitPage="False" BackColor="#ffffff" Height="930px" Width="980px" BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />

                                    <CR:CrystalReportSource ID="ReportSource_AbstractRead" runat="server">
                                    </CR:CrystalReportSource>
                                    <CR:CrystalReportSource ID="ReportSource_AbstractCalculated" runat="server">
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
                <td style="width: 98%" align="center">
                    <div runat="server" id="divNotice" style="width: 880px; background-color: #808080; text-align: center; vertical-align: middle" visible="false">
                        <table width="100%">
                            <tr>
                                <td style="width: 100%; height: 10px"></td>
                            </tr>
                            <tr>
                                <td style="width: 100%" align="center">
                                    <CR:CrystalReportViewer ID="InfrastructureNotice" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False" HasSearchButton="False" HasDrilldownTabs="False"
                                         BestFitPage="true" BackColor="#ffffff" BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />


                                    <CR:CrystalReportSource ID="ReportSource_Resolution" runat="server">
                                    </CR:CrystalReportSource>
                                    <CR:CrystalReportSource ID="ReportSource_NOA" runat="server">
                                    </CR:CrystalReportSource>
                                    <CR:CrystalReportSource ID="ReportSource_Contract" runat="server">
                                    </CR:CrystalReportSource>
                                    <CR:CrystalReportSource ID="ReportSource_NTP" runat="server">
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

