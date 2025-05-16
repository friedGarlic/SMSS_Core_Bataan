<%@ Page Language="VB" MasterPageFile="~/MasterPage1.master" AutoEventWireup="false" CodeFile="ManageApplication.aspx.vb" Inherits="Menu_ManageApplication" title="Web Systems Manager" StylesheetTheme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
   
    <table style="width: 820px">
        <tr>
            <td class="TitleRow" colspan="2" style="width: 100%">
                &nbsp;MANAGE APPLICATION</td>
        </tr>
        <tr>
            <td colspan="2" style="width: 100%">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%; font-size: 10pt; font-family: Verdana; text-align: left;" class="text1Bold">
                Application Name : &nbsp;</td>
            <td style="width: 80%" class="text2">
                <asp:TextBox ID="txtApplication" runat="server" Font-Names="Verdana" Font-Size="10pt"
                    Width="259px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 20%; font-size: 10pt; font-family: Verdana; text-align: left;" class="text1Bold">
                Description :
            </td>
            <td style="width: 80%;" class="text2">
                <asp:TextBox ID="txtDescription" runat="server" Font-Names="Verdana" Font-Size="10pt"
                    Width="259px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 20%; font-size: 10pt; font-family: Verdana; text-align: left;" class="text1Bold">
            </td>
            <td style="width: 80%" class="text2">
                <asp:Button ID="btnSave" runat="server" Font-Names="Tahoma" Font-Size="10pt" Text="Submit"
                    Width="150px" /></td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="width: 100%">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="width: 100%">
                <asp:Label ID="CreateStatus" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="width: 100%">
    <asp:GridView ID="grdApplications" runat="server" AutoGenerateColumns="False"
        Font-Size="10pt" SkinID="gvnew">
        <PagerSettings NextPageText="Next" PreviousPageText="Prev" />
        <Columns>
            <asp:BoundField DataField="ApplicationName" HeaderText="Application Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
        </Columns>
    </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

