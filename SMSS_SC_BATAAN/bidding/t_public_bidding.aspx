
<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    StylesheetTheme="SkinFile" CodeFile="t_public_bidding.aspx.vb" Inherits="t_public_bidding" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 900px">
        <tr>
            <td colspan="8" style="text-align: left">
             <%--   <asp:Label ID="lblHeader" runat="server" Font-Bold="True" Style="text-align: left"
                    Text="PUBLIC BIDDING" SkinID="pageheader"></asp:Label>--%>
                &nbsp;

                    
                <hr />
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
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
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="8">
<asp:UpdatePanel ID="upCollapse" runat="server">
<contenttemplate>
<cc1:CollapsiblePanelExtender id="cpe1" runat="server" TargetControlID="pnlContent1" __designer:wfdid="w26" SuppressPostBack="true" ExpandedText="Collapse" CollapsedText="Expand" ImageControlID="imgBackground1" CollapsedImage="../images/BackGroundPurchaseRequest.png" Collapsed="false" ExpandedImage="../images/HighLightPurchaseRequest.png" ExpandControlID="panelTitle1" CollapseControlID="panelTitle1"></cc1:CollapsiblePanelExtender> <cc1:CollapsiblePanelExtender id="cpe2" runat="server" TargetControlID="panelContent2" __designer:wfdid="w27" SuppressPostBack="True" ExpandedText="Collapse" CollapsedText="Expand" ImageControlID="imgBackground2" CollapsedImage="../images/BackGroundSupplier.png" Collapsed="true" ExpandedImage="../images/HighLightSupplier.png" ExpandControlID="panelTitle2" CollapseControlID="panelTitle2"></cc1:CollapsiblePanelExtender> <cc1:CollapsiblePanelExtender id="cpe3" runat="server" TargetControlID="panelContent3" __designer:wfdid="w28" ExpandedText="Collapse" CollapsedText="Expand" ImageControlID="imgBackground3" CollapsedImage="../images/BackGroundGoods.png" Collapsed="True" ExpandedImage="../images/HighlightGoods.png" ExpandControlID="panelTitle3" CollapseControlID="panelTitle3"></cc1:CollapsiblePanelExtender><asp:Panel id="panelTitle1" runat="server" Width="900px" __designer:wfdid="w29" Height="25px"><IMG id="imgBackground1" height=28 src="../images/BackGroundPurchaseRequest.png" width=900 /></asp:Panel> <asp:Panel id="pnlContent1" runat="server" Width="98%" __designer:wfdid="w30"><DIV style="BORDER-RIGHT: #cccccc 2px solid; PADDING-RIGHT: 0px; BORDER-TOP: #cccccc 0px solid; PADDING-LEFT: 0px; FONT-WEIGHT: normal; PADDING-BOTTOM: 0px; MARGIN: 0px; BORDER-LEFT: #cccccc 2px solid; WIDTH: 98%; PADDING-TOP: 0px; BORDER-BOTTOM: #cccccc 2px solid"><asp:GridView style="FONT-WEIGHT: normal; TEXT-ALIGN: justify" id="gvPublic_bidding" runat="server" SkinID="gvnew" Width="100%" __designer:wfdid="w31" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="bidding_hdr_id" OnSelectedIndexChanged="gvPublic_bidding_SelectedIndexChanged" PageSize="8"><Columns>
<asp:TemplateField HeaderText="Purchase Request Number" ShowHeader="False"><ItemTemplate>
<asp:LinkButton id="LinkButton1" onclick="LinkButton1_Click" runat="server" CausesValidation="False" Text='<%# bind("pr_no") %>' __designer:wfdid="w98" CommandName="Select" Font-Underline="False"></asp:LinkButton> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="rc_name" HeaderText="Department"></asp:BoundField>
<asp:BoundField DataField="project_name" HeaderText="Project Name"></asp:BoundField>
<asp:TemplateField HeaderText="No. of Supplier"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("status") %>' id="TextBox2"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("status") %>' Visible='<%# bind("isVisible") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            
</EditItemTemplate>
<ItemTemplate>
<asp:LinkButton id="lbApprove" onclick="lbApprove_Click1" runat="server" CausesValidation="False" Font-Bold="False" __designer:wfdid="w24" Visible='<%# bind("isVisible") %>' CommandName="Select" Font-Underline="False">Close</asp:LinkButton> <cc1:ConfirmButtonExtender id="ConfirmButtonExtender2" runat="server" __designer:wfdid="w25" TargetControlID="lbApprove" ConfirmText="Are you sure you want to close this transaction?"></cc1:ConfirmButtonExtender>
</ItemTemplate>
</asp:TemplateField>
</Columns>
    <HeaderStyle BackColor="#2977DC" ForeColor="White" />
                        <FooterStyle BackColor="#2977DC" />

</asp:GridView></DIV></asp:Panel> <asp:Panel id="panelTitle2" runat="server" Width="900px" __designer:wfdid="w32" Height="25px"><IMG id="imgBackground2" src="../images/BackGroundSupplier.png" /></asp:Panel> <asp:Panel style="TEXT-ALIGN: center" id="panelContent2" runat="server" Width="98%" __designer:wfdid="w33" CssClass="text"><DIV style="BORDER-RIGHT: #cccccc 2px solid; PADDING-RIGHT: 0px; BORDER-TOP: #cccccc 0px solid; PADDING-LEFT: 0px; FONT-WEIGHT: normal; PADDING-BOTTOM: 0px; MARGIN: 0px; BORDER-LEFT: #cccccc 2px solid; WIDTH: 98%; PADDING-TOP: 0px; BORDER-BOTTOM: #cccccc 2px solid"><asp:GridView id="gvsupplier" runat="server" SkinID="gvnew" Width="100%" __designer:wfdid="w34" PageSize="8" OnSelectedIndexChanged="gvsupplier_SelectedIndexChanged" DataKeyNames="Supplier_Id,isOld" AutoGenerateColumns="False" AllowPaging="True"><Columns>
<asp:TemplateField HeaderText="Supplier Name"><EditItemTemplate>
</EditItemTemplate>
<ItemTemplate>
<asp:LinkButton id="lbSupplier" onclick="lbSupplier_Click" runat="server" CausesValidation="False" Text='<%# Bind("SuppName") %>' __designer:wfdid="w99" CommandName="Select" Font-Underline="False"></asp:LinkButton> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Date Sumitted"><EditItemTemplate>
            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("date") %>'></asp:TextBox>
        
</EditItemTemplate>
<ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Bind("date", "{0:MM/dd/yyyy}") %>' Visible='<%# bind("isVisible") %>'></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>
</Columns>
    <HeaderStyle BackColor="#2977DC" ForeColor="White" />
                        <FooterStyle BackColor="#2977DC" />

</asp:GridView> <TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="FONT-WEIGHT: normal; COLOR: white; BACKGROUND-COLOR: #507cd1; TEXT-ALIGN: left" class="text"><STRONG>Supplier Name:</STRONG> <asp:DropDownList id="ddSupplier" runat="server" Width="582px" __designer:wfdid="w35" OnSelectedIndexChanged="ddSupplier_SelectedIndexChanged" AutoPostBack="True" Enabled="False" AppendDataBoundItems="True"><asp:ListItem Value="0">Select</asp:ListItem>
</asp:DropDownList><asp:Button id="btnsupplier" onclick="btnsupplier_Click" runat="server" Text="ADD SUPPLIER" Width="150px" __designer:wfdid="w36" Enabled="False"></asp:Button></TD></TR></TBODY></TABLE><BR /></DIV></asp:Panel> <asp:Panel id="panelTitle3" runat="server" Width="900px" __designer:wfdid="w37" Height="25px"><IMG id="imgBackground3" src="../images/BackGroundGoods.png" /></asp:Panel> <asp:Panel id="panelContent3" runat="server" Width="98%" __designer:wfdid="w38"><DIV style="BORDER-RIGHT: #cccccc 2px solid; PADDING-RIGHT: 0px; BORDER-TOP: #cccccc 0px solid; PADDING-LEFT: 0px; FONT-WEIGHT: normal; PADDING-BOTTOM: 0px; MARGIN: 0px; BORDER-LEFT: #cccccc 2px solid; WIDTH: 98%; PADDING-TOP: 0px; BORDER-BOTTOM: #cccccc 2px solid"><asp:GridView style="FONT-WEIGHT: normal" id="gvitems" runat="server" SkinID="gvnew" Width="100%" __designer:wfdid="w39" PageSize="5" AutoGenerateColumns="False" CaptionAlign="Left" ShowFooter="True"><Columns>
<asp:BoundField DataField="Item_Desc" HeaderText="Desciption">
<HeaderStyle CssClass="text"></HeaderStyle>

<ItemStyle Width="382px"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Unit"><EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                                
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lblunit" runat="server" Text='<%# Bind("Description") %>' Width="100px" __designer:wfdid="w14" CssClass="text" Visible='<%# bind("isVisible") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle CssClass="text"></HeaderStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Quantity"><EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>
                                
</EditItemTemplate>
<ItemTemplate>
                                    <asp:Label ID="lblqty" runat="server" CssClass="text" Style="text-align: center"
                                        Text='<%# bind("qty") %>' Width="80px" Visible='<%# bind("isVisible") %>'></asp:Label>
                                
</ItemTemplate>

<HeaderStyle CssClass="text"></HeaderStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Price"><EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Cost") %>'></asp:TextBox>
                                
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox style="TEXT-ALIGN: right" id="txtCost" runat="server" Text='<%# bind("Cost","{0:N}") %>' Width="100px" __designer:wfdid="w15" CssClass="text" AutoPostBack="True" Enabled='<%# bind("enable") %>' Visible='<%# bind("isVisible") %>' OnTextChanged="txtCost_TextChanged"></asp:TextBox><cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="txtCost" __designer:wfdid="w16" ValidChars=".0123456789,">
                                        </cc1:FilteredTextBoxExtender> 
</ItemTemplate>

<HeaderStyle CssClass="text"></HeaderStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Total Amount"><EditItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("total") %>'></asp:TextBox>
                                
</EditItemTemplate>
<FooterTemplate>
                                    <asp:Label ID="lbltotal" runat="server" CssClass="text" Style="text-align: right"
                                        Text='<%# Bind("total", "{0:N}") %>' Width="100px"></asp:Label>
                                
</FooterTemplate>
<ItemTemplate>
                                    <asp:Label ID="lbltotal" runat="server" CssClass="text" Style="text-align: right"
                                        Text='<%# Bind("total", "{0:N}") %>' Width="100px" Visible='<%# bind("isVisible") %>'></asp:Label>
                                
</ItemTemplate>

<FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>

<HeaderStyle HorizontalAlign="Right" CssClass="text"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
</Columns>
    <HeaderStyle BackColor="#2977DC" ForeColor="White" />
                        <FooterStyle BackColor="#2977DC" />

<HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
</asp:GridView> <BR /></DIV></asp:Panel>&nbsp; 
</contenttemplate>

</asp:UpdatePanel> &nbsp; &nbsp; &nbsp;
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
        <tr>
            <td colspan="8">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="8">
                <asp:Button ID="btnsubmit" runat="server" Text="SAVE" Width="200px" />
                &nbsp;&nbsp;&nbsp;<cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to save  this transaction?" TargetControlID="btnsubmit">
                </cc1:ConfirmButtonExtender>
            </td>
        </tr>
        <tr>
            <td style="height: 19px;" colspan="8">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 19px">
            </td>
            <td style="width: 100px; height: 19px">
            </td>
            <td style="width: 100px; height: 19px">
            </td>
            <td style="width: 100px; height: 19px">
            </td>
            <td style="width: 100px; height: 19px">
            </td>
            <td style="width: 100px; height: 19px">
            </td>
            <td style="width: 100px; height: 19px">
            </td>
            <td style="width: 100px; height: 19px">
            </td>
        </tr>
    </table>
</asp:Content>
