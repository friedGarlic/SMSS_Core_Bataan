<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_WasteMaterial.aspx.vb" Inherits="Inventory_t_WasteMaterial" title="WasteMaterial" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="OnBarcode.Barcode.ASPNET" Namespace="OnBarcode.Barcode.ASPNET"
    TagPrefix="cc2" %>
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
    }




    </script>

    <table class="PageTitle">
        <tr>
            <td style="width: 1000px; height: 21px;">
                Waste Disposal</td>
        </tr>
    </table>
    <br />


    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" Visible="true">
        <contenttemplate>
<TABLE width=1000><TBODY><TR><TD style="WIDTH: 1000px"><DIV class="DivTitle">Items for Disposal</DIV></TD></TR><TR><TD style="WIDTH: 1000px"><TABLE width=1000><TBODY><TR><TD style="WIDTH: 300px" class="column_RightBold">Department :</TD><TD style="WIDTH: 700px" class="text5"><asp:DropDownList id="drpdept" runat="server" Width="400px" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="drpdept_SelectedIndexChanged" DataTextField="rc_name" DataValueField="rc_id" CssClass="txtboxinspection" __designer:wfdid="w108"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 300px" class="column_RightBold">Function :</TD><TD style="WIDTH: 700px" class="text5"><asp:DropDownList id="ddFunction" runat="server" Width="400px" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="ddFunction_SelectedIndexChanged" DataTextField="Function_desc" DataValueField="Function_id" CssClass="txtboxinspection" __designer:wfdid="w109"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD align=center colSpan=2><asp:RadioButtonList id="rbChoice" runat="server" Width="200px" Font-Bold="True" Font-Size="11pt" Font-Names="Calibri" AutoPostBack="True" OnSelectedIndexChanged="rbChoice_SelectedIndexChanged" CssClass="txtboxinspection" __designer:wfdid="w7" Enabled="False" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="1">Supply</asp:ListItem>
<asp:ListItem Value="2">Property</asp:ListItem>
</asp:RadioButtonList></TD></TR></TBODY></TABLE><asp:Button id="btnADD" onclick="btnADD_Click" runat="server" Width="200px" Visible="False" __designer:wfdid="w111" Enabled="False" Text="VIEW" SkinID="ButtonImage" Height="30px"></asp:Button></TD></TR><TR><TD style="WIDTH: 1000px"></TD></TR><TR><TD style="WIDTH: 1000px"><asp:MultiView id="mvCategory" runat="server" __designer:wfdid="w142"><asp:View id="vwSupplies" runat="server" __designer:wfdid="w143"><asp:Panel id="Panel3" runat="server" Width="1000px" Font-Bold="False" CssClass="text" __designer:wfdid="w18" Height="400px" GroupingText="SUPPLIES" ScrollBars="Vertical" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"><asp:GridView id="grdSupplies" runat="server" Width="970px" CssClass="text" __designer:wfdid="w20" SkinID="GridViewGL" EmptyDataText="No Records Found" DataKeyNames="Item_ID">
<EmptyDataRowStyle BorderColor="Red" BorderWidth="1px" BorderStyle="Solid" Font-Names="Calibri" Font-Size="11pt"></EmptyDataRowStyle>
<Columns>
<asp:TemplateField><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<HeaderTemplate>
<asp:CheckBox id="cbAll" runat="server" __designer:wfdid="w27" AutoPostBack="True" Text="ALL" OnCheckedChanged="cbAll_CheckedChanged"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="cbSelect" runat="server" __designer:wfdid="w28" AutoPostBack="True"></asp:CheckBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="5px"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="Item_Desc" HeaderText="Item Descrption">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="StockDate" HeaderText="Stock Date">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="useful_life" HeaderText="Useful Life">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="uLife" HeaderText="Service Year">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="balance" HeaderText="Balance">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Qty to Dispose"><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox2"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtQty" runat="server" Width="50px" __designer:wfdid="w17" CssClass="txtboxinspection" Text='<%# bind("Balance") %>'></asp:TextBox>
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
</Columns>
</asp:GridView></asp:Panel></asp:View> <asp:View id="vwProperties" runat="server" __designer:wfdid="w144"><asp:Panel id="Panel4" runat="server" Width="1000px" CssClass="text" __designer:wfdid="w32" Height="400px" GroupingText="PROPERTIES" ScrollBars="Vertical" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"><asp:GridView id="grdProperties" runat="server" Width="970px" CssClass="text" __designer:wfdid="w4" SkinID="GridViewGL" EmptyDataText="No Records Found" DataKeyNames="Item_ID"><Columns>
<asp:TemplateField><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<HeaderTemplate>
<asp:CheckBox id="cbAll" runat="server" __designer:wfdid="w6" AutoPostBack="True" Text="ALL" OnCheckedChanged="cbAll_CheckedChanged1"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="cbProp" runat="server" __designer:wfdid="w5" AutoPostBack="True"></asp:CheckBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="5px"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="Item_Desc" HeaderText="Item Descrption">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PropertyNo" HeaderText="Property No.">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Property_Date" HeaderText="Property Date">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="useful_life" HeaderText="Useful Life">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="uLife" HeaderText="Service Year">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView></asp:Panel><BR /></asp:View></asp:MultiView></TD></TR><TR><TD style="WIDTH: 1000px"></TD></TR><TR><TD style="WIDTH: 1000px"><asp:Panel id="Panel1" runat="server" Width="1000px" Font-Bold="False" CssClass="text" __designer:wfdid="w118" GroupingText="INFORMATION" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 150px" class="column_RightBold">Date </TD><TD style="WIDTH: 10px" class="column_RightBold">:</TD><TD style="WIDTH: 840px" class="text5"><asp:TextBox id="txtdate" runat="server" Width="150px" CssClass="txtboxinspection" __designer:wfdid="w54" SkinID="text"></asp:TextBox><asp:ImageButton id="ImageButton2" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" __designer:wfdid="w55" Height="15px"></asp:ImageButton><SPAN style="FONT-SIZE: 9pt"><SPAN style="FONT-FAMILY: Calibri"><STRONG>(mm/dd/yyyy)</STRONG></SPAN></SPAN></TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 150px" class="column_RightBold">Disposal Type&nbsp;</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 10px" class="column_RightBold">:</TD><TD style="WIDTH: 840px" class="text5"><asp:DropDownList id="ddDisposal" runat="server" Width="400px" AutoPostBack="True" OnSelectedIndexChanged="ddDisposal_SelectedIndexChanged" CssClass="txtboxinspection" __designer:wfdid="w2"><asp:ListItem Value="0">Select</asp:ListItem>
<asp:ListItem Value="1">Public Auction</asp:ListItem>
<asp:ListItem Value="2">Private Sale</asp:ListItem>
<asp:ListItem Value="3">Destroy</asp:ListItem>
<asp:ListItem Value="4">Donation</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 150px" class="column_RightBold">Certified Correct</TD><TD style="WIDTH: 10px" class="column_RightBold">:</TD><TD style="WIDTH: 840px" class="text5"><asp:DropDownList id="drpCertified" runat="server" Width="400px" AutoPostBack="True" DataTextField="full_name" DataValueField="Signatory_id" CssClass="txtboxinspection" __designer:wfdid="w67"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 150px" class="column_RightBold">Approving Officer</TD><TD style="WIDTH: 10px" class="column_RightBold">:</TD><TD style="WIDTH: 840px" class="text5"><asp:DropDownList id="drpApproving" runat="server" Width="400px" AutoPostBack="True" OnSelectedIndexChanged="drpdept_SelectedIndexChanged" CssClass="txtboxinspection" __designer:wfdid="w68"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 150px" class="column_RightBold">Property Officer</TD><TD style="WIDTH: 10px" class="column_RightBold">:</TD><TD style="WIDTH: 840px" class="text5"><asp:DropDownList id="drpPropertyOfficer" runat="server" Width="400px" AutoPostBack="True" OnSelectedIndexChanged="drpdept_SelectedIndexChanged" CssClass="txtboxinspection" __designer:wfdid="w69"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 150px" class="column_RightBold">Witness</TD><TD style="WIDTH: 10px" class="column_RightBold">:</TD><TD style="WIDTH: 840px" class="text5"><asp:TextBox id="txtWitness" runat="server" Width="395px" CssClass="txtboxinspection" __designer:wfdid="w4"></asp:TextBox></TD></TR><TR><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: right" class="column_RightBold">Remarks</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 10px" class="column_RightBold">:</TD><TD style="WIDTH: 840px" class="text5"><asp:TextBox style="TEXT-ALIGN: left" id="txtpurpose" runat="server" Width="395px" CssClass="txtboxinspection" __designer:wfdid="w1" SkinID="text" Height="40px" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 150px" class="column_RightBold"></TD><TD style="WIDTH: 10px" class="column_RightBold"></TD><TD style="WIDTH: 840px" class="text5"><cc1:CalendarExtender id="CalendarExtender2" runat="server" __designer:wfdid="w64" TargetControlID="txtdate" PopupButtonID="ImageButton2">
                            </cc1:CalendarExtender> <cc1:MaskedEditExtender id="MaskedEditExtender1" runat="server" __designer:wfdid="w65" TargetControlID="txtdate" Mask="99/99/9999" MaskType="Date">
                            </cc1:MaskedEditExtender></TD></TR></TBODY></TABLE></asp:Panel></TD></TR><TR><TD style="WIDTH: 1000px"><asp:Button id="btnsave" onclick="btnsave_Click" runat="server" Width="203px" __designer:wfdid="w129" Text="SAVE" SkinID="ButtonImage" Height="30px" OnClientClick="StartProgressBar();"></asp:Button><asp:Button id="btnpreview" runat="server" Width="200px" CausesValidation="False" __designer:wfdid="w131" Enabled="False" Text="PREVIEW" SkinID="ButtonImage" Height="30px" OnClick="btnpreview_Click1"></asp:Button></TD></TR></TBODY></TABLE><cc1:ConfirmButtonExtender id="ConfirmButtonExtender1" runat="server" __designer:wfdid="w107" Enabled="True" TargetControlID="btnsave" ConfirmText="Are you sure you want to save this transaction?"></cc1:ConfirmButtonExtender><asp:Panel style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #0033cc; BORDER-BOTTOM-WIDTH: 1px; BORDER-BOTTOM-COLOR: #0033cc; BORDER-TOP-COLOR: #0033cc; BACKGROUND-COLOR: transparent; TEXT-ALIGN: center; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #0033cc" id="PanelProgress" runat="server" Width="109px" __designer:wfdid="w25"><IMG src="../images/ajax-loader.gif" /></asp:Panel> <cc1:ModalPopupExtender id="ProgressBarModalPopupExtender" runat="server" __designer:wfdid="w26" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender> <asp:Button style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none" id="ButtonProgress" runat="server" Width="16px" __designer:wfdid="w27" Enabled="False"></asp:Button> 
</contenttemplate>
    </asp:UpdatePanel></td>
</tr>
</table>
</asp:Content>
