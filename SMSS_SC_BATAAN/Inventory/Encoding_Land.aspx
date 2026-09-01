
<%@ Page
    Title="Encoding of Land"
    Language="VB"
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false"
    CodeFile="Encoding_Land.aspx.vb"
    Inherits="Inventory_Encoding_Land"
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script runat="server">



</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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

            return true;
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
    <script language="javascript" type="text/javascript">
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



        function Table2_onclick() {
        }
        function fun1(e, button1) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(button1);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }
        function ConverttoHectares(e) {
            var hectares = e.replace(/[^0-9]/g, '') / 10000;
            document.getElementById("ctl00_ContentPlaceHolder1_Label1").innerText = hectares;
        }
    </script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table width="100%">
                    <tr>
                        <td colspan="7" class="PageTitle" style="width: 98%">
                            <%--STOCK CARD--%><strong>
                                <asp:Label ID="lblClass" runat="server" Text="Encoding of Land"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 100%">
                            <asp:HiddenField ID="hdnItemNo" runat="server" />
                            <asp:HiddenField ID="hdnGAId" runat="server" />
                        </td>
                    </tr>
                   <tr>
    <td colspan="7" style="padding: 6px 8px; text-align: left;">

        <%-- Hidden Classification --%>
        <div style="display: none;">
            <span class="column_RightBold">Classification :</span>

            <asp:DropDownList ID="ddClass"
                runat="server"
                Width="200px"
                AutoPostBack="True" 
                CssClass="drpdownCSS">
            </asp:DropDownList>
        </div>

        <div style="display: flex; align-items: center; gap: 10px; flex-wrap: nowrap; white-space: nowrap;">

            <span class="column_RightBold required-label">General Account :</span>

            <asp:DropDownList ID="ddGA"
                runat="server"
                Width="260px"
                AutoPostBack="True"
                CssClass="drpdownCSS">
            </asp:DropDownList>

            <span class="column_RightBold required-label">Sub Classification :</span>

            <asp:DropDownList ID="ddSubClass"
                runat="server"
                Width="260px"
                AutoPostBack="True"
                CssClass="drpdownCSS">
            </asp:DropDownList>

        </div>

    </td>
</tr>

                    <tr>
                        <td align="center" colspan="7" class="DivTitle" style="width: 100%">LAND INFORMATION </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <table width="100%">
                                <tr>
                                    <!-- Left column -->
                                    <td align="right" style="width: 55%">
                                        <table width="100%">
                                            <tr>
                                                <td class="column_RightBold" style="width: 35%"><span class="required-label">Address :</span></td>
                                                <td class="column_Left" style="width: 65%" colspan="3">
                                                    <asp:TextBox ID="txtLocation" AutoPostBack="True"  runat="server" CssClass="txtbox_Var" Width="99%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width: 35%">Brgy : </td>
                                                <td class="column_Left" style="width: 65%" colspan="3">
                                                    <asp:DropDownList ID="ddBrgy1"  AutoPostBack="True" runat="server" CssClass="txtbox_Var" Width="50%"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width: 35%">Area : </td>
                                                <td class="column_LeftBold" colspan="3">
                                                    <asp:TextBox ID="txtArea"  AutoPostBack="True" runat="server" CssClass="txtbox_Var" OnTextChanging="txtArea_TextChanging" Width="50%" onchange="return ConverttoHectares(this.value);"></asp:TextBox>
                                                    (in sq. meters) &nbsp;= &nbsp;<asp:Label ID="Label1" runat="server" Text=""></asp:Label> &nbsp;(hectares)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width: 35%">Certificate of Ownership : </td>
                                                <td class="column_Left" colspan="3">
                                                    <asp:DropDownList ID="ddTaxDecNo" runat="server" CssClass="txtbox_Var" Width="75%">
                                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                        <asp:ListItem Value="1">Titled</asp:ListItem>
                                                        <asp:ListItem Value="2">Tax Declaration</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width: 35%">Present Owner : </td>
                                                <td class="column_Left" colspan="3">
                                                    <asp:TextBox ID="txtPrevOwner" AutoPostBack="True"  runat="server" CssClass="txtbox_Var" Width="95%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width: 35%"><span class="required-label">Description :</span></td>
                                                <td class="column_Left" colspan="3">
                                                    <asp:TextBox ID="txtDescription" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width: 35%"><span class="required-label">Unit of Measurement :</span></td>
                                                <td class="column_Left" colspan="3">
                                                    <asp:TextBox ID="txtUnit" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <!-- Right column -->
                                    <td align="left" style="width: 50%">
                                        <table width="100%">
                                            <tr>
                                                <td class="column_RightBold" style="width: 35%"><span class="required-label">Acquisition Date :</span></td>
                                                <td class="column_Left" style="width: 65%">
                                                    <asp:TextBox ID="txtEAcqDate" AutoPostBack="True"  runat="server" CssClass="txtbox_Var" Width="50%"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtEAcqDate" TargetControlID="txtEAcqDate"></cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold"><span class="required-label">Acquisition Cost :</span></td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtAcqCost" AutoPostBack="True"  runat="server" CssClass="txtbox_Var" Width="50%" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold">Acquisition Mode : </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtAcqMode" AutoPostBack="True"  runat="server" CssClass="txtbox_Var" Width="50%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold">Market Value : </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtMarketValue"  AutoPostBack="True" runat="server" CssClass="txtbox_Var" Width="50%" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold"><span class="required-label">Property Number :</span></td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtPropertyNumber"  AutoPostBack="True" runat="server" Width="50%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold">Remarks :</td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtRemarks"  AutoPostBack="True" runat="server" Width="80%" CssClass="txtbox_Var" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>



                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80%; border: 2px solid #5c85d6" valign="top">
                                        <table width="100%">
                                            <tr>
                                                <td align="center" colspan="8" class="DivTitle" style="width: 100%">PROPERTY IDENTIFICATION</td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width: 12%">LGU Code :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtLGUCode" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 12%">District Code :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtDistrictCode" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 12%">City/Mun. Code :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtCityCode" runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 12%">Brgy Code :</td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtBrgyCode" AutoPostBack="True"  runat="server" Width="89%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width: 12%">Section No. :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtSectionNo" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 12%">Parcel No. :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtParcelNo" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 12%">Series No. :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtSeriesNo"  AutoPostBack="True" runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 12%">RPTIN :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtRPTIN" AutoPostBack="True"  runat="server" Width="89%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width: 12%">PIN :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtPIN" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 12%">ARP :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtARP" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 12%">TDN :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtTDN" AutoPostBack="True" runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 12%">Rev Year :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtRevYear"  AutoPostBack="True" runat="server" Width="89%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>

                                            </tr>
                                            <tr style="display: none;">
                                                <td class="column_RightBold" style="width: 12%">Dep. Rate :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtDepRate"  AutoPostBack="True" runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>

                                                <td class="column_RightBold" style="width: 12%">Dep. Value :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtDepValue" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>

                                            </tr>
                                        </table>
                                    </td>
                                    <td rowspan="2" style="width: 80%; border: 2px solid #5c85d6" valign="top">
                                        <asp:Image ID="imgpropertydocs" runat="server" Width="204px" ImageUrl="~/images/blankImage.jpg" Height="202px"></asp:Image></center>
                                                  <br>
                                        <br>
                                        <asp:Button ID="btnUpload" runat="server" Enabled="false" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="UPLOAD" Width="120px" />

                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 80%; border: 2px solid #5c85d6" valign="top">
                                        <table width="100%">
                                            <tr>
                                                <td align="center" colspan="8" class="DivTitle" style="width: 100%">LOCATION</td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width: 12%">Lot No. :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtLotNo" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 12%">Street :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtStreet" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 12%">Purok :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtPurok"  AutoPostBack="True" runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 12%">Phase No. :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtPhaseNo" AutoPostBack="True"  runat="server" Width="89%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width: 12%">Blk No. :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtBlkNo" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 12%">Subdivision :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtSubdivision"  AutoPostBack="True" runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 12%">Sitio :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtSitio" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width: 12%">Brgy:
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtBrgy" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 12%">City/Mun. :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtCityMun" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 12%">Region :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="TxtRegion" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width: 12%">District:
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtDistrict" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 12%">Province :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtProvince" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width: 12%">Zip Code :
                                                </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtZipCode"  AutoPostBack="True" runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                   


                    <tr>
                        <td colspan="7" style="border: 2px solid #5c85d6">
                            <table width="100%">
                                <tr>
                                    <td align="center" colspan="8" class="DivTitle" style="width: 100%">CHARACTERISTICS</td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 12%">Classification :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtClassification"  AutoPostBack="True" runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    <td class="column_RightBold" style="width: 12%">Sub Class :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtSubClass"  AutoPostBack="True" runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    <td class="column_RightBold" style="width: 12%">Land Use :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtLandUse"  AutoPostBack="True" runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    <td class="column_RightBold" style="width: 12%; display: none">Status :
                                    </td>
                                    <td class="column_Left" style="display: none">
                                        <asp:TextBox ID="txtStatus"  AutoPostBack="True" runat="server" Width="89%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 12%">Taxable :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtTaxable"  AutoPostBack="True" runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    <td class="column_RightBold" style="width: 12%">Area :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtSubClassArea" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    <td class="column_RightBold" style="width: 12%"></td>
                                    <td class="column_Left"></td>
                                    <td class="column_RightBold" style="width: 12%; display: none">Status :
                                    </td>
                                    <td class="column_Left" style="display: none">
                                        <asp:TextBox ID="TxtStatus1"  AutoPostBack="True" runat="server" Width="89%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 12%">Assessed Value :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtAssessedValue" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                    </td>
                                    <td class="column_RightBold" style="width: 12%">Market Value :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtCharacteristicsMarketValue" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                    </td>
                                    <td class="column_RightBold" style="width: 12%">Unit Value :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtUnitValue"  AutoPostBack="True" runat="server" Width="89%" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 12%">Date :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtAssessedValueDate" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="txtAssessedValueDate" TargetControlID="txtAssessedValueDate">
                                        </cc1:CalendarExtender>

                                    </td>
                                    <td class="column_RightBold" style="width: 12%">Date :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMarketValueDate" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="txtMarketValueDate" TargetControlID="txtMarketValueDate">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td class="column_RightBold" style="width: 12%">Date :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtUnitValueDate"  AutoPostBack="True" runat="server" Width="89%" CssClass="txtbox_Var"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" PopupButtonID="txtUnitValueDate" TargetControlID="txtUnitValueDate">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 12%">Amount :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtAssessedValueAmount" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                    </td>
                                    <td class="column_RightBold" style="width: 12%">Amount :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtMarketValueAmount" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                    </td>
                                    <td class="column_RightBold" style="width: 12%">Assessment :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="TextBox3"  AutoPostBack="True" runat="server" Width="89%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" align="right">
                            <asp:Button ID="btnLandSave" OnClick="btnLandSave_Click" runat="server" Width="120px"  Text="SAVE" CssClass="CSButton"></asp:Button>
                            <asp:Button ID="btnLandCancel" runat="server" Width="120px" OnClientClick="StartProgressBar();" Text="CANCEL" CssClass="CSButton"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <br />
                           <asp:GridView ID="grdLedger1"
                                runat="server"
                                Width="100%"
                                SkinID="GridViewAA"
                                HorizontalAlign="Center"
                                Font-Size="8pt"
                                DataKeyNames="Property_ID"
                                AutoGenerateColumns="False">

                                <Columns>

                                    <%-- Selection --%>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1"
                                                runat="server">
                                            </asp:TextBox>
                                        </EditItemTemplate>

                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbInspection"
                                                runat="server"
                                                AutoPostBack="True"
                                                OnCheckedChanged="cbInspection_CheckedChanged">
                                            </asp:CheckBox>
                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center"
                                            Width="3%" />

                                        <ItemStyle HorizontalAlign="Center"
                                            Width="3%" />
                                    </asp:TemplateField>

                                    <%-- Existing correct columns --%>
                                    <asp:BoundField DataField="Property_Date"
                                        DataFormatString="{0:d}"
                                        HeaderText="Date">

                                        <HeaderStyle HorizontalAlign="Center"
                                            Width="5%" />

                                        <ItemStyle HorizontalAlign="Center"
                                            Width="5%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Particulars"
                                        HeaderText="Particulars">

                                        <HeaderStyle HorizontalAlign="Center"
                                            Width="46%" />

                                        <ItemStyle HorizontalAlign="Left"
                                            Width="46%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="PropertyNo"
                                        HeaderText="Ref No">

                                        <HeaderStyle HorizontalAlign="Center"
                                            Width="8%" />

                                        <ItemStyle HorizontalAlign="Center"
                                            Width="8%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="OwnerName"
                                        HeaderText="Accountable Person"
                                        Visible="False">

                                        <ItemStyle HorizontalAlign="Left"
                                            Width="8%" />
                                    </asp:BoundField>

                                    <%-- DEBIT --%>
                                    <asp:BoundField DataField="DebitQty"
                                        HeaderText="Qty">

                                        <HeaderStyle HorizontalAlign="Center"
                                            Width="4%" />

                                        <ItemStyle HorizontalAlign="Center"
                                            Width="4%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="DebitCost"
                                        DataFormatString="{0:N2}"
                                        HeaderText="Cost">

                                        <HeaderStyle HorizontalAlign="Center"
                                            Width="8%" />

                                        <ItemStyle HorizontalAlign="Right"
                                            Width="8%" />
                                    </asp:BoundField>

                                    <%-- CREDIT --%>
                                    <asp:BoundField DataField="CreditQty"
                                        HeaderText="Qty">

                                        <HeaderStyle HorizontalAlign="Center"
                                            Width="4%" />

                                        <ItemStyle HorizontalAlign="Center"
                                            Width="4%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="CreditCost"
                                        DataFormatString="{0:N2}"
                                        HeaderText="Cost">

                                        <HeaderStyle HorizontalAlign="Center"
                                            Width="8%" />

                                        <ItemStyle HorizontalAlign="Right"
                                            Width="8%" />
                                    </asp:BoundField>

                                    <%-- BALANCE --%>
                                    <asp:BoundField DataField="BalQty"
                                        HeaderText="Qty">

                                        <HeaderStyle HorizontalAlign="Center"
                                            Width="4%" />

                                        <ItemStyle HorizontalAlign="Center"
                                            Width="4%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="BalCost"
                                        DataFormatString="{0:N2}"
                                        HeaderText="Cost">

                                        <HeaderStyle HorizontalAlign="Center"
                                            Width="8%" />

                                        <ItemStyle HorizontalAlign="Right"
                                            Width="8%" />
                                    </asp:BoundField>

                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>

            </div>


<asp:HiddenField ID="hdnPropertyID" runat="server" />

<asp:Label ID="lblApprovalTarget"
    runat="server"
    Style="display: none;">
</asp:Label>

<cc1:ModalPopupExtender ID="ModalPopupExtender1"
    runat="server"
    TargetControlID="lblApprovalTarget"
    PopupControlID="PanelApproval"
    CancelControlID="Button2"
    BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="PanelApproval" runat="server" Width="350px" CssClass="Panel_Popup" DefaultButton="Button1" >
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
                <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Width="150px"
                    CssClass="CSButton" Text="PROCEED" UseSubmitBehavior="false"></asp:Button>

                <asp:Button ID="Button2" OnClick="Button2_Click"  CausesValidation="False"  runat="server" Width="150px"
                    CssClass="CSButton" Text="CANCEL" UseSubmitBehavior="false"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Panel>


            <asp:Panel ID="PanelProgress" runat="server" Width="109px"
                Style="border-top-width: 1px;
                       border-left-width: 1px;
                       border-left-color: #0033cc;
                       border-bottom-width: 1px;
                       border-bottom-color: #0033cc;
                       border-top-color: #0033cc;
                       position: relative;
                       background-color: transparent;
                       text-align: center;
                       border-right-width: 1px;
                       border-right-color: #0033cc;">
                <img alt="Loading..." src="../images/ajax-loader.gif" />
            </asp:Panel>

            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender"
                runat="server"
                BackgroundCssClass="modalBackground"
                TargetControlID="ButtonProgress"
                PopupControlID="PanelProgress"
                BehaviorID="ProgressBarModalPopupExtender">
            </cc1:ModalPopupExtender>

            <asp:Button ID="ButtonProgress"
                runat="server"
                Width="16px"
                Enabled="False"
                Style="display: none;">
            </asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

