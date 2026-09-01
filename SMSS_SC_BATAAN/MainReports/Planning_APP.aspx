<%@ Page Title="ANNUAL PROCUREMENT PLAN" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Planning_APP.aspx.vb"
    Inherits="Reports_and_Query_Main_Reports_Planning_APP" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>








     <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">ANNUAL PROCUREMENT PLAN REPORT
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <asp:LinkButton ID="lnkBack" runat="server" CssClass="LinkBtnSelect" Text="Back to Previous Page ..."></asp:LinkButton>
                </td>
                <td style="width: 1%"></td>
            </tr>           
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">

                    <CR:CrystalReportViewer ID="PlanningReports" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False" 
                        HasSearchButton="False" HasDrilldownTabs="False" BestFitPage="False" BackColor="#ffffff" Height="930px" Width="980px" 
                        BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />
                    
                     <CR:CrystalReportSource ID="Crystalreportsource1" runat="server" CacheDuration="1">
                    </CR:CrystalReportSource>

                    <CR:CrystalReportSource ID="Crystalreportsource3" runat="server" CacheDuration="1">
                    </CR:CrystalReportSource>
                 
                    <CR:CrystalReportSource ID="Crystalreportsource2" runat="server" CacheDuration="1">
                    </CR:CrystalReportSource>

                    <CR:CrystalReportSource ID="Crystalreportsource4" runat="server" CacheDuration="1">
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

