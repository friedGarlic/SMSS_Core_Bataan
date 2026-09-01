<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PropertyCard_Rev_Intangible.ascx.vb" Inherits="Records_PropertyCard_Rev_Intangible" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table width="100%">

    <%-- =========================
         LIST OF LOCATION (INTANGIBLE)
         ========================= --%>
    <tr>
        <td class="DivTitle" style="width: 100%">
            LIST OF LOCATION (INTANGIBLE ASSETS)
        </td>
    </tr>

    <tr>
        <td>
            <asp:GridView ID="gvIntangibleLocationList" runat="server"
                Width="1000px" SkinID="GridViewAA" HorizontalAlign="Center"
                DataKeyNames="item_particular_id,Item_ID,DeclaredOwner,Barangay"
                AllowPaging="True"
                OnPageIndexChanging="gvIntangibleLocationList_PageIndexChanging"
                OnSelectedIndexChanged="gvIntangibleLocationList_SelectedIndexChanged"
                OnRowDataBound="gvIntangibleLocationList_RowDataBound"
                AutoGenerateColumns="False" Font-Size="9pt"
                EnableSelection="True">
                <Columns>
                    <asp:BoundField DataField="Property_code" HeaderText="CODE" Visible="False"></asp:BoundField>

                    <asp:BoundField DataField="Item_ID" HeaderText="Item Code">
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Location" HeaderText="Location">
                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="DeclaredOwner" DataFormatString="{0:N}" HeaderText="Building">
                        <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Location" HeaderText="Address" Visible="false">
                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Area" HeaderText="Area" Visible="false">
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
        </td>
    </tr>

    <%-- spacing --%>
    <tr><td style="height: 20px;"></td></tr>

    <%-- =========================
         LIST OF INTANGIBLE ASSETS
         (child list based on selected location)
         ========================= --%>
    <tr>
        <td class="DivTitle" style="width: 100%">
            LIST OF INTANGIBLE ASSETS
        </td>
    </tr>

        <!-- Search Section -->
<tr>
    <td style="width: 1000px">
        <table style="width: 100%">
            <tbody>
                <tr>
                    <td style="width: 30%" class="column_RightBold">SEARCH PROPERTY NUMBER :</td>
                    <td style="width: 40%" class="text5">
                        <asp:TextBox ID="txtIntangiblePropSearch" runat="server" Width="95%"></asp:TextBox>
                    </td>
                    <td style="width: 30%" class="text5">
                        <asp:Button ID="btnIntangiblePropSearch" CssClass="CSButton"
                            runat="server" Width="150px" Text="SEARCH"
                            OnClick="btnIntangiblePropSearch_Click"
                            OnClientClick="StartProgressBar();"></asp:Button>
                    </td>
                </tr>
            </tbody>
        </table>
    </td>
</tr>


    <tr>
        <td>
            <asp:GridView ID="grdListOfIntangibleAssets" runat="server"
                Width="1000px" SkinID="GridViewAA" HorizontalAlign="Center"
                DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID"
                AllowPaging="True"
                OnPageIndexChanging="grdListOfIntangibleAssets_PageIndexChanging"
                OnSelectedIndexChanged="grdListOfIntangibleAssets_SelectedIndexChanged"
                OnRowDataBound="grdListOfIntangibleAssets_RowDataBound"
                AutoGenerateColumns="False" Font-Size="9pt"
                EnableSelection="True">
                <Columns>
                    <asp:BoundField DataField="PropertyNo" HeaderText="Property No.">
                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Property_code" HeaderText="Property No." Visible="false">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="AssetName" HeaderText="Asset Name">
                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Description" HeaderText="Description">
                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="LicenseNo" HeaderText="License / Registration No.">
                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Validity" HeaderText="Validity / Expiry">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="AcqDate" HeaderText="Acquisition Date">
                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="AcqCost" HeaderText="Acquisition Cost">
                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="MarketValue" HeaderText="Market Value">
                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>

    <%-- spacing --%>
    <tr><td style="height: 20px;"></td></tr>

    <%-- =========================
         INTANGIBLE ASSET INFORMATION
         ========================= --%>
    <tr>
        <td class="DivTitle" style="width:100%">
            INTANGIBLE ASSET INFORMATION
        </td>
    </tr>


    <tr>
        <td style="width:1000px">
            <table style="width: 100%;">
                <tr>
                    <td align="center" class="DivTitle" style="width: 100%" colspan="5">
                        <asp:Label ID="lblIntangibleHeader" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td class="column_RightBold" style="width: 10%; height: 23px;">Name :</td>
                    <td class="column_Left" style="width: 30%; height: 23px;">
                        <asp:Label ID="lblIntangibleName" runat="server" Visible="false" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                        <asp:TextBox ID="txtIntangibleName" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                    </td>

                    <td class="column_RightBold" style="width: 10%; height: 23px;">Unit :</td>
                    <td class="column_Left" style="width: 30%; height: 23px;">
                        <asp:Label ID="lblIntangibleUnit" runat="server" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                        <asp:DropDownList ID="drpIntangibleUnit" runat="server" CssClass="drpdownCSS" Width="75px" Enabled="False"></asp:DropDownList>
                        <span class="column_RightBold">Quantity :</span>
                        <asp:Label ID="lblIntangibleQuantity" runat="server" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                        <asp:TextBox ID="txtIntangibleQuantity" runat="server" CssClass="txtbox_Var" Width="75px" Enabled="False"></asp:TextBox>
                    </td>

                    <td align="center" rowspan="6" style="width: 20%" valign="middle">
                        <asp:Image ID="imgIntangible" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle"
                            ImageUrl="~/images/blankImage.jpg" Width="90%" />
                        <br />
                        <asp:Button ID="btnIntangibleUpload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>
                    </td>
                </tr>

                <tr>
                    <td class="column_RightBold" style="width: 10%">Description :</td>
                    <td class="column_Left" style="width: 30%">
                        <asp:Label ID="lblIntangibleDescription" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="False"></asp:Label>
                        <asp:TextBox ID="txtIntangibleDescription" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                    </td>

                    <td class="column_RightBold" style="width: 10%">Warranty :</td>
                    <td class="column_Left" style="width: 30%">
                        <asp:Label ID="lblIntangibleWarranty" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                        <asp:TextBox ID="txtIntangibleWarranty" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="column_RightBold" style="width: 10%">Power Input :</td>
                    <td class="column_Left" style="width: 30%">
                        <asp:Label ID="lblIntangiblePowerInput" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="False"></asp:Label>
                        <asp:TextBox ID="txtIntangiblePowerInput" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                    </td>

                    <td class="column_RightBold">Installed At :</td>
                    <td class="column_Left">
                        <asp:Label ID="lblIntangibleInstalledAt" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="False"></asp:Label>
                        <asp:DropDownList ID="drpIntangibleInstalledBuilding" runat="server" Enabled="False" Width="290px" CssClass="drpdownCSS"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td class="column_RightBold" style="width: 10%">Model :</td>
                    <td class="column_Left" style="width: 30%">
                        <asp:Label ID="lblIntangibleModel" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                        <asp:TextBox ID="txtIntangibleModel" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                    </td>

                    <td class="column_RightBold" style="width: 10%">Dimension :</td>
                    <td class="column_Left" style="width: 30%">
                        <asp:Label ID="lblIntangibleDimension" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="False"></asp:Label>
                        <asp:TextBox ID="txtIntangibleDimension" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="column_RightBold" style="width: 10%">License / Reg. No. :</td>
                    <td class="column_Left" style="width: 30%">
                        <asp:Label ID="lblIntangibleLicenseNo" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="False"></asp:Label>
                        <asp:TextBox ID="txtIntangibleLicenseNo" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="column_RightBold">Validity / Expiry :</td>
                    <td class="column_Left">
                        <asp:Label ID="lblIntangibleValidity" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="False"></asp:Label>
                        <asp:TextBox ID="txtIntangibleValidity" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="4">
                        <fieldset style="width: 93%">
                            <legend class="column_LeftBold">Maintenance</legend>
                            <table width="100%">
                                <tr>
                                    <td class="column_RightBold">Contractor :</td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblIntangibleContractor" runat="server" Width="75%" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtIntangibleContractor" runat="server" CssClass="txtbox_Var" Width="75%" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td class="column_RightBold">Contact Person :</td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblIntangibleContactPerson" runat="server" Width="75%" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtIntangibleContactPerson" runat="server" CssClass="txtbox_Var" Width="75%" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td class="column_RightBold">Cellphone No. :</td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblIntangibleContactNo" runat="server" Width="75%" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtIntangibleContactNo" runat="server" CssClass="txtbox_Var" Width="75%" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>

                <tr>
                    <td colspan="4">
                        <fieldset style="width: 93%;">
                            <legend class="column_LeftBold">Acquisition :</legend>
                            <table width="100%">
                                <tr>
                                    <td class="column_RightBold" style="width:15%">Acquisition Date :</td>
                                    <td class="column_Left" style="width: 25%">
                                        <asp:Label ID="lblIntangibleAcqDate" runat="server" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtIntangibleAcqDate" runat="server" CssClass="txtbox_Var" Width="100px" Enabled="False"
                                            onchange="return NoOfYearsEquipment(this.value);"></asp:TextBox>
                                        <cc1:CalendarExtender ID="ceIntangibleAcqDate" runat="server"
                                            TargetControlID="txtIntangibleAcqDate" PopupButtonID="txtIntangibleAcqDate"></cc1:CalendarExtender>
                                        &nbsp;(MM/DD/YYYY)
                                    </td>

                                    <td class="column_RightBold" style="width: 25%">Market Value :</td>
                                    <td class="column_Left" style="width: 25%">
                                        <asp:Label ID="lblIntangibleMarketValue" runat="server" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtIntangibleMarketValue" runat="server" CssClass="txtbox_Var" Width="150px" Enabled="False"
                                            Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Acquisition Cost :</td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblIntangibleAcqCost" runat="server" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtIntangibleAcqCost" runat="server" CssClass="txtbox_Var" Width="150px" Enabled="False"
                                            Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalValEquipment(this),getDepValRateEquipment(this);"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold">No. of Years :</td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblIntangibleNoYears" runat="server" Visible="False"></asp:Label>
                                        <asp:TextBox ID="txtIntangibleNoYears" runat="server" CssClass="txtbox_Var" Width="100px" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Depreciated Rate :</td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblIntangibleDepRate" runat="server" Visible="False"></asp:Label>
                                        <asp:TextBox ID="txtIntangibleDepRate" runat="server" CssClass="txtbox_Var" Width="150px" Enabled="False"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold">Useful Life :</td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblIntangibleUsefulLife" runat="server" Visible="False"></asp:Label>
                                        <asp:TextBox ID="txtIntangibleUsefulLife" runat="server" CssClass="txtbox_Var" Width="100px" Enabled="False"
                                            onchange="return getDepValRateEquipment(this);"></asp:TextBox>
                                        &nbsp;(Years)
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Depreciated Value :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtDepreciatedValueIntangibleNew" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold">Salvage Value :</td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblIntangibleSalvageValue" runat="server" Font-Italic="False" SkinID="Label" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtIntangibleSalvageValue" runat="server" CssClass="txtbox_Var" Enabled="False"
                                            Onchange="this.value=formatCurrency(this.value);" Onkeyup="javascript:this.value=Comma(this.value);" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Depreciation Value :</td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblIntangibleDepValue" runat="server" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtIntangibleDepValue" runat="server" CssClass="txtbox_Var" Width="150px" Enabled="False"
                                            Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold">&nbsp;</td>
                                    <td class="column_Left">&nbsp;</td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>

                <tr>
                    <td class="column_RightBold" style="width: 10%">Specifications :</td>
                    <td class="column_Left" colspan="3">
                        <asp:Label ID="lblIntangibleSpecifications" runat="server" CssClass="text3" Visible="false"></asp:Label>
                        <asp:TextBox ID="txtIntangibleSpecifications" runat="server" CssClass="txtbox_Var" Width="200px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                    <td class="column_RightBold" colspan="3">
                        <asp:Label ID="lbl_Intangible_InfoId" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lbl_Intangible_AssetId" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lbl_Intangible_PropertyDetai_ID" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lbl_Intangible_Property_ID" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lbl_Intangible_Item_ID" runat="server" Visible="false"></asp:Label>
                    </td>
                    <td class="column_Center">
                        <asp:Button ID="btnEditIntangible" runat="server" Width="75%" CssClass="CSButton" Text="Edit"
                            Visible="false" OnClientClick="StartProgressBar();"></asp:Button>
                    </td>
                </tr>
            </table>
        </td>
    </tr>

    <%-- spacing --%>
    <tr><td style="height: 20px;"></td></tr>

    <%-- =========================
         TRANSACTIONS (LEDGER)
         ========================= --%>
    <tr>
        <td style="width: 1000px" class="DivTitle">TRANSACTIONS</td>
    </tr>

    <tr>
        <td style="width: 1000px" colspan="4">
            <asp:Panel ID="pnlIntangibleLedger" runat="server" Width="1000px" CssClass="PanelSize" ScrollBars="Vertical">
                <asp:GridView ID="grdIntangibleLedger" runat="server" Width="980px" SkinID="GridViewAA" Font-Size="8pt"
                    OnDataBound="OnIntangibleLedgerDataBound">
                    <Columns>
                        <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Trans_Type" HeaderText="Particulars">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Top" Width="46%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="ref" HeaderText="Ref. No.">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="AccountablePerson" HeaderText="Accountable Person" Visible="false" />
                        <asp:BoundField DataField="Department" HeaderText="Dept / Office" Visible="false" />
                        <asp:BoundField DataField="position" HeaderText="Position" Visible="False" />
                        <asp:BoundField DataField="acceptedby" HeaderText="Accepted By" Visible="false" />
                        <asp:BoundField DataField="inspectedby" HeaderText="Inspected By" Visible="false" />

                        <asp:BoundField DataField="DebitQty" HeaderText="Qty" SortExpression="DebitQty" Visible="false" />
                        <asp:BoundField DataField="DebitUnit" HeaderText="Unit" SortExpression="DebitUnit" Visible="false" />
                        <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText=" " SortExpression="DebitCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="CreditQty" HeaderText="Qty" SortExpression="CreditQty" Visible="false" />
                        <asp:BoundField DataField="CreditUnit" HeaderText="Unit" SortExpression="CreditUnit" Visible="false" />
                        <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText=" " SortExpression="CreditCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="BalQty" HeaderText="Qty" SortExpression="BalQty" Visible="false" />
                        <asp:BoundField DataField="BalanceUnit" HeaderText="Unit" SortExpression="BalUnit" Visible="false" />
                        <asp:BoundField DataField="BalCost" DataFormatString="{0:N}" HeaderText=" " SortExpression="BalCost">
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
            <asp:Button ID="btnIntangiblePreview" OnClick="btnIntangiblePreview_Click" runat="server"
                Width="200px" Text="PREVIEW" Visible="false"  CssClass="CSButton"></asp:Button>
            <asp:HiddenField ID="hdfIntangibleLedgerReport" runat="server" />
        </td>
    </tr>

</table>
