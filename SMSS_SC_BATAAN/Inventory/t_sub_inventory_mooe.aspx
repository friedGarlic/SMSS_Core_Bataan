<%@ Page 
    Title ="MOOE"
    MasterPageFile="~/MasterPage.master"
    EnableEventValidation="false" 
    Language="VB"
    AutoEventWireup="false"
    CodeFile="t_sub_inventory_mooe.aspx.vb" 
    Inherits="Inventory_t_sub_inventory_mooe"
    StylesheetTheme="SkinFile"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">






</script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript">

    </script>

      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table width="100%">
                        <tr>
                           <td align="center" colspan="7" class="DivTitle" style="width: 100%"> Sub Inventory Per Department</td>
                        </tr>
                        <tr align="center">
                            <td>
                               <table width="70%">
                                  <tr>
                                      <td class="column_RightBold">Department : </td>
                                      <td colspan="3" class="column_Left">
                                          <asp:DropDownList ID="drpDepartment" runat="server" AutoPostBack="True" CssClass="drpdownCSS" Width="350px">
                                          </asp:DropDownList>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td class="column_RightBold" style="height: 21px">Classification : </td>
                                      <td class="column_Left" style="height: 21px">
                                          <asp:DropDownList ID="drpClassification" runat="server" AutoPostBack="True" CssClass="drpdownCSS" Width="220px" OnSelectedIndexChanged="drpClassification_SelectedIndexChanged">
                                          </asp:DropDownList>

                                      </td>
                                      <td class="column_RightBold" style="height: 21px"> Sub-Classification :</td>
                                      <td class="column_Left" style="height: 21px">
                                          <asp:DropDownList ID="drpSub_Classification" runat="server" AutoPostBack="True" CssClass="drpdownCSS" Width="220px" OnSelectedIndexChanged="drpSub_Classification_SelectedIndexChanged">
                                          </asp:DropDownList>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td class="column_RightBold">General Account : </td>
                                      <td colspan="3" class="column_Left">
                                           <asp:DropDownList ID="drpGeneral_Account" runat="server" AutoPostBack="True" CssClass="drpdownCSS" Width="350px" OnSelectedIndexChanged="drpGeneral_Account_SelectedIndexChanged">
                                          </asp:DropDownList>
                                           <asp:HiddenField ID="hdnItemNo" runat="server" />
                                      </td>
                                  </tr>
                                   <tr>
                                      <td class="column_RightBold">Category : </td>
                                      <td class="column_Left">
                                          <asp:DropDownList ID="drpCategory" runat="server" AutoPostBack="True" CssClass="drpdownCSS" Width="220px" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged">
                                                
                                          </asp:DropDownList>
                                      </td>
                                      <td class="column_RightBold">Sub-Category :</td>
                                      <td class="column_Left">
                                          <asp:DropDownList ID="drpSub_Category" runat="server" AutoPostBack="True" CssClass="drpdownCSS" Width="220px" OnSelectedIndexChanged="drpSub_Category_SelectedIndexChanged">
                                          </asp:DropDownList>
                                      </td>
                                  </tr>
                                  
                               </table>
                            </td>
                        </tr>
                        <tr align="center">
                            <td>
                              <table>
                                  <tr>
                                      <td class="column_RightBold">Description :</td>
                                      <td><asp:TextBox ID="txtSearch" CssClass="txtbox_Var" Width="450px" runat="server"></asp:TextBox></td>
                                      <td>
                                      <asp:Button ID="btnSearch" runat="server" CssClass="CSButton" Text="Search" OnClick="btnSearch_Click" /></td>
                                  </tr>
                              </table>
                            </td>
                        </tr>
                        <tr>
                           <td align="center" colspan="7" class="DivTitle" style="width: 100%">List of Supplies</td>
                        </tr>
                        <tr align="center">
                            <td>
                                <asp:GridView ID="grdStockList" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="Item_ID,GA_ID,reorderpt"
                                AllowPaging="True" OnRowDataBound="grdStockList_RowDataBound" OnSelectedIndexChanged="grdStockList_SelectedIndexChanged" >
                                <Columns>
                                    <asp:BoundField DataField="Item_ID" HeaderText="Item No.">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="description" HeaderText="UNIT">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Item_Desc" HeaderText="ITEM DESCRIPTION">
                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Balance" HeaderText="Location">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Balance" HeaderText="Current Bal.">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Balance" HeaderText="Issued Qty">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                     <asp:BoundField DataField="Balance" HeaderText="ReOrder Pt.">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>


                                   
                                </Columns>
                                 <PagerStyle Font-Bold="True" />
                            </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                           <td align="center" colspan="7" class="DivTitle" style="width: 100%">Incoming Deliveries</td>
                        </tr>
                        <tr>
                            
                            <td>
                                    <asp:GridView ID="grdsupplies" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="POHdr_ID,StockID,GA_ID,Received_ID"
                                AllowPaging="True"  PageSize="5" >
                                <Columns>
                                    <asp:BoundField DataField="PO_No" HeaderText="PO NUMBER">
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="batch" HeaderText="BATCH" Visible ="FALSE">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="lot" HeaderText="LOT" Visible ="FALSE">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Unit" HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="qty" HeaderText="QUANTITY" DataFormatString="{0:n0}">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="qtybox" HeaderText="QTY/BOX" Visible="False">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalPcs" HeaderText="TOTAL NO. OF PCS">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ActualPrice" DataFormatString="{0:N}" HeaderText="ACTUAL PRICE">
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="deliverydate" HeaderText="DELIVERY DATE">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SuppName" HeaderText="SUPPLIER">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            </td>
                          
                        </tr>
                        <tr>
                           <td align="center" colspan="7" class="DivTitle" style="width: 100%">Inventory Card</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="grdLedger" runat="server" Width="100%" SkinID="GridViewAA" >
                                                    <Columns>
                                                       
                                                        <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="2%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Trans_Type" HeaderText="PARTICULARS" >
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Top" Width="46%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ref" HeaderText="Ref. No." Visible ="FALSE">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="8%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="AccountablePerson" HeaderText="Accountable Person" Visible ="FALSE">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="8%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Department" HeaderText="Dept / Office" Visible ="FALSE">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="position" HeaderText="Position" Visible="False" >
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="acceptedby" HeaderText="Accepted By" Visible ="FALSE">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                     <%--   <asp:BoundField DataField="inspectedby" HeaderText="UNIT">--%>
                                                            <asp:BoundField DataField="BalanceUnit" HeaderText="UNIT">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="25px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="2%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Cost" HeaderText="UNIT PRICE" SortExpression="BalUnit">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DebitQty" HeaderText="Debit Qty" SortExpression="DebitQty">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText="Debit Cost" SortExpression="DebitCost">
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="9%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CreditQty" HeaderText="Credit Qty" SortExpression="CreditQty">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText="Credit Cost" SortExpression="CreditCost">
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="9%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BalQty" HeaderText="Balance Qty" SortExpression="BalQty">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BalCost" DataFormatString="{0:N}" HeaderText="Balance Cost" SortExpression="BalCost">
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="9%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
      </asp:UpdatePanel>



</asp:Content>



