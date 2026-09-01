<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PropertyCard_Rev_Land.ascx.vb" Inherits="Records_PropertyCard_Rev_Land" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table width="100%">
    <%-- =========================
         LIST OF LOCATION
         ========================= --%>
    <tr>
        <td class="DivTitle" style="width: 100%">
            LIST OF LOCATION (LAND)
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvLandLocationList" runat="server"
                Width="1000px" SkinID="GridViewAA" HorizontalAlign="Center"
                DataKeyNames="item_particular_id,Item_ID,DeclaredOwner,Barangay"
                AllowPaging="True"
                OnPageIndexChanging="gvLandLocationList_PageIndexChanging"
                OnSelectedIndexChanged="gvLandLocationList_SelectedIndexChanged"
                OnRowDataBound="gvLandLocationList_RowDataBound"
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
                </Columns>
            </asp:GridView>
        </td>
    </tr>

    <%-- View PIR Button --%>
    <tr>
        <td style="text-align: center; padding: 10px;">
            <asp:Button ID="btnViewLandPIR" runat="server" Width="240px" CssClass="CSButton"
                Text="View Perpetual Inventory Report"
                OnClientClick="window.open('rpt_view_propertycard_v4.aspx')"></asp:Button>
        </td>
    </tr>

    <%-- spacing --%>
    <tr><td style="height: 20px;"></td></tr>

    <%-- =========================
         LIST OF LANDS
         ========================= --%>
    <tr>
        <td class="DivTitle" style="width: 100%">
            LIST OF LANDS
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
                            <asp:TextBox ID="txtLandPropSearch" runat="server" Width="95%"></asp:TextBox>
                        </td>
                        <td style="width: 30%" class="text5">
                            <asp:Button ID="btnLandPropSearch" CssClass="CSButton"
                                runat="server" Width="150px" Text="SEARCH"
                                OnClick="btnLandPropSearch_Click"
                                OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>

    <%-- Lands List GridView (same columns as grdListOfEquipments) --%>
    <tr>
        <td style="width: 1000px">
          <asp:GridView ID="grdListOfLands" runat="server" Width="1000px" SkinID="GridViewAA"
            OnPageIndexChanging="grdListOfLands_PageIndexChanging"
            AllowPaging="True" HorizontalAlign="Center"
            DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo,Received_ID,AcquisitionCost,Received_Date,Date_Accepted,Received_Dtl_ID"
            OnRowDataBound="grdListOfLands_RowDataBound"
            OnSelectedIndexChanged="grdListOfLands_SelectedIndexChanged"
            Font-Size="9pt"
            OnDataBound="grdListOfLands_OnDataBound"
            AutoGenerateColumns="False">
            <Columns>
     
                <asp:BoundField DataField="PropertyNo" HeaderText="Property No.">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                </asp:BoundField>

      
                <asp:BoundField DataField="ItemType" HeaderText="Description">
                    <ItemStyle HorizontalAlign="Left" Width="28%" />
                </asp:BoundField>

    
                <asp:BoundField DataField="Location" HeaderText="Location">
                    <ItemStyle HorizontalAlign="Left" Width="28%" />
                </asp:BoundField>


                <asp:BoundField DataField="Barangay" HeaderText="Brgy.">
                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                </asp:BoundField>

                <asp:BoundField DataField="AcqDate" HeaderText="Acquisition Date">
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                </asp:BoundField>


                <asp:BoundField DataField="AcqCost" HeaderText="Acquisition Cost">
                    <ItemStyle HorizontalAlign="Right" Width="12%" />
                </asp:BoundField>


                <asp:BoundField DataField="MarketValue" HeaderText="Market Value">
                    <ItemStyle HorizontalAlign="Right" Width="12%" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>


            <br />
        </td>
    </tr>

    <%-- spacing --%>
    <tr><td style="height: 20px;"></td></tr>

       <%-- =========================
         LAND INFORMATION
         ========================= --%>
    <tr>
        <td style="width: 1000px">
            <table width="100%">
                <tr>
                    <td align="center" colspan="7" class="DivTitle" style="width: 100%">
                        LAND INFORMATION
                    </td>
                </tr>

                <%-- MAIN LAND INFORMATION (LEFT/RIGHT) --%>
                <tr>
                    <td colspan="7">
                        <table width="100%">
                            <tr>
                                <!-- Left column -->
                                <td align="right" style="width: 55%">
                                    <table width="100%">
                                        <tr>
                                            <td class="column_RightBold" style="width: 35%">Address :</td>
                                            <td class="column_Left" style="width: 65%" colspan="3">
                                                <asp:TextBox ID="txtLocation" runat="server" CssClass="txtbox_Var" Width="99%" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 35%">Brgy :</td>
                                            <td class="column_Left" style="width: 65%" colspan="3">
                                                <asp:DropDownList ID="ddBrgy1" runat="server" CssClass="txtbox_Var" Width="50%" Enabled="False"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 35%">Area :</td>
                                            <td class="column_LeftBold" colspan="3">
                                                <asp:TextBox ID="txtArea" runat="server" CssClass="txtbox_Var" Width="50%" Enabled="False" onchange="return ConverttoHectares(this.value);"></asp:TextBox>
                                                (in sq. meters) &nbsp;= &nbsp;
                                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                                &nbsp;(hectares)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 35%">Certificate of Ownership :</td>
                                            <td class="column_Left" colspan="3">
                                                <asp:DropDownList ID="ddTaxDecNo" runat="server" CssClass="txtbox_Var" Width="75%" Enabled="False">
                                                    <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                    <asp:ListItem Value="1">Titled</asp:ListItem>
                                                    <asp:ListItem Value="2">Tax Declaration</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 35%">Present Owner :</td>
                                            <td class="column_Left" colspan="3">
                                                <asp:TextBox ID="txtPrevOwner" runat="server" CssClass="txtbox_Var" Width="95%" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 35%">Description :</td>
                                            <td class="column_Left" colspan="3">
                                                <asp:TextBox ID="txtDescription" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 35%">Unit of Measurement :</td>
                                            <td class="column_Left" colspan="3">
                                                <asp:TextBox ID="txtUnit" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>

                                <!-- Right column -->
                                <td align="left" style="width: 50%">
                                    <table width="100%">
                                        <tr>
                                            <td class="column_RightBold" style="width: 35%">Acquisition Date :</td>
                                            <td class="column_Left" style="width: 65%">
                                                <asp:TextBox ID="txtEAcqDate" runat="server" CssClass="txtbox_Var" Width="50%" Enabled="False"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                                    PopupButtonID="txtEAcqDate" TargetControlID="txtEAcqDate">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold">Acquisition Cost :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtAcqCost" runat="server" CssClass="txtbox_Var" Width="50%" Enabled="False"
                                                    Onkeyup="javascript:this.value=Comma(this.value);"
                                                    Onchange="this.value=formatCurrency(this.value);">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold">Acquisition Mode :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtAcqMode" runat="server" CssClass="txtbox_Var" Width="50%" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold">Market Value :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtMarketValue" runat="server" CssClass="txtbox_Var" Width="50%" Enabled="False"
                                                    Onkeyup="javascript:this.value=Comma(this.value);"
                                                    Onchange="this.value=formatCurrency(this.value);">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold">Property Number :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtPropertyNumber" runat="server" Width="50%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold">Remarks :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtRemarks" runat="server" Width="80%" CssClass="txtbox_Var"
                                                    TextMode="MultiLine" Rows="2" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <%-- PROPERTY IDENTIFICATION + IMAGE --%>
                <tr>
                    <td colspan="7">
                        <table width="100%">
                            <tr>
                                <td style="width: 80%; border: 2px solid #5c85d6" valign="top">
                                    <table width="100%">
                                        <tr>
                                            <td align="center" colspan="8" class="DivTitle" style="width: 100%">
                                                PROPERTY IDENTIFICATION
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 12%">LGU Code :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtLGUCode" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 12%">District Code :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtDistrictCode" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 12%">City/Mun. Code :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtCityCode" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 12%">Brgy Code :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtBrgyCode" runat="server" Width="89%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 12%">Section No. :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtSectionNo" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 12%">Parcel No. :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtParcelNo" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 12%">Series No. :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtSeriesNo" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 12%">RPTIN :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtRPTIN" runat="server" Width="89%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 12%">PIN :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtPIN" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 12%">ARP :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtARP" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 12%">TDN :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtTDN" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 12%">Rev Year :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtRevYear" runat="server" Width="89%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>

                                <td rowspan="2" style="width: 80%; border: 2px solid #5c85d6" valign="top">
                                    <asp:Image ID="imgpropertydocs" runat="server" Width="204px" Height="202px"
                                        ImageUrl="~/images/blankImage.jpg"></asp:Image>
                                    <br /><br />
                                    <asp:Button ID="btnUpload" runat="server" CssClass="CSButton"
                                        Text="UPLOAD" Width="120px" Enabled="False" />
                                </td>
                            </tr>

                            <%-- LOCATION SECTION --%>
                            <tr>
                                <td style="width: 80%; border: 2px solid #5c85d6" valign="top">
                                    <table width="100%">
                                        <tr>
                                            <td align="center" colspan="8" class="DivTitle" style="width: 100%">
                                                LOCATION
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 12%">Lot No. :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtLotNo" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 12%">Street :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtStreet" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 12%">Purok :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtPurok" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 12%">Phase No. :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtPhaseNo" runat="server" Width="89%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 12%">Blk No. :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtBlkNo" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 12%">Subdivision :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtSubdivision" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 12%">Sitio :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtSitio" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 12%">Brgy :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtBrgy" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 12%">City/Mun. :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtCityMun" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 12%">Region :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="TxtRegion" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 12%">District :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtDistrict" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 12%">Province :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtProvince" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 12%">Zip Code :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtZipCode" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <%-- CHARACTERISTICS --%>
                <tr>
                    <td colspan="7" style="border: 2px solid #5c85d6">
                        <table width="100%">
                            <tr>
                                <td align="center" colspan="8" class="DivTitle" style="width: 100%">
                                    CHARACTERISTICS
                                </td>
                            </tr>
                            <tr>
                                <td class="column_RightBold" style="width: 12%">Classification :</td>
                                <td class="column_Left">
                                    <asp:TextBox ID="txtClassification" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                </td>
                                <td class="column_RightBold" style="width: 12%">Sub Class :</td>
                                <td class="column_Left">
                                    <asp:TextBox ID="txtSubClass" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                </td>
                                <td class="column_RightBold" style="width: 12%">Land Use :</td>
                                <td class="column_Left">
                                    <asp:TextBox ID="txtLandUse" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                </td>
                                <td class="column_RightBold" style="width: 12%"></td>
                                <td class="column_Left"></td>
                            </tr>
                            <tr>
                                <td class="column_RightBold" style="width: 12%">Taxable :</td>
                                <td class="column_Left">
                                    <asp:TextBox ID="txtTaxable" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                </td>
                                <td class="column_RightBold" style="width: 12%">Area :</td>
                                <td class="column_Left">
                                    <asp:TextBox ID="txtSubClassArea" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                </td>
                                <td class="column_RightBold" style="width: 12%"></td>
                                <td class="column_Left"></td>
                                <td class="column_RightBold" style="width: 12%"></td>
                                <td class="column_Left"></td>
                            </tr>
                            <tr>
                                <td colspan="8">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="column_RightBold" style="width: 12%">Assessed Value :</td>
                                <td class="column_Left">
                                    <asp:TextBox ID="txtAssessedValue" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"
                                        Onkeyup="javascript:this.value=Comma(this.value);"
                                        Onchange="this.value=formatCurrency(this.value);">
                                    </asp:TextBox>
                                </td>
                                <td class="column_RightBold" style="width: 12%">Market Value :</td>
                                <td class="column_Left">
                                    <asp:TextBox ID="txtCharacteristicsMarketValue" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"
                                        Onkeyup="javascript:this.value=Comma(this.value);"
                                        Onchange="this.value=formatCurrency(this.value);">
                                    </asp:TextBox>
                                </td>
                                <td class="column_RightBold" style="width: 12%">Unit Value :</td>
                                <td class="column_Left">
                                    <asp:TextBox ID="txtUnitValue" runat="server" Width="89%" CssClass="txtbox_Var" Enabled="False"
                                        Onkeyup="javascript:this.value=Comma(this.value);"
                                        Onchange="this.value=formatCurrency(this.value);">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="column_RightBold" style="width: 12%">Date :</td>
                                <td class="column_Left">
                                    <asp:TextBox ID="txtAssessedValueDate" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                        PopupButtonID="txtAssessedValueDate" TargetControlID="txtAssessedValueDate">
                                    </cc1:CalendarExtender>
                                </td>
                                <td class="column_RightBold" style="width: 12%">Date :</td>
                                <td class="column_Left">
                                    <asp:TextBox ID="txtMarketValueDate" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server"
                                        PopupButtonID="txtMarketValueDate" TargetControlID="txtMarketValueDate">
                                    </cc1:CalendarExtender>
                                </td>
                                <td class="column_RightBold" style="width: 12%">Date :</td>
                                <td class="column_Left">
                                    <asp:TextBox ID="txtUnitValueDate" runat="server" Width="89%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server"
                                        PopupButtonID="txtUnitValueDate" TargetControlID="txtUnitValueDate">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="column_RightBold" style="width: 12%">Amount :</td>
                                <td class="column_Left">
                                    <asp:TextBox ID="txtAssessedValueAmount" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"
                                        Onkeyup="javascript:this.value=Comma(this.value);"
                                        Onchange="this.value=formatCurrency(this.value);">
                                    </asp:TextBox>
                                </td>
                                <td class="column_RightBold" style="width: 12%">Amount :</td>
                                <td class="column_Left">
                                    <asp:TextBox ID="txtMarketValueAmount" runat="server" Width="95%" CssClass="txtbox_Var" Enabled="False"
                                        Onkeyup="javascript:this.value=Comma(this.value);"
                                        Onchange="this.value=formatCurrency(this.value);">
                                    </asp:TextBox>
                                </td>
                                <td class="column_RightBold" style="width: 12%">Assessment :</td>
                                <td class="column_Left">
                                    <asp:TextBox ID="TextBox3" runat="server" Width="89%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>


    <%-- spacing --%>
    <tr><td style="height: 20px;"></td></tr>

    <%-- =========================
         TRANSACTIONS
         ========================= --%>
    <tr>
        <td style="width: 1000px" class="DivTitle">TRANSACTIONS</td>
    </tr>

    <tr>
        <td style="width: 1000px" colspan="4">
            <asp:Panel ID="pnlLandLedger" runat="server" Width="1000px" CssClass="PanelSize" ScrollBars="Vertical">
                <asp:GridView ID="grdLandLedger" runat="server" Width="980px" SkinID="GridViewAA" Font-Size="8pt"
                    OnDataBound="OnLandLedgerDataBound">
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
                        <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText=" " SortExpression="DebitCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CreditQty" HeaderText="Qty" SortExpression="CreditQty" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CreditUnit" HeaderText="Unit" SortExpression="CreditUnit" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText=" " SortExpression="CreditCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="BalQty" HeaderText="Qty" SortExpression="BalQty" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="BalanceUnit" HeaderText="Unit" SortExpression="BalUnit" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="BalCost" DataFormatString="{0:N}" HeaderText=" " SortExpression="BalCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </td>
    </tr>

    <%-- Preview Button --%>
    <tr>
        <td style="width: 1000px" colspan="4">
            <asp:Button ID="btnLandPreview" OnClick="btnLandPreview_Click" runat="server"
                Width="200px" Text="PREVIEW" Visible="false" CssClass="CSButton"></asp:Button>
            <asp:HiddenField ID="hdfLandLedgerReport" runat="server" />
        </td>
    </tr>
</table>
