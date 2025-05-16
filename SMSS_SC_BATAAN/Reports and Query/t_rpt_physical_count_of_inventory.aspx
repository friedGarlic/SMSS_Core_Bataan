<%@ Page Language="VB" AutoEventWireup="false" CodeFile="t_rpt_physical_count_of_inventory.aspx.vb"
    Inherits="t_rpt_physical_count_of_inventory" MasterPageFile="~/MasterPage.master"
    Title="Physical Count of Inventories" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>



<asp:Content ID="Contetnt1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">PHYSICAL COUNT OF INVENTORIES

                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="80%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">General Account :
                                    </td>
                                    <td style="width: 80%" align="left">
                                        <asp:DropDownList ID="ddcode" runat="server" Width="70%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddcode_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">As of Date :
                                    </td>
                                    <td style="width: 80%" align="left">
                                        <asp:TextBox ID="txtdate" runat="server" CssClass="txtbox_Date"></asp:TextBox>
                                        &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton>
                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                    </td>
                                </tr>
                            </table>

                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtdate" PopupButtonID="ImageButton1">
                            </cc1:CalendarExtender>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtdate" MaskType="Date" Mask="99/99/9999">
                            </cc1:MaskedEditExtender>

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
                        <td style="width: 98%" align="center">
                            <asp:Button ID="Button2" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW" ValidationGroup="save" Enabled="False"></asp:Button>
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
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
