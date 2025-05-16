<%@ Page Language="VB" AutoEventWireup="false" CodeFile="body(old).aspx.vb" Inherits="body" MasterPageFile="~/MasterPage.master" StylesheetTheme="SkinFile" Title="SMS::Supply Management System" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 100px">
                <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td>
                <span style="font-size: 10pt; font-family: Verdana">Welcome&nbsp;</span>
                <asp:Label ID="lblUser" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Verdana"
                    Font-Size="10pt" ForeColor="#CC0000"></asp:Label><span style="font-size: 10pt; font-family: Verdana"><span
                        style="font-size: 12pt; font-family: Times New Roman">Last Logged Date an</span>d<span
                            style="font-size: 12pt; font-family: Times New Roman"> T</span>ime:</span>
                <asp:Label ID="lblDate" runat="server" Font-Names="Verdana" Font-Size="10pt"></asp:Label>
                <span style="font-size: 10pt; font-family: Verdana">|</span>
                <asp:LinkButton ID="lbLogout" runat="server" Font-Names="Verdana" Font-Size="10pt">Logout</asp:LinkButton>
                <span style="font-size: 10pt; font-family: Verdana">|</span>
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Names="Verdana" Font-Size="10pt" ToolTip="To FMIS System">FMIS</asp:LinkButton>
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to logout?"
                    TargetControlID="lbLogout">
                </cc1:ConfirmButtonExtender>
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                <img src="../images/mainbody_new.jpg" /></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>
