<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PropertyCard_Rev_Machinery.ascx.vb" Inherits="Records_PropertyCard_Rev_Machinery" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table width="100%">
    <tr>
        <td class="DivTitle" style="width: 100%">
            LIST OF LOCATION (MACHINERY)
        </td>
    </tr>
    <tr>
        <td>
           <asp:GridView ID="gvMachineryLocationList" runat="server" 
                Width="1000px" SkinID="GridViewAA" HorizontalAlign="Center" 
                DataKeyNames="item_particular_id,Item_ID,DeclaredOwner,Barangay" 
                AllowPaging="True" 
                OnPageIndexChanging="gvMachineryLocationList_PageIndexChanging" 
                OnSelectedIndexChanged="gvMachineryLocationList_SelectedIndexChanged" 
                OnRowDataBound="gvMachineryLocationList_RowDataBound" 
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

                    <%-- Additional Machinery-specific columns --%>
                    <asp:BoundField DataField="ItemDescription" HeaderText="Description" Visible="false">
                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="SerialNo" HeaderText="Serial No." Visible="false">
                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Capacity" HeaderText="Capacity / Specs" Visible="false">
                        <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                    </asp:BoundField>
                </Columns>
    
                <%-- Add these style properties for selection --%>
               
            </asp:GridView>
        </td>
    </tr>

       <%-- Add View PIR Button --%>
    <tr>
        <td style="text-align: center; padding: 10px;">
            <asp:Button ID="btnViewPIR" runat="server" Width="240px" CssClass="CSButton" 
                Text="View Perpetual Inventory Report" OnClientClick="window.open('rpt_view_propertycard_v4.aspx')"></asp:Button>
        </td>
    </tr>
    
    <%-- Add spacing --%>
    <tr>
        <td style="height: 20px;"></td>
    </tr>
    
    <%-- New Section Header --%>
    <tr>
        <td class="DivTitle" style="width: 100%">
            LIST OF EQUIPMENTS (MACHINERY)
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
                            <asp:TextBox ID="txtMachineryPropSearch" runat="server" Width="95%"></asp:TextBox></td>
                        <td style="width: 30%" class="text5">
                            <asp:Button ID="btnMachineryPropSearch"  CssClass="CSButton"  OnClick="btnMachineryPropSearch_Click" runat="server" Width="150px" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>
    
    <%-- Equipment GridView --%>
    <tr>
        <td style="width: 1000px">
            <asp:GridView ID="grdlistofMachinery" runat="server" Width="1000px" SkinID="GridViewAA"
                OnPageIndexChanging="grdlistofMachinery_PageIndexChanging" AllowPaging="True" HorizontalAlign="Center" 
                DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo,Received_ID,AcquisitionCost,Received_Date,Date_Accepted,useful_life,Received_Dtl_ID"
                OnRowDataBound="grdlistofMachinery_RowDataBound" OnSelectedIndexChanged="grdlistofMachinery_SelectedIndexChanged" Font-Size="9pt"
                OnDataBound="grdlistofMachinery_ondatabound" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="PropertyNo" HeaderText="Property No." ControlStyle-CssClass="header">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Type" HeaderText="NAME">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="ServiceFloors" DataFormatString="{0:d}" HeaderText="Floor" Visible="false">
                        <HeaderStyle HorizontalAlign="Center" CssClass="d-none"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                    </asp:BoundField>
               
                    <asp:BoundField DataField="MachineLocation" DataFormatString="{0:d}" HeaderText="Room" Visible="false">
                        <HeaderStyle HorizontalAlign="Center" CssClass="d-none"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                    </asp:BoundField>
                
                    <asp:BoundField DataField="acquisitioncost" DataFormatString="{0:N}" HeaderText="WARRANTY PERIOD">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Right" Width="12%"></ItemStyle>
                    </asp:BoundField>
               
                    <asp:BoundField DataField="MaintenanceContractor" HeaderText="Contractor">
                        <ItemStyle HorizontalAlign="Right" Width="7%"></ItemStyle>
                    </asp:BoundField>
               

                    <asp:BoundField DataField="MaintenanceContactPerson" HeaderText="Contact Person">
                        <ItemStyle HorizontalAlign="Right" Width="11%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="MaintenanceContactNo" HeaderText="Cellphone No.">
                        <ItemStyle HorizontalAlign="Right" Width="11%"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <br />
        </td>
    </tr>


        <%-- Add spacing after equipment gridview --%>
    <tr>
        <td style="height: 20px;"></td>
    </tr>
    
    <%-- MACHINERY INFORMATION Header --%>
    <tr>
        <td style="width: 1000px" class="DivTitle">MACHINERY INFORMATION</td>
    </tr>
    
    
    <%-- Machinery Information Table --%>
    <tr>
        <td style="width: 1000px">
            <table width="100%">
                <tr>
                    <td style="width: 80%;" valign="top">
                        <table width="100%">
                            <tr>
                                <td style="width: 50%;">
                                    <table width="100%">
                                        <tr>
                                            <td class="column_RightBold">Name :
                                            </td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtMachineryName" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold">Description :
                                            </td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtMachineryDescription" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold">Power Input :
                                            </td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtMachineryPowerInput" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold">Model :
                                            </td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtMachineryModel" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold">Installed At :
                                            </td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtInstalledAt" runat="server" Width="75%" CssClass="txtbox_Var" Visible="false" Enabled="False"></asp:TextBox>
                                                <asp:DropDownList ID="drpMachineInstalledBuilding" runat="server" Width="75%" CssClass="drpdownCSS" Enabled="False" ></asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 50%;">
                                    <table width="100%">
                                        <tr>
                                            <td class="column_RightBold">Unit :
                                            </td>
                                            <td class="column_Left" colspan="3">
                                                <asp:TextBox ID="txtMachineryUnit" runat="server" Width="75%" CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                                <asp:DropDownList ID="drpMachineUnit" runat="server" Width="75%" CssClass="drpdownCSS" Enabled="False" ></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold">Dimension :
                                            </td>
                                            <td class="column_Left" colspan="3">
                                                <asp:TextBox ID="txtMachineryDimension" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold">Area Capacity :
                                            </td>
                                            <td class="column_Left" colspan="3">
                                                <asp:TextBox ID="txtMachineryAreaCapacity" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold">Warranty :
                                            </td>
                                            <td class="column_Left" colspan="3">
                                                <asp:TextBox ID="txtMachineryWarranty" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 25%">Floor Location :
                                            </td>
                                            <td class="column_Left" style="width: 25%">
                                                <asp:TextBox ID="txtMachineryFloorLocation" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 15%">Room :
                                            </td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtMachineryRoom" runat="server" Width="46%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <fieldset>
                                        <legend class="column_LeftBold">Maintenance</legend>
                                        <table width="100%">
                                            <tr>
                                                <td class="column_RightBold" style="width: 16%">Contractor : 
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtContractor" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 16%">Contact Person : 
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtContactPerson" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 16%">Cellphone No. : 
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtCellphoneNo" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top" rowspan="2">
                        <fieldset>
                            <asp:Image ID="Image7" runat="server" Width="204px" ImageUrl="~/images/blankImage.jpg" Height="202px"></asp:Image></center>
                            <br />
                            <br />
                            <asp:Button ID="btnUpload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>
                            <br />
                        </fieldset>
                        <br />
                        <asp:Button ID="btnSave" runat="server" Visible="false" Width="48%" CssClass="CSButton" Text="SAVE" Enabled="false" OnClientClick="StartProgressBar();"></asp:Button>
                        <asp:Button ID="btnCancel" runat="server" Visible="false"  Width="48%" CssClass="CSButton" Text="CANCEL" Enabled="false"></asp:Button>
                        <asp:TextBox ID="txtHideMe" runat="server" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 80%;" valign="top">
                        <fieldset>
                            <legend class="column_LeftBold">Acquisition :</legend>
                            <table>
                                <tr>
                                    <td class="column_RightBold">Acquisition Date :
                                    </td>
                                    <td class="column_Left" style="width: 100px;">
                                        <asp:Label ID="Label10" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtMachineryAcqDate" runat="server" CssClass="txtbox_Var" Enabled="False" onchange="return NoOfYearsMachine(this.value);"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtMachineryAcqDate" PopupButtonID="txtMachineryAcqDate"></cc1:CalendarExtender>
                                        &nbsp;(MM/DD/YYYY)</td>
                                    <td class="column_RightBold">Market Value :
                                    </td>
                                    <td class="column_Left">
                                        <asp:Label ID="Label11" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtMachineryMarketValue" runat="server" CssClass="txtbox_Var" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold">Acquisition Cost :
                                    </td>
                                    <td class="column_Left">
                                        <asp:Label ID="Label12" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtMachineryAcqCost" runat="server" CssClass="txtbox_Var" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalValMachine(this),getDepValRateMachine(this);"></asp:TextBox>
                                    </td>
                                    <td class="column_RightBold">No. of Years :
                                    </td>
                                    <td class="column_Left">
                                        <asp:Label ID="Label13" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtMachineryNoYears" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold">Depreciated Rate :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMachineryDepRate" runat="server" Width="100px" CssClass="txtboxAmount" MaxLength="5" ReadOnly="True" Enabled="False"></asp:TextBox>&nbsp;(%) Percent
                                    </td>
                                    <td class="column_RightBold">Useful Life :
                                    </td>
                                    <td class="column_Left">
                                        <asp:Label ID="Label14" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtMachineryUsefulLife" runat="server" Width="100px" CssClass="txtbox_Var" Enabled="False" onchange="return getDepValRateMachine(this);"></asp:TextBox>
                                        &nbsp;(Years)</td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold">Depreciated Value :</td>
                                    <td class="column_Left"><asp:TextBox runat="server" ID="txtDepreciatedValueMachineNew" CssClass="txtbox_Var"></asp:TextBox></td>
                                    <td class="column_RightBold">Salvage Value :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMachinerySalvageValue" runat="server" CssClass="txtboxAmount" Enabled="False" Onchange="this.value=formatCurrency(this.value);" Onkeyup="javascript:this.value=Comma(this.value);" Width="85%">0.00</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold">Depreciation Value :
                                    </td>
                                    <td class="column_Left">
                                        <asp:Label ID="Label15" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtequipmentdepreciatedvalue" runat="server" Width="100px" CssClass="txtbox_Var" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                    </td>
                                    <td class="column_RightBold">&nbsp;</td>
                                    <td class="column_Left">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
            </table>
        </td>
    </tr>


    <%-- Add spacing after Machinery Information Table --%>
    <tr>
        <td style="height: 20px;"></td>
    </tr>
    
    <%-- Button Tab Section --%>
    <tr>
        <td style="width: 1000px" class="text5">
            <table cellspacing="0" cellpadding="0" width="1000" border="0">
                <tbody>
                    <tr>
                        <td style="width: 167px; height: 26px">
                            <asp:Button ID="btnmachineryLedger" runat="server" Width="167px" CssClass="Initial" Text="Transactions"></asp:Button>
                        </td>
                        <td style="width: 156px; height: 26px">
                            <asp:Button ID="btnmachineryRepairs" runat="server" Width="167px" CssClass="Initial" Text="Repairs and Maintenance"></asp:Button>
                        </td>
                        <td style="width: 129px; height: 26px">
                            <asp:Button ID="btnmachineryDocattach" runat="server" Width="129px" CssClass="Initial" Text="Document Attached"></asp:Button>
                        </td>
                        <td style="width: 450px; height: 26px">
                            <asp:Label ID="lbl_MachineryId" runat="server" Text="Label" Visible="false"></asp:Label>
                            <asp:Label ID="lbl_MachineryInfoId" runat="server" Text="Label" Visible="false"></asp:Label>
                            <asp:Label ID="lbl_machine_Property_ID" runat="server" Text="Label" Visible="false"></asp:Label>
                            <asp:Label ID="lbl_Machine_Item_ID" runat="server" Text="Label" Visible="false"></asp:Label>
                        </td>
                        <td style="width: 325px; height: 26px" class="column_Center">
                            <asp:Button ID="btnEdit_Mechinery" runat="server" CssClass="CSButton" Enabled="True" OnClientClick="StartProgressBar();" Visible="false" Text="Edit" Width="75%" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>

    <%-- MultiView Container --%>
    <tr>
        <td colspan="4">
            <asp:MultiView ID="mvledger" runat="server" ActiveViewIndex="0">
            
                <%-- View 1: Ledger --%>
                <asp:View ID="vwledger" runat="server">
                    <table style="width: 1000px">
                        <tbody>
                            <tr style="display: none;">
                                <td style="width: 640px">
                                    <asp:Label ID="lblHistoryDetails" runat="server" Width="100%" Font-Bold="True" ForeColor="Blue" Font-Size="11pt" Font-Names="Calibri" CssClass="panel" Text="HISTORY DETAILS" BorderStyle="Solid" BorderWidth="1px" BorderColor="Blue"></asp:Label>
                                </td>
                                <td style="width: 120px">
                                    <asp:Label ID="Label2" runat="server" Width="100%" Font-Bold="True" ForeColor="Blue" Font-Size="11pt" Font-Names="Calibri" CssClass="panel" Text="DEBIT" BorderStyle="Solid" BorderWidth="1px" BorderColor="Blue"></asp:Label>
                                </td>
                                <td style="width: 120px">
                                    <asp:Label ID="Label3" runat="server" Width="100%" Font-Bold="True" ForeColor="Blue" Font-Size="11pt" Font-Names="Calibri" CssClass="panel" Text="CREDIT" BorderStyle="Solid" BorderWidth="1px" BorderColor="Blue"></asp:Label>
                                </td>
                                <td style="width: 120px">
                                    <asp:Label ID="Label4" runat="server" Width="100%" Font-Bold="True" ForeColor="Red" Font-Size="11pt" Font-Names="Calibri" CssClass="panel" Text="BALANCE" BorderStyle="Solid" BorderWidth="1px" BorderColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 1000px" colspan="4">
                                    <asp:Panel ID="Panel1" runat="server" Width="1000px" CssClass="PanelSize" ScrollBars="Vertical">
                                        <asp:GridView ID="grdLedger" runat="server" Width="980px" SkinID="GridViewAA" Font-Size="8pt" OnDataBound="OnDataBound">
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
                            <tr>
                                <td style="width: 1000px" colspan="4">
                                    <asp:Button ID="Button1" OnClick="btnPreview_Click"  Visible="false" runat="server" Width="200px" Text="PREVIEW" CssClass="CSButton"></asp:Button>
                                    <asp:HiddenField ID="HdfLedgerReport" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </asp:View>
            
                <%-- View 2: Repairs and Maintenance --%>
                <asp:View ID="vwrepairsandmaintenance" runat="server">
                    <asp:GridView ID="grdrepairsandmaintenance" runat="server" Width="950px" DataKeyNames="Property_Dtl_ID,RepairMaintenanceId" OnSelectedIndexChanged="grdrepairsandmaintenance_SelectedIndexChanged" SkinID="GridViewAA" HorizontalAlign="Center" Font-Size="9pt">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkPreview" runat="server" CausesValidation="False" Font-Size="10pt" Font-Names="Arial" Text="View Items" CommandName="Select" Font-Underline="False"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="100px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="ServiceProvider" HeaderText="Service Provider">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="NatureRepair" HeaderText="Nature of Repairs">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No.">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Total" DataFormatString="{0:N}" HeaderText="Amount">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </asp:View>
            
                <%-- View 3: Document Attachment --%>
                <asp:View ID="vwdocumentattachment" runat="server">
                    <table style="height: 236px" width="1000">
                        <tbody>
                            <tr>
                                <td style="vertical-align: top; width: 800px; height: 236px" align="center">
                                    <fieldset style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; width: 700px; padding-top: 5px; height: 223px" class="PanelBorder">
                                        <legend><span style="font-size: 11pt; font-family: Calibri"><strong>DOCUMENT DETAILS</strong></span></legend>
                                        <center>
                                            <asp:GridView ID="grdpropertydocdetails" runat="server" Width="650px" SkinID="gvnew" DataKeyNames="DocuId" OnRowDataBound="grdpropertydocdetails_RowDataBound" OnSelectedIndexChanged="grdpropertydocdetails_SelectedIndexChanged1" PageSize="5" Font-Size="9pt">
                                                <Columns>
                                                    <asp:BoundField DataField="DocumentName" HeaderText="Document Name"></asp:BoundField>
                                                    <asp:BoundField DataField="DocumentNo" HeaderText="Document No."></asp:BoundField>
                                                    <asp:BoundField DataField="ValidatedBy" HeaderText="Validated By"></asp:BoundField>
                                                    <asp:BoundField DataField="DateValidated" DataFormatString="{0:d}" HeaderText="Date Validated"></asp:BoundField>
                                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks"></asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </center>
                                    </fieldset>
                                </td>
                                <td style="vertical-align: top; width: 200px; height: 236px" align="center">
                                    <fieldset style="width: 255px; height: 232px" class="PanelBorder">
                                        <legend><span style="font-size: 11pt; font-family: Calibri"><strong>ATTACHED DOCUMENTS</strong></span></legend>
                                        <center>
                                            <asp:Image ID="imgpropertydocs" runat="server" Width="204px" ImageUrl="~/images/DefaulScannedDocuments.jpg" Height="202px"></asp:Image>
                                        </center>
                                    </fieldset>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </asp:View>
            </asp:MultiView>
        </td>
    </tr>
    
  
</table>