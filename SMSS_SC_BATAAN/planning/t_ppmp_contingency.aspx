<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false"
CodeFile="t_ppmp_contingency.aspx.vb" Inherits="planning_t_ppmp_contingency" 
title="PPMP - Contingency" StylesheetTheme="SkinFile"%>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>  
<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>
<TABLE style="WIDTH: 1015px"><TBODY><TR><TD style="WIDTH: 100px"><TABLE style="WIDTH: 1000px"><TBODY><TR><TD colSpan=4><TABLE class="PageTitle" __designer:dtid="562949953421317"><TBODY><TR __designer:dtid="562949953421318"><TD style="WIDTH: 1000px" __designer:dtid="562949953421319">CONTINGENCY PPMP</TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 5%" class="column_LeftBold"></TD><TD style="WIDTH: 15%" class="column_LeftBold"></TD><TD style="WIDTH: 2%" class="column_LeftBold"></TD><TD style="WIDTH: 78%" class="text5"></TD></TR><TR><TD style="WIDTH: 5%" class="column_LeftBold"></TD><TD style="WIDTH: 15%" class="column_LeftBold">Year</TD><TD style="WIDTH: 2%" class="column_LeftBold">:</TD><TD style="WIDTH: 78%" class="text5"><asp:DropDownList id="ddYear" runat="server" Width="150px" OnSelectedIndexChanged="ddYear_SelectedIndexChanged" AutoPostBack="True" CssClass="txtboxinspection" __designer:wfdid="w3"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <STRONG><SPAN style="FONT-SIZE: 9pt">Date :</SPAN></STRONG> <asp:TextBox id="txtDate" runat="server" Width="100px" CssClass="txtboxinspection" __designer:wfdid="w10"></asp:TextBox><STRONG></STRONG><asp:ImageButton id="ImageButton2" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" __designer:wfdid="w11" Height="15px"></asp:ImageButton><STRONG><SPAN style="FONT-SIZE: 8pt; VERTICAL-ALIGN: middle; FONT-FAMILY: Calibri">(mm/dd/yyyy)</SPAN></STRONG></TD></TR><TR><TD style="WIDTH: 5%" class="column_LeftBold"></TD><TD style="WIDTH: 15%" class="column_LeftBold">Department</TD><TD style="WIDTH: 2%" class="column_LeftBold">:</TD><TD style="WIDTH: 78%" class="text5"><asp:DropDownList id="ddDepartment" runat="server" Width="550px" OnSelectedIndexChanged="ddDepartment_SelectedIndexChanged" AutoPostBack="True" CssClass="txtboxinspection" __designer:wfdid="w4" Enabled="False"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 5%" class="column_LeftBold"></TD><TD style="WIDTH: 15%" class="column_LeftBold">Function</TD><TD style="WIDTH: 2%" class="column_LeftBold">:</TD><TD style="WIDTH: 78%" class="text5"><asp:DropDownList id="ddFunction" runat="server" Width="550px" OnSelectedIndexChanged="ddFunction_SelectedIndexChanged" AutoPostBack="True" CssClass="txtboxinspection" __designer:wfdid="w7" Enabled="False"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 5%" class="column_LeftBold"></TD><TD style="WIDTH: 15%" class="column_LeftBold"></TD><TD style="WIDTH: 2%" class="column_LeftBold"></TD><TD style="WIDTH: 78%" class="text5"></TD></TR><TR><TD style="WIDTH: 5%" class="column_LeftBold"></TD><TD style="WIDTH: 15%" class="column_LeftBold"></TD><TD style="WIDTH: 2%" class="column_LeftBold"></TD><TD style="WIDTH: 78%" class="text5"><asp:RadioButtonList id="rbChoice" runat="server" Width="200px" __designer:dtid="562949953421333" OnSelectedIndexChanged="rbChoice_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w9" Enabled="False" RepeatDirection="Horizontal"><asp:ListItem Value="2" __designer:dtid="562949953421335">MOOE</asp:ListItem>
<asp:ListItem Value="3">Capital Outlay</asp:ListItem>
</asp:RadioButtonList></TD></TR><TR><TD style="WIDTH: 5%" class="column_LeftBold"></TD><TD style="WIDTH: 15%" class="column_LeftBold">Account Code</TD><TD style="WIDTH: 2%" class="column_LeftBold">:</TD><TD style="WIDTH: 78%" class="text5"><asp:DropDownList id="ddAccounts" runat="server" Width="550px" OnSelectedIndexChanged="ddAccounts_SelectedIndexChanged" AutoPostBack="True" CssClass="txtboxinspection" __designer:wfdid="w8" Enabled="False"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 5%" class="column_LeftBold"></TD><TD style="WIDTH: 15%" class="column_LeftBold">Appropriate Budget</TD><TD style="WIDTH: 2%" class="column_LeftBold">:</TD><TD style="WIDTH: 78%" class="text5"><asp:TextBox id="txtApprovedBudget" runat="server" Width="150px" CssClass="txtboxAmount" __designer:wfdid="w36" ReadOnly="True">0.00</asp:TextBox></TD></TR><TR><TD style="WIDTH: 5%" class="column_LeftBold"></TD><TD style="WIDTH: 15%" class="column_LeftBold">Prepared By</TD><TD style="WIDTH: 2%" class="column_LeftBold">:</TD><TD style="WIDTH: 78%" class="text5"><asp:DropDownList id="ddPreparedBy" runat="server" Width="300px" OnSelectedIndexChanged="ddPreparedBy_SelectedIndexChanged" AutoPostBack="True" CssClass="txtboxinspection" __designer:wfdid="w10" Enabled="False"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 5%" class="column_LeftBold"></TD><TD style="WIDTH: 15%" class="column_LeftBold">Reviewed By</TD><TD style="WIDTH: 2%" class="column_LeftBold">:</TD><TD style="WIDTH: 78%" class="text5"><asp:TextBox id="txtReviewedBy" runat="server" Width="295px" CssClass="txtboxinspection" __designer:wfdid="w1" ReadOnly="True"></asp:TextBox> <asp:DropDownList id="ddReviewedBy" runat="server" Width="300px" OnSelectedIndexChanged="ddReviewedBy_SelectedIndexChanged" AutoPostBack="True" CssClass="txtboxinspection" __designer:wfdid="w2" Enabled="False" Visible="False"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 5%" class="column_LeftBold"></TD><TD style="WIDTH: 15%" class="column_LeftBold"></TD><TD style="WIDTH: 2%" class="column_LeftBold"></TD><TD style="WIDTH: 78%" class="text5"><cc1:CalendarExtender id="CalendarExtender5" runat="server" __designer:wfdid="w12" Enabled="True" PopupButtonID="ImageButton2" TargetControlID="txtDate"></cc1:CalendarExtender></TD></TR><TR><TD class="DivTitle" colSpan=4>Budget Information</TD></TR><TR><TD colSpan=4><asp:GridView style="FONT-WEIGHT: normal; TEXT-ALIGN: justify" id="grdPPMP" runat="server" Width="800px" __designer:wfdid="w13" SkinID="GridViewAA" AutoGenerateColumns="False" PageSize="1"><Columns>
<asp:TemplateField HeaderText="1st Quarter"><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txt1st" runat="server" Width="120px" __designer:wfdid="w13" CssClass="txtboxAmount" AutoPostBack="True" OnTextChanged="txt1st_TextChanged" Text='<%# bind("1st","{0:N}") %>'></asp:TextBox> <cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" __designer:wfdid="w25" TargetControlID="txt1st" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="2nd Quarter"><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox2"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txt2nd" runat="server" Width="120px" __designer:wfdid="w15" CssClass="txtboxAmount" AutoPostBack="True" OnTextChanged="txt2nd_TextChanged" Text='<%# bind("2nd","{0:N}") %>'></asp:TextBox> <cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender2" runat="server" __designer:wfdid="w27" TargetControlID="txt2nd" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="3rd Quarter"><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox3"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txt3rd" runat="server" Width="120px" __designer:wfdid="w17" CssClass="txtboxAmount" AutoPostBack="True" OnTextChanged="txt3rd_TextChanged" Text='<%# bind("3rd","{0:N}") %>'></asp:TextBox> <cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender3" runat="server" __designer:wfdid="w29" TargetControlID="txt3rd" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="4th Quarter"><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox4"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txt4th" runat="server" Width="120px" __designer:wfdid="w19" CssClass="txtboxAmount" AutoPostBack="True" OnTextChanged="txt4th_TextChanged" Text='<%# bind("4th","{0:N}") %>'></asp:TextBox> <cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender4" runat="server" __designer:wfdid="w31" TargetControlID="txt4th" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Total Amount"><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox5"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lblTotal" runat="server" __designer:wfdid="w23" Text='<%# bind("Total","{0:N}") %>'></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="200px"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView><BR /></TD></TR><TR><TD colSpan=4><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="200px" __designer:wfdid="w4" Height="30px" Enabled="False" Text="SAVE"></asp:Button><asp:Button id="btnPreview" onclick="btnPreview_Click" runat="server" Width="200px" __designer:wfdid="w5" Height="30px" Enabled="False" Visible="False" Text="PREVIEW"></asp:Button><BR /><BR /></TD></TR><TR><TD class="DivTitle" colSpan=4>PPMP Contingency</TD></TR><TR><TD colSpan=4><asp:GridView style="FONT-WEIGHT: normal; TEXT-ALIGN: justify" id="grdContingency" runat="server" Width="1000px" __designer:wfdid="w13" SkinID="GridViewAA" AutoGenerateColumns="False" PageSize="1" EmptyDataText="No Data Found."><Columns>
<asp:BoundField DataField="GA_Title2" HeaderText="Account Code">
<ItemStyle HorizontalAlign="Left" Width="400px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="FirstQtr" DataFormatString="{0:N}" HeaderText="First Quarter">
<ItemStyle HorizontalAlign="Right" Width="120px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SecondQtr" DataFormatString="{0:N}" HeaderText="Second Quarter">
<ItemStyle HorizontalAlign="Right" Width="120px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ThirdQtr" DataFormatString="{0:N}" HeaderText="Third Quarter">
<ItemStyle HorizontalAlign="Right" Width="120px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="FourthQtr" DataFormatString="{0:N}" HeaderText="Fourth Quarter">
<ItemStyle HorizontalAlign="Right" Width="120px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TotalAmount" DataFormatString="{0:N}" HeaderText="Total Amount">
<ItemStyle HorizontalAlign="Right" Width="120px"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView></TD></TR></TBODY></TABLE>&nbsp;&nbsp; </TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>
</asp:Content>

