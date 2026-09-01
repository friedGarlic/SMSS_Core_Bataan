<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PropertyCard_Rev_Furnitures.ascx.vb" Inherits="Records_PropertyCard_Rev_Furnitures" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table width="100%">

    <%-- =========================
         LIST OF LOCATION (FURNITURES AND FIXTURES)
         ========================= --%>
    <tr>
        <td class="DivTitle" style="width: 100%">
            LIST OF LOCATION (FURNITURES AND FIXTURES)
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvFurnitureLocationList" runat="server"
                Width="1000px" SkinID="GridViewAA" HorizontalAlign="Center"
                DataKeyNames="item_particular_id,Item_ID,DeclaredOwner,Barangay"
                AllowPaging="True"
                OnPageIndexChanging="gvFurnitureLocationList_PageIndexChanging"
                OnSelectedIndexChanged="gvFurnitureLocationList_SelectedIndexChanged"
                OnRowDataBound="gvFurnitureLocationList_RowDataBound"
                AutoGenerateColumns="False" Font-Size="9pt"
                EnableSelection="True">
                <Columns>
                    <asp:BoundField DataField="Property_code" HeaderText="CODE" Visible="False"></asp:BoundField>

                    <asp:BoundField DataField="ItemCode" HeaderText="Item Code">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="ItemDescription" HeaderText="Description">
                        <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Location" HeaderText="Location">
                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Room" HeaderText="Room / Office">
                        <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="AcqDate" HeaderText="Acquisition Date">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="AcqCost" HeaderText="Acquisition Cost">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="MarketValue" HeaderText="Market Value">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>

    <%-- View PIR Button --%>
    <tr>
        <td style="text-align: center; padding: 10px;">
            <asp:Button ID="btnViewFurniturePIR" runat="server" Width="240px" CssClass="CSButton"
                Text="View Perpetual Inventory Report" OnClientClick="window.open('rpt_view_propertycard_v4.aspx')"></asp:Button>
        </td>
    </tr>

    <%-- spacing --%>
    <tr><td style="height: 20px;"></td></tr>

    <%-- =========================
         LIST OF FURNITURES AND FIXTURES
         ========================= --%>
    <tr>
        <td class="DivTitle" style="width: 100%">
            LIST OF FURNITURES AND FIXTURES
        </td>
    </tr>

    <%-- Search Section --%>
    <tr>
        <td style="width: 1000px">
            <table style="width: 100%">
                <tbody>
                    <tr>
                        <td style="width: 30%" class="column_RightBold">SEARCH PROPERTY NUMBER :</td>
                        <td style="width: 40%" class="text5">
                            <asp:TextBox ID="txtFurniturePropSearch" runat="server" Width="95%"></asp:TextBox>
                        </td>
                        <td style="width: 30%" class="text5">
                            <asp:Button ID="btnFurniturePropSearch" CssClass="CSButton" OnClick="btnFurniturePropSearch_Click"
                                runat="server" Width="150px" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>

    <%-- Furnitures List GridView --%>
    <tr>
        <td style="width: 1000px">
            <asp:GridView ID="grdListOfFurnitures" runat="server" Width="1000px" SkinID="GridViewAA"
                OnPageIndexChanging="grdListOfFurnitures_PageIndexChanging"
                AllowPaging="True" HorizontalAlign="Center"
                DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo,Received_ID,AcquisitionCost,Received_Date,Date_Accepted,useful_life,Received_Dtl_ID"
                OnRowDataBound="grdListOfFurnitures_RowDataBound"
                OnSelectedIndexChanged="grdListOfFurnitures_SelectedIndexChanged"
                Font-Size="9pt"
                OnDataBound="grdListOfFurnitures_OnDataBound"
                AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="PropertyNo" HeaderText="Property No." ControlStyle-CssClass="header">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Property_code" HeaderText="Property No." Visible="false">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="ItemDescription" HeaderText="Name">
                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Title" HeaderText="Title">
                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Author" HeaderText="Author">
                        <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Unit" HeaderText="Unit">
                        <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="AcqDate" HeaderText="Acquisition Date">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="AcqCost" HeaderText="Acquisition Cost">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="MarketValue" HeaderText="Market Value">
                        <ItemStyle HorizontalAlign="Center" Width="14%"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <br />
        </td>
    </tr>

    <%-- spacing --%>
    <tr><td style="height: 20px;"></td></tr>
<%-- =========================
     FURNITURE INFORMATION
     ========================= --%>
<tr>
    <td style="width: 1000px" class="DivTitle">FURNITURE INFORMATION</td>
</tr>

<tr>
    <td style="width: 1000px">
        <table width="100%">
            <tr>
                <%-- LEFT SIDE (FIELDS) --%>
                <td style="width: 80%;" valign="top">
                    <table width="100%">
                        <tr>
                            <td align="center" style="width: 100%">
                                <table style="width: 100%;">

                                    <!-- ROW 1 -->
                                    <tr>
                                        <td class="column_RightBold" style="width: 10%">Name :</td>
                                        <td class="column_Left" style="width: 30%">
                                            <asp:TextBox ID="txtFurnitureName" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                                        </td>

                                        <td class="column_RightBold" style="width: 10%">Unit :</td>
                                        <td class="column_Left" style="width: 30%">
                                            <asp:DropDownList ID="drpFurnitureUnit" runat="server" CssClass="drpdownCSS" Width="100px" Enabled="False"></asp:DropDownList>
                                            <span class="column_RightBold">Quantity :</span>
                                            <asp:TextBox ID="txtFurnitureQuantity" runat="server" CssClass="txtbox_Var" Width="100px" Enabled="False"></asp:TextBox>
                                        </td>

                                        <%-- Right-Side IMAGE --%>
                                       <td align="center" rowspan="7" style="width: 20%;" valign="middle">
                                            <asp:Image ID="imgFurniture" runat="server" CssClass="textimage2"
                                                Height="160px" Width="90%" ImageUrl="~/images/blankImage.jpg" ImageAlign="Middle" />
                                            <br />
                                            <asp:Button ID="btnFurnitureUpload" runat="server" Width="48%" CssClass="CSButton"
                                                Text="UPLOAD" Enabled="false"></asp:Button>
                                            <br /><br />
                                            <asp:Button ID="btnEditFurniture" runat="server" Width="48%" CssClass="CSButton"
                                                Visible="false" Text="EDIT" OnClientClick="StartProgressBar();" />
                                        </td>

                                    </tr>

                                    <!-- ROW 2 -->
                                    <tr>
                                        <td class="column_RightBold">Description :</td>
                                        <td class="column_Left">
                                            <asp:TextBox ID="txtFurnitureDescription" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                                        </td>

                                        <td class="column_RightBold">Warranty :</td>
                                        <td class="column_Left">
                                            <asp:TextBox ID="txtFurnitureWarranty" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <!-- ROW 3 -->
                                    <tr>
                                        <td class="column_RightBold">Model :</td>
                                        <td class="column_Left">
                                            <asp:TextBox ID="txtFurnitureModel" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                                        </td>

                                        <td class="column_RightBold">Dimension :</td>
                                        <td class="column_Left">
                                            <asp:TextBox ID="txtFurnitureDimension" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <!-- ROW 4 -->
                                    <tr>
                                        <td class="column_RightBold">Serial Number :</td>
                                        <td class="column_Left">
                                            <asp:TextBox ID="txtFurnitureSerialNumber" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                                        </td>

                                        <td class="column_RightBold">Property Number :</td>
                                        <td class="column_Left">
                                            <asp:TextBox ID="txtFurniturePropertyNo" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <!-- ACQUISITION SECTION -->
                                    <tr>
                                        <td colspan="4">
                                            <fieldset style="width: 93%;">
                                                <legend class="column_LeftBold">Acquisition :</legend>
                                                <table>

                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%;">Acquisition Date :</td>
                                                        <td class="column_Left" style="width: 25%;">
                                                            <asp:TextBox ID="txtFurnitureAcqDate" runat="server" CssClass="txtbox_Var"
                                                                Width="100px" Enabled="False"
                                                                onchange="return NoOfYearsFIXTURES(this.value);"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="ceFurnitureAcqDate" runat="server"
                                                                TargetControlID="txtFurnitureAcqDate" PopupButtonID="txtFurnitureAcqDate"></cc1:CalendarExtender>
                                                            &nbsp;(MM/DD/YYYY)
                                                        </td>

                                                        <td class="column_RightBold" style="width: 25%;">Market Value :</td>
                                                        <td class="column_Left" style="width: 25%;">
                                                            <asp:TextBox ID="txtFurnitureMarketValue" runat="server" CssClass="txtbox_Var"
                                                                Width="100px" Enabled="False"
                                                                Onkeyup="javascript:this.value=Comma(this.value);"
                                                                Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td class="column_RightBold">Acquisition Cost :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtFurnitureAcqCost" runat="server" CssClass="txtbox_Var" Enabled="False"
                                                                Onkeyup="javascript:this.value=Comma(this.value);"
                                                                Onchange="this.value=formatCurrency(this.value); return getSalValFIXTURES(this),getDepValRateFIXTURES(this);"></asp:TextBox>
                                                        </td>

                                                        <td class="column_RightBold">No. of Years :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtFurnitureNoYears" runat="server" CssClass="txtbox_Var"
                                                                Width="100px" Enabled="False"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td class="column_RightBold">Depreciated Rate :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtFurnitureDeprate" runat="server" CssClass="txtboxAmount"
                                                                Width="100px" MaxLength="5" ReadOnly="True"></asp:TextBox>
                                                            &nbsp;(%) Percent
                                                        </td>

                                                        <td class="column_RightBold">Useful Life :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtFurnitureUsefulLife" runat="server" CssClass="txtbox_Var"
                                                                Width="100px" Enabled="False"
                                                                onchange="return getDepValRateFIXTURES(this);"></asp:TextBox>
                                                            &nbsp;(Years)
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td class="column_RightBold">Depreciated Value :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtDepreciatedValueFurnitureNew" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                        </td>

                                                        <td class="column_RightBold">Salvage Value :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtFurnitureSalvageValue" runat="server" CssClass="txtboxAmount"
                                                                Width="100px" Enabled="False"
                                                                Onchange="this.value=formatCurrency(this.value);"
                                                                Onkeyup="javascript:this.value=Comma(this.value);">0.00</asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td class="column_RightBold">Depreciation Value :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtFurnitureDepValue" runat="server" CssClass="txtbox_Var"
                                                                Enabled="False" Width="100px"
                                                                Onkeyup="javascript:this.value=Comma(this.value);"
                                                                Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>

                                                </table>
                                            </fieldset>
                                        </td>
                                    </tr>

                                 

                                </table>
                            </td>
                        </tr>
                    </table>
                </td>

                <%-- RIGHT SIDE IMAGE (already handled above) --%>
            </tr>
        </table>
    </td>
</tr>


    <%-- spacing --%>
    <tr><td style="height: 20px;"></td></tr>

    <%-- =========================
         TRANSACTIONS
         ========================= --%>
    <tr>
        <td style="width: 1000px" class="DivTitle">TRANSACTIONS</td>
    </tr>

    <tr>
        <td style="width: 1000px" colspan="4">
            <asp:Panel ID="pnlFurnitureLedger" runat="server" Width="1000px" CssClass="PanelSize" ScrollBars="Vertical">
                <asp:GridView ID="grdFurnitureLedger" runat="server" Width="980px" SkinID="GridViewAA" Font-Size="8pt"
                    OnDataBound="OnFurnitureLedgerDataBound">
                    <Columns>
                        <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Trans_Type" HeaderText="Transaction Type">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Top" Width="46%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="ref" HeaderText="Ref. No.">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="AccountablePerson" HeaderText="Accountable Person" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Department" HeaderText="Dept / Office" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="position" HeaderText="Position" Visible="False">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="acceptedby" HeaderText="Accepted By" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="inspectedby" HeaderText="Inspected By" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="DebitQty" HeaderText="Qty" SortExpression="DebitQty" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="DebitUnit" HeaderText="Unit" SortExpression="DebitUnit" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText="Debit Cost" SortExpression="DebitCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CreditQty" HeaderText="Qty" SortExpression="CreditQty" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CreditUnit" HeaderText="Unit" SortExpression="CreditUnit" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText="Credit Cost" SortExpression="CreditCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="BalQty" HeaderText="Qty" SortExpression="BalQty" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="BalanceUnit" HeaderText="Unit" SortExpression="BalUnit" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="BalCost" DataFormatString="{0:N}" HeaderText="Balance Cost" SortExpression="BalCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </td>
    </tr>

    <%-- Preview Button --%>
    <tr>
        <td style="width: 1000px" colspan="4">
            <asp:Button ID="btnFurniturePreview" OnClick="btnFurniturePreview_Click" runat="server"
                Width="200px" Text="PREVIEW"  Visible="false" CssClass="CSButton"></asp:Button>
            <asp:HiddenField ID="hdfFurnitureLedgerReport" runat="server" />
        </td>
    </tr>

</table>
