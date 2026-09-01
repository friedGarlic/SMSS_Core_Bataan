<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Encoding_Machineries.aspx.vb" Inherits="Inventory_Encoding_Machineries" 
    StylesheetTheme="SkinFile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>


<script type="text/javascript">
     window.onbeforeunload = function (e) {
         var e = e || window.event;
      // For IE and FireFox
         var value="There is some data to be saved!"
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
            document.getElementById("ctl00_ContentPlaceHolder1_txtNoYears").value = age;}
       
 }
   
     //function getDepValRate(Integer) {
     //    var year =  document.getElementById('ctl00_ContentPlaceHolder1_txtNoYears').value;
     //    var UL =  document.getElementById('ctl00_ContentPlaceHolder1_txtUsefulLife').value;

     //    var depval = ((year / UL) * 100)
          
     //    if (depval > 100) {
     //        depval = 100
     //    }

     //    document.getElementById("ctl00_ContentPlaceHolder1_lblequipmentdepreciatedRate").value = depval;

     //   //Depreciation
     //   var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtEAcqCost").value;
     //   AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
     //   AcquisationCostVal = parseInt(AcquisationCostVal, 10);
     //   var Salvagevalue = document.getElementById('ctl00_ContentPlaceHolder1_txtSalvageValue').value;
     //   Salvagevalue = Salvagevalue.replace(/\,/g, '');
     //   Salvagevalue = parseInt(Salvagevalue, 10);

     //   var Depreciation = 0.00;
     //   if (AcquisationCostVal > 0 && Salvagevalue > 0 && UL > 0) {
     //       Depreciation = (AcquisationCostVal - Salvagevalue) / UL
     //   }

     //    document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciationValue").value = (Depreciation).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

     //   //End Depreciation

     //   //Depreciated
     //   var DepreciatedtVal = document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciationValue").value;
     //   DepreciatedtVal = DepreciatedtVal.replace(/\,/g, '');
     //   DepreciatedtVal = parseInt(DepreciatedtVal, 10);
     //   var DepreciatedValue = 0.00;
     //    if (DepreciatedtVal > 0) {
     //        DepreciatedValue = AcquisationCostVal - (DepreciatedtVal * year);
     //    }
        
     //   document.getElementById("ctl00_ContentPlaceHolder1_txtequipmentdepreciatedvalue").value = (DepreciatedValue).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
     //   //End Depreciated

    //}
    function getDepValRate() {
    const year = parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_txtNoYears').value);
    const UL = parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_txtUsefulLife').value);

    let depval = ((year / UL) * 100);
    depval = (depval > 100) ? 100 : depval;
    document.getElementById("ctl00_ContentPlaceHolder1_lblequipmentdepreciatedRate").value = depval.toFixed(2);

    // Depreciation
    const AcquisationCostVal = parseInt(document.getElementById("ctl00_ContentPlaceHolder1_txtEAcqCost").value.replace(/\,/g, ''), 10);
    const Salvagevalue = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtSalvageValue').value.replace(/\,/g, ''), 10);

    let Depreciation = 0.00;
    if (AcquisationCostVal > 0 && Salvagevalue > 0 && UL > 0) {
        Depreciation = (AcquisationCostVal - Salvagevalue) / UL;
    }
    document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciationValue").value = Depreciation.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

    // Depreciated
    const DepreciatedtVal = parseInt(document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciationValue").value.replace(/\,/g, ''), 10);
    const DepreciatedValue = (DepreciatedtVal > 0) ? (AcquisationCostVal - (DepreciatedtVal * year)) : 0.00;
    document.getElementById("ctl00_ContentPlaceHolder1_txtequipmentdepreciatedvalue").value = DepreciatedValue.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
}


    function getSalVal(Double) {
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtEAcqCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var SalvageVal = AcquisationCostVal * 0.05

        document.getElementById("ctl00_ContentPlaceHolder1_txtSalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }

   
 </script>


    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            document.querySelectorAll("[id$=drpInstalledAtMac]").forEach(function (dropdown) {
                dropdown.addEventListener("change", function () {
                    var selectedText = dropdown.options[dropdown.selectedIndex].text;
                    var locationTextbox = dropdown.closest("tr").querySelector("[id$=txtPIFloorLocation]");
            
                    if (selectedText === "N/A" || selectedText === "Field") {
                        locationTextbox.disabled = false;
                        locationTextbox.value = "";
                    } else {
                        locationTextbox.disabled = true;
                        locationTextbox.value = "Fetching address..."; // Placeholder
                        fetchBuildingAddress(dropdown.value, locationTextbox);
                    }
                });
            });

            function fetchBuildingAddress(buildingId, locationTextbox) {
                // Simulated AJAX call to fetch building address
                setTimeout(function () {
                    locationTextbox.value = "Building Address for ID " + buildingId;
                }, 1000);
            }
        });
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
   <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="True">
   <ContentTemplate>
       <div>
           <table width="100%">
                       <tr>
                        <td colspan="7" class="PageTitle" style="width: 98%">
                            <%--STOCK CARD--%><strong>
                                <asp:Label ID="lblClass" runat="server" Text="Encoding of Machinery"></asp:Label>
                            </strong>
                        </td>
                     </tr>
                     <tr>
                       <td>
                              <table>

                                <!-- Hide Classification row -->
                                <tr style="display:none;">
                                    <td class="column_RightBold">Classification :  </td>
                                    <td>
                                        <asp:DropDownList ID="ddClass" runat="server" CssClass="drpdownCSS" Width="200px"></asp:DropDownList>
                                    </td>
                                </tr>

                                <!-- General Account & Sub Classification on the same row -->
                                <tr>
                                    <td class="column_RightBold">      &nbsp; 
                                        <span class="required-label">General Account :</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddGA"
                                            runat="server"
                                            CssClass="drpdownCSS"
                                            Width="200px"
                                             AutoPostBack="True" >
                                        </asp:DropDownList>
                                    </td>

                                    <td style="width:20px;"></td>

                                    <td class="column_RightBold">
                                        <span>Sub Classification :</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpSubClassification"
                                            runat="server"
                                            CssClass="drpdownCSS"
                                            Width="200px"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                              </table>
                       </td>
                     </tr>
              

                       <tr>
                        <td align="center" colspan="7" class="DivTitle" style="width: 100%">
                            MACHINERY INFORMATION 
                         </td>
                        </tr>


                       <tr>
                           <td>
                              <table> 
                                <tr>
                                    <td style="width:80%;" valign="top">
                                        <table width="100%">
                                            <tr>
                                                <td style="width:50%;">
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="column_RightBold">
                                                                <span class="required-label">Name :</span>
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:DropDownList ID="txtMachineryName" runat="server" Width="75%" CssClass="drpdownCSS" AutoPostBack="true"  >
                                                                </asp:DropDownList>
                                                             </td>
                                                         </tr>


                                                         <tr>
                                                            <td class="column_RightBold">
                                                                <span class="required-label">Description :</span>
                                                             </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMachineryDescription"  AutoPostBack="True"  runat="server" Width="75%" CssClass="txtbox_Var"  ></asp:TextBox>
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                            <td class="column_RightBold">
                                                                Power Input :
                                                             </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMachineryPowerInput"  AutoPostBack="True"  runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                            <td class="column_RightBold">
                                                                Brand :
                                                             </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMachineryBrand"  AutoPostBack="True"  runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                            <td class="column_RightBold">
                                                                <%-- Installed At :--%>
                                                             </td>
                                                            <td class="column_Left">
                                                                <asp:DropDownList ID="drpInstalledAtBuilding"  AutoPostBack="True"  runat="server" Width="75%" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                             <td class="column_RightBold">
                                                                Model :
                                                             </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMachineryModel"   AutoPostBack="True" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                             </td>

                                                         </tr>
                                                          <tr>
                                                          
                                                              <td class="column_RightBold"><span class="required-label">Remarks :</span></td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRemarks"   AutoPostBack="True" runat="server" Width="95%" CssClass="txtbox_Var" TextMode="MultiLine" Rows="2"  ></asp:TextBox>
                                                             </td>

                                                         </tr>
                                                     </table>
                                                 </td>
                                                <td style="width:50%;" valign="top">
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="column_RightBold">
                                                                <span class="required-label">Unit :</span>
                                                             </td>
                                                            <td class="column_Left" colspan="3">
                                                                <asp:DropDownList ID="drpMachineryUnit" runat="server" Width="100px" CssClass="drpdownCSS" Enabled="false"  ></asp:DropDownList>&nbsp;&nbsp;
                                                                <span class="column_RightBold required-label">Quantity :</span>
                                                                <asp:TextBox ID="txtMachineryQuantity"  AutoPostBack="True"  runat="server" Width="100px" CssClass="txtbox_Var"  ></asp:TextBox>
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                            <td class="column_RightBold">
                                                                Dimension :
                                                             </td>
                                                            <td class="column_Left" colspan="3">
                                                                <asp:TextBox ID="txtMachineryDimension"   AutoPostBack="True" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                            <td class="column_RightBold">
                                                                Area Capacity :
                                                             </td>
                                                            <td class="column_Left" colspan="3">
                                                                <asp:TextBox ID="txtMachineryAreaCapacity"  AutoPostBack="True"  runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                            <td class="column_RightBold">
                                                                Warranty :
                                                             </td>
                                                            <td class="column_Left" colspan="3">
                                                                <asp:TextBox ID="txtMachineryWarranty"   AutoPostBack="True" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                            <td class="column_RightBold" style="width:25%">
                                                             </td>
                                                            <td class="column_Left" colspan="3">
                                                                <asp:LinkButton ID="btnaddpropertyinfo"   AutoPostBack="True" runat="server" Text="" OnClick="btnaddpropertyinfo_Click"> <span class="required-label">Add Property Information </span> </asp:LinkButton>
                                                             </td>
                                                         </tr>
                                                        <tr style="display:none">
                                                            <td class="column_RightBold" style="width:25%">
                                                                Floor Location :
                                                             </td>
                                                            <td class="column_Left" style="width:25%">
                                                                <asp:TextBox ID="txtMachineryFloorLocation"  AutoPostBack="True"  runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                             </td>
                                                            <td class="column_RightBold" style="width:15%">
                                                                Room :
                                                             </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMachineryRoom"  AutoPostBack="True"  runat="server" Width="46%" CssClass="txtbox_Var"></asp:TextBox>
                                                             </td>
                                                         </tr>
                                                     </table>
                                                 </td>
                                             </tr>
                                             <!-- SPECIFICATION: spans both left and right sides -->
                                            <tr>
                                                <td colspan="2">
                                                    <table width="100%" style="margin-top:10px; table-layout:fixed;">
                                                        <tr>
                                                            <td class="column_RightBold"
                                                                style="width:129px; vertical-align:top;">
                                                                Specifications :
                                                            </td>

                                                            <td class="column_Left">
                                                                <asp:Label ID="Label4"
                                                                    runat="server"
                                                                    CssClass="text3">
                                                                </asp:Label>

                                                                <asp:TextBox ID="txtSpecification"
                                                                    runat="server"
                                                                    Width="97%"
                                                                    Height="25px"
                                                                    TextMode="MultiLine"
                                                                    AutoPostBack="True"
                                                                    CssClass="txtbox_Var"
                                                                    Rows="2">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>


<!-- MAINTENANCE -->
<tr>
    <td colspan="2">
        <fieldset>
            <legend class="column_LeftBold">Maintenance</legend>

            <table width="100%">
                <tr>
                    <td class="column_RightBold" style="width:100px;">
                        Contractor :
                    </td>

                    <td class="column_Left">
                        <asp:TextBox ID="txtContractor"
                            AutoPostBack="True"
                            runat="server"
                            Width="75%"
                            CssClass="txtbox_Var">
                        </asp:TextBox>
                    </td>

                    <td class="column_RightBold" style="width:100px;">
                        Contact Person :
                    </td>

                    <td class="column_Left">
                        <asp:TextBox ID="txtContactPerson"
                            AutoPostBack="True"
                            runat="server"
                            Width="75%"
                            CssClass="txtbox_Var">
                        </asp:TextBox>
                    </td>

                    <td class="column_RightBold" style="width:100px;">
                        Cellphone No. :
                    </td>

                    <td class="column_Left">
                        <asp:TextBox ID="txtCellphoneNo"
                            AutoPostBack="True"
                            runat="server"
                            Width="75%"
                            CssClass="txtbox_Var">
                        </asp:TextBox>
                    </td>
                </tr>
            </table>
        </fieldset>
    </td>
</tr>
                                         </table>
                                     </td>
                                    <td valign="top" rowspan="2">
                                        <fieldset>
                                            <asp:Image ID="imgpropertydocs" runat="server" Width="204px" ImageUrl="~/images/blankImage.jpg" Height="202px"></asp:Image>
                                            <br /><br />
                                            <asp:Button ID="btnUpload" runat="server" Width="48%" CssClass="CSButton" Enabled="false" Text="UPLOAD" OnClientClick="StartProgressBar();"></asp:Button>
                                            <br />
                                        </fieldset>
                                        <br />
                                        <asp:Button ID="btnSave" runat="server" Width="48%" CssClass="CSButton" Text="SAVE"  OnClick="btnSave_Click"></asp:Button>
                                        <asp:Button ID="btnCancel" runat="server" Width="48%" CssClass="CSButton" Text="CANCEL" OnClick="btnCancel_Click" OnClientClick="StartProgressBar();"></asp:Button>
                                     </td>
                                 </tr>
                                 <tr>
                                    <td style="width:80%;" valign="top">
                                        <fieldset>
                                            <legend class="column_LeftBold">Acquisition :</legend>
                                            <table>
                                                <tr>
                                                    <td class="column_RightBold" style="width: 129px">
                                                        <span class="required-label">Acquisition Date :</span>
                                                     </td>
                                                    <td class="column_Left" style="width:100px;">
                                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtEAcqDate" runat="server" CssClass="txtbox_Var" Width="140" onchange="return NoOfYears(this.value);"  ></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEAcqDate" PopupButtonID="txtEAcqDate"></cc1:CalendarExtender>
                                                        &nbsp;(MM/DD/YYYY)
                                                     </td>
                                                    <td class="column_RightBold">Market Value :</td>
                                                    <td class="column_Left">
                                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtEMarketValue"   AutoPostBack="True" runat="server" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                     </td>
                                                 </tr>
                                                 <tr>
                                                    <td class="column_RightBold" style="width: 129px"><span class="required-label">Acquisition Cost :</span></td>
                                                    <td class="column_Left">
                                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtEAcqCost" runat="server"   AutoPostBack="True" CssClass="txtboxAmount" Width="140" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalVal(this),getDepValRate(this);"  ></asp:TextBox>
                                                     </td>
                                                    <td class="column_RightBold">No. of Years :</td>
                                                    <td class="column_Left">
                                                        <asp:Label ID="lblNoYears" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtNoYears" runat="server"   AutoPostBack="True" CssClass="txtbox_Var" Width="50px"></asp:TextBox>
                                                     </td>
                                                 </tr>
                                                 <tr>
                                                    <td class="column_RightBold" style="width: 129px">Depreciated Rate :</td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="lblequipmentdepreciatedRate"  AutoPostBack="True"  runat="server" Width="50px" CssClass="txtboxAmount" MaxLength="5"></asp:TextBox>&nbsp;(%) Percent
                                                     </td>
                                                    <td class="column_RightBold">Useful Life :</td>
                                                    <td class="column_Left">
                                                        <asp:Label ID="lblUsefulLife" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtUsefulLife"  AutoPostBack="True" Enabled="false" runat="server" Width="50px" CssClass="txtbox_Var" onchange="return getDepValRate(this);"></asp:TextBox>
                                                        &nbsp;(Years)
                                                     </td>
                                                 </tr>
                                                 <tr>
                                                    <td class="column_RightBold" style="width: 129px">Depreciated Value :</td>
                                                    <td class="column_Left">
                                                        <asp:Label ID="lblequipmentdepreciatedvalue" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                        <asp:TextBox ID="txtequipmentdepreciatedvalue"  AutoPostBack="True"  runat="server" CssClass="txtboxAmount" Width="140"></asp:TextBox>
                                                     </td>
                                                    <td class="column_RightBold">Salvage Value :</td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtSalvageValue"  AutoPostBack="True"  runat="server" Width="85%" CssClass="txtboxAmount">0.00</asp:TextBox>
                                                     </td>
                                                 </tr>
                                                 <tr>
                                                    <td class="column_RightBold" style="width: 129px">Depreciation Value :</td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtDepreciationValue"  AutoPostBack="True"  runat="server" CssClass="txtboxAmount" Width="140"></asp:TextBox>
                                                        (Per Year)
                                                     </td>
                                                    <td></td>
                                                    <td></td>
                                                 </tr>
                                             </table>
                                        </fieldset>
                                        
                                     
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
                                        <tr style="display:none;">
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
                                                <asp:GridView ID="grdLedger1"
                                                    runat="server"
                                                    Width="100%"
                                                    SkinID="GridViewAA"
                                                    AutoGenerateColumns="False"
                                                    AllowPaging="True"
                                                    OnPageIndexChanging="grdLedger1_PageIndexChanging"
                                                    OnRowDataBound="grdLedger1_RowDataBound"
                                                    HorizontalAlign="Center"
                                                    Font-Size="8pt"
                                                    DataKeyNames="Ledger_ID"
                                                    EmptyDataText="No data found.">

                                                    <Columns>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="cbInspection"
                                                                    runat="server"
                                                                    AutoPostBack="True"
                                                                    OnCheckedChanged="cbInspection_CheckedChanged" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="dDate"
                                                            DataFormatString="{0:d}"
                                                            HeaderText="Acq Date">
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="Trans_Type"
                                                            HeaderText="Particulars">
                                                            <ItemStyle HorizontalAlign="Left" Width="36%" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="ref"
                                                            HeaderText="Ref No"
                                                            Visible="false">
                                                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="AccountablePerson"
                                                            HeaderText="Accountable Person"
                                                            Visible="false">
                                                            <ItemStyle HorizontalAlign="Left" Width="8%" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="Department"
                                                            HeaderText="Office"
                                                            Visible="false">
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="acceptedby"
                                                            HeaderText="Accepted By"
                                                            Visible="false">
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="inspectedby"
                                                            HeaderText="Inspected By"
                                                            Visible="false">
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="BalanceUnit"
                                                            HeaderText="Units">
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="UnitPrice"
                                                            DataFormatString="{0:N}"
                                                            Visible="false"
                                                            HeaderText="Unit Price">
                                                            <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="DebitQty"
                                                            HeaderText="Debit Qty">
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="DebitCost"
                                                            DataFormatString="{0:N}"
                                                            HeaderText="Debit Cost">
                                                            <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="CreditQty"
                                                            HeaderText="Credit Qty"
                                                            NullDisplayText="0">
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="CreditCost"
                                                            DataFormatString="{0:N}"
                                                            HeaderText="Credit Cost">
                                                            <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="BalQty"
                                                            HeaderText="Bal Qty">
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="BalCost"
                                                            DataFormatString="{0:N}"
                                                            HeaderText="Bal Cost">
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
                                                            <asp:Image ID="Image1" runat="server" Width="204px" ImageUrl="~/images/DefaulScannedDocuments.jpg" Height="202px"></asp:Image></center>
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
              <asp:Panel ID="popupParticular" runat="server" CssClass="Panel_Popup">
                  <table width="100%">
                       <tr>
                         <td style="width: 100%; height: 30px"  class="DivTitle">
                             PROPERTY INFORMATION
                           </td>
                       </tr>
                       <tr>      
                           <td>
                              <div style="overflow:scroll;max-height:500px">

                            
                           <asp:GridView ID="grdPropertyInfo" runat="server" SkinID="gvnew" AutoGenerateColumns="false" DataKeyNames=" PropertyDetai_ID"
                            EmptyDataText="No records has been added." OnRowDataBound="grdPropertyInfo_RowDataBound" Width="680px"
                                onkeydown="return preventPropertyInfoEnter(event);">
                                <Columns>
                                   

                                    <asp:TemplateField HeaderText="Property No." >
                                        <ItemTemplate>
                                         <asp:TextBox ID="txtPropertyNo" runat ="server" AutoPostBack="true" OnTextChanged="txtPropertyNo_TextChanged" Width ="150px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Serial No." >
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtSerialNumber" runat ="server" Width ="150px" AutoPostBack="true"   OnTextChanged="txtSerialNoOfEquip_TextChanged" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-Width ="19%" HeaderText="Installed At" >
                                        <ItemTemplate>
                                            
                                       <asp:DropDownList ID="drpInstalledAtMac" runat="server" Width ="150px"  OnSelectedIndexChanged="drpInstalledAtMac_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-Width ="19%" HeaderText="Location">
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtPIFloorLocation" runat ="server"  Width ="250px" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                               

                                  </Columns>
                            </asp:GridView>

                                </div>
                             </td>
                          
                       </tr>
                      
                       <tr>
                          <td >
                                <asp:Button ID="btnProceedEdit"  runat="server" Width="150px" CssClass="CSButton" Text="PROCEED" OnClick="btnProceedEdit_Click"></asp:Button>
                    
                        <asp:Button ID="btnAuthCancel"  runat="server" Width="150px" CssClass="CSButton" Text="CANCEL"></asp:Button>
                     </td>
                       </tr>
                   </table>
                  
                  </asp:Panel>   



<!-- ===== APPROVAL MODAL ===== -->

<asp:Label ID="lblApprovalTarget"
    runat="server"
    Style="display: none;">
</asp:Label>

<cc1:ModalPopupExtender ID="ModalPopupExtender_Approval"
    runat="server"
    TargetControlID="lblApprovalTarget"
    PopupControlID="pnlApproval"
    CancelControlID="btnCancelApproval"
    BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>


<asp:Panel ID="pnlApproval" runat="server" Width="350px" CssClass="Panel_Popup" DefaultButton="btnProceedApproval" >
    <table width="100%">
        <tr>
            <td style="width: 100%; height: 30px" colspan="2" class="DivTitle">
                APPROVAL
            </td>
        </tr>
        <tr>      
            <td class="column_RightBold" style="width: 40%">Approving Officer :</td>
            <td class="column_Left">
                <asp:DropDownList ID="drpApprovedOfficer" runat="server" Width="180px" CssClass="drpdownCSS"></asp:DropDownList>
            </td>
        </tr>
        <tr>      
            <td class="column_RightBold">Password :</td>
            <td class="column_Left">
                <asp:TextBox ID="txtApprovedPass" runat="server" CssClass="txtbox_Var" Width="180px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center; padding-top: 10px;">
                <asp:Button ID="btnProceedApproval" runat="server" Width="120px" CssClass="CSButton" Text="PROCEED" ></asp:Button>
                <asp:Button ID="btnCancelApproval" CausesValidation="False" runat="server" Width="120px" CssClass="CSButton" Text="CANCEL"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Panel>




   </ContentTemplate>  
       </asp:UpdatePanel>
</asp:Content>