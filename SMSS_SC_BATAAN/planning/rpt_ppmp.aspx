<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rpt_ppmp.aspx.vb" Inherits="rpt_ppmp"
    Title="Project Procurement Management Plan Report" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">PROJECT PROCUREMENT MANAGEMENT PLAN REPORT
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="LinkBtnSelect" Text="Back to Previous Page ..."></asp:LinkButton>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" Visible="false" CssClass="rbCS_Horizontal" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True">PPMP</asp:ListItem>
                        <asp:ListItem>PPMP with Balance</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" CssClass="rbCS_Horizontal" Visible="false" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True">PPMP</asp:ListItem>
                        <asp:ListItem Value="PPMP With Balance">PPMP With Balance</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" AutoPostBack="True" CssClass="rbCS_Horizontal" RepeatDirection="Horizontal" Visible="False">
                        <asp:ListItem>Previous</asp:ListItem>
                        <asp:ListItem>Current</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <div style="width: 1000px; background-color: #808080; text-align: center; vertical-align: middle">
                        <table width="100%">
                            <tr>
                                <td style="width: 100%; height: 5px"></td>
                            </tr>
                            <tr>
                                <td style="width: 100%" align="center">
                                    <CR:CrystalReportViewer ID="CrystalReportViewer3" runat="server" AutoDataBind="true"  HasToggleGroupTreeButton="False" 
                                        BestFitPage="False" Width="980px" Height="900px" BackColor="#ffffff" />
                                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"  HasToggleGroupTreeButton="False" 
                                        BestFitPage="False" Width="980px" Height="900px" BackColor="#ffffff" />
                                    <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true"  HasToggleGroupTreeButton="False" 
                                        BestFitPage="False" Width="980px" Height="900px" BackColor="#ffffff" />

                                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                        <Report FileName="t_rpt__ppmp_history.rpt">
                                        </Report>
                                    </CR:CrystalReportSource>
                                    <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                                        <Report FileName="ppmp with balance.rpt">
                                        </Report>
                                    </CR:CrystalReportSource>
                                    <CR:CrystalReportSource ID="CrystalReportSource3" runat="server">
                                        <Report FileName="ppmpConsolidated.rpt">
                                        </Report>
                                    </CR:CrystalReportSource>
                                    <CR:CrystalReportSource ID="CrystalReportSource4" runat="server">
                                        <Report FileName="ppmp with balance_consolidated.rpt">
                                        </Report>
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
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%"></td>
                <td style="width: 1%"></td>
            </tr>
        </table>
    </div>

    
</asp:Content>

