<%@ Page Title="Bidding Reports" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Bidding_Reports.aspx.vb"
    Inherits="MainReports_Bidding_Reports" StylesheetTheme="SkinFile" %>

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
                <td style="width: 1%; height: 45px;"></td>
                <td style="width: 98%; height: 45px;" class="column_LeftBold">
                    <asp:LinkButton ID="LnkPrevious" runat="server" CssClass="LinkBtnSelect" Text="Back to Previous Page ..."></asp:LinkButton>
                </td>
                <td style="width: 1%; height: 45px;"></td>
            </tr>
            <tr>
                <td style="width: 1%; height: 45px;"></td>
                <td style="width: 20%; height: 10px; text-align: left;">
                    <span style="font-size: 15px; font-weight: bold; display: inline-block; vertical-align: middle;">Report Version:
                    </span>
                    <asp:DropDownList ID="ddlVersion" runat="server" AutoPostBack="True">
                        <asp:ListItem Text="Select a version..." Value="" Selected="True" />
                        <asp:ListItem Text="v1" Value="v1" />
                        <asp:ListItem Text="v2" Value="v2" />
                    </asp:DropDownList>

                </td>
                <td style="width: 79%; height: 45px;"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">

                    <div style="width: 850px; background-color: #808080; text-align: center; vertical-align: middle">
                        <table width="100%">
                            <tr>
                                <td style="width: 100%; height: 5px"></td>
                            </tr>
                            <tr>
                                <td style="width: 100%" align="center">
                                    <CR:CrystalReportViewer ID="BiddingReports" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                                        BackColor="#ffffff" BestFitPage="True" ToolPanelView="None" />
                                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                    </CR:CrystalReportSource>
                                    <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                                    </CR:CrystalReportSource>
                                    <CR:CrystalReportSource ID="CrystalReportSource3" runat="server">
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

