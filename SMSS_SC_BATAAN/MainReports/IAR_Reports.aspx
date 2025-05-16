<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="IAR_Reports.aspx.vb"
    Inherits="MainReports_IAR_Reports" StylesheetTheme="SkinFile" %>

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
                <td style="width: 98%" class="column_LeftBold">
                    <asp:LinkButton ID="LnkPrevious" runat="server" CssClass="LinkBtnSelect" Text="Back to Previous Page ..."></asp:LinkButton>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <table runat="server" id="tbIAR" width="50%">
                        <tr>
                            <td style="width: 5%"></td>
                            <td style="width: 95%" class="column_Left">
                                <span class="column_RightBold">Report Size :</span>
                                &nbsp;<asp:DropDownList runat="server" ID="drpReportFormat" Width="100px" CssClass="drpdownCSS" AutoPostBack="true">
                                    <asp:ListItem Selected="True" Value="1" Text="Short"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Long"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
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
                                    <CR:CrystalReportViewer ID="IARReports" runat="server" AutoDataBind="true" 
                                        CssClass="borderCSS" HasToggleGroupTreeButton="False" BestFitPage="True" HasCrystalLogo="False"
                                        BackColor="#ffffff" ToolPanelView="None" />
                                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
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
        </table>
    </div>

</asp:Content>

