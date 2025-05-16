<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" 
CodeFile="frm_TreasurersCollection.aspx.vb" Inherits="filemaintenance_frm_TreasurersCollection" 
title="FM Treasurers Collection" StylesheetTheme="skinfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<table width="1015px" style="text-align:center">
<tr>
<td width="1015px" style="text-align:center">


    <table class="PageTitle">
        <tr>
            <td style="width: 1000px">
                &nbsp;TREASURERS COLLECTION</td>
        </tr>
    </table>




 <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   

<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>
<TABLE style="WIDTH: 1016px" class="text"><TBODY><TR><TD style="HEIGHT: 21px"></TD><TD style="HEIGHT: 21px"></TD><TD style="HEIGHT: 21px"></TD></TR><TR><TD colSpan=3><asp:GridView id="grdListOfTransaction" runat="server" Width="850px" OnPageIndexChanging="grdListOfTransaction_PageIndexChanging" AllowPaging="True" SkinID="GridViewAA" HorizontalAlign="Center" DataKeyNames="pre_procurement_hdr_id,BidLocation,bid_docs,RefNumber,project_name" PageSize="8"><Columns>
<asp:CommandField ShowSelectButton="True">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:CommandField>
<asp:BoundField DataField="RefNumber" HeaderText="Reference Number">
<FooterStyle HorizontalAlign="Left"></FooterStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="BidLocation" HeaderText="Bid Location">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="opening_date" DataFormatString="{0:d}" HeaderText="Bid Opening Date">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TotalABC" DataFormatString="{0:N}" HeaderText="Total ABC">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView> <TABLE style="WIDTH: 996px"><TBODY><TR><TD style="WIDTH: 108px; HEIGHT: 21px"></TD><TD style="WIDTH: 16px; HEIGHT: 21px"></TD><TD style="HEIGHT: 21px"></TD><TD style="HEIGHT: 21px"></TD></TR><TR><TD style="WIDTH: 108px; HEIGHT: 18px">Project Name</TD><TD style="WIDTH: 16px; HEIGHT: 18px">:</TD><TD style="HEIGHT: 18px"><asp:Label id="lblProjectName" runat="server" Width="476px"></asp:Label></TD><TD style="HEIGHT: 18px"></TD></TR><TR><TD style="WIDTH: 108px; HEIGHT: 21px">Location</TD><TD style="WIDTH: 16px; HEIGHT: 21px">:</TD><TD style="HEIGHT: 21px"><asp:Label id="lbllocation" runat="server" Width="476px"></asp:Label></TD><TD style="HEIGHT: 21px"></TD></TR><TR><TD style="WIDTH: 108px; HEIGHT: 21px">Bid Document</TD><TD style="WIDTH: 16px; HEIGHT: 21px">:</TD><TD style="HEIGHT: 21px"><asp:Label id="lblBiddocument" runat="server" Width="476px"></asp:Label></TD><TD style="HEIGHT: 21px"></TD></TR><TR><TD style="WIDTH: 108px; HEIGHT: 21px">Bidder/Supplier</TD><TD style="WIDTH: 16px; HEIGHT: 21px">:</TD><TD style="HEIGHT: 21px"><asp:DropDownList id="drpSupplierList" runat="server" Width="481px" AutoPostBack="True" OnSelectedIndexChanged="drpSupplierList_SelectedIndexChanged" Enabled="False"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList><asp:TextBox id="txtSuppName" runat="server" Width="466px" CssClass="txtboxinspection" Visible="False" __designer:wfdid="w5"></asp:TextBox><asp:Button id="btnsupplier" runat="server" Width="185px" Enabled="False" Text="Select Bidder"></asp:Button><asp:Button id="btnNew" onclick="btnNew_Click" runat="server" Width="185px" __designer:wfdid="w4" Text="Add New Bidder"></asp:Button></TD><TD style="HEIGHT: 21px"></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="HEIGHT: 18px">List Of Suppliers</TD><TD style="HEIGHT: 18px"></TD><TD style="HEIGHT: 18px"></TD></TR><TR><TD style="HEIGHT: 18px"><asp:GridView id="grdListOfSupplier" runat="server" Width="600px" SkinID="GridViewAA" HorizontalAlign="Center" DataKeyNames="Supplier_ID" PageSize="5" AutoGenerateColumns="False" EmptyDataText="No Data Found"><Columns>
<asp:BoundField DataField="suppname" HeaderText="Supplier Name">
<ItemStyle HorizontalAlign="Left" Width="500px"></ItemStyle>
</asp:BoundField>
<asp:TemplateField><ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CommandArgument="Select" CommandName="Select">Remove</asp:LinkButton>
                            
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
</asp:TemplateField>
</Columns>
</asp:GridView> </TD><TD style="HEIGHT: 18px"></TD><TD style="HEIGHT: 18px"></TD></TR><TR><TD style="HEIGHT: 18px"></TD><TD style="HEIGHT: 18px"></TD><TD style="HEIGHT: 18px"></TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>   
</asp:Content>

