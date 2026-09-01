<%@ Page 
    Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="t_negotiated.aspx.vb"
    Inherits="bidding_t_negotiated" 
    Title="Negotiated Mode of Procurement" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">





</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="upEmployeeDetail" runat="server">
        <ContentTemplate>

            
            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">NEGOTIATED MODE OF PROCUREMENT
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <span class="column_RightBold">Date :</span>
                            &nbsp;<asp:TextBox ID="txtDate" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton>
                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtDate" PopupButtonID="ImageButton2" Enabled="True"></cc1:CalendarExtender>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Search By :</span>
                            &nbsp;<asp:DropDownList ID="ddSearch" runat="server" Width="120px" CssClass="drpdownCSS" OnSelectedIndexChanged="ddSearch_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="1">PR Number</asp:ListItem>
                                <asp:ListItem Value="2">Department</asp:ListItem>
                                <asp:ListItem Value="3">OBR Number</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:TextBox ID="txtSearch" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="SEARCH"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdNegotiated" runat="server" Width="98%" OnSelectedIndexChanged="grdNegotiated_SelectedIndexChanged"
                                OnPageIndexChanging="grdNegotiated_PageIndexChanging" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="prhdr_id"
                                PageSize="8" SkinID="GridViewAA">
                                <Columns>
                                    <asp:TemplateField HeaderText="PR Number">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbPR_No" OnClick="lbPR_No_Click" runat="server" CausesValidation="False" Text='<%#Bind("pr_no") %>' Font-Underline="False" CommandName="Select"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="OBR_No" HeaderText="OBR Number">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="rc_name" HeaderText="Department">
                                        <ItemStyle HorizontalAlign="Left" Width="55%"></ItemStyle>
                                    </asp:BoundField>                                   
                                    <asp:BoundField DataField="DateApproved" DataFormatString="{0:d}" HeaderText="Date Approved">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Action">                                      
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbCancel" OnClick="lbCancel_Click" runat="server" CssClass="LinkBtnCancel" OnClientClick="StartProgressBar();" Font-Underline="False" CommandName="Select" Visible='<%#Bind("isVisible") %>'>Return</asp:LinkButton>
                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender5" runat="server" ConfirmText="Are you sure you want to return this PR to OBR Evaluation?" TargetControlID="lbCancel"></cc1:ConfirmButtonExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle BackColor="#2977DC"></FooterStyle>
                                <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%; height: 10px"></td>
                        <td style="width: 98%">
                            <table>
                                <tr>
                                    <td class="column_RightBold">Negotiated Mode of Procurement :</td>
                                    <td class="column_Left">
                                        <asp:DropDownList ID="dd_mode_of_procurement" runat="server" Width="98%" CssClass="drpdownCSS"  AutoPostBack="True" >
                                            <asp:ListItem Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List Of Goods
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical">
                                        <asp:GridView ID="grdNegoItems" runat="server" Width="100%" PageSize="5" SkinID="GridViewAA" ShowFooter="True"
                                            EmptyDataText="No Data Found">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="cbALL" runat="server" Enabled="False" OnCheckedChanged="cbALL_CheckedChanged"></asp:CheckBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" Enabled="False" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Description">                                                    
                                                    <ItemTemplate>
                                                        <asp:Label  ID="lbldesc" runat="server" Text='<%# Bind("Item_Desc") %>' ></asp:Label>
                                                    </ItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left" Width="55%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unit">                                                   
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblunit" runat="server" CssClass="text" Text='<%# Bind("Unit") %>' ></asp:Label>
                                                    </ItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Quantity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblqty" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Price">
                                                    <FooterTemplate>
                                                        <strong>TOTAL</strong>
                                                    </FooterTemplate>                                             
                                                    <ItemTemplate>
                                                        <asp:TextBox  ID="txtCost" runat="server" Width="98%" CssClass="txtbox_Amt"  Text='<%# Bind("cost", "{0:N2}") %>' AutoPostBack="True" OnTextChanged="txtCost_TextChanged"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"  TargetControlID="txtCost" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                                    </ItemTemplate>

                                                    <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Total Amount">
                                                    <FooterTemplate>
                                                        <asp:Label  ID="lbltotal" runat="server" Text='<%# Bind("total", "{0:N2}") %>' ></asp:Label>
                                                    </FooterTemplate>
                                                   
                                                    <ItemTemplate>
                                                        <asp:Label Style="text-align: right" ID="lbltotalx" runat="server" Text='<%#Bind("total", "{0:N}") %>' ></asp:Label>
                                                    </ItemTemplate>

                                                    <FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>

                                            <FooterStyle BackColor="#2977DC"></FooterStyle>
                                            <HeaderStyle BackColor="#2977DC" Font-Names="Arial" Font-Size="8pt" ForeColor="White"></HeaderStyle>
                                        </asp:GridView>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Supplier :</span>
                            &nbsp;<asp:DropDownList ID="ddSupplier" runat="server" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="ddSupplier_SelectedIndexChanged" Width="350px" CssClass="drpdownCSS">
                                 </asp:DropDownList>
                            &nbsp;<asp:Button ID="btnSave" runat="server" Enabled="False" OnClick="btnSave_Click" OnClientClick="StartProgressBar();" Text="SAVE" Width="150px" CssClass="CSButton" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to save  this transaction?" TargetControlID="btnSave">
                            </cc1:ConfirmButtonExtender>
                            &nbsp<asp:Button ID="btnRFQ" runat="server" Text="PREVIEW RFQ" CssClass="CSButton" OnClick="btnRFQ_Click" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>                   
                   
                    <%-- SUPPLIERS --%>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">&nbsp; Suppliers
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdSupplier1" runat="server" Width="90%" SkinID="GridViewAA" PageSize="1" DataKeyNames="Supplier_ID, SuppName" AutoGenerateColumns="False" OnSelectedIndexChanged="grdSupplier1_SelectedIndexChanged" EmptyDataText="No Data Found." OnRowDataBound="grdSupplier1_RowDataBound" ShowFooter="True">
                                <EmptyDataRowStyle HorizontalAlign="Left"></EmptyDataRowStyle>
                                <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkDelete" OnClick="linkDelete_Click" runat="server" CssClass="LinkBtnCancel" OnClientClick="StartProgressBar();" CommandName="Select" Font-Underline="False" Text="Remove"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SuppName" HeaderText="Supplier Name">
                                        <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Amount" DataFormatString="{0:N}" HeaderText="Amount">
                                        <ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="List of Items">
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkviewItems" OnClick="lnkviewItems_Click" runat="server" CausesValidation="False" CommandName="Select" CssClass="LinkBtnPreview" Font-Underline="False" Text="View Items"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle BackColor="#2977DC"></FooterStyle>

                                <HeaderStyle BackColor="#2977DC" Font-Names="Arial" Font-Size="8pt" ForeColor="White"></HeaderStyle>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <%-- END --%>

                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>

                </table>
            </div>
            
            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>

            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>

            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>

            <asp:Panel ID="pnlDC" runat="server" Width="500px" BorderWidth="2px" BorderStyle="Solid" BorderColor="#FFA016" BackColor="White">
                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                    <tbody>
                        <tr>
                            <td style="text-align: center">
                                <asp:Button ID="Button1" runat="server" Width="80px" Text="OK" ValidationGroup="ok"></asp:Button>
                                <asp:Button ID="Button2" runat="server" Width="80px" Text="CANCEL"></asp:Button></td>
                        </tr>
                    </tbody>
                </table>
                <asp:Label ID="pr_pop_up" runat="server"> </asp:Label>
            </asp:Panel>

            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="pr_pop_up" PopupControlID="pnlDC" BackgroundCssClass="modalBackground" CancelControlID="Button2"></cc1:ModalPopupExtender>

            <asp:Panel Style="display: none" ID="popup" runat="server" Width="743px" CssClass="Panel_Popup">
                <table id="Table8" height="50" cellspacing="0" cellpadding="0" border="0">
                    <tbody>
                        <tr>
                            <td style="vertical-align: top; width: 772px" id="Td3">
                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="vertical-align: top; width: 4%; text-align: center"></td>
                                            <td style="vertical-align: top; width: 100%; text-align: center"></td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; width: 100%; text-align: center;">
                                                <asp:Panel ID="Panel1" runat="server" Width="99%" CssClass="PanelSize_Popup" ScrollBars="Vertical">
                                                    <asp:GridView ID="grdItemList" runat="server" Width="100%" PageSize="12" SkinID="GridViewAA" EmptyDataText="No Data Found." BackColor="White" Font-Size="9pt">
                                                        <Columns>
                                                            <asp:TemplateField Visible="False">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" OnClientClick="StartProgressBar();" CommandName="Select">Delete</asp:LinkButton>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Item_Desc" HeaderText="Item Description">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Unit" HeaderText="Item Description">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Quantity" HeaderText="Item Description">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Canvass Unit Price">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("UnitPrice") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtCanvassPrice" runat="server" Width="90%" Text='<%# Bind("UnitPrice", "{0:N2}") %>' CssClass="txtboxAmount"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="total" DataFormatString="{0:N}" HeaderText="Total Amount">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Item_ID" Visible="False">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Item_ID") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblItem_ID" runat="server" Text='<%# Bind("Item_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>

                                                        <FooterStyle BackColor="#2977DC"></FooterStyle>
                                                        <HeaderStyle BackColor="#2977DC" Font-Names="Arial" Font-Size="8pt" ForeColor="White"></HeaderStyle>
                                                    </asp:GridView>
                                                </asp:Panel>
                                                <br />
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; width: 100%; text-align: center;">
                                                <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" runat="server" Width="150px" OnClientClick="StartProgressBar();" Text="UPDATE" CssClass="CSButton"></asp:Button>&nbsp;
                                    <asp:Button ID="btnCloseModalView" runat="server" Width="150px" CssClass="CSButton" Text="Close"></asp:Button>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <span style="color: black">
                                    <asp:Label Style="position: relative" ID="lblpopup" runat="server" Width="120px"></asp:Label>
                                </span>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>

            <cc1:ModalPopupExtender ID="ModalPopupExtendepopup" runat="server" BackgroundCssClass="modalBackground" PopupControlID="popup" TargetControlID="lblpopup"></cc1:ModalPopupExtender>


            <asp:Panel runat="server" ID="pnl_RFQDate" Width="250px" CssClass="Panel_Popup">
                <table width="100%">
                    <tr>
                        <td style="width: 100%" class="DivTitle">Request for Quotation Date</td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:TextBox ID="txt_RFQDate" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                            &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" Height="15px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="20px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:Button ID="btn_RFQDate" runat="server" Text="OK" Width="100px" CssClass="CSButton" OnClick="btn_RFQDate_Click"></asp:Button>
                            &nbsp;<asp:Button ID="btnCancel" runat="server" Text="CANCEL" Width="100px" CssClass="CSButton"></asp:Button>
                            <cc1:CalendarExtender ID="CalendarExtenderRFQ" runat="server" TargetControlID="txt_RFQDate" Enabled="True" PopupButtonID="ImageButton3"></cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:Label ID="lblPopUp_RFQ" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>

            <cc1:ModalPopupExtender ID="ModalPopup_RFQ" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnl_RFQDate" TargetControlID="lblPopUp_RFQ"></cc1:ModalPopupExtender>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

