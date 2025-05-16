<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    StylesheetTheme="SkinFile" CodeFile="t_bid_evaluation_batch.aspx.vb" Inherits="t_bid_evaluation" Title="Bid Evaluation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<table width="1015px" style="text-align:center">
<tr>
<td width="1015px" style="text-align:center">


    <table class="PageTitle">
        <tr>
            <td style="width: 1000px">
                &nbsp;BID EVALUATION</td>
        </tr>
    </table>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager> 

    <table border="0" cellpadding="0" cellspacing="0" style="width:900px">
         <tr>
            <td colspan="8">
<asp:UpdatePanel ID="upCollapse" runat="server">
<contenttemplate>
<%--<cc1:CollapsiblePanelExtender id="cpe1" runat="server" TargetControlID="pnlContent1" CollapseControlID="panelTitle1" ExpandControlID="panelTitle1" ExpandedImage="../images/HighLightProject.png" Collapsed="false" CollapsedImage="../images/BackGroundProject.png" ImageControlID="imgBackground1" CollapsedText="Expand" ExpandedText="Collapse" SuppressPostBack="true"></cc1:CollapsiblePanelExtender> <cc1:CollapsiblePanelExtender id="cpe2" runat="server" TargetControlID="panelContent2" CollapseControlID="panelTitle2" ExpandControlID="panelTitle2" ExpandedImage="../images/HighLightSupplier.png" Collapsed="true" CollapsedImage="../images/BackGroundSupplier.png" ImageControlID="imgBackground2" CollapsedText="Expand" ExpandedText="Collapse" SuppressPostBack="True"></cc1:CollapsiblePanelExtender> 
--%><asp:Panel id="panelTitle1" runat="server" Width="1000px" Height="25px"><IMG id="imgBackground1" height="28px" src="../images/BackGroundProject.png" width="1000px" /></asp:Panel> <asp:Panel id="pnlContent1" runat="server" Width="1000px"><DIV style="BORDER-RIGHT: #cccccc 2px solid; PADDING-RIGHT: 0px; BORDER-TOP: #cccccc 0px solid; PADDING-LEFT: 0px; FONT-WEIGHT: normal; PADDING-BOTTOM: 0px; MARGIN: 0px; BORDER-LEFT: #cccccc 2px solid; WIDTH: 1000px; PADDING-TOP: 0px; BORDER-BOTTOM: #cccccc 2px solid"><asp:GridView style="FONT-WEIGHT: normal; TEXT-ALIGN: justify" id="gvPublic_bidding" runat="server" Width="1000px" DataKeyNames="pre_procurement_hdr_id,abc,CountSupplier,obr_evaluation_hdr_id" AllowPaging="True" AutoGenerateColumns="False" OnSelectedIndexChanged="gvPublic_bidding_SelectedIndexChanged" PageSize="8" SkinID="GridView"><Columns>
<asp:TemplateField HeaderText="Project Reference " ShowHeader="False"><ItemTemplate>
<asp:LinkButton id="LinkButton1" onclick="LinkButton1_Click" runat="server" CausesValidation="False" Text='<%# bind("project_reference_no") %>' CommandName="Select" Font-Underline="False"></asp:LinkButton> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="project_name" HeaderText="Project Name">
<ItemStyle HorizontalAlign="Left" Width="550px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CountSupplier" HeaderText="No. of Supplier">
<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="ABC"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("abc") %>' id="TextBox2"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("abc", "{0:N}") %>' Visible='<%# bind("isVisible") %>'></asp:Label>
</ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="150px"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView></DIV></asp:Panel> <asp:Panel id="panelTitle2" runat="server" Width="1000px" Height="25px"><IMG id="imgBackground2" height=28 src="../images/BackGroundSupplier.png" width="1000px" /></asp:Panel> <asp:Panel style="TEXT-ALIGN: center" id="panelContent2" runat="server" Width="1000px" CssClass="text"><DIV style="BORDER-RIGHT: #cccccc 2px solid; PADDING-RIGHT: 0px; BORDER-TOP: #cccccc 0px solid; PADDING-LEFT: 0px; FONT-WEIGHT: normal; PADDING-BOTTOM: 0px; MARGIN: 0px; BORDER-LEFT: #cccccc 2px solid; WIDTH: 1000px; PADDING-TOP: 0px; BORDER-BOTTOM: #cccccc 2px solid"><TABLE style="WIDTH: 1000px; HEIGHT: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 16px; TEXT-ALIGN: center"><asp:Label id="lbllStatus" runat="server" Font-Bold="True" Text="PRELIMINARY EXAMINATION OF BIDS" Font-Italic="False"></asp:Label> </TD></TR><TR><TD style="TEXT-ALIGN: right"><asp:MultiView id="MultiView1" runat="server"><asp:View id="View1" runat="server"><asp:GridView id="gvsupplier" runat="server" Width="1000px" DataKeyNames="Supplier_Id,indexNo" AutoGenerateColumns="False" OnSelectedIndexChanged="gvsupplier_SelectedIndexChanged" PageSize="8" SkinID="gvnew"><Columns>
<asp:BoundField DataField="SuppName" HeaderText="Supplier Name">
<ItemStyle Width="60%"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Amount"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("amount") %>' id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("amount", "{0:N}") %>' Visible='<%# bind("isVisible") %>'></asp:Label> 
</ItemTemplate>

<ItemStyle Width="20%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Criteria"><EditItemTemplate>
<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:CheckBox id="cb1" runat="server" Text="Pass" Visible='<%# bind("isVisible") %>' AutoPostBack="True" Checked='<%# bind("examination_bid") %>' OnCheckedChanged="cb1_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>

<ItemStyle Width="20%"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView></asp:View> <asp:View id="View2" runat="server"><asp:GridView id="gvCeiling" runat="server" Width="1000px" DataKeyNames="indexNo" AutoGenerateColumns="False" OnSelectedIndexChanged="gvsupplier_SelectedIndexChanged" PageSize="8" SkinID="gvnew"><Columns>
<asp:BoundField DataField="SuppName" HeaderText="Supplier Name">
<ItemStyle Width="60%"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Amount"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("amount") %>' id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("amount", "{0:N}") %>' Visible='<%# bind("isVisible") %>'></asp:Label> 
</ItemTemplate>

<ItemStyle Width="20%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Criteria"><EditItemTemplate>
<asp:CheckBox runat="server" id="CheckBox1"></asp:CheckBox>
</EditItemTemplate>
<ItemTemplate>
<asp:CheckBox id="cb2" runat="server" Text="Pass" Visible='<%# bind("isVisible") %>' AutoPostBack="True" Checked='<%# bind("ceiling_price") %>' OnCheckedChanged="cb2_CheckedChanged" CommandName="Select"></asp:CheckBox> 
</ItemTemplate>

<ItemStyle Width="20%"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView></asp:View> <asp:View id="View3" runat="server"><asp:GridView id="gvPostQualification" runat="server" Width="1000px" DataKeyNames="indexNo" AutoGenerateColumns="False" OnSelectedIndexChanged="gvsupplier_SelectedIndexChanged" PageSize="8" SkinID="gvnew"><Columns>
<asp:BoundField DataField="SuppName" HeaderText="Supplier Name">
<ItemStyle Width="60%"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Amount"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("amount") %>' id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("amount", "{0:N}") %>' Visible='<%# bind("isVisible") %>'></asp:Label> 
</ItemTemplate>

<ItemStyle Width="15%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Lowest Calculated Bid/Highest Rated Bid"><EditItemTemplate>
<asp:CheckBox runat="server" id="CheckBox1"></asp:CheckBox>
</EditItemTemplate>
<HeaderTemplate>
Lowest Calculated Bid/<BR />Highest Rated Bid
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="cb3" runat="server" Text="Pass" Font-Italic="False" Visible='<%# bind("isVisible") %>' AutoPostBack="True" Checked='<%# bind("isPostQualification") %>' OnCheckedChanged="cb3_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>

<ItemStyle Width="25%"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView></asp:View> <asp:View id="View4" runat="server"><asp:GridView style="TEXT-ALIGN: justify" id="gvPost" runat="server" Width="1000px" DataKeyNames="indexNo" AutoGenerateColumns="False" OnSelectedIndexChanged="gvsupplier_SelectedIndexChanged" PageSize="8" SkinID="gvnew"><Columns>
<asp:BoundField DataField="SuppName" HeaderText="Supplier Name">
<ItemStyle Width="40%"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Amount"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("amount") %>' id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("amount", "{0:N}") %>' Visible='<%# bind("isVisible") %>'></asp:Label> 
</ItemTemplate>

<ItemStyle Width="15%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Lowest Calculated Bid/Highest Rated Bid"><EditItemTemplate>
<asp:CheckBox runat="server" id="CheckBox1"></asp:CheckBox>
</EditItemTemplate>
<HeaderTemplate>
Lowest Calculated Bid/<BR />Highest Rated Bid
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="cb4" runat="server" Text="Pass" Font-Italic="False" Visible='<%# bind("isVisible") %>' AutoPostBack="True" Checked='<%# bind("isWinner") %>' OnCheckedChanged="cb4_CheckedChanged" Enabled='<%# bind("enable") %>'></asp:CheckBox> 
</ItemTemplate>

<ItemStyle Width="20%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="orstatus" HeaderText="Status">
<ItemStyle Width="25%"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView></asp:View></asp:MultiView></TD></TR><TR><TD><TABLE style="WIDTH: 100%; HEIGHT: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="HEIGHT: 24px; TEXT-ALIGN: center" colSpan=3><asp:Button id="btnback" onclick="btnback_Click" runat="server" Width="200px" Text="PREVIOUS STEP" OnClientClick="StartProgressBar();"></asp:Button><asp:Button id="btnFail" onclick="btnFail_Click1" runat="server" Width="200px" Text="FAILURE OF BIDDING" OnClientClick="StartProgressBar();"></asp:Button><asp:Button id="btnNext" onclick="btnNext_Click" runat="server" Width="200px" Text="NEXT STEP" OnClientClick="StartProgressBar();"></asp:Button></TD></TR></TBODY></TABLE><cc1:ConfirmButtonExtender id="ConfirmButtonExtender2" runat="server" TargetControlID="btnFail" __designer:wfdid="w4" ConfirmText="About to declare failure of bidding.">
    </cc1:ConfirmButtonExtender></TD></TR></TBODY></TABLE> <TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><%--<TD style="FONT-WEIGHT: normal; COLOR: white; BACKGROUND-COLOR: #507cd1; TEXT-ALIGN: left" class="text"><STRONG>Supplier Name:</STRONG> <asp:DropDownList id="ddSupplier" runat="server" __designer:wfdid="w35" Width="582px" OnSelectedIndexChanged="ddSupplier_SelectedIndexChanged" AppendDataBoundItems="True" Enabled="False" AutoPostBack="True"><asp:ListItem Value="0">Select</asp:ListItem>
</asp:DropDownList><asp:Button id="btnsupplier" onclick="btnsupplier_Click" runat="server" Text="ADD SUPPLIER" __designer:wfdid="w36" Width="150px" Enabled="False"></asp:Button></TD>--%></TR></TBODY></TABLE><BR /></DIV></asp:Panel><BR /><asp:Panel style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #0033cc; BORDER-BOTTOM-WIDTH: 1px; BORDER-BOTTOM-COLOR: #0033cc; BORDER-TOP-COLOR: #0033cc; POSITION: relative; BACKGROUND-COLOR: transparent; TEXT-ALIGN: center; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #0033cc" id="PanelProgress" runat="server" Width="109px" __designer:wfdid="w41">
                <img src="../images/ajax-loader.gif" /></asp:Panel> <cc1:ModalPopupExtender id="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" __designer:wfdid="w42" BehaviorID="ProgressBarModalPopupExtender">
            </cc1:ModalPopupExtender> <asp:Button style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; POSITION: relative; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none" id="ButtonProgress" runat="server" Width="16px" __designer:wfdid="w43" Enabled="False"></asp:Button><BR /><BR /><BR />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
</contenttemplate>

</asp:UpdatePanel><asp:Panel ID="Panel2" runat="server" BackColor="#E0E0E0" BorderColor="Gray" BorderWidth="1px" Height="150px" Style="display: none" Width="200px">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td class="text" style="height: 7px; text-align: center">
            </td>
        </tr>
        <tr>
            <td class="text" style="text-align: center">
                Resolution Declaring</td>
        </tr>
        <tr>
            <td class="text" style="text-align: center">
                Lowest Calculated and</td>
        </tr>
        <tr>
            <td class="text" style="text-align: center">
                Award
                of Contract</td>
        </tr>
        <tr>
            <td style="height: 7px; text-align: center">
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<asp:TextBox style="TEXT-ALIGN: left" id="txtResolutionNumber" runat="server" Width="90%"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ValidationGroup="ok" ControlToValidate="txtResolutionNumber" ErrorMessage="*"></asp:RequiredFieldValidator> 
</contenttemplate>
                </asp:UpdatePanel></td>
        </tr>
        <tr>
            <td style="text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnOK" runat="server" Text="OK" ValidationGroup="ok" Width="80px" OnClientClick="StartProgressBar();" />
                <asp:Button ID="btnCancel" runat="server" Text="CANCEL" Width="80px" /></td>
        </tr>
    </table>
    <asp:Label ID="Label2" runat="server" Width="0px"></asp:Label>
    &nbsp;</asp:Panel>
                <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground" CancelControlID="btnCancel" PopupControlID="Panel2" TargetControlID="Label2">
                </cc1:ModalPopupExtender>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td colspan="8">
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                &nbsp;
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
 
 </td>
</tr>
</table>   
    
</asp:Content>
