<%@  Page 
    Title="Encoding of Livestock"
    Language="VB" 
    EnableEventValidation="false" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="t_Live_Stocks.aspx.vb" 
    Inherits="Inventory_t_Live_Stocks"
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">




</script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
    </script>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>
                  <div>
                      <table width="100%">
                          <tr>
                              <td style="width:1%"></td>
                              <td style="width:98%" class="PageTitle">List of Livestocks</td>
                              <td style="width:1%"></td>
                          </tr>
                          <tr>
                              <td style="width:1%"></td>
                              <td style="width:98%">
                                  <table width="100%" style="align-content:center">
                                      <tr>
                                          <td class="column_RightBold">Sub Classification : </td>
                                          <td class="column_Left">
                                              <asp:DropDownList ID="drpSubClassification" runat="server" CssClass="drpdownCSS" Width="200px"  AutoPostBack="True" >
                                              </asp:DropDownList>   

                                          </td>
                                          <td class="column_RightBold">Source of Livestock : </td>
                                          <td class="column_Left">
                                              <asp:TextBox ID="txtSourceofLivestock" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                          <td rowspan="4"> 
                                            
                                              <asp:Image ID="imgpropertydocs" runat="server" Height="88px" ImageUrl="~/images/blankImage.jpg" Width="96px" />
                                            
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="column_RightBold">Breed : </td>
                                          <td class="column_Left">
                                              <asp:DropDownList ID="drpBreed" runat="server" CssClass="drpdownCSS" Width="200px"  AutoPostBack="True" >
                                              </asp:DropDownList>   
                                              <asp:LinkButton ID="lnkBreed" runat="server" OnClick="lnkBreed_Click">New Breed</asp:LinkButton></td>
                                          <td class="column_RightBold">Remarks : </td>
                                          <td class="column_Left"><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                         
                                      </tr>
                                      <tr>
                                          <td class="column_RightBold">&nbsp;Description :</td>
                                          <td class="column_Left">
                                              <asp:TextBox ID="txtDescriptionLivestock" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox>
                                          </td>
                                          <td class="column_Right">
                                              <asp:LinkButton ID="lnkAddStockInformation" runat="server" OnClick="lnkAddStockInformation_Click">Add Livestock Information</asp:LinkButton></td>
                                          <td></td>
                                       
                                          
                                      </tr>
                                      <tr>
                                          <td class="column_RightBold">Quantity :</td>
                                          <td class="column_Left">
                                              <asp:TextBox ID="txtQuantity" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox>
                                          </td>
                                          <td></td>
                                          <td></td>
                                      </tr>
                                       <tr>
                                          <td></td>
                                          <td></td>
                                          <td></td>
                                          <td>
                                              <asp:Button ID="btnSave" runat="server" CssClass="CSButton" Text="SAVE" Width="80px" />
                                              <asp:Button ID="btnClear" runat="server" CssClass="CSButton"  Text="Clear" Width="80px" onClick="clearLivestockBtn_Click"/>
                                                 
                                           </td>
                                          <td><asp:Button ID="btnUpload" runat="server" CssClass="CSButton"  Text="UPLOAD" Width="100px" />
                                                 </td>
                                      </tr>
                                  </table>
                              </td>
                              <td style="width:1%"></td>
                          </tr>
                          <tr>
                              <td style="width:1%"></td>
                              <td style="width:98%">
                                   <asp:GridView ID="grdLedger1" runat="server" Width="100%" SkinID="GridViewAA" HorizontalAlign="Center" Font-Size="8pt" OnDataBound = "OnDataBound" >
                                                        
                                                        <Columns>
                                                            
                                                            <asp:TemplateField>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="CheckBox2" runat="server" Font-Bold="true" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" Text="All"></asp:CheckBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="cbInspection" runat="server" AutoPostBack="True" OnCheckedChanged="cbInspection_CheckedChanged"></asp:CheckBox>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date" Visible="false">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Trans_Type" HeaderText="Particulars">
                                                                <ItemStyle HorizontalAlign="Left" Width="46%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ref" HeaderText="Ref No">
                                                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AccountablePerson" HeaderText="Accountable Person" Visible="false">
                                                                <ItemStyle HorizontalAlign="Left" Width="8%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Department" HeaderText="Office" Visible="false">
                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="acceptedby" HeaderText="Accepted By" Visible="false">
                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="inspectedby" HeaderText="Inspected By" Visible="false">
                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BalanceUnit" HeaderText="Ref No."  Visible="false">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="UnitPrice" DataFormatString="{0:N}" HeaderText="Unit Price" Visible="false" >
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="DebitQty" HeaderText="Debit Qty" Visible="false">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText=" ">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CreditQty" HeaderText="Credit Qty" Visible="false">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText=" ">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BalQty" HeaderText="Bal Qty" Visible="false">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BalCost" DataFormatString="{0:N}" HeaderText=" ">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                              </td>
                              <td style="width:1%"></td>
                          </tr>
                      </table>

                  </div>
               <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label1" PopupControlID="popupParticular" CancelControlID="ImageButton2" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
               <asp:Panel ID="popupParticular" runat="server" CssClass="Panel_Popup">
                   <table>
                       <tr>
                            <td style="width: 100%; height: 30px"  class="DivTitle">
                             LIVESTOCK INFORMATION
                            </td>
                       </tr>
                       <tr>
                           <td>
                                 <asp:GridView ID="grdPropertyInfo" runat="server" SkinID="gvnew" AutoGenerateColumns="false"
                            EmptyDataText="No records has been added."  Width="510px">
                                <Columns>
                                  

                                    <asp:TemplateField HeaderText="Live Property No." >
                                        <ItemTemplate>
                                         <asp:TextBox ID="txtLivePropertyNo" runat ="server" Width ="150px" AutoPostBack="true" OnTextChanged="txtPropertyNo_TextChanged"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Date Aquired" >
                                        <ItemTemplate>
                                         <asp:TextBox ID="txtDateAquired" runat ="server" Width ="150px"></asp:TextBox>
                                         <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDateAquired" PopupButtonID="txtDateAquired"></cc1:CalendarExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Age">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtAge" runat ="server" Width ="50px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField  HeaderText="Weight">
                                        <ItemTemplate>
                                         <asp:TextBox ID="txtWeight" runat ="server"  Width ="50px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField  HeaderText="Price">
                                        <ItemTemplate>
                                         <asp:TextBox ID="txtPrice" runat ="server"  Width ="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                  </Columns>
                            </asp:GridView>
                           </td>
                       </tr>
                       <tr align="center">
                            <td>
                                <table>
                                    <tr>
                                        <td>

                                            <asp:Button ID="btnProceed" runat="server" CssClass="CSButton" Width="100px" Text="PROCEED" OnClick="btnProceed_Click" Height="22px" />&nbsp
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancelProperty" runat="server" CssClass="CSButton" Width="100px" Text="CANCEL" OnClick="btnCancelProperty_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                       <tr>
                           
                           <td style="display:none"> <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
                       </tr>
                   </table>
               </asp:Panel>

                <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label2" PopupControlID="popupBreed" CancelControlID="ImageButton2" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
               <asp:Panel ID="popupBreed" runat="server" CssClass="Panel_Popup">
                   <table>
                       <tr>
                            <td style="width: 100%; height: 30px"  class="DivTitle">
                             List of Breed
                            </td>
                       </tr>
                      <tr align="center">
                          <td>
                              <table>
                                  <tr>
                                      <td class="column_RightBold">Breed Name :</td>
                                      <td class="column_Left">
                                          <asp:TextBox ID="txtBreedName" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                      <td class="column_RightBold">Description :</td>
                                      <td class="column_Left">
                                          <asp:TextBox ID="txtDescription" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                  </tr>
                                  <tr>
                                      <td class="column_RightBold">Origin :</td>
                                      <td class="column_Left">
                                          <asp:TextBox ID="txtOrigin" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                      <td class="column_RightBold">Average Size :</td>
                                      <td class="column_Left">
                                          <asp:TextBox ID="txtAverageSize" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                  </tr>
                                  <tr>
                                      <td class="column_RightBold" style="height: 23px">AverageLifespan :</td>
                                      <td class="column_Left" style="height: 23px">
                                          <asp:TextBox ID="txtAverageLifespan" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                      <td style="height: 23px"></td>
                                      <td style="height: 23px"></td>
                                  </tr>
                                  <tr align="center">
                                      <td colspan="4">
                                          <asp:Button ID="btnSAVEBreed" runat="server" Width="100px" CssClass="CSButton" Text="SAVE" OnClick="btnSAVEBreed_Click" /> &nbsp
                                          <asp:Button ID="btnClearBreed" runat="server" Width="100px" CssClass="CSButton"  Text="CLEAR" OnClick="btnClearBreed_Click" />&nbsp
                                          <asp:Button ID="btnCloseBreed" runat="server" Width="100px" CssClass="CSButton"  Text="CLOSE" OnClick="btnCloseBreed_Click" />
                                      </td>
                                    
                                  </tr>
                              </table>
                          </td>
                      </tr>
                       <tr>
                           <td>
                               <asp:GridView ID="gvBreeds" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" SkinID="GridViewAA" 
                                   AllowPaging="True" OnRowDataBound="gvBreeds_RowDataBound" OnSelectedIndexChanged="gvBreeds_SelectedIndexChanged" DataKeyNames="BreedID,BreedName,Description,Origin,AverageSize,AverageLifespan" >
                                   <Columns>
                                       <asp:BoundField DataField="BreedName" HeaderText="Breed Name" SortExpression="BreedName">
                                           <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                           <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                       </asp:BoundField>
                                       <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description">
                                           <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                           <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                       </asp:BoundField>
                                       <asp:BoundField DataField="Origin" HeaderText="Origin" SortExpression="Origin">
                                           <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                           <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                       </asp:BoundField>
                                       <asp:BoundField DataField="AverageSize" HeaderText="Average Size" SortExpression="AverageSize">
                                           <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                           <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                       </asp:BoundField>
                                       <asp:BoundField DataField="AverageLifespan" HeaderText="Average Lifespan" SortExpression="AverageLifespan">
                                           <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                           <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                       </asp:BoundField>
                                   </Columns>
                               </asp:GridView>
                           </td>
                       </tr>
                       <tr>
                           <asp:HiddenField ID="hndBreedID" runat="server" />
                            <asp:HiddenField ID="hf_PropertyDetai_ID" runat="server" />
                            <asp:HiddenField ID="hf_Property_ID" runat="server" />
                            <asp:HiddenField ID="hf_Ledger_ID" runat="server" />

                           <td style="display:none"> <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
                       </tr>
                   </table>
               </asp:Panel>
           </ContentTemplate>
      </asp:UpdatePanel>
</asp:Content>



