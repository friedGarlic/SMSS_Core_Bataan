<%@ Control Language="VB" AutoEventWireup="false" CodeFile="t_StockCard_Rev_Main_Medicine.ascx.vb" Inherits="Records_t_StockCard_Rev_Main_Medicine" %>

<div class="DivTitle">LIST OF MEDICINE</div>

<asp:GridView ID="grdMedicineStockList" runat="server" Width="98%" SkinID="GridViewAA"
    AllowPaging="True"
     DataKeyNames="Item_ID, Stock_ID"
    OnPageIndexChanging="grdMedicineStockList_PageIndexChanging"
    OnRowDataBound="grdMedicineStockList_RowDataBound"
    OnSelectedIndexChanged="grdMedicineStockList_SelectedIndexChanged">

    <Columns>
        <asp:BoundField DataField="Item_ID" HeaderText="Item No.">
            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
        </asp:BoundField>

        <asp:BoundField DataField="Unit" HeaderText="UNIT">
            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
        </asp:BoundField>

        <asp:BoundField DataField="Item_Desc" HeaderText="ITEM DESCRIPTION">
            <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
        </asp:BoundField>

        <asp:BoundField DataField="Balance" HeaderText="CURRENT BALANCE">
            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
        </asp:BoundField>

        <asp:BoundField DataField="Location" HeaderText="LOCATION">
            <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
        </asp:BoundField>
    </Columns>

    <PagerStyle Font-Bold="True" />
</asp:GridView>

<br />

<asp:Button ID="btnViewMedicineStockInventoryReport" runat="server" Width="250px"
    CssClass="CSButton" Text="VIEW STOCK INVENTORY REPORT"
    OnClick="btnViewMedicineStockInventoryReport_Click" />

<br /><br />

<div class="DivTitle">INCOMING DELIVERIES</div>

<asp:GridView ID="grdMedicineIncomingDeliveries" runat="server" Width="98%" SkinID="GridViewAA"
    AllowPaging="True" PageSize="5"
    DataKeyNames="Stock_ID"
    OnRowDataBound="grdMedicineIncomingDeliveries_RowDataBound"
  
    OnPageIndexChanging="grdMedicineIncomingDeliveries_PageIndexChanging">

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

    <PagerStyle Font-Bold="True" />
</asp:GridView>

<br /><br />

<div class="DivTitle">INVENTORY CARD</div>

<table width="100%">
    <tr>
        <td style="width: 70%" align="center">
            <table width="100%">
                <tr>
                    <td style="width: 15%" class="column_RightBold" valign="top">Generic Name :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMedicineGenericName" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold" valign="top">Unit :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMedicineUnit" runat="server" Text="" Width="98%"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 15%" class="column_RightBold" valign="top">Brand Name :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMedicineBrandName" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold" valign="top">Form :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMedicineForm" runat="server" Text="" Width="98%"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 15%" class="column_RightBold" valign="top">Dosage :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMedicineDosage" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold" valign="top">OTC / RX :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMedicineOtcRx" runat="server" Text="" Width="98%"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 15%" class="column_RightBold" valign="top">Unit Cost :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMedicineUnitPrice" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold" valign="top">BFAD No. :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMedicineBFADNo" runat="server" Text="" Width="98%"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 15%" class="column_RightBold" valign="top">Selling Price :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMedicineSellingPrice" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold" valign="top">Item Code :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMedicineItemCode" runat="server" Text="" Width="98%"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 15%" class="column_RightBold" valign="top">Reorder Pt. :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMedicineReorderPt" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold" valign="top">Qty Balance :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMedicineQtyBalance" runat="server" Text="" Width="98%"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 15%" class="column_RightBold" valign="top">Date :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMedicineDate" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold"></td>
                    <td style="width: 35%" class="column_Left"></td>
                </tr>

                <tr>
                    <td colspan="2" valign="top">
                        <fieldset>
                            <legend class="column_Left" style="font-family:Arial; color:#404040;"><strong>Mftg Info:</strong></legend>
                            <table width="100%">
                                <tr>
                                    <td style="width: 30%" class="column_RightBold">Batch :</td>
                                    <td style="width: 70%" class="column_Left">
                                        <asp:Label ID="lblMedicineBatch" runat="server" Text="" Width="98%"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Lot :</td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblMedicineLot" runat="server" Text="" Width="98%"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Mftg. Date :</td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblMedicineMftgDate" runat="server" Text="" Width="98%"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Expiry Date :</td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblMedicineExpiryDate" runat="server" Text="" Width="98%"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Alert :</td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblMedicineAlert" runat="server" Text="" Width="98%"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>

                    <td colspan="2" valign="top">
                        <fieldset>
                            <legend class="column_Left" style="font-family:Arial; color:#404040;"><strong>Price per Quantity:</strong></legend>
                            <table width="100%">
                                <tr>
                                    <td style="width: 35%" class="column_RightBold">Qty./Pack :</td>
                                    <td style="width: 65%" class="column_Left">
                                        <asp:Label ID="lblMedicineQtyPerPack" runat="server" Text="" Width="98%"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Unit Cost :</td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblMedicinePricePerQtyUnitCost" runat="server" Text="" Width="98%"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Selling Price :</td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblMedicinePricePerQtySellingPrice" runat="server" Text="" Width="98%"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>

                <tr>
                    <td colspan="4">
                        <fieldset>
                            <legend class="column_Left" style="font-family:Arial; color:#404040;"><strong>Location:</strong></legend>
                            <table width="100%">
                                <tr>
                                    <td class="column_RightBold">Warehouse :</td>
                                    <td class="column_Left">
                                        <asp:DropDownList ID="drpMedicineWarehouse" runat="server" Width="90%" AutoPostBack="True"
                                            CssClass="drpdownCSS" Enabled="false"></asp:DropDownList>
                                    </td>

                                    <td class="column_RightBold">Bay :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMedicineBay" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold" style="width:10%">Column :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMedicineColumn" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold" style="width:10%">Floor :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMedicineFloor" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Room :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMedicineRoom" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold" style="width:10%">Shelves :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMedicineShelves" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold">Rack :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMedicineRack" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold">Bin :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMedicineBin" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
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

<asp:Panel ID="pnlMedicineLedger" runat="server" Width="100%" CssClass="PanelSize" ScrollBars="Vertical">
    <asp:GridView ID="grdMedicineLedger" runat="server" Width="100%" SkinID="GridViewAA" AutoGenerateColumns="False">
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
