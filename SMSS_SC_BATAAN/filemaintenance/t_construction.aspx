<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" 
CodeFile="t_construction.aspx.vb" Inherits="t_construction" title="Construction Materials" StylesheetTheme="SkinFile"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="1015" style="text-align:center">
<tr>
<td width="1015" style="text-align:center">
    <table class="PageTitle">
        <tr>
            <td style="width: 1000px">
                &nbsp;CONSTRUCTION MATERIALS</td>
        </tr>
    </table>
    <br />

   
    
    
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   

<asp:UpdatePanel id="UpdatePanelCons" runat="server">   
<contenttemplate>
<TABLE style="WIDTH: 1000px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD colSpan=8><TABLE style="WIDTH: 100%" class="text" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="TEXT-ALIGN: center" colSpan=8><asp:Panel id="Panel1" runat="server" Width="98%" Font-Bold="True" GroupingText="Construction Materials"><TABLE style="FONT-WEIGHT: normal; WIDTH: 100%" class="text" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 120px; HEIGHT: 10px" colSpan=2></TD><TD style="WIDTH: 800px; HEIGHT: 24px" colSpan=3></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 10px"><SPAN style="COLOR: red; TEXT-ALIGN: right"></SPAN></TD><TD style="WIDTH: 25px; HEIGHT: 24px" class="column_LeftBold"> </TD><TD style="WIDTH: 800px; HEIGHT: 24px" colSpan=3><SPAN style="FONT-SIZE: 9pt; COLOR: red"><STRONG>Note:</STRONG> <EM>Use the unit that will be used in Issuance of Supplies. <BR /> &nbsp; &nbsp; &nbsp; &nbsp; Example 1.) Box, The unit that will be used for Issuance is by Box.<BR /> &nbsp; &nbsp; &nbsp; &nbsp; Example 2.) Box(12)Piece, The unit that will be used for Issuance is by Piece.&nbsp;<BR /> &nbsp; &nbsp; &nbsp; &nbsp; In Issuance, if you want to issue one(1) box then issue 12 pieces.<BR /></EM><BR /> </SPAN></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 10px">Calendar Year</TD><TD style="WIDTH: 25px; HEIGHT: 24px" class="column_LeftBold">:</TD><TD style="WIDTH: 800px; HEIGHT: 24px" colSpan=3><asp:DropDownList id="ddyear" runat="server" Width="192px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True">
                                                            <asp:ListItem>Select</asp:ListItem>
                                                        </asp:DropDownList> <asp:HiddenField id="HiddenField1" runat="server"></asp:HiddenField> <asp:HiddenField id="HiddenField2" runat="server"></asp:HiddenField> <asp:HiddenField id="HiddenField3" runat="server"></asp:HiddenField> </TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 10px">Particular</TD><TD style="WIDTH: 25px; HEIGHT: 24px" class="column_LeftBold">:</TD><TD style="WIDTH: 800px; HEIGHT: 24px" colSpan=3><asp:DropDownList style="POSITION: relative" id="ddParticular" runat="server" Width="192px" OnSelectedIndexChanged="ddParticular_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><asp:Button style="POSITION: relative" id="btnAddP" onclick="btnAddP_Click" runat="server" Width="150px" Text="Add Particular" Enabled="False"></asp:Button></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 10px">Item Desciprion</TD><TD style="WIDTH: 25px; HEIGHT: 24px" class="column_LeftBold">:</TD><TD style="WIDTH: 800px; HEIGHT: 24px" colSpan=3><asp:TextBox id="txtItemDesc" runat="server" Width="500px" AutoPostBack="True" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 10px">Unit</TD><TD style="WIDTH: 25px; HEIGHT: 24px" class="column_LeftBold">:<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" InitialValue="0" ValidationGroup="saveS" ErrorMessage="*" ControlToValidate="ddUnit"></asp:RequiredFieldValidator> </TD><TD style="WIDTH: 800px; HEIGHT: 24px" colSpan=3><asp:DropDownList id="ddUnit" runat="server" Width="140px" AutoPostBack="True" AppendDataBoundItems="True"><asp:ListItem Value="0">Select</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 10px">Price</TD><TD style="WIDTH: 25px; HEIGHT: 24px" class="column_LeftBold">:<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" InitialValue="0.00" ValidationGroup="saveS" ErrorMessage="*" ControlToValidate="txtprice"></asp:RequiredFieldValidator> </TD><TD style="WIDTH: 400px; HEIGHT: 24px" align=left colSpan=3>&nbsp; <TABLE style="LEFT: -3px; WIDTH: 800px; TOP: -1px"><TBODY><TR><TD style="WIDTH: 400px"><asp:TextBox style="TEXT-ALIGN: right" id="txtprice" runat="server" Width="125px" AutoPostBack="True" CssClass="txtboxinspection">0.00</asp:TextBox> <cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender2" runat="server" TargetControlID="txtprice" ValidChars="0123456789.,">
                                                        </cc1:FilteredTextBoxExtender> </TD><TD style="WIDTH: 400px" align=right></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 10px"></TD><TD style="WIDTH: 25px; HEIGHT: 24px" class="column_LeftBold"></TD><TD style="WIDTH: 800px; HEIGHT: 24px" colSpan=3><asp:Button id="btnadd" runat="server" Width="100px" Text="ADD"></asp:Button> <asp:Button id="btnedit" runat="server" Width="100px" Text="EDIT"></asp:Button> <asp:Button id="btnsave" onclick="btnsave_Click" runat="server" Width="100px" Text="SAVE"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button id="btncopyall" onclick="btncopyall_Click" runat="server" Width="280px" Text="Copy All previous price under this Account" CssClass="wrap" OnClientClick="StartProgressBar();" Font-Overline="False"></asp:Button></TD></TR></TBODY></TABLE><cc1:ConfirmButtonExtender id="ConfirmButtonExtender1" runat="server" TargetControlID="btnsave" Enabled="True" ConfirmText="Are you sure you want to save this transaction?">
                                            </cc1:ConfirmButtonExtender> </asp:Panel> &nbsp; </TD></TR><TR><TD style="WIDTH: 117px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 139px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 140px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: center" colSpan=8><asp:Panel style="TEXT-ALIGN: left" id="Panel222" runat="server" Width="98%" GroupingText="SEARCH" Height="450px"><TABLE style="WIDTH: 967px"><TBODY><TR><TD style="WIDTH: 500px">Item Description: <asp:TextBox id="txtsearch2" runat="server" Width="312px"></asp:TextBox></TD><TD style="WIDTH: 300px"><asp:Button id="btnsearch" runat="server" Width="100px" Text="SEARCH"></asp:Button></TD><TD><asp:Button id="bntcopyPerGrid" runat="server" Width="160px" Height="25px" Text="Copy Previous Value"></asp:Button></TD></TR><TR><TD colSpan=3 rowSpan=2><asp:GridView style="POSITION: relative" id="gvstock" runat="server" Width="98%" OnSelectedIndexChanged="gvstock_SelectedIndexChanged2" DataKeyNames="particular_desc,detail,unit_desc,price1,Item_ID,item_particular_id,Unit_ID,item_desc,isused,price2,price" SkinID="gvnew" AllowPaging="True" OnPageIndexChanging="gvstock_PageIndexChanging2" PageSize="20" __designer:wfdid="w1" AutoGenerateColumns="False" EmptyDataText="No Records Found"><Columns>
<asp:TemplateField HeaderText="Hide?" ShowHeader="False"><ItemTemplate>
<asp:LinkButton id="LinkButton1" onclick="LinkButton1_Click" runat="server" Width="63px" CausesValidation="False" Text="Select" __designer:wfdid="w2" CommandName="Select"></asp:LinkButton> <asp:CheckBox id="CheckBox1" runat="server" AutoPostBack="True" __designer:wfdid="w3" OnCheckedChanged="CheckBox1_CheckedChanged" Checked='<%# Bind("isUsed") %>'></asp:CheckBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle Width="100px"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="Item_desc" HeaderText="ITEM DESCRIPTION">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="unit_desc" HeaderText="UNIT">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="price1" DataFormatString="{0:N}" HeaderText="PRICE 1" HtmlEncode="False">
<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="price2" DataFormatString="{0:N}" HeaderText="PRICE 2">
<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView></TD></TR><TR></TR></TBODY></TABLE></asp:Panel> &nbsp; &nbsp;&nbsp;&nbsp;<BR /><cc1:ModalPopupExtender id="ModalPopupExtender1" runat="server" TargetControlID="pr_pop_up" PopupControlID="pnl_pr_pop_up" CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
                                        </cc1:ModalPopupExtender> <asp:Panel style="DISPLAY: none; TEXT-ALIGN: center" id="pnl_pr_pop_up" runat="server" Width="500px" BorderWidth="2px" BorderStyle="Solid" BorderColor="#FFA016" BackColor="White"><asp:UpdatePanel id="UpdatePanel1" runat="server"><ContentTemplate>
<TABLE style="WIDTH: 500px; TEXT-ALIGN: left" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="FONT-WEIGHT: bold; COLOR: white; HEIGHT: 21px; BACKGROUND-COLOR: #ffa016; TEXT-ALIGN: center" colSpan=3>Input Remarks<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ValidationGroup="ok" ErrorMessage="*" ControlToValidate="txtremarks"></asp:RequiredFieldValidator></TD></TR><TR><TD colSpan=3><TABLE style="WIDTH: 495px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="HEIGHT: 21px; TEXT-ALIGN: left" colSpan=4><asp:TextBox style="TEXT-ALIGN: left" id="txtremarks" runat="server" Width="98%" Height="114px" TextMode="MultiLine"></asp:TextBox></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel> <TABLE cellSpacing=0 cellPadding=0 width=500 border=0><TBODY><TR><TD><asp:Button id="btnOK" runat="server" Width="80px" Text="OK" ValidationGroup="ok"></asp:Button><asp:Button id="btnCancel" runat="server" Width="80px" Text="CANCEL"></asp:Button></TD></TR></TBODY></TABLE><asp:Label id="pr_pop_up" runat="server"></asp:Label></asp:Panel><BR /><cc1:ModalPopupExtender id="ModalPopupExtender2" runat="server" TargetControlID="particular_pop" PopupControlID="popupParticular" CancelControlID="btnCancel" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender> <BR /><BR /><asp:Panel style="DISPLAY: none; POSITION: relative" id="popupParticular" runat="server" Width="900px"><TABLE id="Table2" height=486 cellSpacing=0 cellPadding=0 width=747 border=0><TBODY><TR><TD colSpan=2><IMG height=1 alt="" src="../images/modalpopup_01.png" width=747 /></TD></TR><TR><TD style="BACKGROUND-IMAGE: url(../images/modalpopup_02.png); WIDTH: 772px; HEIGHT: 39px"></TD><TD style="WIDTH: 46px; HEIGHT: 39px"><asp:ImageButton id="ImageButton2" runat="server" ImageUrl="../images/modalpopup_03.png"></asp:ImageButton></TD></TR><TR><TD style="BACKGROUND-IMAGE: url(../images/modalpopup_04.png); VERTICAL-ALIGN: top; WIDTH: 772px" id="Td1"><TABLE style="WIDTH: 705px; HEIGHT: 336px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 4%; TEXT-ALIGN: center"></TD><TD style="VERTICAL-ALIGN: top; WIDTH: 100%; TEXT-ALIGN: center"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: center" align=center colSpan=3></TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 100%; TEXT-ALIGN: left" align=center><asp:Panel id="Panel2" runat="server" Width="100%" GroupingText="NEW PARTICULAR" CssClass="text"><TABLE style="WIDTH: 100%; TEXT-ALIGN: left" class="TEXT" cellSpacing=0 cellPadding=0 rules=groups border=0><TBODY><TR><TD>PARTICULAR DESCRIPTION:</TD><TD style="TEXT-ALIGN: left"><asp:TextBox id="txtParticularDesc" runat="server" Width="321px" Enabled="False" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD>Useful Life :</TD><TD><asp:TextBox style="POSITION: relative; TEXT-ALIGN: right" id="txtLife" runat="server" Width="150px" AutoPostBack="True" Enabled="False" CssClass="txtboxinspection" __designer:wfdid="w2">0</asp:TextBox></TD></TR><TR><TD></TD><TD><cc1:ConfirmButtonExtender id="ConfirmButtonExtender20" runat="server" TargetControlID="btnsaveparticular" Enabled="True" ConfirmText="Are you sure you want to save this transaction?"></cc1:ConfirmButtonExtender></TD></TR><TR><TD style="HEIGHT: 24px; TEXT-ALIGN: center" colSpan=2><asp:Button id="btnaddparticular" onclick="btnaddparticular_Click" runat="server" Width="80px" Text="ADD"></asp:Button> <asp:Button id="btnsaveparticular" onclick="btnsaveparticular_Click" runat="server" Width="80px" Text="SAVE" Enabled="False"></asp:Button></TD></TR></TBODY></TABLE></asp:Panel></TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1%; TEXT-ALIGN: left"></TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 100%; TEXT-ALIGN: center" align=center><asp:GridView style="POSITION: relative" id="gvparticular" runat="server" Width="100%" SkinID="gvnew" AllowPaging="True" OnPageIndexChanging="gvparticular_PageIndexChanging" PageSize="9"><Columns>
<asp:BoundField DataField="description" HeaderText="Description">
<ItemStyle HorizontalAlign="Left" Width="300px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="useful_life" HeaderText="Useful Life">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView><BR /><BR /><asp:Label style="POSITION: relative" id="particular_pop" runat="server"></asp:Label></TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1%; HEIGHT: 368px; TEXT-ALIGN: left"></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 4%; TEXT-ALIGN: center"></TD><TD style="WIDTH: 100%; TEXT-ALIGN: center"></TD></TR></TBODY></TABLE></TD><TD style="BACKGROUND-IMAGE: url(../images/modalpopup_05.png); WIDTH: 46px; HEIGHT: 446px"></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="WIDTH: 117px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 139px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 140px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 117px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 139px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 140px"></TD><TD style="WIDTH: 100px"></TD></TR></TBODY></TABLE> </TD></TR><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>
</td>
</tr>
</table>

  
</asp:Content>

