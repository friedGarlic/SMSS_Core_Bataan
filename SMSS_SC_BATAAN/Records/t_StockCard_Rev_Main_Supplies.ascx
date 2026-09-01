<%@ Control Language="VB" AutoEventWireup="false" CodeFile="t_StockCard_Rev_Main_Supplies.ascx.vb" Inherits="Records_t_StockCard_Rev_Main_Supplies" %>




<div class="DivTitle">LIST OF SUPPLIES</div>

<asp:GridView ID="grdStockList" runat="server" Width="98%" SkinID="GridViewAA"
    AllowPaging="True"
    DataKeyNames="Item_ID,Stock_ID"
    OnPageIndexChanging="grdStockList_PageIndexChanging"
    OnRowDataBound="grdStockList_RowDataBound"
    OnSelectedIndexChanged="grdStockList_SelectedIndexChanged">

    <Columns>


        <asp:BoundField DataField="Item_No" HeaderText="ITEM NO">
            <ItemStyle HorizontalAlign="Center" Width="8%" />
        </asp:BoundField>

        <asp:BoundField DataField="Unit" HeaderText="UNIT">
            <ItemStyle HorizontalAlign="Center" Width="10%" />
        </asp:BoundField>

        <asp:BoundField DataField="Item_Desc" HeaderText="ITEM DESCRIPTION">
            <ItemStyle HorizontalAlign="Left" Width="45%" />
        </asp:BoundField>

        <asp:BoundField DataField="Balance" HeaderText="CURRENT BALANCE">
            <ItemStyle HorizontalAlign="Center" Width="12%" />
        </asp:BoundField>

        <asp:BoundField DataField="Location" HeaderText="LOCATION">
            <ItemStyle HorizontalAlign="Left" Width="25%" />
        </asp:BoundField>

    </Columns>

    <PagerStyle Font-Bold="True" />
</asp:GridView>

<br />

<asp:Button ID="btnViewStockInventoryReport" runat="server" Width="250px"
    CssClass="CSButton" Text="VIEW STOCK INVENTORY REPORT"
    OnClick="btnViewStockInventoryReport_Click" />

<br /><br />

<div class="DivTitle">INCOMING DELIVERIES</div>

<asp:GridView ID="grdIncomingDeliveries" runat="server" Width="98%" SkinID="GridViewAA"
    AllowPaging="True" PageSize="5"
    DataKeyNames="Stock_ID"
    OnPageIndexChanging="grdIncomingDeliveries_PageIndexChanging"
    OnRowDataBound="grdIncomingDeliveries_RowDataBound"
    >

    <Columns>
        <asp:BoundField DataField="PO_No" HeaderText="PO NUMBER">
            <ItemStyle HorizontalAlign="Left"></ItemStyle>
        </asp:BoundField>

        <asp:BoundField DataField="Unit" HeaderText="Unit">
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:BoundField>

        <asp:BoundField DataField="Qty" HeaderText="QUANTITY" DataFormatString="{0:n0}">
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:BoundField>

        <asp:BoundField DataField="TotalPcs" HeaderText="TOTAL NO. OF PCS">
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:BoundField>

        <asp:BoundField DataField="ActualPrice" DataFormatString="{0:N}" HeaderText="ACTUAL PRICE">
            <ItemStyle HorizontalAlign="Right"></ItemStyle>
        </asp:BoundField>

        <asp:BoundField DataField="DeliveryDate" HeaderText="DELIVERY DATE">
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:BoundField>

        <asp:BoundField DataField="SuppName" HeaderText="SUPPLIER">
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:BoundField>
    </Columns>
</asp:GridView>

<br /><br />

<div class="DivTitle">INVENTORY CARD</div>

<table width="100%">
    <tr>
        <td style="width: 70%" align="center">
            <table width="100%">
                <tr>
                    <td style="width: 15%" class="column_RightBold" valign="top">Name :</td>
                    <td style="width: 35%" class="column_Left">
                        <asp:Label ID="lblMROsuppliesName" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold" valign="top">Unit :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMROsuppliesUnit" runat="server" Text="" Width="98%"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 15%" class="column_RightBold">Brand Name :</td>
                    <td style="width: 35%" class="column_Left">
                        <asp:Label ID="lblMROsuppliesBrandName" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold">Length :</td>
                    <td style="width: 35%" class="column_Left">
                        <asp:Label ID="lblMROsuppliesLength" runat="server" Text="" Width="98%"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 15%" class="column_RightBold">Size :</td>
                    <td style="width: 35%" class="column_Left">
                        <asp:Label ID="lblMROsuppliesSize" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold">Width :</td>
                    <td style="width: 35%" class="column_Left">
                        <asp:Label ID="lblMROsuppliesWidth" runat="server" Text="" Width="98%"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 15%" class="column_RightBold">Color :</td>
                    <td style="width: 35%" class="column_Left">
                        <asp:Label ID="lblMROsuppliesColor" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold">Height :</td>
                    <td style="width: 35%" class="column_Left">
                        <asp:Label ID="lblMROsuppliesHeight" runat="server" Text="" Width="98%"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 15%" class="column_RightBold">Unit Cost :</td>
                    <td style="width: 35%" class="column_Left">
                        <asp:Label ID="lblMROsuppliesUnitPrice" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold">Weight :</td>
                    <td style="width: 35%" class="column_Left">
                        <asp:Label ID="lblMROsuppliesWeight" runat="server" Text="" Width="98%"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 15%" class="column_RightBold">Reorder Pt. :</td>
                    <td style="width: 35%" class="column_Left">
                        <asp:Label ID="lblMROsuppliesReorderPt" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold">Quantity :</td>
                    <td style="width: 35%" class="column_Left">
                        <asp:Label ID="lblMROsuppliesQuantity" runat="server" Text="" Width="98%"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 15%" class="column_RightBold">Date :</td>
                    <td style="width: 35%" class="column_Left">
                        <asp:Label ID="lblMROsuppliesDate" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold"></td>
                    <td style="width: 35%" class="column_Left"></td>
                </tr>

                <tr>
                    <td colspan="4">
                        <fieldset>
                            <legend class="column_Left" style="font-family:Arial; color:#404040;"><strong>Location:</strong></legend>
                            <table width="100%">
                                <tr>
                                    <td class="column_RightBold">Warehouse :</td>
                                    <td class="column_Left">
                                        <asp:DropDownList ID="drpMROsuppliesWarehouse" runat="server" Width="90%" AutoPostBack="True"
                                            CssClass="drpdownCSS" Enabled="false"></asp:DropDownList>
                                    </td>

                                    <td class="column_RightBold">Bay :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMROsuppliesBay" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold" style="width:10%">Column :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMROsuppliesColumn" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold" style="width:10%">Floor :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMROsuppliesFloor" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Room :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMROsuppliesRoom" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold" style="width:10%">Shelves :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMROsuppliesShelves" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold">Rack :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMROsuppliesRack" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold">Bin :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMROsuppliesBin" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
            </table>
        </td>

        <td style="width: 30%" align="center">
            <img alt="" height="160" src="../images/Default_Image.jpg" width="80%" />
        </td>
    </tr>
</table>



<br />

<asp:Panel ID="pnlLedger" runat="server" Width="100%" CssClass="PanelSize" ScrollBars="Vertical">
    <asp:GridView ID="grdLedger" runat="server" Width="100%" SkinID="GridViewAA" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="dDate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date">
                <HeaderStyle HorizontalAlign="Center" Height="30px" Width="80px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="8%" />
            </asp:BoundField>

            <asp:BoundField DataField="Trans_Type" HeaderText="PARTICULARS">
                <HeaderStyle HorizontalAlign="Center" Height="30px" Width="40px" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="40%" />
            </asp:BoundField>

            <asp:BoundField DataField="BalanceUnit" HeaderText="UNIT">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="8%" />
            </asp:BoundField>

            <asp:BoundField DataField="Cost" HeaderText="UNIT PRICE" DataFormatString="{0:N2}">
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="10%" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>

            <asp:BoundField DataField="DebitQty" HeaderText="Debit Qty" DataFormatString="{0:N0}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>

            <asp:BoundField DataField="DebitCost" HeaderText="Debit Cost" DataFormatString="{0:N2}">
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="10%" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>

            <asp:BoundField DataField="CreditQty" HeaderText="Credit Qty" DataFormatString="{0:N0}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>

            <asp:BoundField DataField="CreditCost" HeaderText="Credit Cost" DataFormatString="{0:N2}">
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="10%" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>

            <asp:BoundField DataField="BalQty" HeaderText="Balance Qty" DataFormatString="{0:N0}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>

            <asp:BoundField DataField="BalCost" HeaderText="Balance Cost" DataFormatString="{0:N2}">
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="10%" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Panel>
