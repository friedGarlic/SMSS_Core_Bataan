<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PropertyCard_Rev_Building.ascx.vb" Inherits="Records_PropertyCard_Rev_Building" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table width="100%">
    <%-- =========================
         LIST OF LOCATION
         ========================= --%>
    <tr>
        <td class="DivTitle" style="width: 100%">
            LIST OF LOCATION (BUILDINGS)
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvBuildingLocationList" runat="server"
                Width="1000px" SkinID="GridViewAA" HorizontalAlign="Center"
                DataKeyNames="item_particular_id,Item_ID,DeclaredOwner,Barangay"
                AllowPaging="True"
                OnPageIndexChanging="gvBuildingLocationList_PageIndexChanging"
                OnSelectedIndexChanged="gvBuildingLocationList_SelectedIndexChanged"
                OnRowDataBound="gvBuildingLocationList_RowDataBound"
                AutoGenerateColumns="False" Font-Size="9pt"
                EnableSelection="True">
                <Columns>
                    <asp:BoundField DataField="Property_code" HeaderText="CODE" Visible="False" />

                    <asp:BoundField DataField="BuildingNo" HeaderText="Building No.">
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="BuildingName" HeaderText="Building">
                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Location" HeaderText="Location">
                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="FloorArea" HeaderText="Floor Area">
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="AcqDate" HeaderText="Acquisition Date">
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="AcqCost" HeaderText="Acquisition Cost">
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="MarketValue" HeaderText="Market Value">
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>

    <%-- View PIR Button --%>
    <tr>
        <td style="text-align: center; padding: 10px;">
            <asp:Button ID="btnViewBuildingPIR" runat="server" Width="240px" CssClass="CSButton"
                Text="View Perpetual Inventory Report"
                OnClientClick="window.open('rpt_view_propertycard_v4.aspx')"></asp:Button>
        </td>
    </tr>

    <%-- spacing --%>
    <tr><td style="height: 20px;"></td></tr>

    <%-- =========================
         LIST OF BUILDINGS
         ========================= --%>
    <tr>
        <td class="DivTitle" style="width: 100%">
            LIST OF BUILDINGS
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
                            <asp:TextBox ID="txtBuildingPropSearch" runat="server" Width="95%"></asp:TextBox>
                        </td>
                        <td style="width: 30%" class="text5">
                            <asp:Button ID="btnBuildingPropSearch" CssClass="CSButton"
                                runat="server" Width="150px" Text="SEARCH"
                                OnClick="btnBuildingPropSearch_Click"
                                OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>

    <%-- Buildings List GridView (same pattern as grdListOfEquipments) --%>
    <tr>
        <td style="width: 1000px">
            <asp:GridView ID="grdListOfBuildings" runat="server" Width="1000px" SkinID="GridViewAA"
                OnPageIndexChanging="grdListOfBuildings_PageIndexChanging"
                AllowPaging="True" HorizontalAlign="Center"
                DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo,Received_ID,AcquisitionCost,Received_Date,Date_Accepted,useful_life,Received_Dtl_ID"
                OnRowDataBound="grdListOfBuildings_RowDataBound"
                OnSelectedIndexChanged="grdListOfBuildings_SelectedIndexChanged"
                Font-Size="9pt"
                OnDataBound="grdListOfBuildings_OnDataBound"
                AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="PropertyNo" HeaderText="Property No." ControlStyle-CssClass="header">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Property_code" HeaderText="Property No." Visible="false">
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="ItemDescription" HeaderText="Name">
                        <ItemStyle HorizontalAlign="Left" Width="30%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Title" HeaderText="Title">
                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Author" HeaderText="Author">
                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Unit" HeaderText="Unit">
                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="AcqDate" HeaderText="Acquisition Date">
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="AcqCost" HeaderText="Acquisition Cost">
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="MarketValue" HeaderText="Market Value">
                        <ItemStyle HorizontalAlign="Center" Width="14%" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <br />
        </td>
    </tr>

    <%-- spacing --%>
    <tr><td style="height: 20px;"></td></tr>

    <%-- =========================
         BUILDING INFORMATION
         ========================= --%>
    <tr>
        <td style="width: 1000px" class="DivTitle">BUILDING INFORMATION</td>
    </tr>

    <tr>
        <td style="width: 1000px">
            <table width="100%">
                <tr>
                    <td style="width: 100%;" valign="top">
                        <table width="100%">
                            <tr>
                                <td colspan="7">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 50%; vertical-align: top;">
                                                <table width="100%">
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 35%">Building Name :</td>
                                                        <td class="column_Left" style="width: 65%">
                                                            <asp:TextBox ID="txtBuildingName" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Address :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtAddress" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Brgy :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBrgy" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Description :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtDescription" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Unit of Measurement :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtUnit" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 50%; vertical-align: top;">
                                                <table width="100%">
                                                    <tr>
                                                        <td class="column_RightBold">Area :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtArea" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Tax Dec. No. :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtTaxDecNo" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Previous Owner :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtPrevOwner" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 35%">Property No. :</td>
                                                        <td class="column_Left" style="width: 65%">
                                                            <asp:TextBox ID="txtPropertyNo" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Remarks :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRemarks" runat="server" Width="95%" CssClass="txtbox_Var"
                                                                TextMode="MultiLine" Rows="2" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td style="width: 80%;" valign="top">
                                                <fieldset>
                                                    <legend class="column_LeftBold">Acquisition :</legend>
                                                    <table>
                                                        <tr>
                                                            <td class="column_RightBold" style="width: 119px">Acquisition Date :</td>
                                                            <td class="column_Left" style="width: 100px;">
                                                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                                                <asp:TextBox ID="txtEAcqDate" runat="server" CssClass="txtbox_Var" Width="140px"
                                                                    onchange="return NoOfYears(this.value);" Enabled="false"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                                                    TargetControlID="txtEAcqDate" PopupButtonID="txtEAcqDate"></cc1:CalendarExtender>
                                                                &nbsp;(MM/DD/YYYY)
                                                            </td>
                                                            <td class="column_RightBold">Market Value :</td>
                                                            <td class="column_Left">
                                                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                                                <asp:TextBox ID="txtEMarketValue" runat="server" CssClass="txtboxAmount"
                                                                    Onkeyup="javascript:this.value=Comma(this.value);"
                                                                    Onchange="this.value=formatCurrency(this.value);"
                                                                    Width="140px" Enabled="false"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="column_RightBold" style="width: 119px">Acquisition Cost :</td>
                                                            <td class="column_Left">
                                                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                                                <asp:TextBox ID="txtEAcqCost" runat="server" Width="140px" CssClass="txtboxAmount"
                                                                    Onkeyup="javascript:this.value=Comma(this.value);"
                                                                    Onchange="this.value=formatCurrency(this.value); return getSalVal(this),getDepValRate(this);" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">No. of Years :</td>
                                                            <td class="column_Left">
                                                                <asp:Label ID="lblNoYears" runat="server"></asp:Label>
                                                                <asp:TextBox ID="txtNoYears" runat="server" Width="50px" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="column_RightBold" style="width: 119px">Depreciated Rate :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="lblequipmentdepreciatedRate" runat="server" Width="50px"
                                                                    CssClass="txtboxAmount" MaxLength="5" Enabled="false"></asp:TextBox>
                                                                &nbsp;(%) Percent
                                                            </td>
                                                            <td class="column_RightBold">Useful Life :</td>
                                                            <td class="column_Left">
                                                                <asp:Label ID="lblUsefulLife" runat="server"></asp:Label>
                                                                <asp:TextBox ID="txtUsefulLife" runat="server" Width="50px" CssClass="txtbox_Var"
                                                                    onchange="return getDepValRate(this);" Enabled="false"></asp:TextBox>
                                                                &nbsp;(Years)
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="column_RightBold" style="width: 119px">Depreciated Value :</td>
                                                            <td class="column_Left">
                                                                <asp:Label ID="lblequipmentdepreciatedvalue" runat="server" Width="290px"
                                                                    SkinID="Label" Font-Italic="False"></asp:Label>
                                                                <asp:TextBox ID="txtequipmentdepreciatedvalue" runat="server" Width="140px"
                                                                    CssClass="txtboxAmount" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Salvage Value :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtSalvageValue" runat="server" Width="140px"
                                                                    CssClass="txtboxAmount" Enabled="false">0.00</asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="column_RightBold" style="width: 119px">Depreciation Value :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtDepreciationValue" runat="server" Width="140px"
                                                                    CssClass="txtboxAmount" Enabled="false"></asp:TextBox>
                                                                &nbsp;(Per Year)
                                                            </td>
                                                            <td></td>
                                                            <td></td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </td>

                                            <td style="border: 2px solid #5c85d6" valign="top" rowspan="2">
                                                <asp:Image ID="imgpropertydocs" runat="server" Width="204px" Height="202px"
                                                    ImageUrl="~/images/blankImage.jpg"></asp:Image>
                                                <br /><br />
                                                <asp:Button ID="btnUpload" runat="server" CssClass="CSButton"
                                                    OnClientClick="StartProgressBar();" Text="UPLOAD" Width="120px" Enabled="false" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="width: 80%; border: 2px solid #5c85d6" valign="top">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 50%;">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td class="column_RightBold">Building Control No. :</td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBuildingControlNo" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Building Code :</td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBuildingCode" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Building Use :</td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBuildingUse" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Postal Code :</td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtPostalCode" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="width: 50%;">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td class="column_RightBold">Building Occupancy :</td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBuildingOccupancy" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">No. of Floors :</td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtNoofFloors" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Avg. Area per Floor :</td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtAvgAreaperFloor" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Cost per Area :</td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtCostperArea" runat="server" Width="75%"
                                                                            CssClass="txtbox_Var"
                                                                            Onkeyup="javascript:this.value=Comma(this.value);"
                                                                            Onchange="this.value=formatCurrency(this.value);" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="2" class="column_Center" style="padding-top: 10px;">
                                                <asp:Button ID="btnEditBuilding" runat="server" Width="200px" CssClass="CSButton"
                                                    Visible="false" Text="Edit" OnClientClick="StartProgressBar();" Enabled="false"></asp:Button>
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
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
            <asp:Panel ID="pnlBuildingLedger" runat="server" Width="1000px" CssClass="PanelSize" ScrollBars="Vertical">
                <asp:GridView ID="grdBuildingLedger" runat="server" Width="980px" SkinID="GridViewAA" Font-Size="8pt"
                    OnDataBound="OnBuildingLedgerDataBound">
                    <Columns>
                        <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Trans_Type" HeaderText="Particulars">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Top" Width="46%" />
                        </asp:BoundField>

                        <asp:BoundField DataField="ref" HeaderText="Ref. No.">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%" />
                        </asp:BoundField>

                        <asp:BoundField DataField="AccountablePerson" HeaderText="Accountable Person" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Department" HeaderText="Dept / Office" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:BoundField DataField="position" HeaderText="Position" Visible="False">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:BoundField DataField="acceptedby" HeaderText="Accepted By" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:BoundField DataField="inspectedby" HeaderText="Inspected By" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:BoundField DataField="DebitQty" HeaderText="Qty" SortExpression="DebitQty" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:BoundField DataField="DebitUnit" HeaderText="Unit" SortExpression="DebitUnit" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText="Debit Cost" SortExpression="DebitCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%" />
                        </asp:BoundField>

                        <asp:BoundField DataField="CreditQty" HeaderText="Qty" SortExpression="CreditQty" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:BoundField DataField="CreditUnit" HeaderText="Unit" SortExpression="CreditUnit" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText="Credit Cost" SortExpression="CreditCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%" />
                        </asp:BoundField>

                        <asp:BoundField DataField="BalQty" HeaderText="Qty" SortExpression="BalQty" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:BoundField DataField="BalanceUnit" HeaderText="Unit" SortExpression="BalUnit" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:BoundField DataField="BalCost" DataFormatString="{0:N}" HeaderText="Balance Cost" SortExpression="BalCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </td>
    </tr>

    <%-- Preview Button --%>
    <tr>
        <td style="width: 1000px" colspan="4">
            <asp:Button ID="btnBuildingPreview" OnClick="btnBuildingPreview_Click" runat="server"
                Width="200px" Text="PREVIEW" Visible="false"  CssClass="CSButton"></asp:Button>
            <asp:HiddenField ID="hdfBuildingLedgerReport" runat="server" />
        </td>
    </tr>
</table>
