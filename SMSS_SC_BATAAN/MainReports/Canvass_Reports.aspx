<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Canvass_Reports.aspx.vb"
    Inherits="MainReports_Canvass_Reports" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">
                    <asp:Label runat="server" ID="lblTitle" Text="REPORTS"></asp:Label>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%; height: 10px"></td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <asp:LinkButton ID="LnkPrevious" runat="server" CssClass="LinkBtnSelect" Text="Back to Previous Page ..."></asp:LinkButton>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%; height: 5px"></td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">



                    <div runat="server" id="divAOQ" style="width: 100%; background-color: #808080; text-align: center; vertical-align: middle" visible="false">
                        <table width="100%">
                            <tr>
                                <td style="width: 100%; height: 10px"></td>
                            </tr>
                            <tr>
                                <td style="width: 100%" align="center">
                                    <CR:CrystalReportViewer ID="AOQReports" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False" HasSearchButton="False" HasDrilldownTabs="False"
                                         BestFitPage="False" BackColor="#ffffff" Height="930px" Width="980px" BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" ToolPanelView="None" />
                                    <CR:CrystalReportSource ID="ReportSource_AOQ" runat="server">
                                    </CR:CrystalReportSource>

                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100%; height: 10px"></td>
                            </tr>
                        </table>
                    </div>




                    <div runat="server" id="divCanvass" style="width: 850px; background-color: #808080; text-align: center; vertical-align: middle" visible="false">
                        <table width="100%">
                            <tr>
                                <td style="width: 100%; height: 5px"></td>
                            </tr>
                            <tr>
                                <td style="width: 100%" align="center">

                                    <CR:CrystalReportViewer ID="CanvassReport" runat="server" AutoDataBind="true"  HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                                        BackColor="#ffffff" BestFitPage="true" ToolPanelView="None" />
                                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                    </CR:CrystalReportSource>


                                    <CR:CrystalReportViewer ID="CanvassReports" runat="server" AutoDataBind="true"  HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                                        BackColor="#ffffff" BestFitPage="true" ToolPanelView="None" />
                                    <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                                    </CR:CrystalReportSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100%; height: 5px"></td>
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
        </table>
    </div>
</asp:Content>

