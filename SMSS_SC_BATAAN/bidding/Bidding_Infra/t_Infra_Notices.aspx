<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_Infra_Notices.aspx.vb" 
Inherits="bidding_Bidding_Infra_t_Infra_Notices" title="INFRA - NOTICES" EnableEventValidation="false"  StylesheetTheme="SkinFile"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager id="ScriptManager1" runat="server">
</asp:ScriptManager>

<asp:UpdatePanel id="UpdatePanel1" runat="server">
<contenttemplate>
<TABLE style="WIDTH: 1010px"><TBODY>
    <tr>
        <td align="center" style="width: 10px">
        </td>
        <td align="center" style="width: 1000px">
        </td>
    </tr>
    <TR>
        <td align="center" style="width: 10px">
        </td>
        <TD style="WIDTH: 1000px" class="PageTitle" align=center>INFRA - NOTICES</TD></TR><TR>
    <td align="center" style="width: 10px">
    </td>
    <TD style="WIDTH: 1000px" align=center><SPAN style="FONT-SIZE: 10pt; FONT-FAMILY: Tahoma"><STRONG>DATE :</STRONG></SPAN> <asp:TextBox id="txtDate" runat="server" Width="100px"></asp:TextBox><SPAN style="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma">(MM/DD/YYYY)</SPAN></TD></TR><TR>
    <td align="center" style="width: 10px">
    </td>
    <TD style="MARGIN-BOTTOM: 0px; PADDING-BOTTOM: 0px; WIDTH: 1000px" align=center><asp:Button id="btnNOA" onclick="btnNOA_Click" runat="server" Width="250px" CssClass="Initial" Text="NOTICE OF AWARD" OnClientClick="StartProgressBar();"></asp:Button><asp:Button id="btnNTP" onclick="btnNTP_Click" runat="server" Width="250px" CssClass="Initial" Text="NOTICE TO PROCEED" OnClientClick="StartProgressBar();"></asp:Button></TD></TR><TR>
    <td align="center" style="width: 10px">
    </td>
    <TD style="BORDER-RIGHT: silver 1px solid; BORDER-TOP: silver 1px solid; MARGIN-TOP: 0px; BORDER-LEFT: silver 1px solid; WIDTH: 1000px; PADDING-TOP: 0px; BORDER-BOTTOM: silver 1px solid" align=center><asp:MultiView id="mvNotice" runat="server"><asp:View id="vwNOA" runat="server"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 100%" align=center><SPAN style="FONT-SIZE: 10pt; FONT-FAMILY: Tahoma"><STRONG>SEARCH BY :</STRONG></SPAN> <asp:DropDownList id="ddSearch_NOA" runat="server" Width="120px"><asp:ListItem Selected="True" Value="1">PR Number</asp:ListItem>
<asp:ListItem Value="2">Project Name</asp:ListItem>
<asp:ListItem Value="3">ITB Number</asp:ListItem>
</asp:DropDownList><asp:TextBox id="txtSearch_NOA" runat="server" Width="300px"></asp:TextBox><asp:Button id="btnSearch_NOA" onclick="btnSearch_NOA_Click" runat="server" Width="150px" Font-Bold="True" Font-Size="10pt" Font-Names="Tahoma" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></TD></TR><TR><TD style="WIDTH: 100%" align=center><asp:GridView style="FONT-WEIGHT: normal; TEXT-ALIGN: justify" id="grdNOA" runat="server" Width="99%" OnPageIndexChanging="grdNOA_PageIndexChanging" DataKeyNames="Infra_Hdr_ID,pre_procurement_hdr_id,Supplier_ID,prhdr_id,Total_Amount,project_name,pr_no" PageSize="15" AutoGenerateColumns="False" OnSelectedIndexChanged="grdNOA_SelectedIndexChanged" AllowPaging="True" SkinID="GridViewAA" EmptyDataText="No Data Found." Font-Size="9pt"><Columns>
<asp:TemplateField><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:LinkButton id="lnkSelect" runat="server" Font-Underline="False" CommandName="Select" Visible='<%# BIND ("IsVisible") %>'>Select</asp:LinkButton> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="pr_no" HeaderText="PR Number">
<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ITBNumb" HeaderText="ITB No.">
<ItemStyle HorizontalAlign="Center" Width="13%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SuppName" HeaderText="Bidder">
<ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="project_name" HeaderText="Project Name">
<ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Total_Amount" DataFormatString="{0:N}" HeaderText="Bid Amount">
<ItemStyle HorizontalAlign="Right" Width="12%"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView></TD></TR><TR><TD style="WIDTH: 100%" align=center><SPAN style="FONT-SIZE: 10pt; FONT-FAMILY: Tahoma"><STRONG>APPROVED BY :</STRONG></SPAN> <asp:DropDownList id="ddApprovedBy_NOA" runat="server" Width="300px"></asp:DropDownList><asp:Button id="btnSave_NOA" onclick="btnSave_NOA_Click" runat="server" Width="150px" Font-Bold="True" Font-Size="10pt" Font-Names="Tahoma" Text="SAVE" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button><asp:Button id="btnPreview_NOA" onclick="btnPreview_NOA_Click" runat="server" Width="150px" Font-Bold="True" Font-Size="10pt" Font-Names="Tahoma" Text="PREVIEW" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button></TD></TR></TBODY></TABLE></asp:View> <asp:View id="vwNTP" runat="server"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 100%" align=center><SPAN style="FONT-SIZE: 10pt; FONT-FAMILY: Tahoma"><STRONG>SEARCH BY :</STRONG></SPAN> <asp:DropDownList id="ddSearch_NTP" runat="server" Width="120px"><asp:ListItem Selected="True" Value="1">PR Number</asp:ListItem>
<asp:ListItem Value="2">Project Name</asp:ListItem>
<asp:ListItem Value="3">ITB Number</asp:ListItem>
</asp:DropDownList><asp:TextBox id="txtSearch_NTP" runat="server" Width="300px"></asp:TextBox><asp:Button id="btnSearch_NTP" onclick="btnSearch_NTP_Click" runat="server" Width="150px" Font-Bold="True" Font-Size="10pt" Font-Names="Tahoma" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></TD></TR><TR><TD style="WIDTH: 100%" align=center><asp:GridView style="FONT-WEIGHT: normal; TEXT-ALIGN: justify" id="grdNTP" runat="server" Width="99%" DataKeyNames="Infra_Hdr_ID,pre_procurement_hdr_id" PageSize="15" AutoGenerateColumns="False" OnSelectedIndexChanged="grdNTP_SelectedIndexChanged" AllowPaging="True" SkinID="GridViewAA" EmptyDataText="No Data Found." Font-Size="9pt"><Columns>
<asp:TemplateField><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:LinkButton id="lnkSelect" runat="server" Font-Underline="False" CommandName="Select" Visible='<%# BIND ("IsVisible") %>'>Select</asp:LinkButton> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="pr_no" HeaderText="PR Number">
<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ITBNumb" HeaderText="ITB No.">
<ItemStyle HorizontalAlign="Center" Width="13%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SuppName" HeaderText="Bidder">
<ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="project_name" HeaderText="Project Name">
<ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Total_Amount" DataFormatString="{0:N}" HeaderText="Bid Amount">
<ItemStyle HorizontalAlign="Right" Width="12%"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView></TD></TR><TR><TD style="WIDTH: 100%" align=center><SPAN style="FONT-SIZE: 10pt; FONT-FAMILY: Tahoma"><STRONG>APPROVED BY :</STRONG></SPAN> <asp:DropDownList id="ddApprovedBy_NTP" runat="server" Width="300px"></asp:DropDownList><asp:Button id="btnSave_NTP" onclick="btnSave_NTP_Click" runat="server" Width="150px" Font-Bold="True" Font-Size="10pt" Font-Names="Tahoma" Text="SAVE" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button><asp:Button id="btnPreview_NTP" onclick="btnPreview_NTP_Click" runat="server" Width="150px" Font-Bold="True" Font-Size="10pt" Font-Names="Tahoma" Text="PREVIEW" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button></TD></TR></TBODY></TABLE></asp:View></asp:MultiView></TD></TR><TR>
    <td align="center" style="width: 10px">
    </td>
    <TD style="WIDTH: 1000px" align=center></TD></TR></TBODY></TABLE><asp:Panel style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #0033cc; BORDER-BOTTOM-WIDTH: 1px; BORDER-BOTTOM-COLOR: #0033cc; BORDER-TOP-COLOR: #0033cc; BACKGROUND-COLOR: transparent; TEXT-ALIGN: center; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #0033cc" id="PanelProgress" runat="server" Width="109px"><IMG src="../../images/ajax-loader.gif" /></asp:Panel> <cc1:ModalPopupExtender id="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender> <asp:Button style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none" id="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp; 
</contenttemplate>
</asp:UpdatePanel>
</asp:Content>

