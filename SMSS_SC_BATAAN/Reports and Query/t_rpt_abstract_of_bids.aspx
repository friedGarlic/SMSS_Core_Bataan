<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_rpt_abstract_of_bids.aspx.vb" Inherits="t_rpt_abstract_of_bids" Title="Abstract Of Bids Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>



    <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">ABSTRACT OF PRICES ON PUBLIC AUCTION
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <asp:LinkButton ID="lnkBack" runat="server" CssClass="LinkBtnSelect">Back to Previous Page ...</asp:LinkButton>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                   

                    <CR:CrystalReportViewer ID="AbstractReports" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False" 
                        HasSearchButton="False" HasDrilldownTabs="False" BestFitPage="False" 
                        BackColor="#ffffff" Height="930px" Width="980px" BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />

                    <CR:CrystalReportSource ID="CrystalReportSource4" runat="server">
                        <Report FileName="rpt_AbstractProposal_No2.rpt">
                        </Report>
                    </CR:CrystalReportSource>

                    <CR:CrystalReportViewer ID="AbstractReport_template" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False" 
                        HasSearchButton="False" HasDrilldownTabs="False" BestFitPage="False" 
                        BackColor="#ffffff" Height="930px" Width="980px" BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />

                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                        <Report FileName="rpt_AbstractProposal.rpt">
                        </Report>
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
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%"></td>
                <td style="width: 1%"></td>
            </tr>
        </table>
    </div>


</asp:Content>

