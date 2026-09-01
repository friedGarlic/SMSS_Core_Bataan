<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false"
    CodeFile="rpt_propertycard.aspx.vb" Inherits="Records_rpt_propertycard"
    Title="Property Card Report" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<script runat="server">


</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">PROPERTY LEDGER CARD</td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="LinkBtnSelect">Back to Previous Page ...</asp:LinkButton>
                    <br />
                    <asp:DropDownList ID="drpListofReport" CssClass="drpdownCSS" runat="server"
                        AutoPostBack="true" Width="120px"
                        OnSelectedIndexChanged="drpListofReport_SelectedIndexChanged"
                        Visible="false">
                        <asp:ListItem Value="0" Text="Consolidated" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Per Item"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <div style="width: 1000px; background-color: #808080; text-align: center; vertical-align: middle">
                        <table width="100%">
                            <tr>
                                <td style="width: 100%; height: 10px"></td>
                            </tr>
                            <tr>
                                <td style="width: 100%" align="center">
                                    <CR:CrystalReportViewer ID="PropertyCardReports" runat="server"
                                        AutoDataBind="true"
                                        HasToggleGroupTreeButton="False"
                                        HasCrystalLogo="False"
                                        HasSearchButton="False"
                                        HasDrilldownTabs="False"
                                        BestFitPage="False"
                                        BackColor="#ffffff"
                                        Height="930px"
                                        Width="980px"
                                        BorderStyle="Solid"
                                        BorderColor="#2977dc"
                                        BorderWidth="1px"
                                        ToolPanelView="None"
                                        HasGroupTree="False" />

                                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                        <Report FileName="rpt_PropertyCard.rpt">
                                        </Report>
                                    </CR:CrystalReportSource>
                                    <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                                        <Report FileName="rpt_PropertyCard_Per_Item.rpt">
                                        </Report>
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
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%"></td>
                <td style="width: 1%"></td>
            </tr>
        </table>
    </div>
</asp:Content>
