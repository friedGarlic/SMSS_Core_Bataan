<%@ Page 
    Language="VB" 
     MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" 
    CodeFile="t_List_of_Approved_PO.aspx.vb" 
    Inherits="procurement_t_List_of_Approved_PO"
    Title="List of Approved PO" 
    EnableEventValidation="false" 
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
                         <td style="width:1%"></td>
                         <td style="width:98%" class="PageTitle">List of Approved PO</td>
                         <td style="width:1%"></td>
                     </tr>
                     <tr>
                         <td style="width:1%"></td>
                         <td style="width:98%">
                             <table>
                                 <tr>
                                     <td class="column_RightBold">Search By :</td>
                                     <td>
                                         <asp:DropDownList ID="ddSearchOption" runat="server" CssClass="drpdownCSS" Width="200px"  AutoPostBack="True" OnSelectedIndexChanged="ddSearchOption_SelectedIndexChanged">
                                             <asp:ListItem Selected="True" Value="1">ALL</asp:ListItem>
                                             <asp:ListItem Value="2">PO Number</asp:ListItem>
                                             <asp:ListItem Value="3">Delivery Date</asp:ListItem>
                                         </asp:DropDownList>                                                                
                                     </td>
                                     <td>
                                         <asp:TextBox ID="txtPO" runat="server" CssClass="txtbox_Var" Width="150px" Visible="false"></asp:TextBox>
                                         <asp:TextBox ID="txtDeliveryDate" runat="server" CssClass="txtbox_Var" Width="150px" Visible="false"></asp:TextBox>
                                         <asp:Button ID="btnSearch" OnClick ="btnSearch_Click" runat="server" CssClass="CSButton"  Text="Search" Visible="false" />
                                     </td>
                                    
                                 </tr>
                                
                                  <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtDeliveryDate" PopupButtonID="ImageButton1"></cc1:CalendarExtender>
                             </table>
                         </td>
                         <td style="width:1%"></td>
                     </tr>
                     <tr>
                                     <td style="width:1%"></td>
                                      <td style="width:98%">
                                          <table width="100%">
                                              <tr>
                                                  <td>
                                                      <asp:GridView ID="gvPurchase_Order" runat="server" Width="98%" Font-Bold="False" AllowPaging="True" SkinID="GridViewAA"
                                                          OnRowDataBound="gvPurchase_Order_RowDataBound" DataKeyNames="pr_no,pr_hrd_no,Supplier_ID,POHdr_ID"
                                                          AutoGenerateColumns="False"
                                                          EmptyDataText="No Data Found." OnSelectedIndexChanged="gvPurchase_Order_SelectedIndexChanged">
                                                          <Columns>
                                                              <asp:BoundField DataField="pr_no" HeaderText="PR / Reference Number">
                                                                  <FooterStyle HorizontalAlign="Left"></FooterStyle>
                                                                  <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                  <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                              </asp:BoundField>
                                                              <asp:BoundField DataField="Supplier" HeaderText="Supplier" >
                                                                  <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                                                  <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                  <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                              </asp:BoundField>
                                                              <asp:BoundField DataField="Po_Amount" HeaderText="Po Amount">
                                                                  <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                                                  <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                  <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                              </asp:BoundField>
                                                              <asp:BoundField DataField="RC_Description" HeaderText="Requested Department">
                                                                  <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                                                  <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                  <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                                              </asp:BoundField>
                                                       
                                                              <asp:BoundField DataField="Delivery_Date" HeaderText="Delivery Date">
                                                                  <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                                                  <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                  <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                              </asp:BoundField>
                                                                     <asp:BoundField DataField="Extension_Date" HeaderText="Extension Date">
                                                                  <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                                                  <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                  <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                              </asp:BoundField>
                                                              <asp:BoundField DataField="Status" HeaderText="Status">
                                                                  <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                                                  <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                  <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                              </asp:BoundField>
                                                          </Columns>
                                                          <FooterStyle HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
                                                      </asp:GridView>
                                                  </td>
                                              </tr>
                                          </table>
                                      </td>
                                      <td style="width:1%"></td>
                                 </tr>
                                 <tr>
                                     <td style="width:1%"></td>
                                     <td style="width:98%">
                                         <table>
                                             <tr>
                                                 <td class="column_Right">Extention Date :</td>
                                                 <td class="column_Left"><asp:TextBox ID="txtExtension" runat="server"></asp:TextBox></td>
                                             </tr>
                                         </table>
                                          <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txtExtension" PopupButtonID="ImageButton1"></cc1:CalendarExtender>
                                     </td>
                                     <td style="width:1%"></td>
                                 </tr>
                                 <tr align="center">
                                        <td style="width:1%"></td>
                                        <td style="width:98%">
                                            <table>
                                                <tr>
                                                    <td><asp:Button ID="btnSave" runat="server" Text="Save" Width="150px" CssClass="CSButton" Enabled="false" OnClick="btnSave_Click" /></td>
                                                    
                                                    <td><asp:Button ID="btnPreviewPO" runat="server" Text="Preview PO" Width="150px"  CssClass="CSButton" Enabled="false" /></td>
                                                    <td><asp:Button ID="btnPReview" runat="server" Text="Preview Contract" Width="150px"  CssClass="CSButton" Enabled="false" /></td>
                                                    <td><asp:Button ID="btnReturnPo" runat="server" Text="Return PO" Width="150px"  CssClass="CSButton" Enabled="false" OnClick="btnReturnPo_Click" /></td>

                                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender5" runat="server" TargetControlID="btnReturnPo" ConfirmText="Are you sure you want to return this transaction?"></cc1:ConfirmButtonExtender>

                                                    <td><asp:Button ID="btnCancelPO" runat="server" Text="Cancel PO" Width="150px"  CssClass="CSButton" Enabled="false" OnClick="btnCancelPO_Click" /></td>
                                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnCancelPO" ConfirmText="Are you sure you want to cancel this transaction?"></cc1:ConfirmButtonExtender>

                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width:1%"></td>
                                 </tr>


                                 
                                

                 </table>
             </div>
         </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>