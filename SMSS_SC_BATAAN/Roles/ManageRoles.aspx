<%@ Page Language="VB" MasterPageFile="~/MasterPage1.master" AutoEventWireup="false" CodeFile="ManageRoles.aspx.vb" EnableEventValidation="false"
Inherits="Roles_ManageRoles" title="Web Systems Manager" StylesheetTheme="SkinFile"%>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>
<TABLE style="WIDTH: 820px"><TBODY><TR><TD style="WIDTH: 820px" class="TitleRow">MANAGE ROLES</TD></TR><TR><TD style="WIDTH: 820px"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 40%" class="text1Bold">Create a New Role :</TD><TD style="WIDTH: 60%" class="text2"><asp:RadioButtonList id="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" __designer:wfdid="w37">
                <asp:ListItem Selected="True" Value="GSO">GSO</asp:ListItem>
                <asp:ListItem Value="Department"></asp:ListItem>
            </asp:RadioButtonList></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 820px"><asp:Panel id="Panel4" runat="server" Width="100%" __designer:wfdid="w38" BorderWidth="1px" BorderStyle="Solid" BorderColor="DeepSkyBlue"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 100%"><asp:MultiView id="MultiView1" runat="server" __designer:wfdid="w53"><asp:View id="View1" runat="server" __designer:wfdid="w54"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 20%" class="text1Bold"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" __designer:wfdid="w55" ControlToValidate="ddRC" ErrorMessage="*" InitialValue="0" ValidationGroup="save"></asp:RequiredFieldValidator> Department :</TD><TD style="WIDTH: 80%" class="text2"><asp:DropDownList id="ddRC" runat="server" Width="493px" AutoPostBack="True" __designer:wfdid="w56" AppendDataBoundItems="True" CssClass="text">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 20%" class="text1Bold"><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" __designer:wfdid="w57" ControlToValidate="ddFunction" ErrorMessage="*" InitialValue="0" ValidationGroup="save"></asp:RequiredFieldValidator> Function :</TD><TD style="WIDTH: 80%" class="text2"><asp:DropDownList id="ddFunction" runat="server" Width="493px" AutoPostBack="True" __designer:wfdid="w58" AppendDataBoundItems="True" CssClass="text">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 20%" class="text1Bold"><asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" __designer:wfdid="w59" ControlToValidate="RoleName" ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator> Role Name :</TD><TD style="WIDTH: 80%" class="text2"><asp:TextBox id="RoleName" runat="server" Width="550px" __designer:wfdid="w60" Enabled="False"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 20%" class="text1Bold"></TD><TD style="WIDTH: 80%" class="text2"><cc1:listsearchextender id="ListSearchExtender1" runat="server" __designer:wfdid="w61" promptcssclass="ListSearchExtenderPrompt" targetcontrolid="ddRC"> </cc1:listsearchextender> <cc1:ListSearchExtender id="ListSearchExtender2" runat="server" __designer:wfdid="w62" PromptCssClass="ListSearchExtenderPrompt" TargetControlID="ddFunction">
                    </cc1:ListSearchExtender> </TD></TR></TBODY></TABLE></asp:View> <asp:View id="View2" runat="server" __designer:wfdid="w63"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 20%" class="text1Bold"><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ValidationGroup="save2" ErrorMessage="*" ControlToValidate="txtRoleName" __designer:wfdid="w64"></asp:RequiredFieldValidator> Role Name : </TD><TD style="WIDTH: 80%" class="text2"><asp:TextBox id="txtRoleName" runat="server" Width="550px" __designer:wfdid="w65"></asp:TextBox></TD></TR></TBODY></TABLE></asp:View> </asp:MultiView></TD></TR><TR><TD style="WIDTH: 100%" class="text3"><asp:Button id="CreateRoleButton" runat="server" CssClass="CSButton" Width="200px" Height="30px" Text="Create Role" __designer:wfdid="w66"></asp:Button></TD></TR><TR><TD style="WIDTH: 100%" class="text3"></TD></TR><TR><TD style="WIDTH: 100%" class="text3"><asp:Label id="lblRoleConfirm" runat="server" Text="* ROLE has been successfully saved." ForeColor="Red" Font-Size="11pt" Font-Names="Arial" Font-Italic="True" __designer:wfdid="w3" Visible="False"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel></TD></TR><TR><TD style="WIDTH: 820px" class="text3"><asp:GridView id="RoleList" runat="server" Width="100%" Font-Size="10pt" __designer:wfdid="w67" SkinID="GridViewAA" AutoGenerateColumns="False"><Columns>
<asp:TemplateField HeaderText="ROLE"><ItemTemplate>
<asp:Label id="RoleNameLabel" runat="server" Text="<%# Container.DataItem %>" __designer:wfdid="w35"></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left" Width="55%"></ItemStyle>
</asp:TemplateField>
<asp:CommandField DeleteText="Delete Role" ShowDeleteButton="True">
<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:CommandField>
<asp:ButtonField CommandName="Manage" Text="Manage Role">
<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
</asp:ButtonField>
<asp:ButtonField CommandName="View" Text="View Users">
<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:ButtonField>
<asp:ButtonField CommandName="Manage RC" Text="Manage RC">
<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:ButtonField>
</Columns>
</asp:GridView><BR /></TD></TR><TR><TD style="WIDTH: 820px" class="text3"><asp:Panel id="Panel1" runat="server" Width="100%" __designer:wfdid="w68"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 100%" class="TitleRow">MANAGE USER <asp:TextBox id="TextBox1" runat="server" __designer:wfdid="w76" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100%"><asp:GridView id="UserAccounts" runat="server" Width="98%" __designer:dtid="1125899906842632" SkinID="GridViewAA" Font-Size="9pt" AutoGenerateColumns="False" Font-Names="Verdana" __designer:wfdid="w69"><Columns __designer:dtid="1125899906842633">
<asp:TemplateField HeaderText="UserName" __designer:dtid="1125899906842634"><ItemTemplate __designer:dtid="1125899906842635">
                                <asp:Label __designer:dtid="1125899906842636" runat="server" ID="UserNameLabel" Text='<%# Container.DataItem %>' ></asp:Label>
                            
</ItemTemplate>

<ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
</asp:TemplateField>
<asp:ButtonField CommandName="Remove" Text="Remove User" __designer:dtid="1125899906842637">
<ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
</asp:ButtonField>
<asp:ButtonField CommandName="Manage" Text="Manage Account" __designer:dtid="1125899906842638">
<ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
</asp:ButtonField>
</Columns>
</asp:GridView> </TD></TR></TBODY></TABLE></asp:Panel></TD></TR><TR><TD style="WIDTH: 820px" class="text3"><asp:Panel id="Panel2" runat="server" Width="100%" __designer:wfdid="w71"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 100%" class="TitleRow">MANAGE RESPONSIBILITY CENTER</TD></TR><TR><TD style="WIDTH: 100%" class="text2"><asp:Label id="Label1" runat="server" Text="RoleName :" ForeColor="Black" Font-Size="8pt" Font-Bold="True" __designer:dtid="1125899906842644" __designer:wfdid="w72"></asp:Label><asp:Label id="lblRoleName" runat="server" Text="Label" ForeColor="#FF8000" Font-Size="10pt" Font-Bold="True" __designer:dtid="1125899906842645" __designer:wfdid="w73"></asp:Label></TD></TR><TR><TD style="WIDTH: 100%" class="text2"><asp:CheckBoxList id="ChkRCList" runat="server" Font-Size="9pt" Font-Names="Century Gothic" Font-Bold="True" __designer:dtid="1125899906842647" AutoPostBack="True" __designer:wfdid="w74" BorderWidth="1px" BorderStyle="Solid" BorderColor="LightSkyBlue" RepeatColumns="3" CellSpacing="0" CellPadding="0"></asp:CheckBoxList></TD></TR></TBODY></TABLE></asp:Panel></TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>        
     
</asp:Content>
