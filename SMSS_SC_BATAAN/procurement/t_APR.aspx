<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" 
CodeFile="t_APR.aspx.vb" Inherits="procurement_t_APR" title="Agency Procurement Request" StylesheetTheme ="SkinFile"  %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   

<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>
<TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 1000px" align=center><TABLE class="PageTitle" __designer:dtid="562949953421313"><TBODY><TR __designer:dtid="562949953421314"><TD style="WIDTH: 1000px" __designer:dtid="562949953421315">AGENCY PROCUREMENT REQUEST</TD></TR></TBODY></TABLE><BR /></TD></TR><TR><TD style="WIDTH: 1000px" align=center><asp:Panel id="Panel1" runat="server" Width="800px" BorderWidth="1px" BorderStyle="Solid" BorderColor="Silver"><TABLE style="WIDTH: 800px"><TBODY><TR><TD style="WIDTH: 50px" class="text5"></TD><TD style="WIDTH: 150px" class="text5">Year</TD><TD style="WIDTH: 10px" class="text5">:</TD><TD style="WIDTH: 590px" class="text5"><asp:DropDownList id="ddYear" runat="server" Width="150px" AutoPostBack="True" CssClass="txtboxinspection">
                                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 50px" class="text5"></TD><TD style="WIDTH: 150px" class="text5">Allotment Type</TD><TD style="WIDTH: 10px" class="text5">:</TD><TD style="WIDTH: 590px" class="text5"><asp:DropDownList id="ddAllotment" runat="server" Width="150px" __designer:wfdid="w3" Enabled="False" AutoPostBack="True" CssClass="txtboxinspection" OnSelectedIndexChanged="ddAllotment_SelectedIndexChanged"><asp:ListItem Value="1">Select</asp:ListItem>
<asp:ListItem Value="2">MOOE</asp:ListItem>
<asp:ListItem Value="3">Capital Outlay</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 50px" class="text5"></TD><TD style="WIDTH: 150px" class="text5">Account</TD><TD style="WIDTH: 10px" class="text5">:</TD><TD style="WIDTH: 590px" class="text5"><asp:DropDownList id="ddAccount" runat="server" Width="500px" __designer:wfdid="w2" Enabled="False" AutoPostBack="True" CssClass="txtboxinspection" OnSelectedIndexChanged="ddAccount_SelectedIndexChanged"></asp:DropDownList></TD></TR></TBODY></TABLE></asp:Panel><BR /></TD></TR><TR><TD style="WIDTH: 1000px" align=center><TABLE style="LEFT: 0px; WIDTH: 100%; TOP: 0px" id="tblppmp" class="strip"><TBODY><TR align=center><TD style="WIDTH: 1000px; HEIGHT: 16px; TEXT-ALIGN: left"><STRONG>LIST OF ITEMS</STRONG></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 1000px" align=center><asp:Panel id="Panel2" runat="server" Width="1000px" BorderWidth="1px" BorderStyle="Solid" BorderColor="Silver" Height="600px" ScrollBars="Vertical" __designer:wfdid="w8"><asp:GridView style="FONT-WEIGHT: normal" id="gvItems" runat="server" Width="900px" BorderStyle="Solid" EmptyDataText="No Data Found" AutoGenerateColumns="False" PageSize="5" SkinID="GridViewGL" __designer:wfdid="w9"><Columns>
<asp:BoundField DataField="Item_Desc" HeaderText="Item Description">
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="600px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TQty" HeaderText="Quantity">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="unitcost" HeaderText="Price">
<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="150px"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView></asp:Panel></TD></TR><TR><TD style="WIDTH: 1000px; HEIGHT: 26px" align=center><asp:Button id="btnPreview" onclick="btnPreview_Click" runat="server" Width="200px" Height="30px" __designer:wfdid="w1" Enabled="False" Text="PREVIEW"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Width="200px" Height="30px" __designer:wfdid="w2" Text="CANCEL"></asp:Button></TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel> 

</asp:Content>

