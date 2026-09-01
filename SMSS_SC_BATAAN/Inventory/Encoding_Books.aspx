<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Encoding_Books.aspx.vb" Inherits="Inventory_Encoding_Books" 
      StylesheetTheme="SkinFile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">



</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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

    </script>
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
            document.getElementById("ctl00_ContentPlaceHolder1_txtNoYears").value = age;}
       
 }
   
    // function getDepValRate(Integer) {
    //     var year =  document.getElementById('ctl00_ContentPlaceHolder1_txtNoYears').value;
    //     var UL =  document.getElementById('ctl00_ContentPlaceHolder1_txtbookUsefulLife').value;

    //     var depval = ((year / UL) * 100)
          
    //     if (depval > 100) {
    //         depval = 100
    //     }

    //     document.getElementById("ctl00_ContentPlaceHolder1_txtbookdepreciatedRate").value = depval;

    //    //Depreciation
    //    var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtbookAcqCost").value;
    //    AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
    //    AcquisationCostVal = parseInt(AcquisationCostVal, 10);
    //    var Salvagevalue = document.getElementById('ctl00_ContentPlaceHolder1_txtbookSalvageValue').value;
    //    Salvagevalue = Salvagevalue.replace(/\,/g, '');
    //    Salvagevalue = parseInt(Salvagevalue, 10);

    //    var Depreciation = 0.00;
    //    if (AcquisationCostVal > 0 && Salvagevalue > 0 && UL > 0) {
    //        Depreciation = (AcquisationCostVal - Salvagevalue) / UL
    //    }

    //     document.getElementById("ctl00_ContentPlaceHolder1_txtBookDepreciation").value = (Depreciation).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

    //    //End Depreciation

    //    //Depreciated
    //    var DepreciatedtVal = document.getElementById("ctl00_ContentPlaceHolder1_txtBookDepreciation").value;
    //    DepreciatedtVal = DepreciatedtVal.replace(/\,/g, '');
    //    DepreciatedtVal = parseInt(DepreciatedtVal, 10);
    //    var DepreciatedValue = 0.00;
    //     if (DepreciatedtVal > 0) {
    //         DepreciatedValue = AcquisationCostVal - (DepreciatedtVal * year);
    //     }
        
    //    document.getElementById("ctl00_ContentPlaceHolder1_txtbookdepreciatedvalue").value = (DepreciatedValue).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    //    //End Depreciated

    //}
   //Optimize code
    function getDepValRate(Integer) {
  const noYears = document.getElementById('ctl00_ContentPlaceHolder1_txtNoYears');
  const bookUsefulLife = document.getElementById('ctl00_ContentPlaceHolder1_txtbookUsefulLife');
  const bookAcqCost = document.getElementById('ctl00_ContentPlaceHolder1_txtbookAcqCost');
  const bookSalvageValue = document.getElementById('ctl00_ContentPlaceHolder1_txtbookSalvageValue');
  const bookDepreciatedRate = document.getElementById('ctl00_ContentPlaceHolder1_txtbookdepreciatedRate');
  const bookDepreciation = document.getElementById('ctl00_ContentPlaceHolder1_txtBookDepreciation');
  const bookDepreciatedValue = document.getElementById('ctl00_ContentPlaceHolder1_txtbookdepreciatedvalue');

  const year = noYears.value;
  const UL = bookUsefulLife.value;
  const AcquisationCostVal = Number(bookAcqCost.value.replace(/,/g, ''));
  const Salvagevalue = Number(bookSalvageValue.value.replace(/,/g, ''));

  let depval = ((year / UL) * 100);
  if (depval > 100) {
    depval = 100;
  }
  bookDepreciatedRate.value = depval;

  let Depreciation = 0.00;
  if (AcquisationCostVal > 0 && Salvagevalue > 0 && UL > 0) {
    Depreciation = (AcquisationCostVal - Salvagevalue) / UL;
  }
  bookDepreciation.value = Depreciation.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

  const DepreciatedtVal = Number(bookDepreciation.value.replace(/,/g, ''));
  let DepreciatedValue = 0.00;
  if (DepreciatedtVal > 0) {
    DepreciatedValue = AcquisationCostVal - (DepreciatedtVal * year);
  }
  bookDepreciatedValue.value = DepreciatedValue.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
}

    function getSalVal(Double) {
        var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtbookAcqCost").value;
        AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
        AcquisationCostVal = parseInt(AcquisationCostVal, 10);
        var SalvageVal = AcquisationCostVal * 0.05

        document.getElementById("ctl00_ContentPlaceHolder1_txtbookSalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
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
                                <asp:Label ID="lblClass" runat="server" Text="Encoding of Books"></asp:Label>
                            </strong>
                        </td>
                    </tr>

                     <tr>
                         <td>

                          <table>
                            <!-- keep the row hidden if you want, but the control must still exist -->
                                <tr style="display:none;">
                                  <td class="column_RightBold">Classification : </td>
                                  <td>
                                    <asp:DropDownList ID="ddClass" runat="server"
                                        CssClass="drpdownCSS" Width="200px"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddClass_SelectedIndexChanged" />
                                  </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">&nbsp;
                                        <span class="required-label">General Account :</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddGA"
                                            runat="server"
                                            CssClass="drpdownCSS"
                                            Width="200px"
                                            AutoPostBack="True"
                                            OnSelectedIndexChanged="ddGA_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>

                                    <td style="width:20px;"></td>

                                    <td class="column_RightBold">
                                        <span>Sub Classification :</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddSubClass"
                                            runat="server"
                                            CssClass="drpdownCSS"
                                            Width="200px"
                                            AutoPostBack="True"
                                            OnSelectedIndexChanged="ddSubClass_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                           

                        </table>
                              </td>
                     </tr>
                      <tr>
                        <td align="center" style="width: 100%"><asp:HiddenField ID="hdnItemNo" runat="server" /><asp:HiddenField ID="hdnGAId" runat="server" /></td>
                    </tr>
                     <tr>
                        <td align="center" class="DivTitle" style="width: 100%"><asp:Label ID="lblSubClass" runat="server" Text="BOOKS INFORMATION"></asp:Label>

                        </td>
                    </tr>
                       <tr>
                                     <td align="center" style="width: 100%">

                              <table style="width: 100%;">
                                <tr>
                                    <td class="column_RightBold" style="width: 12%">
                                        <span class="required-label">Name :</span>

                                    </td>
                                    <td class="column_Left" style="width: 30%">

                                        <asp:Label ID="lblbookname" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="drpbookName"   CssClass="drpdownCSS" runat="server" Width="91%" OnSelectedIndexChanged="drpbookName_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                                                          
                                        <asp:TextBox ID="txtbookName" runat="server" Width="89%" CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold" style="width: 10%"><span class="required-label">Unit :</span></td>
                                    <td class="column_Left" style="width: 30%">

                                        <asp:Label ID="Label4" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="drpbookUnit"  runat="server" Width="100px" CssClass="drpdownCSS" Enabled="false"  ></asp:DropDownList>&nbsp; &nbsp;


                                                                   <span class="column_RightBold required-label">Quantity :</span>
                                                                    <asp:TextBox ID="txtbookQuantity" AutoPostBack="true"  runat="server" Width="100px" CssClass="txtbox_Var"  ></asp:TextBox>
                                                                
                                        <asp:TextBox ID="TextBox1" runat="server" Width="89%" CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                    </td>
                                    <td align="center" rowspan="6" style="width: 20%" valign="middle" >
                                        <asp:Image ID="Image3" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                        <br />
                                               <asp:Button ID="btnbookupload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false" OnClientClick="StartProgressBar();"></asp:Button>
                                
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 12%"><span class="required-label">Description :</span></td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblbookdesciption" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtbookdesciption"  AutoPostBack="true" runat="server" Width="89%"  CssClass="txtbox_Var"  ></asp:TextBox>

                                    </td>
                                      <td class="column_RightBold" style="width: 10%">Price :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblbookwaranty" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtBookPrice" AutoPostBack="true"  runat="server" Width="25%"  CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 12%">Classification :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                              <asp:TextBox ID="txtBookClassification"  AutoPostBack="true" runat="server" Width="60%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                   
                                                                    <asp:TextBox ID="txtBookClassificationCode"  AutoPostBack="true" runat="server" Width="25%" CssClass="txtbox_Var" ></asp:TextBox>
                                             
                                    </td>
                                     <td class="column_RightBold">
                                                                  ISBN :
                                                              </td>
                                                              <td class="column_Left">
                                                                  <asp:TextBox ID="txtBookISBN"  AutoPostBack="true" runat="server"  Width="89%"  CssClass="txtbox_Var" ></asp:TextBox>
                                              
                                                              </td>
                                   
                                </tr>
                                <tr>
                                     <td class="column_RightBold" style="width: 12%">Title :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:TextBox ID="txtbookTitle"  AutoPostBack="true" runat="server" Width="89%"  CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                  
                                    <td class="column_RightBold" style="width: 10%">Author :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:TextBox ID="txtbookAuthor"  AutoPostBack="true" runat="server" Width="89%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                   
                                </tr>

                               <tr>
                                    <td class="column_RightBold" style="width: 12%">Publication Date :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:TextBox ID="txtBookPublicationDate" runat="server" CssClass="txtbox_Var"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtBookPublicationDate" PopupButtonID="txtBookPublicationDate"></cc1:CalendarExtender>
                                    </td>

                                    <td class="column_RightBold" style="width: 12%">Remarks :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:TextBox ID="txtRemarks"  AutoPostBack="true" runat="server" Width="89%" CssClass="txtbox_Var"
                                            TextMode="MultiLine" Rows="3"></asp:TextBox>
                                    </td>
                                </tr>



                                <tr>
                                    <td class="column_RightBold" style="width: 12%">
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                   
                                        </td>
                                    <td>

                                    </td>
                                    <td class="column_Left" >
                                        <asp:linkbutton ID="btnaddpropertyinfo" runat="server"   OnClick="btnaddpropertyinfo_Click" > <span class="required-label">Add Property Information </span> </asp:linkbutton>
                                  
                                   </td>
                                   


                                </tr>
                                <tr style="display:none">
                                     <td class="column_RightBold" style="width: 12%;">Area Capacity :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblbookareacapacity" runat="server" Width="291px" SkinID="Label" Font-Italic="False" Visible="False"></asp:Label>
                                        <asp:TextBox ID="txtbookareacapacity" AutoPostBack="true"  runat="server" Width="89%"  CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                               </tr>
                                <tr>
                                    <td colspan ="4">
                                        <fieldset style="width:90%;">
                                            <legend class="column_LeftBold">Acquisition :</legend>
                                        <table >
 <tr>
                                     <td  class="column_RightBold" style="width: 115px"><span class="required-label">Acquisition Date :</span></td>
                                    <td class="column_Left" style="width:100px;">
                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtbookAcqDate"  AutoPostBack="true" runat="server" CssClass="txtbox_Var"  ></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtbookAcqDate" PopupButtonID="txtbookAcqDate"></cc1:CalendarExtender>


                                        &nbsp;(MM/DD/YYYY)</td>
                                   <td class="column_RightBold" >Market Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtbookMarketValue" AutoPostBack="true"  runat="server" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>

                                    </td>
                                    
                                    
                                </tr>
                                <tr>
                                    
                                    <td class="column_RightBold" style="width: 115px" ><span class="required-label">Acquisition Cost :</span></td>
                                    <td class="column_Left" >
                                        <asp:Label ID="Label2" runat="server" ></asp:Label>
                                        <asp:TextBox ID="txtbookAcqCost" AutoPostBack="true"  runat="server" CssClass="txtboxAmount" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalVal(this),getDepValRate(this);"  ></asp:TextBox>
                                    </td>
                                    
                                    <td class="column_RightBold" >No. of Years :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="lblNoYears" runat="server" ></asp:Label>
                                        <asp:TextBox ID="txtNoYears" AutoPostBack="true"  runat="server"  CssClass="txtbox_Var" onchange="return getDepValRate(this)" ></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    
                                    <td class="column_RightBold" style="width: 115px">Depreciated Rate :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtbookdepreciatedRate" AutoPostBack="true"  runat="server" Width="100px"  CssClass="txtbox_Var" MaxLength="5" ></asp:TextBox>&nbsp;(%) Percent</td>

                                    
                                    <td class="column_RightBold">Useful Life :
                                    </td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblUsefulLife" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtbookUsefulLife" AutoPostBack="true" Enabled="false"  runat="server" Width="100px"  CssClass="txtbox_Var" onchange="return getDepValRate(this);"></asp:TextBox>

                                        &nbsp;(Years)</td>

                                </tr>


                                <tr>
                                    
                                    <td class="column_RightBold" style="width: 115px" >Depreciated Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="lblbookdepreciatedvalue" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtbookdepreciatedvalue" AutoPostBack="true"  runat="server" Width="100px" CssClass="txtboxAmount" Onkeypress="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                    </td>
                                    
                                   <td class="column_RightBold">Salvage Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:TextBox ID="txtbookSalvageValue" AutoPostBack="true" runat="server" Width="85%" CssClass="txtboxAmount" Onkeypress="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox></td>


                                </tr>
                                            <tr>
                                                 <td class="column_RightBold" style="width: 115px">Depreciation Value :</td>
                                                 <td class="column_Left">
                                                     <asp:TextBox ID="txtBookDepreciation"  AutoPostBack="true" runat="server" CssClass="txtboxAmount" Onchange="this.value=formatCurrency(this.value);" Onkeypress="javascript:this.value=Comma(this.value);" Width="100px"></asp:TextBox>
                                                     (Per Year)</td>
                                                 <td>&nbsp;</td>
                                                 <td>&nbsp;</td>
                                            </tr>
                               
                                        </table>
                                        </fieldset>
                                    </td>
                                </tr>
                                <tr >
                                                        <td colspan="4" >
                                                             <fieldset style="width:93%;">
                                                                 <legend  class="column_Left" style =" font-family:Arial; color:#404040;"><strong>Location:</strong></legend>
                                                                 <table width="100%">
                                                                     <tr>
                                                                         <td class="column_RightBold" >Department/Warehouse :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:DropDownList ID="drpbookWarehouse" runat="server" Width="98%"  CssClass="drpdownCSS"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Bay :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtbookBay" AutoPostBack="true"  runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList2" runat="server" Width="100%"  CssClass="drpdownCSS" Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:15%">Column :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                 <asp:TextBox ID="txtbookColumn"  AutoPostBack="true" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList3" runat="server" Width="100%"  CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Floor :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                <asp:TextBox ID="txtbookFloor" AutoPostBack="true" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList4" runat="server" Width="100%"  CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                     </tr>
                                                                     <tr>
                                                                         <td class="column_RightBold">Room :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtbookRoom" AutoPostBack="true"  runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList5" runat="server" Width="100%"  CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Shelves :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtbookShelves" AutoPostBack="true"  runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList6" runat="server" Width="100%"  CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Rack :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtbookRack" AutoPostBack="true"  runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList7" runat="server" Width="100%"  CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                         
                                                                         <td class="column_RightBold">Bin :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtbookBin"  AutoPostBack="true" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             <asp:DropDownList ID="DropDownList8" runat="server" Width="100%" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                     </tr>
                                                                    
                                                                 </table>
                                                             </fieldset>
                                                        </td>
                                                    </tr>
                                <tr style="display:none">
                                    <td class="column_RightBold" style="width: 12%">Specifications :
                                    </td>
                                    <td class="column_Left" colspan="3">
                                        <asp:Label ID="lblSpecification" runat="server" CssClass="text3"></asp:Label>
                                        <asp:TextBox ID="txtSpecification" AutoPostBack="true"  runat="server" Width="95%" Height="25px" TextMode="MultiLine"  CssClass="txtbox_Var" Rows="2"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 12%">&nbsp;</td>
                                    <td class="column_RightBold" colspan="3">
                                        <asp:HiddenField ID="hf_EquipInfoId" runat="server"/>
                                        <asp:HiddenField ID="hf_EquipmentId" runat="server"/>
                                        <asp:HiddenField ID="hf_PropertyDetai_ID" runat="server"/>
                                        <asp:HiddenField ID="hf_Property_ID" runat="server"/>
                                        <asp:HiddenField ID="hf_Item_ID" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" Width="48%" CssClass="CSButton" Text="SAVE" Enabled="false"  OnClick="btnSave_Click"></asp:Button>
                                        <asp:Button ID="btnCancel" runat="server" Width="48%" CssClass="CSButton" Text="CANCEL" Enabled="false" OnClientClick="StartProgressBar();"></asp:Button>
                                    </td>
                                </tr>
                            </table>

                        </td>
                         
                     </tr>
                      <tr>
                                            <td align="center" colspan="4">
                                                <asp:Panel ID="Panel1" runat="server" CssClass="PanelSize" ScrollBars="Vertical"
                                                    Width="100%">
                                                    <asp:GridView ID="grdLedger1" runat="server" Width="100%" SkinID="GridViewAA" HorizontalAlign="Center" Font-Size="8pt" OnDataBound = "OnDataBound" OnRowDataBound="grdLedger1_RowDataBound">
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
                                                            <asp:BoundField DataField="ref" HeaderText="Ref No" >
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
                                                            <asp:BoundField DataField="BalanceUnit" HeaderText="Unit"  Visible="false">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="UnitPrice" DataFormatString="{0:N}" HeaderText="Unit Price"  Visible="false">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="DebitQty" HeaderText="Debit Qty"  Visible="false">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText="Debit Cost">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CreditQty" HeaderText="Credit Qty"  Visible="false">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText="Credit Cost">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BalQty" HeaderText="Bal Qty"  Visible="false">
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
                 </table>

        </div>
              <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="Loading..." src="../images/ajax-loader.gif" />
            </asp:Panel>

             <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
         <asp:Button Style="display: none; border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>

                  <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label3" PopupControlID="popupParticular" CancelControlID="ImageButton2" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
              <asp:Panel ID="popupParticular" runat="server" CssClass="Panel_Popup" Width ="">
                  <table width="100%">
                      <tr>
                         <td style="width: 100%; height: 30px"  class="DivTitle">
                             PROPERTY INFORMATION
                          </td>
                      </tr>
                      <tr>      
                          <td>
                           <asp:GridView ID="grdPropertyInfo" runat="server" SkinID="gvnew" AutoGenerateColumns="false"
                            EmptyDataText="No records has been added."  Width="300px" OnRowDataBound="grdPropertyInfo_RowDataBound"
                                onkeydown="return preventPropertyInfoEnter(event);">
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
                                    <asp:TemplateField ItemStyle-Width ="19%" HeaderText="Floor Location"   Visible="false">
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtPIFloorLocation" runat ="server"  Width ="100px" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width ="50%" HeaderText="Room"   Visible="false">
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtPIRoom" runat ="server"  Width ="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  </Columns>
                            </asp:GridView>

                              </gridview>
                            </td>
                          
                      </tr>
                      
                      <tr>
                          <td >
                                <asp:Button ID="btnProceedEdit"  runat="server" Width="150px" CssClass="CSButton" Text="PROCEED" OnClick="btnProceedEdit_Click" ></asp:Button><%-- OnClick="btnProceedEdit_Click"--%>
                    
                        <asp:Button ID="btnAuthCancel"  runat="server" Width="150px" CssClass="CSButton" Text="CANCEL"></asp:Button>
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
            <asp:Panel ID="Panel2" runat="server" Width="350px" CssClass="Panel_Popup"  DefaultButton="Button4">
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
                    
                                <asp:Button ID="Button5" OnClick="Button5_Click"  runat="server" Width="150px" CssClass="CSButton"    CausesValidation="False" Text="CANCEL"></asp:Button>
                    </td>
                      </tr>
                  </table>
                  
                  </asp:Panel>

        </ContentTemplate>
  
 </asp:UpdatePanel> 
    
</asp:Content>

