<%@ Page 
    Language="VB" 
    AutoEventWireup="false" 
    MasterPageFile="~/MasterPage.master"
    EnableEventValidation="false"
    CodeFile="t_repeat_order_approval.aspx.vb" 
    Inherits="bidding_t_repeat_order_approval"
    Title="Repeat Order Approval" 
    StylesheetTheme="SkinFile"%>
    
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
                            <td style="width: 100%" class="DivTitle">Repeat Order Approval</td>
                     </tr>
                     <tr align="center">
                            <td>
                                   <asp:GridView runat="server" ID="grdRO" SkinID="GridViewAA" Width="90%" EmptyDataText="No Data Found."
                                                                DataKeyNames="prhdr_id" OnSelectedIndexChanged="grdRO_SelectedIndexChanged">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkSelect" CssClass="LinkBtnSelect" Font-Underline="false" Text="Select" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="7%" />
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-Width="10%" DataField="PO_No" HeaderText="PO No." ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField ItemStyle-Width="30%" DataField="RC_Name" HeaderText="Requesting Department" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField ItemStyle-Width="20%" DataField="ProjectName"  HeaderText="Project Name" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField ItemStyle-Width="20%" DataField="SuppName"  HeaderText="Supplier" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField ItemStyle-Width="20%" DataField="ContractPrice"  HeaderText="Amount" ItemStyle-HorizontalAlign="Right" />

                                                                </Columns>
                                    </asp:GridView>
                            </td>
                       </tr>
                       <tr>
                            <td style="width: 100%" class="DivTitle">List of Goods</td>
                           
                       </tr>
                       <tr align="center">
                            <td>
                                <asp:GridView ID="grdListofItem" runat="server" SkinID="GridViewAA" EmptyDataText="No Data Found." DataKeyNames="">
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

                                              
                                          <asp:BoundField ItemStyle-Width="50%" DataField="ItemCompleteDesc" HeaderText="Item Description" ItemStyle-HorizontalAlign="Left" />
                                          <asp:BoundField ItemStyle-Width="15%" DataField="qty"  HeaderText="Previous Qty" ItemStyle-HorizontalAlign="Left" />
                                          <asp:TemplateField HeaderText="Repeat Order Qty" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRepeatOrderQty" runat="server" CssClass="txtbox_Var"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                          </asp:TemplateField>
                                          <asp:BoundField ItemStyle-Width="15%" DataField="cost"  HeaderText="Price" ItemStyle-HorizontalAlign="Right" />

                                    </Columns>
                                </asp:GridView>
                                <asp:HiddenField ID="txtHiddenReceiveQty" runat="server" />
                            </td>
                        </tr>
                       <tr align="center" style="height:75px">
                            <td>
                                <table>
                                    <tr>
                                        <td class="column_RightBold">Approved By :</td>
                                        <td class="column_Left"><asp:DropDownList ID="drpApproved" CssClass="drpdownCSS" Width="200px" runat="server"></asp:DropDownList></td>
                                    </tr>
                                     <tr>
                                        <td class="column_RightBold">Position :</td>
                                        <td class="column_Left"><asp:TextBox ID="txtPosition" CssClass="txtbox_Var" runat="server"></asp:TextBox></td>
                                    </tr>
                               </table>
                            </td>
                       </tr>
                       <tr align="center" style="height:20px">
                         <td>
                              <table>
                                  <tr>
                                      <td><asp:Button ID="btnSave" runat="server" CssClass="CSButton" Width="100px" Text ="Approved" /> </td>
                                       <td><asp:Button ID="btnReturn" runat="server" CssClass="CSButton" Width="100px" Text ="Return" /> </td>
                                  </tr>
                              </table>
                          </td>
                      </tr>
                     
                  </table>
              </div>
          </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>
