<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="PhysicalCount_PPE.aspx.vb" Inherits="Reports_and_Query_PhysicalCount_PPE"
    Title="Physical Count of PPE" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">PHYSICAL COUNT OF PPE
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="90%">
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Search By : </td>
                                    <td style="width: 85%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drptSearchBy" Width="300px" CssClass="drpdownCSS" AutoPostBack="true">
                                            <asp:ListItem Selected="True" Value="1" Text="Per Department"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Per Account"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Per Items"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>

                                </tr>
                            </table>

                            <table style="width: 90%" id="tb_Dept" runat="server">
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Department : </td>
                                    <td style="width: 45%" class="column_Left">
                                        <asp:DropDownList ID="ddDept" runat="server" Width="90%" OnSelectedIndexChanged="ddDept_SelectedIndexChanged" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList></td>
                                    <td style="width: 40%" class="column_Left">
                                        <asp:Button ID="btnDept" OnClick="btnDept_Click" runat="server" Width="150px" CssClass="CSButton" Text="Preview" OnClientClick="StartProgressBar();"></asp:Button></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Function : </td>
                                    <td style="width: 45%" class="column_Left">
                                        <asp:DropDownList ID="ddFunction" runat="server" Width="90%" OnSelectedIndexChanged="ddFunction_SelectedIndexChanged" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList></td>
                                    <td style="width: 40%" class="column_Left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Sort By : </td>
                                    <td style="width: 45%" class="column_Left">
                                        <asp:DropDownList ID="ddSorting" runat="server" Width="90%" AutoPostBack="True" CssClass="drpdownCSS" Enabled="False">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">By Accounts</asp:ListItem>
                                            <asp:ListItem Value="2">By Accountable Person</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="width: 40%" class="column_Left"></td>
                                </tr>
                            </table>
                            <table style="width: 90%" id="tb_Accnt" runat="server">
                                <tbody>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Account Title : </td>
                                        <td style="width: 45%" class="column_Left">
                                            <asp:DropDownList ID="ddcode" runat="server" Width="90%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList></td>
                                        <td style="width: 40%" class="column_Left">
                                            <asp:Button ID="btnAccounts" runat="server" Width="150px" CssClass="CSButton" Text="Preview" ValidationGroup="save" OnClientClick="StartProgressBar();"></asp:Button></td>
                                    </tr>
                                </tbody>
                            </table>
                            <table style="width: 90%" id="tb_Item" runat="server">
                                <tbody>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Item Description : </td>
                                        <td style="width: 45%" class="column_Left">
                                            <asp:TextBox ID="txtSearchItem" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox></td>
                                        <td style="width: 40%" class="column_Left">
                                            <asp:Button ID="btnItem" runat="server" Width="150px" CssClass="CSButton" Text="Preview" ValidationGroup="save" OnClientClick="StartProgressBar();"></asp:Button></td>
                                    </tr>
                                </tbody>
                            </table>
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


            <%--  <table style="width: 1010px">
                <tbody>

                    <tr>
                        <td style="width: 10px"></td>
                        <td style="width: 1000px" align="center"><span style="font-size: 9pt; font-family: Arial"></span>
                            <table style="width: 100%">
                                <tbody>
                                    <tr>
                                        <td style="width: 30%" class="column_RightBold">SEARCH : </td>
                                        <td style="width: 70%" class="column_Left">
                                            <asp:RadioButtonList ID="rbChoice" runat="server" Width="300px" Font-Size="9pt" Font-Names="Arial" __designer:dtid="7318349394477072" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbChoice_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w136">
                                                <asp:ListItem Selected="True" Value="1" __designer:dtid="7318349394477073">Department</asp:ListItem>
                                                <asp:ListItem Value="2" __designer:dtid="7318349394477074">Consolidated</asp:ListItem>
                                                <asp:ListItem Value="3" __designer:dtid="7318349394477075">By Item</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>--%>

            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px" __designer:wfdid="w145">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" __designer:wfdid="w146" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False" __designer:wfdid="w147"></asp:Button>

        </ContentTemplate>
    </asp:UpdatePanel>





</asp:Content>

