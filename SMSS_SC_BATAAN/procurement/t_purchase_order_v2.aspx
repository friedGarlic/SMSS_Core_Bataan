<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="false"  
CodeFile="t_purchase_order_v2.aspx.vb" Inherits="t_purchase_order_v2" Title="PROCUREMENT - PO" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

 <asp:ScriptManager ID="ScriptManager1" runat="server">
 </asp:ScriptManager>

 <script type="text/javascript">
      // It is important to place this JavaScript code after ScriptManager1
      var xPos, yPos;
      var prm = Sys.WebForms.PageRequestManager.getInstance();

      function BeginRequestHandler(sender, args) {
        if ($get('<%=Panel2.ClientID%>') != null) {
          // Get X and Y positions of scrollbar before the partial postback
          xPos = $get('<%=Panel2.ClientID%>').scrollLeft;
          yPos = $get('<%=Panel2.ClientID%>').scrollTop;
        }
     }

     function EndRequestHandler(sender, args) {
         if ($get('<%=Panel2.ClientID%>') != null) {
           // Set X and Y positions back to the scrollbar
           // after partial postback
           $get('<%=Panel2.ClientID%>').scrollLeft = xPos;
           $get('<%=Panel2.ClientID%>').scrollTop = yPos;
         }
     }

     prm.add_beginRequest(BeginRequestHandler);
     prm.add_endRequest(EndRequestHandler);
 </script>

  
 
    <asp:UpdatePanel  id="UpdatePanel1" runat="server">   
        <contenttemplate>
<SCRIPT type="text/javascript">

function HandleBrowseClick()
{
    var fileinput = document.getElementById("flbuilding");
    fileinput.click();
  
 
}
function Handlechange()
{
    var fileinput = document.getElementById("flbuilding");
    var hiddenControl = '<%= hdfbuilding.ClientID %>';
    document.getElementById(hiddenControl).value= fileinput.value ;
 }
 

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


</SCRIPT>
<TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 1000px" class="PageTitle" align=center>PURCHASE ORDER</TD></TR><TR><TD style="WIDTH: 1000px" align=center><asp:RadioButtonList id="RadioButtonList1" runat="server" Width="221px" __designer:wfdid="w1" CssClass="text2" RepeatDirection="Horizontal" AutoPostBack="True" Visible="False"><asp:ListItem Selected="True">Create PO</asp:ListItem>
<asp:ListItem>PO Table</asp:ListItem>
</asp:RadioButtonList></TD></TR><TR><TD style="WIDTH: 1000px" align=center><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 15%" class="column_RightBold">Search By : </TD><TD style="WIDTH: 25%" class="text5"><asp:DropDownList id="Drpsearch" runat="server" Width="95%" __designer:wfdid="w9" AutoPostBack="True" OnSelectedIndexChanged="Drpsearch_SelectedIndexChanged"><asp:ListItem Value="1">--ALL--</asp:ListItem>
<asp:ListItem Value="2">Purchase Request</asp:ListItem>
<asp:ListItem Value="3">Project Reference No.</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 15%" class="column_RightBold"><asp:Label style="TEXT-ALIGN: left" id="Lblsearch" runat="server" __designer:wfdid="w10" Text="Project Reference No. :"></asp:Label></TD><TD style="WIDTH: 25%" class="text5"><asp:MultiView id="MultiView2" runat="server" __designer:wfdid="w11"><asp:View id="View4" runat="server" __designer:wfdid="w12"><asp:TextBox id="txtsearch" runat="server" Width="95%" __designer:wfdid="w13" MaxLength="10"></asp:TextBox></asp:View> <asp:View id="View5" runat="server" __designer:wfdid="w14"><asp:TextBox id="txtsearchRPN" runat="server" Width="95%" __designer:wfdid="w15"></asp:TextBox></asp:View> </asp:MultiView></TD><TD style="WIDTH: 20%" class="text5"><asp:Button id="btnview" onclick="Button1_Click" runat="server" Width="90%" __designer:wfdid="w16" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></TD></TR></TBODY></TABLE><cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender2" runat="server" __designer:wfdid="w17" TargetControlID="txtsearch" FilterType="Numbers">
                </cc1:FilteredTextBoxExtender></TD></TR><TR><TD style="WIDTH: 1000px" align=center><asp:GridView style="FONT-WEIGHT: normal; TEXT-ALIGN: justify" id="gvPurchase_Order" runat="server" Width="100%" __designer:wfdid="w18" OnSelectedIndexChanged="gvPurchase_Order_SelectedIndexChanged" SkinID="GridViewAA" OnRowDataBound="gvPurchase_Order_RowDataBound" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="prhdr_id,isGasoline,SuppName,Address1,ContractPrice,Supplier_ID,pr_no,RC_ID,Function_ID,CanvassID,mode_of_procurement_id,isCanvass,ID,isBidding,pre_procurement_hdr_id,isConsolidated,GA_ID,ProjectName,Consolidated_PRNumber">
<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

<RowStyle BorderColor="Black" BorderStyle="None"></RowStyle>

<EmptyDataRowStyle BorderColor="Gray" BorderStyle="Solid"></EmptyDataRowStyle>
<Columns>
<asp:BoundField DataField="pr_no" HeaderText="PR No. / Reference No.">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RC_Name" HeaderText="Requesting Dept">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="OBR_No" HeaderText="OBR No."></asp:BoundField>
<asp:BoundField DataField="SuppName" HeaderText="Supplier">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ProjectName" HeaderText="Project Name">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BorderColor="Gray" BorderStyle="None"></PagerStyle>

<SelectedRowStyle BorderColor="Transparent"></SelectedRowStyle>

<HeaderStyle BackColor="#2977DC" BorderColor="Transparent" BorderStyle="None" ForeColor="White"></HeaderStyle>

<EditRowStyle BorderColor="White"></EditRowStyle>
</asp:GridView></TD></TR><TR><TD style="WIDTH: 1000px" align=center><FIELDSET style="BORDER-RIGHT: #2977dc 1px solid; BORDER-TOP: #2977dc 1px solid; BORDER-LEFT: #2977dc 1px solid; WIDTH: 1000px; BORDER-BOTTOM: #2977dc 1px solid; HEIGHT: 150px"><LEGEND><SPAN style="FONT-SIZE: 10pt; FONT-FAMILY: Arial"><STRONG><EM>CREATE PURCHASE ORDER</EM></STRONG></SPAN></LEGEND><TABLE id="tablePurchaseorder" class="text2" width=1000><TBODY><TR><TD style="WIDTH: 129px; HEIGHT: 30px" align=right>Supplier</TD><TD style="WIDTH: 5px; HEIGHT: 30px">:</TD><TD style="WIDTH: 162px; HEIGHT: 30px"><asp:TextBox id="txtSupplier" runat="server" Width="280px" __designer:wfdid="w19" CssClass="txtboxinspection" SkinID="text" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 91px; HEIGHT: 30px" align=right>Contract Price</TD><TD style="WIDTH: 9px; HEIGHT: 30px">:</TD><TD style="WIDTH: 132px; HEIGHT: 30px"><asp:TextBox style="TEXT-ALIGN: right" id="txtAmount" runat="server" Width="150px" __designer:wfdid="w20" CssClass="txtboxinspection" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 115px; HEIGHT: 30px">Payment Term</TD><TD style="WIDTH: 14px; HEIGHT: 30px">:</TD><TD style="HEIGHT: 30px"><asp:DropDownList id="ddPterm" runat="server" Width="124px" __designer:wfdid="w21" CssClass="ddropbox1" Enabled="False"><asp:ListItem>Cash on delivery</asp:ListItem>
<asp:ListItem>Cash before shipment</asp:ListItem>
<asp:ListItem>Payment in advance</asp:ListItem>
<asp:ListItem>End of month</asp:ListItem>
<asp:ListItem>Net 7</asp:ListItem>
<asp:ListItem>Net 30</asp:ListItem>
<asp:ListItem>Net 60</asp:ListItem>
<asp:ListItem>Net 90</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 129px" align=right>Address</TD><TD style="WIDTH: 5px">:</TD><TD style="WIDTH: 162px"><asp:TextBox id="txtaddress" runat="server" Width="280px" __designer:wfdid="w22" CssClass="txtboxinspection" SkinID="text" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 91px" align=right>PO Number</TD><TD style="WIDTH: 9px">:</TD><TD style="WIDTH: 132px"><asp:TextBox id="txtPOnum" runat="server" Width="150px" __designer:wfdid="w23" CssClass="txtboxinspection" SkinID="text" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 115px">Reimbursement</TD><TD style="WIDTH: 14px">:</TD><TD><asp:CheckBox id="cbReimbursement" runat="server" __designer:wfdid="w24" AutoPostBack="True" Enabled="False" OnCheckedChanged="cbReimbursement_CheckedChanged"></asp:CheckBox></TD></TR><TR><TD style="WIDTH: 129px" align=right>Place of Delivery<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" __designer:wfdid="w25" ControlToValidate="txtDPlace" ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator></TD><TD style="WIDTH: 5px">:</TD><TD style="WIDTH: 162px"><asp:TextBox id="txtDPlace" runat="server" Width="280px" __designer:wfdid="w26" CssClass="txtboxinspection" SkinID="text"></asp:TextBox></TD><TD style="WIDTH: 91px" align=right>PO Date<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Width="10px" __designer:wfdid="w27" ControlToValidate="txtPOdate" ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator></TD><TD style="WIDTH: 9px">:</TD><TD style="WIDTH: 132px" align=left><asp:TextBox id="txtPOdate" runat="server" Width="96px" __designer:wfdid="w28" CssClass="txtboxinspection" SkinID="text" OnTextChanged="txtPOdate_TextChanged"></asp:TextBox><asp:ImageButton id="ImageButton1" runat="server" Width="25px" ImageUrl="~/images/CalendarImage.jpg" __designer:wfdid="w29" Height="20px"></asp:ImageButton> </TD><TD style="WIDTH: 115px"></TD><TD style="WIDTH: 14px"></TD><TD></TD></TR><TR><TD style="WIDTH: 129px; HEIGHT: 16px" align=right>Delivery Date<asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" __designer:wfdid="w30" ControlToValidate="txtDeliveryDate" ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator></TD><TD style="WIDTH: 5px; HEIGHT: 16px">:</TD><TD style="WIDTH: 162px; HEIGHT: 16px"><DIV style="TEXT-ALIGN: left"><TABLE style="LEFT: 0px; TOP: 0px" width=280><TBODY><TR><TD style="WIDTH: 100px" class="text5"><asp:TextBox id="txtDeliveryDate" runat="server" Width="100px" __designer:wfdid="w31" CssClass="txtboxinspection" SkinID="text" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 20px" class="text5"><asp:ImageButton id="ImageButton3" runat="server" Width="25px" ImageUrl="~/images/CalendarImage.jpg" __designer:wfdid="w32" Height="20px"></asp:ImageButton></TD><TD style="WIDTH: 140px" class="textimage1"><asp:Label id="lblmsg" runat="server" Width="120px" ForeColor="Red" __designer:wfdid="w33" CssClass="textimage1" Text="Label"></asp:Label></TD></TR></TBODY></TABLE></DIV></TD><TD style="WIDTH: 91px; HEIGHT: 16px" align=right>Delivery Term</TD><TD style="WIDTH: 9px; HEIGHT: 16px">:</TD><TD style="WIDTH: 132px"><asp:DropDownList id="ddDT" runat="server" Width="150px" __designer:wfdid="w34" CssClass="ddropbox1" Enabled="False"><asp:ListItem>7 Days</asp:ListItem>
<asp:ListItem>15 Days</asp:ListItem>
<asp:ListItem>30 Days</asp:ListItem>
<asp:ListItem>60 Days</asp:ListItem>
<asp:ListItem>90 Days</asp:ListItem>
<asp:ListItem>120 Days</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 115px; HEIGHT: 16px"></TD><TD style="WIDTH: 14px; HEIGHT: 16px"></TD><TD style="HEIGHT: 16px"></TD></TR><TR><TD style="WIDTH: 129px"></TD><TD style="WIDTH: 5px"></TD><TD style="WIDTH: 162px"><cc1:CalendarExtender id="CalendarExtender1" runat="server" __designer:wfdid="w35" TargetControlID="txtDeliveryDate" Enabled="False" PopupButtonID="ImageButton3"></cc1:CalendarExtender><cc1:MaskedEditExtender id="MaskedEditExtender1" runat="server" __designer:wfdid="w36" TargetControlID="txtDeliveryDate" Mask="99/99/9999" MaskType="Date">
                                                        </cc1:MaskedEditExtender></TD><TD style="WIDTH: 91px"></TD><TD style="WIDTH: 9px"></TD><TD style="WIDTH: 132px"><cc1:CalendarExtender id="CalendarExtender2" runat="server" __designer:wfdid="w37" TargetControlID="txtPOdate" Enabled="False" PopupButtonID="ImageButton1">
                                                            </cc1:CalendarExtender><cc1:MaskedEditExtender id="Maskededitextender2" runat="server" __designer:wfdid="w38" TargetControlID="txtPOdate" Mask="99/99/9999" MaskType="Date">
                                                        </cc1:MaskedEditExtender></TD><TD style="WIDTH: 115px"></TD><TD style="WIDTH: 14px"></TD><TD></TD></TR></TBODY></TABLE></FIELDSET></TD></TR><TR><TD style="WIDTH: 1000px" align=center><FIELDSET style="BORDER-RIGHT: #2977dc 1px solid; BORDER-TOP: #2977dc 1px solid; BORDER-LEFT: #2977dc 1px solid; WIDTH: 1000px; BORDER-BOTTOM: #2977dc 1px solid"><LEGEND><SPAN style="FONT-SIZE: 10pt; FONT-FAMILY: Arial"><STRONG><EM>LIST OF GOODS</EM></STRONG></SPAN></LEGEND><asp:MultiView id="mvGoods" runat="server" __designer:wfdid="w39"><asp:View id="vwGoods" runat="server" __designer:wfdid="w40"><asp:UpdatePanel id="UpdatePanel5" runat="server" __designer:wfdid="w41"><ContentTemplate>
<asp:Panel id="Panel2" runat="server" Width="990px" __designer:wfdid="w42" CssClass="PanelSize" ScrollBars="Vertical"><asp:GridView style="FONT-WEIGHT: normal" id="gvGoods" runat="server" Width="98%" __designer:wfdid="w43" OnSelectedIndexChanged="gvGoods_SelectedIndexChanged" SkinID="GridViewAA" AutoGenerateColumns="False" PageSize="20" HorizontalAlign="Center" OnPageIndexChanging="gvGoods_PageIndexChanging" ShowFooter="True"><Columns>
<asp:TemplateField HeaderText="Description"><EditItemTemplate>
&nbsp; 
</EditItemTemplate>
<FooterTemplate>
&nbsp;
</FooterTemplate>
<ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbldesc" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unit"><EditItemTemplate>
&nbsp; 
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lblunit" runat="server" Text='<%# bind("Unit") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Quantity"><EditItemTemplate>
&nbsp; 
</EditItemTemplate>
<ItemTemplate>
<asp:Label style="TEXT-ALIGN: center" id="lblqty" runat="server" Text='<%# bind("Quantity") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Price"><EditItemTemplate>
&nbsp; 
</EditItemTemplate>
<FooterTemplate>
<STRONG>TOTAL :</STRONG>
</FooterTemplate>
<ItemTemplate>
<asp:TextBox style="TEXT-ALIGN: right" id="txtcost" runat="server" Width="120px" Text='<%# bind("UnitPrice","{0:N}") %>' ReadOnly="True" OnTextChanged="txtcost_TextChanged"></asp:TextBox> 
</ItemTemplate>

<FooterStyle HorizontalAlign="Right"></FooterStyle>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Total Amount"><EditItemTemplate>
    &nbsp;
</EditItemTemplate>
<FooterTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbltotal" runat="server" Width="100px" CssClass="text" Text='<%# Bind("total", "{0:N}") %>'></asp:Label> 
</FooterTemplate>
<ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbltotal" runat="server" Text='<%# Bind("Total", "{0:N}") %>'></asp:Label> 
</ItemTemplate>

<FooterStyle HorizontalAlign="Right" Wrap="True" Font-Bold="False"></FooterStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField HeaderText="Remarks" Visible="False">
<HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Wrap="True"></ItemStyle>
</asp:BoundField>
<asp:TemplateField><EditItemTemplate>
&nbsp; 
</EditItemTemplate>
<ItemTemplate>
<asp:Button id="btnDetail" runat="server" Text="+" EnableTheming="True"></asp:Button> <asp:Panel style="DISPLAY: none" id="pnlDetail" runat="server" Width="400px" BorderWidth="2px" BorderColor="#FFA016" BorderStyle="Solid" BackColor="White"><TABLE style="WIDTH: 100%; TEXT-ALIGN: center"><TBODY><TR><TD style="WIDTH: 100%"><asp:TextBox id="txtremarks" runat="server" Width="98%" CssClass="text" Text='<%# bind("remarks") %>' Height="150px" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100%"><asp:Button id="Button6" runat="server" Width="100px" Text="OK"></asp:Button></TD></TR></TBODY></TABLE></asp:Panel> <cc1:ModalPopupExtender id="ModalPopupExtender2" runat="server" TargetControlID="btnDetail" BackgroundCssClass="modalBackground" PopupControlID="pnlDetail" DynamicServicePath="" CancelControlID="Button6">
                                                                </cc1:ModalPopupExtender> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" Font-Names="Arial" Font-Size="8pt" ForeColor="White"></HeaderStyle>
</asp:GridView></asp:Panel> 
</ContentTemplate>
</asp:UpdatePanel> <BR /></asp:View> <asp:View id="vwGasoline" runat="server" __designer:wfdid="w44"><asp:GridView id="gvProject" runat="server" Width="100%" __designer:wfdid="w45" SkinID="GridViewAA" AutoGenerateColumns="False" ShowFooter="True" UseAccessibleHeader="False"><Columns>
<asp:TemplateField HeaderText="Description"><ItemTemplate>
                                                                <asp:Label ID="lblTitle" runat="server" Text='<%# CheckIfTitleExists(Eval("rc_name").ToString()) %>'></asp:Label>
                                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Item_Desc") %>'></asp:Label>
                                                            
</ItemTemplate>

<ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="Qty" HeaderText="Quantity">
<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Description" HeaderText="Unit">
<FooterStyle HorizontalAlign="Right"></FooterStyle>

<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Amount"><EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                            
</EditItemTemplate>
<ItemTemplate>
                                                                <asp:Label ID="lblTitle2" runat="server" Text='<%# CheckIfTitleExists2(Eval("rc_name").ToString()) %>'></asp:Label><asp:Label
                                                                    ID="Label4" runat="server" Text='<%# Eval("total", "{0:N}") %>'></asp:Label>
                                                            
</ItemTemplate>

<FooterStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False"></FooterStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView></asp:View></asp:MultiView></FIELDSET></TD></TR><TR><TD style="WIDTH: 1000px" align=center><TABLE style="WIDTH: 100%" id="tb_approvedby" runat="server" Visible="false"><TBODY><TR><TD style="WIDTH: 10%" class="column_RightBold">Approved by : </TD><TD style="WIDTH: 90%" class="text5"><asp:DropDownList id="ddApprovedBy" runat="server" Width="300px" __designer:wfdid="w46" CssClass="txtboxinspection" AutoPostBack="True" OnSelectedIndexChanged="ddApprovedBy_SelectedIndexChanged"></asp:DropDownList></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 1000px" align=center><asp:Button id="btnsave" onclick="btnsave_Click" runat="server" Width="200px" __designer:wfdid="w47" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button><asp:Button id="btnReturn" onclick="btnReturn_Click" runat="server" Width="200px" __designer:wfdid="w48" Text="RETURN" OnClientClick="StartProgressBar();" Enabled="False"></asp:Button><asp:Button id="btnpreview" onclick="btnpreview_Click" runat="server" Width="200px" __designer:wfdid="w49" Text="PREVIEW"></asp:Button><cc1:ConfirmButtonExtender id="ConfirmButtonExtender5" runat="server" __designer:wfdid="w50" TargetControlID="btnReturn" ConfirmText="Are you sure you want to return this transaction in abstract approval?"></cc1:ConfirmButtonExtender></TD></TR><TR><TD style="WIDTH: 1000px" align=center><asp:MultiView id="mvAttchDoc" runat="server" __designer:wfdid="w51"><asp:View id="vwAttchDoc" runat="server" __designer:wfdid="w52"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 100%" class="DivTitle">Document Attachment</TD></TR><TR><TD style="WIDTH: 100%"><TABLE style="HEIGHT: 236px" width=1000><TBODY><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 704px; HEIGHT: 161px" align=right><FIELDSET style="BORDER-RIGHT: #2977dc 1px solid; BORDER-TOP: #2977dc 1px solid; BORDER-LEFT: #2977dc 1px solid; WIDTH: 700px; BORDER-BOTTOM: #2977dc 1px solid; HEIGHT: 163px"><LEGEND><SPAN style="FONT-SIZE: 10pt"><STRONG><EM>DOCUMENTS DETAILS</EM></STRONG></SPAN></LEGEND><TABLE class="text" width=700><TBODY><TR><TD style="HEIGHT: 29px"></TD><TD style="WIDTH: 230px"><asp:HiddenField id="hdfbuilding" runat="server" __designer:wfdid="w53"></asp:HiddenField><INPUT style="DISPLAY: none" id="flbuilding" type=file onchange="Handlechange();" name="fileupload" /><INPUT style="WIDTH: 147px; HEIGHT: 29px" id="btnBuildingBrowse" onclick="HandleBrowseClick();" type=submit value="Browse" runat="server" OnServerClick="btnBuildingBrowse_ServerClick" /></TD><TD style="WIDTH: 105px; HEIGHT: 29px" align=right>Validated By:</TD><TD style="HEIGHT: 29px"><asp:TextBox id="txtvalidatedby" runat="server" Width="200px" __designer:wfdid="w54"></asp:TextBox> <cc1:CalendarExtender id="CalendarExtender3" runat="server" __designer:wfdid="w55" TargetControlID="txtdatevalidated" PopupPosition="BottomRight"></cc1:CalendarExtender> </TD><TD></TD></TR><TR><TD style="WIDTH: 117px" align=right>Document Name:</TD><TD style="WIDTH: 230px"><asp:TextBox id="txtDocumentname" runat="server" Width="230px" __designer:wfdid="w56"></asp:TextBox></TD><TD style="WIDTH: 105px" align=right>Date Validated:</TD><TD style="WIDTH: 217px"><asp:TextBox id="txtdatevalidated" runat="server" Width="200px" __designer:wfdid="w57"></asp:TextBox></TD><TD></TD></TR><TR><TD style="WIDTH: 117px; HEIGHT: 18px" align=right>Document No.:</TD><TD style="WIDTH: 230px"><asp:TextBox id="txtdocumentno" runat="server" Width="230px" __designer:wfdid="w58"></asp:TextBox></TD><TD style="WIDTH: 105px; HEIGHT: 18px" align=right>Remarks:</TD><TD style="WIDTH: 217px" rowSpan=2><asp:TextBox id="txtdocremarks" runat="server" Width="200px" __designer:wfdid="w59" Height="37px" TextMode="MultiLine"></asp:TextBox></TD><TD style="HEIGHT: 18px"></TD></TR><TR><TD style="WIDTH: 117px; HEIGHT: 18px"></TD><TD style="WIDTH: 230px"></TD><TD style="WIDTH: 105px; HEIGHT: 18px"></TD><TD style="HEIGHT: 18px"></TD></TR><TR><TD style="HEIGHT: 18px" align=center colSpan=4><asp:Button id="btnAddlist" onclick="btnAddlist_Click1" runat="server" Width="122px" __designer:wfdid="w60" Text="Add To List"></asp:Button> <asp:Button id="btnCancel" runat="server" Width="122px" __designer:wfdid="w61" Text="Cancel"></asp:Button></TD><TD style="HEIGHT: 18px"></TD></TR></TBODY></TABLE></FIELDSET> </TD><TD style="VERTICAL-ALIGN: top; WIDTH: 250px" align=center rowSpan=2><FIELDSET style="BORDER-RIGHT: #2977dc 1px solid; BORDER-TOP: #2977dc 1px solid; BORDER-LEFT: #2977dc 1px solid; WIDTH: 252px; BORDER-BOTTOM: #2977dc 1px solid; HEIGHT: 340px"><LEGEND>ATTACHED DOCUMENTS</LEGEND><asp:Image id="imgPOAttachDoc" runat="server" Width="228px" ImageUrl="~/images/blankImage.jpg" __designer:wfdid="w62" Height="291px"></asp:Image></FIELDSET> </TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 704px; HEIGHT: 154px" align=right><asp:GridView id="grdocumentdetails" runat="server" Width="700px" __designer:wfdid="w63" OnSelectedIndexChanged="grdocumentdetails_SelectedIndexChanged" SkinID="GridView" DataKeyNames="IdentityNo,DocuId" Height="170px" PageSize="5" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1px"><Columns>
<asp:BoundField DataField="DocumentName" HeaderText="Document Name">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DocumentNo" HeaderText="Document No.">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ValidatedBy" HeaderText="Validated By">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DateValidated" HeaderText="Date Validated">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Remarks" HeaderText="Remarks">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></asp:View></asp:MultiView></TD></TR></TBODY></TABLE><asp:Panel style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #0033cc; BORDER-BOTTOM-WIDTH: 1px; BORDER-BOTTOM-COLOR: #0033cc; BORDER-TOP-COLOR: #0033cc; POSITION: relative; BACKGROUND-COLOR: transparent; TEXT-ALIGN: center; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #0033cc" id="PanelProgress" runat="server" Width="109px" __designer:wfdid="w64">
                <img src="../images/ajax-loader.gif" /></asp:Panel> <cc1:ModalPopupExtender id="ProgressBarModalPopupExtender" runat="server" __designer:wfdid="w65" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender> <asp:Button style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; POSITION: relative; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none" id="ButtonProgress" runat="server" Width="16px" __designer:wfdid="w66" Enabled="False"></asp:Button> 
</contenttemplate>
 </asp:UpdatePanel>
 
</asp:Content>
