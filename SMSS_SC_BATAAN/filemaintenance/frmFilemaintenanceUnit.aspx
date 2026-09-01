<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="frmFilemaintenanceUnit.aspx.vb" Inherits="File_Maintenance_frmFilemaintenanceUnit"
    Title="FM UNITS" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 1010px">
                <tr>
                    <td style="width: 10px"></td>
                    <td align="center" style="width: 1000px"></td>
                </tr>
                <tr>
                    <td style="width: 10px"></td>
                    <td align="center" class="PageTitle" style="width: 1000px">UNITS</td>
                </tr>
                <tr>
                    <td style="width: 10px"></td>
                    <td align="center" style="width: 1000px"></td>
                </tr>
                <tr>
                    <td style="width: 10px"></td>
                    <td align="center" style="width: 1000px">
                        <table style="width: 100%">
                            <tr>
                                <td align="center" style="font-weight: bold; font-size: 9pt; width: 50%; font-family: Arial; height: 20px; background-color: lightgrey; text-align: center">INFORMATION</td>
                                <td align="center" style="font-weight: bold; font-size: 9pt; width: 50%; font-family: Arial; height: 20px; background-color: lightgrey; text-align: center">LIST OF UNITS</td>
                            </tr>
                            <tr>
                                <td align="center" style="vertical-align: top; width: 50%; text-align: center">
                                    <table style="width: 100%; border-right: royalblue 1px solid; border-top: royalblue 1px solid; border-left: royalblue 1px solid; border-bottom: royalblue 1px solid;">
                                        <tbody>
                                            <tr>
                                                <td style="width: 20%" class="column_RightBold">Search : </td>
                                                <td style="width: 70%" class="text5">
                                                    <asp:TextBox ID="txtSearch" runat="server" Width="200px" Height="17px" CssClass="txtboxinspection"></asp:TextBox><asp:Button ID="btnSearch" CssClass="CSButton" OnClick="btnSearch_Click" runat="server" Width="100px" Text="Search"></asp:Button></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 20%" class="column_RightBold">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDescription" ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator>Description : </td>
                                                <td style="width: 70%" class="text5">
                                                    <asp:DropDownList ID="ddunit" runat="server" Width="200px" AppendDataBoundItems="True" AutoPostBack="True">
                                                        <asp:ListItem Selected="True" Value=" 0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value=" ">Create New</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 20%" class="column_RightBold">
                                                    <asp:Label ID="lblUnit" runat="server" Text="Create New Unit :" Visible="False"></asp:Label></td>
                                                <td style="width: 70%" class="text5">
                                                    <asp:TextBox ID="txtDescription" runat="server" Width="200px" Visible="False" CssClass="txtboxinspection"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 20%" class="column_RightBold"></td>
                                                <td style="width: 70%" class="text5">
                                                    <asp:CheckBox ID="cbwith" runat="server" AutoPostBack="True" Visible="False"></asp:CheckBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 20%" class="column_RightBold"></td>
                                                <td style="width: 70%" class="text5">
                                                    <asp:Button ID="btnsave" runat="server" CssClass="CSButton" Width="120px" ValidationGroup="save" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button><asp:Button ID="btnadd" runat="server" CssClass="CSButton" Width="120px" Text="CANCEL"></asp:Button></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnsave" ConfirmText="Are you sure you want to save this transaction?"></cc1:ConfirmButtonExtender>

                                    <table style="width: 100%" id="tbSubUnit" runat="server">
                                        <tbody>
                                            <tr>
                                                <td style="width: 30%" class="column_RightBold">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsubdetail" ErrorMessage="*" ValidationGroup="save" InitialValue="0"></asp:RequiredFieldValidator>Select Unit : </td>
                                                <td style="width: 70%" class="text5">
                                                    <asp:DropDownList ID="ddsubunit" runat="server" Width="120px" AppendDataBoundItems="True" AutoPostBack="True">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    </asp:DropDownList><asp:TextBox ID="txtsubdetail" runat="server" Width="11px" ForeColor="White" BackColor="Transparent" BorderColor="Transparent" BorderWidth="0px" ReadOnly="True"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%" class="column_RightBold">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtvalue" ErrorMessage="*" ValidationGroup="save" InitialValue="0"></asp:RequiredFieldValidator>Value : </td>
                                                <td style="width: 70%" class="text5">
                                                    <asp:TextBox ID="txtvalue" runat="server" Width="150px"></asp:TextBox></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtvalue" ValidChars="0123456789">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td align="center" style="border-right: royalblue 1px solid; border-top: royalblue 1px solid; vertical-align: top; border-left: royalblue 1px solid; width: 50%; border-bottom: royalblue 1px solid; text-align: center">
                                    <asp:GridView ID="gvunit" runat="server" Width="100%" SkinID="GridViewAA" PageSize="12" AutoGenerateColumns="False" AllowPaging="True">
                                        <Columns>
                                            <asp:BoundField DataField="Description" HeaderText="Description">
                                                <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Value" HeaderText="Value">
                                                <ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
                                            </asp:BoundField>
                                        </Columns>

                                        <FooterStyle BackColor="#2977DC"></FooterStyle>

                                        <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="PanelProgress" runat="server" Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc"
                Width="109px">
                <img src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground"
                BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress">
            </cc1:ModalPopupExtender>
            <asp:Button ID="ButtonProgress" runat="server" Enabled="False" Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none"
                Width="16px" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <br />
</asp:Content>

