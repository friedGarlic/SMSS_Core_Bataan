<%@ Page Language="VB" MasterPageFile="~/MasterPage1.master" AutoEventWireup="false" CodeFile="ManageComponent.aspx.vb" Inherits="Menu_ManageComponent" title="Web Systems Manager" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <table style="width: 820px">
        <tr>
            <td class="TitleRow" colspan="2" style="width: 100%; text-align: left">
                &nbsp;MANAGE COMPONENT</td>
        </tr>
        <tr>
            <td class="text1Bold" colspan="2" style="width: 100%; text-align: left">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="font-size: 10pt; width: 20%; font-family: Verdana; text-align: left;" class="text1Bold">
                Application :
            </td>
            <td style="width: 80%" class="text2">
                <asp:DropDownList ID="ddlApplication" runat="server" AutoPostBack="True" Width="250px" Font-Names="Verdana" Font-Size="10pt">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="font-size: 10pt; width: 20%; font-family: Verdana; text-align: left;" class="text1Bold">
                Menu :
            </td>
            <td style="width: 80%" class="text2">
                <asp:DropDownList ID="ddlMenu" runat="server" AutoPostBack="True" Width="250px" Font-Names="Verdana" Font-Size="10pt">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="font-size: 10pt; width: 20%; font-family: Verdana; text-align: left;" class="text1Bold">
                Sub Menu :
            </td>
            <td style="width: 80%" class="text2">
                <asp:DropDownList ID="ddlSubMenu" runat="server" AutoPostBack="True"  Width="250px" Font-Names="Verdana" Font-Size="10pt">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="font-size: 10pt; width: 20%; font-family: Verdana; text-align: left;" class="text1Bold">
                Component Name :
            </td>
            <td style="width: 80%" class="text2">
                <asp:TextBox ID="txtComponent" runat="server" Font-Names="Verdana" Font-Size="10pt" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="font-size: 10pt; width: 20%; font-family: Verdana; text-align: left;" class="text1Bold">
                Description :
            </td>
            <td style="width: 80%" class="text2">
                <asp:TextBox ID="txtDescription" runat="server" Font-Names="Verdana" Font-Size="10pt" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="font-size: 10pt; width: 20%; font-family: Verdana; text-align: left;" class="text1Bold">
                Home Page URL :
            </td>
            <td style="width: 80%" class="text2">
                <asp:TextBox ID="txtURL" runat="server" Font-Names="Verdana" Font-Size="10pt" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="font-size: 10pt; width: 20%; font-family: Verdana; text-align: left;" class="text1Bold">
                Sequence No :
            </td>
            <td style="width: 80%" class="text2">
                <asp:TextBox ID="txtSequence" runat="server" Font-Names="Verdana" Font-Size="10pt" Width="50px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="font-size: 10pt; width: 20%; font-family: Verdana; text-align: left;" class="text1Bold">
            </td>
            <td style="width: 80%" class="text2">
                <asp:Button ID="btnCreate" runat="server" CssClass="CSButton" Font-Names="Tahoma" Font-Size="10pt" Text="Submit" Width="150px" />
                </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="width: 100%">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="width: 100%" align="center">
                <asp:Label ID="CreateStatus" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="width: 100%">
                <asp:GridView ID="grdComponents" runat="server" AutoGenerateColumns="False"
        DataKeyNames="ComponentName,Description,SequenceNo,HomePageURL,ComponentID,ApplicationID,ModuleID,SubModuleID"
        SkinID="gvnew" Style="font-weight: normal; position: relative" Width="100%">
        <Columns>
            <asp:CommandField SelectText="Edit" ShowSelectButton="True">
                <ItemStyle ForeColor="Blue" Width="5%" />
            </asp:CommandField>
            <asp:BoundField DataField="SequenceNo" HeaderText="Sequence No">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="15%" />
            </asp:BoundField>
            <asp:BoundField DataField="ComponentName" HeaderText="Component Name">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="40%" />
            </asp:BoundField>
            <asp:BoundField DataField="Description" HeaderText="Description">
                <ItemStyle HorizontalAlign="Left" Width="40%" />
            </asp:BoundField>
            <asp:BoundField DataField="ModuleID" HeaderText="ModuleID" Visible="False" />
        </Columns>
        <FooterStyle BackColor="#2977DC" />
        <HeaderStyle BackColor="#2977DC" ForeColor="White" />
    </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

