<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" 
CodeFile="t_purchase_request_gasoline.aspx.vb" Inherits="procurement_t_purchase_request_gasoline" 
title="PR Gasoline" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager> 
  
<script type="text/javascript">
      // It is important to place this JavaScript code after ScriptManager1
      var xPos, yPos;
      var prm = Sys.WebForms.PageRequestManager.getInstance();
      function BeginRequestHandler(sender, args) 
      {
        if ($get('<%=PanelMain.ClientID%>') != null) {
          // Get X and Y positions of scrollbar before the partial postback
          xPos = $get('<%=PanelMain.ClientID%>').scrollLeft;
          yPos = $get('<%=PanelMain.ClientID%>').scrollTop;
        }
     }
  
     function EndRequestHandler(sender, args) 
     {
         if ($get('<%=PanelMain.ClientID%>') != null) {
           // Set X and Y positions back to the scrollbar
           // after partial postback
           $get('<%=PanelMain.ClientID%>').scrollLeft = xPos;
           $get('<%=PanelMain.ClientID%>').scrollTop = yPos;
         }
     }

      prm.add_beginRequest(BeginRequestHandler);
      prm.add_endRequest(EndRequestHandler);
     
     
 </script>
 
   
 <script type="text/javascript">
      // It is important to place this JavaScript code after ScriptManager1
      var xPos, yPos;
      var prm = Sys.WebForms.PageRequestManager.getInstance();
      function BeginRequestHandler(sender, args) 
      {
        if ($get('<%=PanelItems.ClientID%>') != null) {
          // Get X and Y positions of scrollbar before the partial postback
          xPos = $get('<%=PanelItems.ClientID%>').scrollLeft;
          yPos = $get('<%=PanelItems.ClientID%>').scrollTop;
        }
     }
  
     function EndRequestHandler(sender, args) 
     {
         if ($get('<%=PanelItems.ClientID%>') != null) {
           // Set X and Y positions back to the scrollbar
           // after partial postback
           $get('<%=PanelItems.ClientID%>').scrollLeft = xPos;
           $get('<%=PanelItems.ClientID%>').scrollTop = yPos;
         }
     }

      prm.add_beginRequest(BeginRequestHandler);
     prm.add_endRequest(EndRequestHandler);
     
     
 </script>
 

 <script type="text/javascript">
      // It is important to place this JavaScript code after ScriptManager1
      var xPos, yPos;
      var prm = Sys.WebForms.PageRequestManager.getInstance();
      function BeginRequestHandler(sender, args) 
      {
        if ($get('<%=Panel9.ClientID%>') != null) {
          // Get X and Y positions of scrollbar before the partial postback
          xPos = $get('<%=Panel9.ClientID%>').scrollLeft;
          yPos = $get('<%=Panel9.ClientID%>').scrollTop;
        }
     }
  
     function EndRequestHandler(sender, args) 
     {
         if ($get('<%=Panel9.ClientID%>') != null) {
           // Set X and Y positions back to the scrollbar
           // after partial postback
           $get('<%=Panel9.ClientID%>').scrollLeft = xPos;
           $get('<%=Panel9.ClientID%>').scrollTop = yPos;
         }
     }

      prm.add_beginRequest(BeginRequestHandler);
     prm.add_endRequest(EndRequestHandler);
     
     
 </script>
 
 
 
<asp:UpdatePanel id="UpdatePanel11" runat="server">   
<contenttemplate>
<asp:Panel id="PanelMain" runat="server" __designer:wfdid="w13"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 1000px" align=center></TD></TR><TR><TD style="WIDTH: 1000px" class="PageTitle" align=center>CREATE PURCHASE REQUEST - GASOLINE</TD></TR><TR><TD style="WIDTH: 1000px" align=center><asp:DropDownList id="ddOffice" runat="server" Width="500px" __designer:wfdid="w14" AutoPostBack="True" AppendDataBoundItems="True" Visible="False">
                                </asp:DropDownList><asp:CheckBox id="cbVarious" runat="server" __designer:wfdid="w15" AutoPostBack="True" Visible="False" Text="Various"></asp:CheckBox></TD></TR><TR><TD style="WIDTH: 1000px" align=center><SPAN style="FONT-SIZE: 11pt; FONT-FAMILY: Calibri">PERIOD :<%-- <asp:TextBox id="txtPeriod" runat="server" Width="176px" __designer:wfdid="w16" CssClass="txtboxinspection"></asp:TextBox>--%><asp:DropdownList id="DdPeriod" runat="server" Width="176px" __designer:wfdid="w16" CssClass="txtboxinspection"></asp:DropdownList><asp:LinkButton id="lbPeriod" runat="server" __designer:wfdid="w17" Font-Underline="False">Create New Period</asp:LinkButton></SPAN></TD></TR><TR style="COLOR: #000000"><TD style="WIDTH: 1000px" align=left>
<cc1:TabContainer style="VERTICAL-ALIGN: top" id="TabContainer1" runat="server" Width="100%" __designer:wfdid="w18" AutoPostBack="True" ActiveTabIndex="0">
<cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
<HeaderTemplate>Offices</HeaderTemplate>
<ContentTemplate>
<asp:Panel id="PanelOffice" runat="server" Width="100%" __designer:wfdid="w3" Height="200px" ScrollBars="Vertical"><asp:GridView id="GVoffices" runat="server" Width="100%" __designer:wfdid="w4" CssClass="text" SkinID="GridViewAA" DataKeyNames="Office_ID,Function_ID,RC_Name" UseAccessibleHeader="False" PageSize="8"><Columns>
<asp:CommandField ShowSelectButton="True">
<ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
</asp:CommandField>
<asp:BoundField DataField="Rc_name" HeaderText="Department">
<HeaderStyle CssClass="text"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="80%"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView> </asp:Panel> &nbsp;&nbsp; 
</ContentTemplate>
</cc1:TabPanel>
<cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2" Visible="false">
<HeaderTemplate><%--Various Offices--%></HeaderTemplate>
<ContentTemplate>
<asp:Panel id="PanelVOffice" runat="server" Width="98%" __designer:wfdid="w3" Height="250px" ScrollBars="Vertical"><asp:GridView runat="server" DataKeyNames="Office_ID,Function_ID,RC_Name" PageSize="8" UseAccessibleHeader="False" CssClass="text" SkinID="GridViewAA" Width="100%" ID="GVvarious" __designer:wfdid="w4"><Columns>
<asp:CommandField ShowSelectButton="True">
<ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
</asp:CommandField>
<asp:BoundField DataField="Rc_name" HeaderText="Department">
<HeaderStyle CssClass="text"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="80%"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView>
</asp:Panel> <BR /> 
</ContentTemplate>
</cc1:TabPanel>
</cc1:TabContainer></TD></TR><TR><TD style="WIDTH: 1000px" class="text5" align=center></TD></TR><TR><TD style="WIDTH: 1000px" class="text5" align=center>Invoice Number : <asp:TextBox accessKey="2" style="TEXT-ALIGN: left" id="txtInvoiceNumber" runat="server" Width="150px" Font-Bold="True" __designer:wfdid="w22" AutoPostBack="True" CssClass="txtboxinspection"></asp:TextBox>SOA # <asp:TextBox style="TEXT-ALIGN: left" id="txtSOA" runat="server" Width="150px" Font-Bold="True" __designer:wfdid="w23" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 1000px" class="text5" align=center>Selected&nbsp;Office / Department&nbsp;: <asp:TextBox id="txtDepartment" runat="server" Width="350px" Font-Bold="True"  __designer:wfdid="w24" CssClass="txtbox_Amt" ReadOnly="True"></asp:TextBox>Available Amount : <asp:Textbox id="txtReleaseAmount"  runat="server" Width="150px" CssClass="txtbox_Amt" Font-Bold="True" __designer:wfdid="w25"></asp:Textbox> <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789.," TargetControlID="txtReleaseAmount">
                                        </cc1:FilteredTextBoxExtender></TD></TR><TR><TD style="WIDTH: 1000px" align=center><cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender3" runat="server" __designer:wfdid="w1" TargetControlID="txtInvoiceNumber" FilterType="Numbers">
                                </cc1:FilteredTextBoxExtender><cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender8" runat="server" __designer:wfdid="w2" TargetControlID="txtSOA" FilterType="Numbers">
                                </cc1:FilteredTextBoxExtender></TD></TR><TR><TD style="WIDTH: 1000px" class="DivTitle" align=center>INVOICE</TD></TR><TR><TD style="WIDTH: 1000px" align=center><asp:UpdatePanel id="UpdatePanel6" runat="server" __designer:wfdid="w46"><ContentTemplate>
<asp:Panel id="Panel4" runat="server" __designer:wfdid="w47"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; WIDTH: 50%; BORDER-BOTTOM: gray 1px solid" align=center><asp:UpdatePanel id="UpdatePanel2" runat="server" __designer:wfdid="w36"><ContentTemplate>
<asp:Panel id="PanelItems" runat="server" Width="100%" __designer:wfdid="w38" CssClass="text" Height="320px" ScrollBars="Both">
    <asp:GridView id="gvitems" runat="server" Width="97%" __designer:wfdid="w39"  SkinID="GridViewAA" 
        DataKeyNames="AllotmentClass_ID,Item_Desc,Description,Item_id,id,cost,qty,GA_ID,BGA_ID" UseAccessibleHeader="False" OnPageIndexChanging="gvitems_PageIndexChanging1" OnSelectedIndexChanged="gvitems_SelectedIndexChanged"><Columns>
<asp:CommandField SelectText="Select" ShowSelectButton="True">
<ItemStyle HorizontalAlign="Center" Width="20%">
</ItemStyle>
</asp:CommandField>
<asp:BoundField DataField="Item_Desc" HeaderText="Description">
<ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Description" HeaderText="Unit">
<ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Item_id">
<ItemStyle Width="10px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="id" HeaderText="id"></asp:BoundField>
<asp:BoundField DataField="cost" DataFormatString="{0:N}" HeaderText="Cost" HtmlEncode="False"></asp:BoundField>
<asp:BoundField DataField="qty" HeaderText="qty"></asp:BoundField>
<asp:BoundField DataField="GA_ID" HeaderText="GA_ID"></asp:BoundField>
<asp:BoundField DataField="BGA_ID" HeaderText="BGA_ID"></asp:BoundField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView></asp:Panel> 
</ContentTemplate>
</asp:UpdatePanel> </TD><TD style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; WIDTH: 50%; BORDER-BOTTOM: gray 1px solid" align=center><asp:UpdatePanel id="UpdatePanel4" runat="server" __designer:wfdid="w37"><ContentTemplate>
<asp:Panel id="Panel9" runat="server" Width="100%" __designer:wfdid="w40" Height="310px" ScrollBars="Vertical">
    <asp:GridView style="FONT-WEIGHT: normal" id="gvInvoice" runat="server" Width="100%" __designer:wfdid="w41" HorizontalAlign="Right" SkinID="GridViewGL" AutoGenerateColumns="False" ShowFooter="True" 
        DataKeyNames="id,Item_Desc,Description,qty,Item_ID,cost,GA_ID,BGA_ID,rows_id" >
<Columns>

<asp:BoundField DataField="Item_Desc" HeaderText="Description">
<ItemStyle HorizontalAlign="Left" Width="45%"></ItemStyle>
</asp:BoundField>

<asp:TemplateField HeaderText="Quantity"><EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" __designer:wfdid="w42"></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox style="TEXT-ALIGN: right" id="txtqty" runat="server" Width="98%" __designer:wfdid="w30" Text='<%# bind("qty") %>' Visible='<%# bind("isVisible") %>' AutoPostBack="True" OnTextChanged="txtqty_TextChanged"></asp:TextBox> <cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" __designer:wfdid="w31" TargetControlID="txtqty" ValidChars="0123456789.">
</cc1:FilteredTextBoxExtender> 
</ItemTemplate>
<ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
</asp:TemplateField>


<asp:TemplateField HeaderText="Total">
<EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w19"></asp:TextBox> 
</EditItemTemplate>

<ItemTemplate>
<asp:TextBox style="TEXT-ALIGN: right" id="txtprice" runat="server" Width="98%" __designer:wfdid="w28" Text='<%# bind("cost", "{0:N}") %>' Visible='<%# bind("isVisible") %>' AutoPostBack="True" OnTextChanged="txtprice_TextChanged"></asp:TextBox><cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender2" runat="server" __designer:wfdid="w29" TargetControlID="txtprice" ValidChars="0123456789,.">
</cc1:FilteredTextBoxExtender> 
</ItemTemplate>
<FooterStyle HorizontalAlign="Right"></FooterStyle>
<ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
</asp:TemplateField>

 <asp:TemplateField >
<ItemTemplate>
 <asp:LinkButton ID="lnkReturnGF" runat="server" CssClass="LinkBtnCancel" CommandName="Select" Font-Underline="False" OnRowDeleting="OnRowDeleting" Visible='<%#Bind("isVisible") %>'>Return</asp:LinkButton>
 </ItemTemplate>
 <ItemStyle HorizontalAlign="Center" Width="6%"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView> </asp:Panel>
</ContentTemplate>
</asp:UpdatePanel> <cc1:ConfirmButtonExtender id="ConfirmButtonExtender3" runat="server" __designer:wfdid="w54" TargetControlID="btnSave" ConfirmText="Are you sure you want to save  this transaction?"></cc1:ConfirmButtonExtender> <asp:Button accessKey="1" style="LEFT: 0px; POSITION: relative" id="btnCreate" runat="server" Width="200px" __designer:wfdid="w55" Visible="False" Text="CREATE INVOICE"></asp:Button><asp:Button style="LEFT: 0px; POSITION: relative" id="btnSave" runat="server" Width="200px" CausesValidation="False" __designer:wfdid="w56" Enabled="False" Text="SAVE INVOICE" OnClientClick="StartProgressBar();"></asp:Button></TD></TR></TBODY></TABLE></asp:Panel> 
</ContentTemplate>
</asp:UpdatePanel></TD></TR><TR><TD style="WIDTH: 1000px" class="DivTitle" align=center>SUMMARY</TD></TR><TR><TD style="WIDTH: 1000px" align=left><TABLE style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; WIDTH: 100%; BORDER-BOTTOM: gray 1px solid"><TBODY><TR><TD style="WIDTH: 60%" align=center><SPAN style="FONT-FAMILY: Calibri"><STRONG>SUMMARY</STRONG></SPAN></TD><TD style="WIDTH: 40%" align=center><SPAN style="FONT-FAMILY: Calibri"><STRONG>SUMMARY SOA</STRONG></SPAN></TD></TR><TR><TD style="WIDTH: 60%" align=center><asp:GridView style="FONT-WEIGHT: normal" id="gvSummary" runat="server" Width="95%" __designer:wfdid="w8" EmptyDataText="No Data Found." ShowFooter="True" AutoGenerateColumns="False" SkinID="GridViewAA"><Columns>
<asp:TemplateField HeaderText="Office" ShowHeader="False"><ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" CausesValidation="False" __designer:wfdid="w5" Text='<%# bind("rc_name") %>' Font-Underline="False" CommandName="Select"></asp:LinkButton> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left" Width="80%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="total" DataFormatString="{0:N}" HeaderText="Amount">
<FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView></TD><TD style="WIDTH: 40%" align=center><asp:GridView style="FONT-WEIGHT: normal" id="gvSOA" runat="server" Width="95%" __designer:wfdid="w7" EmptyDataText="No Data Found." ShowFooter="True" AutoGenerateColumns="False" SkinID="GridViewGL"><Columns>
<asp:BoundField DataField="SOA_No" HeaderText="SOA No.">
<ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Amount" DataFormatString="{0:N}" HeaderText="Amount">
<FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="50%"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 1000px" class="DivTitle" align=center>LIST OF INVOICE</TD></TR><TR style="FONT-SIZE: 12pt"><TD style="WIDTH: 1000px" align=center><asp:GridView style="FONT-WEIGHT: normal" id="gvTotal" runat="server" Width="100%" __designer:wfdid="w10" EmptyDataText="No Data Found." ShowFooter="True" AutoGenerateColumns="False" SkinID="GridViewAA" DataKeyNames="pr_invoice_hdr_id,rc_ID,Function_ID,rc_name,Invoice_No,SOA_No"><Columns>
<asp:TemplateField HeaderText="Edit" ShowHeader="False"><ItemTemplate>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Select"
                                                OnClick="LinkButton2_Click" Text="Edit"></asp:LinkButton>
                                        
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Cancel" ShowHeader="False"><ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                OnClick="LinkButton1_Click1" Text="Cancel"></asp:LinkButton>
                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to cancel the invoice no.?"
                                                TargetControlID="LinkButton1">
                                            </cc1:ConfirmButtonExtender>
                                        
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="SOA_No" HeaderText="SOA #">
<ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Invoice_No" HeaderText="Invoice #">
<ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="rc_name" HeaderText="Office">
<ItemStyle HorizontalAlign="Left" Width="45%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="total" DataFormatString="{0:N}" HeaderText="Amount">
<FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView></TD></TR><TR style="FONT-SIZE: 12pt"><TD style="WIDTH: 1000px" align=center></TD></TR><TR style="FONT-SIZE: 12pt"><TD style="WIDTH: 1000px" align=center><asp:Button id="btncheck" runat="server" CssClass="CSButton" Width="220px" __designer:wfdid="w11" Text="VIEW SUMMARY"></asp:Button><asp:Button id="Button5" runat="server" CssClass="CSButton" Width="220px" __designer:wfdid="w12" Text="VIEW DETAILED">
                                                                                                                                                                                                                                                                                       </asp:Button><asp:Button id="btnCreatePR" runat="server" CssClass="CSButton" Width="220px" __designer:wfdid="w13" Text="CREATE PURCHASE REQUEST" OnClientClick="StartProgressBar();"></asp:Button>
<asp:Button id="btnPreview" runat="server" Width="220px" __designer:wfdid="w14" Text="PREVIEW"></asp:Button>
<cc1:ConfirmButtonExtender id="ConfirmButtonExtender2" runat="server" __designer:wfdid="w15" TargetControlID="btnCreatePR" ConfirmText="Are you sure you want to save  this transaction?">
</cc1:ConfirmButtonExtender></TD></TR><TR style="FONT-SIZE: 12pt"><TD style="WIDTH: 1000px" align=center></TD></TR><TR style="FONT-SIZE: 12pt"><TD style="WIDTH: 1000px" class="DivTitle" align=center>SEARCH</TD></TR><TR style="FONT-SIZE: 12pt"><TD style="WIDTH: 1000px" align=center><STRONG><SPAN style="FONT-SIZE: 11pt; FONT-FAMILY: Calibri">MONTH : <asp:DropDownList id="Drpmonth" runat="server" Width="150px" __designer:wfdid="w16"><asp:ListItem Value="1">January</asp:ListItem>
<asp:ListItem Value="2">February</asp:ListItem>
<asp:ListItem Value="3">March</asp:ListItem>
<asp:ListItem Value="4">April</asp:ListItem>
<asp:ListItem Value="5">May</asp:ListItem>
<asp:ListItem Value="6">June</asp:ListItem>
<asp:ListItem Value="7">July</asp:ListItem>
<asp:ListItem Value="8">August</asp:ListItem>
<asp:ListItem Value="9">September</asp:ListItem>
<asp:ListItem Value="10">October</asp:ListItem>
<asp:ListItem Value="11">November</asp:ListItem>
<asp:ListItem Value="12">December</asp:ListItem>
</asp:DropDownList>YEAR : <asp:DropDownList id="Drpyear" runat="server" Width="150px" __designer:wfdid="w17"></asp:DropDownList><asp:Button id="btnview" runat="server" CssClass="CSButton" Width="120px" __designer:wfdid="w18" Text="View"></asp:Button></SPAN></STRONG></TD></TR><TR><TD style="WIDTH: 1000px" align=center><asp:GridView style="FONT-WEIGHT: normal" id="gvListPR" runat="server" Width="90%" __designer:wfdid="w19" EmptyDataText="No Data Found." AutoGenerateColumns="False" SkinID="GridViewAA" DataKeyNames="pr_period_key_id"><Columns>
<asp:BoundField DataField="pr_period_key_desc" HeaderText="Period">
<ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SuppName" HeaderText="Supplier">
<ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Report" ShowHeader="False"><ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                        Font-Underline="False"  Text="View" Width="20px"></asp:LinkButton>&nbsp;
                                
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView></TD></TR><TR><TD style="WIDTH: 1000px" align=center></TD></TR></TBODY></TABLE></asp:Panel><asp:Panel style="DISPLAY: none" id="popup" runat="server" Width="900px"><TABLE id="Table2" height=486 cellSpacing=0 cellPadding=0 width=747 border=0><TBODY><TR><TD colSpan=2><IMG height=1 alt="" src="../images/modalpopup_02.png" width=747 /></TD></TR><TR><TD style="BACKGROUND-IMAGE: url(../images/modalpopup_02.png); WIDTH: 772px; HEIGHT: 39px"></TD><TD style="WIDTH: 46px; HEIGHT: 39px"><asp:ImageButton id="ImageButton3" runat="server" ImageUrl="../images/modalpopup_03.png"></asp:ImageButton></TD></TR><TR><TD style="BACKGROUND-IMAGE: url(../images/modalpopup_04.png); VERTICAL-ALIGN: top; WIDTH: 772px" id="Td1"><TABLE style="WIDTH: 705px; HEIGHT: 336px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 4%; TEXT-ALIGN: center"></TD><TD style="VERTICAL-ALIGN: top; WIDTH: 100%; TEXT-ALIGN: center"><asp:GridView id="GridView1" runat="server" Width="99%" AutoGenerateColumns="False" SkinID="gvnew">
            <Columns>
                <asp:BoundField DataField="rc_name" HeaderText="Office" />
                <asp:BoundField DataField="amount" DataFormatString="{0:N}" HeaderText="Amount">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
                <HeaderStyle BackColor="#2977DC" ForeColor="White" />
                        <FooterStyle BackColor="#2977DC" />
        </asp:GridView> &nbsp; &nbsp;&nbsp; </TD></TR><TR><TD style="WIDTH: 4%; HEIGHT: 24px; TEXT-ALIGN: center"></TD><TD style="WIDTH: 100%; TEXT-ALIGN: center"></TD></TR></TBODY></TABLE><asp:Label id="Label8" runat="server"></asp:Label></TD><TD style="BACKGROUND-IMAGE: url(../images/modalpopup_05.png); WIDTH: 46px; HEIGHT: 446px"></TD></TR></TBODY></TABLE></asp:Panel> <cc1:ModalPopupExtender id="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground" CancelControlID="ImageButton3" PopupControlID="popup" TargetControlID="Label8">
    </cc1:ModalPopupExtender> <asp:Panel style="DISPLAY: none; TEXT-ALIGN: center" id="pnlMS" runat="server" Width="400px" BorderColor="#FFA016" BorderStyle="Solid" BorderWidth="2px" BackColor="White" HorizontalAlign="Center"><asp:UpdatePanel id="UpdatePanel1" runat="server"><ContentTemplate>
<TABLE style="WIDTH: 400px"><TBODY><TR><TD style="FONT-WEIGHT: bold; FONT-SIZE: 11pt; WIDTH: 400px; COLOR: white; FONT-FAMILY: Calibri; BACKGROUND-COLOR: #ffa016" align=center>PERIOD DATE</TD></TR><TR><TD style="FONT-WEIGHT: bold; FONT-SIZE: 11pt; WIDTH: 400px; FONT-FAMILY: Calibri" align=center>FROM : <asp:TextBox id="txtFrom" runat="server" Width="120px" __designer:wfdid="w27" OnTextChanged="txtFrom_TextChanged" ></asp:TextBox><asp:ImageButton id="btncal1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" __designer:wfdid="w28" Enabled="true" OnClientClick="checkDate"></asp:ImageButton>&nbsp;&nbsp;&nbsp; TO : <asp:TextBox id="txtTo" runat="server" Width="120px" __designer:wfdid="w29"></asp:TextBox><asp:ImageButton id="btnCal2" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" __designer:wfdid="w30" Enabled="true"></asp:ImageButton></TD></TR><TR><TD style="WIDTH: 400px" align=center>
<asp:RangeValidator id="RangeValidator1" runat="server" __designer:wfdid="w31" ValidationGroup="date" ControlToValidate="txtFrom" Display="Dynamic" ErrorMessage="Please enter proper date1" Type="Date">

</asp:RangeValidator><SPAN style="FONT-SIZE: 11pt; FONT-FAMILY: Calibri"></SPAN><asp:RangeValidator id="RangeValidator2" runat="server" __designer:wfdid="w32" ValidationGroup="period" ControlToValidate="txtTo"  Display="Dynamic" ErrorMessage="Please enter proper date" Type="Date" EnableTheming="True" >
                                                                                </asp:RangeValidator></TD></TR><TR><TD style="FONT-WEIGHT: bold; FONT-SIZE: 11pt; WIDTH: 400px; COLOR: white; FONT-FAMILY: Calibri; BACKGROUND-COLOR: #ffa016" align=center>SUPPLIER NAME</TD></TR><TR><TD style="WIDTH: 400px" align=center><asp:DropDownList id="ddSupplier" runat="server" Width="99%" __designer:wfdid="w33"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 400px" align=center>
<asp:Button id="Button6" runat="server" Width="120px" __designer:wfdid="w34" Text="OK" OnClientClick="StartProgressBar();" ValidationGroup="period"></asp:Button>
<asp:Button id="btncancel2" runat="server" Width="120px" __designer:wfdid="w35" Text="CANCEL"></asp:Button></TD></TR></TBODY></TABLE>
<cc1:CalendarExtender id="CalendarExtender1" runat="server" __designer:wfdid="w36" TargetControlID="txtFrom" PopupButtonID="btncal1">
                    </cc1:CalendarExtender>
<cc1:CalendarExtender id="CalendarExtender2" runat="server" __designer:wfdid="w37" TargetControlID="txtTo" PopupButtonID="btncal2">
                    </cc1:CalendarExtender> 
</ContentTemplate>
</asp:UpdatePanel> <asp:Label id="lbl_period_pop_up" runat="server" __designer:wfdid="w24"></asp:Label></asp:Panel> <cc1:ModalPopupExtender id="ModalPopupExtender4" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlMS" TargetControlID="lbl_period_pop_up">
    </cc1:ModalPopupExtender><asp:Panel style="DISPLAY: none; TEXT-ALIGN: center" id="pnl_pr_pop_up" runat="server" Width="217px" BorderColor="#FFA016" BorderStyle="Solid" BorderWidth="2px" BackColor="White"><TABLE style="WIDTH: 217px; TEXT-ALIGN: left" class="text" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="FONT-WEIGHT: bold; COLOR: white; HEIGHT: 16px; BACKGROUND-COLOR: #ffa016; TEXT-ALIGN: center" class="text" colSpan=3>Invoice Number</TD></TR><TR><TD colSpan=3><TABLE style="WIDTH: 213px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="HEIGHT: 21px" colSpan=4> </TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=4>&nbsp; </TD></TR><TR><TD style="WIDTH: 33px; HEIGHT: 18px"></TD><TD style="WIDTH: 24px; HEIGHT: 18px"></TD><TD style="WIDTH: 152px; HEIGHT: 18px"></TD><TD style="WIDTH: 31px"></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=4><asp:Button accessKey="3" id="btnOK" runat="server" Width="80px" Text="OK" ValidationGroup="ok"></asp:Button><asp:Button id="btnCancel" runat="server" Width="80px" Text="CANCEL"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>&nbsp; <asp:LinkButton id="LinkButton2" runat="server" ForeColor="Transparent" Enabled="False" Font-Underline="False">.</asp:LinkButton></asp:Panel> <%--   <asp:TextBox ID="T" runat="server"></asp:TextBox>
<asp:CompareValidator ID="CompareValidator1" runat="server"
ControlToValidate="T" ErrorMessage="CompareValidator"
Operator="GreaterThan" Type="Date"></asp:CompareValidator> 

<asp:Button ID="B" runat="server" Text="Button" />--%><cc1:ModalPopupExtender id="MP" runat="server" BackgroundCssClass="modalBackground" CancelControlID="btnCancel" PopupControlID="pnl_pr_pop_up" TargetControlID="LinkButton2">
    </cc1:ModalPopupExtender><asp:Panel style="DISPLAY: none" id="PopUP5" runat="server" Width="900px"><TABLE id="Table3" height=486 cellSpacing=0 cellPadding=0 width=747 border=0><TBODY><TR><TD colSpan=2><IMG height=1 alt="" src="../images/modalpopup_02.png" width=747 /></TD></TR><TR><TD style="BACKGROUND-IMAGE: url(../images/modalpopup_02.png); WIDTH: 772px; HEIGHT: 39px"></TD><TD style="WIDTH: 46px; HEIGHT: 39px"><asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../images/modalpopup_03.png" PostBackUrl="~/procurement/t_purchase_request_gasoline.aspx"></asp:ImageButton></TD></TR><TR><TD style="BACKGROUND-IMAGE: url(../images/modalpopup_04.png); VERTICAL-ALIGN: top; WIDTH: 772px; HEIGHT: 495px" id="Td2"><TABLE style="WIDTH: 705px; HEIGHT: 336px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 4%; HEIGHT: 432px; TEXT-ALIGN: center"></TD><TD style="VERTICAL-ALIGN: top; WIDTH: 100%; HEIGHT: 432px; TEXT-ALIGN: center"><asp:UpdatePanel id="UpdatePanel3" runat="server"><ContentTemplate>
<TABLE style="WIDTH: 671px; HEIGHT: 43px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:Label id="Label1" runat="server" Width="148px" Text="Starting Invoice No. :" CssClass="text"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:TextBox id="txtinvfrom" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 23px"></TD><TD style="WIDTH: 100px; HEIGHT: 23px"></TD><TD style="WIDTH: 100px; HEIGHT: 23px"></TD><TD style="WIDTH: 100px; HEIGHT: 23px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 24px"><asp:Label id="Label7" runat="server" Width="146px" Text="Ending Invoice No.        : " CssClass="text"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 24px"><asp:TextBox id="txtinvto" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 24px"><asp:Button id="Button4" onclick="Button4_Click" runat="server" Width="97px" Text="ADD"></asp:Button></TD><TD style="WIDTH: 100px; HEIGHT: 24px"></TD><TD style="WIDTH: 100px; HEIGHT: 24px"></TD><TD style="WIDTH: 100px; HEIGHT: 24px"></TD></TR></TBODY></TABLE><cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender4" runat="server" TargetControlID="txtinvfrom" FilterType="Numbers">
                                            </cc1:FilteredTextBoxExtender> <cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender5" runat="server" TargetControlID="txtinvto" FilterType="Numbers">
                                            </cc1:FilteredTextBoxExtender> <BR /><asp:GridView style="FONT-WEIGHT: normal" id="gvTotal1" runat="server" Width="99%" ShowFooter="True" AutoGenerateColumns="False" SkinID="gvnew" DataKeyNames="pr_invoice_hdr_id,rc_ID,Function_ID,Invoice_No,pr_invoice_dtl_id">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Hide">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="CB1" runat="server" AutoPostBack="True" OnCheckedChanged="CB1_CheckedChanged" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Invoice_No" HeaderText="Invoice No." />
                                                    <asp:BoundField DataField="Item_desc" HeaderText="Particulars" />
                                                    <asp:TemplateField HeaderText="Quantity">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            &nbsp;<asp:TextBox ID="txtqnty2" runat="server" Style="text-align: center" Width="67px" Text='<%#Bind("qty") %>' AutoPostBack="True" OnTextChanged="txtqnty2_TextChanged"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtqnty2"
                                                                ValidChars="1234567890.,">
                                                            </cc1:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("total") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtprice2" runat="server" OnTextChanged="TextBox6_TextChanged" Style="text-align: right"
                                                                Width="81px" Text='<%# bind("price") %>' AutoPostBack="True"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtprice2"
                                                                ValidChars="1234567890.,">
                                                            </cc1:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <FooterStyle Font-Bold="False" HorizontalAlign="Right" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                           <HeaderStyle BackColor="#2977DC" ForeColor="White" />
                        <FooterStyle BackColor="#2977DC" />
                                            </asp:GridView> 
</ContentTemplate>
</asp:UpdatePanel> &nbsp; &nbsp; </TD></TR><TR><TD style="WIDTH: 4%; HEIGHT: 24px; TEXT-ALIGN: center"></TD><TD style="WIDTH: 100%; HEIGHT: 24px; TEXT-ALIGN: center"><asp:Button id="Button2" runat="server" Width="150px" Visible="False" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button></TD></TR></TBODY></TABLE><asp:Button id="Button1" runat="server" BorderColor="Transparent" BorderStyle="None" BackColor="Transparent"></asp:Button></TD><TD style="BACKGROUND-IMAGE: url(../images/modalpopup_05.png); WIDTH: 46px; HEIGHT: 495px"></TD></TR></TBODY></TABLE><cc1:ModalPopupExtender id="ModalPopupExtender2" runat="server" BackgroundCssClass="modalBackground" CancelControlID="ImageButton1" PopupControlID="PopUP5" TargetControlID="Button1">
        </cc1:ModalPopupExtender></asp:Panel><BR /><asp:Panel style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #0033cc; BORDER-BOTTOM-WIDTH: 1px; BORDER-BOTTOM-COLOR: #0033cc; BORDER-TOP-COLOR: #0033cc; POSITION: relative; BACKGROUND-COLOR: transparent; TEXT-ALIGN: center; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #0033cc" id="PanelProgress" runat="server" Width="109px" __designer:wfdid="w1">
                <img src="../images/ajax-loader.gif" /></asp:Panel> <cc1:ModalPopupExtender id="ProgressBarModalPopupExtender" runat="server" __designer:wfdid="w2" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender> <asp:Button style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; POSITION: relative; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none" id="ButtonProgress" runat="server" Width="16px" __designer:wfdid="w3" Enabled="False"></asp:Button> 
</contenttemplate>
</asp:UpdatePanel>



</asp:Content>

