<%@ Page Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="PropertyCard_Rev.aspx.vb" 
    Inherits="Records_PropertyCard_Rev"
    Title="Property Card (Revised)"
    EnableEventValidation="false"
    StylesheetTheme="SkinFile" %>

<%@ Register Src="~/Records/PropertyCard_Rev_Books.ascx"
    TagPrefix="uc"
    TagName="BooksLocationList" %>

<%@ Register Src="~/Records/PropertyCard_Rev_Land.ascx"
    TagPrefix="uc"
    TagName="LandLocationList" %>

<%@ Register Src="~/Records/PropertyCard_Rev_Building.ascx"
    TagPrefix="uc"
    TagName="BuildingLocationList" %>

<%@ Register Src="~/Records/PropertyCard_Rev_Construction.ascx"
    TagPrefix="uc"
    TagName="ConstructionLocationList" %>

<%@ Register Src="~/Records/PropertyCard_Rev_Equipment.ascx"
    TagPrefix="uc"
    TagName="EquipmentLocationList" %>

<%@ Register Src="~/Records/PropertyCard_Rev_Furnitures.ascx"
    TagPrefix="uc"
    TagName="FurnitureLocationList" %>

<%@ Register Src="~/Records/PropertyCard_Rev_Intangible.ascx"
    TagPrefix="uc"
    TagName="IntangibleLocationList" %>

<%@ Register Src="~/Records/PropertyCard_Rev_Machinery.ascx"
    TagPrefix="uc"
    TagName="MachineryLocationList" %>


<%@ Register Src="~/Records/PropertyCard_Rev_Office_Equipment.ascx"
    TagPrefix="uc"
    TagName="OfficeEquipmentLocationList" %>

<%@ Register Src="~/Records/PropertyCard_Rev_Others.ascx"
    TagPrefix="uc"
    TagName="OthersLocationList" %>

<%@ Register Src="~/Records/PropertyCard_Rev_Vehicle.ascx"
    TagPrefix="uc"
    TagName="VehicleLocationList" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <table style="width: 100%">
        <tr>
            <td style="width: 1010px" class="PageTitle">
                PROPERTY CARD (REVISED)
            </td>
        </tr>
        <tr>
            <td style="width:1010px;">
                <table style="width:100%; border-collapse:collapse; table-layout:fixed;">

                    <colgroup>
                        <col style="width:20%;" /> <!-- col 1 -->
                        <col style="width:18%;" /> <!-- col 2 -->
                        <col style="width:3%;" />  <!-- col 3 -->
                        <col style="width:18%;" /> <!-- col 4 -->
                        <col style="width:18%;" /> <!-- col 5 -->
                        <col style="width:13%;" /> <!-- col 6 -->
                    </colgroup>

                    <!-- ROW 1 -->
                    <tr>
                        <!-- Column 1: Classification label -->
                        <td style="padding:5px; text-align:right; vertical-align:middle;">
                            <span style="font-size:10pt; font-family:Arial;">
                                <strong>Classification :</strong>
                            </span>
                        </td>

                        <!-- Column 2: Classification dropdown -->
                        <td style="padding:5px; text-align:center; vertical-align:middle;">
                            <asp:DropDownList ID="drpClassification" runat="server"
                                Width="100%" CssClass="txtboxinspection"
                                AutoPostBack="True"
                                OnSelectedIndexChanged="drpClassification_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>

                        <!-- Column 3: empty -->
                        <td style="padding:5px;"></td>

                        <!-- Column 4: Sub Classification label -->
                        <td style="padding:5px; text-align:right; vertical-align:middle;">
                            <span style="font-size:10pt; font-family:Arial;">
                                <strong>Sub Classification :</strong>
                            </span>
                        </td>

                        <!-- Column 5: Sub Classification dropdown -->
                        <td style="padding:5px; text-align:center; vertical-align:middle;">
                            <asp:DropDownList ID="drpSubClassification" runat="server"
                                Width="100%" CssClass="txtboxinspection" 
                                AutoPostBack="True"
                                OnSelectedIndexChanged="drpSubClassification_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>

                        <!-- Column 6: empty -->
                        <td style="padding:5px;"></td>
                    </tr>

                    <!-- ROW 2 -->
                    <tr>
                        <!-- Column 1: General Account label -->
                        <td style="padding:5px; text-align:right; vertical-align:middle;">
                            <span style="font-size:10pt; font-family:Arial;">
                                <strong>General Account :</strong>
                            </span>
                        </td>

                        <!-- Column 2: General Account dropdown -->
                        <td style="padding:5px; text-align:center; vertical-align:middle;">
                            <asp:DropDownList ID="ddGlAccount" runat="server"
                                Width="100%" CssClass="txtboxinspection"
                                AutoPostBack="True"
                                OnSelectedIndexChanged="ddGlAccount_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>

                        <!-- Column 3: empty -->
                        <td style="padding:5px;"></td>

                        <!-- Column 4: Description label -->
                        <td style="padding:5px; text-align:right; vertical-align:middle;">
                            <span style="font-size:10pt; font-family:Arial;">
                                <%-- <strong>Description :</strong>--%>
                            </span>
                        </td>

                        <!-- Column 5: Description textbox -->
                        <td style="padding:5px; text-align:center; vertical-align:middle;">
                            <%--<asp:TextBox ID="txtAccountSearch" runat="server"
                                Width="100%" CssClass="txtboxinspection">
                            </asp:TextBox>--%>
                        </td>

                        <!-- Column 6: Search button -->
                        <td style="padding:5px; text-align:center; vertical-align:middle;">
                            <%-- <asp:Button ID="ItemSearch" runat="server"
                                Text="Search" CssClass="CSButton" Width="80%"
                                OnClick="ItemSearch_Click" />--%>
                        </td>
                    </tr>

                </table>
            </td>
        </tr>


        <tr>
            <td style="height:10px;"></td>
        </tr>

        <!-- MAIN MULTIVIEW AREA -->
        <tr>
            <td style="width: 1010px">
                <asp:MultiView ID="mwProperty" runat="server">
                    <!-- View 1: List of Location (Books) -->
                    <asp:View ID="vwBooksLocationList" runat="server">
                        <uc:BooksLocationList ID="BooksLocationList1" runat="server" />
                    </asp:View>

                    <!-- View 2: List of Location (Land) -->
                    <asp:View ID="vwLandLocationList" runat="server">
                        <uc:LandLocationList ID="LandLocationList1" runat="server" />
                    </asp:View>

                    <!-- View 3: List of Location (Buildings) -->
                    <asp:View ID="vwBuildingLocationList" runat="server">
                        <uc:BuildingLocationList ID="BuildingLocationList1" runat="server" />
                    </asp:View>

                    <!-- View 4: List of Location (Construction in Progress) -->
                    <asp:View ID="vwConstructionLocationList" runat="server">
                        <uc:ConstructionLocationList ID="ConstructionLocationList1" runat="server" />
                    </asp:View>

                     <!-- Equipment -->
                    <asp:View ID="vwEquipmentLocationList" runat="server">
                        <uc:EquipmentLocationList ID="EquipmentLocationList1" runat="server" />
                    </asp:View>

                    <!-- Furnitures and Fixtures -->
                    <asp:View ID="vwFurnitureLocationList" runat="server">
                        <uc:FurnitureLocationList ID="FurnitureLocationList1" runat="server" />
                    </asp:View>

                      <!-- Intangible Assets -->
                    <asp:View ID="vwIntangibleLocationList" runat="server">
                        <uc:IntangibleLocationList ID="IntangibleLocationList1" runat="server" />
                    </asp:View>

                    <!-- Machinery -->
                    <asp:View ID="vwMachineryLocationList" runat="server">
                        <uc:MachineryLocationList ID="MachineryLocationList1" runat="server" />
                    </asp:View>

                     <!-- Office Equipment -->
                    <asp:View ID="vwOfficeEquipmentLocationList" runat="server">
                        <uc:OfficeEquipmentLocationList ID="OfficeEquipmentLocationList1" runat="server" />
                    </asp:View>

                    <!-- Others -->
                    <asp:View ID="vwOthersLocationList" runat="server">
                        <uc:OthersLocationList ID="OthersLocationList1" runat="server" />
                    </asp:View>

                    <!-- Vehicle -->
                    <asp:View ID="vwVehicleLocationList" runat="server">
                        <uc:VehicleLocationList ID="VehicleLocationList1" runat="server" />
                    </asp:View>


                </asp:MultiView>
            </td>
        </tr>

         <%-- Preview Button --%>
        <tr>
            <td style="width: 1000px" colspan="4">
                <asp:Button ID="btnPreview" OnClick="btnPreview_Click" runat="server" Width="200px" Text="PREVIEW" CssClass="CSButton"></asp:Button>
                <asp:HiddenField ID="HdfLedgerReport" runat="server" />
            </td>
        </tr>

    </table>

</asp:Content>
