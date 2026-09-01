<%@ Page Title="Repair Reports" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RepairReports.aspx.vb" Inherits="MainReports_RepairReports" 
    StylesheetTheme="SkinFile"%>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">REPAIR REPORTS</td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <asp:LinkButton runat="server" ID="lnkBack" CssClass="LinkBtnSelect" Text="Back to previous page ..."></asp:LinkButton>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    
                    <!-- Error Display Panel - Shows when there's an error -->
                    <asp:Panel ID="pnlError" runat="server" Visible="false" style="text-align:center; padding:30px;">
                        <asp:Image ID="imgUnderMaintenance" runat="server" ImageUrl="~/images/UNDER MAINTENANCE.png" style="max-width:600px;" />
                        <br />
                        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                    </asp:Panel>

                    <!-- Repair Card Report Viewer -->
                    <asp:Panel ID="pnlRepairCard" runat="server" Visible="false">
                        <CR:CrystalReportViewer ID="RepairCard" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                            HasSearchButton="False" HasDrilldownTabs="False" BestFitPage="true" BackColor="#ffffff" BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />
                        <CR:CrystalReportSource ID="Crystalreportsource1" runat="server">
                        </CR:CrystalReportSource>
                    </asp:Panel>

                    <!-- Pre-Repair Reports Viewer -->
                    <asp:Panel ID="pnlPreRepair" runat="server" Visible="false">
                        <CR:CrystalReportViewer ID="PreRepairReports" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                            HasSearchButton="False" HasDrilldownTabs="False" BestFitPage="true" BackColor="#ffffff" BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />                    
                        <CR:CrystalReportSource ID="Crystalreportsource2" runat="server">
                        </CR:CrystalReportSource>
                    </asp:Panel>

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