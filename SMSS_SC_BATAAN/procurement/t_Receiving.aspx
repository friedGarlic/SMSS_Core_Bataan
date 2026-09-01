<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false"
CodeFile="t_Receiving.aspx.vb" Inherits="procurement_t_Receiving" 
title="Receiving" StylesheetTheme="SkinFile"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager> 
<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>
<TABLE style="WIDTH: 1015px"><TBODY><TR><TD style="WIDTH: 1015px"><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 1000px"><TABLE class="PageTitle"><TBODY><TR><TD style="WIDTH: 1000px">RECEIVING</TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 1000px"><asp:GridView style="FONT-WEIGHT: normal" id="grdReceived" runat="server" Width="900px" OnRowDataBound="grdReceived_RowDataBound" AllowPaging="True" SkinID="GridViewAA" EmptyDataText="No Data Found" OnSelectedIndexChanged="grdReceived_SelectedIndexChanged" AutoGenerateColumns="False" PageSize="8" DataKeyNames="POHdr_ID,Supplier_ID,PO_No,GA_ID"><Columns>
<asp:BoundField DataField="PO_Date" DataFormatString="{0:d}" HeaderText="PO Date">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PO_No" HeaderText="PO Number">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SuppName" HeaderText="Supplier Name">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ContractPrice" DataFormatString="{0:N}" HeaderText="Total Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
</asp:GridView><BR /></TD></TR><TR><TD style="WIDTH: 1000px" class="DivTitle">GOODS</TD></TR><TR><TD style="WIDTH: 1000px"><asp:GridView style="FONT-WEIGHT: normal" id="grdGoods" runat="server" Width="1000px" AllowPaging="True" SkinID="GridViewAA" EmptyDataText="No Data Found" AutoGenerateColumns="False"><Columns>
<asp:TemplateField><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Description"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("Item_Desc") %>' id="TextBox2"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lblItem_Desc" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left" Width="500px"></ItemStyle>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Quantity">
        <EditItemTemplate>
            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:TextBox ID="txtQty" runat="server" CssClass="txtboxAmount" Text='<%# Bind("Quantity") %>'
                Width="120px"></asp:TextBox>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Width="150px" />
    </asp:TemplateField>
<asp:TemplateField HeaderText="Unit"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("Description") %>' id="TextBox3"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lblUnit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Price"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("price") %>' id="TextBox4"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lblPrice" runat="server" Text='<%# Bind("cost", "{0:N}") %>'></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="150px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Item_ID" Visible="False"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("Item_ID") %>' id="TextBox5"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lblItem_ID" runat="server" Text='<%# Bind("Item_ID") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
</asp:GridView><BR /></TD></TR><TR><TD style="VERTICAL-ALIGN: middle; WIDTH: 1000px"><SPAN style="FONT-SIZE: 10pt"><TABLE style="FONT-WEIGHT: bold; WIDTH: 100%; FONT-FAMILY: Arial"><TBODY><TR><TD style="WIDTH: 20%" class="column_RightBold">Date Receive :</TD><TD style="WIDTH: 80%" class="text5"><asp:TextBox id="txtDateReceive" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox><asp:ImageButton id="ImageButton2" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton><asp:Label id="Label1" runat="server" Font-Size="8pt" Text="(mm/dd/yyyy)"></asp:Label></TD></TR><TR><TD style="WIDTH: 20%" class="column_RightBold">Receive By :</TD><TD style="WIDTH: 80%" class="text5"><asp:DropDownList id="ddReceiveBy" runat="server" Width="400px" OnSelectedIndexChanged="ddReceiveBy_SelectedIndexChanged" CssClass="txtboxinspection" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 20%; vertical-align: middle;" class="column_RightBold">
    Delivery :</TD><TD style="WIDTH: 80%" class="text5">
    <asp:RadioButtonList ID="rbChoice" runat="server" AutoPostBack="True" CssClass="text5"
        OnSelectedIndexChanged="rbChoice_SelectedIndexChanged" RepeatDirection="Horizontal"
        Width="200px">
        <asp:ListItem Value="1">Partial</asp:ListItem>
        <asp:ListItem Value="2">Complete</asp:ListItem>
    </asp:RadioButtonList></TD></TR><TR><TD style="WIDTH: 20%" class="column_RightBold"></TD><TD style="WIDTH: 80%" class="text5"><asp:Button id="btnReceive" onclick="btnReceive_Click" runat="server" Width="200px" Height="30px" Text="RECEIVE"></asp:Button><asp:Button id="btnPreview" runat="server" Width="200px" Height="30px" Text="PREVIEW" Enabled="False" OnClick="btnPreview_Click"></asp:Button></TD></TR></TBODY></TABLE></SPAN><cc1:CalendarExtender id="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtDateReceive" PopupButtonID="ImageButton2"></cc1:CalendarExtender></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>
</asp:Content>

