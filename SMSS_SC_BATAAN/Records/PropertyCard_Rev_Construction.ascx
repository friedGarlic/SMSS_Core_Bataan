<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PropertyCard_Rev_Construction.ascx.vb" Inherits="Records_PropertyCard_Rev_Construction" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table width="100%">
    <!-- ========================= -->
    <!-- LIST OF LOCATION -->
    <!-- ========================= -->
    <tr>
        <td class="DivTitle" style="width: 100%">
            LIST OF LOCATION (CONSTRUCTION IN PROGRESS)
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvConstructionLocationList" runat="server"
                Width="1000px" SkinID="GridViewAA" HorizontalAlign="Center"
                DataKeyNames="item_particular_id,Item_ID,DeclaredOwner,Barangay"
                AllowPaging="True"
                OnPageIndexChanging="gvConstructionLocationList_PageIndexChanging"
                OnSelectedIndexChanged="gvConstructionLocationList_SelectedIndexChanged"
                OnRowDataBound="gvConstructionLocationList_RowDataBound"
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

    <!-- View PIR Button -->
    <tr>
        <td style="text-align: center; padding: 10px;">
            <asp:Button ID="btnConstructionViewPIR" runat="server" Width="240px" CssClass="CSButton"
                Text="View Perpetual Inventory Report" OnClientClick="window.open('rpt_view_propertycard_v4.aspx')"></asp:Button>
        </td>
    </tr>

    <tr>
        <td style="height: 20px;"></td>
    </tr>

    <!-- ========================= -->
    <!-- LIST OF EQUIPMENTS -->
    <!-- ========================= -->
    <tr>
        <td class="DivTitle" style="width: 100%">
            LIST OF EQUIPMENTS
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
                            <asp:TextBox ID="txtConstructionPropSearch" runat="server" Width="95%"></asp:TextBox>
                        </td>
                        <td style="width: 30%" class="text5">
                            <asp:Button ID="btnConstructionPropSearch" CssClass="CSButton" OnClick="btnConstructionPropSearch_Click" runat="server"
                                Width="150px" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>

    <!-- Equipments GridView -->
    <tr>
        <td style="width: 1000px">
            <asp:GridView ID="grdListOfConstructionEquipments" runat="server" Width="1000px" SkinID="GridViewAA"
                OnPageIndexChanging="grdListOfConstructionEquipments_PageIndexChanging"
                AllowPaging="True" HorizontalAlign="Center"
                DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo,Received_ID,AcquisitionCost,Received_Date,Date_Accepted,useful_life,Received_Dtl_ID"
                OnRowDataBound="grdListOfConstructionEquipments_RowDataBound"
                OnSelectedIndexChanged="grdListOfConstructionEquipments_SelectedIndexChanged"
                OnDataBound="grdListOfConstructionEquipments_OnDataBound"
                Font-Size="9pt" AutoGenerateColumns="False">
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

    <tr>
        <td style="height: 20px;"></td>
    </tr>

    <!-- ========================= -->
    <!-- ITEM INFORMATION -->
    <!-- ========================= -->
    <tr>
        <td style="width: 1000px" class="DivTitle">ITEM INFORMATION</td>
    </tr>

    <tr>
        <td style="width: 1000px">
            <table width="100%">
                <tr>
                    <td align="center" style="width: 100%">
                        <asp:Label ID="lblConstructionHeader" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="7" style="width: 98%">
                        <asp:MultiView ID="mvSubClass" runat="server">
                            <!-- ========================= -->
                            <!-- ROAD VIEW -->
                            <!-- ========================= -->
                            <asp:View ID="vwRoad" runat="server">
                                <table>
                                    <tr>
                                        <td colspan="7" style="width: 100%">
                                            <fieldset>
                                                <legend class="column_LeftBold">General Information</legend>
                                                <table width="100%">
                                                    <tr>
                                                        <td class="column_RightBold">Project Name :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadProjectName" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Location :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadLocation" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Traffic Volume :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadTrafficVolume" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Road ID / Property Number:</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadID" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Length :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadLength" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Traffic Date :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtTrafficDate" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Road Name :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadName" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">No of Lanes :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtNoofLane" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Speed Limit :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadSpeedLimit" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Classification :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadClassification" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Width :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadWidth" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Elevation (m) :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadElevation" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Road Type :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadType" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Lane Length :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadLaneLength" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Surface Type :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadSurfaceType" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">From Street :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadFromStreet" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Lane Width :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadLaneWidth" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Surface Condition :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadSurfaceCondition" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">To Street :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadtoStreet" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Traffic Direction :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadTrafficDirection" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Remarks :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRemarksRoads" runat="server" Width="89%" CssClass="txtbox_Var"
                                                                TextMode="MultiLine" Rows="3"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Description :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtDescriptionRoads" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Segment Lock :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadSegmentLock" runat="server" Width="10%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="7" style="width: 100%">
                                            <fieldset>
                                                <table width="100%">
                                                    <tr>
                                                        <td class="column_LeftBold">Left</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">L from Address :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadLfromAddress" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">L to Address :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadLtoAddress" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">N/W Shldr Width :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadNorthWestWidth" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_LeftBold">Right</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">R from Address :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadRfromAddress" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">R to Address :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadRtoAddress" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">S/E Shldr Width :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoadSouthEastWidth" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="7" style="width: 100%">
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 80%">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <fieldset style="width: 90%;">
                                                                        <legend class="column_LeftBold">Acquisition :</legend>
                                                                        <table>
                                                                            <tr>
                                                                                <td class="column_RightBold">Acquisition Date :</td>
                                                                                <td class="column_Left" style="width: 100px;">
                                                                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                                                                    <asp:TextBox ID="txtRoadAcqDate" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="140px" onchange="return NoOfYears1(this.value);"></asp:TextBox>
                                                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                                                                        TargetControlID="txtRoadAcqDate" PopupButtonID="txtRoadAcqDate"></cc1:CalendarExtender>
                                                                                    &nbsp;(MM/DD/YYYY)
                                                                                </td>
                                                                                <td class="column_RightBold">Market Value :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:Label ID="Label3" runat="server"></asp:Label>
                                                                                    <asp:TextBox ID="txtRoadMarketValue" runat="server" CssClass="txtbox_Var"
                                                                                        Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); "></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="column_RightBold">Project Cost :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                                                                    <asp:TextBox ID="txtRoadAcqCost" runat="server" AutoPostBack="True" CssClass="txtbox_Var"
                                                                                        Onkeyup="javascript	this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalVal1(this),getDepValRate1(this);"></asp:TextBox>
                                                                                </td>
                                                                                <td class="column_RightBold">No. of Years :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:Label ID="lblNoYears" runat="server"></asp:Label>
                                                                                    <asp:TextBox ID="txtRoadNoYears" runat="server" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="column_RightBold">Depreciated Rate :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:TextBox ID="txtRoadequipmentdepreciatedRate" runat="server" Width="100px" AutoPostBack="True"
                                                                                        CssClass="txtboxAmount" MaxLength="5" ReadOnly="True"></asp:TextBox>
                                                                                    &nbsp;(%) Percent
                                                                                </td>
                                                                                <td class="column_RightBold">Useful Life :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:Label ID="lblUsefulLife" runat="server"></asp:Label>
                                                                                    <asp:TextBox ID="txtRoadUsefulLife" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var"
                                                                                        onchange="return getDepValRate1(this);"></asp:TextBox>
                                                                                    &nbsp;(Years)
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="column_RightBold">Depreciated Value :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:Label ID="lblequipmentdepreciatedvalue" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                    <asp:TextBox ID="txtRoadequipmentdepreciatedvalue" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                                                </td>
                                                                                <td class="column_RightBold">Salvage Value :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:TextBox ID="txtRoadSalvageValue" runat="server" Width="85%" CssClass="txtbox_Var">0.00</asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="column_RightBold">Depreciation Value :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:TextBox ID="txtDepreciationRoad" runat="server" CssClass="txtboxAmount" Width="140px"></asp:TextBox>
                                                                                </td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>
                                                                        </table>
                                                                    </fieldset>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <fieldset>
                                                                        <legend class="column_LeftBold">Contractor</legend>
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td class="column_RightBold">Contractor :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:TextBox ID="txtRoadContractor" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                </td>
                                                                                <td class="column_RightBold">Contact Person :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:TextBox ID="txtRoadContactPerson" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                </td>
                                                                                <td class="column_RightBold">Cellphone No. :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:TextBox ID="txtRoadCellphoneNo" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </fieldset>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="width: 20%; border: 2px solid #5c85d6">
                                                        <asp:Image ID="imgpropertydocs" runat="server" Width="204px" ImageUrl="~/images/blankImage.jpg" Height="202px"></asp:Image><br />
                                                        <asp:Button ID="btnUpload" runat="server" Width="48%" CssClass="CSButton" Enabled="false" Text="UPLOAD"></asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    
                                </table>
                            </asp:View>

                            <!-- ========================= -->
                            <!-- BRIDGE VIEW -->
                            <!-- ========================= -->
                            <asp:View ID="vwBridge" runat="server">
                                <table>
                                    <tr>
                                        <td colspan="7" style="width: 100%">
                                            <fieldset>
                                                <legend class="column_LeftBold">General Information</legend>
                                                <table width="100%">
                                                    <tr>
                                                        <td class="column_RightBold">Project Name :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeProjectName" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Location :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeLocation" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Name of River :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeNameofRiver" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Bridge ID / Property Number:</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeID" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Route No. :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeRouteNo" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Reference Post :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeReferencePost" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Bridge Name :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeName" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Featured Intersected :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeFeaturedIntersected" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">End Reference Post :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeEndReferencePost" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Bridge Type :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeType" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Mile Point :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeMilePoint" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Start Position :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeStartPosition" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Bridge Structure No. :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeStructureNo" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Border Struct No. :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeBorderStructNo" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Current Station :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeCurrentStation" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Route Sign Prefix :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeRouteSignPrefix" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Road No. :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeRoadNo" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">Remarks :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRemarks" runat="server" Width="89%" CssClass="txtbox_Var"
                                                                TextMode="MultiLine" Rows="3"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Description :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtDescription" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold"></td>
                                                        <td class="column_Left"></td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="7" style="width: 100%">
                                            <fieldset>
                                                <table width="100%">
                                                    <tr>
                                                        <td class="column_LeftBold">Left</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">L from Address :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeLfromAddress" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">L to Address :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeLtoAddress" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">N/W Shldr Width :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeNorthWestWidth" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_LeftBold">Right</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">R from Address :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeRfromAddress" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">R to Address :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeRtoAddress" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold">S/E Shldr Width :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBridgeSouthEastWidth" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="7" style="width: 100%">
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 80%">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <fieldset style="width: 90%;">
                                                                        <legend class="column_LeftBold">Acquisition :</legend>
                                                                        <table>
                                                                            <tr>
                                                                                <td class="column_RightBold">Acquisition Date :</td>
                                                                                <td class="column_Left" style="width: 100px;">
                                                                                    <asp:Label ID="Label4" runat="server"></asp:Label>
                                                                                    <asp:TextBox ID="txtBridgeAcqDate" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="140px" onchange="return NoOfYears(this.value);"></asp:TextBox>
                                                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                                                                        TargetControlID="txtBridgeAcqDate" PopupButtonID="txtBridgeAcqDate"></cc1:CalendarExtender>
                                                                                    &nbsp;(MM/DD/YYYY)
                                                                                </td>
                                                                                <td class="column_RightBold">Market Value :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:Label ID="Label5" runat="server"></asp:Label>
                                                                                    <asp:TextBox ID="txtBridgeMarketValue" runat="server" AutoPostBack="True" Width="140px"
                                                                                        CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="column_RightBold">Project Cost :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:Label ID="Label6" runat="server"></asp:Label>
                                                                                    <asp:TextBox ID="txtBridgeAcqCost" runat="server" AutoPostBack="True" Width="140px"
                                                                                        CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalVal(this),getDepValRate(this);"></asp:TextBox>
                                                                                </td>
                                                                                <td class="column_RightBold">No. of Years :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:Label ID="Label7" runat="server"></asp:Label>
                                                                                    <asp:TextBox ID="txtBridgeNoYears" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="50px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="column_RightBold">Depreciated Rate :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:TextBox ID="txtBridgeDepRate" runat="server" Width="50px" AutoPostBack="True"
                                                                                        CssClass="txtboxAmount" MaxLength="5"></asp:TextBox>
                                                                                    &nbsp;(%) Percent
                                                                                </td>
                                                                                <td class="column_RightBold">Useful Life :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:Label ID="Label8" runat="server"></asp:Label>
                                                                                    <asp:TextBox ID="txtBridgeUsefulLife" runat="server" Width="50px" AutoPostBack="True"
                                                                                        CssClass="txtbox_Var" onchange="return getDepValRate(this);"></asp:TextBox>
                                                                                    &nbsp;(Years)
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="column_RightBold">Depreciated Value :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:Label ID="Label9" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                    <asp:TextBox ID="txtBridgeDepValue" runat="server" Width="140px" CssClass="txtboxAmount" AutoPostBack="True"></asp:TextBox>
                                                                                </td>
                                                                                <td class="column_RightBold">Salvage Value :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:TextBox ID="txtBridgeSalvageValue" runat="server" Width="140px" CssClass="txtboxAmount" AutoPostBack="True">0.00</asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="column_RightBold">Depreciation Value :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:TextBox ID="txtDepreciationValue" runat="server" CssClass="txtboxAmount" Width="140px"></asp:TextBox>
                                                                                    &nbsp;(Per Year)
                                                                                </td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>
                                                                        </table>
                                                                    </fieldset>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <fieldset>
                                                                        <legend class="column_LeftBold">Contractor</legend>
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td class="column_RightBold">Contractor :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:TextBox ID="txtBridgeContractor" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                </td>
                                                                                <td class="column_RightBold">Contact Person :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:TextBox ID="txtBridgeContactPerson" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                </td>
                                                                                <td class="column_RightBold">Cellphone No. :</td>
                                                                                <td class="column_Left">
                                                                                    <asp:TextBox ID="txtBridgeCellphoneNo" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </fieldset>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="width: 20%; border: 2px solid #5c85d6">
                                                        <asp:Image ID="Image2" runat="server" Width="204px" ImageUrl="~/images/blankImage.jpg" Height="202px"></asp:Image><br />
                                                        <asp:Button ID="btnBridgeUpload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="7" align="right" style="width: 100%">
                                            <table width="100%">
                                                <tr>
                                                    <td align="right">
                                                        <asp:Button ID="btnBridgesave" runat="server" OnClientClick="StartProgressBar();" Text="SAVE" Width="100px" CssClass="CSButton"></asp:Button>
                                                    </td>
                                                    <td align="right" style="width: 105px">
                                                        <asp:Button ID="btnCancelBridge" runat="server" Text="CANCEL" Width="100px" CssClass="CSButton"></asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>


    <tr>
        <td style="height: 20px;"></td>
    </tr>

    <!-- ========================= -->
    <!-- TRANSACTIONS / LEDGER -->
    <!-- ========================= -->
    <tr>
        <td style="width: 1000px" class="DivTitle">TRANSACTIONS</td>
    </tr>

    <tr>
        <td style="width: 1000px" colspan="4">
            <asp:Panel ID="pnlConstructionLedger" runat="server" Width="1000px" CssClass="PanelSize" ScrollBars="Vertical">
                <asp:GridView ID="grdConstructionLedger" runat="server" Width="980px" SkinID="GridViewAA" Font-Size="8pt" OnDataBound="OnConstructionLedgerDataBound">
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
                        <asp:BoundField DataField="AccountablePerson" HeaderText="Accountable Person" Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="Department" HeaderText="Dept / Office" Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="position" HeaderText="Position" Visible="False"></asp:BoundField>
                        <asp:BoundField DataField="acceptedby" HeaderText="Accepted By" Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="inspectedby" HeaderText="Inspected By" Visible="false"></asp:BoundField>

                        <asp:BoundField DataField="DebitQty" HeaderText="Qty" SortExpression="DebitQty" Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="DebitUnit" HeaderText="Unit" SortExpression="DebitUnit" Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText=" " SortExpression="DebitCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="CreditQty" HeaderText="Qty" SortExpression="CreditQty" Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="CreditUnit" HeaderText="Unit" SortExpression="CreditUnit" Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText=" " SortExpression="CreditCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="BalQty" HeaderText="Qty" SortExpression="BalQty" Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="BalanceUnit" HeaderText="Unit" SortExpression="BalUnit" Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="BalCost" DataFormatString="{0:N}" HeaderText=" " SortExpression="BalCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </td>
    </tr>

    <tr>
        <td style="width: 1000px" colspan="4">
            <asp:Button ID="btnConstructionPreview" OnClick="btnConstructionPreview_Click" runat="server" Width="200px" Text="PREVIEW" Visible="false"  CssClass="CSButton"></asp:Button>
            <asp:HiddenField ID="HdfConstructionLedgerReport" runat="server" />
        </td>
    </tr>
</table>
