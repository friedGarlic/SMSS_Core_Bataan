<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="false"
    AutoEventWireup="false" CodeFile="t_StockCard_Rev_Food.aspx.vb" Inherits="Records_t_StockCard_Rev_Food"
    Title="Encoding of Food" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../Membership/MasterPage/js/autoCurrency.js"></script>

    <style type="text/css">
        .pageTable { width: 100%; border-collapse: collapse; }
        .pageTable td { vertical-align: top; }
        table { border-spacing: 0; }
        .cellPad { padding: 2px 4px; }
        .nowrap { white-space: nowrap; }
        .fieldsetBox { width: 100%; box-sizing: border-box; }
        .ctrl98 { width: 98% !important; box-sizing: border-box; }
        .ctrl90 { width: 90% !important; box-sizing: border-box; }
    </style>

    <asp:ScriptManager ID="ScriptManagerFood" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div>
                <table class="pageTable" width="100%">

                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle"><strong>Food</strong></td>
                        <td style="width: 1%"></td>
                    </tr>

                    <tr>
                        <td style="width: 1%;" height="5px"></td>
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
                        <td style="width: 1%;" height="5px"></td>
                    </tr>

                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">FOOD INFORMATION</td>
                        <td style="width: 1%"></td>
                    </tr>

                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">

                            <!-- REMOVED asp:View so controls always render -->
                    <table width="100%">
                        <tr>
                            <td style="width: 70%" align="center">

                                <table width="100%">

                                  <tr>
                                    <td style="width: 15%" class="column_RightBold">Name :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:HiddenField ID="hdnItemNo" runat="server" />
                                        <asp:HiddenField ID="hdnGAId" runat="server" />

                                       <asp:DropDownList 
                                            ID="ddlItemDesc2"
                                            runat="server"
                                            Width="98%"
                                            CssClass="txtbox_Var"
                                            AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlItemDesc2_SelectedIndexChanged">
                                        </asp:DropDownList>

                                    </td>

                                    <td style="width: 15%" class="column_RightBold">Length :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox ID="txtLenght" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="False"></asp:TextBox>
                                    </td>
                                </tr>


                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Brand Name :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtBrandName2" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="False"></asp:TextBox>
                                        </td>

                                        <td style="width: 15%" class="column_RightBold">Width :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtWidth" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="False"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr style="display:none;">
                                        <td style="width: 15%" class="column_RightBold">Supplier :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:LinkButton ID="lnksuppliermed" runat="server" Text="Supplier" CssClass="LinkBtnSelect"></asp:LinkButton>
                                        </td>

                                        <td style="width: 15%" class="column_RightBold">Height:</td>
                                        <td style="width: 35%" class="column_Left"></td>
                                    </tr>

                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Size :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtSize" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="False"></asp:TextBox>
                                        </td>

                                        <td style="width: 15%" class="column_RightBold">Weight:</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtWeight" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="False"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Color :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtColor" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="False"></asp:TextBox>
                                        </td>

                                        <td style="width: 15%" class="column_RightBold">Height :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtHeight" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="False"></asp:TextBox>
                                            <asp:TextBox ID="TextBox2" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="False" Visible="false"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Component of :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtComponentof" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="False"></asp:TextBox>
                                        </td>

                                        <td style="width: 15%" class="column_RightBold">Unit Cost:</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtUnitPrice" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="False"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Dep. Rate :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtDepRate" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="False"></asp:TextBox>
                                        </td>

                                        <td style="width: 15%" class="column_RightBold">Quantity :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtQuantity" runat="server" Width="50%" CssClass="txtboxinspection" ReadOnly="False"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Dep. Value :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtDepValue" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="False"></asp:TextBox>
                                        </td>

                                        <td style="display:none;">Expiry Date :</td>
                                        <td style="display:none;">
                                            <asp:TextBox ID="txtEDate" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="False"></asp:TextBox>
                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        </td>
                                    </tr>

                                    <tr style="display:none;">
                                        <td style="width: 15%" class="column_RightBold"></td>
                                        <td style="width: 35%" class="column_Left"></td>

                                        <td style="width: 15%" class="column_RightBold">Alert :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtAlert" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="False"></asp:TextBox>
                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td colspan="4">
                                            <fieldset class="fieldsetBox">
                                                <legend class="column_Left" style="font-family: Arial; color: #404040;">
                                                    <strong>Location:</strong>
                                                </legend>

                                                <table width="100%">
                                                    <tr>
                                                        <td class="column_RightBold">Warehouse :</td>
                                                        <td class="column_Left">
                                                            <asp:DropDownList ID="drpWarehouse" runat="server" Width="90%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                        </td>

                                                        <td class="column_RightBold">Bay :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBay" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            <asp:DropDownList ID="drpBay" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                        </td>

                                                        <td class="column_RightBold" style="width:10%">Column :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtColumn" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            <asp:DropDownList ID="drpColumn" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                        </td>

                                                        <td class="column_RightBold" style="width:10%">Floor :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtFloor" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            <asp:DropDownList ID="drpFloor" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td class="column_RightBold">Room :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRoom" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            <asp:DropDownList ID="drpRoom" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                        </td>

                                                        <td class="column_RightBold" style="width:10%">Shelves :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtShelves" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            <asp:DropDownList ID="drpShelves" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                        </td>

                                                        <td class="column_RightBold">Rack :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtRack" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            <asp:DropDownList ID="drpRack" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                        </td>

                                                        <td class="column_RightBold">Bin :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBin" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            <asp:DropDownList ID="drpBin" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </td>
                                    </tr>

                                </table>

                            </td>

                            <td style="width: 30%; text-align: center;" valign="top">
                                <img alt="" height="160" src="../images/Default_Image.jpg" width="80%" style="border: 1px solid black" />
                                <br /><br />
                                <asp:Button ID="btnUpload" runat="server" CssClass="CSButton" Enabled="false"
                                    OnClientClick="StartProgressBar();" Text="UPLOAD" Width="120px" />
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" style="text-align: right;">
                                <asp:Button ID="btnFoodSave" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" AutoPostBack="True"
                                    OnClientClick="StartProgressBar();" OnClick="btnFoodSave_Click"></asp:Button>
                                &nbsp; &nbsp; &nbsp;
                                <asp:Button ID="btnFoodCancel" runat="server" Width="120px" CssClass="CSButton" Text="CANCEL"
                                    OnClick="btnFoodCancel_Click" OnClientClick="StartProgressBar();"></asp:Button>
                            </td>
                        </tr>
                    </table>



                            <asp:Label ID="Label1" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label>
                            <asp:Label ID="Label5" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label>
                            <asp:Label ID="Label6" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label>

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

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
