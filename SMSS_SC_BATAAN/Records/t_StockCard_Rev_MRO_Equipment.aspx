
<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="false"
    AutoEventWireup="false" CodeFile="t_StockCard_Rev_MRO_Equipment.aspx.vb" Inherits="Records_t_StockCard_Rev_MRO_Equipment"
    Title="Encoding of MRO Equipment" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../Membership/MasterPage/js/autoCurrency.js"></script>
     <script type="text/javascript">
        window.onbeforeunload = function (e) {
            var e = e || window.event;

            // For IE and FireFox
            var value = "There is some data to be saved!"

            if (e) {
                e.returnValue = value;
            }

            // For Safari
            return value;
        }
    </script>

    <asp:ScriptManager ID="ScriptManagerMROEquipment" runat="server"></asp:ScriptManager>

    <style type="text/css">
        .required-label {
            position: relative;
            display: inline-block;
        }

        .required-label::before {
            content: "*";
            position: absolute;
            left: -9px;
            top: 0;
            color: Red;
            font-weight: bold;
        }
    </style>

    <script type="text/javascript">
        function StartProgressBar() {
            var progressPopup = $find('ProgressBarModalPopupExtender');

            if (progressPopup != null) {
                progressPopup.show();
            }
        }

        function BeginRequestHandler(sender, args) {
            var progressPopup = $find('ProgressBarModalPopupExtender');

            if (progressPopup != null) {
                progressPopup.show();
            }
        }

        function EndRequestHandler(sender, args) {
            var progressPopup = $find('ProgressBarModalPopupExtender');

            if (progressPopup != null) {
                progressPopup.hide();
            }
        }

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">
                            <strong>MRO Equipment</strong>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>

                    <tr>
                        <td style="width: 1%"></td>

                        <td style="width: 98%" class="column_LeftBold">
                           <span class="required-label">General Account :</span>
                            <asp:DropDownList ID="ddGlAccount" runat="server" Width="20%" AutoPostBack="True"
                                CssClass="drpdownCSS" OnSelectedIndexChanged="ddGlAccount_SelectedIndexChanged">
                            </asp:DropDownList>

                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                            <span>Sub Classification :</span>
                            <asp:DropDownList ID="DrpSubClass" runat="server" Width="20%" AutoPostBack="True" 
                                CssClass="drpdownCSS" OnSelectedIndexChanged="DrpSubClass_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>

                        <td style="width: 1%"></td>
                    </tr>

                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">MRO EQUIPMENT INFORMATION</td>
                        <td style="width: 1%"></td>
                    </tr>

                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">

                            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                <asp:View ID="ViewEquipment" runat="server">

                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="column_RightBold" style="width: 10%"><span class="required-label">Name :</span></td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:DropDownList ID="drpMROEquipmentName" AutoPostBack="true" runat="server" Width="91%"   CssClass="drpdownCSS"
                                                    OnSelectedIndexChanged="drpMROEquipmentName_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>

                                            <td class="column_RightBold" style="width: 10%"> <span class="required-label">Unit :</span>  </td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:DropDownList ID="drpMROEquipmentUnit"  runat="server" Enabled="false" Width="91%"></asp:DropDownList>
                                            </td>

                                            <td align="center" rowspan="6" style="width: 20%" valign="middle">
                                                <asp:Image ID="imgEquipment" runat="server" CssClass="textimage2" Height="160px"
                                                    ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                                <br />
                                                <asp:Button ID="btnUploadEquipment" runat="server" Width="48%" CssClass="CSButton" Enabled="false" Text="UPLOAD"></asp:Button>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Description :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtEquipmentDescription" AutoPostBack="True"  runat="server" Width="89%" CssClass="txtbox_Var"></asp:TextBox>
                                            </td>

                                            <td class="column_RightBold" style="width: 10%">Dimension :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtEquipmentDimension"  AutoPostBack="True" runat="server" Width="89%" CssClass="txtbox_Var"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="column_RightBold" style="width: 10%; height: 38px;">Power Input :</td>
                                            <td class="column_Left" style="width: 30%; height: 38px;">
                                                <asp:TextBox ID="txtEquipmentPowerInput" AutoPostBack="True"  runat="server" Width="89%" CssClass="txtbox_Var"></asp:TextBox>
                                            </td>

                                            <td class="column_RightBold" style="width: 10%; height: 38px;">Area Capacity :</td>
                                            <td class="column_Left" style="width: 30%; height: 38px;">
                                                <asp:TextBox ID="txtEquipmentAreaCapacity"  AutoPostBack="True" runat="server" Width="89%" CssClass="txtbox_Var"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Model :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtEquipmentModel"  AutoPostBack="True" runat="server" Width="89%" CssClass="txtbox_Var"></asp:TextBox>
                                            </td>

                                            <td class="column_RightBold" style="width: 10%">Warranty :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtEquipmentWarranty" AutoPostBack="True"  runat="server" Width="89%" CssClass="txtbox_Var"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="width: 10%" class="column_RightBold">Reorder Pt. :</td>
                                            <td style="width: 30%" class="column_Left">
                                                <asp:TextBox ID="txtEquipmentReOrderPt"  AutoPostBack="True" runat="server" Width="40%" CssClass="txtbox_Amt" ReadOnly="False" Enabled="True"></asp:TextBox>
                                                <asp:Button ID="btnEquipmentROP" CssClass="CSButton" runat="server" Text="R.O.P" Width="40" OnClick="btnROP_Click" />
                                            </td>

                                            <td style="width: 10%" class="column_RightBold"></td>
                                            <td style="width: 30%" class="column_Left"></td>
                                        </tr>

                                        <tr>
                                            <td colspan="4">
                                                <fieldset style="width: 90%;">
                                                    <legend class="column_LeftBold">Acquisition :</legend>

                                                    <table>
                                                        <tr>
                                                            <td class="column_RightBold" style="width: 125px"><span class="required-label">Acquisition Date :</span></td>
                                                            <td class="column_Left" style="width: 100px;">
                                                                <asp:TextBox ID="txtEquipmentAcqDate" runat="server" CssClass="txtbox_Var"   onchange="return NoOfYears(this.value);" Width="140px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtenderAcqDate" runat="server" TargetControlID="txtEquipmentAcqDate" PopupButtonID="txtEquipmentAcqDate"></cc1:CalendarExtender>
                                                                &nbsp;(MM/DD/YYYY)
                                                            </td>

                                                            <td class="column_RightBold">Market Value :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtEquipmentMarketValue" runat="server" AutoPostBack="True"  CssClass="txtboxAmount"
                                                                    Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);" Width="140px"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="column_RightBold" style="width: 125px"><span class="required-label">Acquisition Cost :</span></td>
                                                            <td class="column_Left">
                                                              <asp:TextBox ID="txtEquipmentAcqCost"
                                                                AutoPostBack="True"
                                                                runat="server"
                                                                CssClass="txtboxAmount"
                                                                Onkeyup="javascript:this.value=Comma(this.value);"
                                                                Onchange="this.value=formatCurrency(this.value); getSalVal(this); getDepValRate(this);"
                                                                onkeydown="if (event.keyCode == 13) { this.blur(); return false; }"
                                                                Width="140px">
                                                            </asp:TextBox>
                                                            </td>

                                                            <td class="column_RightBold">No. of Years :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtEquipmentNoYears" AutoPostBack="True"  runat="server" CssClass="txtbox_Var" Width="50px"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="column_RightBold" style="width: 125px">Depreciated Rate :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtEquipmentDepreciatedRate"  AutoPostBack="True" runat="server" CssClass="txtboxAmount" MaxLength="5"  Width="50px"></asp:TextBox>
                                                                &nbsp;(%) Percent
                                                            </td>

                                                            <td class="column_RightBold">Useful Life :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtEquipmentUsefulLife" AutoPostBack="True" Enabled="false"  runat="server" Width="50px" CssClass="txtbox_Var" onchange="return getDepValRate(this);"></asp:TextBox>
                                                                &nbsp;(Years)
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="column_RightBold" style="width: 125px">&nbsp;Depreciated Value :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtEquipmentDepreciatedValue" AutoPostBack="True"  runat="server" CssClass="txtboxAmount" Width="140px"></asp:TextBox>
                                                            </td>

                                                            <td class="column_RightBold">Salvage Value :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtEquipmentSalvageValue" AutoPostBack="True"  runat="server" Width="140px" CssClass="txtboxAmount">0.00</asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="column_RightBold" style="width: 125px">&nbsp;Depreciation Value :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtEquipmentDepreciationValue" AutoPostBack="True"  runat="server" CssClass="txtboxAmount" Width="140px"></asp:TextBox>
                                                                &nbsp;(Per Year)
                                                            </td>

                                                            <td class="column_RightBold"><span class="required-label">Quantity:</span></td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtEquipmentQuantity"  AutoPostBack="True" runat="server" CssClass="txtbox_Var"   Width="50px" onchange="return correctQty(this.value);"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </fieldset>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="4">
                                                <fieldset style="width: 90%;">
                                                    <legend class="column_Left" style="font-family: Arial; color: #404040;"><strong>Location:</strong></legend>

                                                    <table width="100%">
                                                        <tr>
                                                            <td class="column_RightBold">Warehouse :</td>
                                                            <td class="column_Left">
                                                                <asp:DropDownList ID="drpEquipmentWarehouse" runat="server" Width="98%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                            </td>

                                                            <td class="column_RightBold">Bay :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtEquipmentBay"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>

                                                            <td class="column_RightBold" style="width: 15%">Column :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtEquipmentColumn" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>

                                                            <td class="column_RightBold" style="width: 10%">Floor :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtEquipmentFloor"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="column_RightBold">Room :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtEquipmentRoom" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>

                                                            <td class="column_RightBold" style="width: 10%">Shelves :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtEquipmentShelves"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>

                                                            <td class="column_RightBold">Rack :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtEquipmentRack" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>

                                                            <td class="column_RightBold">Bin :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtEquipmentBin"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </fieldset>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="column_RightBold" style="width: 10%; height: 43px;">Specifications :</td>
                                            <td class="column_Left" colspan="3" style="height: 43px">
                                                <asp:TextBox ID="txtEquipmentSpecification" runat="server" Width="95%" Height="25px"
                                                    TextMode="MultiLine" CssClass="txtbox_Var" Rows="2"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                            <td class="column_RightBold" colspan="3"></td>
                                            <td>
                                                <asp:Button ID="btnEquipmentSave" runat="server" Width="48%" CssClass="CSButton" Text="SAVE"
                                                    Enabled="True" OnClick="btnEquipmentSave_Click" ></asp:Button>
                                                <asp:Button ID="btnEquipmentCancel" runat="server" Width="48%" CssClass="CSButton" Text="CANCEL" Enabled="true" OnClick="btnEquipmentCancel_Click"></asp:Button>
                                            </td>
                                        </tr>

                                    </table>

                                </asp:View>
                            </asp:MultiView>

                        </td>
                        <td style="width: 1%"></td>
                    </tr>

                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">

                            <asp:Panel ID="Panel2" runat="server" Width="100%" CssClass="PanelSize" ScrollBars="Vertical">
                                <asp:GridView ID="grdLedger" runat="server" Width="100%" SkinID="GridViewAA"
                                    OnRowDataBound="grdLedger_RowDataBound" DataKeyNames="Item_ID,StockID" AutoGenerateColumns="False">
                                    <Columns>

                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                              
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbInspection" runat="server" AutoPostBack="True"
                                                    OnCheckedChanged="cbInspection_CheckedChanged"></asp:CheckBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="10px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date">
                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="2%"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Trans_Type" HeaderText="PARTICULARS">
                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Top" Width="46%"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="ref" HeaderText="Ref. No." Visible="FALSE" />
                                        <asp:BoundField DataField="AccountablePerson" HeaderText="Accountable Person" Visible="FALSE" />
                                        <asp:BoundField DataField="Department" HeaderText="Dept / Office" Visible="FALSE" />
                                        <asp:BoundField DataField="position" HeaderText="Position" Visible="False" />
                                        <asp:BoundField DataField="acceptedby" HeaderText="Accepted By" Visible="FALSE" />

                                        <asp:BoundField DataField="BalanceUnit" HeaderText="UNIT">
                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="25px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="2%"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Cost" HeaderText="UNIT PRICE">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="DebitQty" HeaderText="Debit Qty">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText="Debit Cost">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="9%"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="CreditQty" HeaderText="Credit Qty">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText="Credit Cost">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="9%"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="BalQty" HeaderText="Balance Qty">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="BalCost" DataFormatString="{0:N}" HeaderText="Balance Cost">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="9%"></ItemStyle>
                                        </asp:BoundField>

                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>

                        </td>
                        <td style="width: 1%"></td>
                    </tr>

                </table>
            </div>

            <asp:Panel ID="popupROP" runat="server" Width="350px" CssClass="Panel_Popup">
                <table width="100%">
                    <tr>
                        <td style="width: 100%; height: 30px; margin-left: 40px;" colspan="3" class="DivTitle">
                            REORDER POINT COMPUTATION
                            <asp:ImageButton ID="BtnImageClose" ImageUrl="~/images/Edited Image/CloseButton.png"
                                runat="server" Height="13px" Width="16px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="column_RightBold">Demand Per Day :</td>
                        <td class="column_Left">
                            <asp:TextBox ID="DRP" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="column_RightBold">Lead Time for Delivery:</td>
                        <td class="column_Left">
                            <asp:TextBox ID="LTD" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="column_RightBold"></td>
                        <td>
                            <asp:Button ID="BtnCompute" runat="server" Width="133px" CssClass="CSButton"
                                Text="Compute" OnClick="BtnCompute_Click"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td class="column_RightBold">Reorder Point :</td>
                        <td class="column_Left">
                            <asp:TextBox ID="RP" runat="server" CssClass="txtbox_Var" Width="150px" s></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%; height: 10px">
                            <asp:Label runat="server" ID="lblpopupROP"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>

            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
                TargetControlID="lblpopupROP"
                PopupControlID="popupROP"
                CancelControlID="BtnImageClose"
                BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>


            <asp:Label ID="lblApprovalTarget" runat="server" Style="display:none;"></asp:Label>

<cc1:ModalPopupExtender ID="ModalPopupExtenderApproval" runat="server"
    TargetControlID="lblApprovalTarget"
    PopupControlID="PanelApproval"
    BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="PanelApproval" runat="server" Width="350px" CssClass="Panel_Popup" DefaultButton="btnApprovalProceed" >
    <table width="100%">
        <tr>
            <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">
                APPROVAL
            </td>
        </tr>
        <tr>
            <td class="column_RightBold">Approving Officer :</td>
            <td class="column_Left">
                <asp:DropDownList ID="drpApprovedOfficer" runat="server" Width="150px" CssClass="ddropbox"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="column_RightBold">Password :</td>
            <td class="column_Left">
                <asp:TextBox ID="txtApprovedPass" runat="server" CssClass="txtbox_Var" Width="150px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="btnApprovalProceed" runat="server" Width="150px" CssClass="CSButton" Text="PROCEED" OnClick="btnApprovalProceed_Click"></asp:Button>
                <asp:Button ID="btnApprovalCancel" runat="server" Width="150px" CssClass="CSButton" Text="CANCEL" CausesValidation="False" OnClick="btnApprovalCancel_Click"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Panel>


            <asp:Panel ID="PanelProgress" runat="server" Width="109px"
                Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc">
                <img alt="Loading..." src="../images/ajax-loader.gif" />
            </asp:Panel>

            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender"
                runat="server"
                BackgroundCssClass="modalBackground"
                TargetControlID="ButtonProgress"
                PopupControlID="PanelProgress"
                BehaviorID="ProgressBarModalPopupExtender">
            </cc1:ModalPopupExtender>

            <asp:Button ID="ButtonProgress" runat="server" Width="16px"
                Enabled="False" Style="display: none;">
            </asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
