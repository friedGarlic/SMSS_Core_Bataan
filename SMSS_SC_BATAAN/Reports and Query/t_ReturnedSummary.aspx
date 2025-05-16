<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_ReturnedSummary.aspx.vb" 
Inherits="Reports_and_Query_t_ReturnedSummary" title="Summary of Returned Properties" StylesheetTheme="SkinFile" 
EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager id="ScriptManager1" runat="server">
</asp:ScriptManager>

<asp:UpdatePanel id="UpdatePanel1" runat="server">
<contenttemplate>
    <table style="width: 100%">
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" class="PageTitle" style="width: 1000px">
                &nbsp;SUMMARY OF RETURNED PROPERTIES</td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" style="width: 1000px">
                <table style="width: 80%" class="panel_border">
                    <tr>
                        <td class="column_RightBold" style="width: 15%">
                            Department / Office :</td>
                        <td class="text5" style="width: 80%">
                            <asp:DropDownList ID="ddDepartment" runat="server" Width="500px">
                            </asp:DropDownList>
                            <asp:CheckBox ID="cbAll" runat="server" AutoPostBack="True" OnCheckedChanged="cbAll_CheckedChanged"
                                Text="ALL" /></td>
                    </tr>
                    <tr>
                        <td class="column_RightBold" style="width: 15%">
                            Report Option :</td>
                        <td class="text5" style="width: 80%">
                            <asp:DropDownList ID="ddOption" runat="server" Width="200px">
                                <asp:ListItem Value="All">ALL</asp:ListItem>
                                <asp:ListItem Value="Stock">Returned to Stock</asp:ListItem>
                                <asp:ListItem Value="Repair">For Repair</asp:ListItem>
                                <asp:ListItem Value="Dispose">Unserviceable</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="column_RightBold" style="width: 15%">
                            Year :</td>
                        <td class="text5" style="width: 80%">
                            <asp:DropDownList ID="ddYear" runat="server" Width="200px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="column_RightBold" style="width: 15%">
                            Month :</td>
                        <td class="text5" style="width: 80%">
                            <asp:DropDownList ID="ddMonth" runat="server" Width="200px">
                                <asp:ListItem Selected="True" Value="0">ALL</asp:ListItem>
                                <asp:ListItem Value="1">January</asp:ListItem>
                                <asp:ListItem Value="2">February</asp:ListItem>
                                <asp:ListItem Value="3">March</asp:ListItem>
                                <asp:ListItem Value="4">April</asp:ListItem>
                                <asp:ListItem Value="5">May</asp:ListItem>
                                <asp:ListItem Value="6">June</asp:ListItem>
                                <asp:ListItem Value="7">July</asp:ListItem>
                                <asp:ListItem Value="8">August</asp:ListItem>
                                <asp:ListItem Value="9">September</asp:ListItem>
                                <asp:ListItem Value="10">October</asp:ListItem>
                                <asp:ListItem Value="11">November</asp:ListItem>
                                <asp:ListItem Value="12">December</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="column_RightBold" style="width: 15%">
                            Prepared by :</td>
                        <td class="text5" style="width: 80%">
                            <asp:DropDownList ID="ddPreparedBy" runat="server" Width="500px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="column_RightBold" style="width: 15%">
                        </td>
                        <td class="text5" style="width: 80%">
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" style="width: 1000px">
                            <asp:Button ID="btnSearch" runat="server" Text="PREVIEW" CssClass="CSButton" Width="200px" OnClientClick="StartProgressBar();" /></td>
        </tr>
    </table>
    <asp:Panel ID="PanelProgress" runat="server" Style="border-top-width: 1px; border-left-width: 1px;
        border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc;
        border-top-color: #0033cc; position: relative; background-color: transparent;
        text-align: center; border-right-width: 1px; border-right-color: #0033cc" Width="109px">
        <img src="../images/ajax-loader.gif" /></asp:Panel>
    <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress">
    </cc1:ModalPopupExtender>
    <asp:Button ID="ButtonProgress" runat="server" Enabled="False" Style="border-top-style: none;
        border-right-style: none; border-left-style: none; position: relative; background-color: transparent;
        border-bottom-style: none" Width="16px" />



</contenttemplate>
</asp:UpdatePanel>



</asp:Content>

