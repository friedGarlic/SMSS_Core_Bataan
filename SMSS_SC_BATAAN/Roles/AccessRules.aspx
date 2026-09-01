<%@ Page Language="VB" MasterPageFile="~/MasterPage1.master" AutoEventWireup="false" CodeFile="AccessRules.aspx.vb" Inherits="Roles_AccessRules" title="Web Systems Manager" StylesheetTheme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 20%">
                <asp:LinkButton ID="lnkBack" runat="server" Font-Size="10pt"><< Back to Role List</asp:LinkButton></td>
            <td style="width: 80%">
            </td>
        </tr>
        <tr>
            <td style="width: 20%; vertical-align: top; text-align: left;">
                &nbsp;<div style="background-color :#FFFBD6">
    <asp:TreeView ID="tvMenu" runat="server" Font-Size="10pt" Font-Names="Verdana" ImageSet="WindowsHelp" ShowLines="True" Width="80%">
        <ParentNodeStyle Font-Bold="False" />
        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
        <SelectedNodeStyle Font-Underline="False" HorizontalPadding="0px" VerticalPadding="0px" BackColor="#B5B5B5" />
        <NodeStyle Font-Names="Verdana" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
            NodeSpacing="0px" VerticalPadding="1px" />
    </asp:TreeView>
    </div>
            </td>
            <td style="width: 80%; vertical-align: text-top; text-align: left;">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td style="width: 80%">
                <div style="border-bottom:dotted 1px #666666; width :300">
                    <h3> Access Rights Applied</h3>
                </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            RoleName:&nbsp;<asp:Label ID="lblRoleName" runat="server" ForeColor="#CC0000"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    Component Name:&nbsp;<asp:Label ID="lblComponent" runat="server" ForeColor="#CC0000"></asp:Label></td>
                    </tr>
                    <tr style="color: #000000; font-style: italic">
                        <td>
                <asp:GridView ID="gvAccessRule" runat="server" Font-Size="10pt" AutoGenerateColumns="False" SkinID="gvnew" Width="100%">
                    <Columns>
                        <asp:CommandField SelectText="Edit Rule" ShowSelectButton="True" />
                        <asp:CheckBoxField DataField="HasAccess" HeaderText="Has Access">
                            <ItemStyle HorizontalAlign="Center" ForeColor="Black" />
                        </asp:CheckBoxField>
                        <asp:CheckBoxField DataField="CanAdd" HeaderText="Can Add">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:CheckBoxField>
                        <asp:CheckBoxField DataField="CanEdit" HeaderText="Can Edit">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:CheckBoxField>
                        <asp:CheckBoxField DataField="CanDelete" HeaderText="Can Delete">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:CheckBoxField>
                        <asp:CheckBoxField DataField="CanPrint" HeaderText="Can Print">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:CheckBoxField>
                        <asp:CheckBoxField DataField="Other" HeaderText="Other">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:CheckBoxField>
                        <asp:BoundField DataField="ComponentId" Visible="False" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#CC0000" Visible="False"></asp:Label>
                <hr />
                        </td>
                    </tr>
                    <tr>
                        <td>
    <table cellpadding ="5" cellspacing ="5" width ="100%">
        <tr>
            <td>
                <h3> Access Rights Management</h3>
                <p> 
                    <em>(Check the appropriate boxes to assign access rights)</em>
                </p>
                <p>
                    <asp:CheckBox ID="cbAccess" runat="server" Text="Has Access" Font-Names="Tahoma" Font-Size="10pt" />
                    |
                    <asp:CheckBox ID="cbAdd" runat="server" Text="Can Add" Font-Names="Tahoma" Font-Size="10pt" />
                    |
                    <asp:CheckBox ID="cbEdit" runat="server" Text="Can Edit" Font-Names="Tahoma" Font-Size="10pt" />
                    |
                    <asp:CheckBox ID="cbDelete" runat="server" Text="Can Delete" Font-Names="Tahoma" Font-Size="10pt" />
                    |
                    <asp:CheckBox ID="cbPrint" runat="server" Text="Can Print" Font-Names="Tahoma" Font-Size="10pt" />
                    |
                    <asp:CheckBox ID="cbOther" runat="server" Text="Other" Font-Names="Tahoma" Font-Size="10pt" />
                </p>
               
                    <br />
                   <p>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update Access Rights" Font-Names="Tahoma" Font-Size="10pt" />
                    </p>
            </td>
        </tr>
      
    </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>


