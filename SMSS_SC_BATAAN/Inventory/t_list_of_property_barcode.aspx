<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="false"
    AutoEventWireup="false" CodeFile="t_list_of_property_barcode.aspx.vb" Inherits="t_list_of_property_barcode"
    StylesheetTheme="SkinFile" Title="list_of_property_barcode" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<table width="1015" style="text-align:center">
<tr>
<td width="1015" style="text-align:center">



    <script language="javascript" type="text/javascript">
function Table2_onclick() {
}
function fun1(e, button1){
          var evt = e ? e : window.event;
          var bt = document.getElementById(button1);
          if (bt){
              if (evt.keyCode == 13){
                    bt.click();
                    return false;
              }
          }
    }
function Table6_onclick() {
}
function DIV1_onclick() {
}


function HandleBrowseClick()
{
    var fileinput = document.getElementById("File1");
    fileinput.click();
}
function Handlechange()
{
    var fileinput = document.getElementById("File1");
    var hiddenControl = '<%= hdfinspection.ClientID %>';
    document.getElementById(hiddenControl).value= fileinput.value ;
    }




    </script>

    <table class="PageTitle">
        <tr>
            <td style="width: 1000px">
                &nbsp;ISSUANCE</td>
        </tr>
    </table>
    <br />


    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" Visible="true">
        <contenttemplate>
<table style="MARGIN-LEFT: auto; WIDTH: 999px; MARGIN-RIGHT: auto"><TBODY><TR><TD align=center colSpan=3><cc1:TabContainer style="TEXT-ALIGN: left" id="TabContainer1" runat="server" Width="992px" ActiveTabIndex="0"><cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>
Supply Requisition and Issuance 
</HeaderTemplate>
<ContentTemplate>
<DIV style="WIDTH: 980px; HEIGHT: 100%"><DIV style="WIDTH: 976px; HEIGHT: 100%"><TABLE style="WIDTH: 974px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="TEXT-ALIGN: left" colSpan=8><DIV class="DivTitle">SUPPLY&nbsp;REQUISITION AND ISSUANCE</DIV>
<HR style="WIDTH: 950px" />
<cc1:ConfirmButtonExtender id="ConfirmButtonExtender1" runat="server" TargetControlID="btnsave" Enabled="True" ConfirmText="Are you sure you want to save this transaction?" __designer:wfdid="w40"></cc1:ConfirmButtonExtender> <DIV style="TEXT-ALIGN: left"><TABLE style="WIDTH: 950px; POSITION: relative"><TBODY><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 850px" align=right><asp:Button style="POSITION: relative" id="btnnew" runat="server" CausesValidation="False" Visible="False" Text="NEW" SkinID="ButtonImage" __designer:wfdid="w41"></asp:Button> <asp:Button style="POSITION: relative" id="btnopen" runat="server" CausesValidation="False" Visible="False" Text="OPEN" SkinID="ButtonImage" __designer:wfdid="w42"></asp:Button> </TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=2><SPAN style="FONT-SIZE: 11pt; FONT-FAMILY: Arial"><STRONG>Supply : </STRONG></SPAN><asp:DropDownList style="POSITION: relative" id="ddSupplies" runat="server" Width="200px" OnSelectedIndexChanged="ddSupplies_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w43"></asp:DropDownList> </TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=2><asp:GridView style="POSITION: relative" id="gvSupplyList" runat="server" Width="600px" OnSelectedIndexChanged="gvSupplyList_SelectedIndexChanged" SkinID="GridViewGL" DataKeyNames="RC_ID,GA_ID" AllowPaging="True" PageSize="8" CssClass="text" OnRowDataBound="gvSupplyList_RowDataBound" __designer:wfdid="w44"><Columns>
<asp:BoundField DataField="Item_Desc" HeaderText="Description">
<HeaderStyle CssClass="text"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Unit" HeaderText="Unit">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Balance" HeaderText="Available Qty">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Department" HeaderText="Department">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RC_ID" HeaderText="RC_ID"></asp:BoundField>
</Columns>
</asp:GridView> </TD></TR><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 850px"><asp:Panel style="LEFT: 0px; POSITION: relative; TOP: 0px" id="Panel3" runat="server" Width="800px" Font-Bold="True" Font-Names="Verdana" CssClass="text" GroupingText="INFORMATION" __designer:wfdid="w45"><TABLE style="LEFT: 0px; WIDTH: 800px; POSITION: relative; TOP: 0px" class="column_LeftBold"><TBODY><TR><TD style="WIDTH: 200px" class="text12"></TD><TD style="WIDTH: 10px" class="column_LeftBold"></TD><TD style="WIDTH: 300px" class="column_LeftBold"></TD><TD style="WIDTH: 480px" class="column_LeftBold"></TD></TR><TR><TD style="WIDTH: 200px" class="text12"></TD><TD style="WIDTH: 10px" class="column_LeftBold"></TD><TD style="WIDTH: 300px" class="column_LeftBold"></TD><TD style="WIDTH: 480px" class="column_LeftBold"></TD></TR><TR><TD style="WIDTH: 200px" class="text12">RIS Number</TD><TD style="WIDTH: 10px" class="column_LeftBold">:</TD><TD style="WIDTH: 300px" class="column_LeftBold"><asp:TextBox style="POSITION: relative" id="txtRIS" runat="server" Width="200px" SkinID="text" CssClass="text" ReadOnly="True" __designer:wfdid="w46"></asp:TextBox> </TD><TD style="WIDTH: 480px" class="column_LeftBold">Date&nbsp; : &nbsp;<asp:TextBox style="POSITION: relative" id="txtdate" runat="server" Width="200px" SkinID="text" CssClass="text" ReadOnly="True" __designer:wfdid="w47"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 200px" class="text12">Department</TD><TD style="WIDTH: 10px" class="column_LeftBold">:</TD><TD class="column_LeftBold" colSpan=2><asp:DropDownList style="POSITION: relative" id="drpdept" runat="server" Width="400px" AutoPostBack="True" AppendDataBoundItems="True" __designer:wfdid="w48"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 200px" class="text12">Function</TD><TD style="WIDTH: 10px" class="column_LeftBold">:</TD><TD class="column_LeftBold" colSpan=2><asp:DropDownList style="POSITION: relative" id="drpFunction" runat="server" Width="400px" AutoPostBack="True" AppendDataBoundItems="True" __designer:wfdid="w49"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 200px" class="text12">Acknowledge To</TD><TD style="WIDTH: 10px" class="column_LeftBold">:</TD><TD class="column_LeftBold" colSpan=2><asp:DropDownList style="POSITION: relative" id="ddmr" runat="server" Width="400px" AutoPostBack="True" CssClass="text" AppendDataBoundItems="True" __designer:wfdid="w50"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 200px" class="text12">Property Officer</TD><TD style="WIDTH: 10px" class="column_LeftBold">:</TD><TD class="column_LeftBold" colSpan=2><asp:TextBox style="POSITION: relative" id="txtfrom" runat="server" Width="250px" CssClass="text" ReadOnly="True" __designer:wfdid="w51"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 200px" class="text12">Remarks</TD><TD style="WIDTH: 10px" class="column_LeftBold">:</TD><TD class="column_LeftBold" colSpan=2 rowSpan=2><asp:TextBox style="POSITION: relative" id="txtremarks" runat="server" Width="400px" SkinID="text" CssClass="text" Height="50px" TextMode="MultiLine" __designer:wfdid="w52"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 200px" class="text12"></TD><TD style="WIDTH: 10px" class="column_LeftBold"></TD></TR><TR><TD style="TEXT-ALIGN: center" class="text12" colSpan=4></TD></TR><TR><TD style="TEXT-ALIGN: center" class="column_LeftBold" colSpan=4 rowSpan=1><asp:Button style="POSITION: relative" id="btnADD" onclick="btnADD_Click" runat="server" Width="150px" Text="ADD ITEM" SkinID="ButtonImage" Height="35px" __designer:wfdid="w53"></asp:Button> </TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 850px"></TD></TR><TR><TD align=center colSpan=2><asp:Panel style="POSITION: relative" id="Panel1" runat="server" Width="900px" Font-Bold="True" CssClass="text" GroupingText="SUPPLIES" __designer:wfdid="w54"><asp:GridView style="FONT-WEIGHT: normal" id="gvbody" runat="server" Width="98%" SkinID="gvnew" AutoGenerateColumns="False" __designer:wfdid="w55" ShowFooter="True"><Columns>
<asp:BoundField DataField="item_desc" HeaderText="Description"></asp:BoundField>
<asp:BoundField DataField="Description" HeaderText="Unit">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Quantity"><EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("qty2") %>'></asp:TextBox>
                                
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox style="TEXT-ALIGN: right" id="txtqty" runat="server" Width="60px" AutoPostBack="True" Text='<%# Bind("qty2") %>' CssClass="text" OnTextChanged="txtqty_TextChanged1"></asp:TextBox> <cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="txtqty" ValidChars="0123456789">
                                    </cc1:FilteredTextBoxExtender> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="qty" HeaderText="Available Qty">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Cost" DataFormatString="{0:N}" HeaderText="Cost" HtmlEncode="False">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="total" DataFormatString="{0:N}" HeaderText="Total" HtmlEncode="False">
<FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView> </asp:Panel> </TD></TR><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 850px"></TD></TR><TR><TD style="VERTICAL-ALIGN: middle; TEXT-ALIGN: center" align=center colSpan=2><asp:Button style="POSITION: relative" id="btnsave" runat="server" Width="200px" Text="SAVE" SkinID="ButtonImage" Height="35px" ValidationGroup="1" __designer:wfdid="w56"></asp:Button> <asp:Button style="POSITION: relative; TOP: 0px" id="btnpreview" runat="server" Width="200px" CausesValidation="False" Text="PREVIEW" SkinID="ButtonImage" Height="35px" Enabled="False" __designer:wfdid="w57"></asp:Button> </TD></TR></TBODY></TABLE></DIV></TD></TR></TBODY></TABLE><BR /><asp:Panel style="DISPLAY: none" id="popup" runat="server" Width="900px" __designer:wfdid="w58"><TABLE id="Table2" height=486 cellSpacing=0 cellPadding=0 width=747 border=0><TBODY><TR><TD colSpan=2><IMG height=1 alt="" src="../images/modalpopup_01.png" width=747 /></TD></TR><TR><TD style="BACKGROUND-IMAGE: url(../images/modalpopup_02.png); WIDTH: 772px; HEIGHT: 39px"></TD><TD style="WIDTH: 46px; HEIGHT: 39px"><asp:ImageButton id="ImageButton3" runat="server" ImageUrl="../images/modalpopup_03.png" __designer:wfdid="w59"></asp:ImageButton> </TD></TR><TR><TD style="BACKGROUND-IMAGE: url(../images/modalpopup_04.png); VERTICAL-ALIGN: top; WIDTH: 772px; HEIGHT: 446px" id="Td1"><TABLE style="WIDTH: 705px; HEIGHT: 336px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 4%; HEIGHT: 380px; TEXT-ALIGN: center"></TD><TD style="VERTICAL-ALIGN: top; WIDTH: 100%; HEIGHT: 380px; TEXT-ALIGN: center"><asp:UpdatePanel id="UpdatePanel2" runat="server" __designer:wfdid="w60"><ContentTemplate>
<TABLE style="WIDTH: 100%" class="text" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%" colSpan=3> Search: <asp:TextBox id="txtsearchitems" runat="server" Width="410px" CssClass="text" OnTextChanged="txtsearchitems_TextChanged" __designer:wfdid="w61"></asp:TextBox><asp:Button id="btnSearch" onclick="btnSearch_Click1" runat="server" Width="100px" Text="SEARCH" __designer:wfdid="w62"></asp:Button></TD></TR></TBODY></TABLE><asp:GridView style="POSITION: relative" id="gvitems" runat="server" Width="100%" OnSelectedIndexChanged="gvitems_SelectedIndexChanged3" SkinID="gvnew" DataKeyNames="Item_ID,Item_Desc,Description,Balance,total" AllowPaging="True" PageSize="8" __designer:wfdid="w63"><Columns>
<asp:TemplateField><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<HeaderTemplate>
<asp:CheckBox id="CheckBox2" runat="server" Width="50px" Font-Bold="True" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" Text="All" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="CheckBox1" runat="server" Width="50px" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="Item_Desc" HeaderText="Description">
<HeaderStyle CssClass="text"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Description" HeaderText="Unit">
<HeaderStyle HorizontalAlign="Left" CssClass="text"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Item_ID"></asp:BoundField>
<asp:BoundField DataField="id" HeaderText="id"></asp:BoundField>
<asp:BoundField DataField="cost" DataFormatString="{0:N}" HeaderText="Cost"></asp:BoundField>
<asp:BoundField DataField="Balance" HeaderText="Balance"></asp:BoundField>
<asp:BoundField DataField="StockID" HeaderText="StockID"></asp:BoundField>
</Columns>
</asp:GridView> 
</ContentTemplate>
</asp:UpdatePanel> </TD></TR><TR><TD style="WIDTH: 4%; HEIGHT: 23px; TEXT-ALIGN: center"></TD><TD style="WIDTH: 100%; HEIGHT: 23px; TEXT-ALIGN: center"><asp:Button style="POSITION: relative" id="btnload" runat="server" Width="150px" Font-Bold="False" Text="LOAD" SkinID="Button" __designer:wfdid="w64" Font-Underline="False"></asp:Button> &nbsp;</TD></TR></TBODY></TABLE></TD><TD style="BACKGROUND-IMAGE: url(../images/modalpopup_05.png); WIDTH: 46px; HEIGHT: 446px"></TD></TR></TBODY></TABLE></asp:Panel> <BR /><cc1:ModalPopupExtender id="ModalPopupExtender1" runat="server" TargetControlID="btnADD" Enabled="True" DynamicServicePath="" CancelControlID="ImageButton3" PopupControlID="popup" BackgroundCssClass="modalBackground" __designer:wfdid="w65"></cc1:ModalPopupExtender> <BR /><asp:Panel style="DISPLAY: none" id="popup2" runat="server" Width="900px" __designer:wfdid="w66"><TABLE id="Table3" height=401 cellSpacing=0 cellPadding=0 width=840 border=0><TBODY><TR><TD colSpan=4><IMG height=5 alt="" src="../images/popupmenu/sms-popup_01.gif" width=840 /></TD></TR><TR><TD style="BACKGROUND-IMAGE: url(../images/popupmenu/sms-popup_02.gif); VERTICAL-ALIGN: bottom; WIDTH: 753px; HEIGHT: 35px" colSpan=2></TD><TD style="WIDTH: 70px; HEIGHT: 35px"><asp:ImageButton id="ImageButton2" runat="server" ImageUrl="../images/popupmenu/sms-popup_03.gif" __designer:wfdid="w67"></asp:ImageButton> </TD><TD style="WIDTH: 18px" rowSpan=3><IMG height=395 alt="" src="../images/popupmenu/sms-popup_04.gif" width=17 /></TD></TR><TR><TD rowSpan=2><IMG height=360 alt="" src="../images/popupmenu/sms-popup_05.gif" width=10 /></TD><TD style="BACKGROUND-IMAGE: url(../images/popupmenu/sms-popup_06.gif); VERTICAL-ALIGN: top; WIDTH: 813px; HEIGHT: 336px; TEXT-ALIGN: left" colSpan=2><TABLE style="WIDTH: 813px; HEIGHT: 336px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 100%; TEXT-ALIGN: left"><asp:UpdatePanel id="UpdatePanel1" runat="server" __designer:wfdid="w68"><ContentTemplate>
<TABLE cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD colSpan=4><TABLE style="WIDTH: 100%" class="text" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%">SEARCH BY:<asp:DropDownList id="ddopen" runat="server" Width="200px" OnSelectedIndexChanged="DropDownList11_SelectedIndexChanged" __designer:wfdid="w69"><asp:ListItem Value="RIS_NO">RIS Number</asp:ListItem>
<asp:ListItem Value="RISDATE">Date</asp:ListItem>
<asp:ListItem Value="fullname">Name</asp:ListItem>
</asp:DropDownList><asp:TextBox id="txtsearch2" runat="server" Width="300px" CssClass="text" OnTextChanged="txtsearch2_TextChanged" __designer:wfdid="w70"></asp:TextBox><asp:Button id="btnsearch2" onclick="btnsearch2_Click" runat="server" Width="100px" Text="SEARCH" __designer:wfdid="w71"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><asp:GridView id="gvopen" runat="server" Width="100%" OnSelectedIndexChanged="gvopen_SelectedIndexChanged" SkinID="gvnew" DataKeyNames="RIS_NO,RISDATE,fullname,RC_NAME,RC_ID,Issued_By,Purpose" AllowPaging="True" PageSize="8" AutoGenerateColumns="False" __designer:wfdid="w72" CaptionAlign="Left">
<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>
<Columns>
<asp:TemplateField><ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                Font-Underline="True" ForeColor="Black" Text="Select" Width="50px"></asp:LinkButton>
                        
</ItemTemplate>

<ItemStyle HorizontalAlign="Left" Width="40px"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="RIS_NO" HeaderText="RIS Number">
<HeaderStyle HorizontalAlign="Center" CssClass="text"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="fullname" HeaderText="Name">
<HeaderStyle HorizontalAlign="Center" CssClass="text"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="RISDATE" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date" HtmlEncode="False">
<HeaderStyle HorizontalAlign="Center" CssClass="text"></HeaderStyle>
</asp:BoundField>
</Columns>

<HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
</asp:GridView> 
</ContentTemplate>
</asp:UpdatePanel> </TD></TR><TR><TD style="WIDTH: 100%; TEXT-ALIGN: center"><asp:Button id="btnload2" runat="server" Width="150px" Font-Bold="False" Text="LOAD" SkinID="Button" __designer:wfdid="w73"></asp:Button> </TD></TR></TBODY></TABLE></TD></TR><TR><TD colSpan=2><IMG height=24 alt="" src="../images/popupmenu/sms-popup_07.gif" width=813 /></TD></TR><TR><TD><IMG height=1 alt="" src="../images/popupmenu/spacer.gif" width=10 /></TD><TD><IMG height=1 alt="" src="../images/popupmenu/spacer.gif" width=743 /></TD><TD><IMG height=1 alt="" src="../images/popupmenu/spacer.gif" width=70 /></TD><TD style="WIDTH: 18px"><IMG height=1 alt="" src="../images/popupmenu/spacer.gif" width=17 /></TD></TR></TBODY></TABLE></asp:Panel> <BR /><BR /><cc1:ModalPopupExtender id="ModalPopupExtender2" runat="server" TargetControlID="btnopen" Enabled="True" DynamicServicePath="" CancelControlID="ImageButton2" PopupControlID="popup2" BackgroundCssClass="modalBackground" __designer:wfdid="w74"></cc1:ModalPopupExtender> </DIV></DIV>
</ContentTemplate>
</cc1:TabPanel>
<cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2"><HeaderTemplate>
Property Acknowledgement Receipt 
</HeaderTemplate>
<ContentTemplate>
<DIV style="TEXT-ALIGN: center"><TABLE style="LEFT: 0px; WIDTH: 950px; POSITION: relative; TOP: 0px"><TBODY><TR><TD style="WIDTH: 1000px; TEXT-ALIGN: center"><DIV class="DivTitle">LIST OF PROPERTY</DIV></TD></TR><TR><TD style="WIDTH: 1000px; TEXT-ALIGN: center"><DIV style="TEXT-ALIGN: center"><TABLE style="LEFT: 0px; WIDTH: 950px; TOP: 0px"><TBODY><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 200px" class="column_RightBold">Property :</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 200px" class="text5"><asp:DropDownList style="POSITION: relative" id="ddProperty" runat="server" Width="200px" OnSelectedIndexChanged="ddProperty_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD style="VERTICAL-ALIGN: top; WIDTH: 200px" class="column_RightBold">Item Desccription :</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 200px" align=left Char="column_LeftBold"><asp:TextBox id="txtSearchProperty" runat="server" Width="200px"></asp:TextBox> </TD><TD style="VERTICAL-ALIGN: top; WIDTH: 200px" class="text5"><asp:Button style="POSITION: relative" id="btnSearchProperty" onclick="btnSearchProperty_Click" runat="server" Width="170px" Text="Search"></asp:Button> </TD></TR></TBODY></TABLE></DIV></TD></TR><TR><TD style="WIDTH: 1000px; TEXT-ALIGN: center"><asp:GridView style="POSITION: relative" id="gvsearchProperty" runat="server" Width="700px" SkinID="GridViewGL" HorizontalAlign="Center" DataKeyNames="Item_id,Item_Desc,GA_ID,ItemParticular" AllowPaging="True"><Columns>
<asp:BoundField DataField="Item_Desc" HeaderText="Item Description">
<HeaderStyle HorizontalAlign="Left" Width="440px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="440px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Description" HeaderText="Unit">
<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Qty" HeaderText="Quantity">
<HeaderStyle Width="100px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView> </TD></TR><TR><TD style="WIDTH: 1000px; TEXT-ALIGN: center"><asp:GridView style="POSITION: relative" id="grListOfProperty" runat="server" Width="950px" SkinID="GridViewGL" HorizontalAlign="Center" DataKeyNames="status,PropertyNo,Rc_name,rc_id,function_id,MREHdr_ID,Property_ID,PropertyDetai_ID,Item_ID,MREDtl_ID" AllowPaging="True" PageSize="5"><Columns>
<asp:BoundField DataField="Item_Desc" HeaderText="Item Description">
<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PropertyNo" HeaderText="Property Number"></asp:BoundField>
<asp:BoundField DataField="PO_Date" DataFormatString="{0:d}" HeaderText="Date Purchase"></asp:BoundField>
<asp:BoundField DataField="Cost" DataFormatString="{0:N}" HeaderText="Amount"></asp:BoundField>
<asp:BoundField DataField="rc_name" HeaderText="Department">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fullname" HeaderText=" Issued To"></asp:BoundField>
<asp:BoundField DataField="DateIssued" DataFormatString="{0:d}" HeaderText="Date Issued"></asp:BoundField>
<asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>
<asp:BoundField DataField="MRE_Hdr" HeaderText="MRE_Hdr"></asp:BoundField>
</Columns>
</asp:GridView> </TD></TR><TR><TD style="WIDTH: 1000px; TEXT-ALIGN: center"><asp:HiddenField id="HiddenField1" runat="server"></asp:HiddenField> </TD></TR><TR><TD style="WIDTH: 1000px; TEXT-ALIGN: center"><asp:Button style="POSITION: relative" id="btnIssue" runat="server" Width="184px" Text="ISSUE"></asp:Button> <asp:Button style="POSITION: relative" id="btnviewProperty" onclick="btnviewProperty_Click" runat="server" Width="184px" Text="VIEW PROPERTY CARD"></asp:Button> <asp:Button style="POSITION: relative" id="btnReturnProperty" runat="server" Width="184px" Text="RETURN"></asp:Button> </TD></TR></TBODY></TABLE></DIV><BR /><TABLE style="WIDTH: 971px; TEXT-ALIGN: center" class="text"><TBODY><TR><TD colSpan=5><TABLE style="LEFT: 0px; POSITION: relative; TOP: 0px" id="Table5" class="strip" onclick="return Table2_onclick()" width=950><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 16px; TEXT-ALIGN: left"><STRONG>ISSUANCE</STRONG></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 970px; HEIGHT: 100%" class="Text"><TBODY><TR><TD style="WIDTH: 166px; HEIGHT: 11px" class="column_RightBold"></TD><TD style="WIDTH: 106px; HEIGHT: 11px"></TD><TD style="WIDTH: 184px; HEIGHT: 11px"><IMG src="../images/Edited%20Image/ReceivedButton.jpg" /></TD><TD style="WIDTH: 247px; HEIGHT: 11px" class="column_RightBold"></TD><TD style="HEIGHT: 11px" colSpan=2><IMG src="../images/Edited%20Image/ReceivedByButton.jpg" /></TD></TR><TR><TD style="WIDTH: 166px; HEIGHT: 24px; TEXT-ALIGN: right" class="column_RightBold">MRE Number :</TD><TD style="HEIGHT: 24px" colSpan=2><asp:TextBox style="POSITION: relative" id="txtMRE" runat="server" Width="180px" CssClass="txtboxinspection" ReadOnly="True"></asp:TextBox> </TD><TD style="WIDTH: 247px; HEIGHT: 24px; TEXT-ALIGN: right" class="column_RightBold"></TD><TD style="HEIGHT: 24px" colSpan=2></TD></TR><TR><TD style="WIDTH: 166px; HEIGHT: 24px; TEXT-ALIGN: right" class="column_RightBold">Department :</TD><TD style="HEIGHT: 24px" colSpan=2><asp:DropDownList id="ddFromDepartment" runat="server" Width="310px" CssClass="txtboxinspection" AppendDataBoundItems="True"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList> </TD><TD style="WIDTH: 247px; HEIGHT: 24px; TEXT-ALIGN: right" class="column_RightBold">Department :</TD><TD style="HEIGHT: 24px" colSpan=2><asp:DropDownList id="ddByDepartment" runat="server" Width="310px" CssClass="txtboxinspection" AppendDataBoundItems="True"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 166px; HEIGHT: 26px; TEXT-ALIGN: right" class="column_RightBold">Property Officer :</TD><TD style="HEIGHT: 26px" colSpan=2><asp:DropDownList id="ddFromProperty" runat="server" Width="310px" CssClass="txtboxinspection" AppendDataBoundItems="True"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList> </TD><TD style="WIDTH: 247px; HEIGHT: 26px; TEXT-ALIGN: right" class="column_RightBold">Acknowledge To :</TD><TD style="HEIGHT: 26px" colSpan=2><asp:DropDownList id="ddByAcknowledgement" runat="server" Width="310px" CssClass="txtboxinspection" AppendDataBoundItems="True"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 166px; HEIGHT: 17px; TEXT-ALIGN: right" class="column_RightBold">Date :</TD><TD style="WIDTH: 106px; HEIGHT: 17px"><asp:TextBox id="txtDateReceivedFrom" runat="server" Width="115px" CssClass="txtboxinspection"></asp:TextBox> </TD><TD style="WIDTH: 184px; HEIGHT: 17px"><asp:Image id="Image1" runat="server" Width="30px" ImageUrl="~/images/CalendarImage.jpg" Height="20px"></asp:Image> </TD><TD style="WIDTH: 247px; HEIGHT: 17px; TEXT-ALIGN: right" class="column_RightBold">Date :</TD><TD style="WIDTH: 116px; HEIGHT: 17px"><asp:TextBox id="txtDateReceivedBy" runat="server" Width="115px" CssClass="txtboxinspection" OnTextChanged="txtDateReceivedBy_TextChanged"></asp:TextBox> </TD><TD style="WIDTH: 366px; HEIGHT: 17px"><asp:Image id="Image2" runat="server" Width="30px" ImageUrl="~/images/CalendarImage.jpg" Height="20px"></asp:Image> </TD></TR><TR><TD style="WIDTH: 166px" class="column_RightBold"></TD><TD colSpan=2><cc1:CalendarExtender id="CalendarExtender2" runat="server" TargetControlID="txtDateReceivedFrom" Enabled="True" PopupButtonID="Image1"></cc1:CalendarExtender> </TD><TD style="WIDTH: 247px" class="column_RightBold"></TD><TD colSpan=2><cc1:CalendarExtender id="CalendarExtender1" runat="server" TargetControlID="txtDateReceivedBy" Enabled="True" PopupButtonID="Image2"></cc1:CalendarExtender> </TD></TR><TR><TD style="WIDTH: 166px" class="column_RightBold"></TD><TD colSpan=2></TD><TD style="WIDTH: 247px" class="column_RightBold"></TD><TD colSpan=2></TD></TR><TR><TD align=center colSpan=6><asp:Button style="POSITION: relative; TOP: 1px" id="btnsavedoc" onclick="btnsavedoc_Click" runat="server" Width="169px" Text="SAVE" Height="32px" Enabled="False"></asp:Button> <asp:Button style="POSITION: relative" id="btncancelDoc" onclick="btncancelDoc_Click" runat="server" Width="169px" Text="CANCEL" Height="32px" Enabled="False"></asp:Button> <asp:Button style="POSITION: relative; TOP: 2px" id="btnpreviewAreDoc" onclick="btnpreviewAreDoc_Click" runat="server" Width="169px" Text="PREVIEW ARE" Height="32px" Enabled="False"></asp:Button> </TD></TR></TBODY></TABLE><BR /><DIV style="TEXT-ALIGN: center"><TABLE style="LEFT: 0px; WIDTH: 975px; POSITION: relative; TOP: 0px"><TBODY><TR><TD style="WIDTH: 975px"><TABLE style="LEFT: 0px; POSITION: relative; TOP: 0px" id="Table6" class="strip" onclick="return Table2_onclick()" width=950><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 16px; TEXT-ALIGN: left"><SPAN style="FONT-SIZE: 10pt; FONT-FAMILY: Verdana"><STRONG>SCANNED DOCUMENTS</STRONG></SPAN></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></DIV><TABLE style="WIDTH: 973px"><TBODY><TR><TD style="WIDTH: 581px; HEIGHT: 430px" colSpan=2><FIELDSET style="WIDTH: 636px; HEIGHT: 420px"><LEGEND><SPAN style="FONT-SIZE: 9pt; FONT-FAMILY: Verdana"><STRONG>Document/s Submitted</STRONG></SPAN></LEGEND><TABLE style="LEFT: 0px; WIDTH: 630px; POSITION: relative; TOP: 0px"><TBODY><TR><TD style="WIDTH: 630px; TEXT-ALIGN: center" colSpan=6><asp:HiddenField id="hdfinspection" runat="server"></asp:HiddenField> <INPUT style="DISPLAY: none; POSITION: relative" id="File2" type=file onchange="Handlechange();" name="fileupload" /> </TD></TR><TR><TD style="WIDTH: 110px" class="column_LeftBold">Document Name </TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 200px"><asp:TextBox style="POSITION: relative" id="txtdocname" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox> </TD><TD style="WIDTH: 110px" class="column_LeftBold">Validated By </TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 200px"><asp:TextBox style="POSITION: relative" id="txtValidatedBy" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 110px" class="column_LeftBold">Property No. </TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 200px"><asp:TextBox style="POSITION: relative" id="txtPropertyNo" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox> </TD><TD style="WIDTH: 110px" class="column_LeftBold">Date Validated </TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 200px"><asp:TextBox style="POSITION: relative" id="txtDatevalidated" runat="server" Width="116px" CssClass="txtboxinspection" Height="20px"></asp:TextBox> &nbsp;<asp:Image style="LEFT: 0px; POSITION: relative; TOP: 3px" id="Image3" runat="server" Width="30px" ImageUrl="~/images/CalendarImage.jpg" Height="20px"></asp:Image> </TD></TR></TBODY></TABLE><cc1:CalendarExtender id="CalendarExtender3" runat="server" TargetControlID="txtDatevalidated" Enabled="True" PopupButtonID="Image3"></cc1:CalendarExtender> <TABLE style="WIDTH: 628px"><TBODY><TR><TD style="WIDTH: 274px; HEIGHT: 34px; TEXT-ALIGN: right"><INPUT style="LEFT: 0px; WIDTH: 147px; POSITION: relative; HEIGHT: 32px" id="btninspectionBrowse" onclick="HandleBrowseClick();" type=submit value="BROWSE" runat="server" OnServerClick="btninspectionBrowse_ServerClick" /> </TD><TD style="WIDTH: 164px; HEIGHT: 34px"><asp:Button id="btnAddDoc" onclick="btnAddDoc_Click" runat="server" Width="169px" Text="ADD DOCUMENT" Height="32px" ValidationGroup="add"></asp:Button> </TD><TD style="HEIGHT: 34px"><asp:Button id="btndoccancel" onclick="btndoccancel_Click" runat="server" Width="169px" Text="CANCEL" Height="32px"></asp:Button> </TD></TR></TBODY></TABLE><BR /><asp:GridView id="gvDocumentAdded" runat="server" Width="628px" OnSelectedIndexChanged="gvDocumentAdded_SelectedIndexChanged" SkinID="GridViewGL" HorizontalAlign="Center" DataKeyNames="DocuID" AllowPaging="True" PageSize="5" OnRowDataBound="gvDocumentAdded_RowDataBound" AutoGenerateColumns="False"><Columns>
<asp:BoundField DataField="DocumentName" HeaderText="Document Name">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PropertyNo" HeaderText="Property No."></asp:BoundField>
<asp:BoundField DataField="ValidatedBy" HeaderText="Validated By">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DateValidated" DataFormatString="{0:d}" HeaderText="Date Validated"></asp:BoundField>
</Columns>
</asp:GridView> </FIELDSET> </TD><TD style="WIDTH: 303px; HEIGHT: 430px"><FIELDSET style="WIDTH: 302px; HEIGHT: 420px"><LEGEND class="text">Document Preview</LEGEND><TABLE style="WIDTH: 296px; HEIGHT: 402px"><TBODY><TR><TD style="WIDTH: 302px; HEIGHT: 175px" align=center><asp:Image id="imgDocPreview" runat="server" Width="302px" ImageUrl="~/images/BlankImage.jpg" Height="396px"></asp:Image> </TD></TR></TBODY></TABLE></FIELDSET> </TD></TR></TBODY></TABLE><BR /><asp:Panel style="LEFT: 0px; POSITION: relative; TOP: 0px" id="popReturn" runat="server" Width="400px" Height="220px" BackImageUrl="~/images/modalpopup_04.png"><TABLE style="LEFT: 3px; POSITION: relative; TOP: 2px"><TBODY><TR><TD style="WIDTH: 100px" class="column_RightBold"></TD><TD style="WIDTH: 10px" class="column_LeftBold"></TD><TD style="WIDTH: 240px"></TD><TD style="WIDTH: 40px"><asp:Button style="LEFT: -7px; POSITION: relative; TOP: 3px" id="btnClose" runat="server" Width="30px" ForeColor="White" Text="X" CssClass="Close" BorderStyle="None" BorderColor="#FFC080" BackColor="#FFC080"></asp:Button> </TD></TR><TR><TD style="WIDTH: 100px" class="column_RightBold">Date Return</TD><TD style="WIDTH: 10px" class="column_LeftBold">:</TD><TD style="WIDTH: 240px"><asp:TextBox style="POSITION: relative" id="txtDateReturn" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox> &nbsp; <cc1:CalendarExtender id="CalendarExtender4" runat="server" TargetControlID="txtDateReturn" Enabled="True" PopupButtonID="txtDateReturn"></cc1:CalendarExtender> </TD><TD style="WIDTH: 40px"></TD></TR><TR><TD style="VERTICAL-ALIGN: top" class="column_RightBold">Remarks &nbsp;</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 10px" class="column_LeftBold">:</TD><TD style="WIDTH: 240px"><asp:TextBox style="POSITION: relative" id="txtReturnRemarks" runat="server" Width="220px" CssClass="txtboxinspection" Height="100px" TextMode="MultiLine"></asp:TextBox> </TD><TD style="WIDTH: 40px"></TD></TR><TR><TD style="VERTICAL-ALIGN: top" class="column_RightBold"></TD><TD style="VERTICAL-ALIGN: top; WIDTH: 10px" class="column_LeftBold"></TD><TD style="WIDTH: 240px"><asp:Button style="POSITION: relative" id="btnReturnPro" onclick="btnReturnPro_Click" runat="server" Width="120px" Text="Return" Height="29px"></asp:Button> </TD><TD style="WIDTH: 40px"></TD></TR></TBODY></TABLE></asp:Panel> &nbsp;<BR /><BR /><BR /><cc1:ModalPopupExtender id="ModalPopupExtender3" runat="server" TargetControlID="btnReturnProperty" Enabled="True" DynamicServicePath="" CancelControlID="btnClose" PopupControlID="popReturn"></cc1:ModalPopupExtender> 
</ContentTemplate>
</cc1:TabPanel>
</cc1:TabContainer> </TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>

</td>
</tr>
</table>
</asp:Content>