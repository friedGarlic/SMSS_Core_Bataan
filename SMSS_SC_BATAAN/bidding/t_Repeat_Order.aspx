<%@ Page 
    Language="VB" 
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" 
    EnableEventValidation="false"
    CodeFile="t_Repeat_Order.aspx.vb" 
    Inherits="bidding_t_Repeat_Order"
    Title="Repeat Order" 
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">




</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table width="100%">
                        <tr>
                            <td style="width: 100%" class="DivTitle">Repeat Order</td>
                        </tr>
                        <tr align="center">
                            <td>
                                  <asp:GridView runat="server" ID="grdRO" SkinID="GridViewAA" Width="90%" EmptyDataText="No Data Found."
                                    DataKeyNames="prhdr_id, pr_no" OnSelectedIndexChanged="grdRO_SelectedIndexChanged" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkSelect" CssClass="LinkBtnSelect" Font-Underline="false" Text="Select" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>

  
                                        <asp:BoundField ItemStyle-Width="15%" DataField="pr_no" HeaderText="PR No." ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField ItemStyle-Width="15%" DataField="DateApproved" HeaderText="Date Approved" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:MM/dd/yyyy}" />
                                        <asp:BoundField ItemStyle-Width="15%" DataField="ABC" HeaderText="ABC" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" />
                                        <asp:BoundField ItemStyle-Width="30%" DataField="remarks" HeaderText="Remarks" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField ItemStyle-Width="15%" DataField="OBR_No" HeaderText="OBR No." ItemStyle-HorizontalAlign="Center" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%" class="DivTitle">List of Goods</td>
                        </tr>
                        <tr align="center">
                            <td>
                                <asp:GridView ID="grdListofItem" runat="server" SkinID="GridViewAA" OnRowDataBound="grdListofItem_RowDataBound" EmptyDataText="No Data Found." DataKeyNames=""  ShowFooter="True">
                                    <Columns>
                                         <asp:TemplateField>
                                                    <EditItemTemplate>
                                                        <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="CheckBox2" runat="server" Font-Bold="true" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" AutoPostBack="true" Text="All" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="cbInspection" runat="server" AutoPostBack="True" ></asp:CheckBox>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                          </asp:TemplateField>

                                              
                                          <asp:BoundField ItemStyle-Width="60%" DataField="ItemCompleteDesc" HeaderText="Item Description" ItemStyle-HorizontalAlign="Left" />
                                          <asp:BoundField ItemStyle-Width="10%" DataField="qty" Visible="false"  HeaderText="Previous Qty" ItemStyle-HorizontalAlign="center" />
                                          <asp:TemplateField HeaderText="Repeat Order Qty" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRepeatOrderQty" runat="server" Text='<%# Bind("Repeat_Order_Qty") %>' CssClass="txtbox_Var"></asp:TextBox>
                                                    </ItemTemplate>
                                              <FooterTemplate>
                                                <asp:Label ID="lblTotalRepeatOrderQty" Text ="Total :" runat="server"></asp:Label>
                                              </FooterTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <FooterStyle HorizontalAlign="Right" />
                                          </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Price" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("cost", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:HiddenField ID="txtHiddenReceiveQty" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%" class="DivTitle">Details</td>
                        </tr>
                        <tr align="center">
                            <td>
                                <table>
                                    <tr>
                                        <td class="column_RightBold">PR Number :</td>
                                        <td class="column_Left"><asp:TextBox ID="txtPR_No" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                        <td class="column_RightBold">OBR No :</td>
                                        <td class="column_Left"><asp:TextBox ID="txtOBR_No" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="column_RightBold">Department :</td>
                                        <td class="column_Left"><asp:DropDownList ID="drpDepartment" runat="server" CssClass="drpdownCSS" Width="300px"></asp:DropDownList></td>
                                        <td class="column_RightBold">Payee :</td>
                                        <td class="column_Left"><asp:TextBox ID="txtPayee" runat="server" CssClass="txtbox_Var" Width="200px">Purchase Request</asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="column_RightBold">Function :</td>
                                        <td class="column_Left">
                                            <asp:DropDownList ID="drpFunction" runat="server" Width="300px" AutoPostBack="True" CssClass="drpdownCSS" AppendDataBoundItems="True">
                                               
                                            </asp:DropDownList>
                                        </td>
                                        <td class="column_RightBold">Payee Address :</td>
                                        <td class="column_Left"><asp:TextBox ID="txtPayeeAddress" runat="server" CssClass="txtbox_Var" Width="200px">Tuguegarao City, Cagayan</asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="column_RightBold">P/P/A :</td>
                                        <td class="column_Left">
                                             <asp:DropDownList ID="drpPPA" runat="server" Width="300px" AutoPostBack="True" CssClass="drpdownCSS">
                                              
                                            </asp:DropDownList>
                                        </td>
                                        <td class="column_RightBold">Requesting Person :</td>
                                        <td class="column_Left"><asp:DropDownList ID="drpRequestingPerson" runat="server" CssClass="drpdownCSS" Width="300px"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td class="column_RightBold">Nature of Transaction :</td>
                                        <td class="column_Left">
                                             <asp:DropDownList ID="drpNature" runat="server" Width="300px" AutoPostBack="True" CssClass="drpdownCSS" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="2">Maintenance and Other Operating Expenses</asp:ListItem>
                                                <asp:ListItem Value="3">Capital Outlays</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="column_RightBold">Approved By :</td>
                                        <td class="column_Left"><asp:DropDownList ID="drpApprovedBy" runat="server" CssClass="drpdownCSS" Width="300px"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td class="column_RightBold">Account Title :</td>
                                        <td class="column_Left">
                                             <asp:DropDownList ID="drpAccounts" runat="server" Width="300px" AutoPostBack="True" CssClass="drpdownCSS" AppendDataBoundItems="True">
                                               
                                            </asp:DropDownList>
                                        </td>
                                     <td class="column_RightBold">Supplier :</td>
<td class="column_Left">
    <asp:DropDownList ID="drpSupllier" runat="server" Width="300px" AutoPostBack="True" CssClass="drpdownCSS" AppendDataBoundItems="True" OnSelectedIndexChanged="drpSupllier_SelectedIndexChanged">
    </asp:DropDownList>
</td>

                                    </tr>
                                    <tr>
                                        <td class="column_RightBold">Purpose :</td>
                                        <td class="column_Left"><asp:TextBox ID="txtPurpose" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                        <td class="column_RightBold">Supplied Address :</td>
                                        <td class="column_Left"><asp:TextBox ID="txtSupplierAddress" runat="server" CssClass="txtbox_Var" Width="291px"></asp:TextBox></td>
                                    </tr>
                                   


                                </table>
                            </td>
                        </tr>
                        <tr style="height:10px">
                            <td></td>
                        </tr>
                        <tr align="center">
                                        <td>
                                            <table>
                                                <tr>
                                                   <td>
                                                       <asp:Button ID="btnSave" runat="server" CssClass="CSButton" Width="100px" Text="Save" OnClick="btnSave_Click" /></td>
                                                   <td>
                                                       <asp:Button ID="btnCancel" runat="server" CssClass="CSButton" Width="100px" Text="Cancel" OnClick="btnCancel_Click" /></td>
                                                </tr>
                                            </table>
                                        </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>