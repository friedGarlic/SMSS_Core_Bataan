<%@ Page Language="VB" MasterPageFile="~/MasterPage1.master" AutoEventWireup="false" CodeFile="UsersAndRoles.aspx.vb" Inherits="Roles_UsersAndRoles" title="Web Systems Manager" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<script type="text/javascript">
        function ChangeCheckBoxState(id, checkState)
        {
            var cb = document.getElementById(id);
            if (cb != null)
               cb.checked = checkState;
        }
        
        function ChangeAllCheckBoxStates(checkState)
        {
            // Toggles through all of the checkboxes defined in the CheckBoxIDs array
            // and updates their value to the checkState input parameter
            if (CheckBoxIDs != null)
            {
                for (var i = 0; i < CheckBoxIDs.length; i++)
                   ChangeCheckBoxState(CheckBoxIDs[i], checkState);
            }
        }
        
        function ChangeHeaderAsNeeded()
        {
            // Whenever a checkbox in the GridView is toggled, we need to
            // check the Header checkbox if ALL of the GridView checkboxes are
            // checked, and uncheck it otherwise
            if (CheckBoxIDs != null)
            {
                // check to see if all other checkboxes are checked
                for (var i = 1; i < CheckBoxIDs.length; i++)
                {
                    var cb = document.getElementById(CheckBoxIDs[i]);
                    if (!cb.checked)
                    {
                        // Whoops, there is an unchecked checkbox, make sure
                        // that the header checkbox is unchecked
                        ChangeCheckBoxState(CheckBoxIDs[0], false);
                        return;
                    }
                }
                
                // If we reach here, ALL GridView checkboxes are checked
                ChangeCheckBoxState(CheckBoxIDs[0], true);
            }
        }

    </script>
    
<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>
<TABLE style="WIDTH: 820px"><TBODY><TR><TD style="WIDTH: 820px" class="TitleRow">USER ROLE MANAGEMENT</TD></TR><TR><TD style="WIDTH: 820px"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 40%" class="text1Bold">Filter User / Roles by Application :</TD><TD style="WIDTH: 100px" class="text2"><asp:DropDownList id="ddlApplication" runat="server" Width="250px" __designer:dtid="1125899906842630" AutoPostBack="True" __designer:wfdid="w1"></asp:DropDownList></TD></TR></TBODY></TABLE><BR /></TD></TR><TR><TD style="WIDTH: 820px" class="text2"><asp:Repeater id="FilteringUI" runat="server" __designer:dtid="1125899906842632" __designer:wfdid="w2">
                <ItemTemplate __designer:dtid="1125899906842633">
                    <asp:LinkButton __designer:dtid="1125899906842634" runat="server" ID="lnkFilter" 
                                    Text='<%# Container.DataItem %>' 
                                    CommandName='<%# Container.DataItem %>'></asp:LinkButton>
                </ItemTemplate>
                
                <SeparatorTemplate __designer:dtid="1125899906842635">|</SeparatorTemplate>
            </asp:Repeater></TD></TR><TR><TD style="WIDTH: 820px" class="text2"><asp:Panel id="Panel1" runat="server" Width="100%" __designer:wfdid="w3" BorderColor="DeepSkyBlue" BorderStyle="Solid" BorderWidth="1px"><asp:GridView id="UserAccounts" runat="server" Width="100%" __designer:dtid="1125899906842636" SkinID="GridViewAA" AutoGenerateColumns="False" Font-Size="9pt" Font-Names="Verdana" __designer:wfdid="w4"><Columns __designer:dtid="1125899906842637">
<asp:TemplateField __designer:dtid="1125899906842638"><HeaderTemplate __designer:dtid="1125899906842639">
                        <asp:CheckBox __designer:dtid="1125899906842640" ID="HeaderLevelCheckBox" runat="server"  />
                    
</HeaderTemplate>
<ItemTemplate __designer:dtid="1125899906842641">
                        <asp:CheckBox __designer:dtid="1125899906842642" ID="RowLevelCheckBox" runat="server"  />
                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="UserName" HeaderText="UserName" __designer:dtid="1125899906842643">
<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Email" HeaderText="Email" __designer:dtid="1125899906842644">
<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
</asp:BoundField>
<asp:CheckBoxField DataField="IsApproved" HeaderText="Approved?" __designer:dtid="1125899906842645">
<ItemStyle HorizontalAlign="Center" Width="15%" __designer:dtid="1125899906842646"></ItemStyle>
</asp:CheckBoxField>
<asp:CheckBoxField DataField="IsLockedOut" HeaderText="Locked Out?" __designer:dtid="1125899906842647">
<ItemStyle HorizontalAlign="Center" Width="15%" __designer:dtid="1125899906842648"></ItemStyle>
</asp:CheckBoxField>
</Columns>
</asp:GridView></asp:Panel></TD></TR><TR><TD style="WIDTH: 820px" class="text3"><asp:LinkButton id="lnkFirst" runat="server" __designer:dtid="1125899906842650" __designer:wfdid="w5">&lt;&lt; First</asp:LinkButton>| <asp:LinkButton id="lnkPrev" runat="server" __designer:dtid="1125899906842651" __designer:wfdid="w6">&lt; Prev</asp:LinkButton>| <asp:LinkButton id="lnkNext" runat="server" __designer:dtid="1125899906842652" __designer:wfdid="w7">Next &gt;</asp:LinkButton>|&nbsp;<asp:LinkButton id="lnkLast" runat="server" __designer:dtid="1125899906842653" __designer:wfdid="w8">Last &gt;&gt;</asp:LinkButton>&nbsp;<asp:Literal id="CheckBoxIDsArray" runat="server" __designer:dtid="1125899906842654" __designer:wfdid="w9"></asp:Literal></TD></TR><TR><TD style="WIDTH: 820px" class="text2"></TD></TR><TR><TD style="WIDTH: 820px" class="TitleRow">MANAGE USER BY ROLE</TD></TR><TR><TD style="WIDTH: 820px" class="text2"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 20%" class="text1Bold">Select a Role :</TD><TD style="WIDTH: 30%" class="text2"><asp:DropDownList id="RoleList" runat="server" Width="98%" __designer:dtid="1125899906842659" __designer:wfdid="w10"></asp:DropDownList></TD><TD style="WIDTH: 20%" class="text2"><asp:Button id="AddUserToRoleButton" runat="server" CssClass="CSButton" Width="150px" Text="Add User/s to Role" __designer:dtid="1125899906842660" Font-Size="10pt" Font-Names="Verdana" __designer:wfdid="w11"></asp:Button></TD><TD style="WIDTH: 30%" class="text2"><asp:Button id="ViewUsers" runat="server" CssClass="CSButton" Width="150px" Text="View Users" __designer:dtid="1125899906842661" Font-Size="10pt" Font-Names="Verdana" __designer:wfdid="w12"></asp:Button></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 820px" class="text3"><asp:GridView id="RolesUserList" runat="server" Width="98%" __designer:dtid="1125899906842663" SkinID="GridViewAA" AutoGenerateColumns="False" Font-Size="10pt" Font-Names="Verdana" EmptyDataText="No users belong to this role." __designer:wfdid="w13"><Columns __designer:dtid="1125899906842664">
<asp:CommandField DeleteText="Remove" ShowDeleteButton="True" __designer:dtid="1125899906842665">
<ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
</asp:CommandField>
<asp:TemplateField HeaderText="Users" __designer:dtid="1125899906842666"><ItemTemplate __designer:dtid="1125899906842667">
                        <asp:Label __designer:dtid="1125899906842668" runat="server" id="UserNameLabel" Text='<%# Container.DataItem %>'></asp:Label>
                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Left" Width="80%"></ItemStyle>
</asp:TemplateField>
</Columns>
</asp:GridView></TD></TR><TR><TD style="WIDTH: 820px" class="text3"><asp:Label id="ActionStatus" runat="server" __designer:dtid="1125899906842670" CssClass="Important" __designer:wfdid="w14"></asp:Label></TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>
</asp:Content>

