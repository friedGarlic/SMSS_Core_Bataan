<%@ Page Language="VB" MasterPageFile="~/MasterPage1.master" AutoEventWireup="false" EnableEventValidation="false" 
CodeFile="ManageMenu.aspx.vb" Inherits="Menu_ManageMenu" title="Web Systems Manager" 
StylesheetTheme="SkinFile"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">


    <table style="width: 820px">
        <tr>
            <td colspan="2" style="width: 100%; text-align: left" class="TitleRow">
                &nbsp;MANAGE MENU</td>
        </tr>
        <tr>
            <td colspan="2" style="width: 100%; text-align: left">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="font-size: 10pt; font-family: Verdana; width: 20%; text-align: left;" class="text1Bold">
                Application :
            </td>
            <td style="width: 80%" class="text2">
                <asp:DropDownList ID="ddlApplication" runat="server" AutoPostBack="True" Font-Names="Verdana"
                    Font-Size="10pt" Width="250px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="font-size: 10pt; font-family: Verdana; width: 20%; text-align: left;" class="text1Bold">
                Menu Name :&nbsp;</td>
            <td style="width: 80%" class="text2">
                <asp:TextBox ID="txtModule" runat="server" Font-Names="Verdana" Font-Size="10pt"
                    Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="font-size: 10pt; font-family: Verdana; width: 20%; text-align: left;" class="text1Bold">
                Description :
            </td>
            <td style="width: 80%" class="text2">
                <asp:TextBox ID="txtDescription" runat="server" Font-Names="Verdana" Font-Size="10pt"
                    Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="font-size: 10pt; font-family: Verdana; width: 20%; text-align: left;" class="text1Bold">
                Home Page URL :
            </td>
            <td style="width: 80%" class="text2">
                <asp:TextBox ID="txtURL" runat="server" Font-Names="Verdana" Font-Size="10pt" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="font-size: 10pt; font-family: Verdana; width: 20%; text-align: left;" class="text1Bold">
                Sequence No. :
            </td>
            <td style="width: 80%" class="text2">
                <asp:TextBox ID="txtSequence" runat="server" Font-Names="Verdana" Font-Size="10pt"
                    Width="50px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="font-size: 10pt; width: 20%; font-family: Verdana; text-align: left;" class="text1Bold">
            </td>
            <td style="width: 70%" class="text2">
                <asp:Button ID="btnCreate" runat="server" CssClass="CSButton" Font-Names="Tahoma" Font-Size="10pt" Text="Submit" Width="150px" />
                </td>
        </tr>
        <tr>
            <td colspan="2" style="width: 100%; text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="width: 100%; text-align: center;">
                <asp:Label ID="CreateStatus" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="width: 100%; text-align: center">
    <asp:GridView ID="grdMenu" runat="server" AutoGenerateColumns="False" DataKeyNames="ModuleName,Description,SequenceNo,ApplicationID,ModuleID"
        SkinID="gvnew" Style="font-weight: normal; position: relative" Width="100%">
        <Columns>
            <asp:CommandField SelectText="Edit" ShowSelectButton="True">
                <ItemStyle ForeColor="Blue" Width="10%" />
            </asp:CommandField>
            <asp:BoundField DataField="SequenceNo" HeaderText="Sequence No">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="20%" />
            </asp:BoundField>
            <asp:BoundField DataField="ModuleName" HeaderText="Menu Name">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="35%" />
            </asp:BoundField>
            <asp:BoundField DataField="Description" HeaderText="Description">
                <ItemStyle HorizontalAlign="Left" Width="35%" />
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

