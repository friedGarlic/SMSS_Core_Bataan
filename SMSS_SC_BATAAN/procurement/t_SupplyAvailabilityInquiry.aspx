<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false"
CodeFile="t_SupplyAvailabilityInquiry.aspx.vb" Inherits="procurement_t_SupplyAvailabilityInquiry" 
title="Supply Availability Inquiry - Preparation" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   

<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>
<TABLE style="TEXT-ALIGN: center" width=1015><TBODY><TR><TD style="TEXT-ALIGN: center" width=1015><TABLE class="PageTitle"><TBODY><TR><TD style="WIDTH: 1000px">SUPPLY AVAILABILITY INQUIRY</TD></TR></TBODY></TABLE><BR /><DIV style="TEXT-ALIGN: center"><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 1000px"><asp:Panel id="Panel1" runat="server" Font-Bold="False" CssClass="text" GroupingText="INFORMATION" __designer:wfdid="w1"><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 250px" class="text4">Date :</TD><TD style="WIDTH: 750px" class="text5"><asp:TextBox id="txtDate" runat="server" Width="150px" CssClass="txtboxinspection" __designer:wfdid="w2" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 250px" class="text4">SAI Number :</TD><TD style="WIDTH: 750px" class="text5"><asp:TextBox id="txtSAINumb" runat="server" Width="150px" CssClass="txtboxinspection" __designer:wfdid="w59" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 250px" class="text4">Department :</TD><TD style="WIDTH: 750px" class="text5"><asp:DropDownList id="ddDepartment" runat="server" Width="400px" CssClass="txtboxinspection" __designer:wfdid="w4" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddDepartment_SelectedIndexChanged"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 250px" class="text4">Function :</TD><TD style="WIDTH: 750px" class="text5"><asp:DropDownList id="ddFunction" runat="server" Width="400px" CssClass="txtboxinspection" __designer:wfdid="w5" Enabled="False" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddFunction_SelectedIndexChanged"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 250px" class="text4">Allotment Type :</TD><TD style="WIDTH: 750px" class="text5"><asp:DropDownList id="ddAllotment" runat="server" Width="400px" CssClass="txtboxinspection" __designer:wfdid="w22" Enabled="False" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddAllotment_SelectedIndexChanged"><asp:ListItem>Select</asp:ListItem>
<asp:ListItem>MOOE</asp:ListItem>
<asp:ListItem>Capitay Outlay</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 250px" class="text4">Account Title :</TD><TD style="WIDTH: 750px" class="text5"><asp:DropDownList id="ddAccount" runat="server" Width="400px" CssClass="txtboxinspection" __designer:wfdid="w6" Enabled="False" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddAccount_SelectedIndexChanged"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList><asp:LinkButton id="lnkView" runat="server" Width="152px" ForeColor="RoyalBlue" __designer:wfdid="w7" Enabled="False">View List of Goods</asp:LinkButton></TD></TR><TR><TD style="WIDTH: 250px" class="text4">Inquire by :</TD><TD style="WIDTH: 750px" class="text5"><asp:DropDownList id="ddInquireBy" runat="server" Width="400px" CssClass="txtboxinspection" __designer:wfdid="w54" Enabled="False" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddInquireBy_SelectedIndexChanged"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList> <asp:Label id="lblreq1" runat="server" ForeColor="#FF0000" Font-Size="8pt" __designer:wfdid="w56" Text="* Required Field" Font-Italic="True" Visible="False"></asp:Label></TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 250px" class="text4">Remarks/Purpose :</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 750px" class="text5"><asp:TextBox id="txtRemarks" runat="server" Width="390px" CssClass="txtboxinspection" __designer:wfdid="w50" TextMode="MultiLine" Height="60px"></asp:TextBox> </TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="WIDTH: 1000px"><asp:Panel id="Panel2" runat="server" Width="900px" Font-Bold="False" CssClass="text" GroupingText="ITEMS" __designer:wfdid="w23"><asp:GridView style="FONT-WEIGHT: normal" id="gvbody" runat="server" Width="100%" CssClass="text" __designer:wfdid="w37" EmptyDataText="NO DATA FOUND" CaptionAlign="Left" UseAccessibleHeader="False" ShowFooter="True" SkinID="GridViewGL" AutoGenerateColumns="False" PageSize="50"><Columns>
<asp:BoundField DataField="Item_Desc" HeaderText="Item Description">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="500px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Description" HeaderText="Unit">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Quantity"><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
&nbsp;<asp:TextBox id="txtqty" runat="server" Width="100px" __designer:wfdid="w122" CssClass="txtboxcenter" AutoPostBack="True"></asp:TextBox> <cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" __designer:wfdid="w123" TargetControlID="txtqty" ValidChars="1234567890"></cc1:FilteredTextBoxExtender> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="250px"></ItemStyle>
</asp:TemplateField>
</Columns>

<SelectedRowStyle Font-Bold="False"></SelectedRowStyle>

<HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
</asp:GridView></asp:Panel> <asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="150px" __designer:wfdid="w49" OnClientClick="StartProgressBar();" Enabled="False" Text="SAVE"></asp:Button> <asp:Button id="btnPreview" onclick="btnPreview_Click" runat="server" Width="150px" __designer:wfdid="w48" Enabled="False" Text="PREVIEW"></asp:Button></TD></TR><TR><TD style="WIDTH: 1000px"></TD></TR></TBODY></TABLE></DIV><BR /><asp:Panel style="DISPLAY: none" id="popup" runat="server" Width="900px" __designer:wfdid="w8"><TABLE id="Table8" height=486 cellSpacing=0 cellPadding=0 width=747 border=0><TBODY><TR><TD colSpan=2><IMG height=1 alt="" src="../images/modalpopup_01.png" width=747 /></TD></TR><TR><TD style="BACKGROUND-IMAGE: url(../images/modalpopup_02.png); WIDTH: 772px; HEIGHT: 39px"></TD><TD style="WIDTH: 34px; HEIGHT: 39px"><asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../images/modalpopup_03.png" __designer:wfdid="w9"></asp:ImageButton></TD></TR><TR><TD style="BACKGROUND-IMAGE: url(../images/modalpopup_04.png); VERTICAL-ALIGN: top; WIDTH: 772px" id="Td3"><TABLE style="WIDTH: 705px; HEIGHT: 336px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 4%; TEXT-ALIGN: center"></TD><TD style="VERTICAL-ALIGN: top; WIDTH: 100%; TEXT-ALIGN: center"><asp:UpdatePanel id="UpdatePanel2" runat="server" __designer:wfdid="w10"><ContentTemplate>
<TABLE style="WIDTH: 100%" class="text" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%; HEIGHT: 48px; TEXT-ALIGN: left" colSpan=3>&nbsp;&nbsp;&nbsp;&nbsp; Search:<asp:TextBox id="SearchBut" runat="server" Width="350px" CssClass="text" __designer:wfdid="w15" AutoPostBack="True"></asp:TextBox> <asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Width="100px" Text="SEARCH"></asp:Button></TD></TR></TBODY></TABLE><asp:GridView style="FONT-WEIGHT: normal" id="gvitems" runat="server" Width="100%" CssClass="text" __designer:wfdid="w17" SkinID="gvnew" PageSize="8" AllowPaging="True" OnPageIndexChanging="gvitems_PageIndexChanging" DataKeyNames="item_id,Item_Desc,Description"><Columns>
<asp:TemplateField><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<HeaderTemplate>
<asp:CheckBox id="CheckBox2" runat="server" Width="50px" Font-Bold="True" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" __designer:wfdid="w43" Text="All" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="CheckBox1" runat="server" Width="50px" __designer:wfdid="w45" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Item_Desc" HeaderText="Description">
<HeaderStyle HorizontalAlign="Center" CssClass="text"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Description" HeaderText="Unit">
<HeaderStyle HorizontalAlign="Center" CssClass="text"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Item_id" HeaderText="Item_id">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle Width="10px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="id" HeaderText="id">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Price" DataFormatString="{0:N}" HeaderText="Price">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="gvitems" EventName="SelectedIndexChanging"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel></TD></TR><TR><TD style="WIDTH: 4%; HEIGHT: 24px; TEXT-ALIGN: center"></TD><TD style="WIDTH: 100%; HEIGHT: 24px; TEXT-ALIGN: center"><asp:Button id="btnLoad" onclick="btnLoad_Click" runat="server" Width="150px" __designer:wfdid="w14" OnClientClick="StartProgressBar();" Text="LOAD"></asp:Button></TD></TR></TBODY></TABLE><SPAN style="COLOR: black"></SPAN></TD><TD style="BACKGROUND-IMAGE: url(../images/modalpopup_05.png); WIDTH: 34px; HEIGHT: 446px"></TD></TR></TBODY></TABLE></asp:Panel> <cc1:ModalPopupExtender id="ModalPopupExtendepopup" runat="server" __designer:wfdid="w18" BackgroundCssClass="modalBackground" PopupControlID="popup" TargetControlID="lnkView">
                </cc1:ModalPopupExtender><BR /><asp:Panel style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #0033cc; BORDER-BOTTOM-WIDTH: 1px; BORDER-BOTTOM-COLOR: #0033cc; BORDER-TOP-COLOR: #0033cc; POSITION: relative; BACKGROUND-COLOR: transparent; TEXT-ALIGN: center; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #0033cc" id="PanelProgress" runat="server" Width="109px" __designer:wfdid="w154">
                <img src="../images/ajax-loader.gif" /></asp:Panel> <cc1:ModalPopupExtender id="ProgressBarModalPopupExtender" runat="server" __designer:wfdid="w155" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender> <asp:Button style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; POSITION: relative; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none" id="ButtonProgress" runat="server" Width="16px" __designer:wfdid="w156" Enabled="False"></asp:Button>&nbsp;<BR /><BR /><BR /></TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>

</asp:Content>

