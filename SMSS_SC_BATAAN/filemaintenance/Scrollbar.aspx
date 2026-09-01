<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Scrollbar.aspx.vb" 
Inherits="filemaintenance_Scrollbar" title="SCROLL BAR" StylesheetTheme="SkinFile" EnableEventValidation="false" MaintainScrollPositionOnPostback ="true"%>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript">     
private void ScrollGrid()
{
    int intScrollTo = this.gridView.SelectedIndex * (int)this.gridView.RowStyle.Height.Value;
    string strScript = string.Empty;
    strScript += "var gridView = document.getElementById('" + this.gridView.ClientID + "');\n";
    strScript += "if (gridView != null && gridView.parentElement != null && gridView.parentElement.parentElement != null)\n";
    strScript += "  gridView.parentElement.parentElement.scrollTop = " + intScrollTo + ";\n";
    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "ScrollGrid", strScript, true);
}

   
</script>



<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   

<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>


<TABLE style="WIDTH: 1010px"><TBODY><TR><TD style="WIDTH: 1010px"><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 1000px"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 50%" class="column_RightBold">SELECTED : </TD><TD style="WIDTH: 50%" class="text5"><asp:Label id="Label1" runat="server"></asp:Label></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 1000px"><asp:Panel id="Panel1" runat="server" Width="90%" ScrollBars="Vertical" CssClass="PanelSize">

<asp:GridView style="FONT-WEIGHT: normal" EnableCallBacks="False" id="grdSB" runat="server" Width="98%" DataKeyNames="RC_Name" PageSize="5" AutoGenerateColumns="False" OnSelectedIndexChanged="grdBAC_SelectedIndexChanged" EmptyDataText="No Data Found" SkinID="GridViewGL" BorderStyle="Solid"><Columns>

<asp:CommandField ShowSelectButton="True">
<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:CommandField>
<asp:BoundField DataField="RC_Name" HeaderText="OFFICE">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Function_desc" HeaderText="FUNCTION">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Office_Code" HeaderText="OFFICE CODE">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#2977DC"></FooterStyle>

<HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
</asp:GridView></asp:Panel></TD></TR><TR><TD style="WIDTH: 1000px"></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>
</asp:Content>

