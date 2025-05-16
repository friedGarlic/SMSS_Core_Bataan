<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_rpt_PRS.aspx.vb" 
Inherits="Reports_and_Query_t_rpt_PRS" title="Property Return Slip" StylesheetTheme ="SkinFile"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:ScriptManager id="ScriptManager1" runat="server">
</asp:ScriptManager>

<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 10px" align=center></TD><TD style="WIDTH: 1000px" class="PageTitle" align=center>PROPERTY RETURN SLIP</TD></TR><TR><TD style="WIDTH: 10px" align=center></TD><TD style="WIDTH: 1000px" align=center></TD></TR><TR><TD style="WIDTH: 10px" align=center></TD><TD style="WIDTH: 1000px" align=center><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 150px" class="column_RightBold">Search :</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 250px" class="text5"><asp:RadioButtonList id="rbChoice" runat="server" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="rbChoice_SelectedIndexChanged"><asp:ListItem Selected="True" Value="1">Responsibility Center</asp:ListItem>
<asp:ListItem Value="2">Employee</asp:ListItem>
<asp:ListItem Value="3">Date (Duration)</asp:ListItem>
</asp:RadioButtonList> </TD><TD style="VERTICAL-ALIGN: top; WIDTH: 600px" class="text5"><asp:MultiView id="mvCategory" runat="server" __designer:wfdid="w92"><asp:View id="vwRC" runat="server" __designer:wfdid="w93"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 15%" class="column_RightBold">Department&nbsp;:</TD><TD style="WIDTH: 60%"><asp:DropDownList id="ddDepartment" runat="server" Width="95%" AutoPostBack="True" OnSelectedIndexChanged="ddDepartment_SelectedIndexChanged" CssClass="txtboxinspection" __designer:wfdid="w94"></asp:DropDownList></TD><TD style="WIDTH: 25%"></TD></TR><TR><TD style="WIDTH: 15%" class="column_RightBold">Function&nbsp; :</TD><TD style="WIDTH: 60%"><asp:DropDownList id="ddFunction" runat="server" Width="95%" AutoPostBack="True" CssClass="txtboxinspection" __designer:wfdid="w95"></asp:DropDownList></TD><TD style="WIDTH: 25%"></TD></TR><TR><TD style="WIDTH: 15%" class="column_RightBold"></TD><TD style="WIDTH: 60%"><asp:Button id="btnRC" onclick="btnRC_Click" runat="server" Width="150px" CssClass="CSButton" Text="Search" __designer:wfdid="w96"></asp:Button></TD><TD style="WIDTH: 25%"></TD></TR></TBODY></TABLE></asp:View> <asp:View id="vwEmployee" runat="server" __designer:wfdid="w97"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 15%" class="column_RightBold">Employee :</TD><TD style="WIDTH: 60%"><asp:TextBox id="txtEmployee" runat="server" Width="95%" CssClass="txtboxinspection" __designer:wfdid="w98"></asp:TextBox></TD><TD style="WIDTH: 25%"><asp:Button id="btnEmployee" onclick="btnEmployee_Click" runat="server" Width="90%" CssClass="CSButton" Text="Search" __designer:wfdid="w99"></asp:Button></TD></TR></TBODY></TABLE></asp:View><BR /><asp:View id="vwDate" runat="server" __designer:wfdid="w100"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 15%" class="column_RightBold">From&nbsp;:</TD><TD style="WIDTH: 85%"><asp:TextBox id="txtFrom" runat="server" Width="200px" CssClass="txtboxinspection" __designer:wfdid="w101"></asp:TextBox><asp:ImageButton id="image1" runat="server" Width="25px" ImageUrl="~/images/Calendar_scheduleHS.png" Enabled="true" Height="17px" __designer:wfdid="w102"></asp:ImageButton><SPAN style="FONT-SIZE: 9pt; FONT-FAMILY: Arial"><STRONG>(mm/dd/yyyy)</STRONG></SPAN></TD></TR><TR><TD style="WIDTH: 15%" class="column_RightBold">To :</TD><TD style="WIDTH: 40%"><asp:TextBox id="txtTo" runat="server" Width="200px" CssClass="txtboxinspection" __designer:wfdid="w103"></asp:TextBox><asp:ImageButton id="Image2" runat="server" Width="25px" ImageUrl="~/images/Calendar_scheduleHS.png" Enabled="true" Height="17px" __designer:wfdid="w104"></asp:ImageButton> <STRONG><SPAN style="FONT-SIZE: 9pt; FONT-FAMILY: Arial">(mm/dd/yyyy)</SPAN></STRONG></TD></TR><TR><TD style="WIDTH: 15%" class="column_RightBold"></TD><TD style="WIDTH: 40%"><asp:Button id="btnDate" onclick="btnDate_Click" runat="server" Width="150px" CssClass="CSButton" Text="Search" __designer:wfdid="w105"></asp:Button></TD></TR></TBODY></TABLE></asp:View></asp:MultiView></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 10px" align=center></TD><TD style="WIDTH: 1000px" align=center><asp:GridView id="grdPRS" runat="server" Width="95%" Font-Size="9pt" OnSelectedIndexChanged="grdPRS_SelectedIndexChanged" DataKeyNames="Returned_ID" AutoGenerateColumns="False" SkinID="GridViewAA" EmptyDataText="NO DATA FOUND"><Columns>
<asp:TemplateField ShowHeader="False"><ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" CausesValidation="False" Text="Preview" Font-Underline="False" CommandName="Select" __designer:wfdid="w106"></asp:LinkButton> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="ReturnedBy" HeaderText="Returned By">
<ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RC_Name" HeaderText="Department">
<ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Returned_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Returned Date">
<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView> </TD></TR><TR><TD style="WIDTH: 10px" align=center></TD><TD style="WIDTH: 1000px" align=center><cc1:calendarextender id="CalendarExtender1" runat="server" popupbuttonid="Image1" targetcontrolid="txtFrom" __designer:wfdid="w90"></cc1:calendarextender><cc1:calendarextender id="Calendarextender2" runat="server" popupbuttonid="Image2" targetcontrolid="txtTo" __designer:wfdid="w91"></cc1:calendarextender></TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>
</asp:Content>

