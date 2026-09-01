<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PropertyCard_Rev_Vehicle.ascx.vb" Inherits="Records_PropertyCard_Rev_Vehicle" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table width="100%">

    <%-- =========================
         LIST OF LOCATION (VEHICLE)
         ========================= --%>
    <tr>
        <td class="DivTitle" style="width: 100%">
            LIST OF LOCATION (VEHICLE)
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvVehicleLocationList" runat="server"
                Width="1000px" SkinID="GridViewAA" HorizontalAlign="Center"
                DataKeyNames="item_particular_id,Item_ID,DeclaredOwner,Barangay"
                AllowPaging="True"
                OnPageIndexChanging="gvVehicleLocationList_PageIndexChanging"
                OnSelectedIndexChanged="gvVehicleLocationList_SelectedIndexChanged"
                OnRowDataBound="gvVehicleLocationList_RowDataBound"
                AutoGenerateColumns="False" Font-Size="9pt"
                EnableSelection="True">
                <Columns>
                    <asp:BoundField DataField="Property_code" HeaderText="CODE" Visible="False"></asp:BoundField>

                    <asp:BoundField DataField="PlateNo" HeaderText="Plate No.">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="MakeModel" HeaderText="Make / Model">
                        <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="EngineNo" HeaderText="Engine No.">
                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="ChassisNo" HeaderText="Chassis No.">
                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Location" HeaderText="Location / User">
                        <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="AcqDate" HeaderText="Acquisition Date">
                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="AcqCost" HeaderText="Acquisition Cost">
                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="MarketValue" HeaderText="Market Value">
                        <ItemStyle HorizontalAlign="Center" Width="6%"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>

    <%-- View PIR Button --%>
    <tr>
        <td style="text-align: center; padding: 10px;">
            <asp:Button ID="btnViewVehiclePIR" runat="server" Width="240px" CssClass="CSButton"
                Text="View Perpetual Inventory Report"
                OnClientClick="window.open('rpt_view_propertycard_v4.aspx')"></asp:Button>
        </td>
    </tr>

    <%-- spacing --%>
    <tr><td style="height: 20px;"></td></tr>

    <%-- =========================
         LIST OF VEHICLES
         ========================= --%>
    <tr>
        <td class="DivTitle" style="width: 100%">
            LIST OF VEHICLES
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
                            <asp:TextBox ID="txtVehiclePropSearch" runat="server" Width="95%"></asp:TextBox>
                        </td>
                        <td style="width: 30%" class="text5">
                            <asp:Button ID="btnVehiclePropSearch" CssClass="CSButton"
                                OnClick="btnVehiclePropSearch_Click"
                                runat="server" Width="150px" Text="SEARCH"
                                OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>

    <%-- Vehicles List GridView --%>
    <tr>
        <td style="width: 1000px">
            <asp:GridView ID="grdListOfVehicles" runat="server" Width="1000px" SkinID="GridViewAA"
                OnPageIndexChanging="grdListOfVehicles_PageIndexChanging"
                AllowPaging="True" HorizontalAlign="Center"
                DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo,Received_ID,AcquisitionCost,Received_Date,Date_Accepted,useful_life,Received_Dtl_ID"
                OnRowDataBound="grdListOfVehicles_RowDataBound"
                OnSelectedIndexChanged="grdListOfVehicles_SelectedIndexChanged"
                Font-Size="9pt"
                OnDataBound="grdListOfVehicles_OnDataBound"
                AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="PropertyNo" HeaderText="Property No." ControlStyle-CssClass="header">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Property_code" HeaderText="Property No." Visible="false">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="PlateNo" HeaderText="Plate No.">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="MakeModel" HeaderText="Make / Model">
                        <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="EngineNo" HeaderText="Engine No.">
                        <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="ChassisNo" HeaderText="Chassis No.">
                        <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="AcqDate" HeaderText="Acquisition Date">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="AcqCost" HeaderText="Acquisition Cost">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="MarketValue" HeaderText="Market Value">
                        <ItemStyle HorizontalAlign="Center" Width="11%"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <br />
        </td>
    </tr>

    <%-- spacing --%>
    <tr><td style="height: 20px;"></td></tr>

    <%-- =========================
         VEHICLE INFORMATION
         ========================= --%>
    <tr>
        <td style="width: 1000px" class="DivTitle">VEHICLE INFORMATION</td>
    </tr>

    <tr>
        <td style="width: 1000px">
            <table width="100%">
                <tr>
                    <td style="width: 80%;" valign="top">
                        <table width="100%">
                            <tr>
                                <td align="center" style="width: 100%">
                                    <table style="width: 100%;">

                                        <tr>
                                            <td class="column_RightBold" style="width: 10%; height: 23px;">Plate No. :</td>
                                            <td class="column_Left" style="width: 30%; height: 23px;">
                                                <asp:TextBox ID="txtVehiclePlateNo" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                                            </td>

                                            <td class="column_RightBold" style="width: 10%; height: 23px;">Make / Model :</td>
                                            <td class="column_Left" style="width: 30%; height: 23px;">
                                                <asp:TextBox ID="txtVehicleMakeModel" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                                            </td>

                                            <td align="center" rowspan="6" style="width: 20%;" valign="middle">
                                                <asp:Image ID="imgVehicle" runat="server" CssClass="textimage2" Height="160px"
                                                    ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                                <br />
                                                <asp:Button ID="btnVehicleUpload" runat="server" Width="48%" CssClass="CSButton"
                                                    Text="UPLOAD" Enabled="false"></asp:Button>
                                                <br /><br />
                                                <asp:Button ID="btnEditVehicle" runat="server" Width="48%" CssClass="CSButton"
                                                    Visible="false" Text="EDIT" OnClientClick="StartProgressBar();" />
                                            </td>

                                        </tr>

                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Engine No. :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtVehicleEngineNo" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                                            </td>

                                            <td class="column_RightBold" style="width: 10%">Chassis No. :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtVehicleChassisNo" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Location / User :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtVehicleLocationUser" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                                            </td>

                                            <td class="column_RightBold" style="width: 10%">Category :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtVehicleCategory" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                             <td class="column_RightBold" style="width: 10%">Unit :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:Label ID="LabelA" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                <asp:DropDownList ID="ddVehicleUnit" runat="server" Width="91%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="false"></asp:DropDownList>
                                            </td>
                                             <td class="column_RightBold" style="width: 10%"> </td>
                                            <td class="column_Left" style="width: 30%">
                                               
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
                                                                <asp:TextBox ID="txtVehicleAcquisitionDate" runat="server" CssClass="txtbox_Var" Width="100px" Enabled="False"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="ceVehicleAcquisitionDate" runat="server" TargetControlID="txtVehicleAcquisitionDate" PopupButtonID="txtVehicleAcquisitionDate"></cc1:CalendarExtender>
                                                                &nbsp;(MM/DD/YYYY)
                                                            </td>
                                                            <td class="column_RightBold" style="width: 25%">Market Value :</td>
                                                            <td class="column_Left" style="width: 25%">
                                                                <asp:TextBox ID="txtVehicleMarketValue" runat="server" CssClass="txtbox_Var" Width="150px" Enabled="False"
                                                                    Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="column_RightBold">Acquisition Cost :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtVehicleAcquisitionCost" runat="server" CssClass="txtbox_Var" Width="150px" Enabled="False"
                                                                    Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">No. of Years :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtVehicleNoYears" runat="server" CssClass="txtbox_Var" Width="100px" Enabled="False"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="column_RightBold">Depreciated Rate :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtVehicleDepRate" runat="server" CssClass="txtbox_Var" Width="150px" Enabled="False"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Useful Life :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtVehicleUsefulLife" runat="server" CssClass="txtbox_Var" Width="100px" Enabled="False"></asp:TextBox>
                                                                &nbsp;(Years)
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="column_RightBold">Depreciated Value :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtDepreciatedValueVehicleNew" runat="server" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Salvage Value :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtVehicleSalvageValue" runat="server" CssClass="txtbox_Var" Enabled="False"
                                                                    Onchange="this.value=formatCurrency(this.value);" Onkeyup="javascript:this.value=Comma(this.value);" Width="150px"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="column_RightBold">Depreciation Value :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtVehicleDepValue" runat="server" CssClass="txtbox_Var" Width="150px" Enabled="False"
                                                                    Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">&nbsp;</td>
                                                            <td class="column_Left">&nbsp;</td>
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
            <asp:Panel ID="pnlVehicleLedger" runat="server" Width="1000px" CssClass="PanelSize" ScrollBars="Vertical">
                <asp:GridView ID="grdVehicleLedger" runat="server" Width="980px" SkinID="GridViewAA" Font-Size="8pt"
                    OnDataBound="OnVehicleLedgerDataBound">
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
            <asp:Button ID="btnVehiclePreview"  Visible="false"  OnClick="btnVehiclePreview_Click" runat="server"
                Width="200px" Text="PREVIEW" CssClass="CSButton"></asp:Button>
            <asp:HiddenField ID="hdfVehicleLedgerReport" runat="server" />
        </td>
    </tr>

</table>
