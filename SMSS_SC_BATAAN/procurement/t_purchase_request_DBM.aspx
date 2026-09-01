<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false"
    CodeFile="t_purchase_request_DBM.aspx.vb" Inherits="t_purchase_request_DBM"
    Title="Purchase Request - DBM" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">CREATE PURCHASE REQUEST FOR DBM
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 100%">
                                <tbody>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Department : </td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddRC" runat="server" AutoPostBack="True" CssClass="drpdownCSS" Width="95%">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 20%" class="column_RightBold">Date :</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:TextBox ID="txtprdate" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%; height: 22px;" class="column_RightBold">Function : </td>
                                        <td style="width: 35%; height: 22px;" class="column_Left">
                                            <asp:DropDownList ID="ddFunction" runat="server" AutoPostBack="True" CssClass="drpdownCSS" Width="95%">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 20%; height: 22px;" class="column_RightBold">Items :</td>
                                        <td style="width: 30%; height: 22px;" class="column_Left"><asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click1" runat="server" CssClass="LinkBtnPreview" Enabled="False" Text="View List of Goods"></asp:LinkButton></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">P/P/A : </td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddPAPS" runat="server" AutoPostBack="True" CssClass="drpdownCSS" Width="95%">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 20%" class="column_RightBold">Payee :</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:TextBox ID="txtpeyee" runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Allotment Type : </td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddnature" runat="server" AutoPostBack="True" CssClass="drpdownCSS" Width="95%">
                                                <asp:ListItem Selected="True" Value="2">MOOE</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 20%" class="column_RightBold">Address :</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:TextBox ID="txtaddpeyee" runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Account Title : </td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddAccounts" runat="server" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddAccounts_SelectedIndexChanged" Width="95%">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 20%" class="column_RightBold">Requesting Person :</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:DropDownList ID="ddRequestedBy" runat="server" Width="95%" CssClass="txtboxinspection" AutoPostBack="True" OnSelectedIndexChanged="ddRequestedBy_SelectedIndexChanged" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%; height: 30px;" class="column_RightBold">Available Budget : </td>
                                        <td style="width: 35%; height: 30px;" class="column_Left">
                                            <asp:TextBox ID="txtBudget" runat="server" CssClass="txtbox_Amt" Width="120px"></asp:TextBox>
                                        </td>
                                        <td style="width: 20%; height: 30px;" class="column_RightBold">Position :</td>
                                        <td style="width: 30%; height: 30px;" class="column_Left">
                                            <asp:TextBox ID="txtposition" runat="server" Width="95%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">
                                            <asp:Label ID="req1" runat="server" ForeColor="Red" Visible="False" Text="*"></asp:Label>
                                            Purpose :</td>
                                        <td style="width: 35%" class="column_Left" rowspan="2">
                                            <asp:TextBox Style="text-align: left" ID="txtpurpose" runat="server" Width="95%" CssClass="txtbox_Remarks" SkinID="text" TextMode="MultiLine" Height="40px"></asp:TextBox></td>
                                        <td style="width: 20%" class="column_RightBold">Approved By : </td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:DropDownList ID="ddApprovedBy" runat="server" CssClass="drpdownCSS" Width="95%">
                                            </asp:DropDownList>
                                            </strong></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold"></td>
                                        <td style="width: 20%" class="column_RightBold"></td>
                                        <td style="width: 30%" class="column_Left"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Note : </td>
                                        <td style="width: 35%" class="column_Left">
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtprdate">
                                            </cc1:CalendarExtender>
                                            <asp:TextBox ID="txtNote" runat="server" CssClass="txtbox_Var" Width="95%"></asp:TextBox>
                                        </td>
                                        <td style="width: 20%" class="column_RightBold"></td>
                                        <td style="width: 30%" class="column_Left"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold"></td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:CheckBox ID="cbReinbursement" runat="server" Visible="False"></asp:CheckBox></td>
                                        <td style="width: 20%" class="column_RightBold"></td>
                                        <td style="width: 30%" class="column_Left"></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle"> List of Goods
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="gvbody" runat="server" Width="95%" Font-Size="8pt" CssClass="text" OnSelectedIndexChanged="gvbody_SelectedIndexChanged" SkinID="GridViewAA" ShowFooter="True" OnRowDeleting="gvbody_RowDeleting" CaptionAlign="Left" PageSize="5" DataKeyNames="Item_ID,GA_ID,BGA_ID">
                                <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" runat="server" CausesValidation="False" Font-Underline="False" CommandName="Select">Delete</asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="20px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            &nbsp;<asp:Label Style="text-align: left" ID="lbldesc" runat="server" CssClass="text" Text='<%# Bind("Item_Desc") %>'></asp:Label>
                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>

                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblunit" runat="server" CssClass="text" Text='<%# Bind("Description") %>'></asp:Label>
                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox Style="text-align: right" ID="txtqty" runat="server" Width="95%" CssClass="txtbox_Var" AutoPostBack="True" Text='<%# Bind("InputQty") %>' OnTextChanged="txtqty_TextChanged"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtqty" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Cost") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <strong>TOTAL</strong> :
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            &nbsp;
                                            <asp:Label ID="lblCost" runat="server" Text='<%# Bind("cost", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>

                                        <FooterStyle HorizontalAlign="Right"></FooterStyle>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("total") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label Style="text-align: right" ID="lbltotal2" runat="server" Width="100px" CssClass="text" Text='<%# Bind("total", "{0:N}") %>'></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label Style="text-align: right" ID="lbltotal" runat="server" Width="100px" CssClass="text" Text='<%# Bind("total", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>

                                        <FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item_ID">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Item_ID") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItem_ID" runat="server" Text='<%# Bind("Item_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton4" visible="true" runat="server" CommandName="Select" Height="15px" ImageUrl="~/images/delete.png" OnClick="ImageButton4_Click" OnClientClick="StartProgressBar();" />
                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to delete this item?" TargetControlID="ImageButton4">
                                            </cc1:ConfirmButtonExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Checked By :</span>
                            <asp:DropDownList ID="ddCheckedBy" runat="server" CssClass="drpdownCSS" Width="300px"></asp:DropDownList>
                            <span class="column_RightBold">Noted By :</span>
                            <asp:DropDownList ID="ddNotedBy" runat="server" CssClass="drpdownCSS" Width="300px"></asp:DropDownList>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass="CSButton" Width="150px" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button>
                            <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" CssClass="CSButton" Width="150px" Text="SUBMIT" OnClientClick="StartProgressBar();"></asp:Button>
                            <asp:Button ID="btnpreview" OnClick="btnpreview_Click" runat="server" CssClass="CSButton" Width="150px" Enabled="False" Text="PREVIEW"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px" align="center"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView Style="font-weight: normal" ID="gvListPR" runat="server" Width="98%" Font-Size="8pt" OnSelectedIndexChanged="gvListPR_SelectedIndexChanged" SkinID="GridView" DataKeyNames="prhdr_id" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="remarks" HeaderText="REMARKS">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Date_Submitted" DataFormatString="{0:MM/dd/yyyy}" HeaderText="DATE">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Report" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click1" runat="server" Width="20px" CausesValidation="False" __designer:wfdid="w13" Text="PR" Font-Underline="False" CommandName="Select"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton4" OnClick="LinkButton4_Click" runat="server" Width="20px" CausesValidation="False" __designer:wfdid="w14" Visible="False" Font-Underline="False" CommandName="Select">ObR</asp:LinkButton>
                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" runat="server" CausesValidation="False" __designer:wfdid="w15" Text="Edit" Font-Underline="False" CommandName="Select"></asp:LinkButton><asp:LinkButton ID="LinkButton6" OnClick="LinkButton6_Click" runat="server" __designer:wfdid="w16" Visible="False" Font-Underline="False" CommandName="Select">Cancel</asp:LinkButton><cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" __designer:wfdid="w17" TargetControlID="LinkButton6" ConfirmText="Are you sure you want to cancel  this transaction?">
                                            </cc1:ConfirmButtonExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>





            <asp:Panel Style="display: none" ID="popup" runat="server" CssClass="Panel_Popup" Width="730px" __designer:wfdid="w59" >
                <table id="Table2" height="486" cellspacing="0" cellpadding="0" width="747" border="0">
                    <tbody>
                        <tr>
                            <td style="width: 772px; height: 39px"></td>
                            <td style="width: 46px; height: 39px">
                              <%--  <asp:ImageButton ID="ImageButton3" runat="server"  __designer:wfdid="w60"></asp:ImageButton></td>--%>
                        </tr>
                        <tr>
                            <td style=" vertical-align: top; width: 772px; text-align: center" id="Td1">
                                <table style="width: 705px; height: 336px" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="vertical-align: top; width: 4%; text-align: center"></td>
                                            <td style="vertical-align: top; width: 100%; text-align: center">
                                                <table style="width: 100%" class="text" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 100%; height: 25px" colspan="3">
                                                                <asp:DropDownList ID="ddpopup" runat="server" Width="150px" __designer:wfdid="w61">
                                                                    <asp:ListItem Value="Item_Desc">Item Description</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:TextBox ID="SearchBut" runat="server" Width="350px" CssClass="text" __designer:wfdid="w62"></asp:TextBox>
                                                                <asp:Button ID="Button5" OnClick="Button5_Click" CssClass="CSButton" runat="server" Width="100px" __designer:wfdid="w63" Text="SEARCH"></asp:Button></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <asp:GridView ID="gvitems" runat="server" Width="100%" __designer:wfdid="w64" SkinID="GridViewAA" PageSize="8" DataKeyNames="item_id" AllowPaging="True" OnPageIndexChanging="gvitems_PageIndexChanging" BackColor="White">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                                                            </EditItemTemplate>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="CheckBox2" runat="server" Width="50px" Font-Bold="True" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" __designer:wfdid="w106" AutoPostBack="True" Text="All" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="CheckBox1" runat="server" Width="50px" AutoPostBack="True" __designer:wfdid="w6" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left" Width="45%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Description" HeaderText="Unit">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="price" DataFormatString="{0:N}" HeaderText="Cost">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Item_ID" HeaderText="Item_ID">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 4%; height: 24px; text-align: center"></td>
                                            <td style="width: 100%; height: 24px; text-align: center">
                                                <asp:Button ID="Button3" OnClick="Button3_Click" runat="server" CssClass="CSButton" Width="150px" __designer:wfdid="w65" Text="LOAD" OnClientClick="StartProgressBar();"></asp:Button></td>
                                        </tr>
                                    </tbody>
                                </table>
                                <span style="font-size: 11pt">
                                    <asp:Label ID="Label1" runat="server" __designer:wfdid="w1"></asp:Label></span></td>
                            <td style=" width: 46px; height: 446px"></td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>


            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" __designer:wfdid="w107" TargetControlID="Label1" CancelControlID="ImageButton3" BackgroundCssClass="modalBackground" PopupControlID="popup"></cc1:ModalPopupExtender>
            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px" __designer:wfdid="w112">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" __designer:wfdid="w113" TargetControlID="ButtonProgress" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" __designer:wfdid="w114" Enabled="False"></asp:Button>&nbsp;&nbsp; 
        
        
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

