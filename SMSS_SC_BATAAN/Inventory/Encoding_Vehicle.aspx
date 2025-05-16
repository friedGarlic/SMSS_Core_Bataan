<%@ Page Title="Encoding of Vehicle" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Encoding_Vehicle.aspx.vb" Inherits="Inventory_Encoding_Vehicle"     
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
<script type="text/javascript" id="8">
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
            document.getElementById("ctl00_ContentPlaceHolder1_txtVehicleNoYears").value = age;}
       
 }
   
    // function getDepValRate(Integer) {
    //     var year =  document.getElementById('ctl00_ContentPlaceHolder1_txtVehicleNoYears').value;
    //     var UL =  document.getElementById('ctl00_ContentPlaceHolder1_txtVehicleUsefullife').value;

    //     var depval = ((year / UL) * 100)
          
    //     if (depval > 100) {
    //         depval = 100
    //     }

    //     document.getElementById("ctl00_ContentPlaceHolder1_txtVehicleDepRate").value = depval;

    //    //Depreciation
    //    var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtVehicleAcqCost").value;
    //    AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
    //    AcquisationCostVal = parseInt(AcquisationCostVal, 10);
    //    var Salvagevalue = document.getElementById('ctl00_ContentPlaceHolder1_txtVehicleSalvageValue').value;
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
        
    //    document.getElementById("ctl00_ContentPlaceHolder1_txtVehicleDepValue").value = (DepreciatedValue).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    //    //End Depreciated

    //}
    //Refactor
        function getDepValRate() {
          const yearInput = document.getElementById('ctl00_ContentPlaceHolder1_txtVehicleNoYears');
          const year = parseInt(yearInput.value, 10);

          const ULInput = document.getElementById('ctl00_ContentPlaceHolder1_txtVehicleUsefullife');
          const UL = parseInt(ULInput.value, 10);

          const depval = Math.min((year / UL) * 100, 100);
          document.getElementById('ctl00_ContentPlaceHolder1_txtVehicleDepRate').value = depval.toFixed(2);

          const acquisationCostInput = document.getElementById('ctl00_ContentPlaceHolder1_txtVehicleAcqCost');
          const acquisationCost = parseInt(acquisationCostInput.value.replace(/\,/g, ''), 10);

          const salvageValueInput = document.getElementById('ctl00_ContentPlaceHolder1_txtVehicleSalvageValue');
          const salvageValue = parseInt(salvageValueInput.value.replace(/\,/g, ''), 10);

          const ULGreaterThanZero = UL > 0;
          if (acquisationCost > 0 && salvageValue > 0 && ULGreaterThanZero) {
            const depreciation = (acquisationCost - salvageValue) / UL;
            document.getElementById('ctl00_ContentPlaceHolder1_txtDepreciationValue').value = depreciation.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
            const depreciatedValue = acquisationCost - (depreciation * year);
            document.getElementById('ctl00_ContentPlaceHolder1_txtVehicleDepValue').value = depreciatedValue.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
          }
        }



    function getSalVal(Double) {
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtVehicleAcqCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var SalvageVal = AcquisationCostVal * 0.05

        document.getElementById("ctl00_ContentPlaceHolder1_txtVehicleSalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }


    function NoOfYearsWater(dateString) {
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
            document.getElementById("ctl00_ContentPlaceHolder1_txtWatercraftNoYears").value = age;}
       
 }
   
     function getWaterDepValRate(Integer) {
         var year =  document.getElementById('ctl00_ContentPlaceHolder1_txtWatercraftNoYears').value;
         var UL =  document.getElementById('ctl00_ContentPlaceHolder1_txtWatercraftUsefulLife').value;

         var depval = ((year / UL) * 100)
          
         if (depval > 100) {
             depval = 100
         }

         document.getElementById("ctl00_ContentPlaceHolder1_txtWatercraftDepRate").value = depval;

        //Depreciation
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtWatercraftAcqCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var Salvagevalue = document.getElementById('ctl00_ContentPlaceHolder1_txtWatercraftSalvageValue').value;
        Salvagevalue = Salvagevalue.replace(/\,/g, '');
        Salvagevalue = parseInt(Salvagevalue, 10);

        var Depreciation = 0.00;
        if (AcquisationCostVal > 0 && Salvagevalue > 0 && UL > 0) {
            Depreciation = (AcquisationCostVal - Salvagevalue) / UL
        }

         document.getElementById("ctl00_ContentPlaceHolder1_txtWatercraftDepreciationValue").value = (Depreciation).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

        //End Depreciation

        //Depreciated
        var DepreciatedtVal = document.getElementById("ctl00_ContentPlaceHolder1_txtWatercraftDepreciationValue").value;
        DepreciatedtVal = DepreciatedtVal.replace(/\,/g, '');
        DepreciatedtVal = parseInt(DepreciatedtVal, 10);
        var DepreciatedValue = 0.00;
         if (DepreciatedtVal > 0) {
             DepreciatedValue = AcquisationCostVal - (DepreciatedtVal * year);
         }
        
        document.getElementById("ctl00_ContentPlaceHolder1_txtWatercraftDepValue").value = (DepreciatedValue).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        //End Depreciated

    }

    function getWaterSalVal(Double) {
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtWatercraftAcqCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var SalvageVal = AcquisationCostVal * 0.05

        document.getElementById("ctl00_ContentPlaceHolder1_txtWatercraftSalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }
 </script>


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>
            <div>
                 <table width="100%">
                      <tr>
                        <td colspan="7" class="PageTitle" style="width: 98%">
                            <%--STOCK CARD--%><strong>
                                <asp:Label ID="lblClass" runat="server" Text="Encoding of Vehicle"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                      <tr>
                       <td colspan="7" style="width: 98%" align="left">
                           <span  class="column_RightBold" >Sub Classification :</span>
                          <asp:DropDownList ID="drpSubClass" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="drpSubClass_SelectedIndexChanged" ></asp:DropDownList> &nbsp;
                           <span  class="column_RightBold" >Category :</span>
                                <asp:DropDownList ID="ddCategory" runat="server" AutoPostBack="True" Width="200px" CssClass="drpdownCSS" OnSelectedIndexChanged="ddCategory_SelectedIndexChanged" ></asp:DropDownList>
                    
                       </td>
                    </tr>
                      <tr>
                        <td align="center" style="width: 100%">
                            <asp:HiddenField ID="hdnItemNo" runat="server" />
                            <asp:HiddenField ID="hdnGAId" runat="server" />

                        </td>

                    </tr>
                      <tr>
                        <td align="center" class="DivTitle" style="width: 100%"><asp:Label ID="lblSubClass" runat="server" Text="VEHICLE INFORMATION"></asp:Label>

                        </td>
                    </tr>
                     <tr>
                        <td style="width: 100%">
                            <asp:MultiView ID="mvVehicle" runat="server" ActiveViewIndex="0" >
                                  <asp:View ID="vwVehicle" runat="server">
                                            
                                      <table style="width: 100%;">
                                          <tr>
                                              <td class="column_RightBold" style="width: 10%">Name :

                                              </td>
                                              <td class="column_Left" style="width: 30%">

                                                  <asp:Label ID="lblVehicleName" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                  <asp:DropDownList ID="DrpVehicleName" AutoPostBack="true" runat="server" Width="91%" OnSelectedIndexChanged="DrpVehicleName_SelectedIndexChanged"></asp:DropDownList>

                                                  <asp:TextBox ID="txtVehicleName" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                              </td>

                                              <td class="column_RightBold" style="width: 10%">Power Input :

                                              </td>
                                              <td class="column_Left" style="width: 30%">
                                                  <asp:Label ID="Label9" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                  <asp:TextBox ID="txtVehiclePowerInput" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                              </td>
                                              <td align="center" rowspan="6" style="width: 20%" valign="middle">
                                                  <asp:Image ID="Image1" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                                  <br />
                                                  <asp:Button ID="Button1" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="true"></asp:Button>

                                              </td>
                                          </tr>
                                          <tr>
                                              <td class="column_RightBold" style="width: 10%">Description :

                                              </td>
                                              <td class="column_Left" style="width: 30%">
                                                  <asp:Label ID="Label7" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                  <asp:TextBox ID="txtVehicleDesc" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                              </td>
                                              <td class="column_RightBold" style="width: 10%">Warranty :

                                              </td>
                                              <td class="column_Left" style="width: 30%">
                                                  <asp:Label ID="Label12" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                  <asp:TextBox ID="txtVehicleWarranty" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                              </td>

                                          </tr>
                                          <tr>


                                              <td class="column_RightBold" style="width: 10%">Make :

                                              </td>
                                              <td class="column_Left" style="width: 30%">

                                                  <asp:Label ID="Label6" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                  <asp:DropDownList ID="DropDownList9" AutoPostBack="true" runat="server" Width="91%" Visible="false"></asp:DropDownList>

                                                  <asp:TextBox ID="txtVehicleMake" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                              </td>
                                              <td class="column_RightBold" style="width: 10%">Quantity :

                                              </td>
                                              <td class="column_Left" style="width: 30%">
                                                  <asp:Label ID="Label10" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                  <asp:TextBox ID="txtVehicleQuantity" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td class="column_RightBold" style="width: 10%">Type Of Vehicle :

                                              </td>
                                              <td class="column_Left" style="width: 30%">
                                                  <asp:Label ID="Label11" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                  <asp:TextBox ID="txtVehicleType" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                              </td>

                                              <td class="column_RightBold" style="width: 10%">Color :

                                              </td>
                                              <td class="column_Left" style="width: 30%">
                                                  <asp:Label ID="Label8" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                  <asp:TextBox ID="txtVehicleColor" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                              </td>
                                          </tr>
                                          <tr>
                                               <td class="column_RightBold" style="width: 10%">Unit :

                                              </td>
                                              <td class="column_Left" style="width: 30%">
                                                  <asp:Label ID="LabelA" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                  <asp:Dropdownlist ID="ddVehicleUnit" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:Dropdownlist>

                                              </td>
                                          </tr>
                                          <tr>
                                              <td class="column_RightBold" style="width: 10%"></td>
                                              <td class="column_Left" style="width: 30%"></td>

                                              <td class="column_RightBold" style="width: 10%"></td>
                                              <td class="column_Left" style="width: 30%">
                                                  <asp:LinkButton ID="btnAddPropertyInfo" runat="server" Text="Add Property Information" OnClick="btnaddpropertyinfo_Click"></asp:LinkButton>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td colspan="4">
                                                  <fieldset style="width: 90%;">
                                                      <legend class="column_LeftBold">Acquisition :</legend>
                                                      <table>
                                                          <tr>
                                                              <td class="column_RightBold" style="width: 121px">Acquisition Date :
                                                              </td>
                                                              <td class="column_Left" style="width: 100px;">
                                                                  <asp:Label ID="Label13" runat="server"></asp:Label>
                                                                  <asp:TextBox ID="txtEAcqDate" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="140px" onchange="return NoOfYears(this.value);"></asp:TextBox>
                                                                  <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEAcqDate" PopupButtonID="txtEAcqDate"></cc1:CalendarExtender>


                                                                  &nbsp;(MM/DD/YYYY)</td>
                                                              <td class="column_RightBold">Market Value :
                                                              </td>
                                                              <td class="column_Left">
                                                                  <asp:Label ID="Label14" runat="server"></asp:Label>
                                                                  <asp:TextBox ID="txtVehicleMarketValue" runat="server" AutoPostBack="True" Width="140px" CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>

                                                              </td>


                                                          </tr>
                                                          <tr>

                                                              <td class="column_RightBold" style="width: 121px">Acquisition Cost :
                                                              </td>
                                                              <td class="column_Left">
                                                                  <asp:Label ID="Label15" runat="server"></asp:Label>
                                                                  <asp:TextBox ID="txtVehicleAcqCost" runat="server" AutoPostBack="True" Width="140px" CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalVal(this),getDepValRate(this);"></asp:TextBox>
                                                              </td>

                                                              <td class="column_RightBold">No. of Years :
                                                              </td>
                                                              <td class="column_Left">
                                                                  <asp:Label ID="Label16" runat="server"></asp:Label>
                                                                  <asp:TextBox ID="txtVehicleNoYears" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="50px"></asp:TextBox>

                                                              </td>
                                                          </tr>
                                                          <tr>

                                                              <td class="column_RightBold" style="width: 121px">Depreciated Rate :
                                                              </td>
                                                              <td class="column_Left">
                                                                  <asp:TextBox ID="txtVehicleDepRate" runat="server" Width="50px" AutoPostBack="True" CssClass="txtboxAmount" MaxLength="5"></asp:TextBox>&nbsp;(%) Percent</td>


                                                              <td class="column_RightBold">Useful Life :
                                                              </td>
                                                              <td class="column_Left">
                                                                  <asp:Label ID="Label17" runat="server"></asp:Label>
                                                                  <asp:TextBox ID="txtVehicleUsefullife" runat="server" Width="50px" AutoPostBack="True" CssClass="txtbox_Var" onchange="return getDepValRate(this);"></asp:TextBox>

                                                                  &nbsp;(Years)</td>

                                                          </tr>


                                                          <tr>

                                                              <td class="column_RightBold" style="width: 121px">Depreciated Value :
                                                              </td>
                                                              <td class="column_Left">
                                                                  <asp:Label ID="Label18" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                  <asp:TextBox ID="txtVehicleDepValue" runat="server" Width="140px" CssClass="txtboxAmount" AutoPostBack="True"></asp:TextBox>
                                                              </td>

                                                              <td class="column_RightBold">Salvage Value :
                                                              </td>
                                                              <td class="column_Left">
                                                                  <asp:TextBox ID="txtVehicleSalvageValue" runat="server" Width="140px" AutoPostBack="True" CssClass="txtboxAmount">0.00</asp:TextBox></td>


                                                          </tr>

                                                          <tr>
                                                              <td class="column_RightBold" style="width: 121px">Depreciation Value :</td>
                                                              <td class="column_Left">
                                                                  <asp:TextBox ID="txtDepreciationValue" runat="server" CssClass="txtboxAmount" Width="140px"></asp:TextBox>
                                                              </td>
                                                              <td></td>
                                                              <td></td>
                                                          </tr>


                                                      </table>
                                                  </fieldset>
                                              </td>
                                          </tr>
                                          <tr style="display: none;">
                                              <td colspan="4">
                                                  <fieldset style="width: 90%;">
                                                      <legend class="column_Left" style="font-family: Arial; color: #404040;"><strong>Location:</strong></legend>
                                                      <table width="100%">
                                                          <tr>
                                                              <td class="column_RightBold">Warehouse :
                                                              </td>
                                                              <td class="column_Left">
                                                                  <asp:DropDownList ID="DropDownList10" runat="server" Width="98%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                              </td>

                                                              <td class="column_RightBold">Bay :
                                                              </td>
                                                              <td class="column_Left">
                                                                  <asp:TextBox ID="TextBox18" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                  <asp:DropDownList ID="DropDownList11" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                              </td>

                                                              <td class="column_RightBold" style="width: 15%">Column :
                                                              </td>
                                                              <td class="column_Left">
                                                                  <asp:TextBox ID="TextBox19" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                  <asp:DropDownList ID="DropDownList12" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                              </td>

                                                              <td class="column_RightBold" style="width: 10%">Floor :
                                                              </td>
                                                              <td class="column_Left">
                                                                  <asp:TextBox ID="TextBox20" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                  <asp:DropDownList ID="DropDownList13" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                              </td>
                                                          </tr>
                                                          <tr>
                                                              <td class="column_RightBold">Room :
                                                              </td>
                                                              <td class="column_Left">
                                                                  <asp:TextBox ID="TextBox21" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                  <asp:DropDownList ID="DropDownList14" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                              </td>

                                                              <td class="column_RightBold" style="width: 10%">Shelves :
                                                              </td>
                                                              <td class="column_Left">
                                                                  <asp:TextBox ID="TextBox22" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                  <asp:DropDownList ID="DropDownList15" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                              </td>

                                                              <td class="column_RightBold">Rack :
                                                              </td>
                                                              <td class="column_Left">
                                                                  <asp:TextBox ID="TextBox23" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                  <asp:DropDownList ID="DropDownList16" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                              </td>

                                                              <td class="column_RightBold">Bin :
                                                              </td>
                                                              <td class="column_Left">
                                                                  <asp:TextBox ID="TextBox24" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                                  <asp:DropDownList ID="DropDownList17" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                              </td>
                                                          </tr>

                                                      </table>
                                                  </fieldset>
                                              </td>
                                          </tr>
                                          <tr style="display: none;">
                                              <td class="column_RightBold" style="width: 10%">Specifications :
                                              </td>
                                              <td class="column_Left" colspan="3">
                                                  <asp:Label ID="Label19" runat="server" CssClass="text3"></asp:Label>
                                                  <asp:TextBox ID="TextBox25" runat="server" Width="95%" Height="25px" TextMode="MultiLine" AutoPostBack="True" CssClass="txtbox_Var" Rows="2"></asp:TextBox>

                                              </td>
                                          </tr>
                                          <tr>
                                              <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                              <td class="column_RightBold" colspan="3">
                                                  <asp:Label ID="Label30" runat="server" Visible="false" Width="100%" Text="CREDIT" CssClass="borderCSS"></asp:Label>
                                                  <asp:Label ID="lblItem_ID" runat="server" Text="Label" Visible="false"></asp:Label>
                                                  <asp:Label ID="lblProperty_ID" runat="server" Text="Label" Visible="false"></asp:Label>
                                                  <asp:Label ID="lblPropertyDetai_ID" runat="server" Text="Label" Visible="false"></asp:Label>
                                                  <asp:Label ID="lblMotor_InfoId" runat="server" Text="Label" Visible="false"></asp:Label>
                                                  <asp:Label ID="lblMotorID" runat="server" Text="Label" Visible="false"></asp:Label>
                                              </td>
                                              <td>
                                                  <asp:Button ID="btnSave" runat="server" Width="48%" CssClass="CSButton" Text="SAVE" Enabled="false" OnClientClick="StartProgressBar();" OnClick="btnSave_Click"></asp:Button>
                                                  <asp:Button ID="Button3" runat="server" Width="48%" CssClass="CSButton" Text="CANCEL" Enabled="false"></asp:Button>
                                              </td>
                                          </tr>
                                      </table>

                             </asp:View>
                                    <asp:View ID="vwWaterCraft" runat="server">
                                            
                                 <table style="width: 100%;">
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">
                                        Name :

                                    </td>
                                    <td class="column_Left" style="width: 30%">

                                        <asp:Label ID="lblWatercraftName" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="drpWatercraftName" AutoPostBack ="true" runat="server" Width="91%" OnSelectedIndexChanged="drpWatercraftName_SelectedIndexChanged" ></asp:DropDownList>
                                                          
                                        <asp:TextBox ID="txtWatercraftName" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold" style="width: 10%">Power Input :

                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblWatercraftPowerInput" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtWatercraftPowerInput" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                    <td align="center" rowspan="6" style="width: 20%" valign="middle" >
                                        <asp:Image ID="imgWatercraftImage" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                        <br />
                                               <asp:Button ID="btnWatercraftUpload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>
                                
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">
                                        Description :

                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblWatercraftDescription" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtWatercraftDescription" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                     <td class="column_RightBold" style="width: 10%">Warranty :

                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblWatercraftWarranty" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtWatercraftWarranty" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                   
                                </tr>
                                <tr>
                                    

                                    <td class="column_RightBold" style="width: 10%">
                                        Make :

                                    </td>
                                    <td class="column_Left" style="width: 30%">

                                        <asp:Label ID="lblWatercraftMake" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="drpWatercraftMake" AutoPostBack ="true" runat="server" Width="91%"  Visible="false"></asp:DropDownList>
                                                          
                                        <asp:TextBox ID="txtWatercraftMake" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" ></asp:TextBox>
                                    </td>
                                    <td class="column_RightBold" style="width: 10%">Quantity :

                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblWatercraftQuantity" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtWatercraftQuantity" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                     <td class="column_RightBold" style="width: 10%">Type Of Vessel :

                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblWatercraftType" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtWatercraftType" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                   
                                    <td class="column_RightBold" style="width: 10%">
                                        Color :

                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblWatercraftColor" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtWatercraftColor" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>
                               <tr>
                                   <td class="column_RightBold" style="width: 10%">
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                     
                                    </td>
                                   
                                    <td class="column_RightBold" style="width: 10%">
                                       
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:LinkButton id="lbWatercraftAddPropertyInfo" runat="server" text="Add Property Information"  OnClick="btnaddpropertyinfo_Click" ></asp:LinkButton>
                                       </td>
                               </tr>

                                     <tr>
                                          <td colspan ="4">
                                              <fieldset style="width:90%;">
                                                       <legend class="column_LeftBold">Vessel Details :</legend>
                                                  <table width="100%">
                                                  <tr>
                                                      <td class="column_RightBold">
                                                          MMSI :
                                                      </td>
                                                      <td class="column_Left">
                                                              <asp:TextBox ID="txtWatercraftMMSI" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                      </td>
                                                     <td class="column_RightBold">
                                                          Hull Material :
                                                      </td>
                                                      <td class="column_Left">
                                                                    <asp:TextBox ID="txtWatercraftHullMaterial" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                  
                                                      </td>
                                                  </tr>
                                                  <tr>
                                                      <td class="column_RightBold">
                                                          Call Sign :
                                                      </td>
                                                      <td class="column_Left">
                                                              <asp:TextBox ID="txtWatercraftCallSign" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                      </td>
                                                     <td class="column_RightBold">
                                                          No. of Mast :
                                                      </td>
                                                      <td class="column_Left">
                                                                    <asp:TextBox ID="txtWatercraftNoofMast" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                  
                                                      </td>
                                                  </tr>
                                                  <tr>
                                                      <td class="column_RightBold">
                                                          IMO # :
                                                      </td>
                                                      <td class="column_Left">
                                                              <asp:TextBox ID="txtWatercraftImoNo" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                      </td>
                                                     <td class="column_RightBold">
                                                          No of Decks :
                                                      </td>
                                                      <td class="column_Left">
                                                                    <asp:TextBox ID="txtWatercraftNoofDecks" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                  
                                                      </td>
                                                  </tr>
                                              </table>
                                              </fieldset>
                                              
                                          </td>
                                     </tr>
                                            <tr>
                                          <td colspan ="4">
                                              <fieldset style="width:90%;">
                                                       <legend class="column_LeftBold">Power & Carrying Capacity :</legend>
                                                  <table width="100%">
                                                  <tr>
                                                      <td class="column_RightBold">
                                                          No. of Engine :
                                                      </td>
                                                      <td class="column_Left">
                                                              <asp:TextBox ID="txtWatercraftNoofEngine" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                      </td>
                                                     <td class="column_RightBold">
                                                          NRT :
                                                      </td>
                                                      <td class="column_Left">
                                                                    <asp:TextBox ID="txtWatercraftNRT" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                  
                                                      </td>
                                                  </tr>
                                                  <tr>
                                                      <td class="column_RightBold">
                                                          Main Engine :
                                                      </td>
                                                      <td class="column_Left">
                                                              <asp:TextBox ID="txtWatercraftMainEngine" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                      </td>
                                                     <td class="column_RightBold">
                                                         LOA :
                                                      </td>
                                                      <td class="column_Left">
                                                                    <asp:TextBox ID="txtWatercraftLOA" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                  
                                                      </td>
                                                  </tr>
                                                  <tr>
                                                      <td class="column_RightBold">
                                                          Horsepower :
                                                      </td>
                                                      <td class="column_Left">
                                                              <asp:TextBox ID="txtWatercraftHorsePower" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                      </td>
                                                     <td class="column_RightBold">
                                                          Breadth:
                                                      </td>
                                                      <td class="column_Left">
                                                                    <asp:TextBox ID="txtWatercraftBreadth" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                  
                                                      </td>
                                                  </tr>
                                                  <tr>
                                                      <td class="column_RightBold">
                                                          GRT :
                                                      </td>
                                                      <td class="column_Left">
                                                              <asp:TextBox ID="txtWaterCraftGRT" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                      </td>
                                                     <td class="column_RightBold">
                                                          Carrying Capacity:
                                                      </td>
                                                      <td class="column_Left">
                                                                    <asp:TextBox ID="txtWaterCraftCarryingCapacity" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                  
                                                      </td>
                                                  </tr>
                                              </table>
                                              </fieldset>
                                              
                                          </td>
                                     </tr>
                              
                                <tr>
                                    <td colspan ="4">
                                        <fieldset style="width:90%;">
                                            <legend class="column_LeftBold">Acquisition :</legend>
                                        <table >
                                             <tr>
                                     <td  class="column_RightBold">Acquisition Date :
                                    </td>
                                    <td class="column_Left" style="width:100px;">
                                        <asp:Label ID="lblWatercraftAcqDate" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtWatercraftAcqDate" runat="server"  AutoPostBack="True" CssClass="txtbox_Var" onchange="return NoOfYearsWater(this.value);"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtWatercraftAcqDate" PopupButtonID="txtWatercraftAcqDate"></cc1:CalendarExtender>


                                        &nbsp;(MM/DD/YYYY)</td>
                                   <td class="column_RightBold" >Market Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="lblWatercraftMarketValue" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtWatercraftMarketValue" runat="server"  AutoPostBack="True" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>

                                    </td>
                                    
                                    
                                </tr>
                                <tr>
                                    
                                    <td class="column_RightBold" >Acquisition Cost :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="lblWatercraftAcqCost" runat="server" ></asp:Label>
                                        <asp:TextBox ID="txtWatercraftAcqCost" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getWaterSalVal(this),getWaterDepValRate(this);"></asp:TextBox>
                                    </td>
                                    
                                    <td class="column_RightBold" >No. of Years :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="lblWatercraftNoYears" runat="server" ></asp:Label>
                                        <asp:TextBox ID="txtWatercraftNoYears" runat="server" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    
                                    <td class="column_RightBold">Depreciated Rate :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtWatercraftDepRate" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" MaxLength="5"></asp:TextBox>&nbsp;(%) Percent</td>

                                    
                                    <td class="column_RightBold">Useful Life :
                                    </td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblWatercraftUsefulLife" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtWatercraftUsefulLife" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var" onchange="return getWaterDepValRate(this);" ></asp:TextBox>

                                        &nbsp;(Years)</td>

                                </tr>


                                <tr>
                                    
                                    <td class="column_RightBold" >Depreciated Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="lblWatercraftDepValue" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtWatercraftDepValue" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    
                                   <td class="column_RightBold">Salvage Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:TextBox ID="txtWatercraftSalvageValue" runat="server" Width="85%"  AutoPostBack="True" CssClass="txtboxAmount" >0.00</asp:TextBox></td>


                                </tr>
                                <tr>
                                    <td class="column_RightBold"><span style="color: rgb(64, 64, 64); font-family: Arial; font-size: 12px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 700; letter-spacing: normal; orphans: 2; text-align: right; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Depreciation Value :</span></td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtWatercraftDepreciationValue" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="100px"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                        </table>
                                        </fieldset>
                                    </td>
                                </tr>
                                <tr style="display:none;">
                                                        <td colspan="4" >
                                                             <fieldset style="width:90%;">
                                                                 <legend  class="column_Left" style =" font-family:Arial; color:#404040;"><strong>Location:</strong></legend>
                                                                 <table width="100%">
                                                                     <tr>
                                                                         <td class="column_RightBold" >Warehouse :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:DropDownList ID="DropDownList3" runat="server" Width="98%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Bay :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="TextBox17" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList4" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:15%">Column :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                 <asp:TextBox ID="TextBox26" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList5" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Floor :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                <asp:TextBox ID="TextBox27" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList6" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                     </tr>
                                                                     <tr>
                                                                         <td class="column_RightBold">Room :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="TextBox28" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList7" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Shelves :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="TextBox29" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList8" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Rack :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="TextBox30" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList18" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                         
                                                                         <td class="column_RightBold">Bin :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="TextBox31" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             <asp:DropDownList ID="DropDownList19" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                     </tr>
                                                                    
                                                                 </table>
                                                             </fieldset>
                                                        </td>
                                                    </tr>
                                <tr style="display:none;">
                                    <td class="column_RightBold" style="width: 10%">Specifications :
                                    </td>
                                    <td class="column_Left" colspan="3">
                                        <asp:Label ID="Label29" runat="server" CssClass="text3"></asp:Label>
                                        <asp:TextBox ID="TextBox32" runat="server" Width="95%" Height="25px" TextMode="MultiLine" AutoPostBack="True" CssClass="txtbox_Var" Rows="2"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                    <td class="column_RightBold" colspan="3"></td>
                                    <td>
                                        <asp:Button ID="btnWatercraftsave" runat="server" Width="48%" CssClass="CSButton" Text="SAVE" Enabled="false" OnClientClick="StartProgressBar();" OnClick="btnWatercraftsave_Click"></asp:Button>
                                        <asp:Button ID="btnWatercraftcancel" runat="server" Width="48%" CssClass="CSButton" Text="CANCEL" Enabled="false"></asp:Button>
                                    </td>
                                </tr>
                            </table>

                             </asp:View>

                            </asp:MultiView>

                        </td>
                    </tr>
                      <tr>
                        <td align="center" class="column_Left" style="width: 100%">
                            <asp:Button ID="btnEquipmentLedger" runat="server" Width="180px" CssClass="Initial" Text="Transactions"  Visible="true"></asp:Button>
                            <asp:Button ID="btnequipmentrepairs" runat="server" Width="180px" CssClass="Initial" Text="Repairs and Maintenance"></asp:Button>
                            <asp:Button ID="btnequipmentattachdoc" runat="server" Width="180px" CssClass="Initial" Text="Document Attached"></asp:Button>
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
                                                    <asp:GridView ID="grdLedger1" runat="server" Width="100%" SkinID="GridViewAA" HorizontalAlign="Center" Font-Size="8pt" OnDataBound = "OnDataBound" OnRowDataBound="grdLedger1_RowDataBound">
                                                        <%--OnSelectedIndexChanged="grdrepairsandmaintenance_SelectedIndexChanged"--%>
                                                        <Columns>
                                                            <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Trans_Type" HeaderText="Particulars">
                                                                <ItemStyle HorizontalAlign="Left" Width="46%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ref" HeaderText="Ref No" Visible="false">
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
                                                            <asp:BoundField DataField="BalanceUnit" HeaderText="Unit">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="UnitPrice" DataFormatString="{0:N}" HeaderText="Unit Price">
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
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>


         <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
         <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>

         <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="lblClass" PopupControlID="popupParticular" CancelControlID="ImageButton2" BackgroundCssClass="modalBackground">
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
                                 <asp:GridView ID="grdPropertyInfo" runat="server" SkinID="gvnew" AutoGenerateColumns="false"
                            EmptyDataText="No records has been added." OnRowDataBound="grdPropertyInfo_RowDataBound" Width="500px">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width ="50px">
                                        <ItemTemplate>
                                            
                                            <asp:CheckBox id="cbPI" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Property Number" >
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtPropertyNo" runat ="server" AutoPostBack="true" OnTextChanged="txtPropertyNo_TextChanged" Width ="200px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Engine Number" >
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtSerialNo" runat ="server" Width ="200px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Chasis No." >
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtChasisNo" runat ="server" Width ="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="License Plate No." >
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtLicensePlateNo" runat ="server" Width ="75px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="MV File No." >
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtMVFileNo" runat ="server" Width ="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Con. Sticker" >
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtConSticker" runat ="server" Width ="75px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width ="19%" HeaderText="Department" Visible="false">
                                        <ItemTemplate>
                                            
                                       <asp:DropDownList ID="drpDepartment" runat="server" Width ="300px" ></asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width ="19%" HeaderText="Accountable Person"  Visible="false">
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtAccountablePerson" runat ="server"  Width ="200px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width ="19%" HeaderText="Floor Location" Visible="false">
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtPIFloorLocation" runat ="server"  Width ="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width ="50%" HeaderText="Room" Visible="false">
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtPIRoom" runat ="server"  Width ="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  </Columns>
                            </asp:GridView>

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

         <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lblSubClass" PopupControlID="popupAccess" CancelControlID="ImageButton2" BackgroundCssClass="modalBackground">
         </cc1:ModalPopupExtender>
               <asp:Panel ID="popupAccess" runat="server" Width="350px" CssClass="Panel_Popup">
                   <div>
                          <table width="100%">
                              <tr>
                                 <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">
                                     APPROVAL
                                  </td>
                              </tr>
                              <tr>      
                                  <td class="column_RightBold">
                                      Approving Officer :
                                    </td>
                                  <td class="column_Left">
                                      <asp:DropDownList id="drpApprovedOfficer" runat="server" Width="150px" CssClass="ddropbox"></asp:DropDownList>
                                  </td>
                              </tr>
                               <tr>      
                                  <td class="column_RightBold">
                                      Password :
                                    </td>
                                  <td class="column_Left">
                                     <asp:TextBox ID="txtApprovedPass" runat ="server" CssClass="txtbox_Var" Width="150px" TextMode="Password"></asp:TextBox>

                                  </td>
                              </tr>
                              <tr>
                                  <td colspan="3">
                                <asp:Button ID="Button2" OnClick="Button2_Click"  runat="server" Width="150px" CssClass="CSButton" Text="PROCEED"></asp:Button>
                    
                                <asp:Button ID="Button4" OnClick="Button4_Click"  runat="server" Width="150px" CssClass="CSButton" Text="CANCEL"></asp:Button>
                            </td>
                              </tr>
                          </table>
                       </div>
                  </asp:Panel>    

                </ContentTemplate>

      </asp:UpdatePanel>
</asp:Content>

