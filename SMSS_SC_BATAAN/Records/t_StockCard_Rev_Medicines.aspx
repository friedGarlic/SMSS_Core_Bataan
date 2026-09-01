<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="false"
    AutoEventWireup="false" CodeFile="t_StockCard_Rev_Medicines.aspx.vb" Inherits="Records_t_StockCard_Rev_Medicines"
    Title="Encoding of Medicines" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../Membership/MasterPage/js/autoCurrency.js"></script>


    <script type="text/javascript">
        function parseNum(val) {
            if (!val) return NaN;
            val = val.toString().replace(/,/g, '').trim();
            return parseFloat(val);
        }

        function computeSellingPrice() {
            var qtyPack = parseNum(document.getElementById('<%= txtQtyPack.ClientID %>').value);
            var unitCost = parseNum(document.getElementById('<%= txtUnitCost.ClientID %>').value);
            var pct = parseNum(document.getElementById('<%= txtPercent.ClientID %>').value);

            if (isNaN(qtyPack) || isNaN(unitCost) || isNaN(pct)) return;
            if (qtyPack <= 0 || unitCost < 0) return;

            var packCost = unitCost * qtyPack;
            var selling = packCost * (1 + (pct / 100.0));

            selling = Math.round(selling * 100) / 100;

            var sp = document.getElementById('<%= txtSellingPrice1.ClientID %>');
            sp.value = selling.toFixed(2);
        }
    </script>


        <style type="text/css">
        /* table driven layout – match the reference feel */
        .pageTable { width: 100%; border-collapse: collapse; }
        .pageTable td { vertical-align: top; }
        table { border-spacing: 0; }

        .cellPad { padding: 2px 4px; }

        /* prevent label wrapping (Generic\nName etc.) */
        .nowrap { white-space: nowrap; }

        /* keep fieldsets tight */
        .fieldsetBox { width: 100%; box-sizing: border-box; }

        /* inner controls */
        .ctrl98 { width: 98% !important; box-sizing: border-box; }
        .ctrl90 { width: 90% !important; box-sizing: border-box; }
    </style>




    <asp:ScriptManager ID="ScriptManagerMedicines" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div>
                <table class="pageTable" width="100%">
                    <!-- Title -->
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle"><strong>Medicines</strong></td>
                        <td style="width: 1%"></td>
                    </tr>

                     <tr>
                          <td style="width: 1%"; height="5px"></td>
                    </tr>


                    <!-- Filters -->
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
                          <td style="width: 1%"; height="5px"></td>
                    </tr>
                    

                    <!-- Section title -->
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">MEDICINES INFORMATION</td>
                        <td style="width: 1%"></td>
                    </tr>

                    <!-- BODY (follow reference widths: 30% | 15% | 10% rowspans) -->
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">

                            <table width="100%">
                                <tr>
                                    <!-- LEFT BLOCK (30%) -->
                                    <td style="width: 30%; text-align: center;" valign="top">
                                        <table width="100%">
                                            <tr>
                                                <td class="column_RightBold cellPad nowrap" style="width: 16%;">Generic Name :</td>
                                                <td class="column_Left cellPad" style="width: 34%;">
                                                    <asp:DropDownList ID="drpGenericName" AutoPostBack="true" runat="server"
                                                        Width="98%" CssClass="ctrl98"
                                                        OnSelectedIndexChanged="drpGenericName_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>

                                                <td class="column_RightBold cellPad nowrap" style="width: 15%;">Unit :</td>
                                                <td class="column_Left cellPad" style="width: 35%;">
                                                    <asp:DropDownList ID="drpUnit" runat="server" Width="90%" Enabled="false"
                                                        CssClass="drpdownCSS ctrl90"></asp:DropDownList>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="column_RightBold cellPad nowrap">Brand Name :</td>
                                                <td class="column_Left cellPad">
                                                    <asp:TextBox ID="txtMedicineBrandName" runat="server" Width="90%"
                                                        CssClass="txtbox_Var ctrl90"></asp:TextBox>
                                                </td>

                                                <td class="column_RightBold cellPad nowrap">Form :</td>
                                                <td class="column_Left cellPad">
                                                    <asp:TextBox ID="txtMedicineForm" runat="server" Width="90%"
                                                        CssClass="txtbox_Var ctrl90"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="column_RightBold cellPad nowrap">Dosage :</td>
                                                <td class="column_Left cellPad">
                                                    <asp:TextBox ID="txtMedicineDose" runat="server" Width="90%"
                                                        CssClass="txtbox_Var ctrl90"></asp:TextBox>
                                                </td>

                                                <td class="column_RightBold cellPad nowrap">OTC / RX :</td>
                                                <td class="column_Left cellPad">
                                                    <asp:TextBox ID="txtMedicineOTXRX" runat="server" Width="90%"
                                                        CssClass="txtbox_Var ctrl90"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="column_RightBold cellPad nowrap">Unit Cost:</td>
                                                <td class="column_Left cellPad">
                                                    <asp:TextBox ID="txtMedicineUnitprice" runat="server" Width="90%"
                                                        CssClass="txtbox_Amt ctrl90"
                                                        Onkeyup="javascript:this.value=Comma(this.value);"
                                                        Onchange="this.value=formatCurrency(this.value);">
                                                    </asp:TextBox>
                                                </td>

                                                <td class="column_RightBold cellPad nowrap">BFAD No. :</td>
                                                <td class="column_Left cellPad">
                                                    <asp:TextBox ID="txtBFADNo" runat="server" Width="90%"
                                                        CssClass="txtbox_Var ctrl90"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="column_RightBold cellPad nowrap">Selling Price:</td>
                                                <td class="column_Left cellPad">
                                                    <asp:TextBox ID="txtSellPrice" runat="server" Width="90%"
                                                        CssClass="txtbox_Amt ctrl90"
                                                        Onkeyup="javascript:this.value=Comma(this.value);"
                                                        Onchange="this.value=formatCurrency(this.value);" ReadOnly="true" >
                                                    </asp:TextBox>
                                                </td>

                                                <td class="column_RightBold cellPad nowrap">Item Code :</td>
                                                <td class="column_Left cellPad">
                                                    <asp:TextBox ID="txtItemCode" runat="server" Width="90%"
                                                        CssClass="txtbox_Var ctrl90"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="column_RightBold cellPad nowrap">Reorder Pt. :</td>
                                                <td class="column_Left cellPad nowrap">
                                                    <asp:TextBox ID="txtReOrderPt" runat="server" CssClass="txtbox_Amt" Width="70%"></asp:TextBox>
                                                    <asp:Button ID="btnROP" runat="server" CssClass="CSButton" OnClick="btnROP_Click" Text="R.O.P" Width="40" />
                                                </td>

                                                <td class="column_RightBold cellPad nowrap">Qty Balance :</td>
                                                <td class="column_Left cellPad">
                                                    <asp:TextBox ID="txtMedicineQuantity" runat="server" CssClass="txtbox_Amt" Width="90%"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="column_RightBold cellPad nowrap">Date :</td>
                                                <td class="column_Left cellPad">
                                                    <asp:TextBox ID="txtSellectDate" runat="server" CssClass="txtbox_Var" Width="90%"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                                        TargetControlID="txtSellectDate" PopupButtonID="txtSellectDate">
                                                    </cc1:CalendarExtender>
                                                </td>
                                                <td class="cellPad"></td>
                                                <td class="cellPad"></td>
                                            </tr>
                                        </table>
                                    </td>

                                    <!-- MIDDLE BLOCK (15%) -->
                                    <td style="width: 15%; text-align: center;" valign="top">
                                        <fieldset class="fieldsetBox">
                                            <legend class="column_Left" style="font-family: Arial; color: #404040;">
                                                <strong>Mftg Info:</strong>
                                            </legend>

                                            <table style="width: 100%">
                                                <tr>
                                                    <td class="column_RightBold cellPad nowrap">Batch :</td>
                                                    <td class="column_Left cellPad">
                                                        <asp:TextBox ID="txtMedicineBatch" runat="server" Width="90%"
                                                            CssClass="txtbox_Var ctrl90"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="column_RightBold cellPad nowrap">Lot :</td>
                                                    <td class="column_Left cellPad">
                                                        <asp:TextBox ID="txtMedicineLot" runat="server" Width="90%"
                                                            CssClass="txtbox_Var ctrl90"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="column_RightBold cellPad nowrap" style="width: 33%;">Mftg. Date :</td>
                                                    <td class="column_Left cellPad">
                                                        <asp:TextBox ID="txtMedicineMdate" runat="server" Width="90%"
                                                            CssClass="txtbox_Date ctrl90"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="column_RightBold cellPad nowrap" style="width: 35%;">Expiry Date :</td>
                                                    <td class="column_Left cellPad">
                                                        <asp:TextBox ID="txtMedicineEdate" runat="server" Width="90%"
                                                            CssClass="txtbox_Date ctrl90"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td style="color: red;" class="column_RightBold cellPad nowrap">Alert :</td>
                                                    <td class="column_Left cellPad">
                                                        <asp:TextBox ID="txtMedicineAlert" runat="server" Width="90%"
                                                            CssClass="txtbox_Date ctrl90"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>

                                    <!-- RIGHT BLOCK (10% like reference snippet; rowspan keeps it aligned) -->
                                    <td style="width: 10%; text-align: center;" valign="top" rowspan="3">
                                        <img alt="" height="160" src="../images/Default_Image.jpg" width="160px" style="border: 1px solid black" />
                                        <br /><br />
                                        <asp:Button ID="btnUpload" runat="server" CssClass="CSButton" Text="UPLOAD" Enabled="false" Width="120px" />
                                    </td>
                                </tr>

                                <!-- PPQ -->
                                <tr>
                                    <td colspan="2" align="center">
                                        <fieldset id="fsPricePerQuantity" runat="server" style="width: 70%;">
                                            <legend class="column_Left" style="font-family: Arial; color: #404040;">
                                                <strong>Price per Quantity:</strong>
                                            </legend>

                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Table ID="tblPPQ" runat="server">
                                                            <asp:TableRow>
                                                                <asp:TableCell CssClass="column_RightBold nowrap">Qty./Pack:</asp:TableCell>
                                                                <asp:TableCell CssClass="column_CenterBold nowrap" HorizontalAlign="left">Unit Cost:</asp:TableCell>
                                                                <asp:TableCell></asp:TableCell>
                                                                <asp:TableCell CssClass="column_RightBold nowrap">Selling Price:</asp:TableCell>
                                                            </asp:TableRow>

                                                            <asp:TableRow>
                                                                <asp:TableCell>
                                                                    <asp:TextBox ID="txtQtyPack" runat="server" AutoPostBack="true" Width="50"
                                                                        Onchange="computeSellingPrice();" onkeyup="computeSellingPrice();"></asp:TextBox>

                                                                </asp:TableCell>

                                                                <asp:TableCell>
                                                                    <asp:TextBox ID="txtUnitCost" runat="server" AutoPostBack="true" Width="75"
                                                                        Onchange="this.value=formatCurrency(this.value); computeSellingPrice();"
                                                                        onkeyup="computeSellingPrice();" />

                                                                </asp:TableCell>

                                                                <asp:TableCell class="nowrap">
                                                                  <asp:TextBox ID="txtPercent" runat="server" AutoPostBack="true" Width="30"
                                                                        Onchange="computeSellingPrice();" onkeyup="computeSellingPrice();"></asp:TextBox>

                                                                    %
                                                                </asp:TableCell>

                                                                <asp:TableCell>
                                                                    <asp:TextBox ID="txtSellingPrice1" runat="server" Width="75"
                                                                        Onchange="this.value=formatCurrency(this.value);" />
                                                                </asp:TableCell>

                                                                <asp:TableCell class="nowrap">
                                                                    <asp:Button ID="btnMedicineAdd" runat="server" CssClass="CSButton" Text="ADD"
                                                                        OnClientClick="return validateMedicineAdd();"
                                                                        OnClick="btnMedicineAdd_Click"></asp:Button>
                                                                    &nbsp;
                                                                    <asp:Button ID="btnMedicineRemove" runat="server" CssClass="CSButton" Text="Remove"
                                                                        Enabled="false" OnClick="btnMedicineRemove_Click"></asp:Button>

                                                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtenderRemovePPQ" runat="server"
                                                                        TargetControlID="btnMedicineRemove"
                                                                        ConfirmText="Are you sure you want to remove this price?">
                                                                    </cc1:ConfirmButtonExtender>
                                                                </asp:TableCell>
                                                            </asp:TableRow>
                                                        </asp:Table>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td style="width: 98%" align="center">
                                                        <asp:GridView ID="GridPPQ" runat="server" Visible="true" Width="98%" SkinID="GridViewAA"
                                                            AllowPaging="True" PageSize="5"
                                                            OnPageIndexChanging="GridPPQ_PageIndexChanging"
                                                            OnSelectedIndexChanged="GridPPQ_SelectedIndexChanged"
                                                            DataKeyNames="PPQ_ID,Item_id,QtyPack,Unit_cost,PPQ_Percent,Selling_Price">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkSelectPPQ" runat="server" Font-Underline="false" CssClass="LinkBtnSelect"
                                                                            CommandName="Select" Text="Select"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                </asp:TemplateField>

                                                                <asp:BoundField DataField="QtyPack" HeaderText="Qty./Pack">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Unit_cost" HeaderText="Unit Cost">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="PPQ_Percent" HeaderText="Percent">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Selling_price" HeaderText="Selling Price">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>
                                </tr>

                                <!-- Location -->
                                <tr>
                                    <td colspan="2" align="center">
                                        <fieldset style="width: 70%;">
                                            <legend class="column_Left" style="font-family: Arial; color: #404040;">
                                                <strong>Location:</strong>
                                            </legend>

                                            <table width="100%">
                                                <tr>
                                                    <td class="column_RightBold cellPad nowrap">Warehouse :</td>
                                                    <td class="column_Left cellPad">
                                                        <asp:DropDownList ID="drpMedicineWarehouse" runat="server" Width="98%" AutoPostBack="True"
                                                            CssClass="drpdownCSS ctrl98"></asp:DropDownList>
                                                    </td>

                                                    <td class="column_RightBold cellPad nowrap">Bay :</td>
                                                    <td class="column_Left cellPad">
                                                        <asp:TextBox ID="txtMedicineBay" runat="server" Width="90%" CssClass="txtbox_Var ctrl90"></asp:TextBox>
                                                    </td>

                                                    <td class="column_RightBold cellPad nowrap" style="width: 15%;">Column :</td>
                                                    <td class="column_Left cellPad">
                                                        <asp:TextBox ID="txtMedicineColumn" runat="server" Width="90%" CssClass="txtbox_Var ctrl90"></asp:TextBox>
                                                    </td>

                                                    <td class="column_RightBold cellPad nowrap" style="width: 10%;">Floor :</td>
                                                    <td class="column_Left cellPad">
                                                        <asp:TextBox ID="txtMedicineFloor" runat="server" Width="90%" CssClass="txtbox_Var ctrl90"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="column_RightBold cellPad nowrap">Room :</td>
                                                    <td class="column_Left cellPad">
                                                        <asp:TextBox ID="txtMedicineRoom" runat="server" Width="90%" CssClass="txtbox_Var ctrl90"></asp:TextBox>
                                                    </td>

                                                    <td class="column_RightBold cellPad nowrap" style="width: 10%;">Shelves :</td>
                                                    <td class="column_Left cellPad">
                                                        <asp:TextBox ID="txtMedicineShelves" runat="server" Width="90%" CssClass="txtbox_Var ctrl90"></asp:TextBox>
                                                    </td>

                                                    <td class="column_RightBold cellPad nowrap">Rack :</td>
                                                    <td class="column_Left cellPad">
                                                        <asp:TextBox ID="txtMedicineRack" runat="server" Width="90%" CssClass="txtbox_Var ctrl90"></asp:TextBox>
                                                    </td>

                                                    <td class="column_RightBold cellPad nowrap">Bin :</td>
                                                    <td class="column_Left cellPad">
                                                        <asp:TextBox ID="txtMedicineBin" runat="server" Width="90%" CssClass="txtbox_Var ctrl90"
                                                            AutoCompleteType="Disabled"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>
                                </tr>

                                <!-- Actions (same row, right aligned) -->
                                <tr>
                                    <td colspan="3" style="text-align: right;">
                                        <asp:Button ID="btnMedicineSave" runat="server" Width="120px" CssClass="CSButton" Text="SAVE"
                                            OnClick="btnMedicineSave_Click"></asp:Button>
                                        &nbsp; &nbsp; &nbsp;
                                        <asp:Button ID="btnMedicineCancel" runat="server" Width="120px" CssClass="CSButton" Text="CANCEL"
                                            OnClick="btnMedicineCancel_Click"></asp:Button>
                                    </td>
                                </tr>
                            </table>

                        </td>
                        <td style="width: 1%"></td>
                    </tr>

                    <!-- Ledger -->
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
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="46%"></ItemStyle>
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

            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtMedicineMdate" PopupButtonID="txtMedicineMdate"></cc1:CalendarExtender>
            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtMedicineEdate" PopupButtonID="txtMedicineEdate"></cc1:CalendarExtender>
            <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtMedicineAlert" PopupButtonID="txtMedicineAlert"></cc1:CalendarExtender>

            <!-- ROP MODAL POPUP -->
            <asp:Panel ID="popupROP" runat="server" Width="350px" CssClass="Panel_Popup" Style="display:none;">
                <table width="100%">
                    <tr>
                        <td style="width: 100%; height: 30px;" colspan="2" class="DivTitle">
                            REORDER POINT COMPUTATION
                            <asp:ImageButton ID="BtnImageClose" ImageUrl="~/images/Edited Image/CloseButton.png"
                                runat="server" Height="13px" Width="16px" Style="float:right;" />
                        </td>
                    </tr>

                    <tr>
                        <td class="column_RightBold">Demand Per Day :</td>
                        <td class="column_Left">
                            <asp:TextBox ID="txtDemandPerDay" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="column_RightBold">Lead Time for Delivery :</td>
                        <td class="column_Left">
                            <asp:TextBox ID="txtLeadTime" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox>
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
                            <asp:TextBox ID="txtComputedROP" runat="server" CssClass="txtbox_Var" Width="150px" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" style="height:10px">
                            <asp:Label runat="server" ID="lblpopupROP"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>

            <cc1:ModalPopupExtender ID="ModalPopupExtenderROP" runat="server"
                TargetControlID="lblpopupROP"
                PopupControlID="popupROP"
                CancelControlID="BtnImageClose"
                BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
