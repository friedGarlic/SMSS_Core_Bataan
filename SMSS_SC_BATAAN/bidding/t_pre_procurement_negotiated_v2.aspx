<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false"
CodeFile="t_pre_procurement_negotiated_v2.aspx.vb" Inherits="bidding_t_pre_procurement_negotiated_v2" 
title="Negotiated" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="1015px" style="text-align:center">
<tr>
<td width="1015px" style="text-align:center">


    <table class="PageTitle">
        <tr>
            <td style="width: 1000px">
                &nbsp;PRE PROCUREMENT NEGOTIATED</td>
        </tr>
    </table>




<script language="javascript" type="text/javascript">
<!--

function TABLE1_onclick() {

}

// -->
</script>

                <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager>

    <table border="0" cellpadding="0" cellspacing="0" style="width: 1000px">
     <%--   <tr>
            <td colspan="8" style="text-align: left; height: 19px;">
             <asp:Label ID="Label3" runat="server" SkinID="pageheader" Style="font-weight: bold; font-size: 14pt" ForeColor="DimGray" Height="14px">Canvass</asp:Label>
             &nbsp;</td>
        </tr>--%>
        <tr>
            <td colspan="8">
                <asp:UpdatePanel id="upEmployeeDetail" runat="server">
                    <contenttemplate>
<%--<cc1:CollapsiblePanelExtender id="cpeEmployeeList" runat="server" SuppressPostBack="true" ExpandedText="Collapse" CollapsedText="Expand" ImageControlID="imgBackgroundEmployeeList" CollapsedImage="../images/BackGroundPurchaseRequest.png" Collapsed="false" ExpandedImage="../images/HighLightPurchaseRequest.png" ExpandControlID="panelTitleEmployeeList" CollapseControlID="panelTitleEmployeeList" TargetControlID="panelTitleEmployeeDetail"></cc1:CollapsiblePanelExtender> <cc1:CollapsiblePanelExtender id="cpeEmployeeDetail" runat="server" SuppressPostBack="True" ExpandedText="Collapse" CollapsedText="Expand" ImageControlID="imgBackgroundEmployeeDetail" CollapsedImage="../images/BackGroundSupplier.png" Collapsed="true" ExpandedImage="../images/HighLightSupplier.png" ExpandControlID="panelTitleEmployeeDetail" CollapseControlID="panelTitleEmployeeDetail" TargetControlID="panelContentEmployeeDetail"></cc1:CollapsiblePanelExtender> 
--%><asp:Label id="Label4" runat="server" Width="436px"></asp:Label> <TABLE class="text" width="100%"><TBODY><TR><TD style="WIDTH: 224px" align=right>PR Number:</TD><TD><asp:TextBox id="txtcanvassearch" runat="server" Width="263px" MaxLength="4"></asp:TextBox><asp:Button id="btnsearch" onclick="btnsearch_Click" runat="server" Width="100px" Text="SEARCH"></asp:Button><asp:Button id="btnviewAll" onclick="btnviewAll_Click" runat="server" Width="96px" Text="View All"></asp:Button></TD></TR></TBODY></TABLE><asp:Panel id="panelContentEmployeeList" runat="server" Width="1000px"><DIV style="BORDER-RIGHT: #cccccc 2px solid; PADDING-RIGHT: 0px; BORDER-TOP: #cccccc 0px solid; PADDING-LEFT: 0px; FONT-WEIGHT: normal; PADDING-BOTTOM: 0px; MARGIN: 0px; BORDER-LEFT: #cccccc 2px solid; WIDTH: 98%; PADDING-TOP: 0px; BORDER-BOTTOM: #cccccc 2px solid; TEXT-ALIGN: center"><asp:GridView style="FONT-WEIGHT: normal; TEXT-ALIGN: justify" id="gvIncomingPR" runat="server" Width="101%" OnPageIndexChanging="gvIncomingPR_PageIndexChanging" AllowPaging="True" OnSelectedIndexChanged="gvIncomingPR_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="prhdr_id,pr_no,ABC,withWinner,isReimbursement,obr_evaluation_hdr_id,obr_evaluation_dtl_id,Transaction_type,isPublicInfra,isStraight,remarks" PageSize="8" SkinID="GridView" OnRowDataBound="gvIncomingPR_RowDataBound"><Columns>
<asp:BoundField DataField="pr_no" HeaderText="PR Number">
<ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="remarks" HeaderText="Particulars">
<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="Amount">
<ItemStyle Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="OBR_No" HeaderText="OBR Number">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Office_Name" HeaderText="Department">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="17%"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Date Approved"><EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Date_Submitted") %>'></asp:TextBox>
                                
</EditItemTemplate>
<ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("pr_date", "{0:MM/dd/yyyy}") %>'
                                        Visible='<%# bind("isVisible") %>'></asp:Label>
                                
</ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView></DIV></asp:Panel> <TABLE class="strip" width=1000><TBODY><TR><TD style="COLOR: white; HEIGHT: 18px; BACKGROUND-COLOR: #2977dc; TEXT-ALIGN: left" align=right colSpan=3><STRONG><SPAN style="FONT-SIZE: 11pt; WIDTH: 1000px">Supplier</SPAN></STRONG></TD></TR></TBODY></TABLE><TABLE class="text" width="100%"><TBODY><TR><TD style="WIDTH: 100%" align=center><asp:Panel id="Panel1" runat="server" Width="98%"><asp:GridView id="gvsupplier" runat="server" Width="1000px" SkinID="GridViewGL" PageSize="8" DataKeyNames="Supplier_Id,isOld,canvass_hdr_id" AutoGenerateColumns="False" OnSelectedIndexChanged="gvsupplier_SelectedIndexChanged"><Columns>
<asp:TemplateField HeaderText="Supplier Name"><EditItemTemplate>
</EditItemTemplate>
<ItemTemplate>
<asp:LinkButton id="lbSupplier" onclick="lbSupplier_Click" runat="server" CausesValidation="False" Text='<%# Bind("SuppName") %>' Font-Underline="False" CommandName="Select"></asp:LinkButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="500px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("amount") %>' OnTextChanged="TextBox1_TextChanged"></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox style="TEXT-ALIGN: right" id="txtcost" runat="server" Width="120px" Text='<%# Bind("amount", "{0:N}") %>' AutoPostBack="True" OnTextChanged="txtcost_TextChanged1" Visible='<%# bind("isVisible") %>' ReadOnly="True"></asp:TextBox> <cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender3" runat="server" TargetControlID="txtcost" ValidChars="0123456789.,">
    </cc1:FilteredTextBoxExtender> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="250px"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="status" HeaderText="Status">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="250px"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView> <TABLE style="WIDTH: 1000px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="FONT-WEIGHT: normal; COLOR: white; HEIGHT: 24px; BACKGROUND-COLOR: #2977dc; TEXT-ALIGN: left; widht: 1000px" class="text"><STRONG style="BACKGROUND-COLOR: #2977dc">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Supplier Name:</STRONG> <asp:DropDownList id="ddSupplier" runat="server" Width="582px" Enabled="False" OnSelectedIndexChanged="ddSupplier_SelectedIndexChanged"></asp:DropDownList><asp:Button id="btnsupplier" onclick="btnsupplier_Click" runat="server" Width="150px" Text="SELECT SUPPLIER" Enabled="False"></asp:Button></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR></TBODY></TABLE><TABLE class="text" width="100%"><TBODY><TR><TD style="COLOR: white; HEIGHT: 18px; BACKGROUND-COLOR: #2977dc; TEXT-ALIGN: left" align=right colSpan=3><STRONG><SPAN style="FONT-SIZE: 11pt; WIDTH: 1000px">Goods</SPAN></STRONG></TD></TR></TBODY></TABLE><TABLE class="text" width="100%"><TBODY><TR><TD align=center><asp:Panel id="Panel2" runat="server" Width="98%"><asp:GridView style="FONT-WEIGHT: normal" id="gvbody" runat="server" Width="1000px" SkinID="GridViewGL" PageSize="50" DataKeyNames="Item_ID" OnSelectedIndexChanged="gvbody_SelectedIndexChanged" ShowFooter="True"><Columns>
<asp:TemplateField><EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<HeaderTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" class="text" style="width: 100%">
                                                <tr>
                                                    <td style="width: 100px; text-align: center">
                                                        Description</td>
                                                </tr>
                                            </table>
                                        
</HeaderTemplate>
<ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbldesc" runat="server" Width="357px" Text='<%# Bind("Item_Desc") %>' CssClass="text"></asp:Label> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="500px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox> 
</EditItemTemplate>
<HeaderTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" class="text" style="width: 100%">
                                                <tr>
                                                    <td style="width: 100px; text-align: center">
                                                        Unit</td>
                                                </tr>
                                            </table>
                                        
</HeaderTemplate>
<ItemTemplate>
<asp:Label id="lblunit" runat="server" Width="100px" Text='<%# Bind("Description") %>' CssClass="text"></asp:Label> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="125px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Quantity"><EditItemTemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("qty") %>'></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox style="TEXT-ALIGN: right" id="txtqty" runat="server" Width="80px" Text='<%# Bind("qty") %>' Enabled='<%# bind("isEnable") %>' AutoPostBack="True" OnTextChanged="txtqty_TextChanged"></asp:TextBox> <cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender2" runat="server" TargetControlID="txtqty" ValidChars="0123456789">
            </cc1:FilteredTextBoxExtender> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="125px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField><EditItemTemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("Cost") %>'></asp:TextBox> 
</EditItemTemplate>
<HeaderTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" class="text" style="width: 100%">
                                                <tr>
                                                    <td style="width: 100px; text-align: center">
                                                        Price</td>
                                                </tr>
                                            </table>
                                        
</HeaderTemplate>
<ItemTemplate>
<asp:TextBox style="TEXT-ALIGN: right" id="txtCost" runat="server" Width="100px" Text='<%# bind("cost", "{0:N}") %>' Enabled='<%# bind("isEnable") %>' AutoPostBack="True" OnTextChanged="txtCost_TextChanged"></asp:TextBox><cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="txtCost" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="125px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField><EditItemTemplate>
<asp:TextBox id="TextBox6" runat="server" Text='<%# Bind("total") %>'></asp:TextBox> 
</EditItemTemplate>
<FooterTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbltotal" runat="server" Width="100px" Text='<%# Bind("total", "{0:N}") %>' CssClass="text"></asp:Label> 
</FooterTemplate>
<HeaderTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" class="text" style="width: 100%">
                                                <tr>
                                                    <td style="width: 100px; text-align: center">
                                                        Total Amount</td>
                                                </tr>
                                            </table>
                                        
</HeaderTemplate>
<ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbltotal" runat="server" Width="100px" Text='<%# Bind("total", "{0:N}") %>' CssClass="text"></asp:Label> 
</ItemTemplate>

<FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="125px"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" Font-Names="Arial" Font-Size="8pt" ForeColor="White"></HeaderStyle>
</asp:GridView></asp:Panel></TD></TR></TBODY></TABLE>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button id="btnsave" onclick="btnsave_Click" runat="server" Width="200px" Text="SAVE" OnClientClick="StartProgressBar();" ValidationGroup="save"></asp:Button> <asp:Button id="btnDeclareWinner" onclick="btnDeclareWinner_Click" runat="server" Width="200px" Text="DECLARE  WINNER" OnClientClick="StartProgressBar();" __designer:wfdid="w42" Enabled="False"></asp:Button> <asp:Button id="btnPreview" onclick="Button1_Click" runat="server" Width="200px" Text="PREVIEW" __designer:wfdid="w43" Enabled="False"></asp:Button> <cc1:ConfirmButtonExtender id="ConfirmButtonExtender1" runat="server" TargetControlID="btnsave" ConfirmText="Are you sure you want to save  this transaction?">
                </cc1:ConfirmButtonExtender>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <BR /><BR /><BR /><asp:Panel style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #0033cc; BORDER-BOTTOM-WIDTH: 1px; BORDER-BOTTOM-COLOR: #0033cc; BORDER-TOP-COLOR: #0033cc; POSITION: relative; BACKGROUND-COLOR: transparent; TEXT-ALIGN: center; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #0033cc" id="PanelProgress" runat="server" Width="109px" __designer:wfdid="w32">
                <img src="../images/ajax-loader.gif" /></asp:Panel> <cc1:ModalPopupExtender id="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" __designer:wfdid="w33" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender> <asp:Button style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; POSITION: relative; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none" id="ButtonProgress" runat="server" Width="16px" __designer:wfdid="w34" Enabled="False"></asp:Button> 
</contenttemplate>
                </asp:UpdatePanel><br />
                <asp:Panel ID="pnl_pr_pop_up" runat="server" BackColor="White" BorderColor="#FFA016"
                    BorderStyle="Solid" BorderWidth="2px" Style="display: none; text-align: center" Width="250px">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 250px; text-align: left">
                        <tr>
                            <td colspan="4" style="font-weight: bold; color: white; height: 21px; background-color: #ffa016;
                                text-align: center">
                                Project Reference
                                Number :</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" style="height: 50px">
                                <asp:TextBox ID="txtProjectRefNo" runat="server" CssClass="txtboxinspection" Style="text-align: left; " Width="160px"></asp:TextBox>
                                <asp:Label ID="lbl1" runat="server" Font-Italic="True" Font-Size="Smaller" ForeColor="Red"
                                     Visible="False">*</asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="font-weight: bold; color: white; height: 21px; background-color: #ffa016;
                                text-align: center">
                                Resolution Declaring Award of Contract:</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" style="height: 50px">
                                <asp:TextBox ID="txtResolutionNo" runat="server" CssClass="txtboxinspection" Style="
                                    text-align: left;" Width="160px"></asp:TextBox>
                                <asp:Label ID="lbl2" runat="server" Font-Italic="True" Font-Size="Smaller" ForeColor="Red"
                                     Visible="False">*</asp:Label></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Label ID="lblreq" runat="server" Font-Italic="True" Font-Size="Smaller" ForeColor="Red"
                                    ></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <br />
                                            <asp:Button ID="btnOK" runat="server" Text="OK" ValidationGroup="ok" Width="80px" /><asp:Button
                                                ID="btnCancel" runat="server" Text="CANCEL" Width="80px"  /></td>
                        </tr>
                    </table>
                    &nbsp;&nbsp;
                    <asp:Label ID="pr_pop_up" runat="server"></asp:Label></asp:Panel>
                <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
                    CancelControlID="btnCancel" PopupControlID="pnl_pr_pop_up" TargetControlID="pr_pop_up">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
    </table>
    
    </td>
    </tr>
    </table>

</asp:Content>

