<%@ Page Language="VB" MasterPageFile="~/masterpage1.master" AutoEventWireup="false" CodeFile="ManageUsers.aspx.vb" Inherits="Administration_ManageUsers" title="Web Systems Manager" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
 <asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>
<TABLE style="WIDTH: 820px"><TBODY><TR><TD style="WIDTH: 820px" class="TitleRow">MANAGE USERS</TD></TR><TR><TD style="WIDTH: 820px" class="text2"></TD></TR><TR><TD style="WIDTH: 820px" class="text2"><asp:Repeater id="FilteringUI" runat="server" __designer:dtid="1688849860263941" __designer:wfdid="w15">
            <ItemTemplate __designer:dtid="1688849860263942">
                <asp:LinkButton __designer:dtid="1688849860263943" runat="server" ID="lnkFilter" 
                                Text='<%# Container.DataItem %>' 
                                CommandName='<%# Container.DataItem %>'></asp:LinkButton>
            </ItemTemplate>
            
            <SeparatorTemplate __designer:dtid="1688849860263944">|</SeparatorTemplate>
        </asp:Repeater></TD></TR><TR><TD style="WIDTH: 820px" class="text2"><asp:GridView id="UserAccounts" runat="server" Width="100%" __designer:dtid="1688849860263946" SkinID="GridViewAA" Font-Names="Verdana" Font-Size="9pt" AutoGenerateColumns="False" __designer:wfdid="w16"><Columns __designer:dtid="1688849860263947">
<asp:HyperLinkField DataNavigateUrlFields="UserName" DataNavigateUrlFormatString="UserInformation.aspx?user={0}" Text="Manage" __designer:dtid="1688849860263948">
<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="UserName" HeaderText="UserName" __designer:dtid="1688849860263949">
<ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Email" HeaderText="Email" __designer:dtid="1688849860263950">
<ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
</asp:BoundField>
<asp:CheckBoxField DataField="IsApproved" HeaderText="Approved?" __designer:dtid="1688849860263951">
<ItemStyle HorizontalAlign="Center" Width="10%" __designer:dtid="1688849860263952"></ItemStyle>
</asp:CheckBoxField>
<asp:CheckBoxField DataField="IsLockedOut" HeaderText="Locked Out?" __designer:dtid="1688849860263953">
<ItemStyle HorizontalAlign="Center" Width="10%" __designer:dtid="1688849860263954"></ItemStyle>
</asp:CheckBoxField>
<asp:CheckBoxField DataField="IsOnline" HeaderText="Online?" __designer:dtid="1688849860263955">
<ItemStyle HorizontalAlign="Center" Width="10%" __designer:dtid="1688849860263956"></ItemStyle>
</asp:CheckBoxField>
<asp:BoundField DataField="Comment" HeaderText="Comment" __designer:dtid="1688849860263957">
<ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView></TD></TR><TR><TD style="WIDTH: 820px" class="text3"><asp:LinkButton id="lnkFirst" runat="server" __designer:dtid="1688849860263959" __designer:wfdid="w17">&lt;&lt; First</asp:LinkButton>| <asp:LinkButton id="lnkPrev" runat="server" __designer:dtid="1688849860263960" __designer:wfdid="w18">&lt; Prev</asp:LinkButton>| <asp:LinkButton id="lnkNext" runat="server" __designer:dtid="1688849860263961" __designer:wfdid="w19">Next &gt;</asp:LinkButton>| <asp:LinkButton id="lnkLast" runat="server" __designer:dtid="1688849860263962" __designer:wfdid="w20">Last &gt;&gt;</asp:LinkButton></TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>  
</asp:Content>

