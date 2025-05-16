<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="rpt_Infra_Abstract.aspx.vb" Inherits="bidding_Bidding_Infra_rpt_Infra_Abstract"
    Title="ABSTRACT OF BIDS - INFRA" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>





    <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">ABSTRACT OF BIDS INFRASTRACTURE REPORT</td>
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
                <td style="width: 98%" align="left">
                    <span class="column_RightBold">Abstract of Bids :</span>
                    &nbsp;<asp:DropDownList runat="server" ID="drpAbstractType" Width="100px" CssClass="drpdownCSS">
                        <asp:ListItem Value="1" Text="AS Read" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="2" Text="AS Calculated"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <div style="width: 100%; background-color: #808080; text-align: center; vertical-align: middle">
                        <table width="100%">
                            <tr>
                                <td style="width: 100%; height: 10px"></td>
                            </tr>
                            <tr>
                                <td style="width: 100%" align="center">
                                    <CR:CrystalReportViewer ID="Infra_Abstract_Reports" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False" HasSearchButton="False" HasDrilldownTabs="False"
                                         BestFitPage="False" BackColor="#ffffff" Height="930px" Width="98%" BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />

                                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                       <%-- <Report FileName="rpt_Infra_Abstract.rpt">
                                        </Report>--%>
                                    </CR:CrystalReportSource>
                                    <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                                        <%--<Report FileName="rpt_Infra_Abstract_read.rpt">
                                        </Report>--%>
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





<%--

    <table style="width: 1000px">
        <tr>
            <td style="width: 50px">&nbsp;</td>
            <td align="left" style="width: 950px"></td>
        </tr>
        <tr>
            <td style="width: 50px"></td>
            <td align="left" style="width: 950px">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton></td>
        </tr>
        <tr>
            <td style="width: 50px"></td>
            <td align="left" class="text5" style="width: 950px">
                <asp:RadioButtonList ID="rbChoice" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                    Width="200px">
                    <asp:ListItem Selected="True" Value="1">As Calculated</asp:ListItem>
                    <asp:ListItem Value="2">As Read</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td style="width: 50px"></td>
            <td align="left" style="width: 950px">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    BestFitPage="False" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                     Height="800px" Width="950px" />

            </td>
        </tr>
        <tr>
            <td style="width: 50px"></td>
            <td align="left" style="width: 950px"></td>
        </tr>
    </table>--%>



</asp:Content>

