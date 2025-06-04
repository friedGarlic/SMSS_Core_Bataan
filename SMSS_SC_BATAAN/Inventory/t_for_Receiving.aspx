<%@ Page Title="" 
    Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    EnableEventValidation="false"
    AutoEventWireup="false" 
    CodeFile="t_for_Receiving.aspx.vb" 
    Inherits="Inventory_t_for_Receiving" 
    StylesheetTheme="SkinFile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">







</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

    </script>


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                 <div>
                     <table width="100%">
                        <tr>
                            <td class="PageTitle" style="width: 98%">
                                <strong>
                                    <asp:Label ID="lblClass" runat="server" Text="Receiving"></asp:Label>
                                &nbsp;P.O</strong></td>
                         </tr>
                        <tr>
                             <td style="width: 98%">
                              <table style="width: 100%">
                                <tbody>
                                    <tr>
                                        <td style="width: 30%" class="column_RightBold">Search By : </td>
                                        <td style="width: 20%" class="column_left">
                                            <asp:DropDownList ID="ddSearch" runat="server" Width="80%" OnSelectedIndexChanged="ddSearch_SelectedIndexChanged" AutoPostBack="True" CssClass="drpdownCSS">
                                                <asp:ListItem Selected="True" Value="1">ALL</asp:ListItem>
                                                <asp:ListItem Value="3">Purchase Order</asp:ListItem>
                                                <asp:ListItem Value="4">Supplier / Bidder</asp:ListItem>

                                            </asp:DropDownList>

                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox_Var" Width="150px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="drpdownCSS" Visible="False"></asp:DropDownList>

                                            <asp:HiddenField ID="txtTraps" runat="server" />
                                            <asp:HiddenField ID="txtHidenQTY" runat="server" />
                                            <asp:HiddenField ID="txtHiddenReceiveQty" runat="server" />
                                        </td>
                                      
                                        
                                            <td class="column_Left" style="width: 50%">
                                                <asp:MultiView ID="mvSearch" runat="server">
                                                    <asp:View ID="vwAccount" runat="server">
                                                        <table id="tb_Account" runat="server" style="width: 100%">
                                                            <tbody>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:RadioButtonList ID="RadioButtonList3" runat="server" AutoPostBack="True" CssClass="rbCS_Horizontal" RepeatDirection="Horizontal" Visible="True" Width="150px">
                                                                            <asp:ListItem Value="1">MOOE</asp:ListItem>
                                                                            <asp:ListItem Value="2">Capital Outlay</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 20%">Account Code :</td>
                                                                    <td align="left" style="width: 80%">
                                                                        <asp:DropDownList ID="ddAccount" runat="server" AutoPostBack="True" CssClass="drpdownCSS" Width="90%">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:View>
                                                    <asp:View ID="vwPO" runat="server">
                                                        <table id="tb_PO" runat="server" style="width: 100%">
                                                            <tbody>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 20%">PO Number :</td>
                                                                    <td style="width: 80%">
                                                                        <asp:TextBox ID="txtPO" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox>
                                                                        &nbsp;<asp:Button ID="btnSearchPO" runat="server" CssClass="CSButton" OnClick="btnSearchPO_Click" OnClientClick="StartProgressBar();" Text="Search" Width="100px" />
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:View>
                                                    <asp:View ID="vwSupp" runat="server">
                                                        <table id="tb_Supplier" runat="server" style="width: 100%">
                                                            <tbody>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 20%">Supplier Name :</td>
                                                                    <td style="width: 80%">
                                                                        <asp:DropDownList ID="ddSupplier" runat="server" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddSupplier_SelectedIndexChanged" Width="90%">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 20%"></td>
                                                                    <td style="width: 80%">
                                                                        <asp:Button ID="btnSupplier" runat="server" CssClass="CSButton" OnClick="btnSupplier_Click" Text="Search" Visible="False" Width="100px" />
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:View>
                                                    <asp:View ID="vwALL" runat="server">
                                                        <asp:RadioButtonList ID="rbALL" runat="server" AutoPostBack="True" CssClass="rbCS_Horizontal" OnSelectedIndexChanged="rbALL_SelectedIndexChanged" RepeatDirection="Horizontal" Visible="False" Width="200px">
                                                            <asp:ListItem Value="2">MOOE</asp:ListItem>
                                                            <asp:ListItem Value="3">Capital Outlay</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </asp:View>
                                                </asp:MultiView>
                                            </td>
                                        </tr>
                                </tbody>
                            </table>
                             </td>
                         </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="grdAIR" runat="server" Width="100%" OnSelectedIndexChanged="grdAIR_SelectedIndexChanged"
                                SkinID="GridViewAA" AllowPaging="True" DataKeyNames="POHdr_ID,PO_No,PO_Date,ContractPrice,SuppName,RC_ID,Function_ID,RC_Name,Function_Desc,GA_ID,Supplier_Id,pre_procurement_hdr_id"
                                OnRowDataBound="grdAIR_RowDataBound" OnPageIndexChanging="grdAIR_PageIndexChanging" Font-Size="8pt" EmptyDataText="No Data Found.">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

                                <Columns>
                                    <asp:BoundField DataField="PO_No" HeaderText="PO No.">
                                        <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PO_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="PO Date">
                                        <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ContractPrice" DataFormatString="{0:N}" HeaderText="PO Amount">
                                        <ItemStyle HorizontalAlign="Right" Width="80px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SuppName" HeaderText="Supplier">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left" Width="220px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RC_Name" HeaderText="Requesting Dept">
                                        <ItemStyle HorizontalAlign="Left" Width="210px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ProjectName" HeaderText="Project Name">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OBR_No" HeaderText="OBR No.">
                                        <ItemStyle HorizontalAlign="Center" Width="130px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="dvno" HeaderText="DV No." Visible="False">
                                        <ItemStyle Width="70px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="checkno" HeaderText="Check No." Visible="False">
                                        <ItemStyle Width="70px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="amountpaid" DataFormatString="{0:N}" HeaderText="Amount Paid" Visible="False">
                                        <ItemStyle HorizontalAlign="Right" Width="75px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="jevno" HeaderText="JEV No." Visible="False">
                                        <ItemStyle Width="70px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RespCenter" HeaderText="RespCenter" Visible="False"></asp:BoundField>
                                </Columns>

                                <PagerStyle HorizontalAlign="Center"></PagerStyle>

                                <EditRowStyle BorderColor="White"></EditRowStyle>
                            </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                             <td>
                                 <asp:Button ID="btnReturn" runat="server" Enabled="False" OnClick="btnReturn_Click" OnClientClick="StartProgressBar();" Text="RETURN" CssClass="CSButton" Width="150px" />
                             </td>
                         </tr>
                        <tr>
                             <td>
                                 &nbsp;
                             </td>
                         </tr>
                      <tr>
                            <td class="DivTitle" style="width: 98%; height: 26px;">
                                <strong>
                                    <asp:Label ID="Label1" runat="server" Text="Details"></asp:Label>
                                </strong>
                            </td>
                      </tr>
                      <tr align="center">
                          <td>
                              <table>
                                  <tbody>
                                      <tr>
                                          <td class="column_RightBold">Supplier Name :</td>
                                          <td class="column_Left" style="width:250px"><asp:TextBox ID="txtSupplierName" CssClass="txtbox_Var" runat="server" Width="200px"></asp:TextBox></td>

                                          <td class="column_RightBold">Invoice Number :</td>
                                          <td class="column_Left"><asp:TextBox ID="txtInvoiceNumber" CssClass="txtbox_Var" runat="server" AutoPostBack="true" OnTextChanged="txtInvoiceNumber_TextChanged"></asp:TextBox></td>

                                      </tr>
                                       <tr>
                                          <td class="column_RightBold">PO Number :</td>
                                          <td class="column_Left" style="width:250px"><asp:TextBox ID="txtPoNumber" CssClass="txtbox_Var" runat="server"></asp:TextBox></td>

                                          <td class="column_RightBold" style="width:200px">Invoice Date :</td>
                                          <td class="column_Left">
                                              <asp:TextBox ID="txtInvoiceDate" CssClass="txtbox_Var" runat="server"></asp:TextBox>&nbsp;(MM/DD/YYYY)
                                              <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtInvoiceDate" PopupButtonID="txtbox_Var"></cc1:CalendarExtender>
                                          </td>

                                      </tr>
                                       <tr>
                                          <td class="column_RightBold">PO Date :</td>
                                          <td class="column_Left" style="width:250px">
                                              <asp:TextBox ID="txtPodate" CssClass="txtbox_Var" runat="server"></asp:TextBox>&nbsp;(MM/DD/YYYY)
                                              <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPodate" PopupButtonID="txtbox_Var"></cc1:CalendarExtender>
                                          </td>

                                          <td class="column_RightBold" style="width:200px">Remarks :</td>
                                          <td class="column_Left" style="width:250px"><asp:TextBox ID="txtRemakrs" CssClass="txtbox_Var" runat="server" Width="250px"></asp:TextBox></td>

                                      </tr>
                                  </tbody>
                              </table>
                          </td>
                      </tr>
                      <tr>
                            <td class="DivTitle" style="width: 98%; height: 26px;">
                                <strong>
                                    <asp:Label ID="Label2" runat="server" Text="For Receiving"></asp:Label>
                                </strong>
                            </td>
                      </tr>
                      <tr>
                          <td>
                              <asp:GridView ID="grdItems" runat="server" Width="100%" SkinID="GridViewAA" HorizontalAlign="Center" DataKeyNames="Qty" >
                                            <Columns>
                                                <asp:TemplateField>
                                                     <HeaderTemplate>
        
                                                        <asp:CheckBox ID="chkSelectAll" runat="server" 
                                                                      Font-Bold="true" ForeColor="White" Font-Size="10pt" Font-Names="tahoma"
                                                                      AutoPostBack="True" 
                                                                      OnCheckedChanged="chkSelectAll_CheckedChanged" 
                                                                      Text="All" />
                                                    </HeaderTemplate>

                                                    <EditItemTemplate>
                                                        <asp:TextBox runat="server" ID="TextBox6"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Visible='<%#Bind("isVisible") %>' OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>

                                                <%-- <asp:TemplateField >
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHdrType" runat="server" Text="Description"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate >
                                                        <asp:Label ID="lblType" runat="server" Text='<%#Bind("Item_Desc") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>--%>

                                                <asp:BoundField DataField="Item_Desc" HeaderText="Description" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="left"></ItemStyle>
                                                </asp:BoundField>


                                                <asp:TemplateField HeaderText="Quantity">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtQty" runat="server" Width="60px" AutoPostBack="True" CssClass="txtbox_Amt" Text='<%#Bind("qty") %>' OnTextChanged="QtyText_TextChanged" Visible='<%# bind("isVisible") %>'></asp:TextBox>
                                                    </ItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Unit">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="cost" DataFormatString="{0:N}" HeaderText="Acquisition Cost">
                                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Market Value">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtMarketValue" runat="server" Width="90px" AutoPostBack="True" CssClass="txtbox_Amt" Text='<%#Bind("MarketValue") %>' Visible='<%# bind("isVisible") %>' OnTextChanged="txtMarketValue_TextChanged"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtMarketValue" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                                    </ItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Condition">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtCondition" runat="server" Width="120px" CssClass="txtboxinspection" AutoPostBack="True" Text='<%#Bind("Condition") %>' Visible='<%# bind("isVisible") %>'></asp:TextBox>
                                                    </ItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Location">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtLocation" runat="server" Width="200px" CssClass="txtboxinspection" AutoPostBack="True" Text='<%#Bind("Location") %>' Visible='<%# bind("isVisible") %>'></asp:TextBox>
                                                    </ItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                          </td>
                      </tr>
                      <tr>
                            <td class="DivTitle" style="width: 98%; height: 26px;">
                                <strong>
                                    <asp:Label ID="Label3" runat="server" Text="Receiving"></asp:Label>
                                </strong>
                            </td>
                      </tr>
                         <tr align="center">
                             <td style="height: 29px">
                                 <table>
                                     <tr>
                                         <td class="column_RightBold">Date : </td>
                                          <td class="column_Left"> 
                                              <asp:TextBox ID="txtDateReceivedBy" runat="server" CssClass="txtbox_Var"></asp:TextBox>&nbsp;(MM/DD/YYYY)
                                              <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDateReceivedBy" PopupButtonID="txtbox_Var"></cc1:CalendarExtender>

                                          </td>
                                     </tr>
                                     <tr>
                                         <td class="column_RightBold">Received By :</td>
                                          <td>
                                              <asp:DropDownList ID="ddReceiveBy" CssClass="drpdownCSS" Width="250px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddReceiveBy_SelectedIndexChanged"></asp:DropDownList></td>
                                     </tr>
                                     
                                 </table>
                             </td>
                         </tr>
                          <tr align="center" style="height:75px">
                              <td>
                                  <table>
                                      <tr align="center">
                                          <td><asp:Button ID="btnSave" runat="server" Width="100px" CssClass="CSButton" Text="Save" OnClick="btnSave_Click" Enabled="False" /></td>
                                          <td><asp:Button ID="btnPreview" runat="server" Width="100px" CssClass="CSButton" Text="Preview" Enabled="False" OnClick="btnPreview_Click" /></td>
                                      </tr>
                                  </table>
                              </td>
                          </tr>
                     
                     </table>
                 </div>
        </ContentTemplate>
    </asp:UpdatePanel>    
</asp:Content>