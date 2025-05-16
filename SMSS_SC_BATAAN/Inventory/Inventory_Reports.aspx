<%@ Page Title="Inventory - Reports" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Inventory_Reports.aspx.vb"
    Inherits="MainReports_Inventory_Reports" StylesheetTheme="SkinFile" EnableEventValidation="false"  %>

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
                    <table runat="server" id="tbRIS" width="50%">
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

                    <div style="max-width: 850px; max-height 1300px; background-color: #808080; text-align: center; vertical-align: middle; overflow:scroll">
                        <table width="100%">
                            <tr>
                                <td style="width: 100%; height: 5px"></td>
                            </tr>
                            <tr>
                                <td style="width: 100%" align="center">
                                    <CR:CrystalReportViewer ID="InventoryReports" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                                        BackColor="#ffffff" BestFitPage="true" />

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

