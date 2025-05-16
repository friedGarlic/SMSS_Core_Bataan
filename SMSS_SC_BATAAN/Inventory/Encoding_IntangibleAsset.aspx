<%@ Page Title="Encoding of Intangible Asset" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Encoding_IntangibleAsset.aspx.vb" Inherits="Inventory_Encoding_IntangibleAsset" StylesheetTheme="SkinFile"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
<script type="text/javascript">

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
            document.getElementById("ctl00_ContentPlaceHolder1_txtNoofYears").value = age;}
       
 }
   

    //Optimize this code
    function getDepValRate() {
      const year = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtNoofYears').value);
      const UL = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtUsefullife').value);

      const depval = Math.min(100, (year / UL) * 100);

      document.getElementById('ctl00_ContentPlaceHolder1_txtDepreciatedRate').value = depval.toFixed(2);

      const AcquisationCostVal = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtAcquisitionCost').value.replace(/\,/g, ''));
      const Salvagevalue = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtSalvageValue').value.replace(/\,/g, ''));

      let Depreciation = 0.00;
      if (AcquisationCostVal > 0 && Salvagevalue > 0 && UL > 0) {
        Depreciation = (AcquisationCostVal - Salvagevalue) / UL;
      }

      document.getElementById('ctl00_ContentPlaceHolder1_txtDepreciationValue').value = Depreciation.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

      const DepreciatedtVal = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtDepreciationValue').value.replace(/\,/g, ''));
      const DepreciatedValue = DepreciatedtVal > 0 ? AcquisationCostVal - DepreciatedtVal * year : 0;

      document.getElementById('ctl00_ContentPlaceHolder1_txtDepreciatedValue').value = DepreciatedValue.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }


    function getSalVal(Double) {
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtAcquisitionCost").value;
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
                        <td class="PageTitle" style="width: 98%">
                            <strong>
                                <asp:Label ID="lblClass" runat="server" Text="Encoding of Intangible Asset"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                     <tr>
                         <td>
                             <table>
                                 <tr>
                                     <td class="column_RightBold">Sub Classification :</td>
                                     <td class="column_Left"><asp:DropDownList ID="drpSubClassification" runat="server" CssClass="drpdownCSS" Width="150px"></asp:DropDownList></td>
                                 </tr>
                             </table>
                         </td>
                    
                     </tr>

                    <tr>
                        <td align="center" style="width: 100%"><asp:HiddenField ID="hdnItemNo" runat="server" /><asp:HiddenField ID="hdnGAId" runat="server" /></td>
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
                                  <td style="width:145px" class="column_RightBold">&nbsp;</td>
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
                                      <asp:TextBox ID="txtTitle" runat="server" CssClass="txtbox_Var"></asp:TextBox>
                                  </td>
                                  <td style="width:145px" class="column_RightBold">No. of Disc :</td>
                                  <td style="width:145px"> 
                                      <asp:TextBox ID="txtNoofdisc" CssClass="txtbox_Var" runat="server"></asp:TextBox></td>
                                  <td style="width:145px"></td>
                                  <td style="width:145px"></td>
                                  <td style="width:145px"></td>
                              </tr>
                              <tr>
                                  <td style="width:145px; height: 23px;" class="column_RightBold">Brand :</td>
                                  <td style="width:145px; height: 23px;" class="column_Left">
                                      <asp:TextBox ID="txtBrand" runat="server" CssClass="txtbox_Var"></asp:TextBox>
                                  </td>
                                  <td style="width:145px; height: 23px;" class="column_RightBold">Model :</td>
                                  <td style="width:145px; height: 23px;"> 
                                      <asp:TextBox ID="txtModel" CssClass="txtbox_Var" runat="server"></asp:TextBox></td>
                                  <td style="width:145px; height: 23px;"></td>
                                  <td style="width:145px; height: 23px;" colspan="2" rowspan="4">
                                      <asp:Image ID="imgpropertydocs" runat="server" Height="202px" ImageUrl="~/images/blankImage.jpg" Width="204px" />
                                      <asp:Button ID="btnUpload" runat="server" OnClientClick="StartProgressBar();" CssClass="CSButton" Text="UPLOAD" Width="120px" />
                                  </td>
                                  
                              </tr>
                              <tr>
                                  <td style="width:145px" class="column_RightBold">Serial No. :</td>
                                  <td style="width:145px" class="column_Left">
                                      <asp:TextBox ID="txtSerialNo" CssClass="txtbox_Var" runat="server"></asp:TextBox>
                                  </td>
                                  <td style="width:145px" class="column_RightBold">License Duration :</td>
                                  <td style="width:145px"> 
                                      <asp:TextBox ID="txtLicenceDuration" CssClass="txtbox_Var" runat="server"></asp:TextBox></td>
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
                                                    <td class="column_Left" style="width:250px"><asp:TextBox ID="txtAcquisitionDate" runat="server" CssClass="txtbox_Var" onchange="return NoOfYears(this.value);"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtAcquisitionDate" PopupButtonID="txtAcquisitionDate"></cc1:CalendarExtender>
                                                        &nbsp;MM/DD/YYYY</td>
                                                    <td class="column_RightBold" style="width:150px">Market Value :</td>
                                                    <td class="column_Left" style="width:100px"><asp:TextBox ID="txtMarketValue" runat="server" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox></td>
                                                </tr>
                                                  <tr>
                                                    <td class="column_RightBold" style="width:115px">Acquisition Cost :</td>
                                                    <td class="column_Left" style="width:250px"><asp:TextBox ID="txtAcquisitionCost" runat="server" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalVal(this),getDepValRate(this);"></asp:TextBox></td>
                                                    <td class="column_RightBold" style="width:150px">No. of Years :</td>
                                                    <td class="column_Left" style="width:100px"><asp:TextBox ID="txtNoofYears" runat="server" CssClass="txtbox_Var" Width="75px"></asp:TextBox></td>
                                                 </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="width:115px">Depreciated Rate :</td>
                                                    <td class="column_Left" style="width:250px"><asp:TextBox ID="txtDepreciatedRate" runat="server" CssClass="txtbox_Var" Width="75"></asp:TextBox> &nbsp;(%)Percent</td>
                                                    <td class="column_RightBold" style="width:150px">Useful Life :</td>
                                                    <td class="column_Left" style="width:100px"><asp:TextBox ID="txtUsefullife" runat="server" CssClass="txtbox_Var" Width="75px" onchange="return getDepValRate(this);"></asp:TextBox></td>
                                                 </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="width:115px">Depreciated Value :</td>
                                                    <td class="column_Left" style="width:250px"><asp:TextBox ID="txtDepreciatedValue" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                                    <td class="column_RightBold" style="width:150px">Salvage Value :</td>
                                                    <td class="column_Left" style="width:100px"><asp:TextBox ID="txtSalvageValue" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                                 </tr>

                                             <tr>
                                                       <td class="column_RightBold" style="width:115px">Depreciation Value :</td>
                                                       <td class="column_Left" style="width:250px"><asp:TextBox ID="txtDepreciationValue" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                                       <td></td>
                                                       <td></td>
                                             </tr>
                                               
                                            </table>
                                       </fieldset>
                                  </td>
                                 <%-- <td colspan="2">
                                 
                                                 
                                      
                                  </td>--%>
                               
                              </tr>
                             <%-- <tr>
                                  <td colspan="5"></td>
                                  <td>&nbsp;</td>
                                  <td>&nbsp;</td>
                              </tr>--%>
                              <tr>
                                  <td colspan="5">
                                        <fieldset>
                                           <legend class="column_LeftBold">Warehouse :</legend>
                                            <table>
                                                <tr>
                                                    <td class="column_RightBold" style="width:75px">Warehouse :</td>
                                                    <td class="column_Left"><asp:DropDownList ID="drpWarehouse" runat="server" Width="150px"></asp:DropDownList></td>
                                                    <td class="column_RightBold" style="width:75px">Bay :</td>
                                                    <td class="column_Left"><asp:TextBox ID="txtBay" runat="server" CssClass="txtbox_Var" Width="85px"></asp:TextBox></td>
                                                    <td class="column_RightBold" style="width:75px">Column :</td>
                                                    <td class="column_Left"><asp:TextBox ID="txtColumn" runat="server" CssClass="txtbox_Var" Width="85px"></asp:TextBox></td>
                                                    <td class="column_RightBold" style="width:75px">Floor :</td>
                                                    <td class="column_Left"><asp:TextBox ID="txtFloor" runat="server" CssClass="txtbox_Var" Width="85px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="width:75px">Room :</td>
                                                    <td class="column_Left"><asp:TextBox ID="txtRoom" runat="server" CssClass="txtbox_Var" Width="85px"></asp:TextBox></td>
                                                    <td class="column_RightBold" style="width:75px">Shelves :</td>
                                                    <td class="column_Left"><asp:TextBox ID="txtShelves" runat="server" CssClass="txtbox_Var" Width="85px"></asp:TextBox></td>
                                                    <td class="column_RightBold" style="width:75px">Rack :</td>
                                                    <td class="column_Left"><asp:TextBox ID="txtRack" runat="server" CssClass="txtbox_Var" Width="85px"></asp:TextBox></td>
                                                    <td class="column_RightBold" style="width:75px">Bin :</td>
                                                    <td class="column_Left"><asp:TextBox ID="txtBin" runat="server" CssClass="txtbox_Var" Width="85px"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                  </td>
                                  <td style="vertical-align:text-top">
                                      <asp:Button ID="btnSave" runat="server" OnClientClick="StartProgressBar();" CssClass="CSButton" Text="SAVE" Width="95%"  />
                                  </td>
                                  <td  style="vertical-align:text-top">
                                      <asp:Button ID="btnCancel0" runat="server" OnClientClick="StartProgressBar();" CssClass="CSButton" Text="CANCEL" Width="95%" />
                                  </td>
                              </tr>
                          </table>
                          </td>
                      </tr>
                      <tr>
                          <td>
                              <br />
                             <asp:GridView ID="grdLedger1" runat="server" Width="100%" AllowPaging="True" SkinID="GridViewAA" HorizontalAlign="Center" OnPageIndexChanging="grdLedger1_PageIndexChanging" Font-Size="8pt" OnDataBound="OnDataBound" >
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
                                                            <asp:BoundField DataField="BalanceUnit" HeaderText="Ref No.">
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