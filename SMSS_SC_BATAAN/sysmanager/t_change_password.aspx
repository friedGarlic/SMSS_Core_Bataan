<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_change_password.aspx.vb" Inherits="t_change_password" title="Untitled Page" StylesheetTheme ="SkinFile"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <div align = "center">
    <table style="width: 1000px">
        <tr>
            <td align="center" class="DivTitle" style="width: 1000px">
                &nbsp;CHANGE PASSWORD</td>
        </tr>
        <tr>
            <td align="center" style="width: 1000px">
                <br />
                <asp:Panel ID="Panel2" runat="server" BorderColor="RoyalBlue" BorderStyle="Solid"
                    BorderWidth="1px" Width="800px">
                    <table style="width: 95%">
                        <tr>
                            <td style="width: 25%; font-size: 10pt; font-family: Verdana; text-align: left;" class="column_LeftBold">
                            </td>
                            <td style="width: 100px">
                                &nbsp;</td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; text-align: left; font-size: 10pt; font-family: Verdana;" class="column_LeftBold">
                                Old
                                Password:</td>
                            <td colspan="2" style="width: 75%;" class="text5">
                                <asp:TextBox ID="txtoldpassword" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtoldpassword"
                                    ErrorMessage="*" ValidationGroup="Change"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr style="color: #000000">
                            <td style="width: 25%; text-align: left; font-size: 10pt; font-family: Verdana;" class="column_LeftBold">
                                New Password:</td>
                            <td colspan="2" style="width: 75%;" class="text5">
                                <asp:TextBox ID="txtnewpassword" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnewpassword"
                                    ErrorMessage="*" ValidationGroup="Change"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr style="color: #000000">
                            <td style="width: 25%; text-align: left; font-size: 10pt; font-family: Verdana;" class="column_LeftBold">
                                Confirm New Password:</td>
                            <td colspan="2" style="width: 75%;" class="text5">
                                <asp:TextBox ID="txtconfirmpassword" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtconfirmpassword"
                                    ErrorMessage="*" ValidationGroup="Change"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td colspan="3" style="width: 100%; text-align: center">
                                <asp:Label ID="lblerror" runat="server" ForeColor="Red"> </asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 100%; text-align: center" colspan="3">
                                <asp:Button ID="Button1" runat="server" CssClass="CSButton" Text="Change Password" ValidationGroup="Change" Width="200px" /></td>
                        </tr>
                        <tr>
                            <td colspan="3" style="width: 100%; text-align: center">
                                &nbsp;</td>
                        </tr>
                    </table>
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to change your password?" TargetControlID="Button1">
                                </cc1:ConfirmButtonExtender>
                </asp:Panel>
                <br />
            </td>
        </tr>
    </table>
    </div>
    
</asp:Content>

