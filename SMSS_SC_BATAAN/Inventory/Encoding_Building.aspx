
<%@ Page
    Title="Encoding of Building"
    Language="VB"
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false"
    CodeFile="Encoding_Building.aspx.vb"
    Inherits="Inventory_Encoding_Building"
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
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
                document.getElementById("ctl00_ContentPlaceHolder1_txtNoYears").value = age;
            }

        }

        function getDepValRate(Integer) {
            var year = document.getElementById('ctl00_ContentPlaceHolder1_txtNoYears').value;
            var UL = document.getElementById('ctl00_ContentPlaceHolder1_txtUsefulLife').value;

            var depval = ((year / UL) * 100)

            if (depval > 100) {
                depval = 100
            }

            document.getElementById("ctl00_ContentPlaceHolder1_lblequipmentdepreciatedRate").value = depval;

            //Depreciation
            var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtEAcqCost").value;
            AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
            AcquisationCostVal = parseInt(AcquisationCostVal, 10);
            var Salvagevalue = document.getElementById('ctl00_ContentPlaceHolder1_txtSalvageValue').value;
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

            document.getElementById("ctl00_ContentPlaceHolder1_txtequipmentdepreciatedvalue").value = (DepreciatedValue).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
            //End Depreciated

        }

        function getSalVal(Double) {
            var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtEAcqCost").value;
            AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
            AcquisationCostVal = parseInt(AcquisationCostVal, 10);
            var SalvageVal = AcquisationCostVal * 0.05

            document.getElementById("ctl00_ContentPlaceHolder1_txtSalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
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
                                <asp:Label ID="lblClass" runat="server" Text="Encoding of Building"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                   <!-- Classification / General Account / Sub Classification -->
                    <tr>
                        <td colspan="7"
                            style="padding: 6px 8px; text-align: left;">

                            <%-- Hidden Building Classification --%>
                            <div style="display: none;">

                                <span class="column_RightBold">
                                    Classification :
                                </span>

                                <asp:DropDownList ID="ddClass"
                                    runat="server"
                                    Width="200px"
                                    AutoPostBack="True" 
                                    CssClass="drpdownCSS">
                                </asp:DropDownList>

                            </div>

                            <div style="display: flex;
                                        align-items: center;
                                        gap: 10px;
                                        flex-wrap: nowrap;
                                        white-space: nowrap;">

                                <span class="column_RightBold required-label">
                                    General Account :
                                </span>

                                <asp:DropDownList ID="ddGA"
                                    runat="server"
                                    Width="260px"
                                    AutoPostBack="True"
                                    CssClass="drpdownCSS">
                                </asp:DropDownList>

                                <span class="column_RightBold required-label">
                                    Sub Classification :
                                </span>

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
                        <td align="center" style="width: 100%">
                            <asp:HiddenField ID="hdnItemNo" runat="server" />
                            <asp:HiddenField ID="hdnGAId" runat="server" />
                        </td>
                    </tr>

                    <tr>
                        <td align="center" colspan="7" class="DivTitle" style="width: 100%">BUILDING INFORMATION
                        </td>
                    </tr>

                    
                    <tr>
                        <td colspan="7">
                            <table width="100%">
                                <tr>
                                    <td style="width: 50%; vertical-align: top;">
                                        <table width="100%">
                                            <tr>
                                                <td class="column_RightBold" style="width: 35%"> <span class="required-label">Building Name :</span> </td>
                                                <td class="column_Left" style="width: 65%">
                                                    <asp:TextBox ID="txtBuildingName"   AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold"> <span class="required-label">Address Name :</span>  </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtAddress" AutoPostBack="True"  runat="server"   Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold">Brgy :</td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtBrgy" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold"><span class="required-label">Description :</span></td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtDescription" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"  ></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold"><span class="required-label">Unit of Measurement :</span></td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtUnit"  AutoPostBack="True" runat="server" Width="95%" CssClass="txtbox_Var"  ></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 50%; vertical-align: top;">
                                        <table width="100%">
                                           
                                            <tr>
                                                <td class="column_RightBold">Area :</td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtArea" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold">Tax Dec. No. :</td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtTaxDecNo"  AutoPostBack="True" runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold">Previous Owner :</td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtPrevOwner"  AutoPostBack="True" runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>

                                             <tr>
                                                <td class="column_RightBold" style="width: 35%"><span class="required-label">Property No. :</span></td>
                                                <td class="column_Left" style="width: 65%">
                                                    <asp:TextBox ID="txtPropertyNo" AutoPostBack="True"  runat="server" Width="95%" CssClass="txtbox_Var"  ></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="column_RightBold">Remarks :</td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtRemarks"  AutoPostBack="True" runat="server" Width="95%" CssClass="txtbox_Var" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>


                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>

                                <tr>
                                    <td style="width: 80%;" valign="top">
                                        <fieldset>

                                            <legend class="column_LeftBold">Acquisition :</legend>
                                            <table>
                                                <tr>
                                                    <td class="column_RightBold" style="width: 119px"> <span class="required-label"> Acquisition Date :</span>
                                                    </td>
                                                    <td class="column_Left" style="width: 100px;">
                                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtEAcqDate" AutoPostBack="True"  runat="server" CssClass="txtbox_Var" Width="140px"   onchange="return NoOfYears(this.value);"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEAcqDate" PopupButtonID="txtEAcqDate"></cc1:CalendarExtender>
                                                        &nbsp;(MM/DD/YYYY)</td>
                                                    <td class="column_RightBold">Market Value :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtEMarketValue" AutoPostBack="True"  runat="server" CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);" Width="140px"></asp:TextBox>

                                                    </td>


                                                </tr>
                                                <tr>

                                                    <td class="column_RightBold" style="width: 119px">  <span class="required-label"> Acquisition Cost :</span>
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtEAcqCost"  AutoPostBack="True" runat="server" Width="140px"   CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalVal(this),getDepValRate(this);"></asp:TextBox>
                                                    </td>

                                                    <td class="column_RightBold">No. of Years :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:Label ID="lblNoYears" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtNoYears"  AutoPostBack="True" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>

                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td class="column_RightBold" style="width: 119px">Depreciated Rate :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="lblequipmentdepreciatedRate" AutoPostBack="True"  runat="server" Width="50px" CssClass="txtboxAmount" MaxLength="5"></asp:TextBox>&nbsp;(%) Percent</td>


                                                    <td class="column_RightBold">Useful Life :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:Label ID="lblUsefulLife" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtUsefulLife"  AutoPostBack="True" runat="server" Width="50px" CssClass="txtbox_Var" onchange="return getDepValRate(this);"></asp:TextBox>

                                                        &nbsp;(Years)</td>

                                                </tr>
                                                <tr>

                                                    <td class="column_RightBold" style="width: 119px">Depreciated Value :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:Label ID="lblequipmentdepreciatedvalue" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                        <asp:TextBox ID="txtequipmentdepreciatedvalue"  AutoPostBack="True" runat="server" Width="140px" CssClass="txtboxAmount"></asp:TextBox>
                                                    </td>

                                                    <td class="column_RightBold">Salvage Value :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtSalvageValue" AutoPostBack="True"  runat="server" Width="140px" CssClass="txtboxAmount">0.00</asp:TextBox></td>


                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="width: 119px">Depreciation Value :</td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtDepreciationValue" AutoPostBack="True"  runat="server" Width="140px" CssClass="txtboxAmount"></asp:TextBox>&nbsp;(Per Year)</td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>

                                            </table>
                                        </fieldset>

                                    </td>
                                    <td style="border: 2px solid #5c85d6" valign="top" rowspan="2">
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
                                                <td style="width: 50%;">
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="column_RightBold">Building Control No. :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBuildingControlNo" AutoPostBack="True"  runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">Building Code :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBuildingCode" AutoPostBack="True"  runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">Building Use :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBuildingUse"  AutoPostBack="True" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">Postal Code :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtPostalCode"  AutoPostBack="True" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 50%;">
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="column_RightBold">Building Occupancy :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBuildingOccupancy"  AutoPostBack="True" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">No. of Floors :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtNoofFloors" AutoPostBack="True"  runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">Avg. Area per Floor :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtAvgAreaperFloor" AutoPostBack="True"  runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>

                                                            <td class="column_RightBold">Cost per Area :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtCostperArea" AutoPostBack="True"  runat="server" Width="75%" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" align="right" style="padding-right: 10px">
                            <asp:Button ID="btnSave" runat="server" Width="18%" CssClass="CSButton" Text="SAVE" OnClick="btnSave_Click"></asp:Button>
                            <asp:Button ID="btnCancel" runat="server" Width="18%" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();"></asp:Button>
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
                                AutoGenerateColumns="False"
                                OnDataBound="OnDataBound"
                                OnRowDataBound="grdLedger1_RowDataBound">

                                <Columns>

                                    <%-- Selection --%>
                                    <asp:TemplateField>

                                        <HeaderStyle Width="3%" />

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
                                        HeaderText="Ref No.">

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
                        </td>
                    </tr>
                </table>
                
            <asp:HiddenField ID="hdnPropertyID" runat="server" />
            </div>


            <%-- AJAX LOADER --%>
            <asp:Panel ID="PanelProgress"
                runat="server"
                Width="109px"
                Style="border-top-width: 1px;
                       border-left-width: 1px;
                       border-left-color: #0033cc;
                       border-bottom-width: 1px;
                       border-bottom-color: #0033cc;
                       border-top-color: #0033cc;
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

            <asp:Label ID="lblApprovalTarget"
                runat="server"
                Style="display: none;">
            </asp:Label>

            <cc1:ModalPopupExtender ID="ModalPopupExtender1"
                runat="server"
                TargetControlID="lblApprovalTarget"
                PopupControlID="Panel2"
                CancelControlID="ImageButton2"
                BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            
            <asp:Panel ID="Panel2" runat="server" Width="350px" CssClass="Panel_Popup" DefaultButton="Button1" >
                <table width="100%">
                    <tr>
                        <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">APPROVAL
                        </td>
                    </tr>
                    <tr>
                        <td class="column_RightBold">Approving Officer :
                        </td>
                        <td class="column_Left">
                            <asp:DropDownList ID="drpApprovedOfficer" runat="server" Width="150px" CssClass="ddropbox"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="column_RightBold">Password :
                        </td>
                        <td class="column_Left">
                            <asp:TextBox ID="txtApprovedPass" runat="server" CssClass="txtbox_Var" Width="150px" TextMode="Password"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                           <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Width="150px"
    CssClass="CSButton" Text="PROCEED" UseSubmitBehavior="false"></asp:Button>

                            <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Width="150px" CssClass="CSButton" CausesValidation="False" Text="CANCEL"></asp:Button>
                        </td>
                    </tr>
                </table>

            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

