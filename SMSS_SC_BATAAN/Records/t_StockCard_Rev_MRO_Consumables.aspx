<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="false"
    AutoEventWireup="false" CodeFile="t_StockCard_Rev_MRO_Consumables.aspx.vb" Inherits="Records_t_StockCard_Rev_MRO_Consumables"
    Title="Encoding of MRO Consumables" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../Membership/MasterPage/js/autoCurrency.js"></script>

    <asp:ScriptManager ID="ScriptManagerMROCons" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">
                            <strong>MRO Consumables</strong>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>

                    <tr>
                        <td style="width: 1%"></td>

                        <td style="width: 98%" class="column_LeftBold">
                            Sub Classification :
                            <asp:DropDownList ID="DrpSubClass" runat="server" Width="20%" AutoPostBack="True"
                                CssClass="drpdownCSS" OnSelectedIndexChanged="DrpSubClass_SelectedIndexChanged">
                            </asp:DropDownList>

                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                            General Account :
                            <asp:DropDownList ID="ddGlAccount" runat="server" Width="20%" AutoPostBack="True"
                                CssClass="drpdownCSS" OnSelectedIndexChanged="ddGlAccount_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>

                        <td style="width: 1%"></td>
                    </tr>

                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">MRO CONSUMABLES INFORMATION</td>
                        <td style="width: 1%"></td>
                    </tr>

                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">

                            <table width="100%">
                                <tr>
                                    <td style="width: 70%" align="center">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">
                                                    Name :
                                                    <asp:HiddenField ID="hdnItemNo" runat="server" />
                                                    <asp:HiddenField ID="hdnGAId" runat="server" />
                                                </td>

                                                <td style="width: 35%" class="column_Left">
                                                    <asp:DropDownList ID="drpConsOthersName" AutoPostBack="true" runat="server" Width="98%"
                                                        OnSelectedIndexChanged="drpConsOthersName_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>

                                                <td style="width: 15%;" class="column_RightBold">Unit :</td>
                                                <td style="width: 35%;" class="column_Left">
                                                    <asp:DropDownList ID="drpConsOthersUnit" runat="server" Width="40%" Enabled="false" ></asp:DropDownList>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Brand Name :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox ID="txtConsOthersBrandName" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>

                                                <td colspan="2" rowspan="5" style="padding-left: 50px;">
                                                    <fieldset>
                                                        <legend class="column_Left" style="font-family: Arial; color: #404040;">
                                                            <strong>Mftg Info:</strong>
                                                        </legend>

                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 35%" class="column_RightBold">Batch :</td>
                                                                <td style="width: 65%" class="column_Left">
                                                                    <asp:TextBox ID="txtConsOthersBatch" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="column_RightBold">Lot :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtConsOthersLot" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="column_RightBold">Mftg. Date :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtMDateConsOthers" runat="server" Width="50%" CssClass="txtbox_Date"></asp:TextBox>
                                                                    &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="column_RightBold">Expiry Date :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtEDateConsOthers" runat="server" Width="50%" CssClass="txtbox_Date"></asp:TextBox>
                                                                    &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="color: red;" class="column_RightBold">Alert :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtAlertConsOthers" runat="server" Width="50%" CssClass="txtbox_Date"></asp:TextBox>
                                                                    &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Form :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox ID="txtConsOthersForm" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Unit Cost :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox ID="txtConsOthersUnitPrice" runat="server" Width="40%" CssClass="txtbox_Amt"
                                                        Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Reorder Pt. :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox ID="txtConsOthersReOrderPt" runat="server" CssClass="txtbox_Amt" Width="50px"></asp:TextBox>
                                                    <asp:Button ID="btnROP" runat="server" CssClass="CSButton" OnClick="btnROP_Click" Text="R.O.P" Width="40" />
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Quantity :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox ID="txtConsOthersQuantity" runat="server" CssClass="txtbox_Amt" Width="40%"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="column_RightBold">Date :</td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtSellectDateCons" runat="server" CssClass="txtbox_Var0"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender8" runat="server"
                                                        TargetControlID="txtSellectDateCons" PopupButtonID="txtSellectDateCons">
                                                    </cc1:CalendarExtender>
                                                </td>
                                                <td></td>
                                                <td></td>
                                            </tr>

                                            <tr>
                                                <td colspan="4">
                                                    <fieldset>
                                                        <legend class="column_Left" style="font-family: Arial; color: #404040;">
                                                            <strong>Location:</strong>
                                                        </legend>

                                                        <table width="100%">
                                                            <tr>
                                                                <td class="column_RightBold">Warehouse :</td>
                                                                <td class="column_Left">
                                                                    <asp:DropDownList ID="drpMROConsOthersWarehouse" runat="server" Width="175px" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                                </td>

                                                                <td class="column_RightBold">Bay :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtConsOthersBay" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>
                                                                </td>

                                                                <td class="column_RightBold" style="width: 10%">Column :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtConsOthersColumn" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>
                                                                </td>

                                                                <td class="column_RightBold" style="width: 10%">Floor :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtConsOthersFloor" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="column_RightBold">Room :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtConsOthersRoom" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>
                                                                </td>

                                                                <td class="column_RightBold" style="width: 10%">Shelves :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtConsOthersShelves" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>
                                                                </td>

                                                                <td class="column_RightBold">Rack :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtConsOthersRack" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>
                                                                </td>

                                                                <td class="column_RightBold">Bin :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtConsOthersBin" runat="server" Width="50px" CssClass="txtbox_Var" AutoCompleteType="Disabled"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </td>
                                            </tr>

                                        </table>
                                    </td>

                                    <td style="width: 30%" align="center">
                                        <img alt="" height="160" src="../images/Default_Image.jpg" width="80%" /><br />
                                        <asp:Button ID="btnConsOthersUpload" runat="server" Width="120px" CssClass="CSButton" Enabled="false" Text="UPLOAD"></asp:Button>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2" style="text-align: right;">
                                        <asp:Button ID="btnConsOthersSave" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" OnClick="btnConsOthersSave_Click"></asp:Button>
                                        &nbsp; &nbsp; &nbsp;
                                        <asp:Button ID="btnConsOthersCancel" runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClick="btnConsOthersCancel_Click"></asp:Button>
                                    </td>
                                </tr>

                            </table>

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
                                                <asp:CheckBox ID="CheckBox2" runat="server" Font-Bold="true" ForeColor="White"
                                                    Font-Size="10pt" Font-Names="tahoma" Text="All"></asp:CheckBox>
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
                            <asp:TextBox ID="RP" runat="server" CssClass="txtbox_Var" Width="150px" ReadOnly="False"></asp:TextBox>
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

            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtMDateConsOthers" PopupButtonID="txtMDateConsOthers"></cc1:CalendarExtender>
            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtEDateConsOthers" PopupButtonID="txtEDateConsOthers"></cc1:CalendarExtender>
            <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtAlertConsOthers" PopupButtonID="txtAlertConsOthers"></cc1:CalendarExtender>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
