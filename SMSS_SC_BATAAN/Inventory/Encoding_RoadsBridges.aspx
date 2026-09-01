
<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Encoding_RoadsBridges.aspx.vb" Inherits="Inventory_Encoding_RoadsBridges"
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">


</script>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript">

    </script>
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
        function NoOfYears(dateString) {
            var today = new Date();
            var birthDate = new Date(dateString);
            var age = today.getFullYear() - birthDate.getFullYear();
            var m = today.getMonth() - birthDate.getMonth();
            if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
                age--;
            }

            if (age < 0) {
                alert("Invalid of year")

            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_txtBridgeNoYears").value = age;
            }

        }

        function NoOfYears1(dateString) {
            var today = new Date();
            var birthDate = new Date(dateString);
            var age = today.getFullYear() - birthDate.getFullYear();
            var m = today.getMonth() - birthDate.getMonth();
            if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
                age--;
            }

            if (age < 0) {
                alert("Invalid of year")

            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_txtRoadNoYears").value = age;
            }

        }

        function getDepValRate(Integer) {
            var year = document.getElementById('ctl00_ContentPlaceHolder1_txtBridgeNoYears').value;
            var UL = document.getElementById('ctl00_ContentPlaceHolder1_txtBridgeUsefulLife').value;

            var depval = ((year / UL) * 100)

            if (depval > 100) {
                depval = 100
            }

            document.getElementById("ctl00_ContentPlaceHolder1_txtBridgeDepRate").value = depval;

            //Depreciation
            var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtBridgeAcqCost").value;
            AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
            AcquisationCostVal = parseInt(AcquisationCostVal, 10);
            var Salvagevalue = document.getElementById('ctl00_ContentPlaceHolder1_txtBridgeSalvageValue').value;
            Salvagevalue = Salvagevalue.replace(/\,/g, '');
            Salvagevalue = parseInt(Salvagevalue, 10);

            var Depreciation = 0.00;
            if (AcquisationCostVal > 0 && Salvagevalue > 0 && UL > 0) {
                Depreciation = (AcquisationCostVal - Salvagevalue) / UL
            }

            document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciationValue").value = (Depreciation).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

            //End Depreciation

            //Depreciated
            var DepreciatedtVal = document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciationValue").value;
            DepreciatedtVal = DepreciatedtVal.replace(/\,/g, '');
            DepreciatedtVal = parseInt(DepreciatedtVal, 10);
            var DepreciatedValue = 0.00;
            if (DepreciatedtVal > 0) {
                DepreciatedValue = AcquisationCostVal - (DepreciatedtVal * year);
            }

            document.getElementById("ctl00_ContentPlaceHolder1_txtBridgeDepValue").value = (DepreciatedValue).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
            //End Depreciated

        }

        function getDepValRate1(Integer) {
            var year = document.getElementById('ctl00_ContentPlaceHolder1_txtRoadNoYears').value;
            var UL = document.getElementById('ctl00_ContentPlaceHolder1_txtRoadUsefulLife').value;

            var depval = ((year / UL) * 100)

            if (depval > 100) {
                depval = 100
            }

            document.getElementById("ctl00_ContentPlaceHolder1_txtRoadequipmentdepreciatedRate").value = depval;

            //Depreciation
            var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtRoadAcqCost").value;
            AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
            AcquisationCostVal = parseInt(AcquisationCostVal, 10);
            var Salvagevalue = document.getElementById('ctl00_ContentPlaceHolder1_txtRoadSalvageValue').value;
            Salvagevalue = Salvagevalue.replace(/\,/g, '');
            Salvagevalue = parseInt(Salvagevalue, 10);

            var Depreciation = 0.00;
            if (AcquisationCostVal > 0 && Salvagevalue > 0 && UL > 0) {
                Depreciation = (AcquisationCostVal - Salvagevalue) / UL
            }

            document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciationRoad").value = (Depreciation).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

            //End Depreciation

            //Depreciated
            var DepreciatedtVal = document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciationRoad").value;
            DepreciatedtVal = DepreciatedtVal.replace(/\,/g, '');
            DepreciatedtVal = parseInt(DepreciatedtVal, 10);
            var DepreciatedValue = 0.00;
            if (DepreciatedtVal > 0) {
                DepreciatedValue = AcquisationCostVal - (DepreciatedtVal * year);
            }

            document.getElementById("ctl00_ContentPlaceHolder1_txtRoadequipmentdepreciatedvalue").value = (DepreciatedValue).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
            //End Depreciated

        }


        function getSalVal(Double) {
            var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtBridgeAcqCost").value;
            AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
            AcquisationCostVal = parseInt(AcquisationCostVal, 10);
            var SalvageVal = AcquisationCostVal * 0.05

            document.getElementById("ctl00_ContentPlaceHolder1_txtBridgeSalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        }
        function getSalVal1(Double) {
            var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtRoadAcqCost").value;
            AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
            AcquisationCostVal = parseInt(AcquisationCostVal, 10);
            var SalvageVal = AcquisationCostVal * 0.05

            document.getElementById("ctl00_ContentPlaceHolder1_txtRoadSalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        }


    </script>
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
                        <td colspan="7" class="PageTitle" style="width: 98%">
                            <%--STOCK CARD--%><strong>
                                <asp:Label ID="lblClass" runat="server" Text="ENCODING OF CONSTRUCTION IN PROGRESS"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="7" class="DivTitle" style="width: 100%">CONSTRUCTION IN PROGRESS INFORMATION 
                        </td>
                    </tr>

                   


                   <tr>
                    <td colspan="7"
                        style="padding: 6px 8px;
                               text-align: left;">

                        <div style="display: flex;
                                    align-items: center;
                                    gap: 10px;
                                    flex-wrap: nowrap;
                                    white-space: nowrap;">

                            <span class="column_RightBold required-label">
                                General Account :
                            </span>

                            <asp:DropDownList ID="ddGlAccount"
                                runat="server"
                                Width="260px"
                                AutoPostBack="True"
                                CssClass="drpdownCSS"
                                OnSelectedIndexChanged="ddGlAccount_SelectedIndexChanged">
                            </asp:DropDownList>

                            <span class="column_RightBold required-label">
                                Sub Classification :
                            </span>

                            <asp:DropDownList ID="drpSubClass"
                                runat="server"
                                Width="260px"
                                AutoPostBack="True"
                                 CssClass="drpdownCSS"
                                OnSelectedIndexChanged="drpSubClass_SelectedIndexChanged">
                            </asp:DropDownList>

                        </div>

                    </td>
                </tr>





                    <tr>
                        <td colspan="7" style="width: 98%">
                            <asp:MultiView ID="mvSubClass" runat="server">
                                <asp:View ID="vwRoad" runat="server">
                                    <table>
                                        <tr>
                                            <td colspan="7" style="width: 100%">
                                                <fieldset>
                                                    <legend class="column_LeftBold">General Information</legend>
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="column_RightBold">Project Name :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadProjectName"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Location :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadLocation"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Traffic Volume :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadTrafficVolume"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold"><span class="required-label">Road ID / Property Number:</span>
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadID" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"  ></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Length :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadLength" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Traffic Date :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtTrafficDate" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">Road Name :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadName" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">No of Lanes :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtNoofLane" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Speed Limit :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadSpeedLimit"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">Classification :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadClassification" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Width :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadWidth" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Elevation (m) :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadElevation" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">Road Type :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadType" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Lane Length :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadLaneLength" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Surface Type :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadSurfaceType"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">From Street :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadFromStreet" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Lane Width :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadLaneWidth"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Surface Condition :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadSurfaceCondition" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">To Street :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadtoStreet" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Traffic Direction :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadTrafficDirection"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                              <td class="column_RightBold"><span class="required-label">Remarks :</span>
                                                            </td>
                                                             <td class="column_Left">
                                                                 <asp:TextBox ID="txtRemarksRoads"  AutoPostBack="True" runat="server" Width="89%" CssClass="txtbox_Var"
                                                                    TextMode="MultiLine" Rows="3"  ></asp:TextBox>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                             <td class="column_RightBold"><span class="required-label">Description :</span>
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtDescriptionRoads"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"  ></asp:TextBox>
                                                            </td>

                                                            <td class="column_RightBold">Segment Lock :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadSegmentLock" AutoPostBack="True"  runat="server" Width="10%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="7" style="width: 100%">
                                                <fieldset>
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="column_LeftBold">Left
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">L from Address :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadLfromAddress" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">L to Address :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadLtoAddress"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">N/W Shldr Width :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadNorthWestWidth" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_LeftBold">Right
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">R from Address :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadRfromAddress" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">R to Address :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadRtoAddress"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">S/E Shldr Width :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoadSouthEastWidth"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="7" style="width: 100%">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 80%">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <fieldset style="width: 90%;">
                                                                            <legend class="column_LeftBold">Acquisition :</legend>
                                                                            <table>
                                                                                <tr>
                                                                                    <td class="column_RightBold"><span class="required-label">Acquisition Date :</span>
                                                                                    </td>
                                                                                    <td class="column_Left" style="width: 100px;">
                                                                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                                                                        <asp:TextBox ID="txtRoadAcqDate" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="140px" onchange="return NoOfYears1(this.value);"  ></asp:TextBox>
                                                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtRoadAcqDate" PopupButtonID="txtRoadAcqDate"></cc1:CalendarExtender>


                                                                                        &nbsp;(MM/DD/YYYY)</td>
                                                                                    <td class="column_RightBold">Market Value :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                                                                        <asp:TextBox ID="txtRoadMarketValue" AutoPostBack="True"  runat="server" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); "></asp:TextBox>

                                                                                    </td>


                                                                                </tr>
                                                                                <tr>

                                                                                    <td class="column_RightBold"><span class="required-label">Project Cost :</span>
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                                                                        <asp:TextBox ID="txtRoadAcqCost" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalVal1(this),getDepValRate1(this);"  ></asp:TextBox>
                                                                                    </td>

                                                                                    <td class="column_RightBold">No. of Years :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:Label ID="lblNoYears" runat="server"></asp:Label>
                                                                                        <asp:TextBox ID="txtRoadNoYears" runat="server" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr>

                                                                                    <td class="column_RightBold">Depreciated Rate :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="txtRoadequipmentdepreciatedRate" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" MaxLength="5" ReadOnly="True"></asp:TextBox>&nbsp;(%) Percent</td>


                                                                                    <td class="column_RightBold">Useful Life :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:Label ID="lblUsefulLife" runat="server"></asp:Label>
                                                                                        <asp:TextBox ID="txtRoadUsefulLife" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var" onchange="return getDepValRate1(this);"></asp:TextBox>

                                                                                        &nbsp;(Years)</td>

                                                                                </tr>


                                                                                <tr>

                                                                                    <td class="column_RightBold">Depreciated Value :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:Label ID="lblequipmentdepreciatedvalue" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                        <asp:TextBox ID="txtRoadequipmentdepreciatedvalue" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                                                    </td>

                                                                                    <td class="column_RightBold">Salvage Value :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="txtRoadSalvageValue" AutoPostBack="True"  runat="server" Width="85%" CssClass="txtbox_Var">0.00</asp:TextBox></td>


                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="column_RightBold">Depreciation Value :</td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="txtDepreciationRoad"  AutoPostBack="True" runat="server" CssClass="txtboxAmount" Width="140px"></asp:TextBox></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                </tr>

                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <fieldset>
                                                                            <legend class="column_LeftBold">Contractor</legend>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td class="column_RightBold">Contractor : 
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="txtRoadContractor" AutoPostBack="True" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                    </td>
                                                                                    <td class="column_RightBold">Contact Person : 
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="txtRoadContactPerson" AutoPostBack="True" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                    </td>
                                                                                    <td class="column_RightBold">Cellphone No. : 
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="txtRoadCellphoneNo" AutoPostBack="True"  runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="width: 20%; border: 2px solid #5c85d6">
                                                            <asp:Image ID="imgpropertydocs" runat="server" Width="204px" ImageUrl="~/images/blankImage.jpg" Height="202px"></asp:Image></center>
                                          <br />
                                                            <asp:Button ID="btnUpload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD"></asp:Button>

                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="7" align="right" style="width: 100%">
                                                <asp:Button ID="btnRoadSave" runat="server" Width="100px"  Text="SAVE" OnClick="btnRoadSave_Click" CssClass="CSButton"></asp:Button>
                                                <asp:Button ID="btnRoadCancel" runat="server" Width="100px" OnClientClick="StartProgressBar();" Text="CANCEL" OnClick="btnRoadCancel_Click" CssClass="CSButton"></asp:Button>

                                            </td>
                                        </tr>

                                    </table>
                                </asp:View>
                                <asp:View ID="vwBridge" runat="server">

                                    <table>
                                        <tr>
                                            <td colspan="7" style="width: 100%">
                                                <fieldset>
                                                    <legend class="column_LeftBold">General Information</legend>
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="column_RightBold">Project Name :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeProjectName"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Location :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeLocation"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Name of River :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeNameofRiver" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold"><span class="required-label">Bridge ID / Property Number:</span>
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeID"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"  ></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Route No. :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeRouteNo" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Reference Post :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeReferencePost" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">Bridge Name :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeName" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Featured Intersected :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeFeaturedIntersected" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">End Reference Post :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeEndReferencePost" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">Bridge Type :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeType"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Mile Point :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeMilePoint" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Start Position :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeStartPosition" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">Bridge Structure No. :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeStructureNo"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Border Struct No. :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeBorderStructNo"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Current Station :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeCurrentStation" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">Route Sign Prefix :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeRouteSignPrefix" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Road No. :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeRoadNo" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                              <td class="column_RightBold"><span class="required-label">Remarks :</span>
                                                            </td>
                                                            <td class="column_Left">
                                                                 <asp:TextBox ID="txtRemarks"  AutoPostBack="True" runat="server" Width="89%" CssClass="txtbox_Var"
                                                                    TextMode="MultiLine" Rows="3"  ></asp:TextBox>
                                                            </td>

                                                        </tr>

                                                         <tr>
                                                            <td class="column_RightBold"><span class="required-label">Description :</span>
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtDescription" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"  ></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">
                                                            </td>
                                                            <td class="column_Left">
                                                                
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="7" style="width: 100%">
                                                <fieldset>
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="column_LeftBold">Left
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">L from Address :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeLfromAddress" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">L to Address :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeLtoAddress" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">N/W Shldr Width :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeNorthWestWidth" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_LeftBold">Right
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">R from Address :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeRfromAddress" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">R to Address :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeRtoAddress" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">S/E Shldr Width :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBridgeSouthEastWidth" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="7" style="width: 100%">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 80%">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <fieldset style="width: 90%;">
                                                                            <legend class="column_LeftBold">Acquisition :</legend>
                                                                            <table>
                                                                                <tr>
                                                                                    <td class="column_RightBold"><span class="required-label">Acquisition Date :</span>

                                                                                    </td>
                                                                                    <td class="column_Left" style="width: 100px;">
                                                                                        <asp:Label ID="Label4" runat="server"></asp:Label>
                                                                                        <asp:TextBox ID="txtBridgeAcqDate" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="140px" onchange="return NoOfYears(this.value);"  ></asp:TextBox>
                                                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtBridgeAcqDate" PopupButtonID="txtBridgeAcqDate"></cc1:CalendarExtender>


                                                                                        &nbsp;(MM/DD/YYYY)</td>
                                                                                    <td class="column_RightBold">Market Value :

                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:Label ID="Label5" runat="server"></asp:Label>
                                                                                        <asp:TextBox ID="txtBridgeMarketValue" runat="server" AutoPostBack="True" Width="140px" CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>

                                                                                    </td>


                                                                                </tr>
                                                                                <tr>

                                                                                    <td class="column_RightBold"><span class="required-label">Project Cost :</span>

                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:Label ID="Label6" runat="server"></asp:Label>
                                                                                        <asp:TextBox ID="txtBridgeAcqCost" runat="server" AutoPostBack="True" Width="140px" CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalVal(this),getDepValRate(this);"  ></asp:TextBox>
                                                                                    </td>

                                                                                    <td class="column_RightBold">No. of Years :

                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:Label ID="Label7" runat="server"></asp:Label>
                                                                                        <asp:TextBox ID="txtBridgeNoYears" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="50px"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr>

                                                                                    <td class="column_RightBold">Depreciated Rate :

                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="txtBridgeDepRate" runat="server" Width="50px" AutoPostBack="True" CssClass="txtboxAmount" MaxLength="5"></asp:TextBox>&nbsp;(%) Percent

                                                                                    </td>


                                                                                    <td class="column_RightBold">Useful Life :

                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:Label ID="Label8" runat="server"></asp:Label>
                                                                                        <asp:TextBox ID="txtBridgeUsefulLife" runat="server" Width="50px" AutoPostBack="True" CssClass="txtbox_Var" onchange="return getDepValRate(this);"></asp:TextBox>

                                                                                        &nbsp;(Years)</td>

                                                                                </tr>


                                                                                <tr>

                                                                                    <td class="column_RightBold">Depreciated Value :

                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:Label ID="Label9" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                        <asp:TextBox ID="txtBridgeDepValue" runat="server" Width="140px" CssClass="txtboxAmount" AutoPostBack="True"></asp:TextBox>
                                                                                    </td>

                                                                                    <td class="column_RightBold">Salvage Value :

                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="txtBridgeSalvageValue" runat="server" Width="140px" CssClass="txtboxAmount" AutoPostBack="True">0.00</asp:TextBox>

                                                                                    </td>


                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="column_RightBold">Depreciation Value :</td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="txtDepreciationValue"  AutoPostBack="True" runat="server" CssClass="txtboxAmount" Width="140px"></asp:TextBox>
                                                                                        &nbsp;(Per Year)</td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <fieldset>
                                                                            <legend class="column_LeftBold">Contractor</legend>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td class="column_RightBold">Contractor : 
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="txtBridgeContractor" AutoPostBack="True"  runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                    </td>
                                                                                    <td class="column_RightBold">Contact Person : 
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="txtBridgeContactPerson" AutoPostBack="True"  runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                    </td>
                                                                                    <td class="column_RightBold">Cellphone No. : 
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="txtBridgeCellphoneNo"  AutoPostBack="True" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="width: 20%; border: 2px solid #5c85d6">
                                                            <asp:Image ID="Image2" runat="server" Width="204px" ImageUrl="~/images/blankImage.jpg" Height="202px"></asp:Image></center>
                                          <br />
                                                            <asp:Button ID="btnBridgeUpload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>

                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="7" align="right" style="width: 100%">


                                                <table width="100%">
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Button ID="btnBridgesave" runat="server"  Text="SAVE" Width="100px" OnClick="btnBridgesave_Click" CssClass="CSButton"></asp:Button>

                                                        </td>
                                                        <td align="right" style="width: 105px">
                                                            <asp:Button ID="btnCancelBridge" runat="server" Text="CANCEL" Width="100px" CssClass="CSButton" OnClick="btnCancelBridge_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>

                                        </tr>

                                    </table>
                                </asp:View>
                            </asp:MultiView>


                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="column_Left" style="width: 100%">
                            <asp:Button ID="btnEquipmentLedger" runat="server" Width="180px" CssClass="Initial" Text="Transactions" Visible="true"></asp:Button>
                            <asp:Button ID="btnequipmentrepairs" runat="server" Width="180px" CssClass="Initial" Text="Repairs and Maintenance"></asp:Button>
                            <asp:Button ID="btnequipmentattachdoc" runat="server" Width="180px" CssClass="Initial" Text="Document Attached"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="column_Left" style="width: 100%">
                            <asp:MultiView ID="mvledger" runat="server">
                                <asp:View ID="vwledger" runat="server">
                                    <table style="width: 100%">
                                        <tr style="display: none;">
                                            <td align="center" style="border-right: royalblue 1px solid; border-top: royalblue 1px solid; font-weight: bold; font-size: 9pt; border-left: royalblue 1px solid; width: 63%; color: blue; border-bottom: royalblue 1px solid; font-family: Arial; height: 30px">
                                                <asp:Label ID="lblHistoryDetails" runat="server" Text="EQUIPMENTS"></asp:Label></td>
                                            <td align="center" style="border-right: royalblue 1px solid; border-top: royalblue 1px solid; font-weight: bold; font-size: 9pt; border-left: royalblue 1px solid; width: 12%; color: blue; border-bottom: royalblue 1px solid; font-family: Arial">DEBIT</td>
                                            <td align="center" style="border-right: royalblue 1px solid; border-top: royalblue 1px solid; font-weight: bold; font-size: 9pt; border-left: royalblue 1px solid; width: 12%; color: blue; border-bottom: royalblue 1px solid; font-family: Arial">CREDIT</td>
                                            <td align="center" style="border-right: royalblue 1px solid; border-top: royalblue 1px solid; font-weight: bold; font-size: 9pt; border-left: royalblue 1px solid; width: 13%; color: blue; border-bottom: royalblue 1px solid; font-family: Arial">BALANCE</td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <asp:Panel ID="Panel1" runat="server" CssClass="PanelSize" ScrollBars="Vertical" Width="100%">
                                                    <asp:GridView ID="grdLedger1"
                                                        runat="server"
                                                        Width="100%"
                                                        SkinID="GridViewAA"
                                                        HorizontalAlign="Center"
                                                        Font-Size="8pt"
                                                        AutoGenerateColumns="False"
                                                        DataKeyNames="Property_ID,Ledger_ID,Item_ID"
                                                        OnDataBound="OnDataBound"
                                                        OnRowDataBound="grdLedger1_RowDataBound">

                                                        <Columns>

                                                            <%-- Selection --%>
                                                            <asp:TemplateField>

                                                                <HeaderStyle HorizontalAlign="Center"
                                                                    Width="3%" />

                                                                <ItemStyle HorizontalAlign="Center"
                                                                    Width="3%" />

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

                                                            </asp:TemplateField>

                                                            <%-- DETAILS --%>
                                                            <asp:BoundField DataField="dDate"
                                                                DataFormatString="{0:d}"
                                                                HeaderText="Date">

                                                                <HeaderStyle HorizontalAlign="Center"
                                                                    Width="5%" />

                                                                <ItemStyle HorizontalAlign="Center"
                                                                    Width="5%" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="Trans_Type"
                                                                HeaderText="Particulars">

                                                                <HeaderStyle HorizontalAlign="Center"
                                                                    Width="46%" />

                                                                <ItemStyle HorizontalAlign="Left"
                                                                    Width="46%" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="Ref"
                                                                HeaderText="Ref No">

                                                                <HeaderStyle HorizontalAlign="Center"
                                                                    Width="8%" />

                                                                <ItemStyle HorizontalAlign="Center"
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
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <asp:Button ID="btnPreview" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW" Visible="false"></asp:Button></td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="vwrepairsandmaintenance" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <asp:GridView ID="grdrepairsandmaintenance" runat="server" Width="100%" DataKeyNames="Property_Dtl_ID,RepairMaintenanceId" SkinID="GridViewAA" HorizontalAlign="Center" Font-Size="9pt">
                                                    <%--OnSelectedIndexChanged="grdrepairsandmaintenance_SelectedIndexChanged"--%>
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkPreview" runat="server" CausesValidation="False" Font-Size="10pt" Font-Names="Arial" Text="View Items" CommandName="Select" Font-Underline="False"></asp:LinkButton>
                                                            </ItemTemplate>

                                                            <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ServiceProvider" DataFormatString="{0:d}" HeaderText="Reference No.">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ServiceProvider" HeaderText="Service Provider" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="NatureRepair" HeaderText="Nature & Scope of Work to be done">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No." Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="Total" DataFormatString="{0:N}" HeaderText="Cost of Repair per P.R. / Quotation">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Total" DataFormatString="{0:N}" HeaderText="Cost of Repair per P.O./ D.R./ Voucher / O.R.">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Total" DataFormatString="{0:N}" HeaderText="Accumulated Cost of Repair">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    &nbsp;
                                </asp:View>
                                <asp:View ID="vwdocumentattachment" runat="server">
                                    <table style="height: 236px" width="1000">
                                        <tbody>
                                            <tr>
                                                <td style="vertical-align: top; width: 800px; height: 236px" align="center">
                                                    <fieldset style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; width: 700px; padding-top: 5px; height: 223px" class="PanelBorder">
                                                        <legend><span style="font-size: 11pt; font-family: Calibri"><strong>DOCUMENT DETAILS</strong></span></legend>
                                                        <center>&nbsp;</center>
                                                        <center>
                                                            <asp:GridView ID="grdpropertydocdetails" runat="server" Width="650px" SkinID="gvnew" DataKeyNames="DocuId" PageSize="5" Font-Size="9pt">
                                                                <%--OnRowDataBound="grdpropertydocdetails_RowDataBound" OnSelectedIndexChanged="grdpropertydocdetails_SelectedIndexChanged1"--%>
                                                                <Columns>
                                                                    <asp:BoundField DataField="DocumentName" HeaderText="Document Name"></asp:BoundField>
                                                                    <asp:BoundField DataField="DocumentNo" HeaderText="Document No."></asp:BoundField>
                                                                    <asp:BoundField DataField="ValidatedBy" HeaderText="Validated By"></asp:BoundField>
                                                                    <asp:BoundField DataField="DateValidated" DataFormatString="{0:d}" HeaderText="Date Validated"></asp:BoundField>
                                                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks"></asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </center>
                                                    </fieldset>
                                                </td>
                                                <td style="vertical-align: top; width: 200px; height: 236px" id="Td6" align="center">
                                                    <fieldset style="width: 255px; height: 232px" class="PanelBorder">
                                                        <legend><span style="font-size: 11pt; font-family: Calibri"><strong>ATTACHED DOCUMENTS</strong></span></legend>
                                                        <center>
                                                            <asp:Image ID="Image1" runat="server" Width="204px" ImageUrl="~/images/DefaulScannedDocuments.jpg" Height="202px"></asp:Image></center>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>

                                    <asp:HiddenField ID="hf_EquipInfoId" runat="server" />
                                    <asp:HiddenField ID="hf_EquipmentId" runat="server" />
                                    <asp:HiddenField ID="hf_PropertyDetai_ID" runat="server" />
                                    <asp:HiddenField ID="hf_Property_ID" runat="server" />
                                    <asp:HiddenField ID="hf_Item_ID" runat="server" />
                                </asp:View>


                            </asp:MultiView>
                        </td>
                    </tr>
                </table>
            </div>

            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc"
                ID="PanelProgress" runat="server" Width="109px">
                <img alt="Loading..." src="../images/ajax-loader.gif" />
            </asp:Panel>

            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender"
                runat="server"
                BackgroundCssClass="modalBackground"
                BehaviorID="ProgressBarModalPopupExtender"
                PopupControlID="PanelProgress"
                TargetControlID="ButtonProgress">
            </cc1:ModalPopupExtender>

            <asp:Button ID="ButtonProgress"
                runat="server"
                Width="16px"
                Enabled="False"
                Style="display: none; border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none">
            </asp:Button>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

