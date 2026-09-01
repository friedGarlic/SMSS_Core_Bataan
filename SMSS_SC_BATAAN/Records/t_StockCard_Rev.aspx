<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="false"
    AutoEventWireup="false" CodeFile="t_StockCard_Rev.aspx.vb" Inherits="Records_t_StockCard_Rev"
    Title="Encoding of Office Supplies" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../Membership/MasterPage/js/autoCurrency.js"></script>

    <asp:ScriptManager ID="ScriptManagerStock" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">
                            <strong>Supplies</strong>
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
                        <td style="width: 98%" class="DivTitle">SUPPLIES INFORMATION</td>
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
                                                    <asp:DropDownList ID="drpItemDesc1" AutoPostBack="true" runat="server" Width="98%"
                                                        OnSelectedIndexChanged="drpItemDesc1_SelectedIndexChanged" Height="16px">
                                                    </asp:DropDownList>
                                                </td>

                                                <td style="width: 15%;" class="column_RightBold">Unit :</td>
                                                <td style="width: 35%;" class="column_Left">
                                                    <asp:DropDownList ID="drpUnit" runat="server" Width="40%"  Enabled="False"></asp:DropDownList>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Brand Name :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox ID="txtBrandName1" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="False"></asp:TextBox>
                                                </td>
                                                <td style="width: 15%" class="column_RightBold">Length :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox ID="txtLenght" runat="server" Width="40%" CssClass="txtbox_Var" ReadOnly="False" AutoPostBack="true"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Size :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox ID="txtSize" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="False" AutoPostBack="true"></asp:TextBox>
                                                </td>

                                                <td style="width: 15%" class="column_RightBold">Width :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox ID="txtWidth" runat="server" Width="40%" CssClass="txtbox_Var" ReadOnly="False" AutoPostBack="true"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Color :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox ID="txtColor" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="False" AutoPostBack="true"></asp:TextBox>
                                                </td>

                                                <td style="width: 15%" class="column_RightBold">Height :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox ID="txtHeight" runat="server" Width="40%" CssClass="txtbox_Var" ReadOnly="False" AutoPostBack="true"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Unit Cost :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox ID="txtUnitPrice" runat="server" Width="40%" CssClass="txtbox_Amt" ReadOnly="False"
                                                        Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);" AutoPostBack="true">
                                                    </asp:TextBox>
                                                </td>

                                                <td style="width: 15%" class="column_RightBold">Weight :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox ID="txtWeight" runat="server" Width="40%" CssClass="txtbox_Var" ReadOnly="False"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Reorder Pt. :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox ID="txtReOrderPt" runat="server" CssClass="txtbox_Amt" ReadOnly="False" Width="50px"></asp:TextBox>
                                                    <asp:Button ID="btnROP" runat="server" CssClass="CSButton" OnClick="btnROP_Click" Text="R.O.P" Width="40" />
                                                </td>

                                                <td style="width: 10%" class="column_RightBold">Quantity :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="txtbox_Amt" ReadOnly="False" Width="40%" AutoPostBack="true"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="column_RightBold">Date :</td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtSellectDate" runat="server" CssClass="txtbox_Var0" AutoPostBack="true"></asp:TextBox>
                                                </td>
                                                <cc1:CalendarExtender ID="CalendarExtender4" runat="server"
                                                    TargetControlID="txtSellectDate" PopupButtonID="txtSellectDate"></cc1:CalendarExtender>

                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:HiddenField ID="hndLoad" Value="1" runat="server" />
                                                </td>
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
                                                                    <asp:DropDownList ID="drpWarehouse" runat="server" Width="175px" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                                </td>

                                                                <td class="column_RightBold">Bay :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtBay" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>
                                                                </td>

                                                                <td class="column_RightBold" style="width: 10%">Column :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtColumn" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>
                                                                </td>

                                                                <td class="column_RightBold" style="width: 10%">Floor :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtFloor" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="column_RightBold">Room :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtRoom" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>
                                                                </td>

                                                                <td class="column_RightBold" style="width: 10%">Shelves :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtShelves" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>
                                                                </td>

                                                                <td class="column_RightBold">Rack :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtRack" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>
                                                                </td>

                                                                <td class="column_RightBold">Bin :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtBin" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>
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
                                        <asp:Button ID="Button3" OnClick="btnEdit1_Click" runat="server" Width="120px" CssClass="CSButton" Enabled="false" Text="UPLOAD"></asp:Button>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2" style="text-align: right;">
                                        <asp:Button ID="btnSave" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" OnClick="btnSave_Click"></asp:Button>
                                        &nbsp; &nbsp; &nbsp;
                                        <asp:Button ID="btnCancel" runat="server" Width="120px" CssClass="CSButton" Text="CANCEL"  OnClick="btnCancel_Click"></asp:Button>
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
                            <asp:TextBox ID="RP" runat="server" CssClass="txtbox_Var" Width="150px" ReadOnly="true"></asp:TextBox>
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



        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
