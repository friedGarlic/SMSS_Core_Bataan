<%@ Page Title="Encoding of Equipment" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Encoding_Equipment.aspx.vb" Inherits="Inventory_Encoding_Equipment"
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" >
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
   
     function getDepValRate(Integer) {
         var year =  document.getElementById('ctl00_ContentPlaceHolder1_txtNoYears').value;
         var UL =  document.getElementById('ctl00_ContentPlaceHolder1_txtUsefulLife').value;

         var depval = ((year / UL) * 100)
          
         if (depval > 100) {
             depval = 100
         }

         document.getElementById("ctl00_ContentPlaceHolder1_txtDepreciatedRate").value = depval;

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
    <script language="javascript" type="text/javascript">
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
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" onkeydown = "return (event.keyCode!=13)">
        <ContentTemplate>
            <div>
                <table width="1020px">
                    <tr>
                        <td colspan="7" class="PageTitle" style="width: 98%">
                            <%--STOCK CARD--%><strong>
                                <asp:Label ID="lblClass" runat="server" Text="Label"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                    <tr>
                       <td colspan="7" style="width: 98%" align="left">
                           <span  class="column_RightBold" >Sub Classification :</span>
                          <asp:DropDownList ID="drpSubClass" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="drpSubClass_SelectedIndexChanged" ></asp:DropDownList> &nbsp;
                           <span  class="column_RightBold" >Category :</span>
                                <asp:DropDownList ID="ddCategory" runat="server" AutoPostBack="True" Width="200px" CssClass="drpdownCSS" OnSelectedIndexChanged="ddCategory_SelectedIndexChanged"></asp:DropDownList>
                      
                       </td>
                    </tr>
                    <tr style="display: none;">
                        <td colspan="7" class="column_RightBold" style="width: 98%; text-align: right;"><%--STOCK CARD--%>Date :
                                 <asp:TextBox ID="txtDate" runat="server" CssClass="txtbox_Date" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td class="column_RightBold" style="width: 25%">
                            <span class="column_RightBold">Classification :</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddClass" runat="server" Width="200px" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                        </td>
                        <td class="column_RightBold" style="width: 100%;">General Account :
                        </td>
                        <td colspan=" 5">
                            <asp:DropDownList ID="ddGlAccount" runat="server" Width="525px" AutoPostBack="True" CssClass="drpdownCSS" Enabled="false" OnSelectedIndexChanged="ddGlAccount_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td style="text-align: right;">
                            <span class="column_RightBold">Category :</span>
                        </td>
                        <td>
                         </td>
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
                </table>


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
                <%--<br />
                <br />--%>
                <table style="width: 100%;">
                    <tr style="display: none;">
                        <td align="center" class="DivTitle" style="width: 100%">List Of Equipment

                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td align="center" style="width: 100%">
                            <span class="column_RightBold">Serial Number :</span>
                            &nbsp;<asp:TextBox ID="txtSerialSearch" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnEquipmentSerialSearch" runat="server" Width="120px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></td>
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
                    <tr>
                        <td align="center" style="width: 100%"><asp:HiddenField ID="hdnItemNo" runat="server" /><asp:HiddenField ID="hdnGAId" runat="server" /></td>
                    </tr>
                    <tr >
                        <td align="center" class="DivTitle" style="width: 100%"><asp:Label ID="lblSubClass" runat="server"></asp:Label> </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 100%">
                          <asp:MultiView ID="mvEquipment" runat="server" ActiveViewIndex ="1">
                             <asp:View ID="vwDefault" runat="server">
                                 
                                 <table style="width: 100%;">
                                     <tr>
                                         <td class="column_RightBold" style="width: 10%">Name :
                                         </td>
                                         <td class="column_Left" style="width: 30%">

                                             <asp:Label ID="lblequipmentname" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                             <asp:DropDownList ID="drpName" AutoPostBack="true" runat="server" Width="91%" OnSelectedIndexChanged="drpName_SelectedIndexChanged"></asp:DropDownList>

                                             <asp:TextBox ID="txtName" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                         </td>

                                         <td class="column_RightBold" style="width: 15%">Unit :
                                         </td>
                                         <td class="column_Left" style="width: 25%">

                                             <asp:Label ID="Label4" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                             <asp:DropDownList ID="drpUnit" AutoPostBack="true" runat="server" Width="100px" CssClass="drpdownCSS"></asp:DropDownList>
                                             <span class="column_RightBold">Quantity :</span>
                                             <asp:TextBox ID="txtEquipmentQuantity" runat="server" Width="100px" CssClass="txtbox_Var"></asp:TextBox>

                                             <asp:TextBox ID="TextBox1" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                         </td>
                                         <td align="center" rowspan="6" style="width: 20%" valign="middle">
                                             <asp:Image ID="Image3" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                             <br />
                                             <asp:Button ID="btnupload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" ></asp:Button>

                                         </td>
                                     </tr>
                                     <tr>
                                         <td class="column_RightBold" style="width: 10%">Description :
                                         </td>
                                         <td class="column_Left" style="width: 30%">
                                             <asp:Label ID="lblequipmentdesciption" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                             <asp:TextBox ID="txtequipmentdesciption" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                         </td>
                                         <td class="column_RightBold" style="width: 10%">Warranty :
                                         </td>
                                         <td class="column_Left" style="width: 30%">
                                             <asp:Label ID="lblequipmentwaranty" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                             <asp:TextBox ID="txtequipmentwaranty" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                         </td>
                                     </tr>
                                     <tr>
                                         <td class="column_RightBold" style="width: 10%">Power Input :
                                         </td>
                                         <td class="column_Left" style="width: 30%">
                                             <asp:Label ID="lblequipmentpowerinput" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                             <asp:TextBox ID="txtequipmentpowerinput" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                         </td>
                                         <td class="column_RightBold">&nbsp;Dimension :</td>
                                         <td class="column_Left">
                                             <asp:Label ID="lblequipmentdimension" runat="server" Font-Italic="False" SkinID="Label" Visible="false" Width="290px"></asp:Label>
                                             <asp:TextBox ID="txtequipmentdimension" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="89%"></asp:TextBox>

                                         </td>
                                         <td class="column_RightBold" style="width: 10%; display: none;">Area Capacity :
                                         </td>
                                         <td class="column_Left" style="width: 30%; display: none;">
                                             <asp:Label ID="lblequipmentareacapacity" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                             <asp:TextBox ID="txtequipmentareacapacity" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td class="column_RightBold" style="width: 10%">Model :
                                         </td>
                                         <td class="column_Left" style="width: 30%">
                                             <asp:Label ID="lblequipmentmodel" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                             <asp:TextBox ID="txtequipmentmodel" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                         </td>

                                         <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                         <td class="column_Left" style="width: 30%">
                                             <asp:LinkButton ID="Linkbutton1" runat="server" OnClick="btnaddpropertyinfo_Click" Text="Add Property Information"></asp:LinkButton>
                                         </td>

                                     </tr>
                                     <tr>
                                         <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                         <td class="column_Left" style="width: 30%">
                                             <asp:Label ID="Label20" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                             <asp:TextBox ID="txtequipmentSerialNo" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                         </td>
                                         <td></td>
                                         <td class="column_Left">

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
                                                             <asp:TextBox ID="txtContractor" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                         </td>
                                                         <td class="column_RightBold">Contact Person : 
                                                         </td>
                                                         <td class="column_Left">
                                                             <asp:TextBox ID="txtContactPerson" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
                                                         </td>
                                                         <td class="column_RightBold">Cellphone No. : 
                                                         </td>
                                                         <td class="column_Left">
                                                             <asp:TextBox ID="txtCellphoneNo" runat="server" Width="75%" CssClass="txtbox_Var"></asp:TextBox>
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
                                                         <td class="column_RightBold" style="width: 119px">Acquisition Date :
                                                         </td>
                                                         <td class="column_Left" style="width: 100px;">
                                                             <asp:Label ID="Label1" runat="server"></asp:Label>
                                                             <asp:TextBox ID="txtEAcqDate" runat="server" AutoPostBack="True" CssClass="txtbox_Var" OnTextChanged="txtEAcqDate_TextChanged" Width="140px" onchange="return NoOfYears(this.value);"></asp:TextBox>
                                                             <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEAcqDate" PopupButtonID="txtEAcqDate"></cc1:CalendarExtender>


                                                             &nbsp;(MM/DD/YYYY)</td>
                                                         <td class="column_RightBold">Market Value :
                                                         </td>
                                                         <td class="column_Left">
                                                             <asp:Label ID="Label3" runat="server"></asp:Label>
                                                             <asp:TextBox ID="txtEMarketValue" runat="server" Width="140px" CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>

                                                         </td>


                                                     </tr>
                                                     <tr>

                                                         <td class="column_RightBold" style="width: 119px">Acquisition Cost :
                                                         </td>
                                                         <td class="column_Left">
                                                             <asp:Label ID="Label2" runat="server"></asp:Label>
                                                             <asp:TextBox ID="txtEAcqCost" runat="server" AutoPostBack="True" Width="140px" CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalVal(this),getDepValRate(this);"></asp:TextBox>
                                                         </td>

                                                         <td class="column_RightBold">No. of Years :
                                                         </td>
                                                         <td class="column_Left">
                                                             <asp:Label ID="lblNoYears" runat="server"></asp:Label>
                                                             <asp:TextBox ID="txtNoYears" runat="server" AutoPostBack="True" CssClass="txtbox_Var" Width="50px"></asp:TextBox>

                                                         </td>
                                                     </tr>
                                                     <tr>

                                                         <td class="column_RightBold" style="width: 119px">Depreciated Rate :
                                                         </td>
                                                         <td class="column_Left">
                                                             <asp:TextBox ID="lblequipmentdepreciatedRate" runat="server" Width="50px"  CssClass="txtboxAmount" MaxLength="5" ReadOnly="True"  Visible="false"></asp:TextBox>
                                                             <asp:TextBox ID="txtDepreciatedRate" runat="server"  CssClass="txtboxAmount" Width="50px" MaxLength="5"></asp:TextBox>&nbsp;(%) Percent
                                                        </td>

                                                         <td class="column_RightBold">Useful Life :
                                                         </td>
                                                         <td class="column_Left">
                                                             <asp:Label ID="lblUsefulLife" runat="server"></asp:Label>
                                                             <asp:TextBox ID="txtUsefulLife" runat="server" Width="50px"  CssClass="txtbox_Var" onchange="return getDepValRate(this);" ></asp:TextBox>

                                                             &nbsp;(Years)</td>

                                                     </tr>


                                                     <tr>

                                                         <td class="column_RightBold" style="width: 119px">Depreciated Value :
                                                         </td>
                                                         <td class="column_Left">
                                                             <asp:Label ID="lblequipmentdepreciatedvalue" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                             <asp:TextBox ID="txtequipmentdepreciatedvalue" runat="server" AutoPostBack="True" Width="140px" CssClass="txtboxAmount"></asp:TextBox>
                                                         </td>

                                                         <td class="column_RightBold">Salvage Value :
                                                         </td>
                                                         <td class="column_Left">
                                                             <asp:TextBox ID="txtSalvageValue" runat="server" Width="140px" CssClass="txtboxAmount">0.00</asp:TextBox></td>


                                                     </tr>
                                                     <tr> 
                                                         <td class="column_RightBold" style="width: 119px">Depreciation Value :</td>
                                                         <td class="column_Left">
                                                             <asp:TextBox ID="txtDepreciationValue" runat="server" CssClass="txtboxAmount" Width="140px"></asp:TextBox>
                                                             (Per Year)</td>
                                                         <td></td>
                                                         <td></td>
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
                                                             <asp:DropDownList ID="drpEquipmentWarehouse" runat="server" Width="98%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                         </td>

                                                         <td class="column_RightBold">Bay :
                                                         </td>
                                                         <td class="column_Left">
                                                             <asp:TextBox ID="txtEquipmentBay" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                             <asp:DropDownList ID="DropDownList2" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                         </td>

                                                         <td class="column_RightBold" style="width: 15%">Column :
                                                         </td>
                                                         <td class="column_Left">
                                                             <asp:TextBox ID="txtEquipmentColumn" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                             <asp:DropDownList ID="DropDownList3" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                         </td>

                                                         <td class="column_RightBold" style="width: 10%">Floor :
                                                         </td>
                                                         <td class="column_Left">
                                                             <asp:TextBox ID="txtEquipmentFloor" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                             <asp:DropDownList ID="DropDownList4" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td class="column_RightBold">Room :
                                                         </td>
                                                         <td class="column_Left">
                                                             <asp:TextBox ID="txtEquipmentRoom" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                             <asp:DropDownList ID="DropDownList5" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                         </td>

                                                         <td class="column_RightBold" style="width: 10%">Shelves :
                                                         </td>
                                                         <td class="column_Left">
                                                             <asp:TextBox ID="txtEquipmentShelves" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                             <asp:DropDownList ID="DropDownList6" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                         </td>

                                                         <td class="column_RightBold">Rack :
                                                         </td>
                                                         <td class="column_Left">
                                                             <asp:TextBox ID="txtEquipmentRack" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>

                                                             <asp:DropDownList ID="DropDownList7" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                         </td>

                                                         <td class="column_RightBold">Bin :
                                                         </td>
                                                         <td class="column_Left">
                                                             <asp:TextBox ID="txtEquipmentBin" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                             <asp:DropDownList ID="DropDownList8" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
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
                                             <asp:Label ID="lblSpecification" runat="server" CssClass="text3"></asp:Label>
                                             <asp:TextBox ID="txtSpecification" runat="server" Width="95%" Height="25px" TextMode="MultiLine" AutoPostBack="True" CssClass="txtbox_Var" Rows="2"></asp:TextBox>

                                         </td>
                                     </tr>
                                     <tr>
                                         <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                         <td class="column_RightBold" colspan="3">
                                        <asp:HiddenField ID="hf_EquipInfoId" runat="server"/>
                                        <asp:HiddenField ID="hf_EquipmentId" runat="server"/>
                                        <asp:HiddenField ID="hf_PropertyDetai_ID" runat="server"/>
                                        <asp:HiddenField ID="hf_Property_ID" runat="server"/>
                                        <asp:HiddenField ID="hf_Item_ID" runat="server" />
                                         </td>

                                         <td>
                                             <asp:Button ID="btnSave" runat="server" Width="48%" CssClass="CSButton" Text="SAVE" Enabled="false" OnClick="btnSave_Click" OnClientClick="StartProgressBar();"></asp:Button>
                                             <asp:Button ID="btnCancel" runat="server" Width="48%" CssClass="CSButton" Text="CANCEL" Enabled="false"></asp:Button>
                                         </td>
                                     </tr>
                                 </table>

                             </asp:View>
                             <asp:View ID="vwVehicle" runat="server">
                                            
                            <table style="width: 100%;">
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">
                                        Name :

                                    </td>
                                    <td class="column_Left" style="width: 30%">

                                        <asp:Label ID="Label5" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="DrpVehicleName" AutoPostBack ="true" runat="server" Width="91%" OnSelectedIndexChanged="drpName_SelectedIndexChanged"></asp:DropDownList>
                                                          
                                        <asp:TextBox ID="TextBox2" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold" style="width: 10%">Power Input :

                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="Label9" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtVehiclePowerInput" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                    <td align="center" rowspan="6" style="width: 20%" valign="middle" >
                                        <asp:Image ID="Image1" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                        <br />
                                               <asp:Button ID="Button1" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>
                                
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">
                                        Description :

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
                                    

                                    <td class="column_RightBold" style="width: 10%">
                                        Make :

                                    </td>
                                    <td class="column_Left" style="width: 30%">

                                        <asp:Label ID="Label6" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="DropDownList9" AutoPostBack ="true" runat="server" Width="91%" OnSelectedIndexChanged="drpName_SelectedIndexChanged" Visible="false"></asp:DropDownList>
                                                          
                                        <asp:TextBox ID="txtVehicleMake" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" ></asp:TextBox>
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
                                   
                                    <td class="column_RightBold" style="width: 10%">
                                        Color :

                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="Label8" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtVehicleColor" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
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
                                        <asp:LinkButton id="btnAddPropertyInfo" runat="server" text="Add Property Information" OnClick="btnaddpropertyinfo_Click"></asp:LinkButton>
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
                                        <asp:Label ID="Label13" runat="server"></asp:Label>
                                        <asp:TextBox ID="TextBox10" runat="server"  AutoPostBack="True" CssClass="txtbox_Var" OnTextChanged="txtEAcqDate_TextChanged"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEAcqDate" PopupButtonID="txtEAcqDate"></cc1:CalendarExtender>


                                        &nbsp;(MM/DD/YYYY)</td>
                                   <td class="column_RightBold" >Market Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="Label14" runat="server"></asp:Label>
                                        <asp:TextBox ID="TextBox11" runat="server"  AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                    
                                    
                                </tr>
                                <tr>
                                    
                                    <td class="column_RightBold" >Acquisition Cost :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="Label15" runat="server" ></asp:Label>
                                        <asp:TextBox ID="TextBox12" runat="server" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    
                                    <td class="column_RightBold" >No. of Years :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="Label16" runat="server" ></asp:Label>
                                        <asp:TextBox ID="TextBox13" runat="server" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    
                                    <td class="column_RightBold">Dep. Rate :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="TextBox14" runat="server" Width="100px" CssClass="txtboxAmount" MaxLength="5" ReadOnly="True" ></asp:TextBox>&nbsp;(%) Percent</td>

                                    
                                    <td class="column_RightBold">Useful Life :
                                    </td>
                                    <td class="column_Left">
                                        <asp:Label ID="Label17" runat="server"></asp:Label>
                                        <asp:TextBox ID="TextBox15" runat="server" Width="100px"  CssClass="txtbox_Var" ></asp:TextBox>

                                        &nbsp;(Years)</td>

                                </tr>


                                <tr>
                                    
                                    <td class="column_RightBold" >Dep. Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="Label18" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="TextBox16" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    
                                   <td class="column_RightBold">Salvage Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:TextBox ID="TextBox17" runat="server" Width="85%"  AutoPostBack="True" CssClass="txtboxAmount" OnTextChanged="txtSalvageValue_TextChanged">0.00</asp:TextBox></td>


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
                                                                             <asp:DropDownList ID="DropDownList10" runat="server" Width="98%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Bay :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="TextBox18" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList11" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:15%">Column :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                 <asp:TextBox ID="TextBox19" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList12" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Floor :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                <asp:TextBox ID="TextBox20" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList13" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                     </tr>
                                                                     <tr>
                                                                         <td class="column_RightBold">Room :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="TextBox21" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList14" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Shelves :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="TextBox22" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList15" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Rack :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="TextBox23" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList16" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                         
                                                                         <td class="column_RightBold">Bin :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="TextBox24" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             <asp:DropDownList ID="DropDownList17" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
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
                                        <asp:Label ID="Label19" runat="server" CssClass="text3"></asp:Label>
                                        <asp:TextBox ID="TextBox25" runat="server" Width="95%" Height="25px" TextMode="MultiLine" AutoPostBack="True" CssClass="txtbox_Var" Rows="2"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                    <td class="column_RightBold" colspan="3"></td>
                                    <td>
                                        <asp:Button ID="Button2" runat="server" Width="48%" CssClass="CSButton" Text="SAVE" Enabled="false" OnClick="btnSave_Click" OnClientClick="StartProgressBar();"></asp:Button>
                                        <asp:Button ID="Button3" runat="server" Width="48%" CssClass="CSButton" Text="CANCEL" Enabled="false"></asp:Button>
                                    </td>
                                </tr>
                            </table>

                             </asp:View>
                             <asp:View ID="vwGun" runat="server">
                                 
                                 <table style="width: 100%;">
                                     <tr>
                                         <td class="column_RightBold" style="width: 10%">Name :

                                         </td>
                                         <td class="column_Left" style="width: 30%">  
                                             <asp:DropDownList ID="drpMilitaryEquipmentName" AutoPostBack="true" runat="server" Width="91%" OnSelectedIndexChanged="drpMilitaryEquipmentName_SelectedIndexChanged"></asp:DropDownList>

                                         </td>

                                         <td class="column_RightBold" style="width: 15%">Unit :

                                         </td>
                                         <td class="column_Left" style="width: 25%">
                                             <asp:DropDownList ID="drpMilitaryEquipmentUnit" AutoPostBack="true" runat="server" Width="100px" CssClass="drpdownCSS"></asp:DropDownList>
                                             <span class="column_RightBold">Quantity :</span>
                                             <asp:TextBox ID="txtMilitaryEquipmentQuantity" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>
                        
                                             </td>
                                         <td align="center" rowspan="7" style="width: 30%" valign="top">
                                             <asp:Image ID="Image2" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
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
                                         <td class="column_RightBold" >Frame :

                                         </td>
                                         <td class="column_Left">
                                             <asp:TextBox ID="txtMilitaryEquipmentFrame" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                         </td>
                                     </tr>
                                     <tr>
                                         <td class="column_RightBold" >Manufacturer :

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
                                         <td class="column_RightBold" >Caliber :

                                         </td>
                                         <td class="column_Left" style="width: 30%">
                                             <asp:TextBox ID="txtMilitaryEquipmentCaliber" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>

                                         </td>

                                         <td class="column_RightBold" >Capacity Extended :

                                         </td>
                                         <td class="column_Left" >
                                             <asp:TextBox ID="txtMilitaryEquipmentCapacityExtended" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                     
                                             </td>

                                     </tr>
                                     <tr>
                                         <td class="column_RightBold" >Barrel :

                                         </td>
                                         <td class="column_Left" style="width: 30%">
                                             <asp:TextBox ID="txtMilitaryEquipmentBarrel" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                         </td>
                                         <td class="column_RightBold">Sights :

                                         </td>
                                         <td class="column_Left" >
                                             <asp:TextBox ID="txtMilitaryEquipmentSights" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                         </td>
                                        

                                     </tr>
                                   <tr>
                                       <td></td>
                                       <td></td>
                                        <td></td>
                                         <td class="column_Left">
                                             <asp:LinkButton ID="btnMilitaryEquipmentaddpropertyinfo" runat="server" Text="Add Property Information" OnClick="btnMilitaryEquipmentaddpropertyinfo_Click"></asp:LinkButton>

                                         </td>
                                   </tr>
                                     <tr>
                                         <td colspan="4" >
                                             <fieldset style="width: 90%;">
                                                 <legend class="column_LeftBold">Acquisition :</legend>
                                                 <table width="100%">
                                                     <tr>
                                                         <td class="column_RightBold">Acquisition Date :

                                                         </td>
                                                         <td class="column_Left" style="width: 200px;">
                                                             <asp:TextBox ID="txtMilitaryEquipmentAcqDate" runat="server" Width="100px"  AutoPostBack="True" CssClass="txtbox_Var" OnTextChanged="txtEAcqDate_TextChanged"></asp:TextBox>
                                                             <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtMilitaryEquipmentAcqDate" PopupButtonID="txtMilitaryEquipmentAcqDate"></cc1:CalendarExtender>


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
                                                             <asp:TextBox ID="txtMilitaryEquipmentDepRate" runat="server" Width="100px"  CssClass="txtboxAmount" MaxLength="5" ></asp:TextBox>&nbsp;(%) Percent</td>


                                                         <td class="column_RightBold">Useful Life :
                                                         </td>
                                                         <td class="column_Left">
                                                             <asp:TextBox ID="txtMilitaryEquipmentUsefulLife" runat="server" Width="100px" CssClass="txtbox_Var" ></asp:TextBox>

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
                                     <tr>
                                         <td class="column_RightBold">&nbsp;</td>
                                         <td class="column_RightBold" colspan="3"></td>
                                         <td>
                                             <asp:Button ID="btnMilitaryEquipmentSave" runat="server" Width="48%" CssClass="CSButton" Text="SAVE" Enabled="false" OnClick="btnMilitaryEquipmentSave_Click" OnClientClick="StartProgressBar();"></asp:Button>
                                             <asp:Button ID="btnMilitaryEquipmentCancel" runat="server" Width="48%" CssClass="CSButton" Text="CANCEL" Enabled="false"></asp:Button>
                                         </td>
                                     </tr>
                                 </table>

                             </asp:View>                           
                          </asp:MultiView>
                            <asp:Label ID="lblEquipDateTaken" runat="server" Width="110px" CssClass="textimage2" Visible="False"></asp:Label>
                            <asp:Label ID="lblEquipUploadedBy" runat="server" Width="110px" CssClass="textimage2" Visible="False"></asp:Label>
                            <asp:Label ID="lblEquipPosition" runat="server" Width="110px" CssClass="textimage2" Visible="False"></asp:Label>
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

                  <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="lblSubClass" PopupControlID="popupParticular" CancelControlID="ImageButton2" BackgroundCssClass="modalBackground">
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
                                   
                                    <asp:TemplateField HeaderText="Property No." >
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtPropertyNo" runat ="server" AutoPostBack="true" OnTextChanged="txtPropertyNo_TextChanged" Width ="150px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Serial No." >
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtSerialNoOfEquip" runat ="server" Width ="150px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width ="19%" HeaderText="Installed At">
                                        <ItemTemplate>
                                       <asp:DropDownList ID="drpInstalledAtEquip" runat="server" Width ="150px" OnSelectedIndexChanged="drpInstalledAtMac_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-Width ="19%" HeaderText="Location">
                                        <ItemTemplate>
                                         <asp:TextBox ID="txtPIFloorLocation" runat ="server"  Width ="250"></asp:TextBox>
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

            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lblClass" PopupControlID="Panel2" CancelControlID="ImageButton2" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
            <asp:Panel ID="Panel2" runat="server" Width="350px" CssClass="Panel_Popup">
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
                                <asp:Button ID="Button4" OnClick="Button4_Click"  runat="server" Width="150px" CssClass="CSButton" Text="PROCEED"></asp:Button>
                    
                                <asp:Button ID="Button5" OnClick="Button5_Click"  runat="server" Width="150px" CssClass="CSButton" Text="CANCEL"></asp:Button>
                    </td>
                      </tr>
                  </table>
                  
                  </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

