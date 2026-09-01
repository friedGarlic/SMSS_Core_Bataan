<%@ Page Title="Checklist for Unserviceable Properties" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Disposal_CheckList.aspx.vb" Inherits="Inventory_Disposal_Disposal_CheckList"
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript"> 
        function stopRKey(evt) {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type == "text")) {
                return false;
            }
        }
        document.onkeypress = stopRKey;
    </script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">CHECKLIST FOR UNSERVICEABLE PROPERTIES
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <span class="column_RightBold">Date :</span>
                            &nbsp;<asp:TextBox runat="server" ID="txtDate" CssClass="txtbox_Date" Width="10%" MaxLength="10"></asp:TextBox>
                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtDate" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                            <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtDate" PopupButtonID="txtDate" PopupPosition="TopLeft"></cc1:CalendarExtender>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="90%">
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Department :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpDept" CssClass="drpdownCSS" Width="95%" AutoPostBack="true">
                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Allotment :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpAllotment" CssClass="drpdownCSS" Width="50%">
                                            <asp:ListItem Value="1" Text="Capital Outlay" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Function :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpFunction" CssClass="drpdownCSS" Width="95%">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Gen. Account :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpGenAccount" CssClass="drpdownCSS" Width="95%" AutoPostBack="true">
                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                    <td style="width: 15%" class="column_RightBold">Checklist :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpChecklist" CssClass="drpdownCSS" Width="60%" Enabled="false" AutoPostBack="true">
                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Vehicles/Heavy Equipment"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Office Equipment"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:RadioButtonList runat="server" ID="rbItems" CssClass="rbCS_Horizontal" RepeatDirection="Horizontal" Width="30%" Visible="false">
                                <asp:ListItem Value="1" Text="FOR DISPOSAL" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="2" Text="FROM INVENTORY"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button runat="server" ID="btnView" Text="View" CssClass="CSButton" Width="12%" OnClientClick="StartProgressBar();" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List of Items
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Search :</span>
                            &nbsp;<asp:DropDownList runat="server" ID="drpSearch" CssClass="drpdownCSS" Width="10%">
                                <asp:ListItem Value="1" Text="Property No." Selected="True"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Description"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:TextBox runat="server" ID="txtSearch" CssClass="txtbox_Var" Width="30%"></asp:TextBox>
                            &nbsp;<asp:Button runat="server" ID="btnSearch" Width="12%" CssClass="CSButton" Text="Search" OnClientClick="StartProgressBar();" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView runat="server" ID="grdItemsList" SkinID="GridViewAA" Width="100%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="15"
                                DataKeyNames="PropertyDetai_ID,Property_Date,Cost,SerialNo,MotorNo,Returned_Date">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelect" CssClass="LinkBtnSelect" Visible='<%#Bind("isVisible") %>' Text="Select" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" DataField="PropertyNo" HeaderText="Property No." />
                                    <asp:BoundField ItemStyle-Width="50%" ItemStyle-HorizontalAlign="Left" DataField="Item_Desc" HeaderText="Description" />
                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="UnitDesc" HeaderText="Unit" />
                                    <asp:BoundField ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Right" DataField="Cost" HeaderText="Unit Cost" DataFormatString="{0:N}" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Details
                            &nbsp;<asp:Label runat="server" ID="lblDetails"></asp:Label>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:MultiView runat="server" ID="mvCheckList">

                                <asp:View runat="server" ID="vwOffice">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 1%"></td>
                                            <td style="width: 98%" align="center">
                                                <table width="80%">
                                                    <tr>
                                                        <td style="width: 30%" class="column_RightBold">Unit Serial No. :</td>
                                                        <td style="width: 70%" class="column_Left">
                                                            <asp:TextBox runat="server" ID="txtOE_SerialNo" CssClass="txtbox_Var" Width="40%" Text="" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 30%" class="column_RightBold">Acquisition Date :</td>
                                                        <td style="width: 70%" class="column_Left">
                                                            <asp:TextBox runat="server" ID="txtOE_AcquiredDate" CssClass="txtbox_Date" Width="25%" Text="" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 30%" class="column_RightBold">Date Reported as Unserviceable :
                                                        </td>
                                                        <td style="width: 70%" class="column_Left">
                                                            <asp:TextBox runat="server" ID="txtOE_DateUnserviceable" CssClass="txtbox_Date" Width="25%" Text="" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 1%"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 1%"></td>
                                            <td style="width: 98%; height: 10px"></td>
                                            <td style="width: 1%"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 1%"></td>
                                            <td style="width: 98%" align="center">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 20px" colspan="4"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">LEGEND :</td>
                                                        <td style="width: 25%" class="column_Left"></td>
                                                        <td style="width: 25%" class="column_RightBold"></td>
                                                        <td style="width: 25%" class="column_Left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px" colspan="4"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">S</td>
                                                        <td style="width: 25%" class="column_Left">= Serviceable
                                                        </td>
                                                        <td style="width: 25%" class="column_RightBold">X</td>
                                                        <td style="width: 25%" class="column_Left">= Unserviceable</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">M</td>
                                                        <td style="width: 25%" class="column_Left">= Missing
                                                        </td>
                                                        <td style="width: 25%" class="column_RightBold">NA</td>
                                                        <td style="width: 25%" class="column_Left">= Not Applicable</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 30px" colspan="4"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_CenterBold">ELECTRICAL :</td>
                                                        <td style="width: 25%" class="column_Left"></td>
                                                        <td style="width: 25%" class="column_CenterBold">MECHANICAL :</td>
                                                        <td style="width: 25%" class="column_Left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Motor Compressor</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_MotorCompressor" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Compressor</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_Compressor" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Running Capacitor</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_RunningCapacitor" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Thermostat</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_Thermostat" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Starting Capacitor</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_StartingCapacitor" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Condenser</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_Condenser" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Selector Switch</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_SelectorSwitch" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Evaporator</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_Evaporator" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Magnetic Contactor</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_MagneticContactor" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Filter Drier</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_FilterDrier" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Relay</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_Relay" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Capillary Tube</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_CapillaryTube" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Overload Protector</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_OverloadProtector" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">H/L Pressure Switch</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_PressureSwitch" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Condensed Fan Motor</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_CondensedFanMotor" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Expansion Valve</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_ExpansionValve" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Fan Motor</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_FanMotor" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Strainer</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_Strainer" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Time Relay Switch</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_TimeRelaySwitch" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Surge Tank</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_SurgeTank" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Wiring</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_Wiring" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Heat Exchanger</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_HeatExchanger" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Solenoid</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_Solenoid" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Sight Glass</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_SightGlass" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 30px" colspan="4"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_CenterBold">OTHERS :</td>
                                                        <td style="width: 25%" class="column_Left"></td>
                                                        <td style="width: 25%" class="column_CenterBold"></td>
                                                        <td style="width: 25%" class="column_Left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Body</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_Body" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Casing</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_Casing" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Front Cover</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_FrontCover" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Air Filter Element</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpOE_AirFilterElement" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 30px" colspan="4"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_CenterBold"></td>
                                                        <td style="width: 25%" class="column_Left"></td>
                                                        <td style="width: 25%" class="column_CenterBold">INSPECTED BY :</td>
                                                        <td style="width: 25%" class="column_Left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold"></td>
                                                        <td style="width: 25%" class="column_Left"></td>
                                                        <td style="width: 25%" class="column_RightBold"></td>
                                                        <td style="width: 25%" class="column_Left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold"></td>
                                                        <td style="width: 25%" class="column_Left"></td>
                                                        <td style="width: 25%" class="column_RightBold">Name :</td>
                                                        <td style="width: 25%" class="column_Left">
                                                            <asp:TextBox runat="server" ID="txtOE_Inspectedby" CssClass="txtbox_Var" Width="90%"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold"></td>
                                                        <td style="width: 25%" class="column_Left"></td>
                                                        <td style="width: 25%" class="column_RightBold">Designation :</td>
                                                        <td style="width: 25%" class="column_Left">
                                                            <asp:TextBox runat="server" ID="txtOE_InspectedBy_Pos" CssClass="txtbox_Var" Width="90%"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 1%"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 1%"></td>
                                            <td style="width: 98%; height: 20px"></td>
                                            <td style="width: 1%"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 1%"></td>
                                            <td style="width: 98%" align="center">
                                                <asp:Button runat="server" ID="btnOE_Save" CssClass="CSButton" Width="12%" Enabled="false" Text="Save" OnClientClick="StartProgressBar();" />
                                                &nbsp;<asp:Button runat="server" ID="btnOE_Preview" CssClass="CSButton" Width="12%" Enabled="false" Text="Preview" OnClientClick="StartProgressBar();" />
                                            </td>
                                            <td style="width: 1%"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 1%"></td>
                                            <td style="width: 98%; height: 20px"></td>
                                            <td style="width: 1%"></td>
                                        </tr>

                                    </table>
                                </asp:View>


                                <asp:View runat="server" ID="vwVehicles">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 1%"></td>
                                            <td style="width: 98%" align="center">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">Unit Serial No. :</td>
                                                        <td style="width: 25%" class="column_Left">
                                                            <asp:TextBox runat="server" ID="txtUnitSerialNo" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 25%" class="column_RightBold">Engine Serial No. :</td>
                                                        <td style="width: 25%" class="column_Left">
                                                            <asp:TextBox runat="server" ID="txtEngineSerialNo" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">Acquisition Cost :</td>
                                                        <td style="width: 25%" class="column_Left">
                                                            <asp:TextBox runat="server" ID="txtAcqCost" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 25%" class="column_RightBold">Date :</td>
                                                        <td style="width: 25%" class="column_Left">
                                                            <asp:TextBox runat="server" ID="txtAcqDate" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 30px" colspan="4"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">LEGEND :</td>
                                                        <td style="width: 25%" class="column_Left"></td>
                                                        <td style="width: 25%" class="column_RightBold"></td>
                                                        <td style="width: 25%" class="column_Left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px" colspan="4"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">S</td>
                                                        <td style="width: 25%" class="column_Left">= Serviceable
                                                        </td>
                                                        <td style="width: 25%" class="column_RightBold">X</td>
                                                        <td style="width: 25%" class="column_Left">= Unserviceable</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">M</td>
                                                        <td style="width: 25%" class="column_Left">= Missing
                                                        </td>
                                                        <td style="width: 25%" class="column_RightBold">NA</td>
                                                        <td style="width: 25%" class="column_Left">= Not Applicable</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 30px" colspan="4"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_CenterBold">ENGINE :</td>
                                                        <td style="width: 25%" class="column_Left"></td>
                                                        <td style="width: 25%" class="column_CenterBold">SUSPENSIONS :</td>
                                                        <td style="width: 25%" class="column_Left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Operating Condition</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpEngine_OperatingCondition" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Front Spring Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpSusp_FrontSpring" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Injection Pump Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpEngine_InjectionPump" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Rear Spring Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpSusp_RearSpring" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Injection / Nozzle Assy.</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpEngine_Nozzle" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Fuel Pump Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpEngine_FuelPump" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Cylinder Head Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpEngine_CylinderHead" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_CenterBold">WHEELS :</td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Water Pump Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpEngine_WaterPump" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Tires Front</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpWheel_TiresFront" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Radiator Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpEngine_Radiator" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Tires Rear</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpWheel_TireRear" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Air Cleaner Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpEngine_AirCleaner" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Spare Tire</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpWheel_Spare" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Carburator Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpEngine_Carburator" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Governor Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpEngine_Governor" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_CenterBold">PROPELLER SHAFT ASSY. :</td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Turbo Charger</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpEngine_Turbo" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Front</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpShaft_Front" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Oil Cooler Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpEngine_OilCooler" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Rear</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpShaft_Rear" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">No. of Cylinders</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpEngine_NoCylinder" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_CenterBold">ELECTRICAL :</td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                        <td style="width: 25%" class="column_CenterBold">DIFFERENTIAL ASSY. :</td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Generator / Alterator Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpElec_Generator" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Front</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpDiff_Front" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Starter Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpElec_Starter" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Rear</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpDiff_Rear" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Voltage Regulator Assy.</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpElec_VoltageRegulator" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Solenoid Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpElec_Solenoid" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_CenterBold">FINAL DRIVE :</td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Ignition Coil Assy</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpElec_IgnitionCoil" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Sprocket Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpFinal_Sprocket" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Magneto</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpElec_Magneto" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Drive Chain</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpFinal_DriveChain" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Distributor Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpElec_Distributor" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">2/cap, rotor</td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                        <td style="width: 25%" class="column_CenterBold">UNDERCARRIAGES :</td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Wiper Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpElec_Wiper" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Track Link Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpCarriage_TrackLink" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Headlight Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpElec_HeadLight" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Idler Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpCarriage_Idler" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Stop & Tail light Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpElec_TailLight" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Track Adjuster Assy.</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpCarriage_TrackAdjuster" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Directional Light Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpElec_DirectionalLightdrp" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Track Roller Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpCarriage_TrackRoller" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">(front & rear)</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpElec_FrontRear" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Carrier Roller Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpCarriage_CarrierRoller" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Battery</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpElec_Battery" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">TORQUE CONVERTER</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpCarriage_Torque" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">CLUTCH ASSEMBLY</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpElec_Clutch" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">BODY/CAB/FENDERS</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpCarriage_Fenders" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                        <td style="width: 25%" class="column_Right">CHASSIS/FRAME</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpCarriage_ChasisFrame" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_CenterBold">CUSHIONS :</td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                        <td style="width: 25%" class="column_Right">WINDSHIELD</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpCarriage_Windshield" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Front Seat</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpCushions_FrontSeat" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">FUEL TANK ASSEMBLY</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpCarriage_FuelTank" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Rear Seat</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpCushion_RearSeat" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Operator's Seat</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpCushion_OperatorSeat" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Ignition Coil Assy</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpCushion_IgnitionCoil" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_CenterBold">GAUGES :</td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                        <td style="width: 25%" class="column_CenterBold">HYDRAULIC SYSTEM :</td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Hour / Service Meter</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpGauge_ServiceMeter" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Hydraulic Pump Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpHydraulic_Pump" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Speedometer</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpGauge_SpeedoMeter" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Hydraulic Motor Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpHydraulic_Motor" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Tachometer</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpGauge_TachoMeter" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Hydraulic Hoses</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpHydraulic_Hoses" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Temperature Gauges</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpGauge_Temperature" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Control Valve Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpHydraulic_ControlValve" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">(water)</td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                        <td style="width: 25%" class="column_Right">Hydraulic Cylinders</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpHydraulic_Cylinders" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Oil Pressure Gauges</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpGauge_OilPressure" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">TRANSMISSION ASSEMBLY</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpHydraulic_Transmission" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Converter oil Temperature Gauges</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpGauge_ConverterOil" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">TRANSFERCASE ASSEMBLY</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpHydraulic_TransferCase" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                        <td style="width: 25%" class="column_Right">WINDSHIELD</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpHydraulic_Windshield" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_CenterBold">BRAKE SYSTEM :</td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                        <td style="width: 25%" class="column_Right">FUEL TANK ASSEMBLY</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpHydraulic_FuelTank" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Master Cylinder Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpBrake_MasterCylinder" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_CenterBold">STEERING SYSTEM :</td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Power Steering System</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpSteering_Power" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Steering Clutch Assembly with</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpSteering_Clutch" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Disc Plate & Brake Lining</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpSteering_DiskPlate" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_CenterBold">ACCESSORIES :</td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                        <td style="width: 25%" class="column_Right"></td>
                                                        <td style="width: 25%" class="column_Center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Dozer/Blade Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpAcc_Dozer" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Riper Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpAcc_Riper" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Cutting Edges</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpAcc_CuttingEdges" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">End Bits</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpAcc_EndBits" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Dragline Bucket</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpAcc_Dragline" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Clamshell Bucket</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpAcc_Clamshell" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Backhoe Bucket</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpAcc_Backhoe" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Ditching Bucket</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpAcc_Ditching" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Fairlead Assembly (for crane)</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpAcc_Fairlead" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Tagline Assembly (for crane)</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpAcc_Tagline" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Compressor</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpAcc_Compressor" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Cables</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpAcc_Cables" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Boom Assembly</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpAcc_Boom" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Boom Pulley</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpAcc_BoomPully" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td style="width: 25%" class="column_Right">Lifting Block</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpAcc_LiftingBlock" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%" class="column_Right">Others</td>
                                                        <td style="width: 25%" class="column_Center">
                                                            <asp:DropDownList runat="server" ID="drpAcc_Others" CssClass="drpdownCSS" Width="50%">
                                                                <asp:ListItem Value="1" Text="NA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="S"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="X"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="M"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold"></td>
                                                        <td style="width: 25%" class="column_Left"></td>
                                                        <td style="width: 25%" class="column_RightBold"></td>
                                                        <td style="width: 25%" class="column_Left"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 1%"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 1%"></td>
                                            <td style="width: 98%; height: 10px"></td>
                                            <td style="width: 1%"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 1%"></td>
                                            <td style="width: 98%" align="center">
                                                <table width="90%">
                                                    <tr>
                                                        <td style="width: 100%" class="column_LeftBold">Remarks :
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:TextBox runat="server" ID="txtRemarks" CssClass="txtbox_Remarks" Width="80%" Height="200px" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 1%"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 1%"></td>
                                            <td style="width: 98%" align="center">
                                                <table width="90%">
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold"></td>
                                                        <td style="width: 35%" class="column_Left"></td>
                                                        <td style="width: 15%" class="column_RightBold">Inspected By :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:DropDownList runat="server" ID="drpInspectedBy1" CssClass="drpdownCSS" Width="95%"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px" colspan="4"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_CenterBold">OTHERS:</td>
                                                        <td style="width: 35%" class="column_Left"></td>
                                                        <td style="width: 15%" class="column_RightBold"></td>
                                                        <td style="width: 35%" class="column_Left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_Right">Body</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox runat="server" ID="txtOthers_Body" CssClass="txtbox_Var" Width="35%"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold"></td>
                                                        <td style="width: 35%" class="column_Left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_Right">Casing</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox runat="server" ID="txtOthers_Casing" CssClass="txtbox_Var" Width="35%"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold"></td>
                                                        <td style="width: 35%" class="column_Left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_Right">Front Cover</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox runat="server" ID="txtOthers_FrontCover" CssClass="txtbox_Var" Width="35%"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold"></td>
                                                        <td style="width: 35%" class="column_Left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_Right">Air Filter Element</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox runat="server" ID="txtOthers_AirFilter" CssClass="txtbox_Var" Width="35%"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold"></td>
                                                        <td style="width: 35%" class="column_Left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px" colspan="4"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold"></td>
                                                        <td style="width: 35%" class="column_Left"></td>
                                                        <td style="width: 15%" class="column_RightBold">Inspected By :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:DropDownList runat="server" ID="drpInspectedby2" CssClass="drpdownCSS" Width="95%"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 1%"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 1%"></td>
                                            <td style="width: 98%; height: 20px"></td>
                                            <td style="width: 1%"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 1%"></td>
                                            <td style="width: 98%" align="center">
                                                <asp:Button runat="server" ID="btnSave" CssClass="CSButton" Enabled="false" Text="Save" Width="15%" OnClientClick="StartProgressBar();" />
                                                &nbsp;<asp:Button runat="server" ID="btnPreview" CssClass="CSButton" Enabled="false" Text="Preview" Width="15%" OnClientClick="StartProgressBar();" />
                                            </td>
                                            <td style="width: 1%"></td>
                                        </tr>

                                    </table>
                                </asp:View>


                            </asp:MultiView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>



                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 20px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

