<%@ Page Language="VB"
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false"
    CodeFile="t_StockCard_Rev_Main.aspx.vb"
    Inherits="Records_t_StockCard_Rev_Main"
    Title="Stock Card (Revised)"
    EnableEventValidation="false"
    StylesheetTheme="SkinFile" %>


<%@ Register Src="~/Records/t_StockCard_Rev_Main_Supplies.ascx"
    TagPrefix="uc"
    TagName="SuppliesStockCard" %>

<%@ Register Src="~/Records/t_StockCard_Rev_Main_MRO_Supplies.ascx"
    TagPrefix="uc" TagName="MROStockCard" %>

<%@ Register Src="~/Records/t_StockCard_Rev_Main_MRO_Consumables.ascx"
    TagPrefix="uc" TagName="MROConsumablesStockCard" %>

<%@ Register Src="~/Records/t_StockCard_Rev_Main_MRO_Equipment.ascx"
    TagPrefix="uc" TagName="MROEquipmentStockCard" %>

<%@ Register Src="~/Records/t_StockCard_Rev_Main_Medicine.ascx"
    TagPrefix="uc" TagName="MedicineStockCard" %>

<%@ Register Src="~/Records/t_StockCard_Rev_Main_Food.ascx"
    TagPrefix="uc" TagName="FoodStockCard" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <table style="width: 100%">
        <tr>
            <td style="width: 1010px" class="PageTitle">
                STOCK CARD (REVISED)
            </td>
        </tr>

        <tr>
            <td style="width:1010px;">
                <table style="width:100%; border-collapse:collapse; table-layout:fixed;">

                    <colgroup>
                        <col style="width:20%;" />
                        <col style="width:18%;" />
                        <col style="width:3%;" />
                        <col style="width:18%;" />
                        <col style="width:18%;" />
                        <col style="width:13%;" />
                    </colgroup>

                    <!-- ROW 1 -->
                    <tr>
                        <td style="padding:5px; text-align:right; vertical-align:middle;">
                            <span style="font-size:10pt; font-family:Arial;">
                                <strong>Classification :</strong>
                            </span>
                        </td>

                        <td style="padding:5px; text-align:center; vertical-align:middle;">
                            <asp:DropDownList ID="drpClassification" runat="server"
                                Width="100%" CssClass="txtboxinspection"
                                AutoPostBack="True"
                                OnSelectedIndexChanged="drpClassification_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>

                        <td style="padding:5px;"></td>

                        <td style="padding:5px; text-align:right; vertical-align:middle;">
                            <span style="font-size:10pt; font-family:Arial;">
                                <strong>General Account :</strong>
                            </span>
                        </td>

                        <td style="padding:5px; text-align:center; vertical-align:middle;">
                            <asp:DropDownList ID="ddGlAccount" runat="server"
                                Width="100%" CssClass="txtboxinspection"
                                AutoPostBack="True"
                                OnSelectedIndexChanged="ddGlAccount_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>

                        <td style="padding:5px;"></td>
                    </tr>

                    <!-- ROW 2 -->
                    <tr>
                        <td style="padding:5px; text-align:right; vertical-align:middle;">
                            <span style="font-size:10pt; font-family:Arial;">
                                <strong>Sub Classification :</strong>
                            </span>
                        </td>

                        <td style="padding:5px; text-align:center; vertical-align:middle;">
                            <asp:DropDownList ID="drpSubClassification" runat="server"
                                Width="100%" CssClass="txtboxinspection"
                                AutoPostBack="True"
                                OnSelectedIndexChanged="drpSubClassification_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>

                        <td style="padding:5px;"></td>

                        <td style="padding:5px; text-align:right; vertical-align:middle;">
                            <span style="font-size:10pt; font-family:Arial;">
                            </span>
                        </td>

                        <td style="padding:5px; text-align:center; vertical-align:middle;">
                        </td>

                        <td style="padding:5px; text-align:center; vertical-align:middle;">
                        </td>
                    </tr>

                </table>
            </td>
        </tr>

        <tr>
            <td style="height:10px;"></td>
        </tr>

        <!-- MAIN MULTIVIEW AREA (EMPTY FOR NOW) -->
        <tr>
            <td style="width: 1010px">
              <asp:MultiView ID="mwStockCard" runat="server">

                <asp:View ID="vwMROSupplies" runat="server">
                    <uc:MROStockCard ID="MROStockCard1" runat="server" />
                </asp:View>

                <asp:View ID="vwMROConsumables" runat="server">
                    <uc:MROConsumablesStockCard ID="MROConsumablesStockCard1" runat="server" />
                </asp:View>

                <asp:View ID="vwMROEquipment" runat="server">
                    <uc:MROEquipmentStockCard ID="MROEquipmentStockCard1" runat="server" />
                </asp:View>

                <asp:View ID="vwMedicine" runat="server">
                    <uc:MedicineStockCard ID="MedicineStockCard1" runat="server" />
                </asp:View>

                <asp:View ID="vwFood" runat="server">
                    <uc:FoodStockCard ID="FoodStockCard1" runat="server" />
                </asp:View>

                <asp:View ID="vwSupplies" runat="server">
                    <uc:SuppliesStockCard ID="SuppliesStockCard1" runat="server" />
                </asp:View>

                <asp:View ID="vwEmpty" runat="server">
                </asp:View>

            </asp:MultiView>


            </td>
        </tr>

        <!-- Preview Button -->
        <tr>
            <td style="width: 1000px" colspan="4">
                <asp:Button ID="btnPreview" OnClick="btnPreview_Click" runat="server" Width="200px" Text="PREVIEW" CssClass="CSButton"></asp:Button>
                <asp:HiddenField ID="HdfLedgerReport" runat="server" />
            </td>
        </tr>

    </table>

</asp:Content>
