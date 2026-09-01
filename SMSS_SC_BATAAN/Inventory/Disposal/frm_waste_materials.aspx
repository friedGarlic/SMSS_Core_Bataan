<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frm_waste_materials.aspx.vb" Inherits="Disposal_frm_waste_materials" title="Untitled Page" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 900px">
        <tr>
            <td colspan="9" style="text-align: left">
                <asp:Label ID="lblHeader" runat="server" Font-Bold="True" SkinID="pageheader" Style="text-align: left"
                    Text="WASTE MATERIALS"></asp:Label>
                <hr />
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 49px;">
            </td>
            <td style="text-align: right; height: 49px;" colspan="8">
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to save this transaction?"
                    TargetControlID="btnsave">
                </cc1:ConfirmButtonExtender>
                &nbsp;<asp:Button ID="btnnew" runat="server" SkinID="ButtonImage" Text="NEW" />
                <asp:Button ID="btnopen" runat="server" SkinID="ButtonImage" Text="OPEN" />
                <asp:Button ID="btnsave" runat="server" SkinID="ButtonImage" Text="SAVE" />
                <asp:Button ID="btnadd" runat="server" SkinID="ButtonImage" Text="ADD ITEM" />
                <asp:Button ID="btnpreview" runat="server" SkinID="ButtonImage" Text="PREVIEW" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                &nbsp;&nbsp;</td>
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
                <asp:Panel ID="Panel1" runat="server" CssClass="text" Font-Bold="True" GroupingText="INFORMATION"
                    Width="98%">
                    <table border="0" cellpadding="0" cellspacing="0" style="font-weight: normal; width: 100%">
                        <tr>
                            <td style="width: 148px">
                                Date</td>
                            <td style="width: 10px">
                                :</td>
                            <td colspan="7">
                                <asp:TextBox ID="txtdate" runat="server" SkinID="text" Width="100px"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdate"
                                    ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator>(MM/DD/YYYY)&nbsp;
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="ImageButton2"
                                    TargetControlID="txtdate">
                                </cc1:CalendarExtender>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                                    MaskType="Date" TargetControlID="txtdate">
                                </cc1:MaskedEditExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 148px">
                                Place of Storage</td>
                            <td style="width: 10px">
                                :</td>
                            <td colspan="7">
                                <asp:TextBox ID="txtpurpose" runat="server" CssClass="text" Height="40px" ReadOnly="True"
                                    SkinID="text" Style="text-align: left" TextMode="MultiLine" Width="487px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 148px">
                                Property Officer</td>
                            <td style="width: 10px">
                                :</td>
                            <td colspan="7">
                                <asp:TextBox ID="txtfrom" runat="server" CssClass="text" ReadOnly="True" Width="272px"></asp:TextBox></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 19px;">
            </td>
            <td style="width: 100px; height: 19px;">
                &nbsp;</td>
            <td style="width: 100px; height: 19px;">
            </td>
            <td style="width: 100px; height: 19px;">
            </td>
            <td style="width: 100px; height: 19px;">
            </td>
            <td style="width: 100px; height: 19px;">
            </td>
            <td style="width: 100px; height: 19px;">
            </td>
            <td style="width: 100px; height: 19px;">
            </td>
            <td style="width: 100px; height: 19px;">
            </td>
        </tr>
        <tr>
            <td colspan="9">
                <asp:Panel ID="Panel2" runat="server" CssClass="text" Font-Bold="True" GroupingText="SUPPLIES"
                    Width="98%">
                    <asp:GridView ID="gvbody" runat="server" AutoGenerateColumns="False"
                        SkinID="gvnew" Style="font-weight: normal" Width="98%">
                        <Columns>
                            <asp:BoundField DataField="Item_desc" HeaderText="Description" />
                            <asp:BoundField DataField="Description" HeaderText="Unit" />
                            <asp:TemplateField HeaderText="Quantity">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtqty" runat="server" Text='<%# bind("qty") %>' Width="50px" AutoPostBack="True" OnTextChanged="txtqty_TextChanged"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers"
                                        TargetControlID="txtqty">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mode of Disposal">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddmd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddmd_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">Public Auction</asp:ListItem>
                                        <asp:ListItem Value="2">Private Sale</asp:ListItem>
                                        <asp:ListItem Value="3">Destroyed</asp:ListItem>
                                        <asp:ListItem Value="4">Transferred without cost</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OR Number">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" AutoPostBack="True" OnTextChanged="TextBox6_TextChanged" Text='<%# bind("OR") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtamount" runat="server" Style="text-align: right" Width="120px" AutoPostBack="True" OnTextChanged="txtamount_TextChanged" Text='<%# bind("Amount","{0:N}") %>'></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtamount"
                                        ValidChars="0123456789.,">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DONEE">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox8" runat="server" AutoPostBack="True" OnTextChanged="TextBox8_TextChanged" Text='<%# bind("donee") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel><asp:Panel ID="Panel3" runat="server" CssClass="text" Font-Bold="True" GroupingText="SUPPLIES"
                    Width="98%">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                        SkinID="gvnew" Style="font-weight: normal" Width="98%">
                        <Columns>
                            <asp:BoundField DataField="Item_desc" HeaderText="Description" />
                            <asp:BoundField DataField="Description" HeaderText="Unit" />
                            <asp:TemplateField HeaderText="Quantity">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtqty" runat="server" AutoPostBack="True" OnTextChanged="txtqty_TextChanged"
                                        Text='<%# bind("qty") %>' Width="50px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers"
                                        TargetControlID="txtqty">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mode of Disposal">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddmd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddmd_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">Public Auction</asp:ListItem>
                                        <asp:ListItem Value="2">Private Sale</asp:ListItem>
                                        <asp:ListItem Value="3">Destroyed</asp:ListItem>
                                        <asp:ListItem Value="4">Transferred without cost</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OR Number">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" AutoPostBack="True" OnTextChanged="TextBox6_TextChanged"
                                        Text='<%# bind("OR") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtamount" runat="server" AutoPostBack="True" OnTextChanged="txtamount_TextChanged"
                                        Style="text-align: right" Text='<%# bind("Amount","{0:N}") %>' Width="120px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtamount"
                                        ValidChars="0123456789.,">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DONEE">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox8" runat="server" AutoPostBack="True" OnTextChanged="TextBox8_TextChanged"
                                        Text='<%# bind("donee") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
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
    </table>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
        CancelControlID="ImageButton1" PopupControlID="popup" TargetControlID="btnadd">
    </cc1:ModalPopupExtender>
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
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" class="text" style="width: 100%">
                                            <tbody>
                                                <tr>
                                                    <td colspan="3" style="width: 100%">
                                                        Search:<asp:TextBox ID="txtSearch" runat="server" CssClass="text" Width="410px"></asp:TextBox><asp:Button
                                                            ID="btnSearch" runat="server" OnClick="btnSearch_Click1" Text="SEARCH" Width="100px" /></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <asp:GridView ID="gvitems" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            CssClass="text" PageSize="8" SkinID="gvnew"
                                            Width="100%">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Font-Bold="True"
                                                            Font-Names="tahoma" Font-Size="10pt" ForeColor="White" OnCheckedChanged="CheckBox2_CheckedChanged"
                                                            Text="All" Width="50px" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" Width="50px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Item_desc" HeaderText="Description" />
                                                <asp:BoundField DataField="Description" HeaderText="Unit" />
                                                <asp:BoundField HeaderText="Quantity" DataField="qty" />
                                                <asp:BoundField DataField="Fullname" HeaderText="Responsible Person" />
                                                <asp:BoundField DataField="Date_Acquired" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date Acquired"
                                                    HtmlEncode="False" />
                                                <asp:BoundField DataField="item_id" HeaderText="Item_id" />
                                                <asp:BoundField DataField="ICSDt_lID" HeaderText="ICSDt_lID" />
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; text-align: center">
                                <asp:Button ID="btnload" runat="server" Text="LOAD" Width="150px" /></td>
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
</asp:Content>

