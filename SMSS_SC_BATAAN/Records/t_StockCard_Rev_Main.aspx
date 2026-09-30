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
                        <col style="width:38%;" />
                        <col style="width:3%;" />
                        <col style="width:8%;" />
                        <col style="width:8%;" />
                        <col style="width:13%;" />
                    </colgroup>

                    <%-- Visible General Account Row --%>
                    <tr>
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
                        <td style="padding:5px;"></td>
                        <td style="padding:5px;"></td>
                        <td style="padding:5px;"></td>
                    </tr>

                    <%-- Keep these controls for the existing UpdateActiveView process --%>
                    <tr style="display:none;">
                        <td>
                            <asp:DropDownList ID="drpClassification" runat="server"
                                AutoPostBack="True"
                                OnSelectedIndexChanged="drpClassification_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>

                        <td>
                            <asp:DropDownList ID="drpSubClassification" runat="server"
                                AutoPostBack="True"
                                OnSelectedIndexChanged="drpSubClassification_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>

                        <td colspan="4"></td>
                    </tr>

                </table>
            </td>
        </tr>

        <tr>
            <td style="height:10px;"></td>
        </tr>

        <%-- List of Items Section --%>
        <tr>
            <td class="DivTitle" style="width:1010px">
                LIST OF ITEMS
            </td>
        </tr>

        <tr>
            <td style="width:1010px">
                <asp:GridView ID="gvItems" runat="server"
                    Width="1000px"
                    SkinID="GridViewAA"
                    HorizontalAlign="Center"
                    DataKeyNames="Item_ID,ClassificationID"
                    AllowPaging="True"
                    AutoGenerateColumns="False"
                    Font-Size="9pt"
                    OnPageIndexChanging="gvItems_PageIndexChanging"
                    OnSelectedIndexChanged="gvItems_SelectedIndexChanged"
                    OnRowDataBound="gvItems_RowDataBound">

                    <Columns>
                        <asp:BoundField DataField="Item_Code" HeaderText="Item Code">
                            <HeaderStyle HorizontalAlign="Center" Width="35%"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" Width="35%"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="ItemDescription" HeaderText="Item Description">
                            <HeaderStyle HorizontalAlign="Center" Width="65%"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" Width="65%"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>

        <tr>
            <td style="height:10px;"></td>
        </tr>

        <!-- MAIN MULTIVIEW AREA -->

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
