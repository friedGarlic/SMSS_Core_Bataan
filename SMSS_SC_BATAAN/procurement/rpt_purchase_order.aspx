<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="rpt_purchase_order.aspx.vb"
    Inherits="rpt_purchase_order" Title="Purchase Order Report" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Contetnt1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">PURCHASE ORDER REPORT
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
                    <span class="column_RightBold">Report Size :</span>
                    &nbsp;<asp:DropDownList runat="server" ID="drpPaperSize" Width="120px" CssClass="drpdownCSS" AutoPostBack="true">
                        <asp:ListItem Selected="True" Value="1" Text="Short"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Long"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <asp:RadioButtonList ID="rdPRFormat" runat="server" Visible="false" AutoPostBack="True" CssClass="rbCS_Horizontal" RepeatDirection="Horizontal" Width="400px">
                        <asp:ListItem Selected="True" Value="1">PO Report Format v1</asp:ListItem>
                        <asp:ListItem Value="2">PO Report Format v2</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td style="width: 1%"></td>
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
                                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"  HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                                        BestFitPage="True" BackColor="#ffffff" ToolPanelView="None" />
                                    <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true"  HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                                        BestFitPage="True" BackColor="#ffffff" ToolPanelView="None" />

                                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                        <Report FileName="rpt_purchase_order.rpt">
                                        </Report>
                                    </CR:CrystalReportSource>
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
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%"></td>
                <td style="width: 1%"></td>
            </tr>
        </table>
    </div>


</asp:Content>
