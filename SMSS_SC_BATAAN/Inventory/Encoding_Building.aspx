<%@ Page 
    Title="Encoding of Building" 
    Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="Encoding_Building.aspx.vb" 
    Inherits="Inventory_Encoding_Building" 
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
   
     function getDepValRate(Integer) {
         var year =  document.getElementById('ctl00_ContentPlaceHolder1_txtNoYears').value;
         var UL =  document.getElementById('ctl00_ContentPlaceHolder1_txtUsefulLife').value;

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
                       <tr>
                        <td align="center" style="width: 100%"><asp:HiddenField ID="hdnItemNo" runat="server" /><asp:HiddenField ID="hdnGAId" runat="server" /></td>
                    </tr>
                      <tr>
                        <td align="center" colspan="7" class="DivTitle" style="width: 100%">
                            BUILDING INFORMATION 
                        </td>
                       </tr>
                      <tr>
                        <td colspan="7">
                            <table width="100%">
                                <tr>
                                <td  style="width:35%">
                                      <table  >
                                           <tr>
                                    <td class="column_RightBold">
                                        Building Name :
                                    </td>
                                    <td class="column_Left">
                                       <asp:TextBox ID="txtBuildingName" runat="server" Width="75%" CssClass="txtbox_Var" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width:30%">

                                        Address : 
                                    </td>
                                    <td class="column_Left" style="width:40%">
                                      <asp:TextBox ID="txtAddress" runat="server" Width="100%" CssClass="txtbox_Var" ></asp:TextBox>
                                  </td>
                                   
                                </tr>
                                <tr>
                                     <td class="column_RightBold"style="width:10%" >
                                        Brgy :
                                    </td>
                                    <td class="column_Left" style="width:20%">
                                         <asp:TextBox ID="txtBrgy" runat="server" Width="50%"  CssClass="txtbox_Var" ></asp:TextBox>
                                 </td>
                                </tr>
                                           <tr>
                                            <td class="column_RightBold" style="width:20%">Property No. :</td>
                                            <td class="column_Left" style="width:40%">
                                                <asp:TextBox ID="txtPropertyNo" runat="server" CssClass="txtbox_Var"></asp:TextBox>
                                               </td>
                                          
                                        </tr>
                                
                            </table>
                                </td>
                                <td align="left"style="width:50%" >
                                    <table width="100%">
                                         <tr>
                                            <td class="column_RightBold" style="width:25%">
                                                Area :
                                            </td>
                                            <td class="column_Left"  style="width:70%">
                                             <asp:TextBox ID="txtArea" runat="server"  Width="34%"  CssClass="txtbox_Var" ></asp:TextBox>
                                      
                                                </td>
                                        </tr>
                                         <tr>
                                            <td class="column_RightBold">
                                                Tax Dec. No.: 
                                            </td>
                                            <td class="column_Left">
                                              <asp:TextBox ID="txtTaxDecNo" runat="server" Width="34%"  CssClass="txtbox_Var" ></asp:TextBox>
                                          </td>
                                        </tr>
                                         <tr>
                                            <td class="column_RightBold" >
                                                Previous Owner :
                                            </td>
                                            <td  class="column_Left" colspan =" 3">
                                               <asp:TextBox ID="txtPrevOwner" runat="server" Width="75%" CssClass="txtbox_Var" ></asp:TextBox>
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
                                      <td style="width:80%;" valign="top">
                                          <fieldset>
                                             
                                            <legend class="column_LeftBold">Acquisition :</legend>
                                               <table >
                                            <tr>
                                             <td  class="column_RightBold" style="width: 119px" >
                                                 Acquisition Date :
                                            </td>
                                             <td class="column_Left" style="width:100px;">
                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtEAcqDate" runat="server"  CssClass="txtbox_Var" Width="140px" onchange="return NoOfYears(this.value);"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEAcqDate" PopupButtonID="txtEAcqDate"></cc1:CalendarExtender>
                                        &nbsp;(MM/DD/YYYY)</td>
                                   <td class="column_RightBold" >Market Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtEMarketValue" runat="server" CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);" Width="140px"></asp:TextBox>

                                    </td>
                                    
                                    
                                </tr>
                                            <tr>
                                    
                                    <td class="column_RightBold" style="width: 119px" >Acquisition Cost :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="Label2" runat="server" ></asp:Label>
                                        <asp:TextBox ID="txtEAcqCost" runat="server" Width="140px" CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalVal(this),getDepValRate(this);"></asp:TextBox>
                                    </td>
                                    
                                    <td class="column_RightBold" >No. of Years :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="lblNoYears" runat="server" ></asp:Label>
                                        <asp:TextBox ID="txtNoYears" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                </tr>
                                            <tr>
                                    
                                    <td class="column_RightBold" style="width: 119px">Depreciated Rate :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="lblequipmentdepreciatedRate" runat="server" Width="50px" CssClass="txtboxAmount" MaxLength="5" ></asp:TextBox>&nbsp;(%) Percent</td>

                                    
                                    <td class="column_RightBold">Useful Life :
                                    </td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblUsefulLife" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtUsefulLife" runat="server" Width="50px" CssClass="txtbox_Var" onchange="return getDepValRate(this);" ></asp:TextBox>

                                        &nbsp;(Years)</td>

                                </tr>
                                            <tr>
                                    
                                    <td class="column_RightBold" style="width: 119px" >Depreciated Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="lblequipmentdepreciatedvalue" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtequipmentdepreciatedvalue" runat="server"  Width="140px"  CssClass="txtboxAmount"></asp:TextBox>
                                    </td>
                                    
                                   <td class="column_RightBold">Salvage Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:TextBox ID="txtSalvageValue" runat="server" Width="140px"  CssClass="txtboxAmount" >0.00</asp:TextBox></td>


                                </tr>
                                                   <tr>
                                                       <td class="column_RightBold" style="width: 119px">Depreciation Value :</td>
                                                       <td class="column_Left"><asp:TextBox ID="txtDepreciationValue" runat="server"  Width="140px"  CssClass="txtboxAmount"></asp:TextBox>&nbsp;(Per Year)</td>
                                                       <td></td>
                                                       <td></td>
                                                   </tr>

                                        </table>
                                          </fieldset>
                                       
                                      </td>
                                      <td style="border:2px solid #5c85d6" valign="top" rowspan ="2">
                                           <asp:Image ID="imgpropertydocs" runat="server" Width="204px" ImageUrl="~/images/blankImage.jpg" Height="202px"></asp:Image></center>
                                       <br><br>
                                                <asp:Button ID="btnUpload" runat="server" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="UPLOAD" Width="120px" />
                                                 
                                      </td>
                                      
                                  </tr>
                                  <tr>
                                      <td style="width:80%;border:2px solid #5c85d6" valign="top">
                                          <table width="100%">
                                              <tr>
                                                  <td style="width:50%;">
                                                      <table width="100%">
                                                          <tr>
                                                              <td class="column_RightBold">
                                                                  Building Control No. :
                                                              </td>
                                                              <td class="column_Left">
                                                                 <asp:TextBox ID="txtBuildingControlNo" runat="server" Width="75%" CssClass="txtbox_Var" ></asp:TextBox>
                                                              </td>
                                                          </tr>
                                                          <tr>
                                                              <td class="column_RightBold">
                                                                  Building Code :
                                                              </td>
                                                              <td class="column_Left">
                                                                 <asp:TextBox ID="txtBuildingCode" runat="server" Width="75%" CssClass="txtbox_Var" ></asp:TextBox>
                                                              </td>
                                                          </tr>
                                                          <tr>
                                                              <td class="column_RightBold">
                                                                  Building Use :
                                                              </td>
                                                              <td class="column_Left">
                                                                 <asp:TextBox ID="txtBuildingUse" runat="server" Width="75%" CssClass="txtbox_Var" ></asp:TextBox>
                                                              </td>
                                                          </tr>
                                                          <tr>
                                                              <td class="column_RightBold">
                                                                  Postal Code :
                                                              </td>
                                                              <td class="column_Left">
                                                                 <asp:TextBox ID="txtPostalCode" runat="server" Width="75%" CssClass="txtbox_Var" ></asp:TextBox>
                                                              </td>
                                                          </tr>
                                                      </table>
                                                  </td>
                                                  <td style="width:50%;">
                                                      <table width="100%">
                                                          <tr>
                                                              <td class="column_RightBold">
                                                                  Building Occupancy :
                                                              </td>
                                                              <td class="column_Left">
                                                                 <asp:TextBox ID="txtBuildingOccupancy" runat="server" Width="75%" CssClass="txtbox_Var" ></asp:TextBox>
                                                              </td>
                                                          </tr>
                                                          <tr>
                                                              <td class="column_RightBold">
                                                                  No. of Floors :
                                                              </td>
                                                              <td class="column_Left">
                                                                 <asp:TextBox ID="txtNoofFloors" runat="server" Width="75%" CssClass="txtbox_Var" ></asp:TextBox>
                                                              </td>
                                                          </tr>
                                                          <tr>
                                                              <td class="column_RightBold">
                                                                  Avg. Area per Floor :
                                                              </td>
                                                              <td class="column_Left">
                                                                 <asp:TextBox ID="txtAvgAreaperFloor" runat="server" Width="75%" CssClass="txtbox_Var" ></asp:TextBox>
                                                              </td>
                                                          </tr>
                                                          <tr>

                                                              <td class="column_RightBold">
                                                                  Cost per Area :
                                                              </td>
                                                              <td class="column_Left">
                                                                 <asp:TextBox ID="txtCostperArea" runat="server" Width="75%" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
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
                          <td colspan="7" align="right" style="padding-right:10px">
                               <asp:Button ID="btnSave" runat="server" Width="18%" CssClass="CSButton" Text="SAVE"  OnClick="btnSave_Click" OnClientClick="StartProgressBar();"></asp:Button>                                       
                               <asp:Button ID="btnCancel" runat="server" Width="18%" CssClass="CSButton" Text="CANCEL"  OnClientClick="StartProgressBar();"></asp:Button>                                       
                          </td>
                      </tr>
                      <tr>
                        <td colspan="7">
                            <br />
                              <asp:GridView ID="grdLedger1" runat="server" Width="100%" SkinID="GridViewAA" HorizontalAlign="Center" Font-Size="8pt" OnDataBound="OnDataBound" >
                                                        <%--OnSelectedIndexChanged="grdrepairsandmaintenance_SelectedIndexChanged" OnRowDataBound="grdLedger1_RowDataBound"--%>
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
                                                            <asp:BoundField DataField="SerialNo" HeaderText="Ref No.">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="UnitPrice" DataFormatString="{0:N}" HeaderText="Unit Price" Visible="false" >
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="DebitQty" HeaderText="Debit Qty" Visible="false">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText=" ">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CreditQty" HeaderText="Credit Qty" Visible="false">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText=" ">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BalQty" HeaderText="Bal Qty" Visible="false">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BalCost" DataFormatString="{0:N}" HeaderText=" ">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                        </td>
                    </tr>
                  </table>
              </div>
          </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

