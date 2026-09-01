
<%@ Page Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    EnableEventValidation="false" 
    AutoEventWireup="false" 
    CodeFile="PropertyCard_v4.aspx.vb" 
    Inherits="Records_PropertyCard_v3"
    title="Property Card"  
    StylesheetTheme="SkinFile"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
 <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
 <script language="javascript" type="text/javascript">
function Table2_onclick() {
}
function fun1(e, button1){
          var evt = e ? e : window.event;
          var bt = document.getElementById(button1);
          if (bt){
              if (evt.keyCode == 13){
                    bt.click();
                    return false;
              }
          }
     }
    // Building
    function NoOfYearsBuilding(dateString) {
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
   
     function getDepValRateBuilding() {
      const yearInput = document.querySelector('#ctl00_ContentPlaceHolder1_txtNoYears');
      const ULInput = document.querySelector('#ctl00_ContentPlaceHolder1_txtUsefulLife');
      const acquisitionCostInput = document.querySelector('#ctl00_ContentPlaceHolder1_txtEAcqCost');
      const salvageValueInput = document.querySelector('#ctl00_ContentPlaceHolder1_txtSalvageValueBuilding');
      const depRateOutput = document.querySelector('#ctl00_ContentPlaceHolder1_txtBuildingDepRate');
      const depValueOutput = document.querySelector('#ctl00_ContentPlaceHolder1_txtBuildingdepreciatedvalue');
      const depreciatedValueOutput = document.querySelector('#ctl00_ContentPlaceHolder1_txtBuildingDepreciatedValueNew');

      const year = Number(yearInput.value);
      const UL = Number(ULInput.value);
      const acquisitionCost = Number(acquisitionCostInput.value.replace(/,/g, ''));
      const salvageValue = Number(salvageValueInput.value.replace(/,/g, ''));

      const depRate = Math.min((year / UL) * 100, 100);
      const depValue = UL > 0 ? (acquisitionCost - salvageValue) / UL : 0;
      const depreciatedValue = acquisitionCost - depValue * year;

      depRateOutput.value = depRate.toFixed(2);
      depValueOutput.value = depValue.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
      depreciatedValueOutput.value = depreciatedValue.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        }
    function getSalValBuilding(Double) {
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtEAcqCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var SalvageVal = AcquisationCostVal * 0.05

        document.getElementById("ctl00_ContentPlaceHolder1_txtSalvageValueBuilding").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }
     //End Building


     // Vehicles
    function NoOfYearsVehicles(dateString) {
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
    function getDepValRateVehicles(Integer) {
         //Depreciated Rate
         var year =  document.getElementById('ctl00_ContentPlaceHolder1_txtVehicleNoYears').value;
         var UL =  document.getElementById('ctl00_ContentPlaceHolder1_txtVehicleUsefullife').value;

         var depval = ((year / UL) * 100)
          
         if (depval > 100) {
             depval = 100
         }

         document.getElementById("ctl00_ContentPlaceHolder1_txtVehicleDepRate").value = depval;
         //End Depreciated Rate


        //Depreciation
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtVehicleAcqCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var Salvagevalue = document.getElementById('ctl00_ContentPlaceHolder1_txtVehicleSalvageValue').value;
        Salvagevalue = Salvagevalue.replace(/\,/g, '');
        Salvagevalue = parseInt(Salvagevalue, 10);

        var Depreciation = 0.00;
        if (AcquisationCostVal > 0 && Salvagevalue > 0 && UL > 0) {
            Depreciation = (AcquisationCostVal - Salvagevalue) / UL
        }

         document.getElementById("ctl00_ContentPlaceHolder1_txtVehicleDepValue").value = (Depreciation).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

        //End Depreciation

        //Depreciated
        var DepreciatedtVal = document.getElementById("ctl00_ContentPlaceHolder1_txtVehicleDepValue").value;
        DepreciatedtVal = DepreciatedtVal.replace(/\,/g, '');
        DepreciatedtVal = parseInt(DepreciatedtVal, 10);
        var DepreciatedValue = 0.00;
         if (DepreciatedtVal > 0) {
             DepreciatedValue = AcquisationCostVal - (DepreciatedtVal * year);
         }
        
        document.getElementById("ctl00_ContentPlaceHolder1_txtVehiclesDepreciatedValueNew").value = (DepreciatedValue).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        //End Depreciated

    }
    function getSalValVehicles(Double) {
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtVehicleAcqCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10); 
        var SalvageVal = AcquisationCostVal * 0.05

        document.getElementById("ctl00_ContentPlaceHolder1_txtVehicleSalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }
     //End Vehicles





      // Brige
    function NoOfYearsBridge(dateString) {
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
            document.getElementById("ctl00_ContentPlaceHolder1_txtBridgeNoYears").value = age;}
       
 }
    function getDepValRateBridge(Integer) {
         //Depreciated Rate
         var year = document.getElementById('ctl00_ContentPlaceHolder1_txtBridgeNoYears').value;
         var UL = document.getElementById('ctl00_ContentPlaceHolder1_txtBridgeUsefulLife').value;

         var depval = ((year / UL) * 100)

         if (depval > 100) {
             depval = 100
         }

         document.getElementById("ctl00_ContentPlaceHolder1_txtBridgeDepRate").value = depval;
         //End Depreciated Rate


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

         document.getElementById("ctl00_ContentPlaceHolder1_txtBridgeDepValue").value = (Depreciation).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

         //End Depreciation

         //Depreciated
         var DepreciatedtVal = document.getElementById("ctl00_ContentPlaceHolder1_txtBridgeDepValue").value;
         DepreciatedtVal = DepreciatedtVal.replace(/\,/g, '');
         DepreciatedtVal = parseInt(DepreciatedtVal, 10);
         var DepreciatedValue = 0.00;
         if (DepreciatedtVal > 0) {
             DepreciatedValue = AcquisationCostVal - (DepreciatedtVal * year);
         }

         document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciatedValueRBNew").value = (DepreciatedValue).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
         //End Depreciated
     }
    function getSalValBridge(Double) {
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtBridgeAcqCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var SalvageVal = AcquisationCostVal * 0.05

        document.getElementById("ctl00_ContentPlaceHolder1_txtBridgeSalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }
          // end Brige

         // Road
    function NoOfYearsRoad(dateString) {
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
            document.getElementById("ctl00_ContentPlaceHolder1_txtRoadNoYears").value = age;}
       
 } 
    function getDepValRateRoad(Integer) {
         //Depreciated Rate
         var year =  document.getElementById('ctl00_ContentPlaceHolder1_txtRoadNoYears').value;
         var UL =  document.getElementById('ctl00_ContentPlaceHolder1_txtRoadUsefulLife').value;

         var depval = ((year / UL) * 100)
          
         if (depval > 100) {
             depval = 100
         }

         document.getElementById("ctl00_ContentPlaceHolder1_txtRoadequipmentdepreciatedRate").value = depval;
         //End Depreciated Rate


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

         document.getElementById("ctl00_ContentPlaceHolder1_txtRoadequipmentdepreciatedvalue").value = (Depreciation).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

        //End Depreciation

        //Depreciated
        var DepreciatedtVal = document.getElementById("ctl00_ContentPlaceHolder1_txtRoadequipmentdepreciatedvalue").value;
        DepreciatedtVal = DepreciatedtVal.replace(/\,/g, '');
        DepreciatedtVal = parseInt(DepreciatedtVal, 10);
        var DepreciatedValue = 0.00;
         if (DepreciatedtVal > 0) {
             DepreciatedValue = AcquisationCostVal - (DepreciatedtVal * year);
         }
        
        document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciatedValueRoadNew").value = (DepreciatedValue).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        //End Depreciated

    }
    function getSalValRoad(Double) {
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtRoadAcqCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var SalvageVal = AcquisationCostVal * 0.05

        document.getElementById("ctl00_ContentPlaceHolder1_txtRoadSalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }
     //End Road


      // Book
    function NoOfYearsBook(dateString) {
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
            document.getElementById("ctl00_ContentPlaceHolder1_txtbookNoYears").value = age;}
       
 }
    function getDepValRateBook(Integer) {
         //Depreciated Rate
         var year =  document.getElementById('ctl00_ContentPlaceHolder1_txtbookNoYears').value;
         var UL =  document.getElementById('ctl00_ContentPlaceHolder1_txtbookUsefulLife').value;

         var depval = ((year / UL) * 100)
          
         if (depval > 100) {
             depval = 100
         }

         document.getElementById("ctl00_ContentPlaceHolder1_txtbookdepreciatedRate").value = depval;
         //End Depreciated Rate


        //Depreciation
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtbookAcqCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var Salvagevalue = document.getElementById('ctl00_ContentPlaceHolder1_txtbookSalvageValue').value;
        Salvagevalue = Salvagevalue.replace(/\,/g, '');
        Salvagevalue = parseInt(Salvagevalue, 10);

        var Depreciation = 0.00;
        if (AcquisationCostVal > 0 && Salvagevalue > 0 && UL > 0) {
            Depreciation = (AcquisationCostVal - Salvagevalue) / UL
        }

         document.getElementById("ctl00_ContentPlaceHolder1_txtbookdepreciatedvalue").value = (Depreciation).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

        //End Depreciation

        //Depreciated
        var DepreciatedtVal = document.getElementById("ctl00_ContentPlaceHolder1_txtbookdepreciatedvalue").value;
        DepreciatedtVal = DepreciatedtVal.replace(/\,/g, '');
        DepreciatedtVal = parseInt(DepreciatedtVal, 10);
        var DepreciatedValue = 0.00;
         if (DepreciatedtVal > 0) {
             DepreciatedValue = AcquisationCostVal - (DepreciatedtVal * year);
         }
        
        document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciatedValueBookNew").value = (DepreciatedValue).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        //End Depreciated

    }
    function getSalValBook(Double) {
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtbookAcqCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var SalvageVal = AcquisationCostVal * 0.05

        document.getElementById("ctl00_ContentPlaceHolder1_txtbookSalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }
     //End Book


      // Machine
    function NoOfYearsMachine(dateString) {
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
            document.getElementById("ctl00_ContentPlaceHolder1_txtMachineryNoYears").value = age;}
       
 } 
   
     //Refactor
     function getDepValRateMachine() {
  // renamed code goes here

  function calculateDepreciation() {
    const acquisationCostVal = parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_txtMachineryAcqCost').value.replace(/\,/g, ''));
    const salvageValue = parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_txtMachinerySalvageValue').value.replace(/\,/g, ''));
    const years = parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_txtMachineryNoYears').value);
    const usefulLife = parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_txtMachineryUsefulLife').value);

    let depreciation = 0.00;

    if (acquisationCostVal > 0 && salvageValue > 0 && usefulLife > 0) {
      depreciation = (acquisationCostVal - salvageValue) / usefulLife;
    }

    document.getElementById('ctl00_ContentPlaceHolder1_txtequipmentdepreciatedvalue').value = depreciation.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
  }

  function calculateDepreciatedValue() {
    const acquisationCostVal = parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_txtMachineryAcqCost').value.replace(/\,/g, ''));
    const depreciatedVal = parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_txtequipmentdepreciatedvalue').value.replace(/\,/g, ''));
    const years = parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_txtMachineryNoYears').value);

    let depreciatedValue = 0.00;

    if (depreciatedVal > 0) {
      depreciatedValue = acquisationCostVal - (depreciatedVal * years);
    }

    document.getElementById('ctl00_ContentPlaceHolder1_txtDepreciatedValueMachineNew').value = depreciatedValue.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
  }

  function calculateDepRate() {
    const years = parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_txtMachineryNoYears').value);
    const usefulLife = parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_txtMachineryUsefulLife').value);

    let depRate = (years / usefulLife) * 100;

    if (depRate > 100) {
      depRate = 100;
    }

    document.getElementById('ctl00_ContentPlaceHolder1_txtMachineryDepRate').value = depRate.toFixed(2);
  }

  calculateDepRate();
  calculateDepreciation();
  calculateDepreciatedValue();
}


    function getSalValMachine(Double) {
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtMachineryAcqCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var SalvageVal = AcquisationCostVal * 0.05

        document.getElementById("ctl00_ContentPlaceHolder1_txtMachinerySalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }
     //End Machine


      // FIXTURES INFORMATION
    function NoOfYearsFIXTURES(dateString) {
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
            document.getElementById("ctl00_ContentPlaceHolder1_txtFurnitureNoYears").value = age;}
       
 } 
    function getDepValRateFIXTURES(Integer) {
         //Depreciated Rate
         var year =  document.getElementById('ctl00_ContentPlaceHolder1_txtFurnitureNoYears').value;
         var UL =  document.getElementById('ctl00_ContentPlaceHolder1_txtFurnitureUsefulLife').value;

         var depval = ((year / UL) * 100)
         
         if (depval > 100) {
             depval = 100
         }

         document.getElementById("ctl00_ContentPlaceHolder1_txtFurnitureDeprate").value = depval;
         //End Depreciated Rate


        //Depreciation
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtFurnitureAcqCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var Salvagevalue = document.getElementById('ctl00_ContentPlaceHolder1_txtFurnitureSalvageValue').value;
        Salvagevalue = Salvagevalue.replace(/\,/g, '');
        Salvagevalue = parseInt(Salvagevalue, 10);

        var Depreciation = 0.00;
        if (AcquisationCostVal > 0 && Salvagevalue > 0 && UL > 0) {
            Depreciation = (AcquisationCostVal - Salvagevalue) / UL
        }

         document.getElementById("ctl00_ContentPlaceHolder1_txtFurnitureDepValue").value = (Depreciation).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

        //End Depreciation

        //Depreciated
        var DepreciatedtVal = document.getElementById("ctl00_ContentPlaceHolder1_txtFurnitureDepValue").value;
        DepreciatedtVal = DepreciatedtVal.replace(/\,/g, '');
        DepreciatedtVal = parseInt(DepreciatedtVal, 10);
        var DepreciatedValue = 0.00;
         if (DepreciatedtVal > 0) {
             DepreciatedValue = AcquisationCostVal - (DepreciatedtVal * year);
         }
        
        document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciatedValueFurnitureNew").value = (DepreciatedValue).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        //End Depreciated

    }
    function getSalValFIXTURES(Double) {
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtFurnitureAcqCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var SalvageVal = AcquisationCostVal * 0.05

        document.getElementById("ctl00_ContentPlaceHolder1_txtFurnitureSalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }
     //End FIXTURES INFORMATION



      // OfficeEquipment
    function NoOfYearsOfficeEquipment(dateString) {
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
            document.getElementById("ctl00_ContentPlaceHolder1_txtOfficeEquipmentNoYears").value = age;}
       
 } 
    function getDepValRateOfficeEquipment(Integer) {
         //Depreciated Rate
         var year =  document.getElementById('ctl00_ContentPlaceHolder1_txtOfficeEquipmentNoYears').value;
         var UL =  document.getElementById('ctl00_ContentPlaceHolder1_txtOfficeEquipmentUsefulLife').value;

         var depval = ((year / UL) * 100)
         
         if (depval > 100) {
             depval = 100
         }

         document.getElementById("ctl00_ContentPlaceHolder1_txtOfficeEquipmentDepRate").value = depval;
         //End Depreciated Rate


        //Depreciation
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtOfficeEquipmentAcqCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var Salvagevalue = document.getElementById('ctl00_ContentPlaceHolder1_txtOfficeEquipmentSalvageValue').value;
        Salvagevalue = Salvagevalue.replace(/\,/g, '');
        Salvagevalue = parseInt(Salvagevalue, 10);

        var Depreciation = 0.00;
        if (AcquisationCostVal > 0 && Salvagevalue > 0 && UL > 0) {
            Depreciation = (AcquisationCostVal - Salvagevalue) / UL
        }

         document.getElementById("ctl00_ContentPlaceHolder1_txtOfficeEquipmentDepValue").value = (Depreciation).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

        //End Depreciation

        //Depreciated
        var DepreciatedtVal = document.getElementById("ctl00_ContentPlaceHolder1_txtOfficeEquipmentDepValue").value;
        DepreciatedtVal = DepreciatedtVal.replace(/\,/g, '');
        DepreciatedtVal = parseInt(DepreciatedtVal, 10);
        var DepreciatedValue = 0.00;
         if (DepreciatedtVal > 0) {
             DepreciatedValue = AcquisationCostVal - (DepreciatedtVal * year);
         }
        
        document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciatedValueOfficeEquipmentNew").value = (DepreciatedValue).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        //End Depreciated

    }
    function getSalValOfficeEquipment(Double) {
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtOfficeEquipmentAcqCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var SalvageVal = AcquisationCostVal * 0.05

        document.getElementById("ctl00_ContentPlaceHolder1_txtOfficeEquipmentSalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }
     //End office equipment


       // Equipment
    function NoOfYearsEquipment(dateString) {
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
            document.getElementById("ctl00_ContentPlaceHolder1_txtDefaultEquipmentNoYears").value = age;}
       
 } 
   
     //Refactor
          function getDepValRateEquipment() {
          var year = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtDefaultEquipmentNoYears').value);
          var UL = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtDefaultEquipmentUsefulLife').value);

          var depval = Math.min(100, (year / UL) * 100);

          document.getElementById("ctl00_ContentPlaceHolder1_txtDefaultEquipmentDepRate").value = depval.toFixed(2);

          var acquisitionCost = parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_txtDefaultEquipmentAcquisitionCost").value.replace(/\,/g, ''));
          var salvageValue = parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_txtDefaultEquipmentSalvageValue').value.replace(/\,/g, ''));
          var depreciation = 0.00;
  
          if (acquisitionCost > 0 && salvageValue > 0 && UL > 0) {
            depreciation = (acquisitionCost - salvageValue) / UL;
          }

          document.getElementById("ctl00_ContentPlaceHolder1_txtDefaultEquipmentDepValue").value = depreciation.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

          var depreciatedValue = 0.00;
          if (depreciation > 0) {
            depreciatedValue = acquisitionCost - (depreciation * year);
          }

          document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciatedValueEquipmentNew").value = depreciatedValue.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        }
    
    function getSalValEquipment(Double) {
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtDefaultEquipmentAcquisitionCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var SalvageVal = AcquisationCostVal * 0.05

        document.getElementById("ctl00_ContentPlaceHolder1_txtDefaultEquipmentSalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }
     //End equipment

     // Intangible


    function NoOfYearsIntangible(dateString) {
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
            document.getElementById("ctl00_ContentPlaceHolder1_txtIntanNoofYears").value = age;}
       
 } 
   
     function getDepValIntangible() {
          const year = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtIntanNoofYears').value);
          const UL = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtIntanUsefullife').value);
          const depval = Math.min((year / UL) * 100, 100);

          document.getElementById("ctl00_ContentPlaceHolder1_txtIntanDepreciatedRate").value = depval.toFixed(2);

          const AcquisationCostVal = parseInt(document.getElementById("ctl00_ContentPlaceHolder1_txtIntanAcquisitionCost").value.replace(/\,/g, ''));
          const Salvagevalue = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtIntanSalvageValue').value.replace(/\,/g, ''));
          const Depreciation = (AcquisationCostVal > 0 && Salvagevalue > 0 && UL > 0) ? (AcquisationCostVal - Salvagevalue) / UL : 0;

          document.getElementById("ctl00_ContentPlaceHolder1_txtIntanDepreciationValue").value = Depreciation.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

          const DepreciatedtVal = parseInt(document.getElementById("ctl00_ContentPlaceHolder1_txtIntanDepreciationValue").value.replace(/\,/g, ''));
          const DepreciatedValue = (DepreciatedtVal > 0) ? AcquisationCostVal - (DepreciatedtVal * year) : 0;

          document.getElementById("ctl00_ContentPlaceHolder1_txtIntanDepreciatedValue").value = DepreciatedValue.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        }
    function getSalValIntangible(Double) {
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtIntanAcquisitionCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var SalvageVal = AcquisationCostVal * 0.05

        document.getElementById("ctl00_ContentPlaceHolder1_txtIntanSalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }



     //end Intangible

 </script> 

     
    
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ListView ID="ListView1" runat="server"></asp:ListView>
            <table style="width: 100%">
                <tbody>
                    <tr>
                        <td style="width: 1010px" class="PageTitle">PROPERTY CARD

                        </td>
                    </tr>
                    <tr>
                        <td style="width:1010px;">
                            <table style="width:100%; border-collapse:collapse; table-layout:fixed;">

                                <colgroup>
                                    <col style="width:18%;" /> <!-- col 1 -->
                                    <col style="width:18%;" /> <!-- col 2 -->
                                    <col style="width:10%;" /> <!-- col 3 -->
                                    <col style="width:18%;" /> <!-- col 4 -->
                                    <col style="width:18%;" /> <!-- col 5 -->
                                    <col style="width:8%;"  /> <!-- col 6 -->
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

                                    <!-- Column 4: General Account label -->
                                    <td style="padding:5px; text-align:right; vertical-align:middle;">
                                        <span style="font-size:10pt; font-family:Arial;">
                                            <strong>General Account :</strong>
                                        </span>
                                    </td>

                                    <!-- Column 5: General Account dropdown -->
                                    <td style="padding:5px; text-align:center; vertical-align:middle;">
                                        <asp:DropDownList ID="ddGlAccount" runat="server"
                                            Width="100%" CssClass="txtboxinspection"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>

                                    <!-- Column 6: empty -->
                                    <td style="padding:5px;"></td>
                                </tr>

                                <!-- ROW 2 -->
                                <tr>
                                    <!-- Column 1: Sub Classification label -->
                                    <td style="padding:5px; text-align:right; vertical-align:middle;">
                                        <span style="font-size:10pt; font-family:Arial;">
                                            <strong>Sub Classification :</strong>
                                        </span>
                                    </td>

                                    <!-- Column 2: Sub Classification dropdown -->
                                    <td style="padding:5px; text-align:center; vertical-align:middle;">
                                        <asp:DropDownList ID="drpSubClassification" runat="server"
                                            Width="100%" CssClass="txtboxinspection">
                                        </asp:DropDownList>
                                    </td>

                                    <!-- Column 3: empty -->
                                    <td style="padding:5px;"></td>

                                    <!-- Column 4: Description label -->
                                    <td style="padding:5px; text-align:right; vertical-align:middle;">
                                        <span style="font-size:10pt; font-family:Arial;">
                                            <strong>Description :</strong>
                                        </span>
                                    </td>

                                    <!-- Column 5: Description textbox -->
                                    <td style="padding:5px; text-align:center; vertical-align:middle;">
                                        <asp:TextBox ID="txtAccountSearch" runat="server"
                                            Width="100%" CssClass="txtboxinspection">
                                        </asp:TextBox>
                                    </td>

                                    <!-- Column 6: Search button -->
                                    <td style="padding:5px; text-align:center; vertical-align:middle;">
                                        <asp:Button ID="ItemSearch" runat="server"
                                            Text="Search" CssClass="CSButton" SkinID="ButtonImage" Width="80%"
                                            OnClick="ItemSearch_Click" />
                                    </td>
                                </tr>

                            </table>
                        </td>
                    </tr>


                    <tr>
                        <td style="width: 1010px"></td>
                    </tr>
                    <tr>
                    <td style="width: 1010px">
                    <asp:MultiView ID="mwProperty" runat="server">
                                <asp:View ID="vwgridviewsearch" runat="server">
                                  

                                    <asp:HiddenField ID="hdnItemNo" runat="server" />
                                    <span style="color: rgb(0, 0, 0); font-family: Arial; font-size: 13.3333px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;"></span>
                                    <asp:GridView ID="gvsearch" runat="server" Width="1000px" OnPageIndexChanging="gvsearch_PageIndexChanging" SkinID="GridViewAA" DataKeyNames="Received_ID,Property_ID,Item_ID" HorizontalAlign="Center" 
                                        AllowPaging="True"  Font-Size="9pt" PageSize="5">
                                        <Columns>
                                            <asp:BoundField DataField="PropertyNo" HeaderText="Property No.">
                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OwnerName" HeaderText="Previous Owner">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="FullAddress" HeaderText="Address">
                                                <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Barangay1" HeaderText="Barangay">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Area1" HeaderText="Area">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Property_Date" DataFormatString="{0:d}" HeaderText="Acquisition Date">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AcquisitionCost" DataFormatString="{0:N}" HeaderText="Acquisition Cost">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MarketValue"  DataFormatString="{0:N}" HeaderText="Market Value">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Right" Width="12%"></ItemStyle>
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:View>
                                <asp:View ID="vwGridviewwithproperty" runat="server">
                                    <asp:MultiView ID="mvGridviewwithproperty" runat="server">
                                        <asp:View ID="vwGridviewwithproperty_onBuilding" runat="server">
                                            <table width="100%">
                                                <tr>
                                                    <td class="DivTitle" style="width: 100%">LIST OF LOCATION
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gvsearchproperty" runat="server" Width="1000px" SkinID="GridViewAA" HorizontalAlign="Center" DataKeyNames="item_particular_id,Item_ID,DeclaredOwner,Barangay" AllowPaging="True" 
                                                         OnPageIndexChanging="gvsearchproperty_PageIndexChanging" OnSelectedIndexChanged="gvsearchproperty_SelectedIndexChanged" OnRowDataBound="gvsearchproperty_RowDataBound" Font-Size="9pt">
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
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vwGridviewwithproperty_Without_Building" runat="server">
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gvsearchproperty_without_Building" runat="server" Width="1000px" SkinID="GridViewAA" HorizontalAlign="Center" DataKeyNames="item_particular_id,Item_ID,Property_Code" AllowPaging="True" 
                                                            OnPageIndexChanging="gvsearchproperty_without_Building_PageIndexChanging" 
                                                            OnSelectedIndexChanged="gvsearchproperty_without_Building_SelectedIndexChanged" 
                                                            OnRowDataBound="gvsearchproperty_without_Building_RowDataBound" Font-Size="9pt" PageSize="5">
                                                            <Columns>
                                                                <asp:BoundField DataField="Property_code" HeaderText="CODE" Visible="False"></asp:BoundField>
                                                                <asp:BoundField DataField="Property_code" HeaderText="Property No.">
                                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ItemDescription" HeaderText="Item Description">
                                                                    <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="VehicleType" HeaderText="Type">
                                                                    <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="VehicleMake" DataFormatString="{0:N}" HeaderText="Make">
                                                                    <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Warranty" DataFormatString="{0:N}" HeaderText="Warranty">
                                                                    <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                                                                </asp:BoundField>

                                                                <%--<asp:BoundField DataField="ItemCount" HeaderText="Current Balance">
                                                                    <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                                                                </asp:BoundField>--%>
                                                                <asp:BoundField DataField="AcqDate" HeaderText="Acquisition Date">
                                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="AcqCost" HeaderText="Acquisition Cost">
                                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="MarketValue" DataFormatString="{0:N}" HeaderText="Market Value">
                                                                    <ItemStyle HorizontalAlign="Center" Width="14%"></ItemStyle>
                                                                </asp:BoundField>

                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vwGridviewwithproperty_Books" runat="server">
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gvsearchproperty_Books" runat="server" Width="1000px" SkinID="GridViewAA" HorizontalAlign="Center" DataKeyNames="Item_ID,Property_Code" AllowPaging="True"
                                                            OnPageIndexChanging="gvsearchproperty_Books_PageIndexChanging"
                                                            OnSelectedIndexChanged="gvsearchproperty_Books_SelectedIndexChanged"
                                                            OnRowDataBound="gvsearchproperty_Books_RowDataBound"
                                                            Font-Size="9pt">
                                                            <Columns>
                                                                <asp:BoundField DataField="Property_code" HeaderText="CODE" Visible="False"></asp:BoundField>
                                                                <asp:BoundField DataField="Property_code" HeaderText="Property No.">
                                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ItemDescription" HeaderText="Name">
                                                                    <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Title" HeaderText="Title">
                                                                    <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Author" DataFormatString="{0:N}" HeaderText="Author">
                                                                    <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Unit" DataFormatString="{0:N}" HeaderText="Unit">
                                                                    <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                                                                </asp:BoundField>

                                                                <asp:BoundField DataField="ItemCount" HeaderText="Current Balance" Visible="false">
                                                                    <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="AcqDate" HeaderText="Acquisition Date">
                                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="AcqCost" DataFormatString="{0:N}" HeaderText="Acquisition Cost">
                                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="MarketValue" DataFormatString="{0:N}" HeaderText="Market Value">
                                                                    <ItemStyle HorizontalAlign="Center" Width="14%"></ItemStyle>
                                                                </asp:BoundField>

                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vwMilitary" runat="server" >
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gvsearchproperty_Military" runat="server" Width="1000px" SkinID="GridViewAA" HorizontalAlign="Center" DataKeyNames="Item_ID" AllowPaging="True"
                                                            OnPageIndexChanging="gvsearchproperty_Military_PageIndexChanging"
                                                            OnSelectedIndexChanged="gvsearchproperty_Military_SelectedIndexChanged"
                                                            OnRowDataBound="gvsearchproperty_Military_RowDataBound"
                                                            Font-Size="9pt">
                                                            <Columns>
                                                                <asp:BoundField DataField="Property_code" HeaderText="CODE" Visible="False"></asp:BoundField>
                                                                <asp:BoundField DataField="Item_ID" HeaderText="Item Code">
                                                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ItemDescription" HeaderText="Name">
                                                                    <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                                                </asp:BoundField>
                                                                
                                                                <asp:BoundField DataField="ItemCount" DataFormatString="{0:N}" HeaderText="Current Balance">
                                                                    <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Unit" DataFormatString="{0:N}" HeaderText="Unit">
                                                                    <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                                                                </asp:BoundField>

                                                                <asp:BoundField DataField="ItemCount" HeaderText="Current Balance" Visible="false">
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
                                            </table>
                             
                                        </asp:View>
                                       
                                    </asp:MultiView>

                                </asp:View>
                                <asp:View ID="vwgridsearchRoadBridges" runat="server">
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:GridView ID="gvsearchRoadBridges" runat="server" Width="1000px" SkinID="GridViewAA" DataKeyNames="Item_ID" HorizontalAlign="Center" AllowPaging="True" OnPageIndexChanging="gvsearch_PageIndexChanging" OnRowDataBound="gvsearchRoadBridges_RowDataBound" OnSelectedIndexChanged="gvsearchRoadBridges_SelectedIndexChanged" Font-Size="9pt">
                                        <Columns>
                                            <asp:BoundField DataField="Item_Code" HeaderText="Item Code">
                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OwnerName" HeaderText="Project Name">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="FullAddress" HeaderText="Location">
                                                <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Barangay1" HeaderText="Contractor">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Area1" HeaderText="Area" Visible="false">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Property_Date" DataFormatString="{0:d}" HeaderText="Acquisition Date">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AcquisitionCost" DataFormatString="{0:N}" HeaderText="Acquisition Cost">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MarketValue" HeaderText="Market Value">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Right" Width="12%"></ItemStyle>
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:View>
                                <asp:View ID="vwGridViewIntangible" runat="server">
                                            <table width="100%">
                                                
                                                <tr>
                                                    <td class="DivTitle" style="width: 100%">LIST OF INTANGIBLE ASSET
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                         <table>
                                                         <tr>
                                                            <td class="column_RightBold">Sub Classification : </td>
                                                            <td class="column_Left">
                                                                <asp:DropDownList ID="drpIntanSubClassification" runat="server" CssClass="drpdownCSS" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="drpIntanSubClassification_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdPropertyIntangible" runat="server" Width="1000px" SkinID="GridViewAA" HorizontalAlign="Center" OnRowDataBound="grdPropertyIntangible_RowDataBound"
                                                          DataKeyNames="Item_Code,Title,Brand,SerialNo,Noofdisc,Model,LicenceDuration,Property_Date,Cost,DepreciationRate,DepreciatedValue,MarketValue,NoofYears,Usefullife,SalvageValue,WarehouseID,Bay,Column,Floor,Room,Shelves,Rack,Bin,Item_ID,Property_ID,PropertyDetai_ID,IntangibleAssetInfoId,IntangibleAssetID,Ledger_ID">
                                                <Columns>
                                                     <asp:BoundField DataField="SerialNo" HeaderText="Serial No">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                     <asp:BoundField DataField="Title" HeaderText="Title">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                     <asp:BoundField DataField="Brand" HeaderText="Brand" >
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                     <asp:BoundField DataField="SerialNo" HeaderText="Serial No.">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                     <asp:BoundField DataField="Noofdisc" HeaderText="Noofdisc" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                     <asp:BoundField DataField="Model" HeaderText="Model" >
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                     <asp:BoundField DataField="LicenceDuration" HeaderText="LicenceDuration" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                     <asp:BoundField DataField="Property_Date" HeaderText="Acquisition Date" >
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                     <asp:BoundField DataField="Cost" HeaderText="Acquisition Cost" >
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                     <asp:BoundField DataField="DepreciationRate" HeaderText="DepreciationRate" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                     <asp:BoundField DataField="DepreciatedValue" HeaderText="DepreciatedValue" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                     <asp:BoundField DataField="MarketValue" HeaderText="Market Value" >
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                     <asp:BoundField DataField="NoofYears" HeaderText="NoofYears" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                     <asp:BoundField DataField="Usefullife" HeaderText="Usefullife" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                     <asp:BoundField DataField="SalvageValue" HeaderText="SalvageValue" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                      <asp:BoundField DataField="WarehouseID" HeaderText="WarehouseID" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                      <asp:BoundField DataField="Bay" HeaderText="Bay" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                      <asp:BoundField DataField="Column" HeaderText="Column" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                      <asp:BoundField DataField="Floor" HeaderText="Floor" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                      <asp:BoundField DataField="Room" HeaderText="Room" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                      <asp:BoundField DataField="Shelves" HeaderText="Shelves" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                      <asp:BoundField DataField="Rack" HeaderText="Rack" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>

                                                      <asp:BoundField DataField="Bin" HeaderText="Bin" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>
                                                    <asp:BoundField DataField="Item_ID" HeaderText="Item_ID" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>
                                                    <asp:BoundField DataField="Property_ID" HeaderText="Property_ID" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>
                                                    <asp:BoundField DataField="PropertyDetai_ID" HeaderText="PropertyDetai_ID" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>
                                                    <asp:BoundField DataField="IntangibleAssetInfoId" HeaderText="IntangibleAssetInfoId" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>
                                                    <asp:BoundField DataField="IntangibleAssetID" HeaderText="IntangibleAssetID" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>
                                                    <asp:BoundField DataField="Ledger_ID" HeaderText="Ledger_ID" Visible="False">
                                                          <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                     </asp:BoundField>
                                                 
                                                </Columns>
                                             </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                             

                                         </asp:View>
                    </asp:MultiView>
                    </td>
                    </tr>




                    <tr>
                        <td style="width: 1010px">
                            <asp:Button ID="btnViewPIR" runat="server" Width="240px" CssClass="CSButton" Text="View Perpetual Inventory Report" OnClick="btnViewPIR_Click" OnClientClick="window.open('rpt_view_propertycard_v4.aspx')"></asp:Button>
                            <br />


                            <asp:MultiView ID="mvPropertyDetailed" runat="server">
                                <asp:View ID="vwLandInfo" runat="server">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 100%" class="DivTitle">LAND INFORMATION

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="right" style="width: 55%">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td class="column_RightBold" style="width: 30%">Address : </td>
                                                                        <td class="column_Left" style="width: 40%">
                                                                            <asp:TextBox ID="txtLocation" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="99%" ></asp:TextBox>
                                                                        </td>
                                                                        <td class="column_RightBold" style="width: 10%">Brgy : </td>
                                                                        <td class="column_Left" style="width: 20%">
                                                                            <asp:DropDownList ID="ddBrgy1" runat="server" CssClass="txtbox_Var" Width="100px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold">Area : </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtArea1" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="75%" ></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold">Tax Dec. No. : </td>
                                                                        <td class="column_Left">
                                                                        <asp:DropDownList ID="ddTaxDecNo" runat="server" CssClass="txtbox_Var" Width="75%">
                                                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                                            <asp:ListItem Value="1">Property Holding (All Property Holdings)</asp:ListItem>
                                                                            <asp:ListItem Value="2">Property Holding (No Land Holding)</asp:ListItem>
                                                                            <asp:ListItem Value="3">Non-Property Holding</asp:ListItem>
                                                                            <asp:ListItem Value="4">Ownership (No Improvements)</asp:ListItem>
                                                                            <asp:ListItem Value="5">Ownership (Improvements Made)</asp:ListItem>
                                                                            <asp:ListItem Value="6">Ownership (One lot)</asp:ListItem>
                                                                            <asp:ListItem Value="7">Ownership (Tax Exempt)</asp:ListItem>
                                                                            <asp:ListItem Value="8">Ownership (With Improvements)</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold">Previous Owner : </td>
                                                                        <td class="column_Left" colspan=" 3">
                                                                            <asp:TextBox ID="txtPrevOwner" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="95%" ></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td align="left" style="width: 50%">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td class="column_RightBold" style="width: 25%">Acquisition Date : </td>
                                                                        <td class="column_Left" style="width: 70%">
                                                                            <asp:TextBox ID="txtEAcqDate" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="50%"></asp:TextBox>
                                                                         <%--   <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtEAcqDate" TargetControlID="txtEAcqDate">
                                                                            </cc1:CalendarExtender>--%>
                                                                             <cc1:CalendarExtender ID="CalendarExtender14" runat="server" TargetControlID="txtEAcqDate" PopupButtonID="txtEAcqDate"></cc1:CalendarExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold">Acquisition Cost : </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtAcqCost" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="50%" ></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold">Acquisition Mode : </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtAcqMode" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="50%" ></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold">Market Value : </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtMarketValue" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="50%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%">
                                                    <table style="width: 100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 800px; border: 2px solid #5c85d6">
                                                                    <table style="font-weight: normal; font-size: 9pt; width: 100%; font-family: Arial">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align="center" colspan="8" class="DivTitle">PROPERTY IDENTIFICATION
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text5" style="width: 112px" >LGU Code :&nbsp; 
                                                                <asp:Label ID="lblLguCode" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                <td><asp:TextBox ID="txtLguCode" runat="server" CssClass="txtbox_Var" Width="90px"></asp:TextBox></td>
                                                                                <td class="text5" style="width: 105px">District Code: 
                                                                <asp:Label ID="lblDistrictCode" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                <td><asp:TextBox ID="txtDistrictCode" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></asp:TextBox></td>


                                                                                <td class="text5" style="width: 116px">City/Mun. Code: 
                                                                <asp:Label ID="lblMunicipalCode" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                                <td> <asp:TextBox ID="txtMunicipalCode" runat="server" CssClass="txtbox_Var" Width="90px"></asp:TextBox></td>
                                                                                <td class="text5" style="width: 101px">Brgy. Code:
                                                                <asp:Label ID="lblBrgyCode" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                <td><asp:TextBox ID="txtBrgyCode" runat="server" CssClass="txtbox_Var" Width="90px"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text5" style="width: 95px" >Section No.: 
                                                                <asp:Label ID="lblSectionNo" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                <td><asp:TextBox ID="txtSectionNo" runat="server" CssClass="txtbox_Var" Width="90px"></asp:TextBox></td>

                                                                                <td class="text5" style="width: 105px">Parcel No.: 
                                                                <asp:Label ID="lblParcelNo" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                <td><asp:TextBox ID="txtParcelNo" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></td>
                                                                                <td class="text5" >Series No.: 
                                                                <asp:Label ID="lblSeriesNo" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                 <td><asp:TextBox ID="txtSeriesNo" runat="server" CssClass="txtbox_Var" Width="90px"></asp:TextBox></td>
                                                                                <td class="text5">RPTIN: 
                                                                <asp:Label ID="lblRptin" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                <td><asp:TextBox ID="txtRptin" runat="server" CssClass="txtbox_Var" Width="90px"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text5" style="width: 95px" >PIN:
                                                                <asp:Label ID="lblPin" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                              <td><asp:TextBox ID="txtPin" runat="server" CssClass="txtbox_Var" Width="90px"></asp:TextBox></td>
                                                                                <td class="text5" style="width: 105px">ARP: 
                                                                <asp:Label ID="lblArp" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                <td><asp:TextBox ID="txtArp" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></td>
                                                                                <td class="text5">TDN:
                                                                <asp:Label ID="lblTdn" runat="server" CssClass="text5" BorderStyle="None"> </asp:Label>
                                                               </td>
                                                                <td> <asp:TextBox ID="txtTdn" runat="server" CssClass="txtbox_Var" Width="90px"></asp:TextBox></td>
                                                                                <td class="text5">Rev Year: 
                                                                <asp:Label ID="lblRevYear" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                <td><asp:TextBox ID="txtRevYear" runat="server" CssClass="txtbox_Var" Width="90px"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr style="display: none;">
                                                                                <td class="text5" style="width: 95px">Depreciation Rate: 
                                                                <asp:Label ID="lblDepRate" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                               <td><asp:TextBox ID="txtDepRate" runat="server" CssClass="txtbox_Var" Width="90px"></asp:TextBox></td>

                                                                                <td class="text5" style="width: 105px">Depreciated Value:
                                                            <asp:Label ID="lblDepValue" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                                <td class="text5"></td>
                                                                                <td class="text5" style="width: 9px"></td>
                                                                                <td class="text5"></td>
                                                                                <td class="text5"></td>
                                                                                <td class="text5"></td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                                <td style="width: 220px; border: 2px solid #5c85d6" rowspan="2">

                                                                    <table style="width: 100%">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 150px" valign="top">
                                                                                    <asp:Image ID="LandImage" runat="server" Width="150px" ImageUrl="~/images/blankImage.jpg" Height="140px" ImageAlign="Middle"></asp:Image>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="display: none;">
                                                                                <td style="width: 40%" class="text5">Date:</td>
                                                                                <td style="width: 60%" class="text5">
                                                                                    <asp:Label ID="lblLandDateTaken" runat="server" CssClass="txtboxinspection"></asp:Label></td>
                                                                            </tr>
                                                                            <tr style="display: none;">
                                                                                <td style="width: 40%" class="text5">By:</td>
                                                                                <td style="width: 60%" class="text5">
                                                                                    <asp:Label ID="lblLandUploadedBy" runat="server" CssClass="txtboxinspection"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="display: none;">
                                                                                <td style="width: 40%" class="text5">Position:</td>
                                                                                <td style="width: 60%" class="text5">
                                                                                    <asp:Label ID="lblLandPosition" runat="server" CssClass="txtboxinspection"></asp:Label></td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>

                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td style="width: 800px; border: 2px solid #5c85d6">

                                                                    <table style="width: 100%">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align="center" colspan="8" class="DivTitle" style="width: 100%">LOCATION</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text5">Street: 
                                                                <asp:Label ID="lblStreetName" runat="server" CssClass="text5"></asp:Label>
                                                                                </td>
                                                                <td><asp:TextBox ID="txtStreetName" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></td>
                                                                                <td class="text5">Purok:
                                                                <asp:Label ID="lblPurok" runat="server" CssClass="text5"></asp:Label>
                                                                                </td>
                                                                <td><asp:TextBox ID="txtPurok" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></td>
                                                                                <td class="text5">Lot No.: 
                                                                <asp:Label ID="lblLotNo" runat="server" CssClass="text5" SkinID="LabelBorder"></asp:Label>
                                                                                </td>
                                                                <td><asp:TextBox ID="txtLotNo" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></td>
                                                                                <td class="text5">Phase No.: 
                                                                <asp:Label ID="lblPhaseNo" runat="server" CssClass="text5"></asp:Label>
                                                                                </td>
                                                                <td><asp:TextBox ID="txtPhaseNo" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text5">Blk No.:
                                                                <asp:Label ID="lblBlkNo" runat="server" CssClass="text3" SkinID="LabelBorder"></asp:Label>
                                                                                </td>
                                                                <td><asp:TextBox ID="txtBlkNo" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></td>

                                                                                <td class="text5">Subdivision:
                                                                <asp:Label ID="lblSubdivision" runat="server" CssClass="text5"></asp:Label>
                                                                                </td>
                                                                <td> <asp:TextBox ID="txtSubdivision" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></td>
                                                                <td class="text5">Sitio:
                                                                    <asp:Label ID="lblSitio" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                                                <td><asp:TextBox ID="txtSitio" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></td>
                                                                                <td class="text5"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text5">City/Mun.:
                                                                      <asp:Label ID="lblMunicipal" runat="server" CssClass="text5"></asp:Label>
                                                                                </td>
                                                                      <td><asp:TextBox ID="txtMunicipal" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></td>
                                                                                <td class="text5">Brgy.:
                                                                      <asp:Label ID="lblBrgy" runat="server" CssClass="text5"></asp:Label>
                                                                                </td>
                                                                      <td><asp:TextBox ID="txtBrgy" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></td>
                                                                                <td class="text5">Region:
                                                                      <asp:Label ID="lblRegion" runat="server" CssClass="text5"></asp:Label>
                                                                                </td>
                                                                      <td><asp:TextBox ID="txtRegion" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></td>
                                                                                <td class="text5"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text5">District:
                                                                                    <asp:Label ID="lblDistrict" runat="server" CssClass="text5"></asp:Label>
                                                                                </td>
                                                                                <td><asp:TextBox ID="txtDistrict" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></td>
                                                                                <td class="text5">Province:
                                                                                    <asp:Label ID="lblProvince" runat="server" CssClass="text5"></asp:Label>
                                                                                </td>
                                                                                <td><asp:TextBox ID="txtProvince" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></td>
                                                                                <td class="text5">Zip Code:
                                                                                    <asp:Label ID="lblZipCode" runat="server" CssClass="text5"></asp:Label>
                                                                                </td>
                                                                                <td><asp:TextBox ID="txtZipCode" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></td>
                                                                                <td class="text5"></td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>

                                                                </td>

                                                            </tr>

                                                        </tbody>

                                                    </table>

                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="width: 100%; border: 2px solid #5c85d6">
                                                    <table style="width: 100%">
                                                        <tbody>
                                                            <tr>
                                                                <td align="center" colspan="8" class="DivTitle" style="width: 100%">CHARACTERISTICS</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text5">Classification:
                                                <asp:Label ID="lblClassification" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                                <td><asp:TextBox ID="txtClassification" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox></td>
                                                                <td class="text5">Sub Class: 
                                                <asp:Label ID="lblSubClass" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                                <td><asp:TextBox ID="txtSubClass" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox></td>
                                                                <td class="text5">Land Use: 
                                                <asp:Label ID="lblLandUse" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                                <td><asp:TextBox ID="txtLandUse" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox></td>
                                                                <td class="text5" style="display: none">Status: 
                                                <asp:Label ID="lblStatus1" runat="server" CssClass="text5"></asp:Label>
                                                <asp:TextBox ID="txtStatus1" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text5">Taxable:
                                                <asp:Label ID="lblTaxable" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                                <td><asp:TextBox ID="txtTaxable" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox></td>
                                                                <td class="text5">Area: 
                                                <asp:Label ID="lblArea" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                                <td><asp:TextBox ID="txtArea" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox></td>
                                                                <td class="text5"></td>
                                                                <td class="text5" style="display: none">Status: 
                                                <asp:Label ID="lblStatus2" runat="server" CssClass="text5"></asp:Label>
                                                <asp:TextBox ID="txtStatus2" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">&nbsp; 
                                                                    <asp:Label ID="lblIntLandId" runat="server" Text="Label" CssClass="text5" Visible="false"></asp:Label>
                                                                     <asp:Label ID="lblIntProperty_Dtl_ID" runat="server" Text="Label" CssClass="text5" Visible="false"></asp:Label>
                                                                     <asp:Label ID="lblIntProperty_ID" runat="server" Text="Label" CssClass="text5" Visible="false"></asp:Label>
                                                                     <asp:Label ID="lblIntM_Item_ID" runat="server" Text="Label" CssClass="text5" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text5">Assessed Value: 
                                            <asp:Label ID="lblAssessedValue" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                            <td><asp:TextBox ID="txtAssessedValue" runat="server" CssClass="txtbox_Var" Width="150px" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox></td>
                                                                <td class="text5">Market Value: 
                                            <asp:Label ID="lblMarketValue" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                            <td> <asp:TextBox ID="txtMarketValue1" runat="server" CssClass="txtbox_Var" Width="150px" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox></td>
                                                                <td class="text5">Unit Value: 
                                            <asp:Label ID="lblUnitValue" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                            <td><asp:TextBox ID="txtUnitValue" runat="server" CssClass="txtbox_Var" Width="150px" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox></td>

                                                            </tr>
                                                            <tr>
                                                                <td class="text5">Date: 
                                           <asp:Label ID="lblAVDate" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                            <td> <asp:TextBox ID="txtAVDate" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox></td>
                                                                <td class="text5">Date: 
                                           <asp:Label ID="lblMVDate" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                           <td><asp:TextBox ID="txtMVDate" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox></td>
                                                                <td class="text5">Date: 
                                           <asp:Label ID="lblUVDate" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                           <td><asp:TextBox ID="txtUVDate" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox></td>
                                                                <tr>
                                                                    <td class="text5" style="display:none;">Amount : 
                                          <asp:Label ID="lblAVAmount" runat="server" CssClass="text5"></asp:Label>
                                                                    </td>
                                        <td style="display:none"><asp:TextBox ID="txtAVAmount" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox></td>
                                                                    <td class="text5" style="display:none;">Amount :
                                          <asp:Label ID="lblMVAmount" runat="server" CssClass="text5"></asp:Label>
                                                                    </td>
                                        <td style="display:none;"><asp:TextBox ID="txtMVAmount" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox></td>
                                                                    <td class="text5" style="display:none;">Assessment : 
                                          <asp:DropDownList ID="ddAssessmentLvl" runat="server" Width="50%" CssClass="text5"></asp:DropDownList>
                                                                    </td>
                                        <td>&nbsp;</td>
                                                                </tr>
                                                            </tr>

                                                        </tbody>

                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 100%" class="column_Right">
                                                    <asp:Label ID="lblClassForTrap" runat="server" Text="Label" Visible="False"></asp:Label>
                                                    <asp:Button ID="btnLandEdit" runat="server" Width="150px"  Text="Edit" Height="25px" Enabled="False" OnClientClick="StartProgressBar();" OnClick="btnLandSave_Click"  CssClass="CSButton" Visible="false"></asp:Button>
                                                    <asp:Button ID="Button12" runat="server" Text="Edit" CssClass="CSButton"  Width="150px" />

                                                    <%--&nbsp
                                                    <asp:Button ID="btnSaveLand" runat="server" Width="150px"  Text="SAVE" Height="25px" Enabled="False"></asp:Button>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%">
                                                    <br />
                                                    <table style="display: none;">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 3px">
                                                                    <asp:Button ID="btnLandDocument" runat="server" Width="105px" CssClass="Initial" Text="Land Document"></asp:Button></td>
                                                                <td>
                                                                    <asp:Button ID="btntechnicaldescription" runat="server" Width="142px" CssClass="Initial" Text="Technical Description"></asp:Button></td>
                                                                <td>
                                                                    <asp:Button ID="btnlandvalue" runat="server" Width="101px" CssClass="Initial" Text="Land Valuation"></asp:Button></td>
                                                                <td>
                                                                    <asp:Button ID="btnHistory" runat="server" Width="137px" CssClass="Initial" Text="History Of Ownership"></asp:Button></td>
                                                                <td>
                                                                    <asp:Button ID="btnimprovements" runat="server" Width="105px" CssClass="Initial" Text="Improvements"></asp:Button></td>
                                                                <td>
                                                                    <asp:Button ID="bntapproval" runat="server" Width="131px" CssClass="Initial" Text="Approval Information"></asp:Button></td>
                                                                <td>
                                                                    <asp:Button ID="btnmemoranda" runat="server" Width="84px" CssClass="Initial" Text="Memoranda"></asp:Button></td>
                                                                <td>
                                                                    <asp:Button ID="bntDocumentAttach" runat="server" Width="143px" CssClass="Initial" Text="Document Attachment"></asp:Button></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <asp:MultiView ID="mvLand" runat="server" Visible="false">
                                                        <asp:View ID="vwTechnicalTechnicaldescription" runat="server">
                                                            <table style="width: 100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 400px">
                                                                            <table style="width: 100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="width: 50%" class="text5">TCT No.:<asp:Label ID="lblTctNo" runat="server" CssClass="text5"></asp:Label></td>
                                                                                        <td style="width: 50%" class="text5">East:<asp:Label ID="lblEast" runat="server" Width="70px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 50%" class="text5">OCT No.:<asp:Label ID="lblOctNo" runat="server" CssClass="text5"></asp:Label></td>
                                                                                        <td style="width: 50%" class="text5">North:<asp:Label ID="lblNorth" runat="server" Width="70px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 50%" class="text5">Date :<asp:Label ID="lblTechDate" runat="server" CssClass="text5"></asp:Label></td>
                                                                                        <td style="width: 50%" class="text5">South:<asp:Label ID="lblSouth" runat="server" Width="70px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 50%" class="text5">Reg. Date:<asp:Label ID="lblDateReg" runat="server" CssClass="text5"></asp:Label></td>
                                                                                        <td style="width: 50%" class="text5">West:<asp:Label ID="lblWest" runat="server" Width="70px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="text5" colspan="2">Cadastral No.:<asp:Label ID="lblCadastralNo" runat="server" CssClass="text5"></asp:Label></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td style="width: 400px">
                                                                            <table>
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="font-weight: bold; font-size: 10pt; width: 35%; color: white; font-family: Arial; background-color: royalblue" align="center">LINE</td>
                                                                                        <td style="font-weight: bold; font-size: 10pt; width: 35%; color: white; font-family: Arial; background-color: royalblue" align="center">BEARING</td>
                                                                                        <td style="font-weight: bold; font-size: 10pt; width: 35%; color: white; font-family: Arial; background-color: royalblue" align="center">DISTANCE</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="3">
                                                                                            <asp:GridView ID="gvTechinicaldescription" runat="server" Width="350px" SkinID="gvnew" Font-Size="9pt">
                                                                                                <Columns>
                                                                                                    <asp:BoundField DataField="StartingPt" HeaderText="Starting PT">
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

                                                                                                        <ItemStyle Width="50px"></ItemStyle>
                                                                                                    </asp:BoundField>
                                                                                                    <asp:BoundField DataField="endingpt" HeaderText="Ending PT">
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

                                                                                                        <ItemStyle Width="50px"></ItemStyle>
                                                                                                    </asp:BoundField>
                                                                                                    <asp:BoundField DataField="ns" HeaderText="N/S">
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>

                                                                                                        <ItemStyle Width="30px"></ItemStyle>
                                                                                                    </asp:BoundField>
                                                                                                    <asp:BoundField DataField="ns1">
                                                                                                        <HeaderStyle Width="30px"></HeaderStyle>

                                                                                                        <ItemStyle Width="30px"></ItemStyle>
                                                                                                    </asp:BoundField>
                                                                                                    <asp:BoundField DataField="ns2">
                                                                                                        <HeaderStyle Width="30px"></HeaderStyle>

                                                                                                        <ItemStyle Width="30px"></ItemStyle>
                                                                                                    </asp:BoundField>
                                                                                                    <asp:BoundField DataField="we" HeaderText="W/E">
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

                                                                                                        <ItemStyle Width="50px"></ItemStyle>
                                                                                                    </asp:BoundField>
                                                                                                    <asp:BoundField DataField="mDistance" HeaderText="m">
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="110px"></HeaderStyle>

                                                                                                        <ItemStyle Width="110px"></ItemStyle>
                                                                                                    </asp:BoundField>
                                                                                                </Columns>
                                                                                            </asp:GridView>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>

                                                                        </td>
                                                                        <td style="width: 200px">
                                                                            <img src="../images/TechDesciption.jpg" width="190" />

                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="vwLandDocument" runat="server">
                                                            <table style="height: 236px" width="1000">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="vertical-align: top; width: 750px; height: 230px" align="center">
                                                                            <fieldset style="width: 700px; height: 220px" class="PanelBorder">
                                                                                <br />
                                                                                <br />
                                                                                <asp:GridView ID="grdlandDocument" runat="server" Width="650px" SkinID="gvnew" DataKeyNames="DocuId" PageSize="5" Font-Size="9pt">
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="agency" HeaderText="Agency"></asp:BoundField>
                                                                                        <asp:BoundField DataField="documentname" HeaderText="Document Name"></asp:BoundField>
                                                                                        <asp:BoundField DataField="documentno" HeaderText="Document No."></asp:BoundField>
                                                                                        <asp:BoundField DataField="validatedby" HeaderText="Validated By"></asp:BoundField>
                                                                                        <asp:BoundField DataField="datevalidated" HeaderText="Date Validated"></asp:BoundField>
                                                                                        <asp:BoundField DataField="remarks" HeaderText="Remarks"></asp:BoundField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </fieldset>
                                                                        </td>
                                                                        <td style="vertical-align: top; width: 250px; height: 230px" id="Td5" align="center">
                                                                            <fieldset style="width: 245px; height: 220px" class="PanelBorder">
                                                                                <legend><span style="font-size: 11pt; font-family: Calibri"><strong>Documents</strong></span></legend>
                                                                                <asp:Image ID="imgeLandocuments" runat="server" Width="220px" ImageUrl="~/images/DefaulScannedDocuments.jpg" Height="200px"></asp:Image>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="vwHistoryofOwnership" runat="server">
                                                            <table style="width: 1000px">
                                                                <tbody>
                                                                    <tr>
                                                                        <td align="center" colspan="2">
                                                                            <asp:GridView ID="gvownership" runat="server" Width="900px" SkinID="GridViewAA" DataKeyNames="OwnershipId" Font-Size="9pt">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="year" HeaderText="Year"></asp:BoundField>
                                                                                    <asp:BoundField DataField="ownername" HeaderText="Owner's Name"></asp:BoundField>
                                                                                    <asp:BoundField DataField="ownertype" HeaderText="Ownership Type"></asp:BoundField>
                                                                                    <asp:BoundField DataField="address" HeaderText="Address"></asp:BoundField>
                                                                                    <asp:BoundField DataField="typeacquisition" HeaderText="Type Of Acquisition"></asp:BoundField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 500px" align="center">
                                                                            <fieldset style="width: 450px; height: 120px" class="PanelBorder">
                                                                                <table style="width: 411px" id="tbownership1">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 131px" class="column_LeftBold" align="left">Corporation Name</td>
                                                                                            <td style="width: 11px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 246px">
                                                                                                <asp:Label ID="lblCorpName" runat="server" Width="238px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 131px; height: 16px" class="column_LeftBold" align="left">Address</td>
                                                                                            <td style="width: 11px; height: 16px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 246px; height: 16px">
                                                                                                <asp:Label ID="lblAddress" runat="server" Width="238px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 131px" class="column_LeftBold" align="left">Telephone No.</td>
                                                                                            <td style="width: 11px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 246px">
                                                                                                <asp:Label ID="lblTelephone" runat="server" Width="238px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 131px" class="column_LeftBold" align="left">Cellphone No.</td>
                                                                                            <td style="width: 11px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 246px">
                                                                                                <asp:Label ID="lblCellphone" runat="server" Width="238px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 131px" class="column_LeftBold" align="left">Email Address</td>
                                                                                            <td style="width: 11px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 246px">
                                                                                                <asp:Label ID="lblEmail" runat="server" Width="238px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </fieldset>
                                                                        </td>
                                                                        <td style="width: 500px" align="center">
                                                                            <fieldset style="width: 450px; height: 120px" class="PanelBorder">
                                                                                <table style="width: 445px" id="tbownership2">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 209px; height: 16px" class="column_LeftBold" align="left">Chairman</td>
                                                                                            <td style="width: 11px; height: 16px" class="column_LeftBold">:</td>
                                                                                            <td style="height: 16px">
                                                                                                <asp:Label ID="lblChairman" runat="server" Width="184px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 209px" class="column_LeftBold" align="left">Vice Chairman</td>
                                                                                            <td style="width: 11px" class="column_LeftBold">:</td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblViceChairman" runat="server" Width="184px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 209px" class="column_LeftBold" align="left">President</td>
                                                                                            <td style="width: 11px" class="column_LeftBold">:</td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblPresident" runat="server" Width="184px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 209px; height: 18px" class="column_LeftBold" align="left">Senior Vice President</td>
                                                                                            <td style="width: 11px; height: 18px" class="column_LeftBold">:</td>
                                                                                            <td style="height: 18px">
                                                                                                <asp:Label ID="lblSeniorVP" runat="server" Width="184px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 209px" class="column_LeftBold" align="left">Administrative&nbsp; Vice President</td>
                                                                                            <td style="width: 11px" class="column_LeftBold">:</td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblAdministrativeVP" runat="server" Width="184px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 209px; height: 16px" class="column_LeftBold" align="left">Corporate Secretary</td>
                                                                                            <td style="width: 11px; height: 16px" class="column_LeftBold">:</td>
                                                                                            <td style="height: 16px">
                                                                                                <asp:Label ID="lblCorporateSec" runat="server" Width="184px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </asp:View>

                                                        <asp:View ID="vwLandValutaion" runat="server">
                                                            <asp:GridView ID="grdlandEvaluation" runat="server" Width="1000px" SkinID="gvnew" HorizontalAlign="Center" AllowPaging="True" Font-Size="9pt">
                                                                <Columns>
                                                                    <asp:BoundField DataField="classification" HeaderText="Classification"></asp:BoundField>
                                                                    <asp:BoundField DataField="subclassification" HeaderText="Sub- Classification"></asp:BoundField>
                                                                    <asp:BoundField DataField="area" HeaderText="Area"></asp:BoundField>
                                                                    <asp:BoundField DataField="unit" HeaderText="Unit"></asp:BoundField>
                                                                    <asp:BoundField DataField="unitvalue" HeaderText="Unit Value">
                                                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="basemarketvalue" HeaderText="Base Market Value">
                                                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="taxable" HeaderText="Taxable"></asp:BoundField>
                                                                    <asp:BoundField DataField="adjustments" HeaderText="Adjustments"></asp:BoundField>
                                                                    <asp:BoundField DataField="adjustedmarketvalue" HeaderText="Adjusted Market Value">
                                                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="strip" HeaderText="Strip"></asp:BoundField>
                                                                    <asp:BoundField DataField="adjunitvalue" HeaderText="Adj Unit value">
                                                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                    </asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <table width="1000">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 272px; height: 16px" class="text5"></td>
                                                                        <td style="width: 249px; height: 16px" class="text5">
                                                                            <asp:CheckBox ID="chkMultiple" runat="server"></asp:CheckBox>Multiple Classification</td>
                                                                        <td style="width: 116px; height: 16px" class="text5">Total Land Areas :</td>
                                                                        <td style="width: 78px; height: 16px" class="text5">
                                                                            <asp:Label ID="lblTotalArea" runat="server" Width="102px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                        <td style="width: 180px; height: 16px" class="text5">Total Base Market Value :</td>
                                                                        <td style="height: 16px" class="text5">
                                                                            <asp:Label ID="lblTotalMarketValue" runat="server" Width="102px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="vwApprovalInformation" runat="server">
                                                            <table style="width: 1000px">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 350px" class="text5">
                                                                            <table style="width: 100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="width: 100%" class="text5">
                                                                                            <asp:CheckBox ID="chkdateregistred" runat="server" Width="144px" Text="Date Registration"></asp:CheckBox><asp:Label ID="lblbuildingdate" runat="server" Width="81px" SkinID="LabelBorder" BorderStyle="Solid" BorderWidth="1px">mm/dd/yyyy</asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 100%" class="text5">
                                                                                            <fieldset style="width: 95%" class="PanelBorder">
                                                                                                <legend><span style="font-size: 11pt; font-family: Calibri"><strong>Effectively of Assessment</strong></span></legend>
                                                                                                <table style="width: 279px" id="tbeffectiveness" class="text5">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="width: 136px; height: 24px">
                                                                                                                <asp:DropDownList ID="ddQuarterbuilding" runat="server" Width="104px">
                                                                                                                </asp:DropDownList></td>
                                                                                                            <td style="height: 24px">
                                                                                                                <asp:DropDownList ID="ddyearbuilding" runat="server" Width="104px">
                                                                                                                </asp:DropDownList></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 136px; height: 16px">Quarter</td>
                                                                                                            <td style="height: 16px">Year</td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </fieldset>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 100%" class="text5">
                                                                                            <asp:RadioButtonList ID="rdbBuilding" runat="server" Width="191px" RepeatDirection="Horizontal">
                                                                                                <asp:ListItem>Taxable</asp:ListItem>
                                                                                                <asp:ListItem>Exemption</asp:ListItem>
                                                                                            </asp:RadioButtonList></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td style="width: 650px" class="text5">
                                                                            <fieldset style="width: 98%" class="PanelBorder">
                                                                                <legend><span style="font-size: 11pt; font-family: Calibri"><strong>SIGNATORIES</strong></span></legend>
                                                                                <table style="width: 100%">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 60%" class="text5">Appraised And Assessment By</td>
                                                                                            <td style="width: 10%" class="text5"></td>
                                                                                            <td style="width: 20%" class="text5">Date</td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 60%" class="text4">
                                                                                                <asp:DropDownList ID="ddappraisedLand" runat="server" Width="95%"></asp:DropDownList></td>
                                                                                            <td style="width: 10%" class="text5">
                                                                                                <asp:CheckBox ID="chk1" runat="server"></asp:CheckBox></td>
                                                                                            <td style="width: 20%" class="text5">
                                                                                                <asp:Label ID="lblappraiseddate" runat="server" Width="81px" SkinID="LabelBorder" BorderStyle="Solid" BorderWidth="1px">mm/dd/yyyy</asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 60%" class="text5">Recommending Approval</td>
                                                                                            <td style="width: 10%" class="text5"></td>
                                                                                            <td style="width: 20%" class="text5"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 60%" class="text4">
                                                                                                <asp:DropDownList ID="ddrecommendingApprovalLand" runat="server" Width="95%"></asp:DropDownList></td>
                                                                                            <td style="width: 10%" class="text5">
                                                                                                <asp:CheckBox ID="chk2" runat="server"></asp:CheckBox></td>
                                                                                            <td style="width: 20%" class="text5">
                                                                                                <asp:Label ID="lblrecommendingdate" runat="server" Width="81px" SkinID="LabelBorder" BorderStyle="Solid" BorderWidth="1px">mm/dd/yyyy</asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 60%" class="text5">Approved By</td>
                                                                                            <td style="width: 10%" class="text5"></td>
                                                                                            <td style="width: 20%" class="text5"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 60%" class="text4">
                                                                                                <asp:DropDownList ID="ddapprovedLand" runat="server" Width="95%"></asp:DropDownList></td>
                                                                                            <td style="width: 10%" class="text5">
                                                                                                <asp:CheckBox ID="chk3" runat="server"></asp:CheckBox></td>
                                                                                            <td style="width: 20%" class="text5">
                                                                                                <asp:Label ID="lblapproveddate" runat="server" Width="81px" SkinID="LabelBorder" BorderStyle="Solid" BorderWidth="1px">mm/dd/yyyy</asp:Label></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="vwImprovements" runat="server">
                                                            <table style="width: 1000px">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 1000px">
                                                                            <asp:GridView ID="gvLandInprovements" runat="server" Width="1000px" SkinID="gvnew" AllowPaging="True" HorizontalAlign="Center" Font-Size="9pt">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="kind" HeaderText="Kind"></asp:BoundField>
                                                                                    <asp:BoundField DataField="quantity" HeaderText="Quantity"></asp:BoundField>
                                                                                    <asp:BoundField DataField="unitvalue" HeaderText="Unit Value"></asp:BoundField>
                                                                                    <asp:BoundField DataField="basemarketvalue" HeaderText="Base Market Value"></asp:BoundField>
                                                                                    <asp:BoundField DataField="taxable" HeaderText="Taxable"></asp:BoundField>
                                                                                    <asp:BoundField DataField="Subclass" HeaderText="SubClass"></asp:BoundField>
                                                                                    <asp:BoundField DataField="type" HeaderText="Type"></asp:BoundField>
                                                                                    <asp:BoundField DataField="asssessmentlevel" HeaderText="AssessmentLevel"></asp:BoundField>
                                                                                    <asp:BoundField DataField="actualuse" HeaderText="Actual Use"></asp:BoundField>
                                                                                    <asp:BoundField DataField="landimprovements" HeaderText="Land Improvements"></asp:BoundField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 1000px" class="text5">Total Improvement Base Market Value:</td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="vwmemoranda" runat="server">
                                                            <table style="width: 1000px" class="text5">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="height: 56px" id="Td1" align="center">
                                                                            <fieldset style="width: 876px; height: 55px" class="PanelBorder">
                                                                                <legend>Memoranda</legend>
                                                                                <asp:Label ID="lblMemoranda" runat="server" Width="841px" CssClass="text3" SkinID="Label" Height="30px"></asp:Label>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 55px" id="Td2" align="center">
                                                                            <fieldset style="width: 878px; height: 56px" class="PanelBorder">
                                                                                <legend>Remarks</legend>
                                                                                <asp:Label ID="lblMemorandaRemarks" runat="server" Width="844px" CssClass="text3" SkinID="Label" Height="41px"></asp:Label>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 84px" id="Td3" align="center">
                                                                            <table width="1000">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="width: 10px"></td>
                                                                                        <td style="width: 290px" class="text4">Date of Entry in the Records of Assesment By :</td>
                                                                                        <td style="width: 230px" class="text3">
                                                                                            <asp:Label ID="lblAssesmentBy" runat="server" Width="200px" CssClass="text3"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 100px" class="text4">Date Encoded :</td>
                                                                                        <td style="width: 80px">
                                                                                            <asp:Label ID="lblEncodedDate" runat="server" CssClass="text3"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 30px" class="text4">By :</td>
                                                                                        <td style="width: 250px" class="text3">
                                                                                            <asp:Label ID="lblEncodedBy" runat="server" Width="220px" CssClass="text3"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 10px"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 10px"></td>
                                                                                        <td style="width: 290px" class="text5" align="right">
                                                                                            <asp:CheckBox ID="CheckBox1" runat="server" Width="290px" CssClass="text4" Text="Date"></asp:CheckBox></td>
                                                                                        <td style="width: 230px" class="text3">
                                                                                            <asp:Label ID="lblDate" runat="server" Width="200px" CssClass="text3" SkinID="LabelBorder" Font-Italic="True"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 100px" class="text4">Date Uploaded :</td>
                                                                                        <td style="width: 80px">
                                                                                            <asp:Label ID="lblUploadedDate" runat="server" CssClass="text3"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 30px" class="text4">By :</td>
                                                                                        <td style="width: 250px" class="text3">
                                                                                            <asp:Label ID="lblUploadBy" runat="server" Width="220px" CssClass="text3"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 10px"></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="vwAttachedDocument" runat="server">
                                                            <table style="width: 1000px">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 700px">
                                                                            <fieldset style="vertical-align: middle; width: 690px; height: 220px; text-align: center" class="PanelBorder">
                                                                                <legend><span style="font-size: 11pt; font-family: Calibri"><strong>DOCUMENTS DETAILS</strong></span></legend>
                                                                                <br />
                                                                                <asp:GridView ID="grblgydocumentdetails" runat="server" Width="650px" SkinID="gvnew" DataKeyNames="DocuId" PageSize="5" Font-Size="9pt">
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="documentname" HeaderText="Document Name"></asp:BoundField>
                                                                                        <asp:BoundField DataField="documentno" HeaderText="Document No."></asp:BoundField>
                                                                                        <asp:BoundField DataField="validatedby" HeaderText="Validated By"></asp:BoundField>
                                                                                        <asp:BoundField DataField="datevalidated" HeaderText="Date Validated"></asp:BoundField>
                                                                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks"></asp:BoundField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </fieldset>
                                                                        </td>
                                                                        <td style="width: 300px">
                                                                            <fieldset style="width: 280px; height: 220px" class="PanelBorder">
                                                                                <legend><span style="font-size: 11pt; font-family: Calibri"><strong>ATTACHED DOCUMENTS</strong></span></legend>
                                                                                <asp:Image ID="imgbuildingdoc" runat="server" Width="220px" ImageUrl="~/images/DefaulScannedDocuments.jpg" Height="200px"></asp:Image>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </asp:View>
                                                    </asp:MultiView>

                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:View>
                                <asp:View ID="vwBLDG" runat="server">
                                    <table style="width: 1000px">
                                        <tbody>
                                            <tr>
                                                <td style="width: 1000px" class="DivTitle">BUILDING INFORMATION

                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="width: 1000px">
                                                    <table style="width: 1000px">
                                                        <tbody>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td style="width: 35%">
                                                                                <table>
                                                                                    <tr>
                                                                                        <td class="column_RightBold">Building Name :
                                                                                        </td>
                                                                                        <td class="column_Left">
                                                                                            <asp:TextBox ID="txtBuildingName" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="column_RightBold" style="width: 30%">Address : 
                                                                                        </td>
                                                                                        <td class="column_Left" style="width: 40%">
                                                                                            <asp:TextBox ID="txtAddress" runat="server" Width="100%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                        </td>

                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="column_RightBold" style="width: 10%">Brgy :
                                                                                        </td>
                                                                                        <td class="column_Left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtBuildingBrgy" runat="server" Width="50%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>

                                                                                </table>
                                                                            </td>
                                                                            <td align="left" style="width: 50%">
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td class="column_RightBold" style="width: 25%">Area :
                                                                                        </td>
                                                                                        <td class="column_Left" style="width: 70%">
                                                                                            <asp:TextBox ID="txtBuildingArea" runat="server" Width="34%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="column_RightBold">Tax Dec. No.: 
                                                                                        </td>
                                                                                        <td class="column_Left">
                                                                                            <asp:TextBox ID="txtBuildingTaxDecNo" runat="server" Width="34%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="column_RightBold">Previous Owner :
                                                                                        </td>
                                                                                        <td class="column_Left" colspan=" 3">
                                                                                            <asp:TextBox ID="txtPreviousOwner" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>

                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr valign="top">
                                                                <td>
                                                                    <fieldset>

                                                                        <legend class="column_LeftBold">Acquisition :</legend>
                                                                        <table>
                                                                            <tr>
                                                                                <td class="column_RightBold">Acquisition Date :
                                                                                </td>
                                                                                <td class="column_Left" style="width: 100px;">
                                                                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                                                                    <asp:TextBox ID="txtEAcqDateBuilding" runat="server" CssClass="txtbox_Var" Enabled="False" onchange="return NoOfYearsBuilding(this.value);"></asp:TextBox>
                                                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEAcqDate" PopupButtonID="txtEAcqDate"></cc1:CalendarExtender>
                                                                                    &nbsp;(MM/DD/YYYY)</td>
                                                                                <td class="column_RightBold">Market Value :
                                                                                </td>
                                                                                <td class="column_Left">
                                                                                    <asp:Label ID="Label5" runat="server"></asp:Label>
                                                                                    <asp:TextBox ID="txtEMarketValue" runat="server" CssClass="txtbox_Var" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>

                                                                                </td>


                                                                            </tr>
                                                                            <tr>

                                                                                <td class="column_RightBold">Acquisition Cost :
                                                                                </td>
                                                                                <td class="column_Left">
                                                                                    <asp:Label ID="Label6" runat="server"></asp:Label>
                                                                                    <asp:TextBox ID="txtEAcqCost" runat="server" CssClass="txtbox_Var" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalValBuilding(this),getDepValRateBuilding(this);"></asp:TextBox>
                                                                                </td>

                                                                                <td class="column_RightBold">No. of Years :
                                                                                </td>
                                                                                <td class="column_Left">
                                                                                    <asp:Label ID="Label7" runat="server"></asp:Label>
                                                                                    <asp:TextBox ID="txtNoYears" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                                                </td>
                                                                            </tr>
                                                                            <tr>

                                                                                <td class="column_RightBold">Depreciated Rate :
                                                                                </td>
                                                                                <td class="column_Left">
                                                                                    <asp:TextBox ID="txtBuildingDepRate" runat="server" Width="100px" CssClass="txtboxAmount" MaxLength="5" ReadOnly="True" Enabled="False"></asp:TextBox>&nbsp;(%) Percent</td>


                                                                                <td class="column_RightBold">Useful Life :
                                                                                </td>
                                                                                <td class="column_Left">
                                                                                    <asp:Label ID="Label8" runat="server"></asp:Label>
                                                                                    <asp:TextBox ID="txtUsefulLife" runat="server" Width="100px" CssClass="txtbox_Var" Enabled="False" onchange="return getDepValRateBuilding(this);" ></asp:TextBox>

                                                                                    &nbsp;(Years)</td>

                                                                            </tr>
                                                                            <tr>
                                                                                   <td class="column_RightBold">Depreciated Value :</td>
                                                                                   <td class="column_Left">
                                                                                       <asp:TextBox ID="txtBuildingDepreciatedValueNew" runat="server"  CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                   </td>
                                                                                   <td class="column_RightBold">Salvage Value :</td>
                                                                                   <td class="column_Left">
                                                                                       <asp:TextBox ID="txtSalvageValueBuilding" runat="server" CssClass="txtboxAmount" Enabled="False" Onchange="this.value=formatCurrency(this.value);" Onkeyup="javascript:this.value=Comma(this.value);" Width="85%">0.00</asp:TextBox>
                                                                                   </td>
                                                                            </tr>
                                                                            <tr>

                                                                                <td class="column_RightBold">Depreciation Value :
                                                                                </td>
                                                                                <td class="column_Left">
                                                                                    <asp:Label ID="Label9" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                    <asp:TextBox ID="txtBuildingdepreciatedvalue" runat="server" Width="100px" CssClass="txtbox_Var" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                                                </td>

                                                                                <td class="column_RightBold">&nbsp;</td>
                                                                                <td class="column_Left">
                                                                                    &nbsp;</td>


                                                                            </tr>
                                                                        </table>
                                                                    </fieldset>

                                                                </td>
                                                                <td style="width: 200px; border: 2px solid #5c85d6" rowspan="2">
                                                                    <table style="width: 195px">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td style="width: 191px;" class="textimage2" colspan="2">
                                                                                    <asp:Image ID="Image2" runat="server" Width="204px" ImageUrl="~/images/blankImage.jpg" CssClass="textimage2" Height="202px" ImageAlign="Middle"></asp:Image>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="display: none;">
                                                                                <td style="width: 80px" class="textimage2">Date Taken:</td>
                                                                                <td style="width: 111px" class="textimage2">
                                                                                    <asp:Label ID="lblbuildingdatetaken" runat="server" Width="110px" CssClass="textimage2" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="display: none;">
                                                                                <td style="width: 80px" class="textimage2">Uploaded By:</td>
                                                                                <td style="width: 111px" class="textimage2">
                                                                                    <asp:Label ID="lblbuildinguploadedby" runat="server" Width="110px" CssClass="textimage2" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="display: none;">
                                                                                <td style="width: 80px" class="textimage2">Position:</td>
                                                                                <td style="width: 111px" class="textimage2">
                                                                                    <asp:Label ID="lblbuildingposition" runat="server" Width="110px" CssClass="textimage2" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>

                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 800px; border: 2px solid #5c85d6">
                                                                    <table id="Table31" width="780">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td style="width: 120px; height: 18px" class="column_LeftBold" align="left">Building Control No.</td>
                                                                                <td style="width: 7px; height: 18px">:</td>
                                                                                <td style="width: 247px" class="text3; column_Left" align="left">
                                                                                    <asp:Label ID="lblbuildingcontrolno" runat="server" Width="0px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                    <asp:TextBox ID="txtbuildingcontrolno" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                </td>
                                                                                <td style="width: 132px" class="column_LeftBold" align="left">Building Occupancy</td>
                                                                                <td style="width: 2px">:</td>
                                                                                <td style="width: 180px" class="text3">
                                                                                    <asp:Label ID="lblbuildingoccupancy" runat="server" Width="0px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                 <asp:TextBox ID="txtbuildingoccupancy" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 120px" class="column_LeftBold" align="left">Building Code</td>
                                                                                <td style="width: 7px">:</td>
                                                                                <td style="width: 247px" class="text3" align="left">
                                                                                    <asp:Label ID="lblbuildingCode" runat="server" Width="0px" CssClass="text3" SkinID="Label" Font-Italic="False" Height="16px"></asp:Label>
                                                                                     <asp:TextBox ID="txtbuildingCode" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                </td>
                                                                                <td style="width: 132px" class="column_LeftBold" align="left">Number of Floors</td>
                                                                                <td style="width: 2px">:</td>
                                                                                <td style="width: 180px" class="text3">
                                                                                    <asp:Label ID="lblbuildingnumberoffloors" runat="server" Width="0px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                    <asp:TextBox ID="txtbuildingnumberoffloors" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 132px; height: 18px" class="column_LeftBold" align="left">Building Use</td>
                                                                                <td style="width: 2px; height: 18px">:</td>
                                                                                <td style="width: 180px" class="text3">
                                                                                    <asp:Label ID="lblbuildinguse" runat="server" Width="0px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                     <asp:TextBox ID="txtbuildinguse" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                </td>
                                                                                <td style="width: 132px" class="column_LeftBold" align="left">Avg. Area Per Floor</td>
                                                                                <td style="width: 2px">:</td>
                                                                                <td style="width: 180px" class="text3">
                                                                                    <asp:Label ID="lblbuildingavgareaperfloor" runat="server" Width="0px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                 <asp:TextBox ID="txtbuildingavgareaperfloor" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 120px" class="column_LeftBold" align="left">Postal Code</td>
                                                                                <td style="width: 7px">:</td>
                                                                                <td style="width: 247px" class="text3; column_Left" align="left" >
                                                                                    <asp:Label ID="lblbuildingpostalcode" runat="server" Width="0px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                    <asp:TextBox ID="txtbuildingpostalcode" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                </td>
                                                                                <td style="width: 132px" class="column_LeftBold" align="left">Cost per Area

                                                                                </td>
                                                                                <td style="width: 2px">:</td>
                                                                                <td style="width: 180px" class="text3">
                                                                                    <asp:Label ID="lblbuildingcostperarea" runat="server" Width="0px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                    <asp:TextBox ID="txtbuildingcostperarea" runat="server" CssClass="txtbox_Var" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                                                </td>
                                                                            </tr>

                                                                        </tbody>

                                                                    </table>
                                                                </td>


                                                            </tr>
                                                            <tr>
                                                                <td class="column_Right" colspan="2" style="margin-left: 40px">
                                                                    <asp:Label ID="lblBuilding_Get_ID" runat="server" Text="Label" Visible="False"></asp:Label>
                                                                    <asp:Label ID="lblBuildingitem_id" runat="server" Text="Label" Visible="False"></asp:Label>
                                                                    <asp:Label ID="lblBuildingProperty_ID" runat="server" Text="Label" Visible="False"></asp:Label>
                                                                    <asp:Button ID="btnBuildingEdit" runat="server" CssClass="CSButton" Enabled="False" Height="25px" OnClientClick="StartProgressBar();" Text="Edit" Width="150px" />
                                                                </td>
                                                                <td></td>
                                                            </tr>

                                                        </tbody>

                                                    </table>

                                                </td>

                                            </tr>
                                            <tr style="display: none;">
                                                <td style="width: 1000px">
                                                    <table style="width: 882px" id="tbbuildingButton" cellspacing="0" cellpadding="0" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 132px; height: 26px">
                                                                    <asp:Button ID="btnConstructionDetails" runat="server" Width="129px" CssClass="Initial" Text="Construction Details"></asp:Button>

                                                                </td>
                                                                <td style="height: 26px">
                                                                    <asp:Button ID="btnBuildingInformation" runat="server" Width="128px" CssClass="Initial" Text="Building Information"></asp:Button>

                                                                </td>
                                                                <td style="height: 26px">
                                                                    <asp:Button ID="btnOwnersInformation" runat="server" Width="126px" CssClass="Initial" Text="Owner's Information"></asp:Button></td>
                                                                <td style="height: 26px">
                                                                    <asp:Button ID="btnOccupants" runat="server" Width="73px" CssClass="Initial" Text="Occupants"></asp:Button></td>
                                                                <td style="width: 5px; height: 26px">
                                                                    <asp:Button ID="btnPermitApplicationHistory" runat="server" Width="162px" CssClass="Initial" Text="Permit Application History"></asp:Button></td>
                                                                <td style="width: 48px; height: 26px">
                                                                    <asp:Button ID="btnInspectionHistory" runat="server" Width="117px" CssClass="Initial" Text="Inspection History"></asp:Button></td>
                                                                <td style="width: 54px; height: 26px"></td>
                                                                <td style="width: 145px; height: 26px">
                                                                    <asp:Button ID="btnPaymentHistory" runat="server" Width="107px" CssClass="Initial" Text="Payment History"></asp:Button><asp:Button ID="btnbuildingDocumentAttach" runat="server" CssClass="Initial" Text="Document Attachment" Width="148px"></asp:Button></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <asp:MultiView ID="mvBLDG" runat="server">
                                                        <asp:View ID="vwConstructionDetails" runat="server">
                                                            <table id="tbconsrtuction" width="955">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="text-align: left" align="center">
                                                                            <fieldset style="width: 980px" class="PanelBorder">
                                                                                <legend style="font-weight: bold"><span style="font-size: 11pt; font-family: Calibri">Original Construction Information</span></legend>
                                                                                <table style="width: 98%">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 15%" class="column_LeftBold" align="left">Construction Type :</td>
                                                                                            <td style="width: 23%" class="text5">
                                                                                                <asp:Label ID="lblConstructionTyp" runat="server" Width="95%" CssClass="text5" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 160px" class="column_LeftBold" align="left">Project Cost :</td>
                                                                                            <td style="width: 23%" class="text5">
                                                                                                <asp:Label ID="lblProjectCost" runat="server" Width="95%" CssClass="text5" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 81px" class="column_LeftBold" align="left">Date Issued :</td>
                                                                                            <td style="width: 14%" class="text5">
                                                                                                <asp:Label ID="lblDateIssued" runat="server" Width="95%" CssClass="text5" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 15%" class="column_LeftBold" align="left">Date Started :</td>
                                                                                            <td style="width: 23%" class="text5">
                                                                                                <asp:Label ID="lblDateStarted" runat="server" Width="95%" CssClass="text5" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 160px" class="column_LeftBold" align="left">Building Permit No. :</td>
                                                                                            <td style="width: 23%" class="text5">
                                                                                                <asp:Label ID="lblBldgPermitNo" runat="server" Width="95%" CssClass="text5" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 81px" class="column_LeftBold" align="left">Remarks :</td>
                                                                                            <td style="width: 14%" class="text5">
                                                                                                <asp:Label ID="lblBldgRemarks" runat="server" Width="95%" CssClass="text5" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 15%" class="column_LeftBold" align="left">Date Of Completion :</td>
                                                                                            <td style="width: 23%" class="text5">
                                                                                                <asp:Label ID="lblDateCompletion" runat="server" Width="95%" CssClass="text5" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 160px" class="column_LeftBold" align="left">Date Of Application :</td>
                                                                                            <td style="width: 23%" class="text5">
                                                                                                <asp:Label ID="lblDateApplication" runat="server" Width="95%" CssClass="text5" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 10%" class="column_LeftBold"></td>
                                                                                            <td style="width: 14%" class="text5"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 15%" class="column_LeftBold"></td>
                                                                                            <td style="width: 23%" class="text5"></td>
                                                                                            <td style="width: 15%" class="column_LeftBold"></td>
                                                                                            <td style="width: 23%" class="text5"></td>
                                                                                            <td style="width: 10%" class="column_LeftBold"></td>
                                                                                            <td style="width: 14%" class="text5"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="text5" colspan="2">LIST OF PROFESSIONALS</td>
                                                                                            <td style="width: 15%" class="column_LeftBold"></td>
                                                                                            <td style="width: 23%" class="text5"></td>
                                                                                            <td style="width: 10%" class="column_LeftBold"></td>
                                                                                            <td style="width: 14%" class="text5"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">
                                                                                                <asp:GridView ID="grdlistofProfessional" runat="server" Width="950px" SkinID="gvnew" Font-Size="9pt">
                                                                                                    <Columns>
                                                                                                        <asp:BoundField DataField="ProfessionalContractor" HeaderText="Profeesional Contractor"></asp:BoundField>
                                                                                                        <asp:BoundField DataField="ProfessionalName" HeaderText="Name"></asp:BoundField>
                                                                                                        <asp:BoundField DataField="Professionaladdress" HeaderText="Address"></asp:BoundField>
                                                                                                        <asp:BoundField DataField="ProfessionalTeleNo" HeaderText="Telephone No."></asp:BoundField>
                                                                                                        <asp:BoundField DataField="ProfessionalCellNo" HeaderText="Cellphone No."></asp:BoundField>
                                                                                                        <asp:BoundField DataField="ProfessionalEmailAddress" HeaderText="Email Address"></asp:BoundField>
                                                                                                        <asp:BoundField DataField="ProfessionalPrcNo" HeaderText="PRC No."></asp:BoundField>
                                                                                                        <asp:BoundField DataField="ProfessionalPtrNo" HeaderText="PIR No."></asp:BoundField>
                                                                                                        <asp:BoundField DataField="Professionalvalidity" HeaderText="Validity"></asp:BoundField>
                                                                                                        <asp:BoundField DataField="Professionaldateissued" HeaderText="Date Issued"></asp:BoundField>
                                                                                                    </Columns>
                                                                                                </asp:GridView>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="vwbuildinginformation" runat="server">
                                                            <table width="1000">
                                                                <tbody>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <fieldset style="width: 955px; height: 80px" class="PanelBorder">
                                                                                <legend><em><strong><span style="font-size: 10pt">Basic Information</span></strong></em></legend>
                                                                                <table id="tdBasicInformation" width="950">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 312px; height: 18px" class="column_LeftBold" align="left">Real Property PIN</td>
                                                                                            <td style="width: 8px; height: 18px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 56px; height: 18px" align="left">
                                                                                                <asp:Label ID="lblPropertyPin" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 341px; height: 18px" class="column_LeftBold" align="left">Occupancy Count</td>
                                                                                            <td style="width: 12px; height: 18px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 123px; height: 18px">
                                                                                                <asp:Label ID="lblOccupancyCount" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 407px; height: 18px" class="column_LeftBold" align="left">Efficiency Rate(U/R)</td>
                                                                                            <td style="height: 18px" class="column_LeftBold" align="left">:</td>
                                                                                            <td style="width: 3px; height: 18px">
                                                                                                <asp:Label ID="lblEfficiencyRate" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 312px" class="column_LeftBold" align="left">Property Code</td>
                                                                                            <td style="width: 8px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 56px" align="left">
                                                                                                <asp:Label ID="lblPropertyCode" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 341px" class="column_LeftBold">Max Building Occupancy</td>
                                                                                            <td style="width: 12px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 123px">
                                                                                                <asp:Label ID="lblMaxBldgOccupancy" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 407px" class="column_LeftBold" align="left">RU Ratio (R/U)</td>
                                                                                            <td class="column_LeftBold" align="left">:</td>
                                                                                            <td style="width: 3px">
                                                                                                <asp:Label ID="lblRatio" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 312px; height: 25px" class="column_LeftBold" align="left">Account Code</td>
                                                                                            <td style="width: 8px; height: 25px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 56px; height: 25px" align="left">
                                                                                                <asp:Label ID="lblAccountCode" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 341px; height: 25px" class="column_LeftBold">Entity Handle/Unique ID</td>
                                                                                            <td style="width: 12px; height: 25px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 123px; height: 25px">
                                                                                                <asp:Label ID="lblEntityHandle" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 407px; height: 25px" class="column_LeftBold" align="left">Comments</td>
                                                                                            <td style="height: 25px" class="column_LeftBold" align="left">:</td>
                                                                                            <td style="width: 3px; height: 25px">
                                                                                                <asp:Label ID="lblComments" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <fieldset style="width: 955px" class="PanelBorder">
                                                                                <legend><strong><em><span style="font-size: 10pt">Area</span></em></strong></legend>
                                                                                <table id="tbArea" width="950">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Ext Gross Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 118px" align="left">
                                                                                                <asp:Label ID="lblExtArea" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 190px" class="column_LeftBold" align="left">Room Bldg. Common Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 126px" class="text3">
                                                                                                <asp:Label ID="lblRoomArea" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Total Non-Occup. Common Area</td>
                                                                                            <td style="width: 3px" class="column_LeftBold" align="left">: </td>
                                                                                            <td style="width: 116px" class="text3">
                                                                                                <asp:Label ID="lblTNonOccuCom" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Int Gross Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 118px" align="left">
                                                                                                <asp:Label ID="lblIntArea" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 190px" class="column_LeftBold" align="left">Service Bldg. Common Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 126px" class="text3">
                                                                                                <asp:Label ID="lblSrvcBldgArea" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Total Non-Occup. Dept Area</td>
                                                                                            <td style="width: 3px" class="column_LeftBold" align="left">:</td>
                                                                                            <td style="width: 116px" class="text3">
                                                                                                <asp:Label ID="lblTNonOccuDept" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Ext Wall Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 118px" align="left">
                                                                                                <asp:Label ID="lblWallArea" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 190px" class="column_LeftBold" align="left">Service Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 126px" class="text3">
                                                                                                <asp:Label ID="lblServiceArea" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Total Occup Area</td>
                                                                                            <td style="width: 3px" class="column_LeftBold" align="left">:</td>
                                                                                            <td style="width: 116px" class="text3">
                                                                                                <asp:Label ID="lblTOccuArea" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Avg. Area Per Emp</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 118px" align="left">
                                                                                                <asp:Label ID="lblAvgPerEmp" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 190px" class="column_LeftBold" align="left">Suite Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 126px" class="text3">
                                                                                                <asp:Label ID="lblSuiteArea" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Total Occup Common Area</td>
                                                                                            <td style="width: 3px" class="column_LeftBold" align="left">:</td>
                                                                                            <td style="width: 116px" class="text3">
                                                                                                <asp:Label ID="lblTOccuCom" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Usable Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 118px" align="left">
                                                                                                <asp:Label ID="lblUsableArea" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 190px" class="column_LeftBold" align="left">Total Emp. Dept Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 126px" class="text3">
                                                                                                <asp:Label ID="lblTEmpArea" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Total Occup Dept Area</td>
                                                                                            <td style="width: 3px" class="column_LeftBold" align="left">:</td>
                                                                                            <td style="width: 116px" class="text3">
                                                                                                <asp:Label ID="lblTOccuDept" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Remaining Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 118px" align="left">
                                                                                                <asp:Label ID="lblRemArea" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 190px" class="column_LeftBold" align="left">Total Group Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 126px" class="text3">
                                                                                                <asp:Label ID="lblTGroupArea" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Total Room Area</td>
                                                                                            <td style="width: 3px" class="column_LeftBold" align="left">:</td>
                                                                                            <td style="width: 116px" class="text3">
                                                                                                <asp:Label ID="lblTRoomArea" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Rentable Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 118px" align="left">
                                                                                                <asp:Label ID="lblRentArea" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 190px" class="column_LeftBold" align="left">Total Group Common Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 126px" class="text3">
                                                                                                <asp:Label ID="lblTGroupCom" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Total Room Common Area</td>
                                                                                            <td style="width: 3px" class="column_LeftBold" align="left">:</td>
                                                                                            <td style="width: 116px" class="text3">
                                                                                                <asp:Label ID="lblTRoomCom" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Group Building Common Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 118px" align="left">
                                                                                                <asp:Label ID="lblGroupArea" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 190px" class="column_LeftBold" align="left">Total Group Dept. Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 126px" class="text3">
                                                                                                <asp:Label ID="lblTGroupDept" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Total Room Dept Area</td>
                                                                                            <td style="width: 3px" class="column_LeftBold" align="left">:</td>
                                                                                            <td style="width: 116px" class="text3">
                                                                                                <asp:Label ID="lblTRoomDept" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Non- Occu Bldg. Common Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 118px" align="left">
                                                                                                <asp:Label ID="lblNonOccu" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 190px" class="column_LeftBold" align="left">Total Lease Negotiated Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 126px" class="text3">
                                                                                                <asp:Label ID="lblTLeaseArea" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Vert Pen Area</td>
                                                                                            <td style="width: 3px" class="column_LeftBold" align="left">:</td>
                                                                                            <td style="width: 116px" class="text3">
                                                                                                <asp:Label ID="lblVertPenArea" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Occupable&nbsp; Bldg. Common Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 118px" align="left">
                                                                                                <asp:Label ID="lblOccuArea" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 190px" class="column_LeftBold" align="left">Total Non Occup. Area</td>
                                                                                            <td style="width: 2px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 126px" class="text3">
                                                                                                <asp:Label ID="lblTNonOccu" runat="server" Width="80px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left"></td>
                                                                                            <td style="width: 3px" class="column_LeftBold" align="left"></td>
                                                                                            <td style="width: 116px" class="text3"></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <fieldset style="width: 955px" class="PanelBorder">
                                                                                <legend><span style="font-size: 10pt"><strong><em>Values</em></strong></span></legend>
                                                                                <table id="tbValue" width="950">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 200px; height: 18px" class="column_LeftBold" align="left">Value Market</td>
                                                                                            <td style="width: 8px; height: 18px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 56px; height: 18px" align="left">
                                                                                                <asp:Label ID="lblValueMarket" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 341px; height: 18px" class="column_LeftBold" align="left">Expense - Other Total</td>
                                                                                            <td style="width: 12px; height: 18px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 123px; height: 18px">
                                                                                                <asp:Label ID="lblOtherTotal" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 407px; height: 18px" class="column_RightBold" align="left">Expense Utility Total</td>
                                                                                            <td style="height: 18px" class="column_LeftBold" align="left">:</td>
                                                                                            <td style="width: 3px; height: 18px">
                                                                                                <asp:Label ID="lblUtilityTotal" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 200px" class="column_LeftBold" align="left">Value Book</td>
                                                                                            <td style="width: 8px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 56px" align="left">
                                                                                                <asp:Label ID="lblValueBook" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 341px" class="column_LeftBold" align="left">Expense Opper Total</td>
                                                                                            <td style="width: 12px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 123px">
                                                                                                <asp:Label ID="lblOpperTotal" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 407px" class="column_RightBold" align="left"></td>
                                                                                            <td class="column_LeftBold" align="left"></td>
                                                                                            <td style="width: 3px"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 200px; height: 16px" class="column_LeftBold" align="left">Income Total</td>
                                                                                            <td style="width: 8px; height: 16px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 56px; height: 16px" align="left">
                                                                                                <asp:Label ID="lblTotalIncome" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 341px; height: 16px" class="column_LeftBold" align="left">Expense Tax Total</td>
                                                                                            <td style="width: 12px; height: 16px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 123px; height: 16px">
                                                                                                <asp:Label ID="lblTaxTotal" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 407px; height: 16px" class="column_RightBold" align="left"></td>
                                                                                            <td style="height: 16px" class="column_LeftBold" align="left"></td>
                                                                                            <td style="width: 3px; height: 16px"></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>

                                                        </asp:View>
                                                        <asp:View ID="vwOwnersInformation" runat="server">
                                                            <table width="950">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 475px; height: 164px">
                                                                            <fieldset style="width: 473px; height: 160px" class="PanelBorder">
                                                                                <legend><strong><em>Corporate</em></strong></legend>
                                                                                <table id="tbCorporate" width="470">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 30px; height: 15px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px; height: 15px" class="column_LeftBold" align="left"></td>
                                                                                            <td style="width: 3px; height: 15px" class="column_LeftBold"></td>
                                                                                            <td style="width: 288px; height: 16px" class="text3" align="left"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 30px; height: 15px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px; height: 15px" class="column_LeftBold" align="left">Corporation Name</td>
                                                                                            <td style="width: 3px; height: 15px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 288px; height: 16px" class="text3" align="left">
                                                                                                <asp:Label ID="lblCorporationName" runat="server" Width="288px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 30px; height: 15px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px; height: 16px" class="column_LeftBold" align="left">Address</td>
                                                                                            <td style="width: 3px; height: 16px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 288px; height: 16px" class="text3" align="left">
                                                                                                <asp:Label ID="lblCorpAddress" runat="server" Width="288px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 30px; height: 15px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px; height: 16px" class="column_LeftBold" align="left">Telephone No.</td>
                                                                                            <td style="width: 3px; height: 16px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 288px; height: 16px" class="text3" align="left">
                                                                                                <asp:Label ID="lblCorpTelephone" runat="server" Width="288px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 30px; height: 15px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px" class="column_LeftBold" align="left">Cellphone No.</td>
                                                                                            <td style="width: 3px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 288px; height: 16px" class="text3" align="left">
                                                                                                <asp:Label ID="lblCorpCellphone" runat="server" Width="288px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 30px; height: 15px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px" class="column_LeftBold" align="left">Email Address</td>
                                                                                            <td style="width: 3px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 288px; height: 16px" class="text3" align="left">
                                                                                                <asp:Label ID="lblCorpEmail" runat="server" Width="288px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </fieldset>
                                                                        </td>
                                                                        <td style="width: 475px; height: 164px">
                                                                            <fieldset style="width: 473px; height: 160px" class="PanelBorder">
                                                                                <legend><strong><em>Officer</em></strong></legend>
                                                                                <table id="tbofficers" width="470">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 20px; height: 16px" class="text5" align="left"></td>
                                                                                            <td style="width: 148px; height: 16px" class="column_LeftBold" align="left">Chairman</td>
                                                                                            <td style="width: 3px; height: 23px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 3px; height: 23px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgChairman" runat="server" Width="280px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 20px; height: 16px" class="text5" align="left"></td>
                                                                                            <td style="width: 148px; height: 16px" class="column_LeftBold" align="left">Vice Chairman</td>
                                                                                            <td style="width: 3px; height: 16px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 3px; height: 16px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgViceChairman" runat="server" Width="280px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 20px; height: 16px" class="text5" align="left"></td>
                                                                                            <td style="width: 148px; height: 16px" class="column_LeftBold" align="left">President</td>
                                                                                            <td style="width: 3px; height: 16px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 3px; height: 16px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgPresident" runat="server" Width="280px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 20px; height: 16px" class="text5" align="left"></td>
                                                                                            <td style="width: 148px; height: 16px" class="column_LeftBold" align="left">Senior Vice President</td>
                                                                                            <td style="width: 3px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 3px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgSeniorVP" runat="server" Width="280px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 20px; height: 16px" class="text5" align="left"></td>
                                                                                            <td style="width: 148px; height: 16px" class="column_LeftBold" align="left">Vice President</td>
                                                                                            <td style="width: 3px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 3px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgVicePresident" runat="server" Width="280px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 20px; height: 16px" class="text5" align="left"></td>
                                                                                            <td style="width: 148px; height: 16px" class="column_LeftBold" align="left">Assistant Vice President</td>
                                                                                            <td style="width: 3px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 3px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgAssistantVP" runat="server" Width="280px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 20px; height: 16px" class="text5" align="left"></td>
                                                                                            <td style="width: 148px; height: 16px" class="column_LeftBold" align="left">Corporate Secretary</td>
                                                                                            <td style="width: 3px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 3px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgCorporateSec" runat="server" Width="280px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <fieldset style="width: 470px; height: 280px" class="PanelBorder">
                                                                                <legend><strong><em>Representative</em></strong></legend>
                                                                                <table id="tbRepresentative" width="470">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 30px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px; height: 15px" class="column_LeftBold" align="left">Representative 1</td>
                                                                                            <td style="width: 3px; height: 15px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 288px; height: 15px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgRep1" runat="server" Width="288px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 30px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px; height: 16px" class="column_LeftBold" align="left">Position </td>
                                                                                            <td style="width: 3px; height: 16px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 288px; height: 15px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgPosition1" runat="server" Width="288px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 30px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px; height: 16px" class="column_LeftBold" align="left">Address</td>
                                                                                            <td style="width: 3px; height: 16px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 288px; height: 15px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgAddress1" runat="server" Width="288px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 30px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px" class="column_LeftBold" align="left">Telephone No.</td>
                                                                                            <td style="width: 3px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 288px; height: 15px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgTelephone1" runat="server" Width="288px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 30px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px" class="column_LeftBold" align="left">Cellphone No.</td>
                                                                                            <td style="width: 3px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 288px; height: 15px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgCellphone1" runat="server" Width="288px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 30px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px" class="column_LeftBold" align="left">Email Address</td>
                                                                                            <td style="width: 3px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 288px; height: 15px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgEmail1" runat="server" Width="288px" CssClass="text3"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 30px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px; height: 16px" class="column_LeftBold" align="left"></td>
                                                                                            <td style="width: 3px; height: 16px" class="column_LeftBold"></td>
                                                                                            <td style="width: 288px; height: 15px" class="text3" align="left"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 30px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px" class="column_LeftBold" align="left">Representative 2</td>
                                                                                            <td style="width: 3px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 288px; height: 15px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgRep2" runat="server" Width="288px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 30px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px; height: 16px" class="column_LeftBold" align="left">Position</td>
                                                                                            <td style="width: 3px; height: 16px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 288px; height: 15px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgPosition2" runat="server" Width="288px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 30px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px" class="column_LeftBold" align="left">Address</td>
                                                                                            <td style="width: 3px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 288px; height: 15px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgAddress2" runat="server" Width="288px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 30px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px" class="column_LeftBold" align="left">Telephone No</td>
                                                                                            <td style="width: 3px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 288px; height: 15px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgTelephone2" runat="server" Width="288px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 30px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px" class="column_LeftBold" align="left">Cellphone No.</td>
                                                                                            <td style="width: 3px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 288px; height: 15px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgCellphone2" runat="server" Width="288px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 30px" class="text5" align="left"></td>
                                                                                            <td style="width: 118px" class="column_LeftBold" align="left">Email Address</td>
                                                                                            <td style="width: 3px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 288px; height: 15px" class="text3" align="left">
                                                                                                <asp:Label ID="lblBldgEmail2" runat="server" Width="288px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </fieldset>
                                                                        </td>
                                                                        <td style="height: 16px">
                                                                            <table style="height: 270px" width="470">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="width: 242px; height: 124px" align="center">
                                                                                            <table style="height: 108px" id="Table4" width="230">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td style="width: 230px; height: 66px" id="tdPerson1" align="center">
                                                                                                            <asp:Image ID="Image1" runat="server" Width="104px" ImageUrl="~/images/noPicture.JPG" Height="96px"></asp:Image></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 71px; height: 16px" align="center">
                                                                                                            <asp:Label ID="lblRep1Name" runat="server" Width="210px" CssClass="text6" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td style="height: 124px">
                                                                                            <table style="height: 108px" id="Table5" width="230">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td style="width: 230px; height: 66px" id="tdPerson2" align="center">
                                                                                                            <asp:Image ID="img2" runat="server" Width="104px" ImageUrl="~/images/noPicture.JPG" Height="96px"></asp:Image></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 71px; height: 16px" align="center">
                                                                                                            <asp:Label ID="lblRep2Name" runat="server" Width="210px" CssClass="text6" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 242px; height: 152px">
                                                                                            <fieldset style="width: 225px; height: 152px" class="PanelBorder">
                                                                                                <legend><strong><em>Personal Information</em></strong></legend>
                                                                                                <table id="tbowner1" width="230">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="width: 71px" class="textimage" align="left">Birth Date</td>
                                                                                                            <td style="width: 5px" class="text5">:</td>
                                                                                                            <td style="text-align: left" class="textimage1" align="left">
                                                                                                                <asp:Label ID="lblRep1Bday" runat="server" Width="130px" CssClass="textimage1" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 71px" class="textimage" align="left">Age</td>
                                                                                                            <td style="width: 5px" class="text5">:</td>
                                                                                                            <td style="text-align: left" class="textimage1" align="left">
                                                                                                                <asp:Label ID="lblRep1Age" runat="server" Width="130px" CssClass="textimage1" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 71px" class="textimage" align="left">Address</td>
                                                                                                            <td style="width: 5px" class="text5">:</td>
                                                                                                            <td style="text-align: left" class="textimage1" align="left">
                                                                                                                <asp:Label ID="lblRep1Address" runat="server" Width="130px" CssClass="textimage1" SkinID="Label" Height="34px" Font-Italic="False"></asp:Label></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 71px" class="textimage" align="left">Tel No.</td>
                                                                                                            <td style="width: 5px" class="text5">:</td>
                                                                                                            <td style="text-align: left" class="textimage1" align="left">
                                                                                                                <asp:Label ID="lblRep1Telephone" runat="server" Width="130px" CssClass="textimage1" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 71px" class="textimage" align="left">Cell No.</td>
                                                                                                            <td style="width: 5px" class="text5">:</td>
                                                                                                            <td style="text-align: left" class="textimage1" align="left">
                                                                                                                <asp:Label ID="lblRep1Cellphone" runat="server" Width="130px" CssClass="textimage1" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 71px" class="textimage" align="left">E. Address</td>
                                                                                                            <td style="width: 5px" class="text5">:</td>
                                                                                                            <td style="text-align: left" class="textimage1" align="left">
                                                                                                                <asp:Label ID="lblRep1Email" runat="server" Width="130px" CssClass="textimage1" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </fieldset>
                                                                                        </td>
                                                                                        <td style="width: 235px; height: 152px">
                                                                                            <fieldset style="width: 225px; height: 152px" class="PanelBorder">
                                                                                                <legend><strong><em>Personal Information</em></strong></legend>
                                                                                                <table id="tbowner2" width="230">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="width: 70px" class="textimage" align="left">Birth Date</td>
                                                                                                            <td style="width: 5px" class="text5">:</td>
                                                                                                            <td style="height: 16px" class="textimage1" align="left">
                                                                                                                <asp:Label ID="lblRep2Bday" runat="server" Width="130px" CssClass="textimage1" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 70px" class="textimage" align="left">Age</td>
                                                                                                            <td style="width: 5px" class="text5">:</td>
                                                                                                            <td class="textimage1" align="left">
                                                                                                                <asp:Label ID="lblRep2Age" runat="server" Width="130px" CssClass="textimage1" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 70px" class="textimage" align="left">Address</td>
                                                                                                            <td style="width: 5px" class="text5">:</td>
                                                                                                            <td class="textimage1" align="left">
                                                                                                                <asp:Label ID="lblRep2Address" runat="server" Width="130px" CssClass="textimage1" SkinID="Label" Height="34px" Font-Italic="False"></asp:Label></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 70px" class="textimage" align="left">Tel No.</td>
                                                                                                            <td style="width: 5px" class="text5">:</td>
                                                                                                            <td class="textimage1" align="left">
                                                                                                                <asp:Label ID="lblRep2Telephone" runat="server" Width="130px" CssClass="textimage1" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 70px" class="textimage" align="left">Cell No.</td>
                                                                                                            <td style="width: 5px" class="text5">:</td>
                                                                                                            <td class="textimage1" align="left">
                                                                                                                <asp:Label ID="lblRep2Cellphone" runat="server" Width="130px" CssClass="textimage1" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 70px" class="textimage" align="left">E. Address</td>
                                                                                                            <td style="width: 5px" class="text5">:</td>
                                                                                                            <td class="textimage1" align="left">
                                                                                                                <asp:Label ID="lblRep2Email" runat="server" Width="130px" CssClass="textimage1" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </fieldset>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>

                                                        </asp:View>
                                                        <asp:View ID="vwOccupants" runat="server">
                                                            <table style="height: 368px" width="900">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 450px; height: 245px">
                                                                            <table style="height: 364px; background-color: #c0c0c0" width="400">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="width: 216px; height: 24px; text-align: right">Building Storey No.:</td>
                                                                                        <td style="height: 24px" align="left">
                                                                                            <asp:DropDownList ID="DropDownList1" runat="server" Width="174px">
                                                                                            </asp:DropDownList></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" colspan="2">
                                                                                            <asp:Image ID="imgbuildingsketch" runat="server" Width="368px" ImageUrl="~/images/DefaultBuildingSkecth.jpg" BorderStyle="Solid" Height="310px" BorderWidth="15px" BorderColor="#c0c0c0"></asp:Image></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td style="width: 450px; height: 245px">
                                                                            <table style="height: 364px" width="450">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td align="center" colspan="2">
                                                                                            <asp:Image ID="imgbuildingfloorplan" runat="server" Width="418px" ImageUrl="~/images/DefaultBuildingfloorplan.jpg" BorderStyle="Solid" Height="344px" BorderWidth="15px" BorderColor="#c0c0c0"></asp:Image></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <asp:GridView ID="grdlistofOccupants" runat="server" Width="900px" SkinID="gvnew" DataKeyNames="DocuId" Font-Size="9pt">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="unitno" HeaderText="Unit No."></asp:BoundField>
                                                                                    <asp:BoundField DataField="occupantname" HeaderText="Occupant Name"></asp:BoundField>
                                                                                    <asp:BoundField DataField="occupbusinessname" HeaderText="Business Name"></asp:BoundField>
                                                                                    <asp:BoundField DataField="occupfloorarea" HeaderText="Floor Area"></asp:BoundField>
                                                                                    <asp:BoundField DataField="occupownership" HeaderText="Ownership"></asp:BoundField>
                                                                                    <asp:BoundField DataField="occupcategory" HeaderText="Category"></asp:BoundField>
                                                                                    <asp:BoundField DataField="occuppermittype" HeaderText="Permit Type"></asp:BoundField>
                                                                                    <asp:BoundField DataField="occuppermitno" HeaderText="Permit No."></asp:BoundField>
                                                                                    <asp:BoundField DataField="occupdateapplication" HeaderText="Date of Application"></asp:BoundField>
                                                                                    <asp:BoundField DataField="occupdatepermitissuance" HeaderText="Date of Permit Issuance"></asp:BoundField>
                                                                                    <asp:BoundField DataField="occupremarks" HeaderText="Remarks"></asp:BoundField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="vwpermitapplicationhistory" runat="server">
                                                            <asp:GridView ID="grdpermitapplicationhistory" runat="server" Width="950px" SkinID="gvnew" Font-Size="9pt">
                                                                <Columns>
                                                                    <asp:BoundField DataField="AppPermitType" HeaderText="Permit Type"></asp:BoundField>
                                                                    <asp:BoundField DataField="Applicationdate" HeaderText="Date of Application"></asp:BoundField>
                                                                    <asp:BoundField DataField="apppermitno" HeaderText="Permit No."></asp:BoundField>
                                                                    <asp:BoundField DataField="appdatepermitissuance" HeaderText="Date of Permit Issuance"></asp:BoundField>
                                                                    <asp:BoundField DataField="appremarks" HeaderText="Remarks"></asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>

                                                        </asp:View>
                                                        <asp:View ID="vwInspectionHistory" runat="server">
                                                            <asp:GridView ID="grdInspectionHistory" runat="server" Width="950px" SkinID="gvnew" Font-Size="9pt">
                                                                <Columns>
                                                                    <asp:BoundField DataField="InspectionDate" HeaderText="Date Inspection"></asp:BoundField>
                                                                    <asp:BoundField DataField="inspectiontype" HeaderText="Inspection Type"></asp:BoundField>
                                                                    <asp:BoundField DataField="missionorderno" HeaderText="Mission Order No."></asp:BoundField>
                                                                    <asp:BoundField DataField="inspector" HeaderText="Inspector"></asp:BoundField>
                                                                    <asp:BoundField DataField="violation" HeaderText="Violation"></asp:BoundField>
                                                                    <asp:BoundField DataField="insremarks" HeaderText="Remarks"></asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </asp:View>
                                                        <asp:View ID="vwPaymentHistory" runat="server">
                                                            <asp:GridView ID="grdPaymentHistory" runat="server" Width="950px" SkinID="gvnew" Font-Size="9pt">
                                                                <Columns>
                                                                    <asp:BoundField DataField="permittype" HeaderText="Permit Type"></asp:BoundField>
                                                                    <asp:BoundField DataField="permitno" HeaderText="Permit No."></asp:BoundField>
                                                                    <asp:BoundField DataField="orno" HeaderText="O.R No."></asp:BoundField>
                                                                    <asp:BoundField DataField="amount" HeaderText="Amount"></asp:BoundField>
                                                                    <asp:BoundField DataField="paymentdate" HeaderText="Payment Date"></asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </asp:View>
                                                        <asp:View ID="vwbuildingdocumentdetails" runat="server">
                                                           
                                                            
                                                  <table style="height: 236px" width="1000">
                                                    <tbody>
                                                        <tr>
                                                            <td style="vertical-align: top; width: 800px; height: 236px" align="center">
                                                                <fieldset style="border-right: #2977dc 1px solid; border-top: #2977dc 1px solid; border-left: #2977dc 1px solid; width: 700px; border-bottom: #2977dc 1px solid; height: 223px">
                                                                    <legend><span style="font-size: 11pt; font-family: Calibri"><strong><em>DOCUMENTS DETAILS</em></strong></span></legend>
                                                                    <br />
                                                                    <asp:GridView ID="grdocumentdetails" runat="server" Width="650px" SkinID="gvnew" DataKeyNames="DocuId" OnRowDataBound="grdocumentdetails_RowDataBound" PageSize="5" Font-Size="9pt">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="documentname" HeaderText="Document Name"></asp:BoundField>
                                                                            <asp:BoundField DataField="documentno" HeaderText="Document No."></asp:BoundField>
                                                                            <asp:BoundField DataField="validatedby" HeaderText="Validated By"></asp:BoundField>
                                                                            <asp:BoundField DataField="datevalidated" HeaderText="Date Validated"></asp:BoundField>
                                                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks"></asp:BoundField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </fieldset>

                                                            </td>
                                                            <td style="vertical-align: top; width: 200px; height: 236px" id="td4" align="center">
                                                                <fieldset style="height: 222px" class="PanelBorder">
                                                                    <legend><span style="font-size: 11pt; font-family: Calibri"><strong>ATTACHED DOCUMENTS</strong></span></legend>
                                                                    <asp:Image ID="ImgBuildingsacnnedDoc" runat="server" Width="204px" ImageUrl="~/images/DefaulScannedDocuments.jpg" Height="202px"></asp:Image>
                                                                </fieldset>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                        </asp:View>

                                                    </asp:MultiView></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:View>
                                <asp:View ID="vwMotorVehicle" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td align="center" class="DivTitle" style="width: 100%">
                                                <asp:Label ID="Label102" runat="server" Text="VEHICLE INFORMATION"></asp:Label>

                                            </td>
                                        </tr>
                                    </table>
                                    <asp:MultiView ID="mvVehicleInformation" runat="server">

                                        <asp:View ID="vwMotorVehicleInformation" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td class="column_RightBold" style="width: 10%">Name :

                                                    </td>
                                                    <td class="column_Left" style="width: 30%">
                                                        <asp:TextBox ID="txtVehicleName" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td class="column_RightBold" style="width: 10%">Power Input :

                                                    </td>
                                                    <td class="column_Left" style="width: 30%">
                                                        <asp:TextBox ID="txtVehiclePowerInput" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                    </td>
                                                    <td align="center" rowspan="6" style="width: 20%" valign="middle">
                                                        <asp:Image ID="Image13" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                                        <br />
                                                        <asp:Button ID="Button18" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="width: 10%">Description :

                                                    </td>
                                                    <td class="column_Left" style="width: 30%">
                                                        <asp:TextBox ID="txtVehicleDesc" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                    </td>
                                                    <td class="column_RightBold" style="width: 10%">Warranty :

                                                    </td>
                                                    <td class="column_Left" style="width: 30%">
                                                        <asp:TextBox ID="txtVehicleWarranty" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="width: 10%">Make :

                                                    </td>
                                                    <td class="column_Left" style="width: 30%">
                                                        <asp:TextBox ID="txtVehicleMake" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td class="column_RightBold" style="width: 10%">Quantity :

                                                    </td>
                                                    <td class="column_Left" style="width: 30%">
                                                        <asp:TextBox ID="txtVehicleQuantity" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="width: 10%">Type Of Vehicle :

                                                    </td>
                                                    <td class="column_Left" style="width: 30%">
                                                        <asp:TextBox ID="txtVehicleType" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td class="column_RightBold" style="width: 10%">Color :

                                                    </td>
                                                    <td class="column_Left" style="width: 30%">
                                                        <asp:TextBox ID="txtVehicleColor" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="width: 10%"></td>
                                                    <td class="column_Left" style="width: 30%"></td>

                                                    <td class="column_RightBold" style="width: 10%"></td>
                                                    <td class="column_Left" style="width: 30%">
                                                        <asp:LinkButton ID="btnAddPropertyInfo" runat="server" Text="View Property Information"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <fieldset style="width: 90%;">
                                                            <legend class="column_LeftBold">Acquisition :</legend>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td class="column_RightBold">Acquisition Date :

                                                                    </td>
                                                                    <td class="column_Left" style="width: 250px;">
                                                                        <asp:TextBox ID="txtVehicleAcqDate" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False" onchange="return NoOfYearsVehicles(this.value);"></asp:TextBox>
                                                                        <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtEAcqDate" PopupButtonID="txtEAcqDate"></cc1:CalendarExtender>


                                                                        &nbsp;(MM/DD/YYYY)</td>
                                                                    <td class="column_RightBold">Market Value :

                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtVehicleMarketValue" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>

                                                                    </td>
                                                                </tr>
                                                                <tr>

                                                                    <td class="column_RightBold">Acquisition Cost :

                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtVehicleAcqCost" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalValVehicles(this),getDepValRateVehicles(this);"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">No. of Years :

                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtVehicleNoYears" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>

                                                                    <td class="column_RightBold">Depreciated Rate :

                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtVehicleDepRate" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" MaxLength="5" Enabled="False"></asp:TextBox>&nbsp;(%) Percent

                                                                    </td>
                                                                    <td class="column_RightBold">Useful Life :

                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtVehicleUsefullife" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False" Onchange="return getDepValRateVehicles(this);"></asp:TextBox>

                                                                        &nbsp;(Years)

                                                                    </td>

                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Depreciated Value :</td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtVehiclesDepreciatedValueNew" runat="server" CssClass="txtbox_Var" Enabled="false"></asp:TextBox></td>
                                                                    <td class="column_RightBold">Salvage Value :</td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtVehicleSalvageValue" runat="server" AutoPostBack="True" CssClass="txtboxAmount" Enabled="False" Onchange="this.value=formatCurrency(this.value);" Onkeyup="javascript:this.value=Comma(this.value);" Width="85%">0.00</asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>

                                                                    <td class="column_RightBold">Depreciation Value :

                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtVehicleDepValue" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">&nbsp;</td>
                                                                    <td class="column_Left">
                                                                        &nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </fieldset>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                     <td></td>
                                                     <td></td>
                                                     <td>
                                                         <asp:Label ID="lblVehicles_Info_ID" runat="server" Text="Label" Visible="False"></asp:Label>
                                                         <asp:Label ID="lblVechicles_Property_ID" runat="server" Text="Label" Visible="False"></asp:Label>
                                                         <asp:Label ID="lblVehicle_Dtl_ID" runat="server" Text="Label" Visible="False"></asp:Label>
                                                         <asp:Label ID="lblVehicles_Item_ID" runat="server" Text="Label" Visible="False"></asp:Label>
                                                    </td>
                                                     <td> <asp:Button ID="btnEditVehicle" runat="server" Width="150px" CssClass="CSButton" Text="Edit" Enabled="false" OnClientClick="StartProgressBar();"  /></td>
                                                    </tr>

                                            </table>
                                        </asp:View>
                                        <asp:View ID="vwWatercrafInformation" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td class="column_RightBold" style="width: 10%">Name :

                                                    </td>
                                                    <td class="column_Left" style="width: 30%">

                                                        <asp:TextBox ID="txtWatercraftName" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" ReadOnly="true" Enabled="False"></asp:TextBox>
                                                    </td>

                                                    <td class="column_RightBold" style="width: 10%">Power Input :

                                                    </td>
                                                    <td class="column_Left" style="width: 30%">
                                                        <asp:TextBox ID="txtWatercraftPowerInput" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                    </td>
                                                    <td align="center" rowspan="6" style="width: 20%" valign="middle">
                                                        <asp:Image ID="imgWatercraftImage" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                                        <br />
                                                        <asp:Button ID="btnWatercraftUpload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>

                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td class="column_RightBold" style="width: 10%">Description :

                                                    </td>
                                                    <td class="column_Left" style="width: 30%">
                                                        <asp:TextBox ID="txtWatercraftDescription" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" ReadOnly="true" Enabled="False"></asp:TextBox>

                                                    </td>
                                                    <td class="column_RightBold" style="width: 10%">Warranty :

                                                    </td>
                                                    <td class="column_Left" style="width: 30%">
                                                        <asp:TextBox ID="txtWatercraftWarranty" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                    </td>

                                                </tr>
                                                <tr>


                                                    <td class="column_RightBold" style="width: 10%">Make :

                                                    </td>
                                                    <td class="column_Left" style="width: 30%">

                                                        <asp:TextBox ID="txtWatercraftMake" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td class="column_RightBold" style="width: 10%">Quantity :

                                                    </td>
                                                    <td class="column_Left" style="width: 30%">
                                                        <asp:TextBox ID="txtWatercraftQuantity" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="width: 10%">Type Of Vessel :

                                                    </td>
                                                    <td class="column_Left" style="width: 30%">
                                                        <asp:TextBox ID="txtWatercraftType" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                    </td>

                                                    <td class="column_RightBold" style="width: 10%">Color :

                                                    </td>
                                                    <td class="column_Left" style="width: 30%">
                                                        <asp:TextBox ID="txtWatercraftColor" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="width: 10%"></td>
                                                    <td class="column_Left" style="width: 30%"></td>

                                                    <td class="column_RightBold" style="width: 10%"></td>
                                                    <td class="column_Left" style="width: 30%">
                                                        <asp:LinkButton ID="lbWatercraftAddPropertyInfo" runat="server" Text="View Property Information"></asp:LinkButton>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="4">
                                                        <fieldset style="width: 90%;">
                                                            <legend class="column_LeftBold">Vessel Details :</legend>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td class="column_RightBold">MMSI :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftMMSI" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Hull Material :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftHullMaterial" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Call Sign :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftCallSign" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">No. of Mast :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftNoofMast" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">IMO # :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftImoNo" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">No of Decks :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftNoofDecks" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </fieldset>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <fieldset style="width: 90%;">
                                                            <legend class="column_LeftBold">Power & Carrying Capacity :</legend>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td class="column_RightBold">No. of Engine :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftNoofEngine" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">NRT :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftNRT" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Main Engine :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftMainEngine" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">LOA :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftLOA" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Horsepower :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftHorsePower" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Breadth:
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftBreadth" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">GRT :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWaterCraftGRT" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Carrying Capacity:
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWaterCraftCarryingCapacity" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </fieldset>

                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_OV_Motor_InfoId" runat="server" Text="Label" Visible="false"></asp:Label>
                                                        <asp:Label ID="lbl_OV_Property_ID" runat="server" Text="Label" Visible="false"></asp:Label>
                                                        <asp:Label ID="lbl_OV_MotorID" runat="server" Text="Label" Visible="false"></asp:Label>
                                                        <asp:Label ID="lbl_OV_Item_ID" runat="server" Text="Label" Visible="false"></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="4">
                                                        <fieldset style="width: 90%;">
                                                            <legend class="column_LeftBold">Acquisition :</legend>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td class="column_RightBold">Acquisition Date :

                                                                    </td>
                                                                    <td class="column_Left" style="width: 250px;">
                                                                        <asp:TextBox ID="txtWatercraftAcqDate" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                        <cc1:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtWatercraftAcqDate" PopupButtonID="txtWatercraftAcqDate"></cc1:CalendarExtender>


                                                                        &nbsp;(MM/DD/YYYY)</td>
                                                                    <td class="column_RightBold">Market Value :

                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftMarketValue" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);" Enabled="False"></asp:TextBox>

                                                                    </td>


                                                                </tr>
                                                                <tr>

                                                                    <td class="column_RightBold">Acquisition Cost :

                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftAcqCost" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);" Enabled="False"></asp:TextBox>
                                                                    </td>

                                                                    <td class="column_RightBold">No. of Years :

                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftNoYears" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                                    </td>
                                                                </tr>
                                                                <tr>

                                                                    <td class="column_RightBold">Dep. Rate :

                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftDepRate" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" MaxLength="5" Enabled="False"></asp:TextBox>&nbsp;(%) Percent

                                                                    </td>


                                                                    <td class="column_RightBold">Useful Life :

                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftUsefulLife" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                                        &nbsp;(Years)</td>

                                                                </tr>


                                                                <tr>

                                                                    <td class="column_RightBold">Dep. Value :

                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftDepValue" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>

                                                                    <td class="column_RightBold">Salvage Value :

                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtWatercraftSalvageValue" runat="server" Width="85%" AutoPostBack="True" CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);" Enabled="False">0.00</asp:TextBox>

                                                                    </td>


                                                                </tr>

                                                            </table>
                                                        </fieldset>
                                                    </td>
                                                    <td class="column_Center" style="vertical-align:bottom">

                                                        <asp:Button ID="btn_edit_other_vehicles" runat="server" CssClass="CSButton" Enabled="false" Text="Edit" Width="48%" />

                                                    </td>
                                                </tr>
                                            </table>

                                        </asp:View>
                                        <asp:View ID="vwMotorVehicleInformationDefault" runat="server">
                                            <table style="width: 1000px; text-align: center; display: none;">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 1000px" class="DivTitle">LIST OF TRANSFORMATION
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td style="width: 1000px">
                                                            <table style="width: 100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 30%" class="column_RightBold">SEARCH SERIAL NUMBER :</td>
                                                                        <td style="width: 40%" class="text5">
                                                                            <asp:TextBox ID="txtMotorSerialSearch" runat="server" Width="95%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                        <td style="width: 30%" class="text5">
                                                                            <asp:Button ID="btnMotorSerialSearch" OnClick="btnMotorSerialSearch_Click" runat="server" Width="150px" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 1000px">
                                                            <asp:GridView ID="grdlistofMotors" runat="server" Width="1000px" SkinID="GridViewAA" OnPageIndexChanging="grdlistofMotors_PageIndexChanging" AllowPaging="True" HorizontalAlign="Center" DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo,Received_Dtl_ID,Barcode" OnRowDataBound="grdlistofMotors_RowDataBound" OnSelectedIndexChanged="grdlistofMotors_SelectedIndexChanged" Font-Size="9pt">
                                                                <Columns>
                                                                    <asp:BoundField DataField="type" HeaderText="TYPE OF SERVICE">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Barcode" HeaderText="PLATE NO.">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="DatePurchased" DataFormatString="{0:d}" HeaderText="DATE PURCHASED">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="AcquisitionCost" DataFormatString="{0:N}" HeaderText="ACQUISITION COST">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="MarketValue" DataFormatString="{0:N}" HeaderText="MARKET VALUE">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Condition" HeaderText="CONDITION">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Location" HeaderText="LOCATION">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Status" HeaderText="STATUS">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 1000px" class="DivTitle">DETAILS</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 1000px">
                                                            <table style="width: 1000px">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 800px">
                                                                            <fieldset style="border-right: #2977dc 1px solid; border-top: #2977dc 1px solid; border-left: #2977dc 1px solid; width: 800px; border-bottom: #2977dc 1px solid; height: 230px">
                                                                                <table style="color: white; background-color: #c0c0c0; text-align: center" id="Table12" width="800">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 1000px; height: 16px; text-align: center"><strong><span style="color: black; font-family: Calibri">VEHICLE INFORMATION</span></strong></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                                <table id="Table8" width="800">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 50px; height: 18px" class="text5" align="right"></td>
                                                                                            <td style="width: 70px; height: 18px" class="column_LeftBold" align="right">Name</td>
                                                                                            <td style="width: 5px; height: 18px" class="text5">:</td>
                                                                                            <td style="width: 162px; height: 18px" class="text3" align="left">
                                                                                                <asp:Label ID="lblvehiclename" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 100px" class="column_LeftBold" align="right">Model</td>
                                                                                            <td style="width: 5px" class="text5" align="left">:</td>
                                                                                            <td style="width: 151px" class="text3" align="left">
                                                                                                <asp:Label ID="lblvehiclemodel" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 100px; height: 18px" class="column_LeftBold" align="right">Wheel Capacity</td>
                                                                                            <td style="width: 5px; height: 18px" class="text5">:</td>
                                                                                            <td style="width: 151px; height: 18px" class="text3">
                                                                                                <asp:Label ID="lblvehiclewheelcapacity" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 50px; height: 18px" class="text5" align="right"></td>
                                                                                            <td style="width: 70px; height: 18px" class="column_LeftBold" align="right">Plate No.</td>
                                                                                            <td style="width: 5px; height: 18px" class="text5">:</td>
                                                                                            <td style="width: 162px; height: 18px" class="text3" align="left">
                                                                                                <asp:Label ID="lblvehicleplate" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 100px" class="column_LeftBold" align="right">Chasis No.</td>
                                                                                            <td style="width: 5px" class="text5" align="left">:</td>
                                                                                            <td style="width: 151px" class="text3" align="left">
                                                                                                <asp:Label ID="lblvehiclechasisno" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 100px; height: 18px" class="column_LeftBold" align="right"><span style="font-size: 10pt">Gross <span style="line-height: 115%; mso-ascii-theme-font: minor-latin; mso-fareast-font-family: Calibri; mso-fareast-theme-font: minor-latin; mso-hansi-theme-font: minor-latin; mso-bidi-font-family: 'Times New Roman'; mso-bidi-theme-font: minor-bidi; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">Weight </span></span></td>
                                                                                            <td style="width: 5px; height: 18px" class="text5">:</td>
                                                                                            <td style="width: 151px; height: 18px" class="text3">
                                                                                                <asp:Label ID="lblvehiclegrossweight" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 50px; height: 18px" class="text5" align="right"></td>
                                                                                            <td style="width: 70px; height: 18px" class="column_LeftBold" align="right">Motor No.</td>
                                                                                            <td style="width: 5px; height: 18px" class="text5">:</td>
                                                                                            <td style="width: 162px; height: 18px" class="text3" align="left">
                                                                                                <asp:Label ID="lblvehiclemotorno" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 100px" class="column_LeftBold" align="right">Vehicle Color</td>
                                                                                            <td style="width: 5px" class="text5" align="left">:</td>
                                                                                            <td style="width: 151px" class="text3" align="left">
                                                                                                <asp:Label ID="lblvehiclecolor" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 100px; height: 18px" class="column_LeftBold" align="right">Seats</td>
                                                                                            <td style="width: 5px; height: 18px" class="text5">:</td>
                                                                                            <td style="width: 151px; height: 18px" class="text3">
                                                                                                <asp:Label ID="lblvehicleseat" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                                <table style="width: 800px">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 80px" class="text5" colspan="4">
                                                                                                <hr style="width: 798px; height: 2px" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="font-weight: bold; width: 600px; font-style: italic" class="text5" colspan="2">&nbsp; Vehicle Specification :</td>
                                                                                            <td style="font-weight: bold; width: 80px; font-style: italic" class="text5">Warranty :</td>
                                                                                            <td style="width: 120px" class="text3">
                                                                                                <asp:Label ID="lblvehiclewarranty" runat="server" CssClass="text5"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 80px" class="text3"></td>
                                                                                            <td style="width: 520px" class="text3" rowspan="2">
                                                                                                <asp:Label ID="lblvehiclespecification" runat="server" Width="510px" CssClass="text3" Height="30px"></asp:Label></td>
                                                                                            <td style="font-weight: bold; width: 80px; font-style: italic" class="text3"></td>
                                                                                            <td style="width: 120px" class="text3"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 80px" class="text3"></td>
                                                                                            <td style="font-weight: bold; width: 80px; font-style: italic" class="text3"></td>
                                                                                            <td style="width: 120px" class="text3"></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                                <table id="Table11" width="800">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 213px; height: 14px" class="column_RightBold" align="right"></td>
                                                                                            <td style="width: 7px; height: 14px" class="text4"></td>
                                                                                            <td style="width: 155px; height: 14px" class="text3" align="left"></td>
                                                                                            <td style="width: 144px; height: 14px" class="column_RightBold" align="right"></td>
                                                                                            <td style="width: 12px; height: 14px" class="text4" align="left"></td>
                                                                                            <td style="width: 173px; height: 14px" class="text3" align="left"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 213px; height: 14px" class="column_RightBold" align="right">Vehicle Owner</td>
                                                                                            <td style="width: 7px; height: 14px" class="text4">:</td>
                                                                                            <td style="width: 155px; height: 14px" class="text3" align="left">
                                                                                                <asp:Label ID="lblvehicleowner" runat="server" Width="273px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 144px; height: 14px" class="column_RightBold" align="right">Beneficial User</td>
                                                                                            <td style="width: 12px; height: 14px" class="text4" align="left">:</td>
                                                                                            <td style="width: 173px; height: 14px" class="text3" align="left">
                                                                                                <asp:Label ID="lblvehiclebeneficialuser" runat="server" Width="200px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 213px; height: 16px" class="column_RightBold" align="right">Declared Name</td>
                                                                                            <td style="width: 7px; height: 16px" class="text4">:</td>
                                                                                            <td style="width: 155px; height: 16px" class="text3" align="left">
                                                                                                <asp:Label ID="lblvehicledeclaredname" runat="server" Width="273px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                            <td style="width: 144px; height: 16px" class="column_RightBold" align="right"></td>
                                                                                            <td style="width: 12px; height: 16px" align="left"></td>
                                                                                            <td style="width: 173px; height: 16px" class="text3" align="left"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 213px" class="column_RightBold" align="right"></td>
                                                                                            <td style="width: 7px"></td>
                                                                                            <td style="width: 155px" class="text3" align="left"></td>
                                                                                            <td style="width: 144px" class="column_RightBold" align="right"></td>
                                                                                            <td style="width: 12px" align="left"></td>
                                                                                            <td style="width: 173px" class="text3" align="left"></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </fieldset>
                                                                        </td>
                                                                        <td style="width: 200px">
                                                                            <fieldset style="border-right: #2977dc 1px solid; border-top: #2977dc 1px solid; border-left: #2977dc 1px solid; width: 191px; border-bottom: #2977dc 1px solid; height: 230px">
                                                                                <table>
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 191px; height: 160px" class="textimage2" colspan="2">
                                                                                                <asp:Image ID="Image5" runat="server" Width="151px" ImageUrl="~/images/blankImage.jpg" CssClass="textimage2" Height="124px" ImageAlign="Middle"></asp:Image></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 80px" class="textimage2">Date Taken:</td>
                                                                                            <td style="width: 111px" class="textimage2">
                                                                                                <asp:Label ID="lblMotorDateTaken" runat="server" Width="110px" CssClass="textimage2" BorderStyle="Solid" BorderWidth="1px"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 80px" class="textimage2">Uploaded By:</td>
                                                                                            <td style="width: 111px" class="textimage2">
                                                                                                <asp:Label ID="lblMotorUploadedBy" runat="server" Width="110px" CssClass="textimage2" BorderStyle="Solid" BorderWidth="1px"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 80px" class="textimage2">Position:</td>
                                                                                            <td style="width: 111px" class="textimage2">
                                                                                                <asp:Label ID="lblMotorPosition" runat="server" Width="110px" CssClass="textimage2" BorderStyle="Solid" BorderWidth="1px"></asp:Label></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 1000px" class="text5">
                                                            <table cellspacing="0" cellpadding="0" width="1000" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 66px; height: 26px">
                                                                            <asp:Button ID="btnvehicleledger" runat="server" Width="77px" CssClass="Initial" Text="Ledger"></asp:Button></td>
                                                                        <td style="width: 180px; height: 26px">
                                                                            <asp:Button ID="btnvehiclerepairs" runat="server" Width="180px" CssClass="Initial" Text="Repairs and Maintenance"></asp:Button></td>
                                                                        <td style="width: 129px; height: 26px">
                                                                            <asp:Button ID="btnvehicledocattach" runat="server" Width="140px" CssClass="Initial" Text="Document Attached"></asp:Button></td>
                                                                        <td style="width: 324px; height: 26px"></td>
                                                                        <td style="width: 325px; height: 26px"></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>

                                </asp:View>
                                <asp:View ID="vwEquipment" runat="server">
                                    <table style="width: 1000px; text-align: center">
                                        <tbody>
                                            <tr>
                                                <td style="width: 1000px" class="DivTitle">LIST OF EQUIPMENTS

                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="width: 1000px">
                                                    <table style="width: 100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 30%" class="column_RightBold">SEARCH SERIAL NUMBER :

                                                                </td>
                                                                <td style="width: 40%" class="text5">
                                                                    <asp:TextBox ID="txtSerialSearch" runat="server" Width="95%" CssClass="txtboxinspection"></asp:TextBox>

                                                                </td>
                                                                <td style="width: 30%" class="text5">
                                                                    <asp:Button ID="btnEquipmentSerialSearch" OnClick="btnSerialSearch_Click" runat="server" Width="150px" Text="SEARCH" OnClientClick="StartProgressBar();" CssClass="CSButton"></asp:Button>

                                                                </td>

                                                            </tr>

                                                        </tbody>

                                                    </table>

                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="width: 1000px">
                                                    <asp:GridView ID="grdlistofEuipment" runat="server" Width="1000px" SkinID="GridViewAA" OnPageIndexChanging="grdlistofEuipment_PageIndexChanging" AllowPaging="True" HorizontalAlign="Center" DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo,Received_ID,AcquisitionCost,Received_Date,Date_Accepted,useful_life,Received_Dtl_ID,barcode" OnRowDataBound="grdlistofEuipment_RowDataBound" OnSelectedIndexChanged="grdlistofEuipment_SelectedIndexChanged" OnDataBound="grdlistofEuipment_ondatabound" Font-Size="9pt">
                                                        <Columns>
                                                            <asp:BoundField DataField="PropertyNo" HeaderText="">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Type" HeaderText="">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" Width="40%"></ItemStyle>
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="barcode" HeaderText="SERIAL NO." Visible="false">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>


                                                            <asp:BoundField DataField="FloorLocation" DataFormatString="{0:d}" HeaderText="Floor" Visible="false">
                                                                <HeaderStyle HorizontalAlign="Center" CssClass="d-none"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="RoomLocation" DataFormatString="{0:d}" HeaderText="Room" Visible="false">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Warranty" DataFormatString="{0:N}" HeaderText="Room">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Right" Width="12%"></ItemStyle>
                                                            </asp:BoundField>
                                                           
                                                            <asp:BoundField DataField="MaintenanceContractor" HeaderText="Contractor">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%"></ItemStyle>
                                                            </asp:BoundField>
                                                        
                                                            <asp:BoundField DataField="MaintenanceContactPerson" HeaderText="Contact Person">
                                                                <ItemStyle HorizontalAlign="Right" Width="11%"></ItemStyle>
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="MaintenanceContactNo" HeaderText="Cellphone No.">
                                                                <ItemStyle HorizontalAlign="Right" Width="11%"></ItemStyle>
                                                            </asp:BoundField>

                                                        </Columns>
                                                    </asp:GridView>


                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:MultiView ID="mvEquipment" runat="server">
                                                        <asp:View ID="vwDefault" runat="server">

                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td align="center" class="DivTitle" style="width: 100%" colspan="5">
                                                                        <asp:Label ID="Label101" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 10%; height: 23px;">Name :

                                                                    </td>
                                                                    <td class="column_Left" style="width: 30%; height: 23px;">

                                                                        <asp:Label ID="lblDefaultEquipmentName" runat="server" Visible="false" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>

                                                                        <asp:TextBox ID="txtDefaultEquipmentName" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>

                                                                    </td>

                                                                    <td class="column_RightBold" style="width: 10%; height: 23px;">Unit :

                                                                    </td>
                                                                    <td class="column_Left" style="width: 30%; height: 23px;">

                                                                        <asp:Label ID="lblDefaultEquipmentUnit" runat="server" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                        <asp:DropDownList ID="drpEquipmentUnit" runat="server" CssClass="drpdownCSS" Width="75px" Enabled="False"></asp:DropDownList>
                                                                        <span class="column_RightBold">Quantity :</span>
                                                                        <asp:Label ID="lblDefaultEquipmentQuantity" runat="server" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                        <asp:TextBox ID="txtDefaultEquipmentQuantity" runat="server" CssClass="txtbox_Var" Width="75px" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center" rowspan="6" style="width: 20%" valign="middle">
                                                                        <asp:Image ID="Image12" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                                                        <br />
                                                                        <asp:Button ID="Button15" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 10%">Description :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 30%">
                                                                        <asp:Label ID="lblDefaultEquipmentDescription" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="False"></asp:Label>
                                                                        <asp:TextBox ID="txtDefaultEquipmentDescription" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold" style="width: 10%">Warranty :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 30%">
                                                                        <asp:Label ID="lblDefaultEquipmentWarranty" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                        <asp:TextBox ID="txtDefaultEquipmentWarranty" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 10%">Power Input :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 30%">
                                                                        <asp:Label ID="lblDefaultEquipmentPowerInput" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="False"></asp:Label>
                                                                        <asp:TextBox ID="txtDefaultEquipmentPowerInput" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                                                                   
                                                                        </td>
                                                                    <td class="column_RightBold">Installed At :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:Label ID="lblDefaultEquipmentInstalledAt" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="False"></asp:Label>
                                                                        <asp:DropDownList ID="drpEquipmentInstalledBuilding" runat="server" Enabled="False"></asp:DropDownList>
                                                                    </td>
                                                                    <td class="column_RightBold" style="width: 10%; display: none;">Area Capacity :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 30%; display: none;">
                                                                        <asp:Label ID="lblDefaultEquipmentAreaCapacity" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                        <asp:TextBox ID="txtDefaultEquipmentAreaCapacity" runat="server" Width="290px" CssClass="txtbox_Var"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 10%">Model :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 30%">
                                                                        <asp:Label ID="lblDefaultEquipmentModel" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                        <asp:TextBox ID="txtDefaultEquipmentModel" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                                                                    </td>

                                                                    <td class="column_RightBold" style="width: 10%">Dimension :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 30%">
                                                                        <asp:Label ID="lblDefaultEquipmentDimension" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="False"></asp:Label>
                                                                        <asp:TextBox ID="txtDefaultEquipmentDimension" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                                                                    </td>

                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 10%">Serial Number :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 30%">
                                                                        <asp:Label ID="lblDefaultEquipmentSerialNumber" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="False"></asp:Label>
                                                                        <asp:TextBox ID="txtDefaultEquipmentSerialNumber" runat="server" CssClass="txtbox_Var" Width="290px" Enabled="False"></asp:TextBox>
                                                                        </td>
                                                                    <td></td>
                                                                    <td class="column_Left"></td>

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
                                                                                        <asp:Label ID="lblDefaultEquipmentContractor" runat="server" Width="75%" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                        <asp:TextBox ID="txtDefaultEquipmentContractor" runat="server" CssClass="txtbox_Var" Width="75%" Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                    <td class="column_RightBold">Contact Person : 
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:Label ID="lblDefaultEquipmentContactPerson" runat="server" Width="75%" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                        <asp:TextBox ID="txtDefaultEquipmentContactPerson" runat="server" CssClass="txtbox_Var" Width="75%" Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                    <td class="column_RightBold">Cellphone No. : 
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:Label ID="lblDefaultEquipmentContactNo" runat="server" Width="75%" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                        <asp:TextBox ID="txtDefaultEquipmentContactNo" runat="server" CssClass="txtbox_Var" Width="75%" Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4">
                                                                        <fieldset style="width: 93%;">
                                                                            <legend class="column_LeftBold">Acquisition :</legend>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td class="column_RightBold" style="width:15%">Acquisition Date :
                                                                                    </td>
                                                                                    <td class="column_Left" style="width: 25%">
                                                                                        <asp:Label ID="lblDefaultEquipmentAcquisitionDate" runat="server" Visible="false"></asp:Label>
                                                                                        <asp:TextBox ID="txtDefaultEquipmentAcquisitionDate" runat="server" CssClass="txtbox_Var" Width="100px" Enabled="False" onchange="return NoOfYearsEquipment(this.value);"></asp:TextBox>
                                                                                        <cc1:CalendarExtender ID="CalendarExtender15" runat="server" TargetControlID="txtDefaultEquipmentAcquisitionDate" PopupButtonID="txtDefaultEquipmentAcquisitionDate"></cc1:CalendarExtender>
                                                                                        &nbsp;(MM/DD/YYYY)</td>
                                                                                    <td class="column_RightBold" style="width: 25%">Market Value :

                                                                                    </td>
                                                                                    <td class="column_Left" style="width: 25%">
                                                                                        <asp:Label ID="lblDefaultEquipmentMarketValue" runat="server" Visible="false"></asp:Label>
                                                                                        <asp:TextBox ID="txtDefaultEquipmentMarketValue" runat="server" CssClass="txtbox_Var" Width="150px" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>

                                                                                    </td>


                                                                                </tr>
                                                                                <tr>

                                                                                    <td class="column_RightBold">Acquisition Cost :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:Label ID="lblDefaultEquipmentAcquisitionCost" runat="server" Visible="false"></asp:Label>
                                                                                        <asp:TextBox ID="txtDefaultEquipmentAcquisitionCost" runat="server" CssClass="txtbox_Var" Width="150px" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalValEquipment(this),getDepValRateEquipment(this);"></asp:TextBox>
                                                                                    </td>

                                                                                    <td class="column_RightBold">No. of Years :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:Label ID="lblDefaultEquipmentNoYears" runat="server" Visible="False"></asp:Label>
                                                                                        <asp:TextBox ID="txtDefaultEquipmentNoYears" runat="server" CssClass="txtbox_Var" Width="100px" Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>

                                                                                    <td class="column_RightBold">Depreciated Rate :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:Label ID="lblDefaultEquipmentDepRate" runat="server" Visible="False"></asp:Label>
                                                                                        <asp:TextBox ID="txtDefaultEquipmentDepRate" runat="server" CssClass="txtbox_Var" Width="150px" Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                    <td class="column_RightBold">Useful Life :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:Label ID="lblDefaultEquipmentUsefulLife" runat="server" Visible="False"></asp:Label>
                                                                                        <asp:TextBox ID="txtDefaultEquipmentUsefulLife" runat="server" CssClass="txtbox_Var" Width="100px" Enabled="False" onchange="return getDepValRateEquipment(this);"></asp:TextBox>
                                                                                        &nbsp;(Years)</td>

                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="column_RightBold">Depreciated Value :</td>
                                                                                      <td class="column_Left"><asp:TextBox ID="txtDepreciatedValueEquipmentNew" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                                                                      <td class="column_RightBold">Salvage Value :</td>
                                                                                      <td class="column_Left">
                                                                                          <asp:Label ID="lblDefaultEquipmentSalvageValue" runat="server" Font-Italic="False" SkinID="Label" Visible="false"></asp:Label>
                                                                                          <asp:TextBox ID="txtDefaultEquipmentSalvageValue" runat="server" CssClass="txtbox_Var" Enabled="False" Onchange="this.value=formatCurrency(this.value);" Onkeyup="javascript:this.value=Comma(this.value);" Width="150px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>

                                                                                    <td class="column_RightBold">Depreciation Value :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:Label ID="lblDefaultEquipmentDepValue" runat="server" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                        <asp:TextBox ID="txtDefaultEquipmentDepValue" runat="server" CssClass="txtbox_Var" Width="150px" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                                                    </td>

                                                                                    <td class="column_RightBold">&nbsp;</td>
                                                                                    <td class="column_Left">
                                                                                        &nbsp;</td>


                                                                                </tr>

                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                                <tr style="display: none">
                                                                    <td colspan="4">
                                                                        <fieldset style="width: 90%;">
                                                                            <legend class="column_Left" style="font-family: Arial; color: #404040;"><strong>Location:</strong></legend>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td class="column_RightBold">Warehouse :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:DropDownList ID="DropDownList17" runat="server" Width="98%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                                                    </td>

                                                                                    <td class="column_RightBold">Bay :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="TextBox32" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                                        <asp:DropDownList ID="DropDownList18" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                                    </td>

                                                                                    <td class="column_RightBold" style="width: 15%">Column :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="TextBox33" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                                        <asp:DropDownList ID="DropDownList19" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                                    </td>

                                                                                    <td class="column_RightBold" style="width: 10%">Floor :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="TextBox34" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                                        <asp:DropDownList ID="DropDownList20" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="column_RightBold">Room :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="TextBox35" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                                        <asp:DropDownList ID="DropDownList21" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                                    </td>

                                                                                    <td class="column_RightBold" style="width: 10%">Shelves :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="TextBox36" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                                        <asp:DropDownList ID="DropDownList22" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                                    </td>

                                                                                    <td class="column_RightBold">Rack :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="TextBox37" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                                        <asp:DropDownList ID="DropDownList23" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                                    </td>

                                                                                    <td class="column_RightBold">Bin :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="TextBox38" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                        <asp:DropDownList ID="DropDownList24" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                                    </td>
                                                                                </tr>

                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 10%">Specifications :
                                                                    </td>
                                                                    <td class="column_Left" colspan="3">
                                                                        <asp:Label ID="lblDefaultEquipmentSpecifications" runat="server" CssClass="text3" Visible="false"></asp:Label>
                                                                        <asp:TextBox ID="txtDefaultEquipmentSpecifications" runat="server" CssClass="txtbox_Var" Width="200px" Enabled="false"></asp:TextBox>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                                                    <td class="column_RightBold" colspan="3">
                                                                        <asp:Label ID="lbl_Equipment_EquipInfoId" runat="server" Text="Label" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lbl_Equipment_EquipmentId" runat="server" Text="Label"  Visible="false"></asp:Label>
                                                                        <asp:Label ID="lbl_Equipment_PropertyDetai_ID" runat="server" Text="Label"  Visible="false"></asp:Label>
                                                                        <asp:Label ID="lbl_Equipment_Property_ID" runat="server" Text="Label"  Visible="false"></asp:Label>
                                                                        <asp:Label ID="lbl_Equipment_Item_ID" runat="server" Text="Label"  Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td class="column_Center">
                                                                        <asp:Button ID="btn_Edit_Equipment" runat="server" Width="75%" CssClass="CSButton" Text="Edit"  OnClientClick="StartProgressBar();"></asp:Button>
                                                                        
                                                                    </td>
                                                                </tr>
                                                            </table>

                                                        </asp:View>
                                                        <asp:View ID="vwDefaultEquipment" runat="server">

                                                            <table>
                                                                <tr>
                                                                    <td style="width: 1000px" class="DivTitle">DETAILS
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 1000px">
                                                                        <table style="width: 100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 80%">
                                                                                        <fieldset style="width: 800px; height: 280px" class="PanelBorder">
                                                                                            <table style="color: white; background-color: #c0c0c0; text-align: center" id="Table15" width="800">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td style="width: 1000px; height: 15px; text-align: center">
                                                                                                            <strong>
                                                                                                                <span style="color: black; font-family: Calibri">EQUIPMENT INFORMATION

                                                                                                                </span>

                                                                                                            </strong>

                                                                                                        </td>

                                                                                                    </tr>

                                                                                                </tbody>

                                                                                            </table>
                                                                                            <table id="Table16" width="800">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td style="width: 40px" class="text5" align="right"></td>
                                                                                                        <td style="width: 115px; height: 18px" class="column_LeftBold" align="right">Name

                                                                                                        </td>
                                                                                                        <td style="width: 5px; height: 16px" class="text4">:

                                                                                                        </td>
                                                                                                        <td style="width: 265px" class="text3" align="left">
                                                                                                            <asp:Label ID="lblequipmentname" runat="server" Width="200px" CssClass="text3" SkinID="Label" Font-Italic="False">

                                                                                                            </asp:Label>

                                                                                                        </td>
                                                                                                        <td style="width: 130px; height: 18px" class="column_LeftBold" align="right">Dimension 

                                                                                                        </td>
                                                                                                        <td style="width: 5px; height: 16px" class="text4" align="left">:

                                                                                                        </td>
                                                                                                        <td style="width: 240px" class="text3" align="left">
                                                                                                            <asp:Label ID="lblequipmentdimension" runat="server" Width="230px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label>

                                                                                                        </td>

                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 40px" class="text5" align="right"></td>
                                                                                                        <td style="width: 115px; height: 18px" class="column_LeftBold" align="right">Description

                                                                                                        </td>
                                                                                                        <td style="width: 5px; height: 16px" class="text4">:

                                                                                                        </td>
                                                                                                        <td style="width: 265px" class="text3" align="left" rowspan="2">
                                                                                                            <asp:Label ID="lblequipmentdesciption" runat="server" Width="260px" CssClass="text3" SkinID="Label" Height="32px" Font-Italic="False"></asp:Label>

                                                                                                        </td>
                                                                                                        <td style="width: 130px; height: 18px" class="column_LeftBold" align="right">Area Capacity

                                                                                                        </td>
                                                                                                        <td style="width: 5px; height: 16px" class="text4" align="left">:

                                                                                                        </td>
                                                                                                        <td style="width: 240px" class="text3" align="left">
                                                                                                            <asp:Label ID="lblequipmentareacapacity" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label>

                                                                                                        </td>

                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 40px" class="text5" align="right"></td>
                                                                                                        <td style="width: 115px; height: 18px" class="column_LeftBold" align="right"></td>
                                                                                                        <td style="width: 5px; height: 16px" class="text4"></td>
                                                                                                        <td style="width: 130px; height: 18px" class="column_LeftBold" align="right">Model 

                                                                                                        </td>
                                                                                                        <td style="width: 5px; height: 16px" class="text4" align="left">:

                                                                                                        </td>
                                                                                                        <td style="width: 240px" class="text3" align="left">
                                                                                                            <asp:Label ID="lblequipmentmodel" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label>

                                                                                                        </td>

                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 40px" class="text5" align="right"></td>
                                                                                                        <td style="width: 115px; height: 18px" class="column_LeftBold" align="right">Power Input

                                                                                                        </td>
                                                                                                        <td style="width: 5px; height: 16px" class="text4">:

                                                                                                        </td>
                                                                                                        <td style="width: 265px" class="text3" align="left">
                                                                                                            <asp:Label ID="lblequipmentpowerinput" runat="server" Width="200px" CssClass="text3" SkinID="Label" Font-Italic="False">

                                                                                                            </asp:Label>

                                                                                                        </td>
                                                                                                        <td style="width: 130px; height: 18px" class="column_LeftBold" align="right">Warranty 

                                                                                                        </td>
                                                                                                        <td style="width: 5px; height: 16px" class="text4" align="left">:

                                                                                                        </td>
                                                                                                        <td style="width: 240px" class="text3" align="left">
                                                                                                            <asp:Label ID="lblequipmentwaranty" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label>

                                                                                                        </td>

                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 40px" class="text5" align="right"></td>
                                                                                                        <td style="width: 115px; height: 18px" class="column_LeftBold" align="right">Depreciation Rate

                                                                                                        </td>
                                                                                                        <td style="width: 5px; height: 16px" class="text4">:

                                                                                                        </td>
                                                                                                        <td style="width: 265px" class="text3" align="left">
                                                                                                            <asp:TextBox ID="lblequipmentdepreciatedRate" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" MaxLength="5" ReadOnly="True" OnTextChanged="lblequipmentdepreciatedRate_TextChanged"></asp:TextBox>
                                                                                                            (<strong>
                                                                    %) Percent

                                                                                                            </strong>

                                                                                                        </td>
                                                                                                        <td style="width: 130px; height: 18px" class="column_LeftBold" align="right">Depreciated Value

                                                                                                        </td>
                                                                                                        <td style="width: 5px; height: 16px" class="text4" align="left">:

                                                                                                        </td>
                                                                                                        <td style="width: 240px" class="text3" align="left">
                                                                                                            <asp:Label ID="lblequipmentdepreciatedvalue" runat="server" Width="150px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label>

                                                                                                        </td>

                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 40px" class="text5" align="right"></td>
                                                                                                        <td style="width: 115px; height: 18px" class="column_LeftBold" align="right">
                                                                                                            <span style="color: #222222">Salvage Value

                                                                                                            </span>

                                                                                                        </td>
                                                                                                        <td style="width: 5px; height: 16px" class="text4">:

                                                                                                        </td>
                                                                                                        <td style="width: 265px" class="text3" align="left">
                                                                                                            <asp:TextBox ID="txtSalvageValue" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" OnTextChanged="txtSalvageValue_TextChanged">
                                                                    0.00

                                                                                                            </asp:TextBox>

                                                                                                        </td>
                                                                                                        <td style="width: 130px; height: 18px" class="column_LeftBold" align="right">No. of Years

                                                                                                        </td>
                                                                                                        <td style="width: 5px; height: 16px" class="text4" align="left">:

                                                                                                        </td>
                                                                                                        <td style="width: 240px" class="text3" align="left">
                                                                                                            <asp:Label ID="lblNoYears" runat="server">
                                                                                                            </asp:Label>

                                                                                                        </td>

                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 40px" class="text5" align="right"></td>
                                                                                                        <td style="width: 115px; height: 18px" class="column_LeftBold" align="right">Useful Life

                                                                                                        </td>
                                                                                                        <td style="width: 5px; height: 16px" class="text4">:

                                                                                                        </td>
                                                                                                        <td style="width: 265px" class="text3" align="left">
                                                                                                            <asp:Label ID="lblUsefulLife" runat="server"></asp:Label>
                                                                                                            Years

                                                                                                        </td>
                                                                                                        <td style="width: 130px; height: 18px" class="column_LeftBold" align="right"></td>
                                                                                                        <td style="width: 5px; height: 16px" class="text4" align="left"></td>
                                                                                                        <td style="width: 240px" class="text3" align="left"></td>

                                                                                                    </tr>

                                                                                                </tbody>

                                                                                            </table>
                                                                                            <table id="Table17" width="800">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td style="font-weight: bold; font-style: italic; height: 15px" class="text5" align="right" colspan="2">
                                                                                                            <hr style="height: 1px" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="font-weight: bold; width: 200px; font-style: italic; height: 15px" class="text5" align="right">&nbsp; Equipment Specifications :

                                                                                                        </td>
                                                                                                        <td style="width: 600px" class="text3" align="right" rowspan="2">
                                                                                                            <asp:Label ID="lblSpecification" runat="server" Width="580px" CssClass="text3" Height="30px">

                                                                                                            </asp:Label>

                                                                                                        </td>

                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="font-weight: bold; width: 200px; font-style: italic; height: 15px" class="text5" align="right"></td>

                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </fieldset>
                                                                                    </td>
                                                                                    <td style="width: 20%">
                                                                                        <fieldset style="width: 191px; height: 280px" class="PanelBorder">
                                                                                            <table>
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td style="width: 191px; height: 20px" class="textimage2" colspan="2"></td>

                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 191px; height: 20px" class="textimage2" colspan="2"></td>

                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 191px; height: 141px" class="textimage2" colspan="2">
                                                                                                            <asp:Image ID="Image3" runat="server" Width="151px" ImageUrl="~/images/blankImage.jpg" CssClass="textimage2" Height="124px" ImageAlign="Middle"></asp:Image>

                                                                                                        </td>

                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 80px" class="textimage2">Date Taken:

                                                                                                        </td>
                                                                                                        <td style="width: 111px" class="textimage2">
                                                                                                            <asp:Label ID="lblEquipDateTaken" runat="server" Width="110px" CssClass="textimage2" BorderStyle="Solid" BorderWidth="1px"></asp:Label>

                                                                                                        </td>

                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 80px" class="textimage2">Uploaded By:

                                                                                                        </td>
                                                                                                        <td style="width: 111px" class="textimage2">
                                                                                                            <asp:Label ID="lblEquipUploadedBy" runat="server" Width="110px" CssClass="textimage2" BorderStyle="Solid" BorderWidth="1px"></asp:Label>

                                                                                                        </td>

                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 80px" class="textimage2">Position:

                                                                                                        </td>
                                                                                                        <td style="width: 111px" class="textimage2">
                                                                                                            <asp:Label ID="lblEquipPosition" runat="server" Width="110px" CssClass="textimage2" BorderStyle="Solid" BorderWidth="1px"></asp:Label>

                                                                                                        </td>

                                                                                                    </tr>

                                                                                                </tbody>

                                                                                            </table>

                                                                                        </fieldset>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 1000px" class="text5">
                                                                                        <table cellspacing="0" cellpadding="0" width="1000" border="0">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td style="width: 66px; height: 26px">
                                                                                                        <asp:Button ID="btnEquipmentLedger" runat="server" Width="66px" CssClass="Initial" Text="Ledger"></asp:Button>

                                                                                                    </td>
                                                                                                    <td style="width: 156px; height: 26px">
                                                                                                        <asp:Button ID="btnequipmentrepairs" runat="server" Width="180px" CssClass="Initial" Text="Repairs and Maintenance"></asp:Button>

                                                                                                    </td>
                                                                                                    <td style="width: 129px; height: 26px">
                                                                                                        <asp:Button ID="btnequipmentattachdoc" runat="server" Width="140px" CssClass="Initial" Text="Document Attached"></asp:Button>

                                                                                                    </td>
                                                                                                    <td style="width: 324px; height: 26px"></td>
                                                                                                    <td style="width: 325px; height: 26px"></td>

                                                                                                </tr>

                                                                                            </tbody>

                                                                                        </table>

                                                                                    </td>

                                                                                </tr>

                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>

                                                        </asp:View>
                                                        <asp:View ID="vwOfficeEquipment" runat="server">
                                                            <table width="1000px">
                                                                <tr>
                                                                    <td align="center" class="DivTitle" style="width: 100%">
                                                                        <asp:Label ID="Label116" runat="server" Text="OFFICE EQUIPMENT INFORMATION"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="width: 100%">
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td class="column_RightBold" style="width: 10%">Name :

                                                                                </td>
                                                                                <td class="column_Left" style="width: 30%">

                                                                                    <asp:Label ID="lblOfficeEquipmentName" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                    <asp:TextBox ID="txtOfficeEquipmentName" runat="server" Width="290px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                <td class="column_RightBold" style="width: 10%">Unit :

                                                                                </td>
                                                                                <td class="column_Left" style="width: 30%">
                                                                                    <asp:Label ID="lblOfficeEquipmentUnit" runat="server" Width="100px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                    <asp:DropDownList ID="drpOfficeEquipmentUnit" runat="server" CssClass="drpdownCSS" Width="100px" Enabled="False">
                                                                                    </asp:DropDownList>
                                                                                    <span class="column_RightBold">Quantity :</span>
                                                                                    <asp:Label ID="lblOfficeEquipmentQuantity" runat="server" Width="100px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                    <asp:TextBox ID="txtOfficeEquipmentQuantity" runat="server" Width="100px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                </td>
                                                                                <td align="center" rowspan="6" style="width: 20%" valign="middle">
                                                                                    <asp:Image ID="Image11" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                                                                    <br />
                                                                                    <asp:Button ID="Button10" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>

                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="column_RightBold" style="width: 10%">Description :

                                                                                </td>
                                                                                <td class="column_Left" style="width: 30%">
                                                                                    <asp:Label ID="lblOfficeEquipmentDesc" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                    <asp:TextBox ID="txtOfficeEquipmentDesc" runat="server" Width="290px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                </td>
                                                                                <td class="column_RightBold" style="width: 10%">Warranty :

                                                                                </td>
                                                                                <td class="column_Left" style="width: 30%">
                                                                                    <asp:Label ID="lblOfficeEquipmentWarranty" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                    <asp:TextBox ID="txtOfficeEquipmentWarranty" runat="server" Width="290px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="column_RightBold" style="width: 10%">Power Input :

                                                                                </td>
                                                                                <td class="column_Left" style="width: 30%">
                                                                                    <asp:Label ID="lblOfficeEquipmentPowerInput" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                    <asp:TextBox ID="txtOfficeEquipmentPowerInput" runat="server" Width="290px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                </td>
                                                                                <td class="column_RightBold">Installed At :
                                                                                </td>
                                                                                <td class="column_Left">
                                                                                    <asp:Label ID="lblOfficeEquipmentInstalledat" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                    <asp:DropDownList ID="drpOfficeEquipmentBuilding" runat="server" CssClass="drpdownCSS" Width="290px" Enabled="False">
                                                                                    </asp:DropDownList>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td class="column_RightBold" style="width: 10%">Model :

                                                                                </td>
                                                                                <td class="column_Left" style="width: 30%">
                                                                                    <asp:Label ID="lblOfficeEquipmentModel" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                    <asp:TextBox ID="txtOfficeEquipmentModel" runat="server" Width="290px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                </td>

                                                                                <td class="column_RightBold" style="width: 10%">Dimension :

                                                                                </td>
                                                                                <td class="column_Left" style="width: 30%">
                                                                                    <asp:Label ID="lblOfficeEquipmentDimension" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                    <asp:TextBox ID="txtOfficeEquipmentDimension" runat="server" Width="290px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td class="column_RightBold" style="width: 10%">Serial Number :

                                                                                </td>
                                                                                <td class="column_Left" style="width: 30%">
                                                                                    <asp:Label ID="lblOfficeEquipmentSerialNo" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                    <asp:TextBox ID="txtOfficeEquipmentSerialNo" runat="server" Width="290px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                </td>
                                                                                <td></td>
                                                                                <td class="column_Left">
                                                                                    <asp:LinkButton ID="btnviewpropertyinfo" runat="server" Text="View Property Information"></asp:LinkButton>

                                                                                </td>

                                                                            </tr>
                                                                            <tr style="display: none">
                                                                                <td class="column_RightBold" style="width: 10%;">Area Capacity :
                                                                                </td>
                                                                                <td class="column_Left" style="width: 30%">
                                                                                    <asp:Label ID="Label108" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                    <asp:TextBox ID="txtequipmentareacapacity" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
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
                                                                                                    <asp:Label ID="lblOfficeEquipmentContractor" runat="server" Width="100px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                                    <asp:TextBox ID="txtOfficeEquipmentContractor" runat="server" Width="100px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                                </td>
                                                                                                <td class="column_RightBold">Contact Person : 
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:Label ID="lblOfficeEquipmentContactPerson" runat="server" Width="100px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                                    <asp:TextBox ID="txtOfficeEquipmentContactPerson" runat="server" Width="100px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                                </td>
                                                                                                <td class="column_RightBold">Cellphone No. : 
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:Label ID="lblOfficeEquipmentContactNo" runat="server" Width="100px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                                    <asp:TextBox ID="txtOfficeEquipmentContactNo" runat="server" Width="100px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </fieldset>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4">
                                                                                    <fieldset style="width: 93%;">
                                                                                        <legend class="column_LeftBold">Acquisition :</legend>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td class="column_RightBold" style="width: 15%;">Acquisition Date :
                                                                                                </td>
                                                                                                <td class="column_Left" style="width: 25%;">
                                                                                                    <asp:Label ID="lblOfficeEquipmentAcqDate" runat="server" Visible="false"></asp:Label>
                                                                                                    <asp:TextBox ID="txtOfficeEquipmentAcqDate" runat="server" CssClass="txtbox_Var" Width="100px" Enabled="False" onchange="return NoOfYearsOfficeEquipment(this.value);"></asp:TextBox>
                                                                                                    &nbsp;(MM/DD/YYYY)

                                                                                                </td>
                                                                                                <td class="column_RightBold" style="width: 25%;">Market Value :

                                                                                                </td>
                                                                                                <td class="column_Left" style="width: 25%;">
                                                                                                    <asp:Label ID="lblOfficeEquipmentMarketValue" runat="server" Visible="false"></asp:Label>

                                                                                                    <asp:TextBox ID="txtOfficeEquipmentMarketValue" runat="server" CssClass="txtbox_Var" Width="100px" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>

                                                                                                </td>


                                                                                            </tr>
                                                                                            <tr>

                                                                                                <td class="column_RightBold">Acquisition Cost :
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:Label ID="lblOfficeEquipmentAcqCost" runat="server" Visible="false"></asp:Label>
                                                                                                    <asp:TextBox ID="txtOfficeEquipmentAcqCost" runat="server" CssClass="txtbox_Var" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalValOfficeEquipment(this),getDepValRateOfficeEquipment(this);"></asp:TextBox>
                                                                                                </td>

                                                                                                <td class="column_RightBold">No. of Years :
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:Label ID="lblOfficeEquipmentNoYears" runat="server" Visible="false"></asp:Label>

                                                                                                    <asp:TextBox ID="txtOfficeEquipmentNoYears" runat="server" CssClass="txtbox_Var" Width="100px" Enabled="False"></asp:TextBox>

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>

                                                                                                <td class="column_RightBold">Depreciated Rate :
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:Label ID="lblOfficeEquipmentDepRate" runat="server" Visible="false"></asp:Label>
                                                                                                    <asp:TextBox ID="txtOfficeEquipmentDepRate" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                                                                    <td class="column_RightBold">Useful Life :
                                                                                                    </td>
                                                                                                    <td class="column_Left">
                                                                                                        <asp:Label ID="lblOfficeEquipmentUsefulLife" runat="server" Visible="false"></asp:Label>
                                                                                                        <asp:TextBox ID="txtOfficeEquipmentUsefulLife" runat="server" CssClass="txtbox_Var" Width="100px" Enabled="False" onchange="return getDepValRateOfficeEquipment(this);"></asp:TextBox>
                                                                                                        &nbsp;(Years)
                                                                                                    </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td class="column_RightBold">Depreciated Value :</td>
                                                                                                <td class="column_Left"><asp:TextBox ID="txtDepreciatedValueOfficeEquipmentNew" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                                                                                <td class="column_RightBold">Salvage Value :</td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:Label ID="lblOfficeEquipmentSalvageValue" runat="server" Font-Italic="False" SkinID="Label" Visible="false" Width="100px"></asp:Label>
                                                                                                    <asp:TextBox ID="txtOfficeEquipmentSalvageValue" runat="server" CssClass="txtbox_Var" Enabled="False" Onchange="this.value=formatCurrency(this.value);" Onkeyup="javascript:this.value=Comma(this.value);" Width="100px"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>

                                                                                                <td class="column_RightBold">Depreciation Value :
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                <asp:Label ID="lblOfficeEquipmentDepValue" runat="server" Width="100px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                                                                                <asp:Label ID="Depvalueperyear" runat ="server" Visible="false"></asp:Label>
                                                                                                <asp:TextBox ID="txtOfficeEquipmentDepValue" runat="server" CssClass="txtbox_Var" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                                                                </td>

                                                                                                <td class="column_RightBold">&nbsp;</td>
                                                                                                <td class="column_Left">
                                                                                                    &nbsp;</td>


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
                                                                                                    <asp:TextBox ID="txtEquipmentBay" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                                                    <asp:DropDownList ID="DropDownList10" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                                                </td>

                                                                                                <td class="column_RightBold" style="width: 15%">Column :
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:TextBox ID="txtEquipmentColumn" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                                                    <asp:DropDownList ID="DropDownList11" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                                                </td>

                                                                                                <td class="column_RightBold" style="width: 10%">Floor :
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:TextBox ID="txtEquipmentFloor" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                                                    <asp:DropDownList ID="DropDownList12" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="column_RightBold">Room :
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:TextBox ID="txtEquipmentRoom" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                                                    <asp:DropDownList ID="DropDownList13" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                                                </td>

                                                                                                <td class="column_RightBold" style="width: 10%">Shelves :
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:TextBox ID="txtEquipmentShelves" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                                                    <asp:DropDownList ID="DropDownList14" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                                                </td>

                                                                                                <td class="column_RightBold">Rack :
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:TextBox ID="txtEquipmentRack" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                                                    <asp:DropDownList ID="DropDownList15" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                                                </td>

                                                                                                <td class="column_RightBold">Bin :
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:TextBox ID="txtEquipmentBin" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                                    <asp:DropDownList ID="DropDownList16" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>

                                                                                        </table>
                                                                                    </fieldset>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="display: none">
                                                                                <td class="column_RightBold" style="width: 10%">Specifications :
                                                                                </td>
                                                                                <td class="column_Left" colspan="3">
                                                                                    <asp:Label ID="Label115" runat="server" CssClass="text3"></asp:Label>
                                                                                    <asp:TextBox ID="txtSpecification" runat="server" Width="95%" Height="25px" TextMode="MultiLine" AutoPostBack="True" CssClass="txtbox_Var" Rows="2"></asp:TextBox>

                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                                                                <td class="column_RightBold" colspan="3">
                                                                                    <asp:Label ID="lbl_OfficeEquipment_EquipInfoId" runat="server" Text="Label" Visible="false"></asp:Label>
                                                                                    <asp:Label ID="lbl_OfficeEquipment_EquipmentId" runat="server" Text="Label" Visible="false"></asp:Label>
                                                                                    <asp:Label ID="lbl_OfficeEquipment_PropertyDetai_ID" runat="server" Text="Label" Visible="false"></asp:Label>
                                                                                    <asp:Label ID="lbl_OfficeEquipment_Property_ID" runat="server" Text="Label" Visible="false"></asp:Label>
                                                                                    <asp:Label ID="lbl_OfficeEquipment_Item_ID" runat="server" Text="Label" Visible="false"></asp:Label>
                                                                                </td>
                                                                                <td class="column_Center">
                                                                                    <asp:Button ID="btm_Edit_Office_Equipment" runat="server" Width="75%" CssClass="CSButton" Text="Edit" OnClientClick="StartProgressBar();"></asp:Button>
                                                                                 
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                        </asp:View>
                                                        <asp:View ID="View1" runat="server">
                                                            <table width="1000px">
                                                                <tr>
                                                                    <td align="center" class="DivTitle" style="width: 100%">
                                                                        <asp:Label ID="Label100" runat="server" Text="MEDICAL EQUIPMENT INFORMATION"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="width: 100%">
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td class="column_RightBold" style="width: 10%">Name :

                                                                                </td>
                                                                                <td class="column_Left" style="width: 30%">

                                                                                    <asp:Label ID="lblMedicalEquipmentName" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                </td>
                                                                                <td class="column_RightBold" style="width: 10%">Unit :

                                                                                </td>
                                                                                <td class="column_Left" style="width: 30%">
                                                                                    <asp:Label ID="lblMedicalEquipmentUnit" runat="server" Width="100px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                    <span class="column_RightBold">Quantity :</span>
                                                                                    <asp:Label ID="lblMedicalEquipmentQuantity" runat="server" Width="100px" SkinID="Label" Font-Italic="False"></asp:Label>

                                                                                </td>
                                                                                <td align="center" rowspan="6" style="width: 20%" valign="middle">
                                                                                    <asp:Image ID="imgMedicalEquipment" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                                                                    <br />
                                                                                    <asp:Button ID="btnlblMedicalEquipmentUpload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>

                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="column_RightBold" style="width: 10%">Description :

                                                                                </td>
                                                                                <td class="column_Left" style="width: 30%">
                                                                                    <asp:Label ID="lblMedicalEquipmentDesc" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>

                                                                                </td>
                                                                                <td class="column_RightBold" style="width: 10%">Warranty :

                                                                                </td>
                                                                                <td class="column_Left" style="width: 30%">
                                                                                    <asp:Label ID="lblMedicalEquipmentWarranty" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>

                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="column_RightBold" style="width: 10%">Power Input :

                                                                                </td>
                                                                                <td class="column_Left" style="width: 30%">
                                                                                    <asp:Label ID="lblMedicalEquipmentPowerInput" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>

                                                                                </td>
                                                                                <td class="column_RightBold">Installed At :
                                                                                </td>
                                                                                <td class="column_Left">
                                                                                    <asp:Label ID="lblMedicalEquipmentInstalledAt" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="column_RightBold" style="width: 10%">Model :

                                                                                </td>
                                                                                <td class="column_Left" style="width: 30%">
                                                                                    <asp:Label ID="lblMedicalEquipmentModel" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>

                                                                                </td>

                                                                                <td class="column_RightBold" style="width: 10%">Dimension :

                                                                                </td>
                                                                                <td class="column_Left" style="width: 30%">
                                                                                    <asp:Label ID="lblMedicalEquipmentDimension" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td class="column_RightBold" style="width: 10%">Serial Number :

                                                                                </td>
                                                                                <td class="column_Left" style="width: 30%">
                                                                                    <asp:Label ID="lblMedicalEquipmentSerialNo" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                </td>
                                                                                <td></td>
                                                                                <td class="column_Left">
                                                                                    <asp:LinkButton ID="lnkbtnMedicalEquipmentVwPropInfo" runat="server" Text="View Property Information"></asp:LinkButton>

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
                                                                                                    <asp:Label ID="lblMedicalEquipmentContractor" runat="server" Width="100px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                                </td>
                                                                                                <td class="column_RightBold">Contact Person : 
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:Label ID="lblMedicalEquipmentContactPerson" runat="server" Width="100px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                                </td>
                                                                                                <td class="column_RightBold">Cellphone No. : 
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:Label ID="lblMedicalEquipmentContactNo" runat="server" Width="100px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </fieldset>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4">
                                                                                    <fieldset style="width: 93%;">
                                                                                        <legend class="column_LeftBold">Acquisition :</legend>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td class="column_RightBold" style="width: 25%;">Acquisition Date :

                                                                                                </td>
                                                                                                <td class="column_Left" style="width: 25%;">
                                                                                                    <asp:Label ID="lblMedicalEquipmentAcqDate" runat="server"></asp:Label>
                                                                                                    &nbsp;(MM/DD/YYYY)

                                                                                                </td>
                                                                                                <td class="column_RightBold" style="width: 25%;">Market Value :

                                                                                                </td>
                                                                                                <td class="column_Left" style="width: 25%;">
                                                                                                    <asp:Label ID="lblMedicalEquipmentMarketValue" runat="server"></asp:Label>

                                                                                                </td>


                                                                                            </tr>
                                                                                            <tr>

                                                                                                <td class="column_RightBold">Acquisition Cost :
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:Label ID="lblMedicalEquipmentAcqCost" runat="server"></asp:Label>
                                                                                                </td>

                                                                                                <td class="column_RightBold">No. of Years :
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:Label ID="lblMedicalEquipmentNoYears" runat="server"></asp:Label>

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>

                                                                                                <td class="column_RightBold">Dep. Rate :
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:Label ID="lblMedicalEquipmentDepRate" runat="server"></asp:Label>


                                                                                                    <td class="column_RightBold">Useful Life :
                                                                                                    </td>
                                                                                                    <td class="column_Left">
                                                                                                        <asp:Label ID="lblMedicalEquipmentUsefulLife" runat="server"></asp:Label>

                                                                                                        &nbsp;(Years)</td>
                                                                                            </tr>
                                                                                            <tr>

                                                                                                <td class="column_RightBold">Dep. Value :
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:Label ID="lblMedicalEquipmentDepValue" runat="server" Width="100px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                                </td>

                                                                                                <td class="column_RightBold">Salvage Value :
                                                                                                </td>
                                                                                                <td class="column_Left">
                                                                                                    <asp:Label ID="lblMedicalEquipmentSalvageValue" runat="server" Width="100px" SkinID="Label" Font-Italic="False"></asp:Label>


                                                                                                </td>


                                                                                            </tr>
                                                                                        </table>
                                                                                    </fieldset>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                                                                <td class="column_RightBold" colspan="3">
                                                                                    <asp:TextBox ID="txtHideMe3" runat="server"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="Button13" runat="server" Width="48%" CssClass="CSButton" Text="SAVE" Enabled="false" OnClientClick="StartProgressBar();"></asp:Button>
                                                                                    <asp:Button ID="Button14" runat="server" Width="48%" CssClass="CSButton" Text="CANCEL" Enabled="false"></asp:Button>
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

                                        </tbody>
                                    </table>
                                </asp:View>
                                <asp:View ID="vwmachineries" runat="server">
                                    <table style="width: 1000px; text-align: center">
                                        <tbody>
                                            <tr>
                                                <td style="width: 1000px" class="DivTitle">LIST OF MACHINERY</td>
                                            </tr>
                                            <tr style="display: none">
                                                <td style="width: 1000px">
                                                    <table style="width: 100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 30%" class="column_RightBold">SEARCH SERIAL NUMBER :</td>
                                                                <td style="width: 40%" class="text5">
                                                                    <asp:TextBox ID="txtMachinerySearch" runat="server" Width="95%" CssClass="txtboxinspection"></asp:TextBox>
                                                                </td>
                                                                <td style="width: 30%" class="text5">
                                                                    <asp:Button ID="btnMachinerySerial" OnClick="btnMachinerySearch_Click" runat="server" Width="150px" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1000px">
                                                    <asp:GridView ID="grdpropertyListofmachinery" runat="server" Width="1000px" SkinID="GridViewAA"
                                                        OnPageIndexChanging="grdpropertyListofmachinery_PageIndexChanging" AllowPaging="True" HorizontalAlign="Center" DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo,Received_ID,AcquisitionCost,Received_Date,Date_Accepted,useful_life,Received_Dtl_ID"
                                                        OnRowDataBound="grdpropertyListofmachinery_RowDataBound" OnSelectedIndexChanged="grdpropertyListofmachinery_SelectedIndexChanged" Font-Size="9pt"
                                                        OnDataBound="grdpropertyListofmachinery_ondatabound">
                                                        <%----%>
                                                        <Columns>
                                                            <asp:BoundField DataField="PropertyNo" HeaderText="Property No." ControlStyle-CssClass="header">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="Type" HeaderText="NAME">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="ServiceFloors" DataFormatString="{0:d}" HeaderText="Floor" Visible="false">
                                                                <HeaderStyle HorizontalAlign="Center" CssClass="d-none"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                                            </asp:BoundField>
                                                           
                                                            <asp:BoundField DataField="MachineLocation" DataFormatString="{0:d}" HeaderText="Room" Visible="false">
                                                                <HeaderStyle HorizontalAlign="Center" CssClass="d-none"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>

                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="acquisitioncost" DataFormatString="{0:N}" HeaderText="WARRANTY PERIOD">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Right" Width="12%"></ItemStyle>
                                                            </asp:BoundField>
                                                           
                                                            <asp:BoundField DataField="MaintenanceContractor" HeaderText="Contractor">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%"></ItemStyle>
                                                            </asp:BoundField>
                                                           

                                                            <asp:BoundField DataField="MaintenanceContactPerson" HeaderText="Contact Person">
                                                                <ItemStyle HorizontalAlign="Right" Width="11%"></ItemStyle>
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="MaintenanceContactNo" HeaderText="Cellphone No.">
                                                                <ItemStyle HorizontalAlign="Right" Width="11%"></ItemStyle>
                                                            </asp:BoundField>

                                                        </Columns>
                                                    </asp:GridView>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1000px" class="DivTitle">MACHINERY INFORMATION</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1000px">
                                                    <table>
                                                        <tr>
                                                            <td style="width: 80%;" valign="top">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 50%;">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td class="column_RightBold">Name :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="txtMachineryName" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="column_RightBold">Description :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="txtMachineryDescription" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="column_RightBold">Power Input :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="txtMachineryPowerInput" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="column_RightBold">Model :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="txtMachineryModel" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="column_RightBold">Installed At :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="txtInstalledAt" runat="server" Width="75%" CssClass="txtbox_Var" Visible="false" Enabled="False"></asp:TextBox>
                                                                                        <asp:DropDownList ID="drpMachineInstalledBuilding" runat="server" Width="75%" CssClass="drpdownCSS" Enabled="False" ></asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td style="width: 50%;">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td class="column_RightBold">Unit :
                                                                                    </td>
                                                                                    <td class="column_Left" colspan="3">
                                                                                        <asp:TextBox ID="txtMachineryUnit" runat="server" Width="75%" CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                                                                        <asp:DropDownList ID="drpMachineUnit" runat="server" Width="75%" CssClass="drpdownCSS" Enabled="False" ></asp:DropDownList>
                                                                                                                                                                         
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="column_RightBold">Dimension :
                                                                                    </td>
                                                                                    <td class="column_Left" colspan="3">
                                                                                        <asp:TextBox ID="txtMachineryDimension" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="column_RightBold">Area Capacity :
                                                                                    </td>
                                                                                    <td class="column_Left" colspan="3">
                                                                                        <asp:TextBox ID="txtMachineryAreaCapacity" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="column_RightBold">Warranty :
                                                                                    </td>
                                                                                    <td class="column_Left" colspan="3">
                                                                                        <asp:TextBox ID="txtMachineryWarranty" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                        </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="column_RightBold" style="width: 25%">Floor Location :
                                                                                    </td>
                                                                                    <td class="column_Left" style="width: 25%">
                                                                                        <asp:TextBox ID="txtMachineryFloorLocation" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                    <td class="column_RightBold" style="width: 15%">Room :
                                                                                    </td>
                                                                                    <td class="column_Left">
                                                                                        <asp:TextBox ID="txtMachineryRoom" runat="server" Width="46%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <fieldset>
                                                                                <legend class="column_LeftBold">Maintenance</legend>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td class="column_RightBold" style="width: 16%">Contractor : 
                                                                                        </td>
                                                                                        <td class="column_Left">
                                                                                            <asp:TextBox ID="txtContractor" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                        </td>
                                                                                        <td class="column_RightBold" style="width: 16%">Contact Person : 
                                                                                        </td>
                                                                                        <td class="column_Left">
                                                                                            <asp:TextBox ID="txtContactPerson" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                        </td>
                                                                                        <td class="column_RightBold" style="width: 16%">Cellphone No. : 
                                                                                        </td>
                                                                                        <td class="column_Left">
                                                                                            <asp:TextBox ID="txtCellphoneNo" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
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
                                                                    <asp:Image ID="Image7" runat="server" Width="204px" ImageUrl="~/images/blankImage.jpg" Height="202px"></asp:Image></center>
                                            <br />
                                                                    <br />
                                                                    <asp:Button ID="btnUpload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>

                                                                    <br />
                                                                </fieldset>
                                                                <br />
                                                                <asp:Button ID="btnSave" runat="server" Width="48%" CssClass="CSButton" Text="SAVE" Enabled="false" OnClientClick="StartProgressBar();"></asp:Button>
                                                                <asp:Button ID="btnCancel" runat="server" Width="48%" CssClass="CSButton" Text="CANCEL" Enabled="false"></asp:Button>
                                                                <asp:TextBox ID="txtHideMe" runat="server" Visible="false"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 80%;" valign="top">
                                                                <fieldset>

                                                                    <legend class="column_LeftBold">Acquisition :</legend>
                                                                    <table>
                                                                        <tr>
                                                                            <td class="column_RightBold">Acquisition Date :
                                                                            </td>
                                                                            <td class="column_Left" style="width: 100px;">
                                                                                <asp:Label ID="Label10" runat="server"></asp:Label>
                                                                                <asp:TextBox ID="txtMachineryAcqDate" runat="server" CssClass="txtbox_Var" Enabled="False" onchange="return NoOfYearsMachine(this.value);"></asp:TextBox>
                                                                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtMachineryAcqDate" PopupButtonID="txtMachineryAcqDate"></cc1:CalendarExtender>
                                                                                &nbsp;(MM/DD/YYYY)</td>
                                                                            <td class="column_RightBold">Market Value :

                                                                            </td>
                                                                            <td class="column_Left">
                                                                                <asp:Label ID="Label11" runat="server"></asp:Label>
                                                                                <asp:TextBox ID="txtMachineryMarketValue" runat="server" CssClass="txtbox_Var" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="column_RightBold">Acquisition Cost :

                                                                            </td>
                                                                            <td class="column_Left">
                                                                                <asp:Label ID="Label12" runat="server"></asp:Label>
                                                                                <asp:TextBox ID="txtMachineryAcqCost" runat="server" CssClass="txtbox_Var" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalValMachine(this),getDepValRateMachine(this);"></asp:TextBox>
                                                                            </td>
                                                                            <td class="column_RightBold">No. of Years :

                                                                            </td>
                                                                            <td class="column_Left">
                                                                                <asp:Label ID="Label13" runat="server"></asp:Label>
                                                                                <asp:TextBox ID="txtMachineryNoYears" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="column_RightBold">Depreciated Rate :

                                                                            </td>
                                                                            <td class="column_Left">
                                                                                <asp:TextBox ID="txtMachineryDepRate" runat="server" Width="100px" CssClass="txtboxAmount" MaxLength="5" ReadOnly="True" Enabled="False"></asp:TextBox>&nbsp;(%) Percent

                                                                            </td>
                                                                            <td class="column_RightBold">Useful Life :

                                                                            </td>
                                                                            <td class="column_Left">
                                                                                <asp:Label ID="Label14" runat="server"></asp:Label>
                                                                                <asp:TextBox ID="txtMachineryUsefulLife" runat="server" Width="100px" CssClass="txtbox_Var" Enabled="False" onchange="return getDepValRateMachine(this);"></asp:TextBox>

                                                                                &nbsp;(Years)</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="column_RightBold">Depreciated Value :</td>
                                                                            <td class="column_Left"><asp:TextBox runat="server" ID="txtDepreciatedValueMachineNew" CssClass="txtbox_Var"></asp:TextBox></td>
                                                                            <td class="column_RightBold">Salvage Value :</td>
                                                                            <td class="column_Left">
                                                                                <asp:TextBox ID="txtMachinerySalvageValue" runat="server" CssClass="txtboxAmount" Enabled="False" Onchange="this.value=formatCurrency(this.value);" Onkeyup="javascript:this.value=Comma(this.value);" Width="85%">0.00</asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="column_RightBold">Depreciation Value :

                                                                            </td>
                                                                            <td class="column_Left">
                                                                                <asp:Label ID="Label15" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                <asp:TextBox ID="txtequipmentdepreciatedvalue" runat="server" Width="100px" CssClass="txtbox_Var" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                                            </td>
                                                                            <td class="column_RightBold">&nbsp;</td>
                                                                            <td class="column_Left">
                                                                                &nbsp;</td>


                                                                        </tr>
                                                                    </table>
                                                                </fieldset>

                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table style="width: 100%; display: none;">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 80%">
                                                                    <fieldset style="width: 800px; height: 280px" class="PanelBorder">
                                                                        <table style="color: white; background-color: #c0c0c0; text-align: center" id="Table21" width="800">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 1000px; height: 16px; text-align: center">
                                                                                        <strong>
                                                                                            <span style="color: black; font-family: Calibri">MACHINERY INFORMATION</span>
                                                                                        </strong>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <table id="Table22" width="800">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 40px" class="text4" align="right"></td>
                                                                                    <td style="width: 125px" class="column_LeftBold" align="right">Brand/Model</td>
                                                                                    <td style="width: 5px" class="text4">:</td>
                                                                                    <td style="width: 245px" class="text3" align="left">
                                                                                        <asp:Label ID="lblmachiniriesbrandmodel" runat="server" Width="200px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                    <td style="width: 125px; height: 16px" class="column_LeftBold" align="right">Unit No.</td>
                                                                                    <td style="width: 5px" class="text4" align="left">:</td>
                                                                                    <td style="width: 255px" class="text3" align="left">
                                                                                        <asp:Label ID="lblmachiniriesunitno" runat="server" Width="200px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 40px" class="text4" align="right"></td>
                                                                                    <td style="width: 125px" class="column_LeftBold" align="right">Description</td>
                                                                                    <td style="width: 5px" class="text4">:</td>
                                                                                    <td style="width: 245px" class="text3" align="left">
                                                                                        <asp:Label ID="lblmachiniriesDesc" runat="server" Width="200px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                    <td style="width: 125px; height: 16px" class="column_LeftBold" align="right">Working Load</td>
                                                                                    <td style="width: 5px" class="text4" align="left">:</td>
                                                                                    <td style="width: 255px" class="text3" align="left">
                                                                                        <asp:Label ID="lblmachiniriesworkingload" runat="server" Width="200px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 40px" class="text4" align="right"></td>
                                                                                    <td style="width: 125px" class="column_LeftBold" align="right">Location</td>
                                                                                    <td style="width: 5px" class="text4">:</td>
                                                                                    <td style="width: 245px" class="text3" align="left">
                                                                                        <asp:Label ID="lblmachinirieslocation" runat="server" Width="200px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                    <td style="width: 125px; height: 16px" class="column_LeftBold" align="right">Rated Speed</td>
                                                                                    <td style="width: 5px" class="text4" align="left">:</td>
                                                                                    <td style="width: 255px" class="text3" align="left">
                                                                                        <asp:Label ID="lblmachiniriesratedspeed" runat="server" Width="200px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 40px" class="text4" align="right"></td>
                                                                                    <td style="width: 125px" class="column_LeftBold" align="right">No. of Passengers </td>
                                                                                    <td style="width: 5px" class="text4">:</td>
                                                                                    <td style="width: 245px" class="text3" align="left">
                                                                                        <asp:Label ID="lblmachiniriesnoofpassenger" runat="server" Width="200px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                    <td style="width: 125px; height: 16px" class="column_LeftBold" align="right">Car Dimension</td>
                                                                                    <td style="width: 5px" class="text4" align="left">:</td>
                                                                                    <td style="width: 255px" class="text3" align="left">
                                                                                        <asp:Label ID="lblmachiniriescardimension" runat="server" Width="200px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 40px" class="text4" align="right"></td>
                                                                                    <td style="width: 125px" class="column_LeftBold" align="right">Service Floors</td>
                                                                                    <td style="width: 5px" class="text4">:</td>
                                                                                    <td style="width: 245px" class="text3" align="left">
                                                                                        <asp:Label ID="lblmachiniriesservicefloor" runat="server" Width="200px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                    <td style="width: 125px; height: 16px" class="column_LeftBold" align="right"></td>
                                                                                    <td style="width: 5px" class="text4" align="left"></td>
                                                                                    <td style="width: 255px" class="text3" align="left"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 40px" class="text4" align="right"></td>
                                                                                    <td style="width: 125px" class="column_LeftBold" align="right">Depreciation Rate&nbsp;</td>
                                                                                    <td style="width: 5px" class="text4">:</td>
                                                                                    <td style="width: 245px" class="text3" align="left">
                                                                                        <asp:TextBox ID="lblmachiniriesdepreciatedrate" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" MaxLength="5" ReadOnly="True" OnTextChanged="lblmachiniriesdepreciatedrate_TextChanged"></asp:TextBox><strong>(%) Percent</strong></td>
                                                                                    <td style="width: 125px; height: 16px" class="column_LeftBold" align="right">Depreciated Value</td>
                                                                                    <td style="width: 5px" class="text4" align="left">:</td>
                                                                                    <td style="width: 255px" class="text3" align="left">
                                                                                        <asp:Label ID="lblmachiniriesdepriciatedvalue" runat="server" Width="200px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 40px" class="text4" align="right"></td>
                                                                                    <td style="width: 125px" class="column_LeftBold" align="right">Salvage Value</td>
                                                                                    <td style="width: 5px" class="text4">:</td>
                                                                                    <td style="width: 245px" class="text3" align="left">
                                                                                        <asp:TextBox ID="txtMSalValue" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" OnTextChanged="txtMSalValue_TextChanged"></asp:TextBox></td>
                                                                                    <td style="width: 125px; height: 16px" class="column_LeftBold" align="right">No. of Years</td>
                                                                                    <td style="width: 5px" class="text4" align="left">:</td>
                                                                                    <td style="width: 255px" class="text3" align="left">
                                                                                        <asp:Label ID="lblMNoYears" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 40px" class="text4" align="right"></td>
                                                                                    <td style="width: 125px" class="column_LeftBold" align="right">Useful&nbsp;Life</td>
                                                                                    <td style="width: 5px" class="text4"></td>
                                                                                    <td style="width: 245px" class="text3" align="left">
                                                                                        <asp:Label ID="lblMULife" runat="server"></asp:Label>Years</td>
                                                                                    <td style="width: 125px; height: 16px" class="column_LeftBold" align="right"></td>
                                                                                    <td style="width: 5px" class="text4" align="left">:</td>
                                                                                    <td style="width: 255px" class="text3" align="left"></td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <hr style="height: 1px" />
                                                                        <table style="height: 18px" id="Table23" width="800">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 195px" class="column_RightBold" align="right">Mech Permit No.</td>
                                                                                    <td style="width: 5px" class="text4" align="left">:</td>
                                                                                    <td style="width: 210px" align="left">
                                                                                        <asp:Label ID="lblmachiniriesmechpermitno" runat="server" Width="200px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                    <td style="width: 125px" class="column_RightBold" align="right">Date Inspected</td>
                                                                                    <td style="width: 5px" class="text4" align="left">:</td>
                                                                                    <td style="width: 260px" align="left">
                                                                                        <asp:Label ID="lblmachiniriesdateinspected" runat="server" Width="250px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 195px" class="column_RightBold" align="right">Date to Operate</td>
                                                                                    <td style="width: 5px" class="text4" align="left">:</td>
                                                                                    <td style="width: 210px" align="left">
                                                                                        <asp:Label ID="lblmachiniriesdatetooperate" runat="server" Width="200px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                    <td style="width: 125px" class="column_RightBold" align="right">Inspected By</td>
                                                                                    <td style="width: 5px" class="text4" align="left">:</td>
                                                                                    <td style="width: 260px" align="left">
                                                                                        <asp:Label ID="lblmachiniriesinspectedby" runat="server" Width="250px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 195px" class="column_RightBold" align="right">Date Issued </td>
                                                                                    <td style="width: 5px" class="text4" align="left">:</td>
                                                                                    <td style="width: 210px" align="left">
                                                                                        <asp:Label ID="lblmachiniriesdateissued" runat="server" Width="200px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                    <td style="width: 125px" class="column_RightBold" align="right">Remarks</td>
                                                                                    <td style="width: 5px" class="text4" align="left">:</td>
                                                                                    <td style="width: 260px" align="left">
                                                                                        <asp:Label ID="lblmachiniriesremarks" runat="server" Width="250px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </fieldset>
                                                                </td>
                                                                <td style="width: 20%">
                                                                    <fieldset style="width: 191px; height: 280px" class="PanelBorder">
                                                                        <table>
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 191px; height: 50px" class="textimage2" colspan="2"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 191px; height: 147px" class="textimage2" colspan="2">
                                                                                        <asp:Image ID="Image6" runat="server" Width="151px" ImageUrl="~/images/blankImage.jpg" CssClass="textimage2" Height="124px" ImageAlign="Middle"></asp:Image></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 80px" class="textimage2">Date Taken:</td>
                                                                                    <td style="width: 111px" class="textimage2">
                                                                                        <asp:Label ID="lblMchneDateTaken" runat="server" Width="110px" CssClass="textimage2" BorderStyle="Solid" BorderWidth="1px"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 80px" class="textimage2">Uploaded By:</td>
                                                                                    <td style="width: 111px" class="textimage2">
                                                                                        <asp:Label ID="lblMchneUploadedBy" runat="server" Width="110px" CssClass="textimage2" BorderStyle="Solid" BorderWidth="1px"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 80px" class="textimage2">Position:</td>
                                                                                    <td style="width: 111px" class="textimage2">
                                                                                        <asp:Label ID="lblMchnePosition" runat="server" Width="110px" CssClass="textimage2" BorderStyle="Solid" BorderWidth="1px"></asp:Label></td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </fieldset>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1000px" class="text5">
                                                    <table cellspacing="0" cellpadding="0" width="1000" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 167px; height: 26px">
                                                                    <asp:Button ID="btnmachineryLedger" runat="server" Width="167px" CssClass="Initial" Text="Transactions"></asp:Button>

                                                                </td>
                                                                <td style="width: 156px; height: 26px">
                                                                    <asp:Button ID="btnmachineryRepairs" runat="server" Width="167px" CssClass="Initial" Text="Repairs and Maintenance"></asp:Button></td>
                                                                <td style="width: 129px; height: 26px">
                                                                    <asp:Button ID="btnmachineryDocattach" runat="server" Width="129px" CssClass="Initial" Text="Document Attached"></asp:Button></td>
                                                                <td style="width: 450px; height: 26px">
                                                                    <asp:Label ID="lbl_MachineryId" runat="server" Text="Label" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lbl_MachineryInfoId" runat="server" Text="Label" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lbl_machine_Property_ID" runat="server" Text="Label" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lbl_Machine_Item_ID" runat="server" Text="Label" Visible="false"></asp:Label>
                                                                    </td>
                                                                <td style="width: 325px; height: 26px" class="column_Center">
                                                                    <asp:Button ID="btnEdit_Mechinery" runat="server" CssClass="CSButton" Enabled="True" OnClientClick="StartProgressBar();" Text="Edit" Width="75%" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>

                                                </td>

                                            </tr>

                                        </tbody>

                                    </table>

                                </asp:View>
                                <asp:View ID="vwfurnitureandfixtures" runat="server">
                                    <table style="width: 1000px; text-align: center">
                                        <tbody>
                                            <tr>
                                                <td style="width: 1000px" class="DivTitle">LIST OF FURNITURE AND FIXTURES

                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="width: 1000px">
                                                    <table style="width: 100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 30%" class="column_RightBold">SEARCH SERIAL NUMBER :

                                                                </td>
                                                                <td style="width: 40%" class="text5">
                                                                    <asp:TextBox ID="txtFurnitureSerialSearch" runat="server" Width="95%" CssClass="txtboxinspection"></asp:TextBox>

                                                                </td>
                                                                <td style="width: 30%" class="text5">
                                                                    <asp:Button ID="Button3" OnClick="Button3_Click" runat="server" Width="150px" Text="SEARCH" OnClientClick="StartProgressBar();" CssClass="CSButton"></asp:Button>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>

                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="width: 1000px">
                                                    <asp:GridView ID="grdfurnitureandfixtures" runat="server" Width="1000px" SkinID="GridViewAA" OnPageIndexChanging="grdfurnitureandfixtures_PageIndexChanging" AllowPaging="True" HorizontalAlign="Center" 
                                                        DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo,Received_ID,AcquisitionCost,Received_Date,Date_Accepted,useful_life,Received_Dtl_ID" OnRowDataBound="grdfurnitureandfixtures_RowDataBound1" OnSelectedIndexChanged="grdfurnitureandfixtures_SelectedIndexChanged" Font-Size="9pt" PageSize="4" OnDataBound="grdfurnitureandfixtures_ondatabound">
                                                        <Columns>
                                                            <asp:BoundField DataField="PropertyNo" HeaderText="TYPE OF FURNITURE">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Name" HeaderText="SERIAL NO.">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center" Width="40%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FloorLocation" DataFormatString="{0:d}" HeaderText="FLOOR" Visible="false">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="RoomLocation" DataFormatString="{0:N}" HeaderText="ROOM" Visible="false">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Right" Width="7%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Warranty" DataFormatString="{0:N}" HeaderText="MARKET VALUE">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Right" Width="12%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="MaintenanceContractor" HeaderText="CONTRACTOR">
                                                                <HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="MaintenanceContactPerson" HeaderText="CONTACT PERSON">
                                                                <HeaderStyle HorizontalAlign="Center" Width="11%"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="MaintenanceContactNo" HeaderText="CONTACT NO.">
                                                                <HeaderStyle HorizontalAlign="Center" Width="11%"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1000px" class="DivTitle">FURNITURE & FIXTURES INFORMATION
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1000px">
                                                    <table style="width: 1000px">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 800px; display: none;">
                                                                    <fieldset style="width: 800px; height: 280px" class="PanelBorder">
                                                                        <table style="color: white; background-color: #c0c0c0; text-align: center" id="Table27" width="800">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 1000px; height: 16px; text-align: center">
                                                                                        <strong>
                                                                                            <span style="color: black; font-family: Calibri">FURNITURE AND FIXTURES INFORMATION

                                                                                            </span>

                                                                                        </strong>

                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <table id="Table28" width="800">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50px" class="text5" align="right"></td>
                                                                                    <td style="width: 115px" class="column_LeftBold" align="right">Name</td>
                                                                                    <td style="width: 5px" class="text4">:</td>
                                                                                    <td style="width: 255px" class="text3" align="left">
                                                                                        <asp:Label ID="lblfurniturename" runat="server" Width="220px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                    <td style="width: 115px" class="column_LeftBold" align="right">Model</td>
                                                                                    <td style="width: 4px; height: 16px" class="text4" align="left">:</td>
                                                                                    <td style="width: 255px; height: 16px" class="text3" align="left">
                                                                                        <asp:Label ID="lblfurnituremodel" runat="server" Width="220px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px" class="text5" align="right"></td>
                                                                                    <td style="width: 115px" class="column_LeftBold" align="right">Description</td>
                                                                                    <td style="width: 5px" class="text4">:</td>
                                                                                    <td style="width: 255px" class="text3" align="left">
                                                                                        <asp:Label ID="lblfurnituredescription" runat="server" Width="220px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                    <td style="width: 115px" class="column_LeftBold" align="right">Warranty</td>
                                                                                    <td style="width: 4px" class="text4" align="left">:</td>
                                                                                    <td style="width: 255px; height: 16px" class="text3" align="left">
                                                                                        <asp:Label ID="lblfurniturewaranty" runat="server" Width="220px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px" class="text5" align="right"></td>
                                                                                    <td style="width: 115px" class="column_LeftBold" align="right">Dimension</td>
                                                                                    <td style="width: 5px" class="text4">:</td>
                                                                                    <td style="width: 255px" class="text3" align="left">
                                                                                        <asp:Label ID="lblfurnituredimension" runat="server" Width="220px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                    <td style="width: 115px" class="column_LeftBold" align="right">Area Capacity</td>
                                                                                    <td style="width: 4px" class="text4" align="left">:</td>
                                                                                    <td style="width: 255px; height: 16px" class="text3" align="left">
                                                                                        <asp:Label ID="lblfurnitureareacapacity" runat="server" Width="220px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px" class="text5" align="right"></td>
                                                                                    <td style="width: 115px" class="column_LeftBold" align="right">Depreciation Rate</td>
                                                                                    <td style="width: 5px" class="text4">:</td>
                                                                                    <td style="width: 255px" class="text3" align="left">
                                                                                        <asp:TextBox ID="lblfurnituredepreciatedrate" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" ReadOnly="True" OnTextChanged="lblfurnituredepreciatedrate_TextChanged"></asp:TextBox><strong>(%) Percent</strong></td>
                                                                                    <td style="width: 115px" class="column_LeftBold" align="right">Depreciated Value</td>
                                                                                    <td style="width: 4px; height: 16px" class="text4" align="left">:</td>
                                                                                    <td style="width: 255px; height: 16px" class="text3" align="left">
                                                                                        <asp:Label ID="lblfurnituredepriatedvalue" runat="server" Width="220px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px" class="text5" align="right"></td>
                                                                                    <td style="width: 115px" class="column_LeftBold" align="right">Salvage Value</td>
                                                                                    <td style="width: 5px" class="text4">:</td>
                                                                                    <td style="width: 255px" class="text3" align="left">
                                                                                        <asp:TextBox ID="txtFSalValue" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" OnTextChanged="txtFSalValue_TextChanged"></asp:TextBox></td>
                                                                                    <td style="width: 115px" class="column_LeftBold" align="right">No of Years</td>
                                                                                    <td style="width: 4px; height: 16px" class="text4" align="left">:</td>
                                                                                    <td style="width: 255px; height: 16px" class="text3" align="left">
                                                                                        <asp:Label ID="lblFNoYears" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px" class="text5" align="right"></td>
                                                                                    <td style="width: 115px" class="column_LeftBold" align="right">Useful Life</td>
                                                                                    <td style="width: 5px" class="text4">:</td>
                                                                                    <td style="width: 255px" class="text3" align="left">
                                                                                        <asp:Label ID="lblFULife" runat="server"></asp:Label>Years</td>
                                                                                    <td style="width: 115px" class="column_LeftBold" align="right">Power Input :</td>
                                                                                    <td style="width: 4px; height: 16px" class="text4" align="left"></td>
                                                                                    <td style="width: 255px; height: 16px" class="text3" align="left">
                                                                                        <asp:TextBox ID="txtequipmentpowerinput" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="89%"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <hr style="height: 1px" />
                                                                        <table id="Table29" width="800">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 213px; height: 14px" class="text5" align="right">
                                                                                        <strong>
                                                                                            <em>Furniture Specifications:</em>

                                                                                        </strong>

                                                                                    </td>
                                                                                    <td class="text5" colspan="5" rowspan="3">
                                                                                        <br />
                                                                                        <asp:Label ID="lblfurniturespecification" runat="server" Width="510px" CssClass="text3" SkinID="Label" Height="45px" Font-Italic="False"></asp:Label>

                                                                                    </td>

                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 213px; height: 16px" class="text5" align="right"></td>

                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 213px" class="text5" align="right"></td>

                                                                                </tr>

                                                                            </tbody>

                                                                        </table>

                                                                    </fieldset>

                                                                </td>
                                                                <td style="width: 800px;" valign="top">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td class="column_RightBold" style="width: 15%">Name :
                                                                            </td>
                                                                            <td class="column_Left" style="width: 30%">

                                                                                <asp:TextBox ID="txtName" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                                            </td>
                                                                            <td class="column_RightBold">Unit :

                                                                            </td>
                                                                            <td class="column_Left">


                                                                                <asp:TextBox ID="txtFurnitureUnit" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                                                                 <asp:DropDownList ID="drpFurnitureUnit" runat="server" CssClass="drpdownCSS" Width="100px">
                                                                                </asp:DropDownList>
                                                                                <span class="column_RightBold">Quantity :</span>
                                                                                <asp:TextBox ID="txtQuantity" runat="server" Width="100px" CssClass="txtbox_Var"></asp:TextBox>

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="column_RightBold">Description :

                                                                            </td>
                                                                            <td class="column_Left">
                                                                                <asp:TextBox ID="txtequipmentdesciption" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                                                            </td>
                                                                            <td class="column_RightBold">Dimension :

                                                                            </td>
                                                                            <td class="column_Left">
                                                                                <asp:TextBox ID="txtequipmentdimension" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="column_RightBold">&nbsp;Serial Number :</td>
                                                                            <td class="column_Left">
                                                                                <asp:TextBox ID="txtequipmentSerialNumber" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="89%"></asp:TextBox>

                                                                            </td>
                                                                            <td class="column_RightBold">Model :

                                                                            </td>
                                                                            <td class="column_Left">
                                                                                <asp:TextBox ID="txtequipmentmodel" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                                                            </td>
                                                                        </tr>
                                                                        <tr>

                                                                            <td class="column_RightBold">&nbsp;Property Number :</td>
                                                                            <td class="column_Left">
                                                                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="drpdownCSS" Visible="false" Width="75%">
                                                                                </asp:DropDownList>
                                                                                <asp:TextBox ID="txtPropertyNo" runat="server" CssClass="txtbox_Var" Width="89%"></asp:TextBox>
                                                                            </td>
                                                                            <td class="column_RightBold">Warranty :

                                                                            </td>
                                                                            <td class="column_Left">
                                                                                <asp:TextBox ID="txtequipmentwaranty" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                                                            </td>

                                                                        </tr>
                                                                        <tr>

                                                                            <td class="column_RightBold">&nbsp;Installed At :</td>
                                                                            <td class="column_Left">
                                                                                <asp:DropDownList ID="drpInstalledAtBuilding" runat="server" CssClass="drpdownCSS" Width="75%">
                                                                                </asp:DropDownList>
                                                                                <asp:TextBox ID="txtFurnitureInstalledat" runat="server" CssClass="txtbox_Var" Width="89%" Visible="False"></asp:TextBox>
                                                                            </td>
                                                                            <td class="column_RightBold">Department:
                                                                            </td>
                                                                            <td class="column_Left">
                                                                                <asp:TextBox ID="txtDepartment" runat="server" Width="89%" CssClass="txtbox_Var" Visible="false"></asp:TextBox>

                                                                                <asp:DropDownList ID="drpDepartmentFurnifure" runat="server" CssClass="drpdownCSS" Width="89%">
                                                                                </asp:DropDownList>

                                                                            </td>

                                                                        </tr>
                                                                        <tr>

                                                                            <td class="column_RightBold">&nbsp;Accountable Officer:</td>
                                                                            <td class="column_Left">
                                                                                <asp:TextBox ID="txtAccountablePerson" runat="server" CssClass="txtbox_Var" Width="89%"></asp:TextBox>
                                                                            </td>
                                                                            <td class="column_RightBold">&nbsp;</td>
                                                                            <td class="column_Left">
                                                                                &nbsp;</td>

                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="4">
                                                                                <fieldset>
                                                                                    <legend class="column_LeftBold">Acquisition :</legend>
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td class="column_RightBold">Acquisition Date :
                                                                                            </td>
                                                                                            <td class="column_Left" style="width: 100px;">
                                                                                                <asp:Label ID="Label25" runat="server"></asp:Label>
                                                                                                <asp:TextBox ID="txtFurnitureAcqDate" runat="server" CssClass="txtbox_Var" onchange="return NoOfYearsFIXTURES(this.value);"></asp:TextBox>
                                                                                                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtFurnitureAcqDate" PopupButtonID="txtFurnitureAcqDate"></cc1:CalendarExtender>


                                                                                                &nbsp;(MM/DD/YYYY)</td>
                                                                                            <td class="column_RightBold">Market Value :
                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:Label ID="lblFurnitureMarketValue" runat="server"></asp:Label>
                                                                                                <asp:TextBox ID="txtFurnitureMarketValue" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>

                                                                                            </td>


                                                                                        </tr>
                                                                                        <tr>

                                                                                            <td class="column_RightBold">Acquisition Cost :
                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:Label ID="Label27" runat="server"></asp:Label>
                                                                                                <asp:TextBox ID="txtFurnitureAcqCost" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalValFIXTURES(this),getDepValRateFIXTURES(this);"></asp:TextBox>
                                                                                            </td>

                                                                                            <td class="column_RightBold">No. of Years :
                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:Label ID="Label28" runat="server"></asp:Label>
                                                                                                <asp:TextBox ID="txtFurnitureNoYears" runat="server" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>

                                                                                            <td class="column_RightBold">Depreciated Rate :
                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:TextBox ID="txtFurnitureDeprate" runat="server" Width="100px" CssClass="txtboxAmount" MaxLength="5" ReadOnly="True"></asp:TextBox>&nbsp;(%) Percent</td>


                                                                                            <td class="column_RightBold">Useful Life :
                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:Label ID="Label29" runat="server"></asp:Label>
                                                                                                <asp:TextBox ID="txtFurnitureUsefulLife" runat="server" Width="100px" CssClass="txtbox_Var" onchange="return getDepValRateFIXTURES(this);"></asp:TextBox>

                                                                                                &nbsp;(Years)</td>

                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="column_RightBold">Depreciated Value</td>
                                                                                             <td class="column_Left"><asp:TextBox ID="txtDepreciatedValueFurnitureNew" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                                                                             <td  class="column_RightBold">Salvage Value :</td>
                                                                                             <td class="column_Left">
                                                                                                 <asp:TextBox ID="txtFurnitureSalvageValue" runat="server" CssClass="txtboxAmount" Onchange="this.value=formatCurrency(this.value);" Onkeyup="javascript:this.value=Comma(this.value);" Width="85%">0.00</asp:TextBox>
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr>

                                                                                            <td class="column_RightBold">Depreciation Value :
                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:Label ID="Label30" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                                <asp:TextBox ID="txtFurnitureDepValue" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                                                            </td>

                                                                                            <td class="column_RightBold">&nbsp;</td>
                                                                                            <td class="column_Left">
                                                                                                &nbsp;</td>


                                                                                        </tr>

                                                                                    </table>
                                                                                </fieldset>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="width: 200px; border: 2px solid #808080" valign="top">

                                                                    <table>
                                                                        <tbody>

                                                                            <tr>
                                                                                <td style="width: 191px;" class="textimage2" colspan="2" valign="top">
                                                                                    <asp:Image ID="imgFurniture" runat="server" Width="151px" ImageUrl="~/images/blankImage.jpg" CssClass="textimage2" Height="161px" ImageAlign="Middle"></asp:Image>

                                                                                </td>

                                                                            </tr>
                                                                            <tr style="display: none;">
                                                                                <td style="width: 80px" class="textimage2">Date Taken:

                                                                                </td>
                                                                                <td style="width: 111px" class="textimage2">
                                                                                    <asp:Label ID="lblfurnitureDateTaken" runat="server" Width="110px" CssClass="textimage2" BorderStyle="Solid" BorderWidth="1px"></asp:Label>

                                                                                </td>

                                                                            </tr>
                                                                            <tr style="display: none;">
                                                                                <td style="width: 80px" class="textimage2">Uploaded By:

                                                                                </td>
                                                                                <td style="width: 111px" class="textimage2">
                                                                                    <asp:Label ID="lblFurnitureUploadedBy" runat="server" Width="110px" CssClass="textimage2" BorderStyle="Solid" BorderWidth="1px"></asp:Label>

                                                                                </td>

                                                                            </tr>
                                                                            <tr style="display: none;">
                                                                                <td style="width: 80px" class="textimage2">Position:

                                                                                </td>
                                                                                <td style="width: 111px" class="textimage2">
                                                                                    <asp:Label ID="lblFurniturePosition" runat="server" Width="110px" CssClass="textimage2" BorderStyle="Solid" BorderWidth="1px"></asp:Label>

                                                                                </td>

                                                                            </tr>

                                                                        </tbody>

                                                                    </table>



                                                                </td>

                                                            </tr>

                                                        </tbody>

                                                    </table>

                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="width: 1000px" class="text5">
                                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 1026px">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 66px; height: 26px">
                                                                    <asp:Button ID="btnfurnitureledger" runat="server" Width="167px" CssClass="Initial" Text="Transactions"></asp:Button>

                                                                </td>
                                                                <td style="width: 156px; height: 26px">
                                                                    <asp:Button ID="btnfurnitureRepairs" runat="server" Width="167px" CssClass="Initial" Text="Repairs and Maintenance"></asp:Button></td>
                                                                <td style="width: 129px; height: 26px">
                                                                    <asp:Button ID="btnfurnitureAttachedDoc" runat="server" Width="129px" CssClass="Initial" Text="Document Attached"></asp:Button></td>
                                                                <td style="width: 450px; height: 26px">
                                                                    <asp:TextBox ID="txtHideMe2" runat="server" Visible="False"></asp:TextBox>
                                                                    <asp:Label ID="lbl_furniture_FurnitureInfoId" runat="server" Text="Label" Visible="False"></asp:Label>
                                                                    <asp:Label ID="lbl_Furniture_Property_ID" runat="server" Text="Label" Visible="False"></asp:Label>
                                                                    <asp:Label ID="lbl_furniture_FurnitureId" runat="server" Text="Label" Visible="False"></asp:Label>
                                                                    <asp:Label ID="lbl_furniture_Item_ID" runat="server" Text="Label" Visible="False"></asp:Label>
                                                                </td>
                                                                <td class="column_Center" style="width: 325px; height: 26px"><asp:Button ID="btn_Edit_Furniture_Fixes" runat="server" CssClass="CSButton" Enabled="True" OnClientClick="StartProgressBar();" Text="Edit" Width="75%" />
                                                                </td>
                                                               
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                              
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:View>
                                <asp:View ID="vwAmbulance" runat="server">
                                    <div style="text-align: center">
                                        <div style="text-align: center">
                                            <table style="width: 1000px">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 100px" class="DivTitle">LIST OF AMBULANCE</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            <table width="1000">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 397px; height: 23px; text-align: right"><strong><span style="font-family: Calibri">Search By SERIAL NO.:</span></strong></td>
                                                                        <td style="width: 217px; height: 23px" class="text5">
                                                                            <asp:TextBox ID="txtSearchAmbulance" runat="server" Width="220px" CssClass="text5"></asp:TextBox></td>
                                                                        <td style="height: 23px" align="left">
                                                                            <asp:Button ID="btnSearchAmbulance" OnClick="Button3_Click" runat="server" Width="153px" Text="Search"></asp:Button></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            <asp:GridView ID="grdListAmbulance" runat="server" Width="1000px" SkinID="GridViewGL" OnPageIndexChanging="grdListAmbulance_PageIndexChanging" AllowPaging="True" HorizontalAlign="Center" DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo" OnRowDataBound="grdListAmbulance_RowDataBound" OnSelectedIndexChanged="grdListAmbulance_SelectedIndexChanged" Font-Size="9pt">
                                                                <Columns>
                                                                    <asp:BoundField DataField="type" HeaderText="TYPE OF SERVICE">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Barcode" HeaderText="PLATE NO.">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="DatePurchased" DataFormatString="{0:d}" HeaderText="DATE PURCHASED">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="AcquisitionCost" DataFormatString="{0:N}" HeaderText="ACQUISITION COST">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="MarketValue" DataFormatString="{0:N}" HeaderText="MARKET VALUE">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Condition" HeaderText="CONDITION">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Location" HeaderText="LOCATION">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Status" HeaderText="STATUS">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            <table style="width: 1010px" id="Table9" class="strip">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 1000px; height: 5px; text-align: left">
                                                                            <strong>Vehicle Information</strong></td>
                                                                    </tr>
                                                                </tbody>

                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            <table style="width: 990px" id="ambulance" class="PanelBorder">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 300px; background-color: #c0c0c0"><strong><span style="font-family: Calibri">Vehicle Information</span></strong></td>
                                                                        <td style="width: 300px; background-color: #c0c0c0"><strong><span style="font-family: Calibri">Equipments</span></strong></td>
                                                                        <td style="width: 400px" rowspan="3">
                                                                            <asp:Image ID="Image4" runat="server" Width="350px" ImageUrl="~/images/Ambulance.jpg" CssClass="textimage2" Height="200px" ImageAlign="Middle"></asp:Image></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 300px; border-bottom: gray 2px solid"><span style="color: orangered"><strong><span style="font-family: Calibri">Ambulance Location</span><br />
                                                                        </strong></span>
                                                                            <asp:Label ID="lblAmbulanceLoc" runat="server" Width="220px" Font-Names="Calibri" CssClass="text8" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                        <td style="border-top-width: 2px; border-left-width: 2px; border-left-color: gray; border-bottom-width: 2px; border-bottom-color: gray; width: 300px; border-top-color: gray; border-right-width: 2px; border-right-color: gray" rowspan="2">
                                                                            <asp:Label ID="lblAmbulanceEquip" runat="server" Width="280px" Font-Size="11pt" Font-Names="Calibri" CssClass="text8" Height="60px"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 300px">
                                                                            <table style="width: 300px">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="width: 75px" class="column_RightBold">Brand</td>
                                                                                        <td style="width: 5px" class="column_RightBold">:</td>
                                                                                        <td style="width: 220px" class="text5">
                                                                                            <asp:Label ID="lblAmublanceBrand" runat="server" Width="200px" CssClass="text5" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 75px" class="column_RightBold">Model</td>
                                                                                        <td style="width: 5px" class="column_RightBold">:</td>
                                                                                        <td style="width: 220px" class="text5">
                                                                                            <asp:Label ID="lblAmublanceModel" runat="server" Width="200px" CssClass="text5" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 75px" class="column_RightBold">Area</td>
                                                                                        <td style="width: 5px" class="column_RightBold">:</td>
                                                                                        <td style="width: 220px" class="text5">
                                                                                            <asp:Label ID="lblAmublanceArea" runat="server" Width="200px" CssClass="text5" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 75px" class="column_RightBold">Plate No.</td>
                                                                                        <td style="width: 5px" class="column_RightBold">:</td>
                                                                                        <td style="width: 220px" class="text5">
                                                                                            <asp:Label ID="lblAmublancePlate" runat="server" Width="200px" CssClass="text5" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 75px" class="column_RightBold">Seat </td>
                                                                                        <td style="width: 5px" class="column_RightBold">:</td>
                                                                                        <td style="width: 220px" class="text5">
                                                                                            <asp:Label ID="lblAmublanceSeat" runat="server" Width="200px" CssClass="text5" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 75px" class="column_RightBold">Color</td>
                                                                                        <td style="width: 5px" class="column_RightBold">:</td>
                                                                                        <td style="width: 220px" class="text5">
                                                                                            <asp:Label ID="lblAmublanceColor" runat="server" Width="200px" CssClass="text5" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <div style="text-align: center"></div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px" class="text5">
                                                            <table cellspacing="0" cellpadding="0" width="1000" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 66px; height: 26px">
                                                                            <asp:Button ID="btnAmbulanceLedger" OnClick="btnAmbulanceLedger_Click" runat="server" Width="66px" CssClass="Initial" Text="Ledger"></asp:Button></td>
                                                                        <td style="width: 156px; height: 26px">
                                                                            <asp:Button ID="btnAmbulanceRepairs" OnClick="btnAmbulanceRepairs_Click" runat="server" Width="167px" CssClass="Initial" Text="Repairs and Maintenance"></asp:Button></td>
                                                                        <td style="width: 129px; height: 26px">
                                                                            <asp:Button ID="btnAmbulanceDocuAttch" OnClick="btnAmbulanceDocuAttch_Click" runat="server" Width="129px" CssClass="Initial" Text="Document Attached"></asp:Button></td>
                                                                        <td style="width: 324px; height: 26px"></td>
                                                                        <td style="width: 325px; height: 26px"></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </asp:View>
                                <asp:View ID="vwRoads" runat="server">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 100%" class="DivTitle">LAND INFORMATION

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="right" style="width: 55%">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td class="column_RightBold" style="width: 30%">Address : </td>
                                                                        <td class="column_Left" style="width: 40%">
                                                                            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="99%" ReadOnly="true"></asp:TextBox>
                                                                        </td>
                                                                        <td class="column_RightBold" style="width: 10%">Brgy : </td>
                                                                        <td class="column_Left" style="width: 20%">
                                                                            <asp:TextBox ID="TextBox5" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="89%" ReadOnly="true"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold">Area : </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="TextBox6" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="75%" ReadOnly="true"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold">Tax Dec. No. : </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="TextBox7" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="75%" ReadOnly="true"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold">Previous Owner : </td>
                                                                        <td class="column_Left" colspan=" 3">
                                                                            <asp:TextBox ID="TextBox8" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="95%" ReadOnly="true"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td align="left" style="width: 50%">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td class="column_RightBold" style="width: 25%">Acquisition Date : </td>
                                                                        <td class="column_Left" style="width: 70%">
                                                                            <asp:TextBox ID="TextBox9" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="50%" ReadOnly="true"></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" PopupButtonID="txtEAcqDate" TargetControlID="txtEAcqDate">
                                                                            </cc1:CalendarExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold">Acquisition Cost : </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="TextBox10" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="50%" ReadOnly="true"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold">Acquisition Mode : </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="TextBox11" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="50%" ReadOnly="true"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold">Market Value : </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="TextBox12" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="50%" ReadOnly="true"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%">
                                                    <table style="width: 100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 800px; border: 2px solid #5c85d6">
                                                                    <table style="font-weight: normal; font-size: 9pt; width: 100%; font-family: Arial">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align="center" colspan="5" class="DivTitle" style="width: 100%">PROPERTY IDENTIFICATION
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text5">LGU Code : 
                                                                <asp:Label ID="Label16" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                                <td class="text5">District Code: 
                                                                <asp:Label ID="Label17" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                                <td class="text5">City Code: 
                                                                <asp:Label ID="Label18" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                                <td class="text5">Brgy. Code:
                                                                <asp:Label ID="Label19" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text5">Section No.: 
                                                                <asp:Label ID="Label20" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                                <td class="text5">Parcel No.: 
                                                                <asp:Label ID="Label21" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                                <td class="text5">Series No.: 
                                                                <asp:Label ID="Label22" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                                <td class="text5">RPTIN: 
                                                                <asp:Label ID="Label23" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text5">PIN:
                                                                <asp:Label ID="Label24" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                                <td class="text5">ARP: 
                                                                <asp:Label ID="Label26" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>

                                                                                <td class="text5">TDN: 
                                                                <asp:Label ID="Label31" runat="server" CssClass="text5" BorderStyle="None">
                                                                </asp:Label>
                                                                                </td>
                                                                                <td class="text5">Rev Year: 
                                                                <asp:Label ID="Label32" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="display: none;">
                                                                                <td class="text5">Depreciation Rate: 
                                                                <asp:Label ID="Label33" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>

                                                                                <td class="text5">Depreciated Value:
                                                                                    <asp:Label ID="Label34" runat="server" CssClass="text5" BorderStyle="None"></asp:Label>
                                                                                </td>
                                                                                <td class="text5"></td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                                <td style="width: 220px; border: 2px solid #5c85d6" rowspan="2">

                                                                    <table style="width: 100%">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 150px" valign="top">
                                                                                    <asp:Image ID="Image8" runat="server" Width="150px" ImageUrl="~/images/blankImage.jpg" Height="140px" ImageAlign="Middle"></asp:Image>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="display: none;">
                                                                                <td style="width: 40%" class="text5">Date:</td>
                                                                                <td style="width: 60%" class="text5">
                                                                                    <asp:Label ID="Label35" runat="server" CssClass="txtboxinspection"></asp:Label></td>
                                                                            </tr>
                                                                            <tr style="display: none;">
                                                                                <td style="width: 40%" class="text5">By:</td>
                                                                                <td style="width: 60%" class="text5">
                                                                                    <asp:Label ID="Label36" runat="server" CssClass="txtboxinspection"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="display: none;">
                                                                                <td style="width: 40%" class="text5">Position:</td>
                                                                                <td style="width: 60%" class="text5">
                                                                                    <asp:Label ID="Label37" runat="server" CssClass="txtboxinspection"></asp:Label></td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>

                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td style="width: 800px; border: 2px solid #5c85d6">

                                                                    <table style="width: 100%">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align="center" colspan="4" class="DivTitle" style="width: 100%">LOCATION</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text5">Street: 
                                                                <asp:Label ID="Label38" runat="server" CssClass="text5"></asp:Label>
                                                                                </td>
                                                                                <td class="text5">Purok:
                                                                <asp:Label ID="Label39" runat="server" CssClass="text5"></asp:Label>
                                                                                </td>
                                                                                <td class="text5">Lot No.: 
                                                                <asp:Label ID="Label40" runat="server" CssClass="text5" SkinID="LabelBorder"></asp:Label>
                                                                                </td>
                                                                                <td class="text5">Phase No.: 
                                                                <asp:Label ID="Label41" runat="server" CssClass="text5"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text5">Blk No.:
                                                                                    <asp:Label ID="Label42" runat="server" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                <td class="text5">Subdivision:
                                                                                    <asp:Label ID="Label43" runat="server" CssClass="text5"></asp:Label></td>
                                                                                <td class="text5">Sitio:<asp:Label ID="Label44" runat="server" CssClass="text5"></asp:Label></td>
                                                                                <td class="text5"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text5">City/Mun.:<asp:Label ID="Label45" runat="server" CssClass="text5"></asp:Label></td>
                                                                                <td class="text5">Brgy.:<asp:Label ID="Label46" runat="server" CssClass="text5"></asp:Label></td>
                                                                                <td class="text5">Region:<asp:Label ID="Label47" runat="server" CssClass="text5"></asp:Label></td>
                                                                                <td class="text5"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text5">District:<asp:Label ID="Label48" runat="server" CssClass="text5"></asp:Label></td>
                                                                                <td class="text5">Province:<asp:Label ID="Label49" runat="server" CssClass="text5"></asp:Label></td>
                                                                                <td class="text5">Zip Code:<asp:Label ID="Label50" runat="server" CssClass="text5"></asp:Label></td>
                                                                                <td class="text5"></td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>

                                                                </td>

                                                            </tr>

                                                        </tbody>

                                                    </table>

                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="width: 100%; border: 2px solid #5c85d6">
                                                    <table style="width: 100%">
                                                        <tbody>
                                                            <tr>
                                                                <td align="center" colspan="4" class="DivTitle" style="width: 100%">CHARACTERISTICS</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text5">Classification:
                                                <asp:Label ID="Label51" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                                                <td class="text5">Sub Class: 
                                                <asp:Label ID="Label52" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                                                <td class="text5">Land Use: 
                                                <asp:Label ID="Label53" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                                                <td class="text5" style="display: none">Status: 
                                                <asp:Label ID="Label54" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text5">Taxable:
                                                <asp:Label ID="Label55" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                                                <td class="text5">Area: 
                                                <asp:Label ID="Label56" runat="server" CssClass="text5"></asp:Label>

                                                                </td>
                                                                <td class="text5"></td>
                                                                <td class="text5" style="display: none">Status: 
                                                <asp:Label ID="Label57" runat="server" CssClass="text5"></asp:Label>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">&nbsp; 
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text5">Assessed Value: 
                                            <asp:Label ID="Label58" runat="server" CssClass="text5"></asp:Label>

                                                                </td>
                                                                <td class="text5">Market Value: 
                                            <asp:Label ID="Label59" runat="server" CssClass="text5"></asp:Label>

                                                                </td>
                                                                <td class="text5">Unit Value: 
                                            <asp:Label ID="Label60" runat="server" CssClass="text5"></asp:Label>

                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td class="text5">Date: 
                                           <asp:Label ID="Label61" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                                                <td class="text5">Date: 
                                           <asp:Label ID="Label62" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                                                <td class="text5">Date: 
                                           <asp:Label ID="Label63" runat="server" CssClass="text5"></asp:Label>
                                                                </td>
                                                                <tr>
                                                                    <td class="text5">Amount : 
                                          <asp:Label ID="Label64" runat="server" CssClass="text5"></asp:Label>
                                                                    </td>
                                                                    <td class="text5">Amount :
                                          <asp:Label ID="Label65" runat="server" CssClass="text5"></asp:Label>
                                                                    </td>
                                                                    <td class="text5">Assessment : 
                                          <asp:DropDownList ID="DropDownList3" runat="server" Width="50%" CssClass="text5"></asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </tr>

                                                        </tbody>

                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 100%"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%">
                                                    <br />
                                                    <table style="display: none;">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 3px">
                                                                    <asp:Button ID="Button1" runat="server" Width="105px" CssClass="Initial" Text="Land Document"></asp:Button></td>
                                                                <td>
                                                                    <asp:Button ID="Button2" runat="server" Width="142px" CssClass="Initial" Text="Technical Description"></asp:Button></td>
                                                                <td>
                                                                    <asp:Button ID="Button4" runat="server" Width="101px" CssClass="Initial" Text="Land Valuation"></asp:Button></td>
                                                                <td>
                                                                    <asp:Button ID="Button5" runat="server" Width="137px" CssClass="Initial" Text="History Of Ownership"></asp:Button></td>
                                                                <td>
                                                                    <asp:Button ID="Button6" runat="server" Width="105px" CssClass="Initial" Text="Improvements"></asp:Button></td>
                                                                <td>
                                                                    <asp:Button ID="Button7" runat="server" Width="131px" CssClass="Initial" Text="Approval Information"></asp:Button></td>
                                                                <td>
                                                                    <asp:Button ID="Button8" runat="server" Width="84px" CssClass="Initial" Text="Memoranda"></asp:Button></td>
                                                                <td>
                                                                    <asp:Button ID="Button9" runat="server" Width="143px" CssClass="Initial" Text="Document Attachment"></asp:Button></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <asp:MultiView ID="MultiView1" runat="server" Visible="false">
                                                        <asp:View ID="View2" runat="server">
                                                            <table style="width: 100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 400px">
                                                                            <table style="width: 100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="width: 50%" class="text5">TCT No.:<asp:Label ID="Label66" runat="server" CssClass="text5"></asp:Label></td>
                                                                                        <td style="width: 50%" class="text5">East:<asp:Label ID="Label67" runat="server" Width="70px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 50%" class="text5">OCT No.:<asp:Label ID="Label68" runat="server" CssClass="text5"></asp:Label></td>
                                                                                        <td style="width: 50%" class="text5">North:<asp:Label ID="Label69" runat="server" Width="70px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 50%" class="text5">Date :<asp:Label ID="Label70" runat="server" CssClass="text5"></asp:Label></td>
                                                                                        <td style="width: 50%" class="text5">South:<asp:Label ID="Label71" runat="server" Width="70px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 50%" class="text5">Reg. Date:<asp:Label ID="Label72" runat="server" CssClass="text5"></asp:Label></td>
                                                                                        <td style="width: 50%" class="text5">West:<asp:Label ID="Label73" runat="server" Width="70px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="text5" colspan="2">Cadastral No.:<asp:Label ID="Label74" runat="server" CssClass="text5"></asp:Label></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td style="width: 400px">
                                                                            <table>
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="font-weight: bold; font-size: 10pt; width: 35%; color: white; font-family: Arial; background-color: royalblue" align="center">LINE</td>
                                                                                        <td style="font-weight: bold; font-size: 10pt; width: 35%; color: white; font-family: Arial; background-color: royalblue" align="center">BEARING</td>
                                                                                        <td style="font-weight: bold; font-size: 10pt; width: 35%; color: white; font-family: Arial; background-color: royalblue" align="center">DISTANCE</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="3">
                                                                                            <asp:GridView ID="GridView1" runat="server" Width="350px" SkinID="gvnew" Font-Size="9pt">
                                                                                                <Columns>
                                                                                                    <asp:BoundField DataField="StartingPt" HeaderText="Starting PT">
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

                                                                                                        <ItemStyle Width="50px"></ItemStyle>
                                                                                                    </asp:BoundField>
                                                                                                    <asp:BoundField DataField="endingpt" HeaderText="Ending PT">
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

                                                                                                        <ItemStyle Width="50px"></ItemStyle>
                                                                                                    </asp:BoundField>
                                                                                                    <asp:BoundField DataField="ns" HeaderText="N/S">
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>

                                                                                                        <ItemStyle Width="30px"></ItemStyle>
                                                                                                    </asp:BoundField>
                                                                                                    <asp:BoundField DataField="ns1">
                                                                                                        <HeaderStyle Width="30px"></HeaderStyle>

                                                                                                        <ItemStyle Width="30px"></ItemStyle>
                                                                                                    </asp:BoundField>
                                                                                                    <asp:BoundField DataField="ns2">
                                                                                                        <HeaderStyle Width="30px"></HeaderStyle>

                                                                                                        <ItemStyle Width="30px"></ItemStyle>
                                                                                                    </asp:BoundField>
                                                                                                    <asp:BoundField DataField="we" HeaderText="W/E">
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

                                                                                                        <ItemStyle Width="50px"></ItemStyle>
                                                                                                    </asp:BoundField>
                                                                                                    <asp:BoundField DataField="mDistance" HeaderText="m">
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="110px"></HeaderStyle>

                                                                                                        <ItemStyle Width="110px"></ItemStyle>
                                                                                                    </asp:BoundField>
                                                                                                </Columns>
                                                                                            </asp:GridView>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td style="width: 200px">
                                                                            <img src="../images/TechDesciption.jpg" width="190" /></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="View3" runat="server">
                                                            <table style="height: 236px" width="1000">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="vertical-align: top; width: 750px; height: 230px" align="center">
                                                                            <fieldset style="width: 700px; height: 220px" class="PanelBorder">
                                                                                <br />
                                                                                <br />
                                                                                <asp:GridView ID="GridView2" runat="server" Width="650px" SkinID="gvnew" DataKeyNames="DocuId" PageSize="5" Font-Size="9pt">
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="agency" HeaderText="Agency"></asp:BoundField>
                                                                                        <asp:BoundField DataField="documentname" HeaderText="Document Name"></asp:BoundField>
                                                                                        <asp:BoundField DataField="documentno" HeaderText="Document No."></asp:BoundField>
                                                                                        <asp:BoundField DataField="validatedby" HeaderText="Validated By"></asp:BoundField>
                                                                                        <asp:BoundField DataField="datevalidated" HeaderText="Date Validated"></asp:BoundField>
                                                                                        <asp:BoundField DataField="remarks" HeaderText="Remarks"></asp:BoundField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </fieldset>
                                                                        </td>
                                                                        <td style="vertical-align: top; width: 250px; height: 230px" id="Td5" align="center">
                                                                            <fieldset style="width: 245px; height: 220px" class="PanelBorder"><legend><span style="font-size: 11pt; font-family: Calibri"><strong>Documents</strong></span></legend>
                                                                                <asp:Image ID="Image9" runat="server" Width="220px" ImageUrl="~/images/DefaulScannedDocuments.jpg" Height="200px"></asp:Image></fieldset>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="View4" runat="server">
                                                            <table style="width: 1000px">
                                                                <tbody>
                                                                    <tr>
                                                                        <td align="center" colspan="2">
                                                                            <asp:GridView ID="GridView3" runat="server" Width="900px" SkinID="GridViewAA" DataKeyNames="OwnershipId" Font-Size="9pt">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="year" HeaderText="Year"></asp:BoundField>
                                                                                    <asp:BoundField DataField="ownername" HeaderText="Owner's Name"></asp:BoundField>
                                                                                    <asp:BoundField DataField="ownertype" HeaderText="Ownership Type"></asp:BoundField>
                                                                                    <asp:BoundField DataField="address" HeaderText="Address"></asp:BoundField>
                                                                                    <asp:BoundField DataField="typeacquisition" HeaderText="Type Of Acquisition"></asp:BoundField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 500px" align="center">
                                                                            <fieldset style="width: 450px; height: 120px" class="PanelBorder">
                                                                                <table style="width: 411px" id="tbownership1">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 131px" class="column_LeftBold" align="left">Corporation Name</td>
                                                                                            <td style="width: 11px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 246px">
                                                                                                <asp:Label ID="Label75" runat="server" Width="238px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 131px; height: 16px" class="column_LeftBold" align="left">Address</td>
                                                                                            <td style="width: 11px; height: 16px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 246px; height: 16px">
                                                                                                <asp:Label ID="Label76" runat="server" Width="238px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 131px" class="column_LeftBold" align="left">Telephone No.</td>
                                                                                            <td style="width: 11px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 246px">
                                                                                                <asp:Label ID="Label77" runat="server" Width="238px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 131px" class="column_LeftBold" align="left">Cellphone No.</td>
                                                                                            <td style="width: 11px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 246px">
                                                                                                <asp:Label ID="Label78" runat="server" Width="238px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 131px" class="column_LeftBold" align="left">Email Address</td>
                                                                                            <td style="width: 11px" class="column_LeftBold">:</td>
                                                                                            <td style="width: 246px">
                                                                                                <asp:Label ID="Label79" runat="server" Width="238px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </fieldset>
                                                                        </td>
                                                                        <td style="width: 500px" align="center">
                                                                            <fieldset style="width: 450px; height: 120px" class="PanelBorder">
                                                                                <table style="width: 445px" id="tbownership2">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 209px; height: 16px" class="column_LeftBold" align="left">Chairman</td>
                                                                                            <td style="width: 11px; height: 16px" class="column_LeftBold">:</td>
                                                                                            <td style="height: 16px">
                                                                                                <asp:Label ID="Label80" runat="server" Width="184px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 209px" class="column_LeftBold" align="left">Vice Chairman</td>
                                                                                            <td style="width: 11px" class="column_LeftBold">:</td>
                                                                                            <td>
                                                                                                <asp:Label ID="Label81" runat="server" Width="184px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 209px" class="column_LeftBold" align="left">President</td>
                                                                                            <td style="width: 11px" class="column_LeftBold">:</td>
                                                                                            <td>
                                                                                                <asp:Label ID="Label82" runat="server" Width="184px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 209px; height: 18px" class="column_LeftBold" align="left">Senior Vice President</td>
                                                                                            <td style="width: 11px; height: 18px" class="column_LeftBold">:</td>
                                                                                            <td style="height: 18px">
                                                                                                <asp:Label ID="Label83" runat="server" Width="184px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 209px" class="column_LeftBold" align="left">Administrative&nbsp; Vice President</td>
                                                                                            <td style="width: 11px" class="column_LeftBold">:</td>
                                                                                            <td>
                                                                                                <asp:Label ID="Label84" runat="server" Width="184px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 209px; height: 16px" class="column_LeftBold" align="left">Corporate Secretary</td>
                                                                                            <td style="width: 11px; height: 16px" class="column_LeftBold">:</td>
                                                                                            <td style="height: 16px">
                                                                                                <asp:Label ID="Label85" runat="server" Width="184px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="View5" runat="server">
                                                            <asp:GridView ID="GridView4" runat="server" Width="1000px" SkinID="gvnew" HorizontalAlign="Center" AllowPaging="True" Font-Size="9pt">
                                                                <Columns>
                                                                    <asp:BoundField DataField="classification" HeaderText="Classification"></asp:BoundField>
                                                                    <asp:BoundField DataField="subclassification" HeaderText="Sub- Classification"></asp:BoundField>
                                                                    <asp:BoundField DataField="area" HeaderText="Area"></asp:BoundField>
                                                                    <asp:BoundField DataField="unit" HeaderText="Unit"></asp:BoundField>
                                                                    <asp:BoundField DataField="unitvalue" HeaderText="Unit Value">
                                                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="basemarketvalue" HeaderText="Base Market Value">
                                                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="taxable" HeaderText="Taxable"></asp:BoundField>
                                                                    <asp:BoundField DataField="adjustments" HeaderText="Adjustments"></asp:BoundField>
                                                                    <asp:BoundField DataField="adjustedmarketvalue" HeaderText="Adjusted Market Value">
                                                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="strip" HeaderText="Strip"></asp:BoundField>
                                                                    <asp:BoundField DataField="adjunitvalue" HeaderText="Adj Unit value">
                                                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                    </asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <table width="1000">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 272px; height: 16px" class="text5"></td>
                                                                        <td style="width: 249px; height: 16px" class="text5">
                                                                            <asp:CheckBox ID="CheckBox2" runat="server"></asp:CheckBox>Multiple Classification</td>
                                                                        <td style="width: 116px; height: 16px" class="text5">Total Land Areas :</td>
                                                                        <td style="width: 78px; height: 16px" class="text5">
                                                                            <asp:Label ID="Label86" runat="server" Width="102px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                        <td style="width: 180px; height: 16px" class="text5">Total Base Market Value :</td>
                                                                        <td style="height: 16px" class="text5">
                                                                            <asp:Label ID="Label87" runat="server" Width="102px" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="View6" runat="server">
                                                            <table style="width: 1000px">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 350px" class="text5">
                                                                            <table style="width: 100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="width: 100%" class="text5">
                                                                                            <asp:CheckBox ID="CheckBox3" runat="server" Width="144px" Text="Date Registration"></asp:CheckBox><asp:Label ID="Label88" runat="server" Width="81px" SkinID="LabelBorder" BorderStyle="Solid" BorderWidth="1px">mm/dd/yyyy</asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 100%" class="text5">
                                                                                            <fieldset style="width: 95%" class="PanelBorder">
                                                                                                <legend><span style="font-size: 11pt; font-family: Calibri"><strong>Effectively of Assessment</strong></span></legend>
                                                                                                <table style="width: 279px" id="tbeffectiveness" class="text5">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="width: 136px; height: 24px">
                                                                                                                <asp:DropDownList ID="DropDownList4" runat="server" Width="104px">
                                                                                                                </asp:DropDownList></td>
                                                                                                            <td style="height: 24px">
                                                                                                                <asp:DropDownList ID="DropDownList5" runat="server" Width="104px">
                                                                                                                </asp:DropDownList></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 136px; height: 16px">Quarter</td>
                                                                                                            <td style="height: 16px">Year</td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </fieldset>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 100%" class="text5">
                                                                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="191px" RepeatDirection="Horizontal">
                                                                                                <asp:ListItem>Taxable</asp:ListItem>
                                                                                                <asp:ListItem>Exemption</asp:ListItem>
                                                                                            </asp:RadioButtonList></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td style="width: 650px" class="text5">
                                                                            <fieldset style="width: 98%" class="PanelBorder"><legend><span style="font-size: 11pt; font-family: Calibri"><strong>SIGNATORIES</strong></span></legend>
                                                                                <table style="width: 100%">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 60%" class="text5">Appraised And Assessment By</td>
                                                                                            <td style="width: 10%" class="text5"></td>
                                                                                            <td style="width: 20%" class="text5">Date</td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 60%" class="text4">
                                                                                                <asp:DropDownList ID="DropDownList6" runat="server" Width="95%"></asp:DropDownList></td>
                                                                                            <td style="width: 10%" class="text5">
                                                                                                <asp:CheckBox ID="CheckBox4" runat="server"></asp:CheckBox></td>
                                                                                            <td style="width: 20%" class="text5">
                                                                                                <asp:Label ID="Label89" runat="server" Width="81px" SkinID="LabelBorder" BorderStyle="Solid" BorderWidth="1px">mm/dd/yyyy</asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 60%" class="text5">Recommending Approval</td>
                                                                                            <td style="width: 10%" class="text5"></td>
                                                                                            <td style="width: 20%" class="text5"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 60%" class="text4">
                                                                                                <asp:DropDownList ID="DropDownList7" runat="server" Width="95%"></asp:DropDownList></td>
                                                                                            <td style="width: 10%" class="text5">
                                                                                                <asp:CheckBox ID="CheckBox5" runat="server"></asp:CheckBox></td>
                                                                                            <td style="width: 20%" class="text5">
                                                                                                <asp:Label ID="Label90" runat="server" Width="81px" SkinID="LabelBorder" BorderStyle="Solid" BorderWidth="1px">mm/dd/yyyy</asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 60%" class="text5">Approved By</td>
                                                                                            <td style="width: 10%" class="text5"></td>
                                                                                            <td style="width: 20%" class="text5"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 60%" class="text4">
                                                                                                <asp:DropDownList ID="DropDownList8" runat="server" Width="95%"></asp:DropDownList></td>
                                                                                            <td style="width: 10%" class="text5">
                                                                                                <asp:CheckBox ID="CheckBox6" runat="server"></asp:CheckBox></td>
                                                                                            <td style="width: 20%" class="text5">
                                                                                                <asp:Label ID="Label91" runat="server" Width="81px" SkinID="LabelBorder" BorderStyle="Solid" BorderWidth="1px">mm/dd/yyyy</asp:Label></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="View7" runat="server">
                                                            <table style="width: 1000px">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 1000px">
                                                                            <asp:GridView ID="GridView5" runat="server" Width="1000px" SkinID="gvnew" AllowPaging="True" HorizontalAlign="Center" Font-Size="9pt">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="kind" HeaderText="Kind"></asp:BoundField>
                                                                                    <asp:BoundField DataField="quantity" HeaderText="Quantity"></asp:BoundField>
                                                                                    <asp:BoundField DataField="unitvalue" HeaderText="Unit Value"></asp:BoundField>
                                                                                    <asp:BoundField DataField="basemarketvalue" HeaderText="Base Market Value"></asp:BoundField>
                                                                                    <asp:BoundField DataField="taxable" HeaderText="Taxable"></asp:BoundField>
                                                                                    <asp:BoundField DataField="Subclass" HeaderText="SubClass"></asp:BoundField>
                                                                                    <asp:BoundField DataField="type" HeaderText="Type"></asp:BoundField>
                                                                                    <asp:BoundField DataField="asssessmentlevel" HeaderText="AssessmentLevel"></asp:BoundField>
                                                                                    <asp:BoundField DataField="actualuse" HeaderText="Actual Use"></asp:BoundField>
                                                                                    <asp:BoundField DataField="landimprovements" HeaderText="Land Improvements"></asp:BoundField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 1000px" class="text5">Total Improvement Base Market Value:</td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="View8" runat="server">
                                                            <table style="width: 1000px" class="text5">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="height: 56px" id="Td1" align="center">
                                                                            <fieldset style="width: 876px; height: 55px" class="PanelBorder"><legend>Memoranda</legend>
                                                                                <asp:Label ID="Label92" runat="server" Width="841px" CssClass="text3" SkinID="Label" Height="30px"></asp:Label>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 55px" id="Td2" align="center">
                                                                            <fieldset style="width: 878px; height: 56px" class="PanelBorder"><legend>Remarks</legend>
                                                                                <asp:Label ID="Label93" runat="server" Width="844px" CssClass="text3" SkinID="Label" Height="41px"></asp:Label>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 84px" id="Td3" align="center">
                                                                            <table width="1000">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="width: 10px"></td>
                                                                                        <td style="width: 290px" class="text4">Date of Entry in the Records of Assesment By :</td>
                                                                                        <td style="width: 230px" class="text3">
                                                                                            <asp:Label ID="Label94" runat="server" Width="200px" CssClass="text3"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 100px" class="text4">Date Encoded :</td>
                                                                                        <td style="width: 80px">
                                                                                            <asp:Label ID="Label95" runat="server" CssClass="text3"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 30px" class="text4">By :</td>
                                                                                        <td style="width: 250px" class="text3">
                                                                                            <asp:Label ID="Label96" runat="server" Width="220px" CssClass="text3"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 10px"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 10px"></td>
                                                                                        <td style="width: 290px" class="text5" align="right">
                                                                                            <asp:CheckBox ID="CheckBox7" runat="server" Width="290px" CssClass="text4" Text="Date"></asp:CheckBox></td>
                                                                                        <td style="width: 230px" class="text3">
                                                                                            <asp:Label ID="Label97" runat="server" Width="200px" CssClass="text3" SkinID="LabelBorder" Font-Italic="True"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 100px" class="text4">Date Uploaded :</td>
                                                                                        <td style="width: 80px">
                                                                                            <asp:Label ID="Label98" runat="server" CssClass="text3"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 30px" class="text4">By :</td>
                                                                                        <td style="width: 250px" class="text3">
                                                                                            <asp:Label ID="Label99" runat="server" Width="220px" CssClass="text3"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 10px"></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>

                                                        </asp:View>
                                                        <asp:View ID="View9" runat="server">
                                                            <table style="width: 1000px">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 700px">
                                                                            <fieldset style="vertical-align: middle; width: 690px; height: 220px; text-align: center" class="PanelBorder">
                                                                                <legend><span style="font-size: 11pt; font-family: Calibri"><strong>DOCUMENTS DETAILS</strong></span></legend>
                                                                                <br />
                                                                                <asp:GridView ID="GridView6" runat="server" Width="650px" SkinID="gvnew" DataKeyNames="DocuId" PageSize="5" Font-Size="9pt">
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="documentname" HeaderText="Document Name"></asp:BoundField>
                                                                                        <asp:BoundField DataField="documentno" HeaderText="Document No."></asp:BoundField>
                                                                                        <asp:BoundField DataField="validatedby" HeaderText="Validated By"></asp:BoundField>
                                                                                        <asp:BoundField DataField="datevalidated" HeaderText="Date Validated"></asp:BoundField>
                                                                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks"></asp:BoundField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </fieldset>
                                                                        </td>
                                                                        <td style="width: 300px">
                                                                            <fieldset style="width: 280px; height: 220px" class="PanelBorder"><legend><span style="font-size: 11pt; font-family: Calibri"><strong>ATTACHED DOCUMENTS</strong></span></legend>
                                                                                <asp:Image ID="Image10" runat="server" Width="220px" ImageUrl="~/images/DefaulScannedDocuments.jpg" Height="200px"></asp:Image></fieldset>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </asp:View>

                                                    </asp:MultiView></td>
                                            </tr>
                                        </tbody>
                                    </table>

                                </asp:View>
                                <asp:View ID="vwInfrastructures" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="center" class="DivTitle" style="width: 100%">ROADS AND BRIDGES CONSTRUCTION INFORMATION 
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:MultiView ID="mvInfrastructures" runat="server">

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
                                                                        <asp:TextBox ID="txtRoadProjectName" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Location :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadLocation" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Traffic Volume :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadTrafficVolume" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Road ID :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadID" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Length :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadLength" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Traffic Date :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtTrafficDate" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Road Name :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadName" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">No of Lanes :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtNoofLane" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Speed Limit :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadSpeedLimit" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Classification :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadClassification" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Width :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadWidth" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Elevation (m) :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadElevation" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Road Type :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadType" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Lane Length :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadLaneLength" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Surface Type :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadSurfaceType" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">From Street :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadFromStreet" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Lane Width :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadLaneWidth" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Surface Condition :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadSurfaceCondition" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">To Street :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadtoStreet" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Traffic Direction :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadTrafficDirection" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Segment Lock :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadSegmentLock" runat="server" Width="10%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
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
                                                                        <asp:TextBox ID="txtRoadLfromAddress" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">L to Address :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadLtoAddress" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">N/W Shldr Width :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadNorthWestWidth" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
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
                                                                        <asp:TextBox ID="txtRoadRfromAddress" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">R to Address :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadRtoAddress" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">S/E Shldr Width :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtRoadSouthEastWidth" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
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
                                                                                            <td class="column_RightBold">Acquisition Date :
                                                                                            </td>
                                                                                            <td class="column_Left" style="width: 100px;">
                                                                                                <asp:Label ID="Label103" runat="server"></asp:Label>
                                                                                                <asp:TextBox ID="txtRoadAcqDate" runat="server" CssClass="txtbox_Var" Enabled="False" onchange="return NoOfYearsRoad(this.value);"></asp:TextBox>
                                                                                                <cc1:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txtRoadAcqDate" PopupButtonID="txtRoadAcqDate"></cc1:CalendarExtender>


                                                                                                &nbsp;(MM/DD/YYYY)</td>
                                                                                            <td class="column_RightBold">Market Value :
                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:Label ID="Label104" runat="server"></asp:Label>
                                                                                                <asp:TextBox ID="txtRoadMarketValue" runat="server" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);" Enabled="False"></asp:TextBox>

                                                                                            </td>


                                                                                        </tr>
                                                                                        <tr>

                                                                                            <td class="column_RightBold">Acquisition Cost :
                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:Label ID="Label105" runat="server"></asp:Label>
                                                                                                <asp:TextBox ID="txtRoadAcqCost" runat="server" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalValRoad(this),getDepValRateRoad(this);" Enabled="False"></asp:TextBox>
                                                                                            </td>

                                                                                            <td class="column_RightBold">No. of Years :
                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:Label ID="Label106" runat="server"></asp:Label>
                                                                                                <asp:TextBox ID="txtRoadNoYears" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>

                                                                                            <td class="column_RightBold">Depreciated Rate :
                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:TextBox ID="txtRoadequipmentdepreciatedRate" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" MaxLength="5" ReadOnly="True" Enabled="False"></asp:TextBox>&nbsp;(%) Percent</td>


                                                                                            <td class="column_RightBold">Useful Life :
                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:Label ID="Label107" runat="server"></asp:Label>
                                                                                                <asp:TextBox ID="txtRoadUsefulLife" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False" onchange="return getDepValRateRoad(this);"></asp:TextBox>

                                                                                                &nbsp;(Years)</td>

                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="column_RightBold">Depreciated Value :</td>
                                                                                            <td class="column_Left">
                                                                                                <asp:TextBox ID="txtDepreciatedValueRoadNew" runat="server" CssClass="txtbox_Amt"></asp:TextBox>
                                                                                            </td>
                                                                                            <td class="column_RightBold">Salvage Value :</td>
                                                                                            <td class="column_Left">
                                                                                                <asp:TextBox ID="txtRoadSalvageValue" runat="server" AutoPostBack="True" CssClass="txtboxAmount" Enabled="False" Onchange="this.value=formatCurrency(this.value);" Onkeyup="javascript:this.value=Comma(this.value);" Width="85%">0.00</asp:TextBox>
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr>

                                                                                            <td class="column_RightBold">Depreciation Value :
                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:Label ID="Label109" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                                <asp:TextBox ID="txtRoadequipmentdepreciatedvalue" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);" Enabled="False"></asp:TextBox>
                                                                                            </td>

                                                                                            <td class="column_RightBold">&nbsp;</td>
                                                                                            <td class="column_Left">
                                                                                                &nbsp;</td>


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
                                                                                                <asp:TextBox ID="txtRoadContractor" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                            </td>
                                                                                            <td class="column_RightBold">Contact Person : 
                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:TextBox ID="txtRoadContactPerson" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                            </td>
                                                                                            <td class="column_RightBold">Cellphone No. : 
                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:TextBox ID="txtRoadCellphoneNo" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </fieldset>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="width: 20%; border: 2px solid #5c85d6">
                                                                    <asp:Image ID="Image14" runat="server" Width="204px" ImageUrl="~/images/blankImage.jpg" Height="202px"></asp:Image></center>
                                          <br />
                                                                    <asp:Button ID="Button19" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>

                                                                </td>

                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:Label ID="lbl_Road_Bridge_Trap" runat="server" Text="Label" Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                          <asp:Label ID="lbl_Road_EquipInfoId" runat="server" Text="Label" Visible="false"></asp:Label>
                                                          <asp:Label ID="lbl_Road_Property_ID" runat="server" Text="Label" Visible="false"></asp:Label>
                                                          <asp:Label ID="lbl_Road_EquipmentId" runat="server" Text="Label" Visible="false"></asp:Label>
                                                          <asp:Label ID="lbl_Road_Item_ID" runat="server" Text="Label" Visible="false"></asp:Label>

                                                    </td>
                                                    <td class="column_Right" style="width:200px">
                                                        <asp:Button ID="btn_Edit_Road" runat="server" CssClass="CSButton" Enabled="false" Text="Edit" Width="150px" />
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
                                                                        <asp:TextBox ID="txtBridgeProjectName" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Location :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeLocation" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Name of River :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeNameofRiver" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Bridge ID :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeID" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Route No. :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeRouteNo" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Reference Post :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeReferencePost" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Bridge Name :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeName" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Featured Intersected :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeFeaturedIntersected" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">End Reference Post :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeEndReferencePost" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Bridge Type :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeType" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Mile Point :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeMilePoint" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Start Position :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeStartPosition" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Bridge Structure No. :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeStructureNo" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Border Struct No. :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeBorderStructNo" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Current Station :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeCurrentStation" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Route Sign Prefix :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeRouteSignPrefix" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Road No. :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeRoadNo" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
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
                                                                        <asp:TextBox ID="txtBridgeLfromAddress" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">L to Address :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeLtoAddress" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">N/W Shldr Width :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeNorthWestWidth" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
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
                                                                        <asp:TextBox ID="txtBridgeRfromAddress" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">R to Address :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeRtoAddress" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">S/E Shldr Width :
                                                                    </td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtBridgeSouthEastWidth" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
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
                                                                                            <td class="column_RightBold">Acquisition Date :

                                                                                            </td>
                                                                                            <td class="column_Left" style="width: 100px;">
                                                                                                <asp:Label ID="Label110" runat="server"></asp:Label>
                                                                                                <asp:TextBox ID="txtBridgeAcqDate" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False" onchange="return NoOfYearsBridge(this.value);" ></asp:TextBox>
                                                                                                <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txtBridgeAcqDate" PopupButtonID="txtBridgeAcqDate"></cc1:CalendarExtender>


                                                                                                &nbsp;(MM/DD/YYYY)</td>
                                                                                            <td class="column_RightBold">Market Value :

                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:Label ID="Label111" runat="server"></asp:Label>
                                                                                                <asp:TextBox ID="txtBridgeMarketValue" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);" Enabled="False"></asp:TextBox>

                                                                                            </td>


                                                                                        </tr>
                                                                                        <tr>

                                                                                            <td class="column_RightBold">Acquisition Cost :

                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:Label ID="Label112" runat="server"></asp:Label>
                                                                                                <asp:TextBox ID="txtBridgeAcqCost" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalValBridge(this),getDepValRateBridge(this);" Enabled="False"></asp:TextBox>
                                                                                            </td>

                                                                                            <td class="column_RightBold">No. of Years :

                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:Label ID="Label113" runat="server"></asp:Label>
                                                                                                <asp:TextBox ID="txtBridgeNoYears" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>

                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>

                                                                                            <td class="column_RightBold">Depreciated Rate :

                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:TextBox ID="txtBridgeDepRate" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" MaxLength="5" ReadOnly="True" Enabled="False"></asp:TextBox>&nbsp;(%) Percent

                                                                                            </td>


                                                                                            <td class="column_RightBold">Useful Life :

                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:Label ID="Label114" runat="server"></asp:Label>
                                                                                                <asp:TextBox ID="txtBridgeUsefulLife" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var" Enabled="False" onchange="return getDepValRateBridge(this);"></asp:TextBox>

                                                                                                &nbsp;(Years)</td>

                                                                                        </tr>

                                                                                        <tr>  
                                                                                            <td class="column_RightBold">Depreciated Value :</td>
                                                                                            <td class="column_Left">
                                                                                                <asp:TextBox ID="txtDepreciatedValueRBNew" runat="server" CssClass="txtbox_Var"></asp:TextBox>
                                                                                            </td>
                                                                                            <td class="column_RightBold">Salvage Value :</td>
                                                                                            <td class="column_Left">
                                                                                                <asp:TextBox ID="txtBridgeSalvageValue" runat="server" AutoPostBack="True" CssClass="txtboxAmount" Enabled="False" Onchange="this.value=formatCurrency(this.value);" Onkeyup="javascript:this.value=Comma(this.value);" Width="85%">0.00</asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>

                                                                                            <td class="column_RightBold">Depreciation Value :

                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:Label ID="Label117" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                                                                <asp:TextBox ID="txtBridgeDepValue" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);" Enabled="False"></asp:TextBox>
                                                                                            </td>

                                                                                            <td class="column_RightBold">&nbsp;</td>
                                                                                            <td class="column_Left">
                                                                                                &nbsp;</td>


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
                                                                                                <asp:TextBox ID="txtBridgeContractor" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                            </td>
                                                                                            <td class="column_RightBold">Contact Person : 
                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:TextBox ID="txtBridgeContactPerson" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                            </td>
                                                                                            <td class="column_RightBold">Cellphone No. : 
                                                                                            </td>
                                                                                            <td class="column_Left">
                                                                                                <asp:TextBox ID="txtBridgeCellphoneNo" runat="server" Width="75%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </fieldset>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="width: 20%; border: 2px solid #5c85d6">
                                                                    <asp:Image ID="Image15" runat="server" Width="204px" ImageUrl="~/images/blankImage.jpg" Height="202px"></asp:Image></center>
                                          <br />
                                                                    <asp:Button ID="btnBridgeUpload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>

                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td >
                                                        <asp:Label ID="lblRoadBridgeEquipInfoId" runat="server" Text="Label" Visible="False"></asp:Label>
                                                        <asp:Label ID="lblRoadBridgeEquipmentId" runat="server" Text="Label" Visible="False"></asp:Label>
                                                        <asp:Label ID="lblRoadBridgeProperty_ID" runat="server" Text="Label" Visible="False"></asp:Label>
                                                        <asp:Label ID="lblRoadBridge_Item_ID" runat="server" Text="Label" Visible="False"></asp:Label>
                                                    </td>
                                                    <td class="column_Right"><asp:Button ID="btn_Edit_Road_and_Bridge" runat="server" CssClass="CSButton" Enabled="false" OnClientClick="StartProgressBar();" Text="Edit" Width="150px" /></td>
                                               </tr>


                                            </table>
                                        </asp:View>


                                    </asp:MultiView>
                                </asp:View>
                                <asp:View ID="vwBooks" runat="server">
                                    <table>

                                        <tr>
                                            <td align="center" class="DivTitle" style="width: 100%">
                                                <asp:Label ID="Label118" runat="server" Text="BOOKS INFORMATION"></asp:Label>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%">

                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Name :

                                                        </td>
                                                        <td class="column_Left" style="width: 30%">

                                                            <asp:TextBox ID="txtbookName" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>

                                                        <td class="column_RightBold" style="width: 10%">Unit :

                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <span class="column_RightBold">
                                                            <asp:DropDownList ID="drpbookUnit" runat="server" CssClass="drpdownCSS" Width="100px">
                                                            </asp:DropDownList>
                                                            &nbsp;Quantity :</span>
                                                            <asp:TextBox ID="txtbookQuantity" runat="server" Width="100px" CssClass="txtbox_Var"></asp:TextBox>

                                                        </td>
                                                        <td align="center" rowspan="6" style="width: 20%" valign="middle">
                                                            <asp:Image ID="Image16" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                                            <br />
                                                            <asp:Button ID="btnbookupload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Description :

                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:TextBox ID="txtbookdesciption" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                                        </td>
                                                        <td class="column_RightBold" style="width: 10%">Price :

                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:TextBox ID="txtBookPrice" runat="server" Width="25%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Classification :

                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:TextBox ID="txtBookClassification" runat="server" Width="60%" CssClass="txtbox_Var"></asp:TextBox>

                                                            <asp:TextBox ID="txtBookClassificationCode" runat="server" Width="25%" CssClass="txtbox_Var"></asp:TextBox>

                                                        </td>
                                                        <td class="column_RightBold">ISBN :
                                                        </td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtBookISBN" runat="server" Width="89%" CssClass="txtbox_Var"></asp:TextBox>

                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Title :

                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:TextBox ID="txtbookTitle" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                                        </td>

                                                        <td class="column_RightBold" style="width: 10%">Author :

                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:TextBox ID="txtbookAuthor" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Publication Date :

                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:TextBox ID="txtBookPublicationDate" runat="server" CssClass="txtbox_Var" ReadOnly="true"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txtBookPublicationDate" PopupButtonID="txtBookPublicationDate"></cc1:CalendarExtender>

                                                        </td>
                                                        <td></td>
                                                        <td class="column_Left">
                                                            <asp:LinkButton ID="Linkbutton1" runat="server" Text="View Property Information"></asp:LinkButton>

                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            <fieldset style="width: 90%;">
                                                                <legend class="column_LeftBold">Acquisition :

                                                                </legend>
                                                                <table>
                                                                    <tr>
                                                                        <td class="column_RightBold">Acquisition Date :

                                                                        </td>
                                                                        <td class="column_Left" style="width: 300px;">
                                                                            <asp:TextBox ID="txtbookAcqDate" runat="server" AutoPostBack="True" CssClass="txtbox_Var" onchange="return NoOfYearsBook(this.value);"></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="txtbookAcqDate" PopupButtonID="txtbookAcqDate"></cc1:CalendarExtender>


                                                                            &nbsp;(MM/DD/YYYY)</td>
                                                                        <td class="column_RightBold">Market Value :

                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtbookMarketValue" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>

                                                                        </td>


                                                                    </tr>
                                                                    <tr>

                                                                        <td class="column_RightBold">Acquisition Cost :

                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtbookAcqCost" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalValBook(this),getDepValRateBook(this);"></asp:TextBox>
                                                                        </td>

                                                                        <td class="column_RightBold">No. of Years :

                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtbookNoYears" runat="server" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                                                        </td>
                                                                    </tr>
                                                                    <tr>

                                                                        <td class="column_RightBold">Depreciated Rate :

                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtbookdepreciatedRate" runat="server" Width="100px" CssClass="txtboxAmount" MaxLength="5"></asp:TextBox>&nbsp;(%) Percent

                                                                        </td>


                                                                        <td class="column_RightBold">Useful Life :

                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtbookUsefulLife" runat="server" Width="100px" CssClass="txtbox_Var" onchange="return getDepValRateBook(this);"></asp:TextBox>

                                                                            &nbsp;(Years)

                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold">Depreciated Value :</td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtDepreciatedValueBookNew" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                                                        <td class="column_RightBold">Salvage Value : </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtbookSalvageValue" runat="server" CssClass="txtboxAmount" Onchange="this.value=formatCurrency(this.value);" Onkeyup="javascript:this.value=Comma(this.value);" style="margin-bottom: 0px" Width="85%">0.00</asp:TextBox>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>

                                                                        <td class="column_RightBold">Depreciation Value :

                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtbookdepreciatedvalue" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>

                                                                        </td>

                                                                        <td class="column_RightBold">&nbsp;</td>
                                                                        <td class="column_Left">
                                                                            &nbsp;</td>


                                                                    </tr>

                                                                </table>
                                                            </fieldset>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            <fieldset style="width: 93%;">
                                                                <legend class="column_Left" style="font-family: Arial; color: #404040;"><strong>Location:</strong></legend>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td class="column_RightBold">Warehouse :

                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:DropDownList ID="drpbookWarehouse" runat="server" Width="98%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                                        </td>

                                                                        <td class="column_RightBold">Bay :

                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtbookBay" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                        </td>

                                                                        <td class="column_RightBold" style="width: 15%">Column :

                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtbookColumn" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                        </td>

                                                                        <td class="column_RightBold" style="width: 10%">Floor :

                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtbookFloor" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold">Room :

                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtbookRoom" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                                        </td>

                                                                        <td class="column_RightBold" style="width: 10%">Shelves :

                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtbookShelves" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                                        </td>

                                                                        <td class="column_RightBold">Rack :

                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtbookRack" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                        </td>

                                                                        <td class="column_RightBold">Bin :

                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtbookBin" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                        </td>
                                                                    </tr>

                                                                </table>
                                                            </fieldset>
                                                        </td>
                                                        <td style="top:50px" class="column_Center"> 
                                                            <br />
                                                            <br />
                                                            <br />
                                                            <br />
                                                            <asp:Button ID="btn_EditBooks" runat="server" CssClass="CSButton" Enabled="false" OnClientClick="StartProgressBar();" Text="Edit" Width="150px" />
                                                        </td>
                                                    </tr>
                                                    <tr style="display:none">
                                                        <td style="width:200px">
                                                            <asp:Label ID="lbl_book_EquipInfoId" runat="server" Text="Label"></asp:Label>
                                                            <asp:Label ID="lbl_book_Property_ID" runat="server" Text="Label"></asp:Label>
                                                            <asp:Label ID="lbl_book_item_ID" runat="server" Text="Label"></asp:Label>
                                                            <asp:Label ID="lbl_book_EquipmentId" runat="server" Text="Label"></asp:Label>
                                                            <asp:TextBox ID="txtbookUnit" runat="server" AutoPostBack="true" CssClass="drpdownCSS" Width="100px"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                </table>

                                            </td>

                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="vwGun" runat="server">

                                    <table style="width: 100%;">
                                        <tr>
                                            <td align="center" class="DivTitle" style="width: 100%" colspan="5">
                                              MILITARY, POLICE and SECURITY EQUIPMENT INFORMATION
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Name :

                                            </td>
                                            <td class="column_Left" style="width: 30%">
                                             <asp:TextBox ID="txtMilitaryEquipmentName" runat="server" Width="89%" CssClass="txtbox_Var"></asp:TextBox>
                                                   
                                            </td>

                                            <td class="column_RightBold" style="width: 15%">Unit :

                                            </td>
                                            <td class="column_Left" style="width: 25%">
                                                   <asp:TextBox ID="txtMilitaryEquipmentUnit" runat="server" Width="75px" CssClass="txtbox_Var"></asp:TextBox>
                                                    <span class="column_RightBold">Quantity :</span>
                                                <asp:TextBox ID="txtMilitaryEquipmentQuantity" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>

                                            </td>
                                            <td align="center" rowspan="7" style="width: 30%" valign="top">
                                                <asp:Image ID="Image17" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                                <br />
                                                <asp:Button ID="btnMilitaryEquipmentUpload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Description :

                                            </td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtMilitaryEquipmentDescription" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                            </td>
                                            <td class="column_RightBold">Frame :

                                            </td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtMilitaryEquipmentFrame" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold">Manufacturer :

                                            </td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtMilitaryEquipmentManufacturer" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                            </td>
                                            <td class="column_RightBold">Color / Finish :

                                            </td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtMilitaryEquipmentColor" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold">Caliber :

                                            </td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtMilitaryEquipmentCaliber" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                            </td>

                                            <td class="column_RightBold">Capacity Extended :

                                            </td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtMilitaryEquipmentCapacityExtended" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="column_RightBold">Barrel :

                                            </td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtMilitaryEquipmentBarrel" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold">Sights :

                                            </td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtMilitaryEquipmentSights" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                            </td>


                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td class="column_Left">
                                                <asp:LinkButton ID="btnMilitaryEquipmentaddpropertyinfo" runat="server" Text="Add Property Information"></asp:LinkButton>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <fieldset style="width: 90%;">
                                                    <legend class="column_LeftBold">Acquisition :</legend>
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="column_RightBold">Acquisition Date :

                                                            </td>
                                                            <td class="column_Left" style="width: 200px;">
                                                                <asp:TextBox ID="txtMilitaryEquipmentAcqDate" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var" ></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="txtMilitaryEquipmentAcqDate" PopupButtonID="txtMilitaryEquipmentAcqDate"></cc1:CalendarExtender>


                                                                &nbsp;(MM/DD/YYYY)</td>
                                                            <td class="column_RightBold">Market Value :

                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMilitaryEquipmentMarketValue" runat="server" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                                            </td>


                                                        </tr>
                                                        <tr>

                                                            <td class="column_RightBold">Acquisition Cost :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMilitaryEquipmentAcqCost" runat="server" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>

                                                            <td class="column_RightBold">No. of Years :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMilitaryEquipmentNoYears" runat="server" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr>

                                                            <td class="column_RightBold">Dep. Rate :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMilitaryEquipmentDepRate" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" MaxLength="5" OnTextChanged="lblequipmentdepreciatedRate_TextChanged"></asp:TextBox>&nbsp;(%) Percent</td>


                                                            <td class="column_RightBold">Useful Life :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMilitaryEquipmentUsefulLife" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var" OnTextChanged="lblequipmentdepreciatedRate_TextChanged"></asp:TextBox>

                                                                &nbsp;(Years)</td>

                                                        </tr>


                                                        <tr>

                                                            <td class="column_RightBold">Dep. Value :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMilitaryEquipmentDepValue" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>

                                                            <td class="column_RightBold">Salvage Value :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMilitaryEquipmentSalvageValue" runat="server" Width="85%" CssClass="txtboxAmount">0.00</asp:TextBox></td>


                                                        </tr>

                                                    </table>
                                                </fieldset>
                                            </td>
                                        </tr>
                                    </table>

                                </asp:View>  
                                <asp:View ID="vwMilitaryDefault" runat="server">
                                       
                                    <table style="width: 100%;">
                                          <tr>
                                            <td align="center" class="DivTitle" style="width: 100%" colspan="5">
                                              MILITARY, POLICE and SECURITY EQUIPMENT INFORMATION
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Name :

                                            </td>
                                            <td class="column_Left" style="width: 30%">


                                                <asp:TextBox ID="txtMilitaryDefaultName" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                            </td>

                                            <td class="column_RightBold" style="width: 15%">Unit :

                                            </td>
                                            <td class="column_Left" style="width: 25%">
                                                <asp:TextBox ID="txtMilitaryDefaultUnit" runat="server" Width="75px" AutoPostBack="True" CssClass="txtbox_Var" ></asp:TextBox>

                                                <span class="column_RightBold">Quantity :</span>
                                                <asp:TextBox ID="txtMilitaryDefaultQuantity" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>

                                            </td>
                                            <td align="center" rowspan="6" style="width: 20%" valign="middle">
                                                <asp:Image ID="imgMilitaryDefault" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                                <br />
                                                <asp:Button ID="btnMilitaryDefaultUpload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Description :

                                            </td>
                                            <td class="column_Left" style="width: 30%">
                                                 <asp:TextBox ID="txtMilitaryDefaultDescription" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                            </td>
                                            <td class="column_RightBold" style="width: 10%">Warranty :

                                            </td>
                                            <td class="column_Left" style="width: 30%">
                                               <asp:TextBox ID="txtMilitaryDefaultWarranty" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Power Input :

                                            </td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtMilitaryDefaultPowerInput" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                            </td>
                                            <td class="column_RightBold">Installed At :

                                            </td>
                                            <td class="column_Left">
                                                 <asp:TextBox ID="txtMilitaryDefaultInstalled" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                            </td>
                                            <td class="column_RightBold" style="width: 10%; display: none;">Area Capacity :

                                            </td>
                                            <td class="column_Left" style="width: 30%; display: none;">
                                                <asp:TextBox ID="txtMilitaryDefaultAreaCapacity" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                            
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Model :

                                            </td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtMilitaryDefaultModel" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                            </td>

                                            <td class="column_RightBold" style="width: 10%">Dimension :

                                            </td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtMilitaryDefaultDimension" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                           
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Serial Number :

                                            </td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtMilitaryDefaultSerialNumber" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                            
                                            </td>
                                            <td></td>
                                            <td class="column_Left">
                                                <asp:LinkButton ID="btnMilitaryDefaultPropertyInfo" runat="server" Text="View Property Information" ></asp:LinkButton>

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
                                                                <asp:TextBox ID="txtMilitaryDefaultContractor" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Contact Person : 
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMilitaryDefaultContactPerson" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Cellphone No. : 
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMilitaryDefaultCellphoneNo" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
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
                                                            <td class="column_RightBold">Acquisition Date :

                                                            </td>
                                                            <td class="column_Left" style="width: 100px;">
                                                                <asp:TextBox ID="txtMilitaryDefaultAcqDate" runat="server" CssClass="txtbox_Var" ></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender13" runat="server" TargetControlID="txtMilitaryDefaultAcqDate" PopupButtonID="txtMilitaryDefaultAcqDate"></cc1:CalendarExtender>


                                                                &nbsp;(MM/DD/YYYY)</td>
                                                            <td class="column_RightBold">Market Value :

                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMilitaryDefaultMarketValue" runat="server" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                                            </td>


                                                        </tr>
                                                        <tr>

                                                            <td class="column_RightBold">Acquisition Cost :

                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMilitaryDefaultAcqCost" runat="server" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                            
                                                            </td>

                                                            <td class="column_RightBold">No. of Years :

                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMilitaryDefaultNoofYears" runat="server" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr>

                                                            <td class="column_RightBold">Dep. Rate :

                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMilitaryDefaultDepRate" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" MaxLength="5" ReadOnly="True" OnTextChanged="lblequipmentdepreciatedRate_TextChanged"></asp:TextBox>&nbsp;(%) Percent

                                                            </td>


                                                            <td class="column_RightBold">Useful Life :

                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMilitaryDefaultUsefulLife" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var" OnTextChanged="lblequipmentdepreciatedRate_TextChanged"></asp:TextBox>

                                                                &nbsp;(Years)</td>

                                                        </tr>


                                                        <tr>

                                                            <td class="column_RightBold">Dep. Value :

                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtMilitaryDefaultDepValue" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                            
                                                            </td>


                                                            <td class="column_RightBold">Salvage Value :

                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txttxtMilitaryDefaultSalvageValue" runat="server" Width="85%" CssClass="txtboxAmount">0.00</asp:TextBox>

                                                            </td>


                                                        </tr>

                                                    </table>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td colspan="4">
                                                <fieldset style="width: 90%;">
                                                    <legend class="column_Left" style="font-family: Arial; color: #404040;"><strong>Location:</strong></legend>
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="column_RightBold">Warehouse :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:DropDownList ID="DropDownList25" runat="server" Width="98%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                            </td>

                                                            <td class="column_RightBold">Bay :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="TextBox40" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                <asp:DropDownList ID="DropDownList26" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                            </td>

                                                            <td class="column_RightBold" style="width: 15%">Column :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="TextBox41" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                <asp:DropDownList ID="DropDownList27" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                            </td>

                                                            <td class="column_RightBold" style="width: 10%">Floor :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="TextBox42" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                <asp:DropDownList ID="DropDownList28" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">Room :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="TextBox43" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                <asp:DropDownList ID="DropDownList29" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                            </td>

                                                            <td class="column_RightBold" style="width: 10%">Shelves :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="TextBox44" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                <asp:DropDownList ID="DropDownList30" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                            </td>

                                                            <td class="column_RightBold">Rack :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="TextBox45" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                                <asp:DropDownList ID="DropDownList31" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                            </td>

                                                            <td class="column_RightBold">Bin :
                                                            </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="TextBox46" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                                <asp:DropDownList ID="DropDownList32" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Specifications :

                                            </td>
                                            <td class="column_Left" colspan="3">
                                                <asp:TextBox ID="txttxtMilitaryDefaultSpecifications" runat="server" Width="95%" Height="25px" TextMode="MultiLine" AutoPostBack="True" CssClass="txtbox_Var" Rows="2"></asp:TextBox>

                                            </td>
                                        </tr>

                                    </table>

                                  </asp:View>
                                <asp:View ID="vwIntangibleAsset" runat="server">
                                          <div>
                                          <table width="100%">
                                              <tbody>
                                             
                                             <tr>
                                                 <td>
                                                     <table>
                                                         <tr>
                                                             <td class="column_RightBold"></td>
                                                             <td class="column_Left"></td>
                                                         </tr>
                                                     </table>
                                                 </td>
                    
                                             </tr>

                                            <tr>
                                                <td align="center" style="width: 100%"><asp:HiddenField ID="HiddenField2" runat="server" /><asp:HiddenField ID="hdnGAId" runat="server" /></td>
                                            </tr>

                                            <tr>
                                                <td align="center" class="DivTitle" style="width: 100%">
                                                    INTANGIBLE ASSET INFORMATION 
                                                </td>
                                            </tr>
                                                  
                                              <tr>
                                                  <td>
                                                  <table width="">
                            
                                                       <tr>
                                                          <td style="width:145px" class="column_RightBold"></td>
                                                          <td style="width:145px" class="column_Left">
                                                          </td>
                                                          <td style="width:145px"></td>
                                                          <td style="width:145px"></td>
                                                          <td style="width:145px"></td>
                                                          <td style="width:145px"></td>
                                                          <td style="width:145px"></td>
                                                      </tr>
                                                       <tr>
                                                          <td style="width:145px" class="column_RightBold">Title :</td>
                                                          <td style="width:145px" class="column_Left">
                                                              <asp:TextBox ID="txtIntanTitle" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                          </td>
                                                          <td style="width:145px" class="column_RightBold">No. of Disc :</td>
                                                          <td style="width:145px"> 
                                                              <asp:TextBox ID="txtIntanNoofdisc" CssClass="txtbox_Var" runat="server" Enabled="False"></asp:TextBox></td>
                                                          <td style="width:145px"></td>
                                                          <td style="width:145px"></td>
                                                          <td style="width:145px"></td>
                                                      </tr>
                                                      <tr>
                                                          <td style="width:145px; height: 23px;" class="column_RightBold">Brand :</td>
                                                          <td style="width:145px; height: 23px;" class="column_Left">
                                                              <asp:TextBox ID="txtIntanBrand" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                          </td>
                                                          <td style="width:145px; height: 23px;" class="column_RightBold">Model :</td>
                                                          <td style="width:145px; height: 23px;"> 
                                                              <asp:TextBox ID="txtIntanModel" CssClass="txtbox_Var" runat="server" Enabled="False"></asp:TextBox></td>
                                                          <td style="width:145px; height: 23px;"></td>
                                                          <td style="width:145px; height: 23px;" colspan="2" rowspan="4">
                                                              <asp:Image ID="Image18" runat="server" Height="202px" ImageUrl="~/images/blankImage.jpg" Width="204px" />
                                                              <asp:Button ID="Button11" runat="server" OnClientClick="StartProgressBar();" CssClass="CSButton" Text="UPLOAD" Width="120px" />
                                                          </td>
                                  
                                                      </tr>
                                                      <tr>
                                                          <td style="width:145px" class="column_RightBold">Serial No. :</td>
                                                          <td style="width:145px" class="column_Left">
                                                              <asp:TextBox ID="txtIntanSerialNo" CssClass="txtbox_Var" runat="server" Enabled="False"></asp:TextBox>
                                                          </td>
                                                          <td style="width:145px" class="column_RightBold">License Duration :</td>
                                                          <td style="width:145px"> 
                                                              <asp:TextBox ID="txtIntanLicenceDuration" CssClass="txtbox_Var" runat="server" Enabled="False"></asp:TextBox></td>
                                                          <td style="width:145px"></td>
                                                          <%--<td style="width:145px" colspan="2"></td>--%>
                                 
                                                      </tr>
                                                      <tr>
                                                          <td></td>
                                                          <td></td>
                                                          <td></td>
                                                          <td class="column_Left">
                                                          </td>
                                                          <td></td>
                                                          <%--<td colspan="2"></td>--%>
                          
                                                      </tr>
                                                        <tr>
                                                          <td colspan="5">
                                                               <fieldset>
                                                                   <legend class="column_LeftBold">Acquisition :</legend>
                                                                    <table>
                                                                        <tr>
                                                                            <td class="column_RightBold" style="width:115px">Acquisition Date :</td>
                                                                            <td class="column_Left" style="width:250px"><asp:TextBox ID="txtIntanAcquisitionDate" runat="server" CssClass="txtbox_Var" onchange="return NoOfYearsIntangible(this.value);" Enabled="False"></asp:TextBox>
                                                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtIntanAcquisitionDate" PopupButtonID="txtIntanAcquisitionDate"></cc1:CalendarExtender>
                                                                                &nbsp;MM/DD/YYYY</td>
                                                                            <td class="column_RightBold" style="width:150px">Market Value :</td>
                                                                            <td class="column_Left" style="width:100px"><asp:TextBox ID="txtIntanMarketValue" runat="server" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);" Enabled="False"></asp:TextBox></td>
                                                                        </tr>
                                                                          <tr>
                                                                            <td class="column_RightBold" style="width:115px">Acquisition Cost :</td>
                                                                            <td class="column_Left" style="width:250px"><asp:TextBox ID="txtIntanAcquisitionCost" runat="server" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalValIntangible(this),getDepValIntangible(this);" Enabled="False"></asp:TextBox></td>
                                                                            <td class="column_RightBold" style="width:150px">No. of Years :</td>
                                                                            <td class="column_Left" style="width:100px"><asp:TextBox ID="txtIntanNoofYears" runat="server" CssClass="txtbox_Var" Width="75px" Enabled="False"></asp:TextBox></td>
                                                                         </tr>
                                                                        <tr>
                                                                            <td class="column_RightBold" style="width:115px">Depreciated Rate :</td>
                                                                            <td class="column_Left" style="width:250px"><asp:TextBox ID="txtIntanDepreciatedRate" runat="server" CssClass="txtbox_Var" Width="75" Enabled="False"></asp:TextBox> &nbsp;(%)Percent</td>
                                                                            <td class="column_RightBold" style="width:150px">Useful Life :</td>
                                                                            <td class="column_Left" style="width:100px"><asp:TextBox ID="txtIntanUsefullife" runat="server" CssClass="txtbox_Var" Width="75px" onchange="return getDepValIntangible(this);" Enabled="False"></asp:TextBox></td>
                                                                         </tr>
                                                                        <tr>
                                                                            <td class="column_RightBold" style="width:115px">Depreciated Value :</td>
                                                                            <td class="column_Left" style="width:250px"><asp:TextBox ID="txtIntanDepreciatedValue" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox></td>
                                                                            <td class="column_RightBold" style="width:150px">Salvage Value :</td>
                                                                            <td class="column_Left" style="width:100px"><asp:TextBox ID="txtIntanSalvageValue" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox></td>
                                                                         </tr>
                                                                       
                                                                     <tr>
                                                                               <td class="column_RightBold" style="width:115px">Depreciation Value :</td>
                                                                               <td class="column_Left" style="width:250px"><asp:TextBox ID="txtIntanDepreciationValue" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox></td>
                                                                               <td></td>
                                                                               <td></td>
                                                                     </tr>
                                               
                                                                    </table>
                                                               </fieldset>
                                                          </td>
                                                         <%-- <td colspan="2">
                                 
                                                 
                                      
                                                          </td>--%>
                               
                                                      </tr>
                                                   
                                                      <tr>
                                                          <td colspan="5">
                                                                <fieldset>
                                                                   <legend class="column_LeftBold">Warehouse :</legend>
                                                                    <table>
                                                                        <tr>
                                                                            <td class="column_RightBold" style="width:75px">Warehouse :</td>
                                                                            <td class="column_Left"><asp:DropDownList ID="drpIntanWarehouse" runat="server" Width="150px" Enabled="False"></asp:DropDownList></td>
                                                                            <td class="column_RightBold" style="width:75px">Bay :</td>
                                                                            <td class="column_Left"><asp:TextBox ID="txtIntanBay" runat="server" CssClass="txtbox_Var" Width="85px" Enabled="False"></asp:TextBox></td>
                                                                            <td class="column_RightBold" style="width:75px">Column :</td>
                                                                            <td class="column_Left"><asp:TextBox ID="txtIntanColumn" runat="server" CssClass="txtbox_Var" Width="85px" Enabled="False"></asp:TextBox></td>
                                                                            <td class="column_RightBold" style="width:75px">Floor :</td>
                                                                            <td class="column_Left"><asp:TextBox ID="txtIntanFloor" runat="server" CssClass="txtbox_Var" Width="85px" Enabled="False"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="column_RightBold" style="width:75px">Room :</td>
                                                                            <td class="column_Left"><asp:TextBox ID="txtIntanRoom" runat="server" CssClass="txtbox_Var" Width="85px" Enabled="False"></asp:TextBox></td>
                                                                            <td class="column_RightBold" style="width:75px">Shelves :</td>
                                                                            <td class="column_Left"><asp:TextBox ID="txtIntanShelves" runat="server" CssClass="txtbox_Var" Width="85px" Enabled="False"></asp:TextBox></td>
                                                                            <td class="column_RightBold" style="width:75px">Rack :</td>
                                                                            <td class="column_Left"><asp:TextBox ID="txtIntanRack" runat="server" CssClass="txtbox_Var" Width="85px" Enabled="False"></asp:TextBox></td>
                                                                            <td class="column_RightBold" style="width:75px">Bin :</td>
                                                                            <td class="column_Left"><asp:TextBox ID="txtIntanBin" runat="server" CssClass="txtbox_Var" Width="85px" Enabled="False"></asp:TextBox></td>
                                                                        </tr>
                                                                    </table>
                                                                </fieldset>
                                                          </td>
                                                          <td style="vertical-align:text-top">
                                                              <asp:Button ID="btnEdit_Intangible" runat="server" OnClientClick="StartProgressBar();" CssClass="CSButton" Text="Edit" Width="95%"  />
                                                          </td>
                                                          <td  style="vertical-align:text-top">
                                                              <asp:Button ID="btnCancel0" runat="server" OnClientClick="StartProgressBar();" CssClass="CSButton" Text="CANCEL" Width="95%" />
                                                          </td>
                                                      </tr>
                                                  </table>
                                                  </td>
                                              </tr>
                                                </tbody>
                                          </table>
                                    </div>
                                </asp:View>
                            </asp:MultiView>



                            <asp:MultiView ID="mvledger" runat="server">
                                <asp:View ID="vwledger" runat="server">
                                    <table style="width: 1000px">
                                        <tbody>
                                            <tr style="display: none;">
                                                <td style="width: 640px">
                                                    <asp:Label ID="lblHistoryDetails" runat="server" Width="100%" Font-Bold="True" ForeColor="Blue" Font-Size="11pt" Font-Names="Calibri" CssClass="panel" Text="HISTORY DETAILS" BorderStyle="Solid" BorderWidth="1px" BorderColor="Blue"></asp:Label>

                                                </td>
                                                <td style="width: 120px">
                                                    <asp:Label ID="Label2" runat="server" Width="100%" Font-Bold="True" ForeColor="Blue" Font-Size="11pt" Font-Names="Calibri" CssClass="panel" Text="DEBIT" BorderStyle="Solid" BorderWidth="1px" BorderColor="Blue"></asp:Label>

                                                </td>
                                                <td style="width: 120px">
                                                    <asp:Label ID="Label3" runat="server" Width="100%" Font-Bold="True" ForeColor="Blue" Font-Size="11pt" Font-Names="Calibri" CssClass="panel" Text="CREDIT" BorderStyle="Solid" BorderWidth="1px" BorderColor="Blue"></asp:Label>

                                                </td>
                                                <td style="width: 120px">
                                                    <asp:Label ID="Label4" runat="server" Width="100%" Font-Bold="True" ForeColor="Red" Font-Size="11pt" Font-Names="Calibri" CssClass="panel" Text="BALANCE" BorderStyle="Solid" BorderWidth="1px" BorderColor="Blue"></asp:Label>

                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="width: 1000px" colspan="4">
                                                    <asp:Panel ID="Panel1" runat="server" Width="1000px" CssClass="PanelSize" ScrollBars="Vertical">

                                                        <asp:GridView ID="grdLedger" runat="server" Width="980px" SkinID="GridViewAA" Font-Size="8pt" OnDataBound="OnDataBound">
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
                                            <tr>
                                                <td style="width: 1000px" colspan="4">

                                                    <asp:Button ID="btnPreview" OnClick="btnPreview_Click" runat="server" Width="200px" Text="PREVIEW" CssClass="CSButton"></asp:Button>
                                                    <asp:HiddenField ID="HdfLedgerReport" runat="server" />
                                                </td>

                                            </tr>

                                        </tbody>

                                    </table>

                                </asp:View>
                                <asp:View ID="vwrepairsandmaintenance" runat="server">
                                    <asp:GridView ID="grdrepairsandmaintenance" runat="server" Width="950px" DataKeyNames="Property_Dtl_ID,RepairMaintenanceId" OnSelectedIndexChanged="grdrepairsandmaintenance_SelectedIndexChanged" SkinID="GridViewAA" HorizontalAlign="Center" Font-Size="9pt">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="linkPreview" runat="server" CausesValidation="False" Font-Size="10pt" Font-Names="Arial" Text="View Items" CommandName="Select" Font-Underline="False"></asp:LinkButton>
                                                </ItemTemplate>

                                                <ItemStyle Width="100px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ServiceProvider" HeaderText="Service Provider">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NatureRepair" HeaderText="Nature of Repairs">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No.">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Total" DataFormatString="{0:N}" HeaderText="Amount">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:View>
                                <asp:View ID="vwdocumentattachment" runat="server">
                                    <table style="height: 236px" width="1000">
                                        <tbody>
                                            <tr>
                                                <td style="vertical-align: top; width: 800px; height: 236px" align="center">
                                                    <fieldset style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; width: 700px; padding-top: 5px; height: 223px" class="PanelBorder">
                                                        <legend><span style="font-size: 11pt; font-family: Calibri"><strong>DOCUMENT DETAILS</strong></span></legend>
                                                        <center></center>
                                                        <center>
                                                            <asp:GridView ID="grdpropertydocdetails" runat="server" Width="650px" SkinID="gvnew" DataKeyNames="DocuId" OnRowDataBound="grdpropertydocdetails_RowDataBound" OnSelectedIndexChanged="grdpropertydocdetails_SelectedIndexChanged1" PageSize="5" Font-Size="9pt">
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
                                                    <fieldset style="width: 255px; height: 232px" class="PanelBorder"><legend><span style="font-size: 11pt; font-family: Calibri"><strong>ATTACHED DOCUMENTS</strong></span></legend>
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
                </tbody>
            </table>

            <asp:Panel Style="display: none" ID="PanelRepair" runat="server" Width="900px">
                <table id="Table35" height="486" cellspacing="0" cellpadding="0" width="747" border="0">
                    <tbody>
                        <tr>
                            <td colspan="2">
                                <img height="1" alt="" src="../images/modalpopup_01.png" width="747" /></td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../images/modalpopup_02.png); width: 772px; height: 39px"></td>
                            <td style="width: 34px; height: 39px">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/modalpopup_03.png"></asp:ImageButton></td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../images/modalpopup_04.png); vertical-align: top; width: 772px" id="Td7"><span style="color: black">
                                <div style="text-align: center">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 5%" align="center"></td>
                                                <td style="width: 95%" align="center"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 5%" align="center"></td>
                                                <td style="width: 95%" align="center">
                                                    <table style="width: 100%" id="Table10" class="strip">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 1000px; height: 5px; text-align: left"><strong>Repair and Maintenance Items :</strong></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 5%" align="center"></td>
                                                <td style="width: 95%" align="center">
                                                    <table style="width: 100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 23%" class="column_LeftBold">Property Description</td>
                                                                <td style="width: 2%" class="column_LeftBold">:</td>
                                                                <td style="width: 25%" class="text5">
                                                                    <asp:Label ID="lblPropertyDesc" runat="server" Width="100%"></asp:Label></td>
                                                                <td style="width: 23%" class="column_LeftBold">Property Number</td>
                                                                <td style="width: 2%" class="column_LeftBold">:</td>
                                                                <td style="width: 25%" class="text5">
                                                                    <asp:Label ID="lblPropertyNo" runat="server" Width="100%"></asp:Label></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 5%" align="center"></td>
                                                <td style="width: 95%" align="center">
                                                    <asp:GridView ID="grdRepair" runat="server" Width="100%" PageSize="5" SkinID="gvnew" AllowPaging="True" OnPageIndexChanging="grdRepair_PageIndexChanging" Font-Size="9pt">
                                                        <Columns>
                                                            <asp:BoundField DataField="RepairItems" HeaderText="Item Description">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Qty" HeaderText="Quantity">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="price" HeaderText="Cost">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 5%" align="center"></td>
                                                <td style="width: 95%" align="center">
                                                    <asp:Button ID="btnOK" OnClick="btnOK_Click" runat="server" Width="166px" Text="OK"></asp:Button>
                                                    <asp:Button ID="btnRPreview" runat="server" Width="166px" Text="Preview" Visible="False"></asp:Button></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </span>
                                <asp:Label ID="lblRepair" runat="server" Width="71px"></asp:Label></td>
                            <td style="background-image: url(../images/modalpopup_05.png); width: 34px; height: 446px"></td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lblRepair" PopupControlID="PanelRepair"></cc1:ModalPopupExtender>
            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
       
            
        

        <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label3" PopupControlID="popupParticular" CancelControlID="ImageButton2" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
        <asp:Panel ID="popupParticular" runat="server" Width="350px" CssClass="Panel_Popup">
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
                                <asp:Button ID="btnProceedEdit" OnClick="btnProceedEdit_Click" runat="server" Width="150px" CssClass="CSButton" Text="PROCEED"></asp:Button>
                    
                        <asp:Button ID="btnAuthCancel" OnClick="btnAuthCancel_Click" runat="server" Width="150px" CssClass="CSButton" Text="CANCEL"></asp:Button>
                    </td>
                      </tr>
                  </table>
                  
                  </asp:Panel>
        
        
        </ContentTemplate>
    </asp:UpdatePanel>
    

</asp:Content>



                 