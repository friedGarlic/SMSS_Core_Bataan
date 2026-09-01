<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_APP_Supplemental.aspx.vb" 
Inherits="planning_t_APP_Supplemental" title="APP Supplemental" StylesheetTheme="SkinFile"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager id="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel id="UpdatePanel1" runat="server">
<ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY>
    <TR>
        <td align="center" style="width: 10px">
        </td>
        <TD style="WIDTH: 1000px" align="center" class="PageTitle">ANNUAL PROCUREMENT PLAN - SUPPLEMENTAL</TD></TR><TR>
    <td align="center" style="width: 10px">
    </td>
    <TD style="WIDTH: 1000px" align="center" class="column_RightBold">
        DATE : <asp:TextBox id="txtDate" runat="server" Width="120px" ReadOnly="True" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR>
    <td align="center" style="width: 10px">
    </td>
    <TD style="WIDTH: 1000px" align="center"><asp:GridView style="FONT-WEIGHT: normal" id="grdAppSupp" runat="server" Width="70%" OnPageIndexChanging="grdAppSupp_PageIndexChanging" BorderStyle="Solid" SkinID="GridViewAA" AllowPaging="True" AutoGenerateColumns="False" PageSize="8" DataKeyNames="AppropriationSource_ID,Budget_Year" OnSelectedIndexChanged="grdAppSupp_SelectedIndexChanged" Font-Size="9pt">
<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PageButtonCount="5" PreviousPageText="Previous"></PagerSettings>
<Columns>
<asp:TemplateField><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:LinkButton id="lnkSelect" runat="server" CommandName="Select" Font-Underline="False">Select</asp:LinkButton>
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="AppropriationSource_Desc" HeaderText="TITLE">
<ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Status" HeaderText="STATUS" Visible="False">
<ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle HorizontalAlign="Center"></FooterStyle>

<PagerStyle HorizontalAlign="Center"></PagerStyle>
</asp:GridView></TD></TR><TR>
    <td align="center" style="width: 10px">
    </td>
    <TD style="WIDTH: 1000px" class="DivTitle" align="center">PROJECT PROCUREMENT MANAGEMENT PLAN</TD></TR><TR>
    <td align="center" style="width: 10px">
    </td>
    <TD style="WIDTH: 1000px" align="center"><cc1:TabContainer style="TEXT-ALIGN: left" id="TabContainer1" runat="server" ActiveTabIndex="0" Font-Size="9pt"><cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>
<SPAN style="FONT-SIZE: 9pt; FONT-FAMILY: Arial"><strong>Office Operational Expense 
</strong></SPAN>
</HeaderTemplate>
<ContentTemplate>
<asp:GridView style="FONT-WEIGHT: normal" id="gvppmp" runat="server" Width="100%" BorderStyle="Solid" SkinID="GridViewAA" AllowPaging="True" AutoGenerateColumns="False">
<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PageButtonCount="5" PreviousPageText="Previous"></PagerSettings>
<Columns>
<asp:BoundField DataField="rc_name" HeaderText="Department">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Function_Desc" HeaderText="Function">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="GA_CODE2" HeaderText="Account Code">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Amount" DataFormatString="{0:N}" HeaderText="Amount" HtmlEncode="False">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle HorizontalAlign="Center" BackColor="#2977DC"></FooterStyle>

<PagerStyle HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView> 
</ContentTemplate>
</cc1:TabPanel>
<cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2"><HeaderTemplate>
<SPAN style="FONT-SIZE: 9pt; FONT-FAMILY: Arial"><strong>Programs, Activity, and Projects 
</strong></SPAN>
</HeaderTemplate>
<ContentTemplate>
<asp:GridView style="FONT-WEIGHT: normal" id="gvPPA" runat="server" Width="100%" CssClass="text" BorderStyle="Solid" SkinID="GridViewAA" AllowPaging="True" AutoGenerateColumns="False" Font-Size="9pt"><Columns>
<asp:BoundField DataField="rc_name" HeaderText="Department">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Function_Desc" HeaderText="Function">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PPA" HeaderText="PPA">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="GA_CODE2" HeaderText="Account Code">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Amount" DataFormatString="{0:N}" HeaderText="Amount">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>

<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

<PagerStyle HorizontalAlign="Center"></PagerStyle>
</asp:GridView> 
</ContentTemplate>
</cc1:TabPanel>
</cc1:TabContainer></TD></TR><TR>
    <td align="center" style="width: 10px">
    </td>
    <TD style="WIDTH: 1000px" align="center"></TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

