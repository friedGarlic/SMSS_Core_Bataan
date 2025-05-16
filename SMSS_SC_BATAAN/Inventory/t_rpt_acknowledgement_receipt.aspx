<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="t_rpt_acknowledgement_receipt.aspx.vb"
    Inherits="t_rpt_acknowledgement_receipt" Title="Acknowledgement Receipt Report" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">PROPERTY ACKNOWLEDGEMENT RECEIPT FOR EQUIPMENTS</td>
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
                <td style="width: 98%;height:5px"></td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <span class="column_RightBold">Paper Size :</span>
                   &nbsp;<asp:DropDownList runat="server" ID="drpPaperSize" CssClass="drpdownCSS" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="drpPaperSize_SelectedIndexChanged">
                       <asp:ListItem Selected="True" Value="1" Text="Short"></asp:ListItem>
                       <asp:ListItem Value="2" Text="Long"></asp:ListItem>
                   </asp:DropDownList>
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
                                  <CR:CrystalReportViewer ID="PARE_Reports" runat="server" AutoDataBind="true"
                                    HasToggleGroupTreeButton="False" HasCrystalLogo="False" BestFitPage="True"
                                    BackColor="#ffffff" ToolPanelView="None"
                                    HasExportButton="True" HasPrintButton="True" PrintMode="Pdf" />

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
        </table>
    </div>
</asp:Content>