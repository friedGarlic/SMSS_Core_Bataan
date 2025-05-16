<%@ Page Language="VB" 
    AutoEventWireup="false" 
    MasterPageFile="~/MasterPage.master" 
    CodeFile="t_RepeatOrder.aspx.vb" 
    Inherits="bidding_t_RepeatOrder"
    Title="Repeat Order"
    StylesheetTheme="SkinFile"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
     </asp:ScriptManager>
     <asp:UpdatePanel ID="upEmployeeDetail" runat="server">
           <ContentTemplate>
               <div>
                   <table width="100%">
                       <tr>
                           <td style="width: 1%"></td>
                           <td style="width: 98%" class="PageTitle">Repeat Order Canvassing
                           </td>
                           <td style="width: 1%"></td>
                       </tr>
                       <tr>
                           <td style="width: 1%"></td>
                           <td style="width: 98%" align="center">
                               <span class="column_RightBold">PR Number :</span>
                               &nbsp;<asp:TextBox ID="txtcanvassearch" runat="server" Width="250px" CssClass="txtbox_Var"></asp:TextBox>
                               &nbsp;<asp:Button ID="btnsearch" OnClick="btnsearch_Click" runat="server" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="SEARCH"></asp:Button>
                               &nbsp;<span class="column_RightBold">Date :</span>
                               &nbsp;<asp:TextBox ID="txtdate" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                               &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton>
                               &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                               <asp:Button ID="btnviewAll" OnClick="btnviewAll_Click" runat="server" Width="96px" OnClientClick="StartProgressBar();" Text="View All" Visible="false"></asp:Button>
                           </td>
                           <td style="width: 1%"></td>
                       </tr>
                       <tr>
                           <td style="width: 1%"></td>
                           <td style="width: 98%" align="center">
                               <asp:GridView ID="gvIncomingPR" runat="server" Width="98%" SkinID="GridViewAA" PageSize="8" DataKeyNames="prhdr_id,pr_no,isRecanvass,isDBM"
                                   AutoGenerateColumns="False" OnSelectedIndexChanged="gvIncomingPR_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvIncomingPR_PageIndexChanging"
                                   EmptyDataText="No Data Found.">
                                   <Columns>
                                       <asp:TemplateField HeaderText="PR Number">
                                           <EditItemTemplate>
                                               <asp:TextBox runat="server" Text='<%# Bind("pr_no") %>' ID="TextBox4"></asp:TextBox>
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                               <asp:LinkButton ID="lbPR_No" OnClick="lbPR_No_Click" runat="server" Text='<%# Bind("pr_no") %>' OnClientClick="StartProgressBar();" Visible='<%# bind("isVisible") %>' CommandName="Select" Font-Underline="False"></asp:LinkButton>
                                           </ItemTemplate>

                                           <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                           <ItemStyle HorizontalAlign="Center" Width="13%"></ItemStyle>
                                       </asp:TemplateField>

                                       <asp:BoundField DataField="remarks" HeaderText="Particulars">
                                           <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                           <ItemStyle HorizontalAlign="Left" Width="27%" Font-Size="8pt"></ItemStyle>
                                       </asp:BoundField>
                                       <asp:TemplateField HeaderText="Amount">
                                           <EditItemTemplate>
                                               <asp:TextBox runat="server" Text='<%# Bind("ABC") %>' ID="TextBox1"></asp:TextBox>
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                               <asp:Label ID="Label2" runat="server" Text='<%# Bind("ABC", "{0:N}") %>' Visible='<%# bind("isVisible") %>'></asp:Label>
                                           </ItemTemplate>

                                           <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                           <ItemStyle HorizontalAlign="Right" Width="8%"></ItemStyle>
                                       </asp:TemplateField>
                                       <asp:BoundField DataField="OBR_No" HeaderText="CAA Number">
                                           <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                           <ItemStyle HorizontalAlign="Center" Width="13%"></ItemStyle>
                                       </asp:BoundField>
                                       <asp:BoundField DataField="RC_Name" HeaderText="Department">
                                           <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                           <ItemStyle HorizontalAlign="Left" Width="20%" Font-Size="8pt"></ItemStyle>
                                       </asp:BoundField>
                                       <asp:TemplateField HeaderText="Date Approved">
                                           <EditItemTemplate>
                                               <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Date_Submitted") %>'></asp:TextBox>

                                           </EditItemTemplate>
                                           <ItemTemplate>
                                               <asp:Label ID="Label1" runat="server" Text='<%# Bind("DateApproved", "{0:MM/dd/yyyy}") %>' Visible='<%# bind("isVisible") %>'></asp:Label>
                                           </ItemTemplate>

                                           <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                           <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Action">
                                           <EditItemTemplate>
                                               <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox>
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                               <asp:LinkButton ID="lbCancel" OnClick="lbCancel_Click" runat="server" OnClientClick="StartProgressBar();" Visible='<%#Bind("isVisible") %>' CssClass="LinkBtnCancel" CommandName="Select" Font-Underline="False" Text="Return"></asp:LinkButton>
                                               <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender5" runat="server" TargetControlID="lbCancel" ConfirmText="Are you sure you want to return this PR to OBR Evaluation?"></cc1:ConfirmButtonExtender>
                                           </ItemTemplate>

                                           <ItemStyle HorizontalAlign="Center" Width="6%"></ItemStyle>
                                       </asp:TemplateField>
                                   </Columns>

                                   <FooterStyle BackColor="#2977DC"></FooterStyle>

                                   <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                               </asp:GridView>
                               <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtdate" Enabled="True" PopupButtonID="ImageButton2"></cc1:CalendarExtender>
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
                               <asp:MultiView ID="mvCategory" runat="server">
                                   <asp:View ID="vwItems" runat="server">
                                       <table style="width: 100%">
                                           <tbody>
                                               <tr align="center">
                                                   <td></td>
                                               </tr>
                                               <tr>
                                                   <td style="width: 100%" align="center">
                                                       <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                           <ContentTemplate>
                                                            <asp:Panel ID="Panel2" runat="server" Width="98%" CssClass="PanelSize" HorizontalAlign="Center" ScrollBars="Vertical">
                                                                <asp:GridView ID="grdPerItems" runat="server" Width="100%" SkinID="GridViewAA" PageSize="10" DataKeyNames="Item_ID" ShowFooter="True" EmptyDataText="No Data Found.">
                                                                    <EmptyDataRowStyle HorizontalAlign="Left"></EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:TemplateField>
                                                                            <HeaderTemplate>
                                                                                <asp:CheckBox ID="CheckBox2" runat="server" Text="ALL" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="CheckBox1" runat="server" Enabled="False" AutoPostBack="True" Checked="True" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Description">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbldesc" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Unit">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblunit" runat="server" Text='<%# Bind("Unit") %>' CssClass="text"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Quantity">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtqty" runat="server" Width="99%" Text='<%#Bind("Quantity") %>' CssClass="txtboxAmount" AutoPostBack="True" OnTextChanged="txtqty_TextChanged" Enabled="false"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtqty" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                        </asp:TemplateField>

    
                                                                        <asp:TemplateField HeaderText="Bidder's Unit Price" Visible="True">
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="Label2" runat="server" Text="TOTAL :"></asp:Label>
                                                                            </FooterTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtCost1" runat="server" Width="99%" Text='<%#Bind("cost", "{0:N}") %>' CssClass="txtboxAmount" AutoPostBack="True" OnTextChanged="txtCost1_TextChanged"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <FooterStyle HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
                                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField HeaderText="Total Amount" Visible="True">
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalAmount1" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtTotal1" runat="server" Width="99%" CssClass="txtboxAmount" ReadOnly="True">0.00</asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField Visible="True">
                                                                            <ItemTemplate>
                                                                                <asp:Button ID="btnDetail" runat="server" Text="+" EnableTheming="True"></asp:Button>
                                                                                <asp:Panel Style="display: none" ID="pnlDetail" runat="server" Width="400px" BorderWidth="2px" BorderColor="#FFA016" BorderStyle="Solid" BackColor="White">
                                                                                    <table style="width: 100%; text-align: center">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td style="width: 100%">
                                                                                                    <asp:TextBox ID="txtItemSpecs" runat="server" Width="99%" CssClass="text" Height="150px" TextMode="MultiLine"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="font-size: 9pt; width: 100%; color: red; font-style: italic; font-family: Calibri; text-align: left">
                                                                                                    Note: Use Comma " , " to separate each specifications.
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%">
                                                                                                    <br />
                                                                                                    <asp:Button ID="Button6" runat="server" Width="120px" Text="OK"></asp:Button>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </asp:Panel>
                                                                                <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnDetail" PopupControlID="pnlDetail" BackgroundCssClass="modalBackground" CancelControlID="Button6" DynamicServicePath="">
                                                                                </cc1:ModalPopupExtender>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField Visible="True">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblApprovedBudget" runat="server" Text='<%#Bind("cost", "{0:N}") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                    </Columns>

                                                                    <FooterStyle BackColor="#2977DC"></FooterStyle>
                                                                    <HeaderStyle BackColor="#2977DC" Font-Names="Arial" Font-Size="8pt" ForeColor="White"></HeaderStyle>
                                                                </asp:GridView>
                                                            </asp:Panel>

                                                           </ContentTemplate>
                                                       </asp:UpdatePanel>
                                                   </td>
                                               </tr>

                                               <tr>
                                                   <td style="width: 100%" align="center"></td>
                                               </tr>
                                           </tbody>
                                       </table>
                                   </asp:View>
                               </asp:MultiView>
                           </td>
                           <td style="width: 1%"></td>
                       </tr>
                       <tr>
                           <td style="width: 1%"></td>
                           <td style="width: 98%" align="center">
                               <asp:MultiView ID="MultiView1" runat="server">
                                   <asp:View ID="View1" runat="server">
                                       <table style="width: 100%">
                                           <tbody>
                                               <tr align="center">
                                                   <td></td>
                                               </tr>
                                               <tr>
                                                   <td style="width: 100%" align="center">
                                                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                           <ContentTemplate>
                                                               <asp:Panel ID="Panel1" runat="server" Width="98%" CssClass="PanelSize" HorizontalAlign="Center" ScrollBars="Vertical">
                                                                   <asp:GridView ID="GridView1" runat="server" Width="100%" SkinID="GridViewAA" PageSize="10" DataKeyNames="Item_ID" ShowFooter="True" EmptyDataText="No Data Found.">
                                                                       <EmptyDataRowStyle HorizontalAlign="Left"></EmptyDataRowStyle>
                                                                       <Columns>
                                                                           <asp:TemplateField>
                                                                               <HeaderTemplate>
                                                                                   <asp:CheckBox ID="CheckBox2" runat="server" Text="ALL" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox>
                                                                               </HeaderTemplate>
                                                                               <ItemTemplate>
                                                                                   <asp:CheckBox ID="CheckBox1" runat="server" Enabled="False" AutoPostBack="True" Checked="True" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                                                                               </ItemTemplate>
                                                                               <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                           </asp:TemplateField>

                                                                           <asp:TemplateField HeaderText="Description">
                                                                               <ItemTemplate>
                                                                                   <asp:Label ID="lbldesc" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:Label>
                                                                               </ItemTemplate>
                                                                               <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                               <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                                                           </asp:TemplateField>

                                                                           <asp:TemplateField HeaderText="Unit">
                                                                               <ItemTemplate>
                                                                                   <asp:Label ID="lblunit" runat="server" Text='<%# Bind("Unit") %>' CssClass="text"></asp:Label>
                                                                               </ItemTemplate>
                                                                               <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                               <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                           </asp:TemplateField>

                                                                           <asp:TemplateField HeaderText="Quantity">
                                                                               <ItemTemplate>
                                                                                   <asp:TextBox ID="txtqty" runat="server" Width="99%" Text='<%#Bind("Quantity") %>' CssClass="txtboxAmount" AutoPostBack="True" OnTextChanged="txtqty_TextChanged" Enabled="false"></asp:TextBox>
                                                                                   <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtqty" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                                               </ItemTemplate>

                                                                               <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                           </asp:TemplateField>

                                                                           <asp:TemplateField HeaderText="Bidder's Unit Price" Visible="False">
                                                                               <FooterTemplate>
                                                                                   <asp:Label ID="Label2" runat="server" Text="TOTAL :"></asp:Label>
                                                                               </FooterTemplate>
                                                                               <ItemTemplate>
                                                                                   <asp:TextBox ID="txtCost1" runat="server" Width="99%" Text='<%#Bind("cost", "{0:N}") %>' CssClass="txtboxAmount" AutoPostBack="True" OnTextChanged="txtCost1_TextChanged"></asp:TextBox>
                                                                               </ItemTemplate>

                                                                               <FooterStyle HorizontalAlign="Right" Font-Bold="True"></FooterStyle>

                                                                               <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                                           </asp:TemplateField>

                                                                           <asp:TemplateField HeaderText="Total Amount" Visible="False">
                                                                               <FooterTemplate>
                                                                                   <asp:Label ID="lblTotalAmount1" runat="server"></asp:Label>
                                                                               </FooterTemplate>
                                                                               <ItemTemplate>
                                                                                   <asp:TextBox ID="txtTotal1" runat="server" Width="99%" CssClass="txtboxAmount" ReadOnly="True">0.00</asp:TextBox>
                                                                               </ItemTemplate>

                                                                               <FooterStyle HorizontalAlign="Right"></FooterStyle>

                                                                               <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                                           </asp:TemplateField>

                                                                           <asp:TemplateField Visible="False">
                                                                               <ItemTemplate>
                                                                                   <asp:Button ID="btnDetail" runat="server" Text="+" EnableTheming="True"></asp:Button>
                                                                                   <asp:Panel Style="display: none" ID="pnlDetail" runat="server" Width="400px" BorderWidth="2px" BorderColor="#FFA016" BorderStyle="Solid" BackColor="White">
                                                                                       <table style="width: 100%; text-align: center">
                                                                                           <tbody>
                                                                                               <tr>
                                                                                                   <td style="width: 100%">
                                                                                                       <asp:TextBox ID="txtItemSpecs" runat="server" Width="99%" CssClass="text" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
                                                                                               </tr>
                                                                                               <tr>
                                                                                                   <td style="font-size: 9pt; width: 100%; color: red; font-style: italic; font-family: Calibri; text-align: left">Note: Use Comma " , " to separate each specifications.</td>
                                                                                               </tr>
                                                                                               <tr>
                                                                                                   <td style="width: 100%">
                                                                                                       <br />
                                                                                                       <asp:Button ID="Button6" runat="server" Width="120px" Text="OK"></asp:Button></td>
                                                                                               </tr>
                                                                                           </tbody>
                                                                                       </table>
                                                                                   </asp:Panel>
                                                                                   <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnDetail" PopupControlID="pnlDetail" BackgroundCssClass="modalBackground" CancelControlID="Button6" DynamicServicePath="">
                                                                                   </cc1:ModalPopupExtender>
                                                                               </ItemTemplate>

                                                                               <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                           </asp:TemplateField>

                                                                           <asp:TemplateField Visible="False">
                                                                               <ItemTemplate>
                                                                                   <asp:Label ID="lblApprovedBudget" runat="server" Text='<%#Bind("cost", "{0:N}") %>'></asp:Label>
                                                                               </ItemTemplate>
                                                                               <ItemStyle HorizontalAlign="Center" />
                                                                           </asp:TemplateField>
                                                                       </Columns>

                                                                       <FooterStyle BackColor="#2977DC"></FooterStyle>

                                                                       <HeaderStyle BackColor="#2977DC" Font-Names="Arial" Font-Size="8pt" ForeColor="White"></HeaderStyle>
                                                                   </asp:GridView>
                                                               </asp:Panel>
                                                           </ContentTemplate>
                                                       </asp:UpdatePanel>
                                                   </td>
                                               </tr>

                                               <tr>
                                                   <td style="width: 100%" align="center"></td>
                                               </tr>
                                           </tbody>
                                       </table>
                                   </asp:View>
                               </asp:MultiView>
                           </td>
                           <td style="width: 1%"></td>
                       </tr>
                       <tr>
                           <td style="width: 1%"></td>
                           <td style="width: 98%" align="center">
                               <span class="column_RightBold">Supplier :</span>
                               &nbsp;<asp:DropDownList ID="ddSupplier1" runat="server" Width="300px" CssClass="drpdownCSS" OnSelectedIndexChanged="ddSupplier1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                               &nbsp;<asp:Button ID="btnSave1" OnClick="btnSave1_Click" runat="server" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="SAVE"></asp:Button>
                               &nbsp;<asp:Button ID="btnPrint" OnClick="btnPrint_Click" runat="server" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="PREVIEW RFQ" Enabled="False" Visible="false"></asp:Button>
                           </td>
                           <td style="width: 1%"></td>
                       </tr>
                       <tr>
                           <td style="width: 1%"></td>
                           <td style="width: 98%" class="DivTitle">&nbsp; Suppliers
                           </td>
                           <td style="width: 1%"></td>
                       </tr>
                       <tr>
                           <td style="width: 1%"></td>
                           <td style="width: 98%" align="center">
                               <asp:GridView ID="grdSupplier1" runat="server" Width="90%" SkinID="GridViewAA" PageSize="1" DataKeyNames="Supplier_ID,SuppName" AutoGenerateColumns="False" OnSelectedIndexChanged="grdSupplier1_SelectedIndexChanged"
                                   EmptyDataText="No Data Found." OnRowDataBound="grdSupplier1_RowDataBound" ShowFooter="True">
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

                       <tr>
                           <td style="width: 1%"></td>
                           <td style="width: 98%"></td>
                           <td style="width: 1%"></td>
                       </tr>
                       <tr>
                           <td style="width: 1%"></td>
                           <td style="width: 98%"></td>
                           <td style="width: 1%"></td>
                       </tr>
                       <tr>
                           <td style="width: 1%"></td>
                           <td style="width: 98%" align="center">
                               <asp:Label ID="Label4" runat="server" Width="436px"></asp:Label>
                           </td>
                           <td style="width: 1%"></td>
                       </tr>
                   </table>
               </div>
               <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />



            <asp:Panel Style="display: none" ID="popup" runat="server" Width="743px" CssClass="Panel_Popup">
                <table id="Table8" height="50" cellspacing="0" cellpadding="0" width="747px" border="0">
                    <tbody>
                        
                        <tr>
                            <td style="/*background-image: url(../images/modalpopup_04.png);*/ vertical-align: top; width: 772px" id="Td3">
                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="vertical-align: top; width: 4%; text-align: center"></td>
                                            <td style="vertical-align: top; width: 100%; text-align: center"></td>
                                        </tr>
                                        <tr>
                                           
                                            <td style="vertical-align: top; width: 100%; text-align: center">
                                                <asp:Panel ID="Panel3" runat="server" Width="99%" CssClass="PanelSize_Popup" ScrollBars="Vertical">
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
                                                            <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Quantity" HeaderText="Quantity">
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
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                           
                                            <td style="vertical-align: top; width: 100%; text-align: center">
                                                <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" runat="server" Width="150px" OnClientClick="StartProgressBar();" Text="UPDATE" CssClass="CSButton"></asp:Button> &nbsp
                                                <asp:button ID="btnCloseModalView" runat="server" Width ="150px" CssClass="CSButton" Text="Close"/>

                                            </td>
                                                
                                        </tr>
                                    </tbody>
                                </table>
                                <span style="color: black">
                                    <asp:Label Style="position: relative" ID="lblpopup" runat="server" Width="120px"></asp:Label></span></td>
                           
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtendepopup" runat="server" BackgroundCssClass="modalBackground" PopupControlID="popup" TargetControlID="lblpopup"></cc1:ModalPopupExtender>



            <asp:Panel runat="server" ID="pnl_RFQDate" Width="250px" CssClass="Panel_Popup">
                <table width="100%">
                    <tr>
                        <td style="width: 100%" class="DivTitle">Request for Quotation Date
                        </td>
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
                            <asp:Button ID="btn_RFQDate" runat="server" Text="OK" Width="100px" CssClass="CSButton" />
                            &nbsp;<asp:Button ID="btnCancel" runat="server" Text="CANCEL" Width="100px" CssClass="CSButton" />
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
            <cc1:ModalPopupExtender ID="ModalPopup_RFQ" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnl_RFQDate" TargetControlID="lblPopUp_RFQ">
            </cc1:ModalPopupExtender>
           </ContentTemplate>
     </asp:UpdatePanel>

</asp:Content>

