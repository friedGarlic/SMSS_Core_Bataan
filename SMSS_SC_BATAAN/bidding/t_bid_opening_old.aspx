<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    StylesheetTheme="SkinFile" CodeFile="t_bid_opening_old.aspx.vb" Inherits="t_bid_opening" Title="BID Opening" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<table width="1015px" style="text-align:center">
<tr>
<td width="1015px" style="text-align:center">


    <table class="PageTitle">
        <tr>
            <td style="width: 1000px">
                &nbsp;BID OPENING</td>
        </tr>
    </table>
    <br />



 <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   

<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>
<TABLE style="WIDTH: 1000px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD colSpan=8><asp:UpdatePanel id="upCollapse" runat="server"><ContentTemplate>
<%--<cc1:CollapsiblePanelExtender id="cpe1" runat="server" SuppressPostBack="true" ExpandedText="Collapse" CollapsedText="Expand" ImageControlID="imgBackground1" CollapsedImage="../images/BackGroundProject.png" Collapsed="false" ExpandedImage="../images/HighLightProject.png" ExpandControlID="panelTitle1" CollapseControlID="panelTitle1" TargetControlID="pnlContent1"></cc1:CollapsiblePanelExtender> <cc1:CollapsiblePanelExtender id="cpe2" runat="server" SuppressPostBack="True" ExpandedText="Collapse" CollapsedText="Expand" ImageControlID="imgBackground2" CollapsedImage="../images/BackGroundSupplier.png" Collapsed="true" ExpandedImage="../images/HighLightSupplier.png" ExpandControlID="panelTitle2" CollapseControlID="panelTitle2" TargetControlID="panelContent2"></cc1:CollapsiblePanelExtender> --%><asp:Panel id="panelTitle1" runat="server" Width="1000px" Height="25px"><IMG id="imgBackground1" height=28 src="../images/BackGroundProject.png" width=1000 /></asp:Panel> <asp:Panel id="pnlContent1" runat="server" Width="98%"><DIV style="BORDER-RIGHT: #cccccc 2px solid; PADDING-RIGHT: 0px; BORDER-TOP: #cccccc 0px solid; PADDING-LEFT: 0px; FONT-WEIGHT: normal; PADDING-BOTTOM: 0px; MARGIN: 0px; BORDER-LEFT: #cccccc 2px solid; WIDTH: 98%; PADDING-TOP: 0px; BORDER-BOTTOM: #cccccc 2px solid"><asp:GridView style="FONT-WEIGHT: normal; TEXT-ALIGN: justify" id="gvPublic_bidding" runat="server" Width="100%" PageSize="8" OnSelectedIndexChanged="gvPublic_bidding_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="pre_procurement_hdr_id,abc,CountSupplier,obr_evaluation_hdr_id,isPublicInfra" SkinID="GridView"><Columns>
<asp:TemplateField HeaderText="Project Reference " ShowHeader="False"><ItemTemplate>
<asp:LinkButton id="LinkButton1" onclick="LinkButton1_Click" runat="server" CausesValidation="False" Text='<%# bind("project_reference_no") %>' Font-Underline="False" CommandName="Select"></asp:LinkButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateField>
<asp:BoundField DataField="project_name" HeaderText="Project Name">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="CountSupplier" HeaderText="No. of Supplier">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="ABC"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("abc") %>' id="TextBox2"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("abc", "{0:N}") %>' Visible='<%# bind("isVisible") %>'></asp:Label>
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView></DIV></asp:Panel> <asp:Panel id="panelTitle2" runat="server" Width="1000px" Height="25px"><IMG id="imgBackground2" height=28 src="../images/BackGroundSupplier.png" width=1000 /></asp:Panel> <asp:Panel style="TEXT-ALIGN: center" id="panelContent2" runat="server" Width="98%" CssClass="text"><DIV style="BORDER-RIGHT: #cccccc 2px solid; PADDING-RIGHT: 0px; BORDER-TOP: #cccccc 0px solid; PADDING-LEFT: 0px; FONT-WEIGHT: normal; PADDING-BOTTOM: 0px; MARGIN: 0px; BORDER-LEFT: #cccccc 2px solid; WIDTH: 98%; PADDING-TOP: 0px; BORDER-BOTTOM: #cccccc 2px solid"><asp:Label id="Label12" runat="server" ForeColor="Red" Text="Note: If Bidder is not present just leave it blank."></asp:Label><BR /><asp:GridView id="gvsupplier" runat="server" Width="100%" CssClass="text" SkinID="gvnew" DataKeyNames="Supplier_Id" AutoGenerateColumns="False" OnSelectedIndexChanged="gvsupplier_SelectedIndexChanged" PageSize="8"><Columns>
<asp:TemplateField HeaderText="Bid Security Details"><EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server"></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<TABLE style="WIDTH: 481px" class="text" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD><asp:Label id="Label4" runat="server" Text="Bidder" Visible='<%# bind("isVisible") %>'></asp:Label></TD><TD style="WIDTH: 12px">:</TD><TD><asp:Label id="Label2" runat="server" Font-Bold="True" Text='<%# bind("SuppName") %>'></asp:Label></TD></TR><TR><TD><asp:Label id="Label5" runat="server" Text="Form of Bid Security" Visible='<%# bind("isVisible") %>'></asp:Label></TD><TD style="WIDTH: 12px">:</TD><TD><asp:DropDownList id="ddBid" runat="server" OnSelectedIndexChanged="ddBid_SelectedIndexChanged" AutoPostBack="True">
</asp:DropDownList></TD></TR><TR><TD><asp:Label id="Label6" runat="server" Text="Bank/ Company" Visible='<%# bind("isVisible") %>'></asp:Label></TD><TD style="WIDTH: 12px">:</TD><TD><asp:TextBox id="txtBankName" runat="server" Width="300px" Text='<%# bind("bank") %>' Visible='<%# bind("isVisible") %>' AutoPostBack="True" OnTextChanged="txtBankName_TextChanged"></asp:TextBox></TD></TR><TR><TD><asp:Label id="Label7" runat="server" Text="Number" Visible='<%# bind("isVisible") %>'></asp:Label></TD><TD style="WIDTH: 12px">:</TD><TD><asp:TextBox id="txtNumber" runat="server" Width="300px" Text='<%# bind("number") %>' Visible='<%# bind("isVisible") %>' AutoPostBack="True" OnTextChanged="txtNumber_TextChanged"></asp:TextBox></TD></TR><TR><TD><asp:Label id="Label8" runat="server" Text="Validity Period" Visible='<%# bind("isVisible") %>'></asp:Label></TD><TD style="WIDTH: 12px">:</TD><TD><asp:TextBox style="TEXT-ALIGN: right" id="txtValidityPeriod" runat="server" Width="60px" Text='<%# bind("validityPeriod") %>' Visible='<%# bind("isVisible") %>' AutoPostBack="True" OnTextChanged="txtValidityPeriod_TextChanged"></asp:TextBox><asp:Label id="Label3" runat="server" Text="(Days)" Visible='<%# bind("isVisible") %>'></asp:Label> <cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender2" runat="server" TargetControlID="txtValidityPeriod" ValidChars="0123456789"></cc1:FilteredTextBoxExtender></TD></TR><TR><TD><asp:Label id="Label9" runat="server" Text="Bid Security Amount" Visible='<%# bind("isVisible") %>'></asp:Label></TD><TD style="WIDTH: 12px">:</TD><TD><asp:TextBox style="TEXT-ALIGN: right" id="txtBidSecurityAmount" runat="server" Width="150px" Text='<%# bind("Bid_security","{0:N}") %>' Visible='<%# bind("isVisible","{0:N}") %>' AutoPostBack="True" OnTextChanged="txtBidSecurityAmount_TextChanged"></asp:TextBox> <cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender3" runat="server" TargetControlID="txtBidSecurityAmount" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender></TD></TR><TR><TD><asp:Label id="Label10" runat="server" Text="Required Bid Security" Visible='<%# bind("isVisible") %>'></asp:Label></TD><TD style="WIDTH: 12px">:</TD><TD><asp:TextBox style="TEXT-ALIGN: right" id="txtRequiredBid" runat="server" Width="150px" Text='<%# bind("requiredBid_security","{0:N}") %>' Visible='<%# bind("isVisible") %>' ReadOnly="True"></asp:TextBox></TD></TR></TBODY></TABLE>
</ItemTemplate>

<ItemStyle Width="50%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server"></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<TABLE style="WIDTH: 378px" class="text" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD><asp:Label id="Label14" runat="server" Text="Bid Amount" Visible='<%# bind("isVisible") %>'></asp:Label></TD><TD style="WIDTH: 12px">:</TD><TD style="WIDTH: 288px"><asp:TextBox style="TEXT-ALIGN: right" id="txtamount" runat="server" Text='<%# bind("amount","{0:N}") %>' Width="100px" Visible='<%# bind("isVisible") %>' AutoPostBack="True" OnTextChanged="txtamount_TextChanged"></asp:TextBox><cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="txtamount" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender></TD></TR><TR><TD><asp:Label id="Label11" runat="server" Text="Remarks" Visible='<%# bind("isVisible") %>'></asp:Label></TD><TD style="WIDTH: 12px">:</TD><TD style="WIDTH: 288px"><asp:TextBox id="txtRemarks" runat="server" Text='<%# bind("remarks") %>' Width="250px" Visible='<%# bind("isVisible") %>' AutoPostBack="True" OnTextChanged="txtRemarks_TextChanged"></asp:TextBox></TD></TR><TR><TD></TD><TD style="WIDTH: 12px"></TD><TD style="WIDTH: 288px"></TD></TR><TR><TD></TD><TD style="WIDTH: 12px"></TD><TD style="WIDTH: 288px"></TD></TR><TR><TD></TD><TD style="WIDTH: 12px"></TD><TD style="WIDTH: 288px"></TD></TR><TR><TD></TD><TD style="WIDTH: 12px"></TD><TD style="WIDTH: 288px"></TD></TR><TR><TD></TD><TD style="WIDTH: 12px"></TD><TD style="WIDTH: 288px"></TD></TR></TBODY></TABLE>&nbsp; 
</ItemTemplate>

<ItemStyle Width="38%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="Status" HeaderText="Status">
<ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="12%"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView> <TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><%--<TD style="FONT-WEIGHT: normal; COLOR: white; BACKGROUND-COLOR: #507cd1; TEXT-ALIGN: left" class="text"><STRONG>Supplier Name:</STRONG> <asp:DropDownList id="ddSupplier" runat="server" __designer:wfdid="w35" Width="582px" OnSelectedIndexChanged="ddSupplier_SelectedIndexChanged" AppendDataBoundItems="True" Enabled="False" AutoPostBack="True"><asp:ListItem Value="0">Select</asp:ListItem>
</asp:DropDownList><asp:Button id="btnsupplier" onclick="btnsupplier_Click" runat="server" Text="ADD SUPPLIER" __designer:wfdid="w36" Width="150px" Enabled="False"></asp:Button></TD>--%></TR></TBODY></TABLE><BR /></DIV></asp:Panel><asp:Button id="btnsubmit" runat="server" Width="200px" OnClientClick="StartProgressBar();" Text="SAVE"></asp:Button> <asp:Button id="btnFail" onclick="btnFail_Click" runat="server" Width="200px" Text="FAILURE OF BIDDING" Visible="False"></asp:Button> <cc1:ConfirmButtonExtender id="ConfirmButtonExtender1" runat="server" TargetControlID="btnsubmit" ConfirmText="Are you sure you want to save  this transaction?">
                </cc1:ConfirmButtonExtender>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<BR /><asp:Panel style="POSITION: relative" id="Panel1" runat="server" __designer:wfdid="w11"><asp:Panel style="LEFT: 0px; POSITION: relative; TOP: 0px" id="popReturn" runat="server" Width="400px" Height="180px" __designer:wfdid="w12" BackImageUrl="~/images/modalpopup_04.png"><TABLE style="LEFT: 3px; POSITION: relative; TOP: 2px"><TBODY><TR><TD style="WIDTH: 130px" class="column_RightBold"></TD><TD style="VERTICAL-ALIGN: top; WIDTH: 5px" class="column_LeftBold"></TD><TD style="WIDTH: 210px"></TD><TD style="WIDTH: 40px"><asp:Button style="LEFT: -7px; POSITION: relative; TOP: 3px" id="btnClose" runat="server" Width="30px" ForeColor="White" CssClass="Close" Text="X" __designer:wfdid="w13" BorderStyle="None" BorderColor="#FFC080" BackColor="#FFC080"></asp:Button> </TD></TR><TR><TD style="WIDTH: 130px" class="column_RightBold"></TD><TD style="VERTICAL-ALIGN: top; WIDTH: 5px" class="column_LeftBold"></TD><TD style="WIDTH: 210px">&nbsp;</TD><TD style="WIDTH: 40px"></TD></TR><TR><TD style="WIDTH: 130px" class="column_RightBold">Resolution Number</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 210px"><asp:TextBox style="POSITION: relative" id="txtResolutionNumber" runat="server" Width="200px" Height="20px" CssClass="txtboxinspection" __designer:wfdid="w14"></asp:TextBox> </TD><TD style="WIDTH: 40px" align=left><SPAN style="FONT-SIZE: 14pt; COLOR: #ff0000"></SPAN></TD></TR><TR><TD align=center colSpan=4><asp:Button style="POSITION: relative" id="btnResolutionNo" onclick="btnResolutionNo_Click" runat="server" Width="120px" Height="29px" OnClientClick="StartProgressBar();" Text="OK" __designer:wfdid="w15"></asp:Button> </TD></TR><TR><TD align=center colSpan=4><asp:Label style="POSITION: relative" id="lblrequiredField" runat="server" Width="231px" ForeColor="Red" Font-Size="8pt" Font-Names="Arial" Text="* Resolution Number is Required" Visible="False" __designer:wfdid="w16"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel></asp:Panel> <cc1:ModalPopupExtender id="ModalPopupExtender3" runat="server" TargetControlID="Panel1" __designer:wfdid="w20" DynamicServicePath="" CancelControlID="btnClose" PopupControlID="popReturn" Enabled="True"></cc1:ModalPopupExtender> <BR /><BR /><asp:Panel style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #0033cc; BORDER-BOTTOM-WIDTH: 1px; BORDER-BOTTOM-COLOR: #0033cc; BORDER-TOP-COLOR: #0033cc; POSITION: relative; BACKGROUND-COLOR: transparent; TEXT-ALIGN: center; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #0033cc" id="PanelProgress" runat="server" Width="109px" __designer:wfdid="w38">
                <img src="../images/ajax-loader.gif" /></asp:Panel> <cc1:ModalPopupExtender id="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" __designer:wfdid="w39" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender> <asp:Button style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; POSITION: relative; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none" id="ButtonProgress" runat="server" Width="16px" __designer:wfdid="w40" Enabled="False"></asp:Button> 
</ContentTemplate>
</asp:UpdatePanel>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<BR /></TD></TR><TR><TD colSpan=8>&nbsp; </TD></TR><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"> </TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>    
  
</td>
</tr>
</table>  
    
</asp:Content>
