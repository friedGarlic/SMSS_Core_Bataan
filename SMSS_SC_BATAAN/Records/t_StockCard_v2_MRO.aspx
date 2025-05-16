<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="t_StockCard_v2_MRO.aspx.vb" Inherits="Records_t_StockCard_v2_MRO" StylesheetTheme="SkinFile" Title="Encoding of MRO"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    <script type="text/javascript" src="../Membership/MasterPage/js/autoCurrency.js"></script>

<script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
<script type="text/javascript">

     window.onbeforeunload = function (e) {
         var e = e || window.event;
      // For IE and FireFox
         var value="Maybe some changes needed to be saved!"
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
    function getDepValRate() {
    var noYears = document.getElementById('ctl00_ContentPlaceHolder1_txtNoYears');
    var usefulLife = document.getElementById('ctl00_ContentPlaceHolder1_txtUsefulLife');
    var acquisationCost = document.getElementById("ctl00_ContentPlaceHolder1_txtEAcqCost");
    var salvageValue = document.getElementById('ctl00_ContentPlaceHolder1_txtSalvageValue');
    var depreciationValue = document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciationValue");
    var equipmentDepreciatedValue = document.getElementById("ctl00_ContentPlaceHolder1_txtequipmentdepreciatedvalue");
    var equipmentDepreciatedRate = document.getElementById("ctl00_ContentPlaceHolder1_lblequipmentdepreciatedRate");

    var year = parseFloat(noYears.value);
    var UL = parseFloat(usefulLife.value);
    var AcquisationCostVal = parseFloat(acquisationCost.value.replace(/\,/g, ''));
    var Salvagevalue = parseFloat(salvageValue.value.replace(/\,/g, ''));

    var depval = (year / UL) * 100;
    if (depval > 100) {
        depval = 100;
    }
    equipmentDepreciatedRate.value = depval.toFixed(2);

    var DepreciatedValue = (AcquisationCostVal - Salvagevalue) * (1 - depval / 100) ** year;
    depreciationValue.value = (DepreciatedValue / UL).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

    equipmentDepreciatedValue.value = DepreciatedValue.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
}

    function getSalVal(Double) {
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtEAcqCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var SalvageVal = AcquisationCostVal * 0.05

        document.getElementById("ctl00_ContentPlaceHolder1_txtSalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }
    function correctQty(Integer) {
        //var ROP =  parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtequipmentReOrderPt').value);
        //var Qty = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtEquipmentQuantity').value);
        //if (Qty < ROP) {
        //    document.getElementById('ctl00_ContentPlaceHolder1_txtEquipmentQuantity').value = ""
        //   alert("Warning : Quantity should be higher that ROP")
        //}
    }
    function correctQty1() {
        //var ROP =  parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtReOrderPt').value);
        //var Qty = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtQuantity').value);
        //if (Qty < ROP)
        //{
        //    document.getElementById('ctl00_ContentPlaceHolder1_txtQuantity').value = ""
        //    alert("Warning : Quantity should be higher that ROP")
        //}
    }

    function correctQty2() {
     
        //var ROP = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtConsOthersReOrderPt').value);
        //var Qty = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtConsOthersQuantity').value);
       
        //if (Qty < ROP) {
        //    document.getElementById('ctl00_ContentPlaceHolder1_txtConsOthersQuantity').value = ""
        //  alert("Warning : Quantity should be higher that ROP")
        //}
       
      
    }
   
 </script>
   
    <asp:ScriptManager ID="ScriptManagerStock" runat="server">
    </asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server" autocomplete="off">

          <ContentTemplate>
             
              <div>
                  <table width="100%">
                      <tr >
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle"><%--STOCK CARD--%><strong><asp:Label ID="lblClass" runat="server" Text="Label"></asp:Label></strong>
                        </td>
                        <td style="width: 1%"></td>
                      </tr>
                        <tr style="display:none;">
                        <td style="width: 1%"></td>
                        <td style="width: 98%; text-align:right;"class="column_RightBold" ><%--STOCK CARD--%>Date : 
                            <asp:TextBox ID="txtDate" runat="server" Width="100px"  CssClass="txtbox_Date" ></asp:TextBox>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                       <tr  style="display:none;">
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center" >
                            <table>
                                <tr>
                                    <td  class="column_RightBold" style="width: 25%" >
                                        <span class="column_RightBold" >Classification :</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddClass" runat="server" Width="200px" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddClass_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td class="column_RightBold" style ="width:100%;">
                                        General Account :
                                    </td>
                                    <td colspan =" 5">
                                        <asp:DropDownList ID="ddGlAccount" runat="server" Width="525px" AutoPostBack="True" CssClass="drpdownCSS" enabled ="false" OnSelectedIndexChanged="ddGlAccount_SelectedIndexChanged" ></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">
                                        <span class="column_RightBold">Category :</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddCategory" runat="server"  AutoPostBack="True"  Width="200px" CssClass="drpdownCSS" OnSelectedIndexChanged="ddCategory_SelectedIndexChanged" ></asp:DropDownList> 
                                    </td>
                                    <td class="column_RightBold" style ="width:100%;">
                                        <span class="column_RightBold">Sub Category :</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddSubCategory" runat="server" AutoPostBack="True"  Width="200px" CssClass="drpdownCSS" Enabled =" false" OnSelectedIndexChanged="ddSubCategory_SelectedIndexChanged" ></asp:DropDownList>
                                    </td>
                                    <td class="column_RightBold">
                                         <span >Description &nbsp; :</span>
                                    </td>
                                    <td >
                                    <asp:TextBox ID="txtSearchStock" runat="server"  Width="100%" CssClass="txtbox_Var"> </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearchStock"  runat="server" Width="100%" CssClass="CSButton" Text="Search" OnClick="btnSearchStock_Click"></asp:Button>
                        
                                    </td>
                                </tr>
                            </table>
                           
                            &nbsp;&nbsp;
                              &nbsp;
                           
                            &nbsp;
                            &nbsp;</td>
                        <td style="width: 1%"></td>
                    </tr>
                       <tr  style="display:none;">
                         <td style="width: 98%" class="DivTitle" colspan =" 2">LIST OF <asp:Label ID="lblClass1" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                         <tr  style="display:none;">
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdStockList" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="Item_ID,GA_ID"
                                AllowPaging="True" OnPageIndexChanging="grdStockList_PageIndexChanging"  OnRowDataBound="grdStockList_RowDataBound" OnSelectedIndexChanged="grdStockList_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="Item_ID" HeaderText="Item No.">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="unit" HeaderText="UNIT">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Item_Desc" HeaderText="ITEM DESCRIPTION">
                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Balance" HeaderText="CURRENT BALANCE">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="reorderPT" HeaderText="REORDER PT">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Qty" HeaderText="QTY" Visible="False"></asp:BoundField>
                                    <asp:BoundField HeaderText="NO OF ORDERS/YEAR" Visible="False"></asp:BoundField>
                                    <asp:BoundField HeaderText="MIN QTY/ORDER" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="Location" HeaderText="LOCATION">
                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Item_ID" HeaderText="Item_ID" Visible="False"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr >
                        <tr  style="display:none;">
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle"><%--Batch--%> INCOMING DELIVERIES
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                      <tr  style="display:none;">
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdsupplies" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="POHdr_ID,StockID,GA_ID,Received_ID"
                                AllowPaging="True" PageSize="5">
                                <Columns>
                                    <asp:BoundField DataField="PO_No" HeaderText="PO NUMBER">
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="batch" HeaderText="BATCH" Visible ="FALSE">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="lot" HeaderText="LOT" Visible ="FALSE">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Unit" HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="qty" HeaderText="QUANTITY">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="qtybox" HeaderText="QTY/BOX" Visible="False">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalPcs" HeaderText="TOTAL NO. OF PCS">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ActualPrice" DataFormatString="{0:N}" HeaderText="ACTUAL PRICE">
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="deliverydate" HeaderText="DELIVERY DATE">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EpiryDate" HeaderText="SUPPLIER">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                      <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">INVENTORY CARD
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                        <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                     <table width="100%">
                                        <tr>
                                            <td style="width: 70%" align="center">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Name:</td>
                                                        <td style="width: 35%" class="column_Left">
                                                             <asp:DropDownList ID="drpConsOthersName" AutoPostBack ="true" runat="server" Width="98%" OnSelectedIndexChanged="drpConsOthersName_SelectedIndexChanged"></asp:DropDownList>
                                                          
                                                            <asp:TextBox ID="txtConsOthersName" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible="false"></asp:TextBox>
                                                        </td>
                                                         <td style="width: 15%; " class="column_RightBold" >Unit :</td>
                                                        <td style="width: 35%;" class="column_Left">
                                                            <asp:DropDownList ID="drpConsOthersUnit" runat="server" Width="40%" ></asp:DropDownList>
                                                        </td>
                                                       
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Brand Name :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersBrandName" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td> 
                                                        <td colspan ="2" rowspan ="5" style ="padding-left:50px;">
                                                            <fieldset>
                                                                        <legend  class="column_Left" style =" font-family:Arial; color:#404040;"><strong>Mftg Info:</strong></legend>
                                                         
                                                                <table>
                                                                <tr>
                                                                     <td style="width: 15%" class="column_RightBold">Batch :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersBatch1" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                         <td style="width: 15%" class="column_RightBold">Lot :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersLot" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                                </tr>
                                                                <tr>

                                                         <td style="width: 15%" class="column_RightBold">Mftg. Date :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtMDateConsOthers" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                     <td style="width: 15%" class="column_RightBold">Expiry Date :</td>
                                                            <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtEDateConsOthers" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                                </tr>
                                                                <tr>
                                                <td style="width: 15%;color:red;" class="column_RightBold">Alert :</td>
                                                        <td style="width: 35%;" class="column_Left">
                                                            <asp:TextBox ID="txtAlertConsOthers" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                                </tr>
                                                            </table>
                                                            </fieldset>
                                                           
                                                        </td>
                                                            
                                                     
                                                    </tr>
                                                    <tr style="display:none;">
                                                        <td style="width: 15%; height: 25px;" class="column_RightBold">Dose :</td>
                                                        <td style="width: 35%; height: 25px;" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersDose" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        
                                                        <td style="width: 15%; height: 25px;" class="column_RightBold">Batch :</td>
                                                        <td style="width: 35%; height: 25px;" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersBatch" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                       <%-- <td style="width: 15%" class="column_RightBold">Supplier :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Supplier" CssClass="LinkBtnSelect"></asp:LinkButton>
                                                        </td>--%>
                                                           <td style="width: 15%" class="column_RightBold">Form :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersForm" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                       
                                                      
                                                       
                                                    </tr>
                                                    <tr>
                                                       
                                                        
                                                        
                                                          <td style="width: 15%" class="column_RightBold">Unit Cost:</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersUnitPrice" runat="server" Width="40%" CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                     
                                                    </tr>
                                                    <tr>
                                                         <td style="width: 15%; height: 24px;" class="column_RightBold">Reorder Pt. :</td>
                                                        <td style="width: 35%; height: 24px;" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersReOrderPt" runat="server" CssClass="txtbox_Amt" ReadOnly="True" Width="40%"></asp:TextBox>
                                                            <asp:Button ID="ROP2" runat="server" cssClass="CSButton" OnClick="btnROP_Click" Text="R.O.P" Width="40" />
                                                        </td>
                                                          <td style="width: 15%;display:none; height: 24px;" class="column_RightBold">Dep. Rate :</td>
                                                        <td style="width: 35%;display:none; height: 24px;" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersDepRate" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                       <td style="width: 15%" class="column_RightBold">Quantity :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                             <asp:TextBox ID="txtConsOthersQuantity" runat="server" CssClass="txtboxinspection" ReadOnly="True" Width="50%" onchange="return correctQty2(this.value);"></asp:TextBox>
                                                           
                                                        
                                                        
                                                           </td>
                                                         <td style="width: 15%;display:none;" class="column_RightBold">Dep. Value :</td>
                                                        <td style="width: 35%;display:none;" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersDepValue" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        
                                                      
                                                    </tr>
                                                    <tr>
                                                       <td class="column_RightBold">Date :</td>
                                                        <td class="column_Left"><asp:TextBox ID="txtSellectDateCons" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                                        <cc1:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txtSellectDateCons" Enabled="True" PopupButtonID="txtSellectDateCons"></cc1:CalendarExtender>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                     <tr>
                                                        <td colspan="4">
                                                             <fieldset>
                                                                 <legend  class="column_Left" style =" font-family:Arial; color:#404040;"><strong>Location:</strong></legend>
                                                                 <table width="100%">
                                                                     <tr>
                                                                         <td class="column_RightBold">Warehouse :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:DropDownList ID="drpMROConsOthersWarehouse" runat="server" Width="175px" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Bay :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtConsOthersBay" runat="server"  Width="50px" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList2" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" >Column :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                 <asp:TextBox ID="txtConsOthersColumn" runat="server" Width="50px" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList3" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" >Floor :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                <asp:TextBox ID="txtConsOthersFloor" runat="server" Width="50px" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList4" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                     </tr>
                                                                     <tr>
                                                                         <td class="column_RightBold">Room :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtConsOthersRoom" runat="server" Width="50px" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList5" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" >Shelves :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtConsOthersShelves" runat="server" Width="50px" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList6" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Rack :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtConsOthersRack" runat="server" Width="50px" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList7" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                         
                                                                         <td class="column_RightBold">Bin :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtConsOthersBin" runat="server" Width="50px" CssClass="txtbox_Var" AutoCompleteType="Disabled" ></asp:TextBox>
                                                                             <asp:DropDownList ID="DropDownList8" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         <table style="position:absolute; top:-999px; width:0px;">
                                                                           <tr>
                                                                               <td>
                                                                                   <asp:TextBox ID="TextBox3" runat="server" Width="0px" Readonly="true"></asp:TextBox>
                                                                        
                                                                               </td>
                                                                           </tr>
                                                                       </table>
                                                                             </td>
                                                                     </tr>
                                                                    
                                                                 </table>
                                                             </fieldset>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 30%" align="center">
                                                <img alt="" height="160" src="../images/Default_Image.jpg" width="80%" />
                                                  <asp:Button ID="btnConsOthersUpload"  runat="server" Width="120px" CssClass="CSButton" Text="Upload" OnClientClick="StartProgressBar();"></asp:Button>
                                              
                                            </td>
                                        </tr>
                                          <tr>
                                                                        <td colspan ="2" style="text-align:right;">
                                                                              <asp:Button ID="btnConsOthersSave" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();" OnClick="btnConsOthersSave_Click"></asp:Button>
                                                                           &nbsp; &nbsp; &nbsp;
                                                                             <asp:Button ID="btnConsOthersCancel"  runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();" OnClick="btnConsOthersCancel_Click"></asp:Button>
                                          
                                                                        </td>
                                                                    </tr>
                                        <tr>
                                            <td style="width: 70%" align="center">
                                               <%-- <asp:Button ID="btnEdit2" OnClick="btnEdit2_Click" runat="server" Width="120px" CssClass="CSButton" Text="EDIT" OnClientClick="StartProgressBar();"></asp:Button>
                                                &nbsp;<asp:Button ID="btnUpdateDetails2" OnClick="btnUpdateDetails2_Click" runat="server" Width="120px" CssClass="CSButton" Text="UPDATE" OnClientClick="StartProgressBar();"></asp:Button>
                                                &nbsp;<asp:Button ID="btnCancel2" OnClick="btnCancel2_Click" runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();"></asp:Button>--%>
                                            </td>
                                            <td style="width: 30%"></td>
                                        </tr>
                                    </table>
                                    
                                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtMDateConsOthers" Enabled="True" PopupButtonID="txtMDateConsOthers"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtEDateConsOthers" Enabled="True" PopupButtonID="txtEDateConsOthers"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtAlertConsOthers" Enabled="True" PopupButtonID="txtAlertConsOthers"></cc1:CalendarExtender>
                                    <asp:Label ID="Label1" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="Label5" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="Label6" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label>

                                </asp:View>
                                   <asp:View ID="View2" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 70%" align="center">
                                                <table width="100%">
                                                    <tr>
                                                       <td style="width: 15%" class="column_RightBold">Name :</td>
                                                        <td style="width: 35%" class="column_Left"><asp:HiddenField ID="hdnItemNo" runat="server" /><asp:HiddenField ID="hdnGAId" runat="server" />
                                                              <asp:DropDownList ID="drpItemDesc2" AutoPostBack ="true" runat="server" Width="98%" OnSelectedIndexChanged="drpItemDesc2_SelectedIndexChanged"></asp:DropDownList>
                                                          
                                                            <asp:TextBox ID="txtItemDesc2" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                       <td style="width: 15%; " class="column_RightBold" >Unit :</td>
                                                        <td style="width: 35%;" class="column_Left">
                                                            <asp:DropDownList ID="drpUnit" runat="server" Width="40%" ></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Brand Name :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtBrandName2" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                         <td style="width: 15%" class="column_RightBold">Length :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtLenght" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style ="display:none;">
                                                        <td style="width: 15%" class="column_RightBold">Supplier :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:LinkButton ID="lnksuppliermed" runat="server" Text="Supplier" CssClass="LinkBtnSelect"></asp:LinkButton>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Height:</td>
                                                        <td style="width: 35%" class="column_Left">
                                                           </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Size :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtSize" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        
                                                        <td style="width: 15%" class="column_RightBold">Width  :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtWidth" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        
                                                        <td style="width: 15%" class="column_RightBold">Color :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtColor" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                       
                                                        <td style="width: 15%" class="column_RightBold">Weight:</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtWeight" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>

                                                    </tr>
                                                     <tr>
                                                        <td style="width: 15%" class="column_RightBold">Component of :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtComponentof" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                          <td style="width: 15%" class="column_RightBold">Height :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                           <asp:TextBox ID="txtHeight" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                          <asp:TextBox ID="TextBox2" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false" ></asp:TextBox>
                                                        </td>
                                                      
                                                    </tr>
                                                    <tr>
                                                          <td style="width: 15%" class="column_RightBold">Unit Cost:</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtUnitPrice" runat="server" Width="140px" CssClass="txtbox_Amt" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                        </td>
                                                         <td style="width: 15%" class="column_RightBold">Quantity :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                             <asp:TextBox ID="txtQuantity" runat="server" CssClass="txtboxinspection" Width="50%" onchange="return correctQty1(this.value);"></asp:TextBox>
                                                        
                                                           </td>
                                                        <td style="width: 15%;display:none" class="column_RightBold" >Dep. Rate :</td>
                                                        <td style="width: 35% ;display:none" class="column_Left">
                                                            <asp:TextBox ID="txtDepRate" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                       <td style="width: 15% ;display:none" class="column_RightBold">Dep. Value :</td>
                                                        <td style="width: 35%;display:none" class="column_Left">
                                                            <asp:TextBox ID="txtDepValue" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr> 
                                                        <td style="width: 15%" class="column_RightBold">Reorder Pt. :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtReOrderPt" runat="server" CssClass="txtbox_Amt" ReadOnly="True" Width="40%"></asp:TextBox>
                                                            <asp:Button ID="btnROP" runat="server" cssClass="CSButton" OnClick="btnROP_Click" Text="R.O.P" Width="40" />
                                                           
                                                        </td>
                                                        
                                                        <td style ="display:none;" <%--style="width: 15%" class="column_RightBold"--%>>Expiry Date :</td>
                                                        <td style ="display:none;"<%-- style="width: 35%" class="column_Left"--%>>
                                                            <asp:TextBox ID="txtEDate" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                    </tr>
                                                    <tr >
                                                        <td style="width: 15%" class="column_RightBold">Date :</td>
                                                        <td style="width: 35%" class="column_Left"><asp:TextBox ID="txtSellectDate" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                                        <cc1:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtSellectDate" PopupButtonID="txtSellectDate"></cc1:CalendarExtender>
                                                        <td style="width: 15%; display:none;" class="column_RightBold" >Alert :</td>
                                                        <td style="width: 35%; display:none;" class="column_Left">
                                                            <asp:TextBox ID="txtAlert" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td colspan="4">
                                                             <fieldset>
                                                                 <legend  class="column_Left" style =" font-family:Arial; color:#404040;"><strong>Location:</strong></legend>
                                                                 <table width="100%">
                                                                     <tr>
                                                                         <td class="column_RightBold">Warehouse :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:DropDownList ID="drpWarehouse" runat="server" Width="175px" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Bay :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtBay" runat="server"  Width="50px" CssClass="txtbox_Var" Readonly="true" onchange="locationclr(this.value)" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="drpBay" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" >Column :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                 <asp:TextBox ID="txtColumn" runat="server"  Width="50px" CssClass="txtbox_Var" Readonly="true"></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="drpColumn" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" >Floor :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                <asp:TextBox ID="txtFloor" runat="server"  Width="50px" CssClass="txtbox_Var" Readonly="true"></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="drpFloor" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                     </tr>
                                                                     <tr>
                                                                         <td class="column_RightBold">Room :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtRoom" runat="server"  Width="50px" CssClass="txtbox_Var" Readonly="true"></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="drpRoom" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" >Shelves :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtShelves" runat="server"   Width="50px" CssClass="txtbox_Var" Readonly="true"></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="drpShelves" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Rack :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtRack" runat="server"  Width="50px" CssClass="txtbox_Var" Readonly="true"></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="drpRack" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                         
                                                                         <td class="column_RightBold">Bin :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtBin" runat="server"  Width="50px" CssClass="txtbox_Var" Readonly="true"></asp:TextBox>
                                                                       <table style="position:absolute; top:-999px; width:0px;">
                                                                           <tr>
                                                                               <td>
                                                                                   <asp:TextBox ID="TextBox1" runat="server" Width="0px" Readonly="true"></asp:TextBox>
                                                                        
                                                                               </td>
                                                                           </tr>
                                                                       </table>
                                                                             
                                                                             <asp:DropDownList ID="drpBin" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                         <td >
                                                                                     </td>
                                                                     </tr>
                                                                    
                                                                 </table>
                                                             </fieldset>
                                                        </td>
                                                    </tr>
                                                    
                                                </table>
                                            </td>
                                            <td style="width: 30%" align="center">
                                                <img alt="" height="160" src="../images/Default_Image.jpg" width="80%" />
                                               <asp:Button ID="btnUploadMROSupplies"  runat="server" Width="120px" CssClass="CSButton" Text="Upload" OnClientClick="StartProgressBar();"></asp:Button>
                                              
                                            </td>
                                        </tr>
                                         <tr>
                                                                        <td colspan ="2" style="text-align:right;">
                                                                              <asp:Button ID="btnSave" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();" OnClick="btnSave_Click"></asp:Button>
                                                                           &nbsp; &nbsp; &nbsp;
                                                                             <asp:Button ID="btnCancel"  runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();" OnClick="btnCancel_Click" ></asp:Button>
                                          
                                                                        </td>
                                                                    </tr>
                                        <tr>
                                            <td style="width: 70%" align="center">
                                                <%--<asp:Button ID="btnEdit2" OnClick="btnEdit2_Click" runat="server" Width="120px" CssClass="CSButton" Text="EDIT" OnClientClick="StartProgressBar();"></asp:Button>--%>
                                                <%--&nbsp;<asp:Button ID="btnUpdateDetails2" OnClick="btnUpdateDetails2_Click" runat="server" Width="120px" CssClass="CSButton" Text="UPDATE" OnClientClick="StartProgressBar();"></asp:Button>--%>
                                                &nbsp;<%--<asp:Button ID="btnCancel2" OnClick="btnCancel2_Click" runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();"></asp:Button>--%></td>
                                            <td style="width: 30%">

                                            </td>
                                        </tr>
                                    </table>

                                    <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtMDate" Enabled="True" PopupButtonID="txtMDate"></cc1:CalendarExtender>--%>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEDate" Enabled="True" PopupButtonID="txtEDate"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtAlert" Enabled="True" PopupButtonID="txtAlert"></cc1:CalendarExtender>
                                    <asp:Label ID="lblmedicinedatetaken" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="lblmedicineUploadedby" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="lblmedicineposition" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label>


                                </asp:View>
                                <asp:View ID="View3" runat="server">
                                     <table style="width: 100%;">
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">Name :
                                    </td>
                                    <td class="column_Left" style="width: 30%">

                                        <asp:Label ID="lblequipmentname" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="drpMROEquipmentName" AutoPostBack ="true" runat="server" Width="91%" OnSelectedIndexChanged ="drpMROEquipmentName_SelectedIndexChanged" ></asp:DropDownList>
                                                          
                                        <asp:TextBox ID="txtMROEquipmentName" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold" style="width: 10%">Unit :
                                    </td>
                                    <td class="column_Left" style="width: 30%">

                                        <asp:Label ID="Label7" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="drpMROEquipmentUnit" AutoPostBack ="true" runat="server" Width="91%" ></asp:DropDownList>
                                                          
                                        <asp:TextBox ID="TextBox4" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                    </td>
                                    <td align="center" rowspan="6" style="width: 20%" valign="middle" >
                                        <asp:Image ID="Image3" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                        <br />
                                               <asp:Button ID="btnupload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD"  ></asp:Button>
                                
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">Description :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentdesciption" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtequipmentdesciption" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                    <td class="column_RightBold" style="width: 10%">Dimension :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentdimension" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtequipmentdimension" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 10%; height: 38px;">Power Input :
                                    </td>
                                    <td class="column_Left" style="width: 30%; height: 38px;">
                                        <asp:Label ID="lblequipmentpowerinput" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtequipmentpowerinput" runat="server" Width="89%"  CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                    <td class="column_RightBold" style="width: 10%; height: 38px;">Area Capacity :
                                    </td>
                                    <td class="column_Left" style="width: 30%; height: 38px;">
                                        <asp:Label ID="lblequipmentareacapacity" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtequipmentareacapacity" runat="server" Width="89%"  CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                     <td class="column_RightBold" style="width: 10%">Model :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentmodel" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtequipmentmodel" runat="server" Width="89%"  CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                    <td class="column_RightBold" style="width: 10%">Warranty :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentwaranty" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtequipmentwaranty" runat="server" Width="89%"  CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                   
                                </tr>
                               <tr>
                                     <td style="width: 10%" class="column_RightBold">Reorder Pt. :</td>
                                                        <td style="width: 30%" class="column_Left">
                                                             <asp:TextBox ID="txtequipmentReOrderPt" runat="server" Width="40%" CssClass="txtbox_Amt" ReadOnly="True" Enabled="false"></asp:TextBox>
                                                                <asp:Button ID="BtnROP3" cssClass="CSButton" runat="server" Text="R.O.P" Width="40" OnClick="btnROP_Click"  />
                                                        
                                                           
                                                        
                                                           </td>
                                     <td style="width: 10%" class="column_RightBold"></td>
                                                        <td style="width: 30%" class="column_Left">
                                                       
                                                           </td>
                               </tr>
                                <tr>
                                    <td colspan ="4">
                                        <fieldset style="width:90%;">
                                            <legend class="column_LeftBold">Acquisition :</legend>
                                        <table >
 <tr>
                                     <td  class="column_RightBold" style="width: 125px">Acquisition Date :
                                    </td>
                                    <td class="column_Left" style="width:100px;">
                                        <asp:Label ID="Label8" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtEAcqDate" runat="server"   CssClass="txtbox_Var" onchange="return NoOfYears(this.value);" Width="140px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEAcqDate" PopupButtonID="txtEAcqDate"></cc1:CalendarExtender>


                                        &nbsp;(MM/DD/YYYY)</td>
                                   <td class="column_RightBold" >Market Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="Label9" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtEMarketValue" runat="server"  CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);" Width="140px"></asp:TextBox>

                                    </td>
                                    
                                    
                                </tr>
                                <tr>
                                    
                                    <td class="column_RightBold" style="width: 125px" >Acquisition Cost :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="Label10" runat="server" ></asp:Label>
                                        <asp:TextBox ID="txtEAcqCost" runat="server"  CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalVal(this),getDepValRate(this);" Width="140px"></asp:TextBox>
                                    </td>
                                    
                                    <td class="column_RightBold" >No. of Years :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="lblNoYears" runat="server" ></asp:Label>
                                        <asp:TextBox ID="txtNoYears" runat="server"  CssClass="txtbox_Var" Width="50px"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                     <td class="column_RightBold" style="width: 125px" >Depreciated Rate :</td>
                                    <td class="column_Left" >
                                        <asp:TextBox ID="lblequipmentdepreciatedRate" runat="server" CssClass="txtboxAmount" MaxLength="5" ReadOnly="True" Width="50px"></asp:TextBox>
                                        &nbsp;(%) Percent</td>
                                    <td class="column_RightBold">Useful Life :
                                    </td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblUsefulLife" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtUsefulLife" runat="server" Width="50px"  CssClass="txtbox_Var" onchange="return getDepValRate(this);" ></asp:TextBox>

                                        &nbsp;(Years)</td>

                                </tr>


                                <tr>
                                    
                                    <td class="column_RightBold" style="width: 125px">&nbsp;Depreciated Value :</td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblequipmentdepreciatedvalue" runat="server" Font-Italic="False" SkinID="Label" Width="290px"></asp:Label>
                                        <asp:TextBox ID="txtequipmentdepreciatedvalue" runat="server" CssClass="txtboxAmount" Width="140px"></asp:TextBox>
                                    </td>

                                    
                                    
                                   <td class="column_RightBold">Salvage Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:TextBox ID="txtSalvageValue" runat="server" Width="140px"   CssClass="txtboxAmount" >0.00</asp:TextBox>

                                         

                                    </td>


                                </tr>
                                <tr>
                                    
                                    <td class="column_RightBold" style="width: 125px" >&nbsp;Depreciation Value :</td>
                                    <td class="column_Left" >
                                        <asp:TextBox ID="txtDepreciationValue" runat="server" CssClass="txtboxAmount" Width="140px"></asp:TextBox>
                                        &nbsp;(Per Year)</td>
                                    <td class="column_RightBold">Quantity: </td>
                                    <td class="column_Left">
                                        <asp:Label ID="Label11" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtEquipmentQuantity" runat="server" CssClass="txtbox_Var" Width="50px" onchange="return correctQty(this.value);"></asp:TextBox>
                                    </td>
                                </tr>

                                            
                                        </table>
                                    
                                    </td>
                                </tr>
                                           <tr>
                                                        <td colspan="4" >
                                                             <fieldset style="width:90%;">
                                                                 <legend  class="column_Left" style =" font-family:Arial; color:#404040;"><strong>Location:</strong></legend>
                                                                 <table width="100%">
                                                                     <tr>
                                                                         <td class="column_RightBold" >Warehouse :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:DropDownList ID="drpEquipmentWarehouse" runat="server" Width="98%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Bay :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtEquipmentBay" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList1" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:15%">Column :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                 <asp:TextBox ID="txtEquipmentColumn" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList9" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Floor :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                <asp:TextBox ID="txtEquipmentFloor" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList10" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                     </tr>
                                                                     <tr>
                                                                         <td class="column_RightBold">Room :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtEquipmentRoom" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList11" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Shelves :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtEquipmentShelves" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList12" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Rack :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtEquipmentRack" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList13" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                         
                                                                         <td class="column_RightBold">Bin :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtEquipmentBin" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             <asp:DropDownList ID="DropDownList14" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         <table style="position:absolute; top:-999px; width:0px;">
                                                                           <tr>
                                                                               <td>
                                                                                   <asp:TextBox ID="TextBox5" runat="server" Width="0px" Readonly="true"></asp:TextBox>
                                                                        
                                                                               </td>
                                                                           </tr>
                                                                       </table>
                                                                         </td>
                                                                     </tr>
                                                                    
                                                                 </table>
                                                             </fieldset>
                                                        </td>
                                                    </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 10%; height: 43px;">Specifications :
                                    </td>
                                    <td class="column_Left" colspan="3" style="height: 43px">
                                        <asp:Label ID="lblSpecification" runat="server" CssClass="text3"></asp:Label>
                                        <asp:TextBox ID="txtSpecification" runat="server" Width="95%" Height="25px" TextMode="MultiLine"  CssClass="txtbox_Var" Rows="2"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                    <td class="column_RightBold" colspan="3"></td>
                                    <td>
                                        <asp:Button ID="btnEquipmentSave" runat="server" Width="48%" CssClass="CSButton" Text="SAVE" Enabled="false" OnClick="btnEquipmentSave_Click" OnClientClick="StartProgressBar();"></asp:Button>
                                        <asp:Button ID="btnEquipmentCancel" runat="server" Width="48%" CssClass="CSButton" Text="CANCEL" Enabled="false"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                                </asp:View>
                            </asp:MultiView>
                            </td>

                        </tr>
                       <tr>
                        <td style="width: 1%"></td>
                        <td style="height: 1%" class="DivTitle">
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                      <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 100%">
                                <tbody>
                                    <tr style="display:none;">
                                        <td style="width: 55%" class="column_CenterBold">
                                            <asp:Label ID="lblHistoryDetails" runat="server" Width="100%" Text="DETAILS" CssClass="borderCSS"></asp:Label></td>
                                        <td style="width: 14%" class="column_CenterBold">
                                            <asp:Label ID="Label2" runat="server" Width="100%" Text="DEBIT"  CssClass="borderCSS"></asp:Label></td>
                                        <td style="width: 14%" class="column_CenterBold">                                             
                                            <asp:Label ID="Label3" runat="server" Width="100%" Text="CREDIT" CssClass="borderCSS"></asp:Label></td>
                                        <td style="width: 16%" class="column_CenterBold">                                             
                                            <asp:Label ID="Label4" runat="server" Width="100%" Text="BALANCE" CssClass="borderCSS"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" colspan="4">
                                            <asp:Panel ID="Panel2" runat="server" Width="100%" CssClass="PanelSize" ScrollBars="Vertical">
                                                <asp:GridView ID="grdLedger" runat="server" Width="100%" SkinID="GridViewAA"  OnRowDataBound="grdLedger_RowDataBound">
                                                    <Columns>

                                                        <asp:TemplateField>

                                                            <EditItemTemplate>
                                                                <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="CheckBox2" runat="server" Font-Bold="true" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" Text="All"></asp:CheckBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="cbInspection" runat="server" AutoPostBack="True" OnCheckedChanged="cbInspection_CheckedChanged"></asp:CheckBox>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="10px"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="2%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Trans_Type" HeaderText="PARTICULARS" >
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Top" Width="46%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ref" HeaderText="Ref. No." Visible ="FALSE">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="2%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="AccountablePerson" HeaderText="Accountable Person" Visible ="FALSE">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Department" HeaderText="Dept / Office" Visible ="FALSE">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="position" HeaderText="Position" Visible="False" >
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="acceptedby" HeaderText="Accepted By" Visible ="FALSE">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                     <%--   <asp:BoundField DataField="inspectedby" HeaderText="UNIT">--%>
                                                            <asp:BoundField DataField="BalanceUnit" HeaderText="UNIT">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="25px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="2%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Cost" HeaderText="UNIT PRICE" SortExpression="BalUnit">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DebitQty" HeaderText="Debit Qty" SortExpression="DebitQty">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText="Debit Cost" SortExpression="DebitCost">
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="9%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CreditQty" HeaderText="Credit Qty" SortExpression="CreditQty">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText="Credit Cost" SortExpression="CreditCost">
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="9%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BalQty" HeaderText="Balance Qty" SortExpression="BalQty">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BalCost" DataFormatString="{0:N}" HeaderText="Balance Cost" SortExpression="BalCost">
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="9%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                  
                                </tbody>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                      <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnPreview" OnClick="btnPreview_Click" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW" Visible="false"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                  </table>
              </div>
              <asp:Panel ID="popupROP" runat="server" Width="350px" CssClass="Panel_Popup">
                  <table width="100%" >
                      <tr>
                         <td style="width: 100%; height: 30px; margin-left: 40px;" colspan="3" class="DivTitle">
                             REORDER POINT COMPUTATION
                              <asp:ImageButton ID="BtnImageClose" ImageUrl="~/images/Edited Image/CloseButton.png" runat="server" border="10px" Height="13px" Width="16px" />
                         </tr>
                      <tr>      
                          <td class="column_RightBold">
                              Demand Per Day :
                            </td>
                          <td class="column_Left">
                             <asp:TextBox ID="DRP" runat ="server" CssClass="txtbox_Var" Width="150px" ></asp:TextBox>
                          </td>
                      </tr>
                       <tr>      
                          <td class="column_RightBold">
                              Lead Time for Delivery:
                            </td>
                          <td class="column_Left">
                             <asp:TextBox ID="LTD" runat ="server" CssClass="txtbox_Var" Width="150px" ></asp:TextBox>

                          </td>
                      </tr>
                      <tr>
                            <td class="column_RightBold"> </td>
                          <td>
                             
                                <asp:Button ID="BtnCompute"  runat="server" Width="133px" CssClass="CSButton" Text="Compute" OnClick="BtnCompute_Click" ></asp:Button>
                          </td>

                      </tr>
                      <tr>      
                          <td class="column_RightBold">
                              Reorder Point :
                            </td>
                          <td class="column_Left">
                             <asp:TextBox ID="RP" runat ="server" CssClass="txtbox_Var"  Width="150px" ReadOnly ="true" ></asp:TextBox>

                          </td>
                          
                      </tr>
                       <tr>
                        
                            <td style="width: 50%; height: 10px">
                                <asp:Label runat="server" ID="lblpopupROP"></asp:Label>
                            </td>
                        </tr>
                  </table>
                  
                  </asp:Panel>    
                         <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lblpopupROP" PopupControlID="popupROP"  CancelControlID="BtnImageClose" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender> 
                <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
                  <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
         <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>

            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label3" PopupControlID="popupParticular" CancelControlID="ImageButton2" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
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


               <asp:Panel ID="popupNOTIF" runat="server"  CssClass="Panel_Popup" Width="300px" >
                  <table width="100%" >
                      <tr>
                         <td  class="rounded-corners" style="width: 100%;  height: 30px; background-color: red"  colspan="3" >
                             NOTIFICATION ALERT <asp:Image ID="Notif" runat="server" ImageUrl="~/images/POPUP/alert-notif.png" Width="20" />
                             
                         </tr>
                  
                      <tr>
                           <td   colspan="3" style="width: 100%; height: 30px; ">
                              You have reached the re-order point of this item. Order now. </td>
                      
                          
                      </tr>
                       <tr>
                           <td class="center">
                               <asp:Button ID="BtnOK" runat="server" CssClass="CSButton" Text="CLOSE" Width="70px" />
                           </td>
                      </tr>
                  
                       <tr>
                        
                            <td style="width: 50%; height: 10px">
                                <asp:Label runat="server" ID="lblNotif"></asp:Label>
                            </td>
                        </tr>
                  </table>
                  
                  </asp:Panel>    
                         <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID="lblNotif" PopupControlID="popupNOTIF"  CancelControlID="BtnImageClose" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>    
          </ContentTemplate>
          </asp:UpdatePanel>
  
   
</asp:Content>

