<%@ Page 
    Title="Encoding of Land"
    Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="Encoding_Land.aspx.vb" 
    Inherits="Inventory_Encoding_Land" 
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">



</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script language="javascript" type="text/javascript">
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
        function ConverttoHectares(e) {
            var hectares = e.replace(/[^0-9]/g, '') / 10000;
            document.getElementById("ctl00_ContentPlaceHolder1_Label1").innerText =hectares;
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" onkeydown = "return (event.keyCode!=13)">
        <ContentTemplate>
        <div>
                <table width="100%">
                    <tr>
                        <td colspan="7" class="PageTitle" style="width: 98%">
                            <%--STOCK CARD--%><strong>
                                <asp:Label ID="lblClass" runat="server" Text="Encoding of Land"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 100%"><asp:HiddenField ID="hdnItemNo" runat="server" /><asp:HiddenField ID="hdnGAId" runat="server" /></td>
                    </tr>
                    <tr style="display:none;">
                       <td colspan ="7">
                           <table>
                                <tr>
                                    <td class="column_RightBold">Classification : </td>
                                    <td>
                                        <asp:DropDownList ID="ddClass" runat="server"   CssClass="drpdownCSS" OnSelectedIndexChanged="ddClass_SelectedIndexChanged" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                           </table>
                           </td>
                    </tr>
                        <tr>
                            <td align="center" colspan="7" class="DivTitle" style="width: 100%">LAND INFORMATION </td>
                        </tr>
                    <tr>
                        <td colspan="7">
                            <table width="100%">
                                <tr>
                                    <td align="right" style="width:55%">
                                        <table width="100%">
                                            <tr>
                                                <td class="column_RightBold" style="width:35%">Address : </td>
                                                <td class="column_Left" style="width:35%">
                                                    <asp:TextBox ID="txtLocation" runat="server" CssClass="txtbox_Var" Width="99%"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:10%">Brgy : </td>
                                                <td class="column_Left" style="width:15%">
                                                    <asp:Dropdownlist ID="ddBrgy1" runat="server" CssClass="txtbox_Var" Width="89%"></asp:Dropdownlist>
                                                
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width: 35%">Area : </td>
                                                <td class="column_LeftBold" >
                                                    <asp:TextBox ID="txtArea" runat="server" CssClass="txtbox_Var" OnTextChanging="txtArea_TextChanging" Width="50%" onchange="return ConverttoHectares(this.value);"></asp:TextBox>(in sq. meters)
                                                    
                                                </td>
                                            <td class="column_LeftBold" colspan ="2">
                                                = &nbsp; <asp:Label ID="Label1" runat="server" Text="" ></asp:Label> &nbsp;(hectares)
                                            </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width: 35%">Certificate of Ownership : </td>
                                                <td class="column_Left">
                                                    <asp:DropDownList ID="ddTaxDecNo" runat="server" CssClass="txtbox_Var" Width="75%">
                                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                        <asp:ListItem Value="1">Titled</asp:ListItem>
                                                        <asp:ListItem Value="2">Tax Declaration</asp:ListItem>
                                                        <%--<asp:ListItem Value="1">Property Holding (All Property Holdings)</asp:ListItem>
                                                        <asp:ListItem Value="2">Property Holding (No Land Holding)</asp:ListItem>
                                                        <asp:ListItem Value="3">Non-Property Holding</asp:ListItem>
                                                        <asp:ListItem Value="4">Ownership (No Improvements)</asp:ListItem>
                                                        <asp:ListItem Value="5">Ownership (Improvements Made)</asp:ListItem>
                                                        <asp:ListItem Value="6">Ownership (One lot)</asp:ListItem>
                                                        <asp:ListItem Value="7">Ownership (Tax Exempt)</asp:ListItem>
                                                        <asp:ListItem Value="8">Ownership (With Improvements)</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width: 35%">Present Owner : </td>
                                                <td class="column_Left" colspan=" 3">
                                                    <asp:TextBox ID="txtPrevOwner" runat="server" CssClass="txtbox_Var" Width="95%"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="left" style="width:50%">
                                        <table width="100%">
                                            <tr>
                                                <td class="column_RightBold" style="width:25%">Acquisition Date : </td>
                                                <td class="column_Left" style="width:70%">
                                                    <asp:TextBox ID="txtEAcqDate" runat="server" CssClass="txtbox_Var" Width="50%"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtEAcqDate" TargetControlID="txtEAcqDate">
                                                    </cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold">Acquisition Cost : </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtAcqCost" runat="server" CssClass="txtbox_Var" Width="50%" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold">Acquisition Mode : </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtAcqMode" runat="server" CssClass="txtbox_Var" Width="50%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold">Market Value : </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtMarketValue" runat="server" CssClass="txtbox_Var" Width="50%" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>               
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" >
                            <table width="100%">
                                <tr>
                                    <td style="width:80%;border:2px solid #5c85d6" valign="top" >
                                        <table width="100%">
                                            <tr>
                                                <td align="center" colspan="8" class="DivTitle" style="width: 100%">PROPERTY IDENTIFICATION</td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width:12%">
                                                    LGU Code :
                                                </td>
                                                <td class="column_Left">
                                                   <asp:TextBox ID="txtLGUCode" runat="server" Width="95%"  CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    District Code :
                                                </td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="txtDistrictCode" runat="server" Width="95%"  CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    City/Mun. Code :
                                                </td>
                                                <td  class="column_Left" >
                                                    <asp:TextBox ID="txtCityCode" runat="server" Width="95%"  CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">Brgy Code :</td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="txtBrgyCode" runat="server" Width="89%"  CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="column_RightBold" style="width:12%">
                                                    Section No. :
                                                </td>
                                                <td class="column_Left">
                                                   <asp:TextBox ID="txtSectionNo" runat="server" Width="95%"  CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    Parcel No. :
                                                </td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="txtParcelNo" runat="server" Width="95%"  CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    Series No. :
                                                </td>
                                                <td  class="column_Left" >
                                                    <asp:TextBox ID="txtSeriesNo" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    RPTIN :
                                                </td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="txtRPTIN" runat="server" Width="89%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="column_RightBold" style="width:12%">
                                                   PIN :
                                                </td>
                                                <td class="column_Left">
                                                   <asp:TextBox ID="txtPIN" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    ARP :
                                                </td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="txtARP" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                  <td class="column_RightBold" style="width:12%">
                                                   TDN :
                                                </td>
                                                <td class="column_Left">
                                                   <asp:TextBox ID="txtTDN" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                              <td class="column_RightBold" style="width:12%">
                                                    Rev Year :
                                                </td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="txtRevYear" runat="server" Width="89%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                              
                                            </tr>
                                             <tr style="display:none;">
                                                 <td class="column_RightBold" style="width:12%">
                                                   Dep. Rate :
                                                </td>
                                                <td  class="column_Left" >
                                                    <asp:TextBox ID="txtDepRate" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                
                                                <td class="column_RightBold" style="width:12%">
                                                   Dep. Value :
                                                </td>
                                                <td  class="column_Left" >
                                                    <asp:TextBox ID="txtDepValue" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                              
                                            </tr>
                                        </table>
                                    </td>
                                    <td  rowspan="2"  style="width:80% ;border:2px solid #5c85d6" valign="top">
                                              <asp:Image ID="imgpropertydocs" runat="server" Width="204px" ImageUrl="~/images/blankImage.jpg" Height="202px"></asp:Image></center>
                                                  <br><br>
                                                <asp:Button ID="btnUpload" runat="server" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="UPLOAD" Width="120px" />
                                                 
                                    </td>
                                </tr>
                                <tr>
                                      <td style="width:80% ;border:2px solid #5c85d6" valign="top">
                                            <table width="100%">
                                            <tr>
                                                <td align="center" colspan="8" class="DivTitle" style="width: 100%">LOCATION</td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width:12%">
                                                    Lot No. :
                                                </td>
                                                <td class="column_Left">
                                                   <asp:TextBox ID="txtLotNo" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    Street :
                                                </td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="txtStreet" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    Purok :
                                                </td>
                                                <td  class="column_Left" >
                                                    <asp:TextBox ID="txtPurok" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    Phase No. :
                                                </td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="txtPhaseNo" runat="server" Width="89%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width:12%">
                                                    Blk No. :
                                                </td>
                                                <td class="column_Left">
                                                   <asp:TextBox ID="txtBlkNo" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    Subdivision :
                                                </td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="txtSubdivision" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    Sitio :
                                                </td>
                                                <td  class="column_Left" >
                                                    <asp:TextBox ID="txtSitio" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                               
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width:12%">
                                                    Brgy:
                                                </td>
                                                <td class="column_Left">
                                                   <asp:TextBox ID="txtBrgy" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    City/Mun. :
                                                </td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="txtCityMun" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    Region :
                                                </td>
                                                <td  class="column_Left" >
                                                    <asp:TextBox ID="TxtRegion" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width:12%">
                                                    District:
                                                </td>
                                                <td class="column_Left">
                                                   <asp:TextBox ID="txtDistrict" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    Province :
                                                </td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="txtProvince" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    Zip Code :
                                                </td>
                                                <td  class="column_Left" >
                                                    <asp:TextBox ID="txtZipCode" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td  colspan="7"style="border:2px solid #5c85d6" >
                                <table width="100%">
                                     <tr>
                                         <td align="center" colspan="8" class="DivTitle" style="width: 100%">CHARACTERISTICS</td>
                                     </tr>
                                      <tr>
                                                <td class="column_RightBold" style="width:12%">
                                                   Classification :
                                                </td>
                                                <td class="column_Left">
                                                   <asp:TextBox ID="txtClassification" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    Sub Class :
                                                </td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="txtSubClass" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    Land Use :
                                                </td>
                                                <td  class="column_Left" >
                                                    <asp:TextBox ID="txtLandUse" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%; display:none">
                                                   Status :
                                                </td>
                                                <td  class="column_Left"  style="display:none">
                                                    <asp:TextBox ID="txtStatus" runat="server" Width="89%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                            </tr>
                                      <tr>
                                                <td class="column_RightBold" style="width:12%">
                                                   Taxable :
                                                </td>
                                                <td class="column_Left">
                                                   <asp:TextBox ID="txtTaxable" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    Area :
                                                </td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="txtSubClassArea" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                 </td>
                                                <td  class="column_Left" >
                                                 </td>
                                                <td class="column_RightBold" style="width:12%; display:none">
                                                   Status :
                                                </td>
                                                <td  class="column_Left"  style="display:none">
                                                    <asp:TextBox ID="TxtStatus1" runat="server" Width="89%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                            </tr>
                                    <tr>
                                        <td colspan ="8">&nbsp;</td>
                                    </tr>
                                      <tr>
                                                <td class="column_RightBold" style="width:12%">
                                                   Assessed Value :
                                                </td>
                                                <td class="column_Left">
                                                   <asp:TextBox ID="txtAssessedValue" runat="server" Width="95%"   CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    Market Value :
                                                </td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="txtCharacteristicsMarketValue" runat="server" Width="95%"   CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                   Unit Value :
                                                </td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="txtUnitValue" runat="server" Width="89%"   CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);" ></asp:TextBox>
                                                </td>
                                            </tr>
                                     <tr>
                                                <td class="column_RightBold" style="width:12%">
                                                   Date :
                                                </td>
                                                <td class="column_Left">
                                                   <asp:TextBox ID="txtAssessedValueDate" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="txtAssessedValueDate" TargetControlID="txtAssessedValueDate">
                                                    </cc1:CalendarExtender>
                                                    
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    Date :
                                                </td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="txtMarketValueDate" runat="server" Width="95%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="txtMarketValueDate" TargetControlID="txtMarketValueDate">
                                                    </cc1:CalendarExtender>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                   Date :
                                                </td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="txtUnitValueDate" runat="server" Width="89%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" PopupButtonID="txtUnitValueDate" TargetControlID="txtUnitValueDate">
                                                    </cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                     <tr>
                                                <td class="column_RightBold" style="width:12%">
                                                   Amount :
                                                </td>
                                                <td class="column_Left">
                                                   <asp:TextBox ID="txtAssessedValueAmount" runat="server" Width="95%"   CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                    Amount :
                                                </td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="txtMarketValueAmount" runat="server" Width="95%"   CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                </td>
                                                <td class="column_RightBold" style="width:12%">
                                                   Assessment :
                                                </td>
                                                <td  class="column_Left">
                                                    <asp:TextBox ID="TextBox3" runat="server" Width="89%"   CssClass="txtbox_Var" ></asp:TextBox>
                                                </td>
                                            </tr>
                                </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" align="right" >
                           <asp:Button ID="btnLandSave" OnClick="btnLandSave_Click" runat="server" Width="120px" OnClientClick="StartProgressBar();" Text="SAVE" CssClass="CSButton"></asp:Button>
                            <asp:Button ID="btnLandCancel" runat="server" Width="120px" OnClientClick="StartProgressBar();" Text="CANCEL" CssClass="CSButton" ></asp:Button>
                              </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <br />
                              <asp:GridView ID="grdLedger1" runat="server" Width="100%" SkinID="GridViewAA" HorizontalAlign="Center" Font-Size="8pt" OnDataBound = "OnDataBound" >
                                                        
                                                        <Columns>
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
                                                            <asp:BoundField DataField="BalanceUnit" HeaderText="Ref No."  Visible="false">
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

