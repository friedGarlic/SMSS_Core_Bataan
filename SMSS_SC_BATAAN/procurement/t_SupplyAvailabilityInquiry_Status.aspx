<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" 
CodeFile="t_SupplyAvailabilityInquiry_Status.aspx.vb"  EnableEventValidation="false"
Inherits="procurement_t_SupplyAvailabilityInquiry_Status" title="Supply Availability Inquiry - Status"
StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   

<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>
<TABLE style="TEXT-ALIGN: center" width=1015><TBODY><TR><TD style="TEXT-ALIGN: center" width=1015><TABLE class="PageTitle"><TBODY><TR><TD style="WIDTH: 1000px">SUPPLY AVAILABILITY INQUIRY - STATUS</TD></TR></TBODY></TABLE><BR /><asp:Panel id="Panel1" runat="server" Font-Bold="False" CssClass="text" GroupingText="INFORMATION" __designer:wfdid="w1"><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 250px" class="text4">Date :</TD><TD style="WIDTH: 750px" class="text5"><asp:TextBox id="txtDate" runat="server" Width="150px" __designer:wfdid="w42" CssClass="txtboxinspection" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 250px" class="text4">Department :</TD><TD style="WIDTH: 750px" class="text5"><asp:DropDownList id="ddDepartment" runat="server" Width="400px" __designer:wfdid="w44" CssClass="txtboxinspection" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="ddDepartment_SelectedIndexChanged"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 250px" class="text4">Function :</TD><TD style="WIDTH: 750px" class="text5"><asp:DropDownList id="ddFunction" runat="server" Width="400px" __designer:wfdid="w45" CssClass="txtboxinspection" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="ddFunction_SelectedIndexChanged" Enabled="False"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 250px" class="text4">Supply Officer :</TD><TD style="WIDTH: 750px" class="text5"><asp:DropDownList id="ddSupplyOfficer" runat="server" Width="400px" __designer:wfdid="w21" CssClass="txtboxinspection" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="ddSupplyOfficer_SelectedIndexChanged" Enabled="False"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList> <asp:Label  id="lblreq" runat="server" ForeColor="#FF0000" Font-Size="9pt" __designer:wfdid="w24" Text="* Required" Font-Italic="True" Visible="False"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel><BR /><DIV style="TEXT-ALIGN: left"><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 1000px"><asp:RadioButtonList id="RadioButtonList3" runat="server" Width="250px" CssClass="text" __designer:wfdid="w112" RepeatDirection="Horizontal" Enabled="False" OnSelectedIndexChanged="RadioButtonList3_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True">For Confirmation</asp:ListItem>
<asp:ListItem>Confirmed</asp:ListItem>
</asp:RadioButtonList></TD></TR></TBODY></TABLE></DIV><BR /><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 1000px" class="DivTitle">SUPPLY AVAILABILITY INQUIRY</TD></TR><TR><TD style="WIDTH: 1000px"><asp:GridView style="FONT-WEIGHT: normal" id="gvSAI" runat="server" Width="1000px" CssClass="text" __designer:wfdid="w52" OnSelectedIndexChanged="gvSAI_SelectedIndexChanged" EmptyDataText="NO DATA FOUND" DataKeyNames="Sai_Hdr_ID" PageSize="20" AutoGenerateColumns="False" ShowFooter="True" UseAccessibleHeader="False" CaptionAlign="Left" SkinID="GridViewGL" AllowPaging="True" OnPageIndexChanging="gvSAI_PageIndexChanging"><Columns>
<asp:CommandField ShowSelectButton="True">
<ItemStyle HorizontalAlign="Center" ForeColor="Blue" Width="100px"></ItemStyle>
</asp:CommandField>
<asp:BoundField DataField="sai_no" HeaderText="SAI NUMBER">
<HeaderStyle Font-Bold="False"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="GA_Title" HeaderText="Account Title">
<ItemStyle HorizontalAlign="Left" Width="350px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Inquiryby" HeaderText="INQUIRED BY">
<ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Sai_Date" DataFormatString="{0:d}" HeaderText="DATE">
<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
</asp:BoundField>
</Columns>

<SelectedRowStyle Font-Bold="False"></SelectedRowStyle>

<HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
</asp:GridView><BR /></TD></TR><TR><TD style="WIDTH: 1000px" class="DivTitle">GOODS</TD></TR><TR><TD style="WIDTH: 1000px"><asp:GridView style="FONT-WEIGHT: normal" id="gvSAI_Items" runat="server" Width="900px" CssClass="text" __designer:wfdid="w52" EmptyDataText="NO DATA FOUND" DataKeyNames="Item_ID,Sai_Hdr_ID" PageSize="50" AutoGenerateColumns="False" ShowFooter="True" UseAccessibleHeader="False" CaptionAlign="Left" SkinID="GridViewGL" AllowPaging="True" OnPageIndexChanging="gvSAI_Items_PageIndexChanging"><Columns>
<asp:BoundField DataField="Item_Desc" HeaderText="ITEM DESCRIPTION">
<ItemStyle HorizontalAlign="Left" Width="400px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="unit" HeaderText="UNIT">
<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="InquireQty" HeaderText="INQUIRED QTY">
<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="AVAILABLE QTY"><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
&nbsp;<asp:TextBox id="txtAvailableQty" runat="server" Width="100px" __designer:wfdid="w120" CssClass="txtboxcenter" Text='<%# bind("AvailbleQty") %>'></asp:TextBox><cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" __designer:wfdid="w121" TargetControlID="txtAvailableQty" ValidChars="1234567890"></cc1:FilteredTextBoxExtender> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="Item_id" HeaderText="item_id"></asp:BoundField>
</Columns>

<SelectedRowStyle Font-Bold="False"></SelectedRowStyle>

<HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
</asp:GridView> </TD></TR><TR><TD style="WIDTH: 1000px"><asp:Button id="btnSAVE" onclick="btnSAVE_Click" runat="server" Width="150px" __designer:wfdid="w22" Enabled="False" OnClientClick="StartProgressBar();" Text="SAVE"></asp:Button> <asp:Button id="btnPreview" onclick="btnPreview_Click" runat="server" Width="150px" __designer:wfdid="w23" Enabled="False" Text="PREVIEW"></asp:Button></TD></TR></TBODY></TABLE><BR /><BR /><asp:Panel style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #0033cc; BORDER-BOTTOM-WIDTH: 1px; BORDER-BOTTOM-COLOR: #0033cc; BORDER-TOP-COLOR: #0033cc; POSITION: relative; BACKGROUND-COLOR: transparent; TEXT-ALIGN: center; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #0033cc" id="PanelProgress" runat="server" Width="109px" __designer:wfdid="w158">
                <img src="../images/ajax-loader.gif" /></asp:Panel> <cc1:ModalPopupExtender id="ProgressBarModalPopupExtender" runat="server" __designer:wfdid="w159" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender> <asp:Button style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; POSITION: relative; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none" id="ButtonProgress" runat="server" Width="16px" __designer:wfdid="w160" Enabled="False"></asp:Button>&nbsp; </TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>
</asp:Content>

