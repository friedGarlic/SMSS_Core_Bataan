<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Encoding_OfficeEquipment.aspx.vb" Inherits="Inventory_Encoding_OfficeEquipment"
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
            var box = document.getElementById("ctl00_ContentPlaceHolder1_txtNoYears");
            if (!box) return;                                // safety: element not found
            if (box.value && box.value.trim() !== "") return; // keep server value

            // Parse date safely: avoid locale ambiguity with MM/dd/yyyy
            var parts = (dateString || "").split(/[\/\-]/);   // expects MM/dd/yyyy
            if (parts.length !== 3) return;
            var m = parseInt(parts[0], 10) - 1;
            var d = parseInt(parts[1], 10);
            var y = parseInt(parts[2], 10);
            var birthDate = new Date(y, m, d);
            if (isNaN(birthDate.getTime())) return;          // invalid date

            var today = new Date();
            var age = today.getFullYear() - birthDate.getFullYear();
            var mm = today.getMonth() - birthDate.getMonth();
            if (mm < 0 || (mm === 0 && today.getDate() < birthDate.getDate())) age--;

            if (age < 0) { alert("Invalid year"); return; }
            box.value = age;
        }


        // function getDepValRate(Integer) {
        //     var year =  document.getElementById('ctl00_ContentPlaceHolder1_txtNoYears').value;
        //     var UL =  document.getElementById('ctl00_ContentPlaceHolder1_txtUsefulLife').value;

        //     var depval = ((year / UL) * 100)

        //     if (depval > 100) {
        //         depval = 100
        //     }

        //     document.getElementById("ctl00_ContentPlaceHolder1_lblequipmentdepreciatedRate").value = depval;

        //    //Depreciation
        //    var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtEAcqCost").value;
        //    AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        //    AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        //    var Salvagevalue = document.getElementById('ctl00_ContentPlaceHolder1_txtSalvageValue').value;
        //    Salvagevalue = Salvagevalue.replace(/\,/g, '');
        //    Salvagevalue = parseInt(Salvagevalue, 10);

        //    var Depreciation = 0.00;
        //    if (AcquisationCostVal > 0 && Salvagevalue > 0 && UL > 0) {
        //        Depreciation = (AcquisationCostVal - Salvagevalue) / UL
        //    }

        //     document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciationValue").value = (Depreciation).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

        //    //End Depreciation

        //    //Depreciated
        //    var DepreciatedtVal = document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciationValue").value;
        //    DepreciatedtVal = DepreciatedtVal.replace(/\,/g, '');
        //    DepreciatedtVal = parseInt(DepreciatedtVal, 10);
        //    var DepreciatedValue = 0.00;
        //     if (DepreciatedtVal > 0) {
        //         DepreciatedValue = AcquisationCostVal - (DepreciatedtVal * year);
        //     }

        //    document.getElementById("ctl00_ContentPlaceHolder1_txtequipmentdepreciatedvalue").value = (DepreciatedValue).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        //    //End Depreciated

        //}
        //Optimize Code
        function getDepValRate(Integer) {
            var yearInput = document.getElementById('ctl00_ContentPlaceHolder1_txtNoYears');
            var ulInput = document.getElementById('ctl00_ContentPlaceHolder1_txtUsefulLife');
            var acquisationCostInput = document.getElementById("ctl00_ContentPlaceHolder1_txtEAcqCost");
            var salvageValueInput = document.getElementById('ctl00_ContentPlaceHolder1_txtSalvageValue');
            var depValOutput = document.getElementById("ctl00_ContentPlaceHolder1_lblequipmentdepreciatedRate");
            var depreciationValueOutput = document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciationValue");
            var depreciatedValueOutput = document.getElementById("ctl00_ContentPlaceHolder1_txtequipmentdepreciatedvalue");

            var year = yearInput.value;
            var ul = ulInput.value;

            var depval = ((year / ul) * 100);
            depval = (depval > 100) ? 100 : depval;
            depValOutput.value = depval;

            var acquisationCost = parseInt(acquisationCostInput.value.replace(/\,/g, ''), 10);
            var salvageValue = parseInt(salvageValueInput.value.replace(/\,/g, ''), 10);
            var depreciation = 0.00;

            if (acquisationCost > 0 && salvageValue > 0 && ul > 0) {
                depreciation = (acquisationCost - salvageValue) / ul;
            }

            depreciationValueOutput.value = formatValue(depreciation.toFixed(2));

            var depreciatedValue = 0.00;
            var depreciatedtVal = parseInt(depreciationValueOutput.value.replace(/\,/g, ''), 10);

            if (depreciatedtVal > 0) {
                depreciatedValue = acquisationCost - (depreciatedtVal * year);
            }

            depreciatedValueOutput.value = formatValue(depreciatedValue.toFixed(2));
        }

        function formatValue(value) {
            return value.replace(/\d(?=(\d{3})+\.)/g, '$&,');
        }


        //function getSalVal(Double) {
        //    var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtEAcqCost").value;
        //    AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        //    AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        //    var SalvageVal = AcquisationCostVal * 0.05

        //    document.getElementById("ctl00_ContentPlaceHolder1_txtSalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        //}
        function getSalVal() {
            const acquisitionCostInput = document.getElementById("ctl00_ContentPlaceHolder1_txtEAcqCost");
            const acquisitionCostVal = Number(acquisitionCostInput.value.replace(/,/g, ''));
            const salvageVal = acquisitionCostVal * 0.05;
            const formattedSalvageVal = salvageVal.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
            const salvageValueInput = document.getElementById("ctl00_ContentPlaceHolder1_txtSalvageValue");
            salvageValueInput.value = formattedSalvageVal;
        }


    </script>
        <script type="text/javascript">
        function preventPropertyInfoEnter(evt) {
            evt = evt || window.event;

            var keyCode = evt.keyCode || evt.which;

            if (keyCode == 13) {
                if (evt.preventDefault) {
                    evt.preventDefault();
                }

                evt.returnValue = false;
                return false;
            }

            return true;
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
                                <asp:Label ID="lblClass" runat="server" Text="Encoding of Office Equipment"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td colspan="7" style="width: 98%" align="left">
                           <span class="column_RightBold">Classification :</span>
                                        <asp:DropDownList ID="ddClass" runat="server" Width="200px" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                           <span class="column_RightBold">Category :</span>
                            <asp:DropDownList ID="ddCategory" runat="server" AutoPostBack="True" Width="200px" CssClass="drpdownCSS" OnSelectedIndexChanged="ddCategory_SelectedIndexChanged"></asp:DropDownList>

                        </td>
                    </tr>
                   <tr>
                    <td colspan="7" style="padding:6px 8px; text-align:left;">
                        <div style="display:flex; align-items:center; gap:10px; flex-wrap:nowrap; white-space:nowrap;">

                            <span class="column_RightBold required-label">General Account :</span>
                            <asp:DropDownList ID="ddGlAccount"
                                runat="server"
                                Width="260px"
                                AutoPostBack="True"
                                CssClass="drpdownCSS"
                                OnSelectedIndexChanged="ddGlAccount_SelectedIndexChanged">
                            </asp:DropDownList>

                            <span class="column_RightBold">Sub Classification :</span>
                            <asp:DropDownList ID="drpSubClass"
                                runat="server"
                                Width="260px"
                                CssClass="drpdownCSS"
                                AutoPostBack="True"
                                OnSelectedIndexChanged="drpSubClass_SelectedIndexChanged">
                            </asp:DropDownList>

                        </div>
                    </td>
                </tr>
                    </tr>


                    <tr style="display: none;">
                        <td style="text-align: right;">
                            <span class="column_RightBold">Category :</span>
                        </td>
                        <td></td>
                        <td class="column_RightBold" style="width: 100%;">
                            <span class="column_RightBold">Sub Category :</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddSubCategory" runat="server" AutoPostBack="True" Width="200px" CssClass="drpdownCSS" Enabled=" false" OnSelectedIndexChanged="ddSubCategory_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                        <td class="column_RightBold">
                            <span>Description &nbsp; :</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSearchStock" runat="server" Width="95%" CssClass="txtbox_Var"> </asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnSearchStock" runat="server" Width="100%" CssClass="CSButton" Text="Search"></asp:Button>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvsearchproperty" runat="server" Width="98%" SkinID="GridViewAA" HorizontalAlign="Center" OnRowDataBound="gvsearchproperty_RowDataBound"
                                DataKeyNames="item_particular_id,Item_ID,Property_code" AllowPaging="True" OnSelectedIndexChanged="gvsearchproperty_SelectedIndexChanged" AutoGenerateSelectButton="True" Visible="false">
                                <%--OnPageIndexChanging="gvsearchproperty_PageIndexChanging"--%>
                                <%-- --%>
                                <Columns>
                                    <asp:BoundField DataField="Property_code" HeaderText="CODE" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="Item_ID" HeaderText="ITEM NO.">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="itemdescription" HeaderText="ITEM DESCRIPTION" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="unit" DataFormatString="{0:N}" HeaderText="UNIT">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ItemCount" HeaderText="BAL AS OF TODAY">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="NO. OF ORDERS/YEAR">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="MIN QTY/ORDER">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="reorderPT" HeaderText="REORDER PT">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td align="center" style="width: 100%">
                            <asp:GridView ID="grdlistofEuipment" runat="server" Width="98%" SkinID="GridViewAA"
                                AllowPaging="True" HorizontalAlign="Center" DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo,Received_ID,AcquisitionCost,Received_Date,Date_Accepted,useful_life,Received_Dtl_ID,barcode"
                                OnRowDataBound="grdlistofEuipment_RowDataBound" OnSelectedIndexChanged="grdlistofEuipment_SelectedIndexChanged" OnPageIndexChanging="grdlistofEuipment_PageIndexChanging">
                                <%--  >--%>
                                <Columns>
                                    <asp:BoundField DataField="Type" HeaderText="TYPE OF EQUIPMENT">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="barcode" HeaderText="SERIAL NO.">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DatePurchased" DataFormatString="{0:d}" HeaderText="DATE PURCHASED">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AcquisitionCost" DataFormatString="{0:N}" HeaderText="ACQUISITION COST">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MarketValue" HeaderText="MARKET VALUE">
                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Condition" HeaderText="CONDITION">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Location" HeaderText="LOCATION">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Status" HeaderText="STATUS">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td colspan="7" class="column_RightBold" style="width: 98%; text-align: right;"><%--STOCK CARD--%>Date :
                                 <asp:TextBox ID="txtDate" runat="server" CssClass="txtbox_Date" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 100%">
                            <asp:HiddenField ID="hdnItemNo" runat="server" />
                            <asp:HiddenField ID="hdnGAId" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="DivTitle" style="width: 100%">
                            <asp:Label ID="lblSubClass" runat="server" Text="OFFICE EQUIPMENT INFORMATION"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 100%">

                            <table style="width: 100%;">
                                <tr>
                                    <td class="column_RightBold" style="width: 10%"><span class="required-label">Name :</span>

                                    </td>
                                    <td class="column_Left" style="width: 30%">

                                        <asp:Label ID="lblequipmentname" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="drpName" AutoPostBack="true"  CssClass="drpdownCSS"  runat="server" Width="91%" OnSelectedIndexChanged="drpName_SelectedIndexChanged"></asp:DropDownList>

                                        <asp:TextBox ID="txtName" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold" style="width: 10%"><span class="required-label">Unit :</span>

                                    </td>
                                    <td class="column_Left" style="width: 30%">

                                        <asp:Label ID="Label4" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="drpUnit" AutoPostBack="true" runat="server" Width="100px" CssClass="drpdownCSS" Enabled="false"  ></asp:DropDownList>&nbsp;&nbsp;
                                        <span class="column_RightBold required-label">Quantity :</span>
                                        <asp:TextBox ID="txtEquipmentQuantity" AutoPostBack="True"  runat="server" Width="100px" CssClass="txtbox_Var"  ></asp:TextBox>

                                        <asp:TextBox ID="TextBox1" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                    </td>
                                    <td align="center" rowspan="6" style="width: 20%" valign="middle">
                                        <asp:Image ID="Image3" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                        <br />
                                        <asp:Button ID="btnupload" runat="server" Width="48%" CssClass="CSButton" Enabled="false" Text="UPLOAD" OnClientClick="StartProgressBar();"></asp:Button>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 10%"><span class="required-label">Description :</span>
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentdesciption" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtequipmentdesciption"   runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"  ></asp:TextBox>

                                    </td>
                                    <td class="column_RightBold" style="width: 10%">Warranty :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentwaranty" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtequipmentwaranty"   runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">Power Input :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentpowerinput" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtequipmentpowerinput"   runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                    <td class="column_RightBold">Dimension :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtequipmentdimension" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="89%"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr>
                                      <td class="column_RightBold">Brand :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtequipmentbrand"  runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="89%"></asp:TextBox>

                                    </td>

                                    <td class="column_RightBold" style="width: 10%">Model :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentmodel" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtequipmentmodel"   runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                    </td>

                                  

                                </tr>
                                <tr>
                               

                                      <td class="column_RightBold" style="width: 10%">Remarks :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="Label6" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtRemarks"  runat="server" Width="89%" AutoPostBack="True" TextMode="MultiLine" CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                     <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:LinkButton ID="btnaddpropertyinfo" runat="server"  OnClick="btnaddpropertyinfo_Click">  <span class="required-label">Add Property Information </span></asp:LinkButton>
                                        <asp:Label ID="lblequipmentdimension" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                    </td>

                                   

                                 
                                   
                                 
                                  

                                      <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="Label5" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtequipmentSerialNo" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Style="margin-bottom: 0px" Visible="false"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="column_RightBold" style="width: 10%">Specifications :
                                    </td>
                                    <td class="column_Left" colspan="3">
                                        <asp:Label ID="lblSpecification" runat="server" CssClass="text3"></asp:Label>
                                        <asp:TextBox ID="txtSpecification" runat="server" Width="95%" Height="25px" TextMode="MultiLine" AutoPostBack="True" CssClass="txtbox_Var" Rows="2"></asp:TextBox>

                                    </td>
                                </tr>
                                 


                                <tr style="display: none">
                                    <td class="column_RightBold" style="width: 10%;">Area Capacity :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentareacapacity" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtequipmentareacapacity"  runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                        <asp:DropDownList ID="drpInstalledAtBuilding" runat="server" CssClass="drpdownCSS" Width="75%" Visible="false">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <fieldset style="width: 93%">
                                            <legend class="column_LeftBold">Maintenance</legend>
                                            <table width="100%">
                                                <tr>
                                                    <td class="column_RightBold">Contractor : 
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtContractor"  AutoPostBack="True" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                    </td>
                                                    <td class="column_RightBold">Contact Person : 
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtContactPerson" AutoPostBack="True" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                    </td>
                                                    <td class="column_RightBold">Cellphone No. : 
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtCellphoneNo" AutoPostBack="True"  runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <fieldset style="width: 90%;">
                                            <legend class="column_LeftBold">Acquisition :</legend>
                                            <table>
                                                <tr>
                                                    <td class="column_RightBold" style="width: 116px"><span class="required-label">Acquisition Date :</span>
                                                    </td>
                                                    <td class="column_Left" style="width: 100px;">
                                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtEAcqDate" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="140px" OnTextChanged="txtEAcqDate_TextChanged" onchange="return NoOfYears(this.value);"  ></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEAcqDate" PopupButtonID="txtEAcqDate"></cc1:CalendarExtender>


                                                        &nbsp;(MM/DD/YYYY)</td>
                                                    <td class="column_RightBold">Market Value :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtEMarketValue" runat="server" AutoPostBack="True" CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>

                                                    </td>


                                                </tr>
                                                <tr>

                                                    <td class="column_RightBold" style="width: 116px"><span class="required-label">Acquisition Cost :</span>
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtEAcqCost" runat="server" AutoPostBack="True" Width="140px" CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalVal(this),getDepValRate(this);"  ></asp:TextBox>
                                                    </td>

                                                    <td class="column_RightBold">No. of Years :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:Label ID="lblNoYears" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtNoYears"  runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="50px"></asp:TextBox>

                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td class="column_RightBold" style="width: 116px">Depreciated Rate :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="lblequipmentdepreciatedRate" AutoPostBack="True"  runat="server" Width="50px" CssClass="txtboxAmount" MaxLength="5" ReadOnly="True"></asp:TextBox>&nbsp;(%) Percent</td>


                                                    <td class="column_RightBold">Useful Life :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:Label ID="lblUsefulLife" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtUsefulLife"  AutoPostBack="True" Enabled="false" runat="server" Width="50px" CssClass="txtbox_Var" onchange="return getDepValRate(this);"></asp:TextBox>

                                                        &nbsp;(Years)</td>

                                                </tr>


                                                <tr>

                                                    <td class="column_RightBold" style="width: 116px">Depreciated Value :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:Label ID="lblequipmentdepreciatedvalue" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                        <asp:TextBox ID="txtequipmentdepreciatedvalue"  runat="server" AutoPostBack="True" CssClass="txtboxAmount" Width="140px" onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                    </td>

                                                    <td class="column_RightBold">Salvage Value :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtSalvageValue" AutoPostBack="True" runat="server" Width="140px" CssClass="txtboxAmount" onchange="this.value=formatCurrency(this.value);">0.00</asp:TextBox></td>


                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="width: 116px">Depreciation Value :</td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtDepreciationValue"  AutoPostBack="True" runat="server" CssClass="txtboxAmount" Width="140px"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>

                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <td colspan="4">
                                        <fieldset style="width: 93%;">
                                            <legend class="column_Left" style="font-family: Arial; color: #404040;"><strong>Location:</strong></legend>
                                            <table width="100%">
                                                <tr>
                                                    <td class="column_RightBold">Warehouse :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:DropDownList ID="drpEquipmentWarehouse" runat="server" Width="98%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                    </td>

                                                    <td class="column_RightBold">Bay :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtEquipmentBay" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                        <asp:DropDownList ID="DropDownList2" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                    </td>

                                                    <td class="column_RightBold" style="width: 15%">Column :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtEquipmentColumn"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                        <asp:DropDownList ID="DropDownList3" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                    </td>

                                                    <td class="column_RightBold" style="width: 10%">Floor :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtEquipmentFloor" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                        <asp:DropDownList ID="DropDownList4" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold">Room :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtEquipmentRoom"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                        <asp:DropDownList ID="DropDownList5" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                    </td>

                                                    <td class="column_RightBold" style="width: 10%">Shelves :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtEquipmentShelves" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                        <asp:DropDownList ID="DropDownList6" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                    </td>

                                                    <td class="column_RightBold">Rack :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtEquipmentRack"  AutoPostBack="True" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                        <asp:DropDownList ID="DropDownList7" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                    </td>

                                                    <td class="column_RightBold">Bin :
                                                    </td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtEquipmentBin" AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                        <asp:DropDownList ID="DropDownList8" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                    </td>
                                                </tr>

                                            </table>
                                        </fieldset>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                    <td class="column_RightBold" colspan="3">
                                        <asp:HiddenField ID="hf_EquipInfoId" runat="server" />
                                        <asp:HiddenField ID="hf_EquipmentId" runat="server" />
                                        <asp:HiddenField ID="hf_PropertyDetai_ID" runat="server" />
                                        <asp:HiddenField ID="hf_Property_ID" runat="server" />
                                        <asp:HiddenField ID="hf_Item_ID" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" Width="48%" CssClass="CSButton" Text="SAVE" Enabled="false" OnClick="btnSave_Click" ></asp:Button>
                                        <asp:Button ID="btnCancel" runat="server" Width="48%" CssClass="CSButton" Text="CANCEL" Enabled="false" OnClientClick="StartProgressBar();"></asp:Button>

                                    </td>
                                </tr>
                            </table>

                        </td>

                    </tr>
                    <tr>
                        <td align="center" class="column_Left" style="width: 100%">
                            <asp:Button ID="btnEquipmentLedger" runat="server" Width="180px" CssClass="Initial" Text="Transactions" OnClick="btnEquipmentLedger_Click" Visible="true"></asp:Button>
                            <asp:Button ID="btnequipmentrepairs" runat="server" Width="180px" CssClass="Initial" Text="Repairs and Maintenance" OnClick="btnequipmentrepairs_Click"></asp:Button>
                            <asp:Button ID="btnequipmentattachdoc" runat="server" Width="180px" CssClass="Initial" Text="Document Attached" OnClick="btnequipmentattachdoc_Click"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td>
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
                                                <asp:Panel ID="Panel1" runat="server" CssClass="PanelSize" ScrollBars="Vertical"
                                                    Width="100%">
                                                    <asp:GridView ID="grdLedger1" runat="server" Width="100%" SkinID="GridViewAA" HorizontalAlign="Center" Font-Size="8pt" DataKeyNames="Ledger_ID, Property_ID" OnDataBound="OnDataBound" OnRowDataBound="grdLedger1_RowDataBound">
                                                        <%--OnSelectedIndexChanged="grdrepairsandmaintenance_SelectedIndexChanged"--%>
                                                        <Columns>

                                                            <asp:TemplateField>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <HeaderTemplate>
                                                                    
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="cbInspection" runat="server" AutoPostBack="True" OnCheckedChanged="cbInspection_CheckedChanged"></asp:CheckBox>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Trans_Type" HeaderText="Particulars">
                                                                <ItemStyle HorizontalAlign="Left" Width="46%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ref" HeaderText="Ref No">
                                                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AccountablePerson" HeaderText="Accountable Person" Visible="false">
                                                                <ItemStyle HorizontalAlign="Left" Width="8%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Department" HeaderText="Office" Visible="false">
                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="acceptedby" HeaderText="Accepted By" Visible="false">
                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="inspectedby" HeaderText="Inspected By" Visible="false">
                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BalanceUnit" HeaderText="Unit" Visible="false">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="UnitPrice" DataFormatString="{0:N}" HeaderText="Unit Price" Visible="false">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="DebitQty" HeaderText="Debit Qty">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText="Debit Cost">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CreditQty" HeaderText="Credit Qty">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText="Credit Cost">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BalQty" HeaderText="Bal Qty">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BalCost" DataFormatString="{0:N}" HeaderText="Bal Cost">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
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
                                                            <asp:Image ID="imgpropertydocs" runat="server" Width="204px" ImageUrl="~/images/DefaulScannedDocuments.jpg" Height="202px"></asp:Image></center>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:View>

                            </asp:MultiView>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="Loading..." src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="display: none; border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>

            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label3" PopupControlID="popupParticular" CancelControlID="ImageButton2" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="popupParticular" runat="server" CssClass="Panel_Popup" Width="">
                <table width="100%">
                    <tr>
                        <td style="width: 100%; height: 30px" class="DivTitle">PROPERTY INFORMATION
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="grdPropertyInfo" runat="server" SkinID="gvnew" AutoGenerateColumns="false" 
                                EmptyDataText="No records has been added." OnRowDataBound="grdPropertyInfo_RowDataBound" DataKeyNames="Property_ID, PropertyDetai_ID"  Width="680px"
                                 onkeydown="return preventPropertyInfoEnter(event);">
                                <Columns>


                                    <asp:TemplateField HeaderText="Property No.">
                                        <ItemTemplate>

                                            <asp:TextBox ID="txtPropertyNo" runat="server" Width="150px" AutoPostBack="true" OnTextChanged="txtPropertyNo_TextChanged"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Serial No.">
                                        <ItemTemplate>

                                            <asp:TextBox ID="txtSerialNoOfEquip" runat="server" Width="150px" AutoPostBack="true" OnTextChanged="txtSerialNoOfEquip_TextChanged" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="19%" HeaderText="Installed At">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="drpInstalledAtOfEquip" runat="server" Width="150px" OnSelectedIndexChanged="drpInstalledAtMac_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-Width="19%" HeaderText="Location">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPIFloorLocation" runat="server" Width="250"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>

                            <%-- </gridview>--%>
                        </td>

                    </tr>

                    <tr>
                        <td>
                            <asp:Button ID="btnProceedEdit" runat="server" Width="150px" CssClass="CSButton" Text="PROCEED" OnClick="btnProceedEdit_Click"></asp:Button>

                            <asp:Button ID="btnAuthCancel" runat="server" Width="150px" CssClass="CSButton" Text="CANCEL"></asp:Button>
                        </td>
                    </tr>
                </table>

            </asp:Panel>



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

            <asp:Panel ID="Panel2" runat="server" Width="350px" CssClass="Panel_Popup"  DefaultButton="Button1">
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
                            <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Width="150px" CssClass="CSButton" Text="PROCEED"></asp:Button>

                            <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Width="150px" CssClass="CSButton" CausesValidation="False" Text="CANCEL"></asp:Button>
                        </td>
                    </tr>
                </table>

            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

