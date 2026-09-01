<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PropertyCard_Rev_Office_Equipment.ascx.vb" Inherits="Records_PropertyCard_Rev_Office_Equipment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table width="100%">
    <%-- =========================
         LIST OF LOCATION
         ========================= --%>
    <tr>
        <td class="DivTitle" style="width: 100%">
            LIST OF LOCATION (OFFICE EQUIPMENT)
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvOfficeEquipmentLocationList" runat="server"
                Width="1000px" SkinID="GridViewAA" HorizontalAlign="Center"
                DataKeyNames="item_particular_id,Item_ID,DeclaredOwner,Barangay"
                AllowPaging="True"
                OnPageIndexChanging="gvOfficeEquipmentLocationList_PageIndexChanging"
                OnSelectedIndexChanged="gvOfficeEquipmentLocationList_SelectedIndexChanged"
                OnRowDataBound="gvOfficeEquipmentLocationList_RowDataBound"
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

    <%-- View PIR Button --%>
    <tr>
        <td style="text-align: center; padding: 10px;">
            <asp:Button ID="btnViewOfficeEquipmentPIR" runat="server" Width="240px" CssClass="CSButton"
                Text="View Perpetual Inventory Report" OnClientClick="window.open('rpt_view_propertycard_v4.aspx')"></asp:Button>
        </td>
    </tr>

    <%-- spacing --%>
    <tr><td style="height: 20px;"></td></tr>

    <%-- =========================
         LIST OF OFFICE EQUIPMENTS
         ========================= --%>
    <tr>
        <td class="DivTitle" style="width: 100%">
            LIST OF OFFICE EQUIPMENTS
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
                            <asp:TextBox ID="txtOfficeEquipmentPropSearch" runat="server" Width="95%"></asp:TextBox>
                        </td>
                        <td style="width: 30%" class="text5">
                            <asp:Button ID="btnOfficeEquipmentPropSearch" CssClass="CSButton" OnClick="btnOfficeEquipmentPropSearch_Click"
                                runat="server" Width="150px" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>

    <%-- Office Equipments List GridView (same columns as grdlistofBooks) --%>
    <tr>
        <td style="width: 1000px">
            <asp:GridView ID="grdListOfOfficeEquipments" runat="server" Width="1000px" SkinID="GridViewAA"
                OnPageIndexChanging="grdListOfOfficeEquipments_PageIndexChanging"
                AllowPaging="True" HorizontalAlign="Center"
                DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo,Received_ID,AcquisitionCost,Received_Date,Date_Accepted,useful_life,Received_Dtl_ID"
                OnRowDataBound="grdListOfOfficeEquipments_RowDataBound"
                OnSelectedIndexChanged="grdListOfOfficeEquipments_SelectedIndexChanged"
                Font-Size="9pt"
                OnDataBound="grdListOfOfficeEquipments_OnDataBound"
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
         OFFICE EQUIPMENT INFORMATION
         ========================= --%>
    <tr>
        <td style="width: 1000px" class="DivTitle">OFFICE EQUIPMENT INFORMATION</td>
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
                                            <td class="column_RightBold" style="width: 10%">Name :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtOfficeEquipmentName" runat="server" Width="290px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 10%">Unit :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:DropDownList ID="drpOfficeEquipmentUnit" runat="server" CssClass="drpdownCSS" Width="100px" Enabled="False"></asp:DropDownList>
                                                <span class="column_RightBold">Quantity :</span>
                                                <asp:TextBox ID="txtOfficeEquipmentQuantity" runat="server" Width="100px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td align="center" rowspan="6" style="width: 20%" valign="middle">
                                                <asp:Image ID="imgOfficeEquipment" runat="server" CssClass="textimage2" Height="160px"
                                                    ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                                <br />
                                                <asp:Button ID="btnOfficeEquipmentUpload" runat="server" Width="48%" CssClass="CSButton"
                                                    Text="UPLOAD" Enabled="false"></asp:Button>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Description :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtOfficeEquipmentDesc" runat="server" Width="290px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 10%">Warranty :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtOfficeEquipmentWarranty" runat="server" Width="290px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Power Input :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtOfficeEquipmentPowerInput" runat="server" Width="290px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold">Remark :</td>
                                            <td class="column_Left">
                                                 <asp:TextBox ID="txtOfficeEquipmentRemarks" runat="server" Width="290px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                          
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Model :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtOfficeEquipmentModel" runat="server" Width="290px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 10%">Dimension :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtOfficeEquipmentDimension" runat="server" Width="290px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Serial Number :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtOfficeEquipmentSerialNo" runat="server" Width="290px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td class="column_Left"></td>
                                        </tr>

                                        <tr>
                                            <td colspan="4">
                                                <fieldset style="width: 93%">
                                                    <legend class="column_LeftBold">Maintenance</legend>
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="column_RightBold">Contractor :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtOfficeEquipmentContractor" runat="server" Width="100px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Contact Person :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtOfficeEquipmentContactPerson" runat="server" Width="100px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Cellphone No. :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtOfficeEquipmentContactNo" runat="server" Width="100px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
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
                                                    <table>
                                                        <tr>
                                                            <td class="column_RightBold" style="width: 15%;">Acquisition Date :</td>
                                                            <td class="column_Left" style="width: 25%;">
                                                                <asp:TextBox ID="txtOfficeEquipmentAcqDate" runat="server" CssClass="txtbox_Var" Width="100px"
                                                                    Enabled="False" onchange="return NoOfYearsOfficeEquipment(this.value);"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="ceOfficeEquipmentAcqDate" runat="server"
                                                                    TargetControlID="txtOfficeEquipmentAcqDate" PopupButtonID="txtOfficeEquipmentAcqDate"></cc1:CalendarExtender>
                                                                &nbsp;(MM/DD/YYYY)
                                                            </td>
                                                            <td class="column_RightBold" style="width: 25%;">Market Value :</td>
                                                            <td class="column_Left" style="width: 25%;">
                                                                <asp:TextBox ID="txtOfficeEquipmentMarketValue" runat="server" CssClass="txtbox_Var" Width="100px"
                                                                    Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="column_RightBold">Acquisition Cost :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtOfficeEquipmentAcqCost" runat="server" CssClass="txtbox_Var" Enabled="False"
                                                                    Onkeyup="javascript:this.value=Comma(this.value);"
                                                                    Onchange="this.value=formatCurrency(this.value); return getSalValOfficeEquipment(this),getDepValRateOfficeEquipment(this);"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">No. of Years :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtOfficeEquipmentNoYears" runat="server" CssClass="txtbox_Var" Width="100px" Enabled="False"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="column_RightBold">Depreciated Rate :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtOfficeEquipmentDepRate" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Useful Life :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtOfficeEquipmentUsefulLife" runat="server" CssClass="txtbox_Var" Width="100px"
                                                                    Enabled="False" onchange="return getDepValRateOfficeEquipment(this);"></asp:TextBox>
                                                                &nbsp;(Years)
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="column_RightBold">Depreciated Value :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtDepreciatedValueOfficeEquipmentNew" runat="server" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Salvage Value :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtOfficeEquipmentSalvageValue" runat="server" CssClass="txtbox_Var" Enabled="False"
                                                                    Onchange="this.value=formatCurrency(this.value);" Onkeyup="javascript:this.value=Comma(this.value);" Width="100px"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="column_RightBold">Depreciation Value :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtOfficeEquipmentDepValue" runat="server" CssClass="txtbox_Var" Enabled="False"
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
                                            <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                            <td class="column_RightBold" colspan="3"></td>
                                            <td class="column_Center">
                                                <asp:Button ID="btnEditOfficeEquipment" runat="server" Width="75%" CssClass="CSButton"
                                                    Visible="false" Text="Edit" OnClientClick="StartProgressBar();"></asp:Button>
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
            <asp:Panel ID="pnlOfficeEquipmentLedger" runat="server" Width="1000px" CssClass="PanelSize" ScrollBars="Vertical">
                <asp:GridView ID="grdOfficeEquipmentLedger" runat="server" Width="980px" SkinID="GridViewAA" Font-Size="8pt"
                    OnDataBound="OnOfficeEquipmentLedgerDataBound">
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
                        <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText=" " SortExpression="DebitCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CreditQty" HeaderText="Qty" SortExpression="CreditQty" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CreditUnit" HeaderText="Unit" SortExpression="CreditUnit" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText=" " SortExpression="CreditCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="BalQty" HeaderText="Qty" SortExpression="BalQty" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="BalanceUnit" HeaderText="Unit" SortExpression="BalUnit" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
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
            <asp:Button ID="btnOfficeEquipmentPreview" OnClick="btnOfficeEquipmentPreview_Click" runat="server"
                Width="200px" Text="PREVIEW" Visible="false"  CssClass="CSButton"></asp:Button>
            <asp:HiddenField ID="hdfOfficeEquipmentLedgerReport" runat="server" />
        </td>
    </tr>
</table>
