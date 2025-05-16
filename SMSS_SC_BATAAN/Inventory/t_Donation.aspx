<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_Donation.aspx.vb" Inherits="Inventory_t_Donation" title="Untitled Page" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 900px">
        <tr>
            <td colspan="9" style="text-align: left">
                <asp:Label ID="lblHeader" runat="server" Font-Bold="True" SkinID="pageheader" Style="text-align: left"
                    Text="DONATION"></asp:Label>
                <hr style="width: 98%" />
                <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager></td>
        </tr>
        <tr>
            <td colspan="9" style="height: 19px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="9" style="height: 96px">
                <asp:Panel ID="Panel2" runat="server" CssClass="text" Font-Bold="True" GroupingText="INFORMATION"
                    Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" style="font-weight: normal; width: 100%">
                        <tr>
                            <td style="height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fund &nbsp; &nbsp; &nbsp;&nbsp; :
                                <asp:DropDownList ID="drpfund" runat="server">
                                </asp:DropDownList>
                                Date Purchased :
                                <asp:TextBox ID="txtprdate" runat="server" CssClass="text" SkinID="text" Width="100px"></asp:TextBox><asp:ImageButton
                                    ID="ImageButton2" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" />
                                (MM/DD/YYYY) &nbsp; &nbsp; &nbsp;
                                <asp:Button ID="btnadd" runat="server" SkinID="ButtonImage" Text="ADD ITEMS" ValidationGroup="2"
                                    Width="100px" /></td>
                        </tr>
                        <tr>
                            <td>
                                Remarks&nbsp; :
                                <asp:TextBox ID="txtremarks" runat="server" Width="285px"></asp:TextBox></td>
                        </tr>
                    </table>
                    &nbsp;
                </asp:Panel>
                &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="9">
                <asp:Panel ID="Panel1" runat="server" CssClass="text" Font-Bold="True" GroupingText="CAPITAL OUTLAYS"
                    Style="vertical-align: top; text-align: left" Width="100%">
                    <asp:GridView ID="gvbody" runat="server" AutoGenerateColumns="False" CaptionAlign="Left"
                        DataKeyNames="Item_ID" PageSize="5" ShowFooter="True" SkinID="gvnew" Style="font-weight: normal"
                        Width="98%">
                        <Columns>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" class="text" style="width: 100%">
                                        <tr>
                                            <td style="width: 100px; text-align: center">
                                                Description</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbldesc" runat="server" CssClass="text" Style="text-align: left" Text='<%# Bind("Item_Desc") %>'
                                        Width="397px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" class="text" style="width: 100%">
                                        <tr>
                                            <td style="width: 100px; text-align: center">
                                                Unit</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblunit" runat="server" CssClass="text" Text='<%# Bind("Description") %>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" class="text" style="width: 100%">
                                        <tr>
                                            <td style="width: 100px; text-align: center">
                                                Quantity</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtqty" runat="server" AutoPostBack="True" CssClass="text" OnTextChanged="txtqty_TextChanged"
                                        SkinID="text" Style="text-align: right" Text='<%# Bind("Qty") %>' Width="80px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtqty" ValidChars="123456790">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Cost") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" class="text" style="width: 100%">
                                        <tr>
                                            <td style="width: 100px; text-align: center">
                                                Price</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtcost" runat="server" AutoPostBack="True" CssClass="text" 
                                        SkinID="text" Style="text-align: right" Text='<%# Bind("price", "{0:N}") %>'
                                        Width="80px" OnTextChanged="txtcost_TextChanged"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtcost" ValidChars="012345679.,">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="total" DataFormatString="{0:N}" HeaderText="Total Amount">
                                <FooterStyle Font-Bold="False" HorizontalAlign="Right" />
                                <HeaderStyle CssClass="text" HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle Font-Names="Arial" Font-Size="8pt" />
                    </asp:GridView>
                </asp:Panel>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="9">
            </td>
        </tr>
        <tr>
            <td colspan="9">
                <asp:Button ID="btnSave" runat="server" Enabled="False" EnableTheming="True" SkinID="ButtonImage"
                    Text="SAVE" ValidationGroup="save" Width="200px" /><asp:Button ID="btnpreview" runat="server"
                        Enabled="False" SkinID="ButtonImage" Text="PREVIEW" Width="200px" /></td>
        </tr>
    </table>
    <br />
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="popup"
        TargetControlID="btnadd">
    </cc1:ModalPopupExtender>
    <br />
    <asp:Panel ID="popup" runat="server" Style="display: none" Width="900px">
        <table id="Table_01" border="0" cellpadding="0" cellspacing="0" height="401" width="840">
            <tr>
                <td colspan="4">
                    <img alt="" height="5" src="../images/popupmenu/sms-popup_01.gif" width="840" /></td>
            </tr>
            <tr>
                <td colspan="2" style="background-image: url(../images/popupmenu/sms-popup_02.gif);
                    vertical-align: bottom; width: 753px; height: 35px">
                </td>
                <td style="width: 70px; height: 35px">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/popupmenu/sms-popup_03.gif" /></td>
                <td rowspan="3" style="width: 18px">
                    <img alt="" height="395" src="../images/popupmenu/sms-popup_04.gif" width="17" /></td>
            </tr>
            <tr>
                <td rowspan="2">
                    <img alt="" height="360" src="../images/popupmenu/sms-popup_05.gif" width="10" /></td>
                <td colspan="2" style="background-image: url(../images/popupmenu/sms-popup_06.gif);
                    vertical-align: top; width: 813px; height: 336px; text-align: left">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 813px; height: 336px">
                        <tr>
                            <td style="vertical-align: top; width: 100%; text-align: left">
                                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                                    <contenttemplate>
<TABLE style="WIDTH: 100%" class="text" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%" colSpan=3> Search: <asp:TextBox id="txtsearchitems" runat="server" Width="410px" CssClass="text" ></asp:TextBox><asp:Button id="btnSearch" runat="server" Text="SEARCH" Width="100px"></asp:Button></TD></TR></TBODY></TABLE><asp:GridView id="gvitems" runat="server" SkinID="gvnew" Width="100%" CssClass="text" PageSize="8" DataKeyNames="item_id" AllowPaging="True" ><Columns>
<asp:TemplateField><EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" __designer:wfdid="w7"></asp:TextBox> 
</EditItemTemplate>
<HeaderTemplate>
<asp:CheckBox id="CheckBox2" runat="server" Font-Bold="True" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" Text="All" Width="50px" __designer:wfdid="w8" OnCheckedChanged="CheckBox2_CheckedChanged" AutoPostBack="True"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="CheckBox1" runat="server" Width="50px" __designer:wfdid="w6"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Item_Desc" HeaderText="Description">
<HeaderStyle CssClass="text"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Description" HeaderText="Unit">
<HeaderStyle HorizontalAlign="Left" CssClass="text"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Item_id">
<ItemStyle Width="10px"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView> 
</contenttemplate>
                                </asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td style="width: 100%; text-align: center">
                                <asp:Button ID="Button4" runat="server" Font-Bold="False" SkinID="Button" Text="LOAD"
                                    Width="150px" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <img alt="" height="24" src="../images/popupmenu/sms-popup_07.gif" width="813" /></td>
            </tr>
            <tr>
                <td>
                    <img alt="" height="1" src="../images/popupmenu/spacer.gif" width="10" /></td>
                <td>
                    <img alt="" height="1" src="../images/popupmenu/spacer.gif" width="743" /></td>
                <td>
                    <img alt="" height="1" src="../images/popupmenu/spacer.gif" width="70" /></td>
                <td style="width: 18px">
                    <img alt="" height="1" src="../images/popupmenu/spacer.gif" width="17" /></td>
            </tr>
        </table>
    </asp:Panel>
    <br />
</asp:Content>

