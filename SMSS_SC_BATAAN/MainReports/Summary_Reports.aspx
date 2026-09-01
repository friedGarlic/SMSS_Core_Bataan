<%@ Page Title="Summary Reports" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Summary_Reports.aspx.vb" Inherits="MainReports_Summary_Reports"
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>



    <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">SUMMARY REPORTS
                </td>
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
                          <CR:CrystalReportViewer ID="Summary_RPRI" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                        HasSearchButton="False" HasDrilldownTabs="False" BestFitPage="true" BackColor="#ffffff"
                        BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />
                    <CR:CrystalReportSource ID="Crystalreportsource6" runat="server">
                        <Report FileName="SummaryOfRPRI.rpt"></Report>
                    </CR:CrystalReportSource>
                    <CR:CrystalReportViewer ID="Summary_RPCPPE" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                        HasSearchButton="False" HasDrilldownTabs="False" BestFitPage="true" BackColor="#ffffff"
                        BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />
                    <CR:CrystalReportSource ID="Crystalreportsource1" runat="server">
                        <Report FileName="rpt_SummaryRPCPPE.rpt"></Report>
                    </CR:CrystalReportSource>

                    <CR:CrystalReportViewer ID="Summary_RPCPPE_Conso" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                        HasSearchButton="False" HasDrilldownTabs="False" BestFitPage="true" BackColor="#ffffff"
                        BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />
                    <CR:CrystalReportSource ID="Crystalreportsource2" runat="server">
                        <Report FileName="rpt_SummaryRPCPPE_Conso.rpt"></Report>
                    </CR:CrystalReportSource>

                    <CR:CrystalReportViewer ID="Summary_SChools" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                        HasSearchButton="False" HasDrilldownTabs="False" BestFitPage="true" BackColor="#ffffff"
                        BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />
                    <CR:CrystalReportSource ID="Crystalreportsource3" runat="server">
                        <Report FileName="rpt_SummarySchools.rpt"></Report>
                    </CR:CrystalReportSource>



                    <CR:CrystalReportViewer ID="Summary_PAR" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False" HasSearchButton="False" HasDrilldownTabs="False"
                        BestFitPage="False" ToolPanelView="None" BackColor="#ffffff" Height="850px" Width="980px" BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />
                    <CR:CrystalReportSource ID="Crystalreportsource4" runat="server">
                    </CR:CrystalReportSource>


                    <CR:CrystalReportViewer ID="Summary_PRS" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                        HasSearchButton="False" HasDrilldownTabs="False" BestFitPage="true" BackColor="#ffffff"
                        BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />
                    <CR:CrystalReportSource ID="Crystalreportsource5" runat="server">
                    </CR:CrystalReportSource>


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

