
<%@ Control Language="VB" AutoEventWireup="false" CodeFile="t_StockCard_Rev_Main_MRO_Equipment.ascx.vb" Inherits="Records_t_StockCard_Rev_Main_MRO_Equipment" %>

<div class="DivTitle">LIST OF MRO EQUIPMENT</div>

<asp:GridView ID="grdMROEquipmentStockList" runat="server" Width="98%" SkinID="GridViewAA"
    AllowPaging="True"
    DataKeyNames="Item_ID, Stock_ID"
    OnPageIndexChanging="grdMROEquipmentStockList_PageIndexChanging"
    OnRowDataBound="grdMROEquipmentStockList_RowDataBound"
    OnSelectedIndexChanged="grdMROEquipmentStockList_SelectedIndexChanged">

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

<asp:Button ID="btnViewMROEquipmentStockInventoryReport" runat="server" Width="250px"
    CssClass="CSButton" Text="VIEW STOCK INVENTORY REPORT"
    OnClick="btnViewMROEquipmentStockInventoryReport_Click" />

<br /><br />

<div class="DivTitle">INCOMING DELIVERIES</div>

<asp:GridView ID="grdMROEquipmentIncomingDeliveries" runat="server" Width="98%" SkinID="GridViewAA"
    AllowPaging="True" PageSize="5"
    DataKeyNames="Stock_ID"
    OnRowDataBound="grdMROEquipmentIncomingDeliveries_RowDataBound"
   
    OnPageIndexChanging="grdMROEquipmentIncomingDeliveries_PageIndexChanging">

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
                    <td style="width: 15%" class="column_RightBold" valign="top">Name :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMROEquipmentName" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold" valign="top">Unit :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMROEquipmentUnit" runat="server" Text="" Width="98%"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 15%" class="column_RightBold" valign="top">Description :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMROEquipmentDescription" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold" valign="top">Dimension :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMROEquipmentDimension" runat="server" Text="" Width="98%"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 15%" class="column_RightBold" valign="top">Power Input :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMROEquipmentPowerInput" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold" valign="top">Area Capacity :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMROEquipmentAreaCapacity" runat="server" Text="" Width="98%"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 15%" class="column_RightBold" valign="top">Model :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMROEquipmentModel" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold" valign="top">Warranty :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMROEquipmentWarranty" runat="server" Text="" Width="98%"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 15%" class="column_RightBold" valign="top">Reorder Pt. :</td>
                    <td style="width: 35%" class="column_Left" valign="top">
                        <asp:Label ID="lblMROEquipmentReorderPt" runat="server" Text="" Width="98%"></asp:Label>
                    </td>

                    <td style="width: 15%" class="column_RightBold"></td>
                    <td style="width: 35%" class="column_Left"></td>
                </tr>

                <tr>
                    <td colspan="4">
                        <fieldset>
                            <legend class="column_Left" style="font-family:Arial; color:#404040;"><strong>Acquisition:</strong></legend>
                            <table width="100%">
                                <tr>
                                    <td style="width: 15%" class="column_RightBold" valign="top">Acq. Date :</td>
                                    <td style="width: 35%" class="column_Left" valign="top">
                                        <asp:Label ID="lblMROEquipmentAcquisitionDate" runat="server" Text="" Width="98%"></asp:Label>
                                    </td>

                                    <td style="width: 15%" class="column_RightBold" valign="top">Market Value :</td>
                                    <td style="width: 35%" class="column_Left" valign="top">
                                        <asp:Label ID="lblMROEquipmentMarketValue" runat="server" Text="" Width="98%"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold" valign="top">Acq. Cost :</td>
                                    <td class="column_Left" valign="top">
                                        <asp:Label ID="lblMROEquipmentAcquisitionCost" runat="server" Text="" Width="98%"></asp:Label>
                                    </td>

                                    <td class="column_RightBold" valign="top">No. of Years :</td>
                                    <td class="column_Left" valign="top">
                                        <asp:Label ID="lblMROEquipmentNoOfYears" runat="server" Text="" Width="98%"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold" valign="top">Dep. Rate :</td>
                                    <td class="column_Left" valign="top">
                                        <asp:Label ID="lblMROEquipmentDepreciatedRate" runat="server" Text="" Width="98%"></asp:Label>
                                    </td>

                                    <td class="column_RightBold" valign="top">Useful Life :</td>
                                    <td class="column_Left" valign="top">
                                        <asp:Label ID="lblMROEquipmentUsefulLife" runat="server" Text="" Width="98%"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold" valign="top">Dep. Value :</td>
                                    <td class="column_Left" valign="top">
                                        <asp:Label ID="lblMROEquipmentDepreciatedValue" runat="server" Text="" Width="98%"></asp:Label>
                                    </td>

                                    <td class="column_RightBold" valign="top">Salvage Value :</td>
                                    <td class="column_Left" valign="top">
                                        <asp:Label ID="lblMROEquipmentSalvageValue" runat="server" Text="" Width="98%"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold" valign="top">Dep. Value :</td>
                                    <td class="column_Left" valign="top">
                                        <asp:Label ID="lblMROEquipmentDepreciationValue" runat="server" Text="" Width="98%"></asp:Label>
                                    </td>

                                    <td class="column_RightBold" valign="top">Quantity :</td>
                                    <td class="column_Left" valign="top">
                                        <asp:Label ID="lblMROEquipmentQuantity" runat="server" Text="" Width="98%"></asp:Label>
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
                                        <asp:DropDownList ID="drpMROEquipmentWarehouse" runat="server" Width="90%" AutoPostBack="True"
                                            CssClass="drpdownCSS" Enabled="false"></asp:DropDownList>
                                    </td>

                                    <td class="column_RightBold">Bay :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMROEquipmentBay" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold" style="width:10%">Column :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMROEquipmentColumn" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold" style="width:10%">Floor :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMROEquipmentFloor" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Room :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMROEquipmentRoom" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold" style="width:10%">Shelves :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMROEquipmentShelves" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold">Rack :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMROEquipmentRack" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold">Bin :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMROEquipmentBin" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
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

<asp:Panel ID="pnlMROEquipmentLedger" runat="server" Width="100%" CssClass="PanelSize" ScrollBars="Vertical">
    <asp:GridView ID="grdMROEquipmentLedger" runat="server" Width="100%" SkinID="GridViewAA" AutoGenerateColumns="False">
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

