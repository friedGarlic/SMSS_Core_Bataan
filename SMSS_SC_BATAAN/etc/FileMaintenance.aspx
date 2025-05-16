<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FileMaintenance.aspx.vb" Inherits="FileMaintenance" MasterPageFile="~/MasterPage.master" StylesheetTheme="SkinFile" Title="SMS::File Maintenance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="3">
                <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <span style="font-size: 10pt; font-family: Verdana">Welcome&nbsp;</span>
                <asp:Label ID="lblUser" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Verdana"
                    Font-Size="10pt" ForeColor="#CC0000"></asp:Label><span style="font-size: 10pt; font-family: Verdana"><span
                        style="font-size: 12pt; font-family: Times New Roman">Last Logged Date an</span>d<span
                            style="font-size: 12pt; font-family: Times New Roman"> T</span>ime:</span>
                <asp:Label ID="lblDate" runat="server" Font-Names="Verdana" Font-Size="10pt"></asp:Label>
                <span style="font-size: 10pt; font-family: Verdana">|</span>
                <asp:LinkButton ID="lbLogout" runat="server" Font-Names="Verdana" Font-Size="10pt">Logout</asp:LinkButton>
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to logout?"
                    TargetControlID="lbLogout">
                </cc1:ConfirmButtonExtender>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <img src="../images/file_maintenance_body.jpg" /></td>
        </tr>
        <tr>
            <td colspan="3">
            </td>
        </tr>
    </table>
</asp:Content>
