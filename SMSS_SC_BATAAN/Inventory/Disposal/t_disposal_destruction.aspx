<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_disposal_destruction.aspx.vb" Inherits="Inventory_Disposal_t_disposal_destruction" title="Destruction" StylesheetTheme="SkinFile"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   

<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>   
   
    <table border="0" cellpadding="0" cellspacing="0" style="width: 900px">
        <tr>
            <td colspan="8" style="text-align: left">
                <asp:Label ID="lblHeader" runat="server" Font-Bold="True" SkinID="pageheader" Style="text-align: left"
                    Text="Donation" Font-Size="14pt" ForeColor="DimGray"></asp:Label>

                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="text-align: right;" colspan="7">
                <cc1:confirmbuttonextender id="ConfirmButtonExtender1" runat="server" confirmtext="Are you sure you want to save this transaction?"
                    targetcontrolid="btnsave">
                </cc1:confirmbuttonextender>
                <asp:Button ID="btnnew" runat="server" SkinID="ButtonImage" Text="NEW" Visible="False" />
                <asp:Button ID="btnopen" runat="server" SkinID="ButtonImage" Text="OPEN" Visible="False" />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                &nbsp;</td>
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
            <td colspan="8">
                <asp:Panel ID="Panel1" runat="server" CssClass="text" Font-Bold="True" GroupingText="INFORMATION"
                    Width="960px">
                    <table border="0" cellpadding="0" cellspacing="0" style="font-weight: normal; width: 100%">
                        <tr>
                            <td style="width: 221px; height: 10px">
                            </td>
                            <td style="width: 8px; height: 10px">
                            </td>
                            <td colspan="4" style="height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 221px">
                                Date</td>
                            <td style="width: 8px">
                                :</td>
                            <td colspan="4">
                                <asp:TextBox ID="txtdate" runat="server" SkinID="text" Width="100px" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 221px">
                                Transfer To<span style="font-size: 7pt; color: red"></span></td>
                            <td style="width: 8px">
                                :</td>
                            <td colspan="4">
                                <asp:TextBox ID="txtTo" runat="server" Width="435px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTo"
                                    ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator><em><span style="font-size: 7pt;
                                        color: #ff0000">(Name of Bureau or Office)</span></em></td>
                        </tr>
                        <tr>
                            <td style="width: 221px">
                                Receiving Accountable Officer</td>
                            <td style="width: 8px">
                                :</td>
                            <td colspan="4">
                                <asp:TextBox ID="txtRAO" runat="server" Width="317px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRAO"
                                    ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 221px">
                                Authorized By</td>
                            <td style="width: 8px">
                                :</td>
                            <td colspan="4">
                                <asp:TextBox ID="txtBy" runat="server" Width="317px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBy"
                                    ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
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
        </tr>
        <tr>
            <td colspan="8">
                <asp:Panel ID="Panel3" runat="server" CssClass="text" Font-Bold="True" GroupingText="CAPITAL OUTLAYS"
                    Style="vertical-align: top; text-align: left" Width="960px">
                    &nbsp;<asp:GridView ID="gvNEW" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CaptionAlign="Left" DataKeyNames="IIRUPHdr_ID,IIRUP_Date" PageSize="8" SkinID="gvnew"
                        Style="font-weight: normal" Width="950px">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                        Font-Underline="True" ForeColor="Black" Text="Select"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="IIRUPHdr_ID" HeaderText="TransactionID">
                                <HeaderStyle CssClass="text" />
                                <ItemStyle HorizontalAlign="Left" Width="400px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IIRUP_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date"
                                HtmlEncode="False">
                                <HeaderStyle CssClass="text" />
                                <ItemStyle HorizontalAlign="Left" Width="400px" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle Font-Names="Arial" Font-Size="8pt" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="8" style="height: 19px">
            </td>
        </tr>
        <tr>
            <td colspan="8">
                <asp:Panel ID="Panel2" runat="server" CssClass="text" Font-Bold="True" GroupingText="CAPITAL OUTLAYS"
                    Style="vertical-align: top; text-align: left" Width="960px">
                <asp:GridView ID="gvbody" runat="server" AutoGenerateColumns="False" SkinID="gvnew"
                    Style="font-weight: normal;" Width="950px">
                    <Columns>
                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Font-Bold="True"
                                    Font-Names="tahoma" Font-Size="10pt" ForeColor="White" OnCheckedChanged="CheckBox2_CheckedChanged"
                                    Text="All" Width="50px" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="textGrdHeader" />
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Property_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date of Purchased"
                            HtmlEncode="False" >
                            <HeaderStyle CssClass="textGrdHeader" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="propertyNo" HeaderText="Property Number" >
                            <HeaderStyle CssClass="textGrdHeader" />
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Item_Desc" HeaderText="Article" >
                            <HeaderStyle CssClass="textGrdHeader" />
                            <ItemStyle HorizontalAlign="Left" Width="350px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Unit" HeaderText="Unit" >
                            <HeaderStyle CssClass="textGrdHeader" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="qty" HeaderText="Quantity" >
                            <HeaderStyle CssClass="textGrdHeader" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="val" HeaderText="Unit Value" DataFormatString="{0:N}" HtmlEncode="False" >
                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                            <HeaderStyle CssClass="textGrdHeader" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                </asp:Panel>
                &nbsp;
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
        </tr>
        <tr>
            <td colspan="8">
                <asp:Button ID="btnsave" runat="server" SkinID="ButtonImage" Text="SAVE" ValidationGroup="save" Width="200px" /><asp:Button ID="btnpreview" runat="server" SkinID="ButtonImage" Text="PREVIEW" Width="200px" /></td>
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
        </tr>
    </table>
    <asp:Panel ID="popup" runat="server" Style="display: none" Width="900px">
        <table id="Table1" border="0" cellpadding="0" cellspacing="0" height="401" width="840">
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
<TABLE cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD colSpan=4><TABLE style="WIDTH: 100%" class="text" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%">DATE:<asp:TextBox id="txtsearch2" runat="server" Width="150px" CssClass="text"></asp:TextBox><asp:ImageButton id="im1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton> (MM/DD/YYYY)<cc1:CalendarExtender id="CalendarExtender3" runat="server" TargetControlID="txtsearch2" PopupButtonID="im1">
                                                                        </cc1:CalendarExtender> <cc1:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="txtsearch2" MaskType="Date" Mask="99/99/9999">
                                                                        </cc1:MaskedEditExtender> <asp:Button id="Button2" onclick="Button2_Click" runat="server" Text="SEARCH"></asp:Button> &nbsp; &nbsp;&nbsp;</TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE> 
</ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; text-align: center">
                                <asp:Button ID="Button1" runat="server" CausesValidation="False" Font-Bold="False"
                                    SkinID="Button" Text="LOAD" Width="150px" /></td>
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
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
        CancelControlID="ImageButton1" PopupControlID="popup" TargetControlID="btnnew">
    </cc1:ModalPopupExtender>
    <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" BackgroundCssClass="modalBackground"
        CancelControlID="ImageButton3" PopupControlID="popup2" TargetControlID="btnopen">
    </cc1:ModalPopupExtender>
    <br />
    <asp:Panel ID="popup2" runat="server" Style="display: none" Width="900px">
        <table id="Table2" border="0" cellpadding="0" cellspacing="0" height="401" width="840">
            <tr>
                <td colspan="4">
                    <img alt="" height="5" src="../images/popupmenu/sms-popup_01.gif" width="840" /></td>
            </tr>
            <tr>
                <td colspan="2" style="background-image: url(../images/popupmenu/sms-popup_02.gif);
                    vertical-align: bottom; width: 753px; height: 35px">
                </td>
                <td style="width: 70px; height: 35px">
                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="../images/popupmenu/sms-popup_03.gif" /></td>
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
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tbody>
                                                <tr>
                                                    <td colspan="4">
                                                        <table border="0" cellpadding="0" cellspacing="0" class="text" style="width: 100%">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 100%">
                                                                        DATE:<asp:TextBox ID="txtsearch" runat="server" CssClass="text" Width="150px"></asp:TextBox><asp:ImageButton
                                                                            ID="im2" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" />
                                                                        (MM/DD/YYYY)<cc1:CalendarExtender ID="CalendarExtender4" runat="server" PopupButtonID="im2"
                                                                            TargetControlID="txtsearch">
                                                                        </cc1:CalendarExtender>
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99/99/9999"
                                                                            MaskType="Date" TargetControlID="txtsearch">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:Button ID="btnsearch5" runat="server" OnClick="Button19_Click" Text="SEARCH"
                                                                            Width="100px" />
                                                                        &nbsp; &nbsp;</td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <asp:GridView ID="gvopen" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            CaptionAlign="Left" DataKeyNames="Disposal_Donation_hdr_id,Disposa_date,TransTo,RAO,AuthorizedBy" PageSize="8" SkinID="gvnew"
                                            Width="100%">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                            Font-Underline="True" ForeColor="Black" Text="Select"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Transto" HeaderText="Donee">
                                                    <HeaderStyle CssClass="text" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="disposa_date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date"
                                                    HtmlEncode="False">
                                                    <HeaderStyle CssClass="text" />
                                                </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle Font-Names="Arial" Font-Size="8pt" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; text-align: center">
                                <asp:Button ID="btnload2" runat="server" CausesValidation="False" Font-Bold="False"
                                    SkinID="Button" Text="LOAD" Width="150px" /></td>
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
    

</contenttemplate>
</asp:UpdatePanel>    
</asp:Content>

