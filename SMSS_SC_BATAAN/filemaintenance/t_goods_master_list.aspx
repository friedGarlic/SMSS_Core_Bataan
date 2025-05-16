<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_goods_master_list.aspx.vb" 
Inherits="filemaintenance_t_goods_master_list" title="FM MASTER LIST OF GOODS" StylesheetTheme="SkinFile" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   

<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>
    <table style="width: 1010px">
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" style="width: 1000px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" class="PageTitle" style="width: 1000px">
                MASTER LIST</td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" style="width: 1000px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" style="width: 1000px">
                <table style="width: 90%">
                    <tr>
                        <td class="column_RightBold" style="width: 20%">
                            Allotment Type :
                        </td>
                        <td class="text5" style="width: 80%">
                            <asp:RadioButtonList id="RadioButtonList1" runat="server" Width="200px" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True" Value="1">MOOE</asp:ListItem>
<asp:ListItem Value="2">Capital Outlay</asp:ListItem>
</asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td class="column_RightBold" style="width: 20%">
                            Categories :
                        </td>
                        <td class="text5" style="width: 80%">
                            <asp:DropDownList id="ddCategories" runat="server" Width="400px" OnSelectedIndexChanged="ddCategories_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="column_RightBold" style="width: 20%">
                            <asp:DropDownList id="ddSearch" runat="server" Width="120px"><asp:ListItem Selected="True" Value="1">Description</asp:ListItem>
<asp:ListItem Value="2">Item Code</asp:ListItem>
</asp:DropDownList>: 
                        </td>
                        <td class="text5" style="width: 80%">
                            <asp:TextBox id="txtSearch" runat="server" Width="350px" CssClass="txtboxinspection"></asp:TextBox><asp:Button id="btnsearch" runat="server" Width="150px" Text="SEARCH" CssClass="CSButton"></asp:Button></td>
                    </tr>
                    <tr>
                        <td class="column_RightBold" style="width: 20%">
                        </td>
                        <td class="text5" style="width: 80%">
                        </td>
                    </tr>
                    <tr>
                        <td class="column_RightBold" style="width: 20%">
                        </td>
                        <td class="text5" style="width: 80%">
                            <asp:Button id="btnPreview" onclick="btnPreview_Click" runat="server" Width="200px" Text="Generate Report" CssClass="CSButton"></asp:Button></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" class="DivTitle" style="width: 1000px">
                &nbsp;<asp:Label id="lblAccntCode" runat="server" Font-Bold="True" Font-Size="11pt" Font-Names="Arial"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" style="width: 1000px">


<asp:GridView id="gvstock" runat="server" Width="95%" PageSize="30" SkinID="GridViewAA" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Data Found." Font-Size="9pt"><Columns>
<asp:BoundField DataField="No" HeaderText="No.">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ItemCode" HeaderText="Item Code">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Item_Desc" HeaderText="DESCRIPTION">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="65%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="unit_desc" HeaderText="UNIT">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="price" DataFormatString="{0:N}" HeaderText="PRICE" HtmlEncode="False">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" style="width: 1000px">
                <asp:Panel id="Panel1" runat="server" Width="98%" GroupingText="SEARCH CRITERIA" CssClass="text" Visible="False"><asp:RadioButtonList id="rb" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="0">Like</asp:ListItem>
            <asp:ListItem Value="1">Contains</asp:ListItem>
        </asp:RadioButtonList></asp:Panel> <asp:Panel style="TEXT-ALIGN: left" id="Panel222" runat="server" Width="98%" GroupingText="SEARCH" CssClass="text" Visible="False"><asp:Button id="Button1" runat="server" Width="100px" Text="REFRESH" Visible="False"></asp:Button></asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" style="width: 1000px">
            </td>
        </tr>
    </table>
</contenttemplate>
</asp:UpdatePanel>
</asp:Content>

