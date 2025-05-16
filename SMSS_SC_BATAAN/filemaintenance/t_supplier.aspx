<%@ Page 
    Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="t_supplier.aspx.vb" 
    Inherits="t_supplier" 
    StylesheetTheme="SkinFile" 
    Title="FM SUPPLIER / BIDDER" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">



</script>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

    function getAge(dateString) {
    var today = new Date();
    var birthDate = new Date(dateString);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
        }
        
        if (age <= 0) {
            alert("Invalid Birthdate")

        }
        else { 
            document.getElementById("ctl00_ContentPlaceHolder1_CAge").value = age;}
       
 }
     

   
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=Image2.ClientID%>').prop('src', e.target.result)
                        .width(240)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }


function myFunction(String) {
  var gender = this.value; // Getting the current selected value
  if (gender == 'male') {
    document.getElementById("printGender").value = "ctl00_ContentPlaceHolder1_cGender";
  } else if (gender == 'female') {
    document.getElementById("printGender").value = "ctl00_ContentPlaceHolder1_cGender";
  }
};




        //JAVA SCRIPT FOR IMAGE UPLOADING OF CONTACT PERSON
  



        function ShowImagePreviewContact(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=Image1.ClientID%>').prop('src', e.target.result)
                        .width(240)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }


         function ShowImageOwner(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=Image3.ClientID%>').prop('src', e.target.result)
                        .width(240)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }


</script>
     <style type="text/css">
      .hiddencol { display: none; }
        .auto-style1 {
            text-align: right;
            font-size: 9pt;
            font-family: Arial;
            font-weight: bold;
            color: #404040;
            padding: 0px;
            width: 15%;
            height: 13px;
        }
        .auto-style2 {
            text-align: left;
            font-size: 9pt;
            font-family: Arial;
            padding: 0px;
            width: 35%;
            height: 13px;
        }
        .auto-style3 {
            text-align: center;
            font-size: 9pt;
            font-family: Arial;
            vertical-align: middle;
            text-transform: uppercase;
            font-weight: bold;
            color: #0033cc;
            padding: 0px;
        }
         .auto-style5 {
             height: 20px;
             width: 84%;
         }
         .auto-style6 {
             height: 100px;
             width: 84%;
         }
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
        <asp:PostBackTrigger ControlID="btnsave" />
        </Triggers>
        <ContentTemplate>
            <table style="width: 1010px">
                <tr>
                    <td style="width: 10px"></td>
                    <td align="center" style="width: 1000px"></td>
                </tr>
                <tr>
                    <td style="width: 10px"></td>
                    <td align="center" class="PageTitle" style="width: 1000px">SUPPLIERS</td>
                </tr>
                <tr>
                    <td style="width: 10px"></td>
                    <td align="center" style="width: 1000px"></td>
                </tr>
                <tr>
                    <td style="width: 10px"></td>
                    <td align="center" style="width: 1000px">
                        <table style="width: 100%">
                            <tr>
                               <td align="center" class="DivTitle" style="width: 100%; height: 23px;">COMPANY LIST</td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 1000px"><span style="font-size: 9pt; font-family: Arial"><strong>Search Company Name :</strong></span>
                                    <asp:TextBox ID="txtsearch" runat="server" CssClass="txtboxinspection" Width="200px"></asp:TextBox>
                                    <asp:Button ID="Button3" CssClass="CSButton" runat="server" OnClientClick="StartProgressBar();" Text="SEARCH" Width="200px" />
                                </td>
                            </tr>
                            <tr>
                               
                                <td style="border-right: royalblue 1px solid; border-top: royalblue 1px solid; vertical-align: top; border-left: royalblue 1px solid; width: 50%; border-bottom: royalblue 1px solid; height: 168px">
                                    <asp:GridView ID="gvbody" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Supplier_Id,SuppName,Address1,ContactP,Officeno,Faxno,TIN,Address2,contactno,TaxType,EmailAddress,Position,CBdate,CAge,CGender,CNationality,FullnameOwner,AddressOwner,MobileNoOwner,EmailAddressOwner" EmptyDataText="No Data Found." Font-Size="9pt" PageSize="5" SkinID="GridViewAA" Style="text-align: justify" Width="100%">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" />
                                            <asp:BoundField DataField="SUPPNAME" HeaderText="COMPANY NAME">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ADDRESS1" HeaderText="COMPANY ADDRESS">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="officeno" HeaderText="TELEPHONE NO.">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TIN" HeaderText="TIN" Visible="False">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CONTACTP" HeaderText="OWNERS NAME">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                           
                        </table>
                         <table width="100%">
                            <tr>
                                <td style="width: 10px; height: 23px;">
                                </td>
                                
                               <td style="font-weight: bold; font-size: 9pt; width: 50%; font-family: Arial; height: 20px; background-color: lightgrey; text-align: center">COMPANY PROFILE</td>
                                <td style="font-weight: bold; font-size: 9pt; width: 50%; font-family: Arial; height: 20px; background-color: lightgrey; text-align: center">ACCREDITATION</td>
                                
                            </tr>
                           
                           
                            <tr>
                                <td style="width: 10px"></td>
                                
                                   <td style="border: 1px solid royalblue; vertical-align: top; width: 56%; height: 250px">
                                    <table style="width: 99%; margin-right: 0px;">
                                        <tbody>
                                            <tr>
                                                <td style="width: 56px" class="column_RightBold">Company Name: </td>
                                                <td style="width: 108%" class="text5">
                                                    <asp:TextBox ID="txtcompany" runat="server" Width="98%" ReadOnly="True" CssClass="txtboxinspection"></asp:TextBox></td>
                                                <td style="width: 25px" align="center">
                                            <asp:Image ID="Image2" runat="server" Height="116px" ImageUrl="~/images/noPicture.jpg" Width="151px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 56px; height: 42px;" class="column_RightBold">Address: </td>
                                                <td style="width: 108%; height: 42px;" class="text5">
                                                    <asp:TextBox ID="txtadd1" runat="server" Width="98%" ReadOnly="True" CssClass="txtboxinspection" TextMode="MultiLine" Height="40px"></asp:TextBox></td>
                                                <td style="height: 42px; width: 148px;">
                                                 <asp:FileUpload type="file" onchange="return ShowImagePreview(this)" ID="FileUpload1" Enabled="false" runat="server" Width="88px" />
                                                    
                                                    <asp:Label ID="lblNoti" runat="server" Font-Names="Calibri" Font-Size="9pt" ForeColor="Red" Text="* No file to upload." Visible="False"></asp:Label>
                                                 
                                                    <asp:TextBox ID="Attched" runat="server" Visible="false"></asp:TextBox>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="width: 56px" class="column_RightBold">Tel. Number: </td>
                                                <td style="width: 108%" class="text5">
                                                    <asp:TextBox ID="txtofficeno" runat="server" Width="70%" ReadOnly="True" CssClass="txtboxinspection"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 56px" class="column_RightBold">Fax Number: </td>
                                                <td style="width: 108%" class="text5">
                                                    <asp:TextBox ID="txtfaxno" runat="server" Width="70%" ReadOnly="True" CssClass="txtboxinspection"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 56px" class="column_RightBold">Tax Type:</td>
                                                <td style="width: 108%" class="text5">
                                                    <asp:DropDownList ID="ddtax" runat="server" Width="40%" CssClass="txtboxinspection">
                                                        <asp:ListItem>VAT</asp:ListItem>
                                                        <asp:ListItem>NONE VAT</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 56px" class="column_RightBold">T.I.N. : </td>
                                                <td style="width: 108%" class="text5">
                                                    <asp:TextBox ID="txttin" runat="server" Width="70%" CssClass="txtboxinspection"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 56px" class="column_RightBold">Product &amp;Services:</td>
                                                <td style="width: 108%" class="text5">
                                                    <asp:TextBox ID="txtPS" runat="server" Width="98%" CssClass="txtboxinspection" TextMode="MultiLine" Height="40px" style="margin-left: 0px"></asp:TextBox></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td style="border-right: royalblue 1px solid; border-top: royalblue 1px solid; vertical-align: top; border-left: royalblue 1px solid; width: 50%; border-bottom: royalblue 1px solid; height: 250px">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Accreditation No. :</td>
                                                <td style="width: 75%" class="text5">
                                                    <asp:TextBox ID="txtAccNo" runat="server" Width="98%" ReadOnly="True" CssClass="txtboxinspection"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Date : </td>
                                                <td style="width: 75%" class="text5">
                                                    <asp:TextBox ID="txtAccDate" runat="server" Width="40%" ReadOnly="True" CssClass="txtboxdate" ></asp:TextBox>
                                                    &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" Width="18px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton>
                                                </td>
                                                 
                                               <td> <cc1:CalendarExtender ID="CalendarExtender5" runat="server" PopupButtonID="ImageButton2" Enabled="True" TargetControlID="txtAccDate"></cc1:CalendarExtender></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Valid Until :</td>
                                                <td style="width: 75%" class="text5">
                                                    <asp:TextBox ID="txtAccUntil"  runat="server" Width="40%" ReadOnly="True" CssClass="txtboxinspection" ></asp:TextBox>
                                                 &nbsp;<asp:ImageButton ID="ImageButton4" runat="server" Width="18px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton></td>
                                                <td> <cc1:CalendarExtender ID="CalendarExtender7" runat="server" PopupButtonID="ImageButton4" Enabled="True" TargetControlID="txtAccUntil"></cc1:CalendarExtender></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Approved by : </td>
                                                <td style="width: 75%" class="text5">
                                                    <asp:TextBox ID="txtAccApprovedBy" runat="server" Width="98%" ReadOnly="True" CssClass="txtboxinspection"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">MOA : </td>
                                                <td style="width: 75%" class="text5">
                                                    <asp:TextBox Style="position: relative" ID="txtMOA" runat="server" Width="98%" ReadOnly="True" CssClass="txtboxinspection"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold"></td>
                                                <td style="width: 75%" class="text5"></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                

                                </td>
                                
                            </tr>
                           </table>
                        <table style="width:100%" >
                           <tr>
                              <td style="font-weight: bold; font-size: 9pt; font-family: Arial; background-color: lightgrey; text-align: CENTER" class="auto-style5">OWNSER'S PROFILE</td>
                              <td style="font-weight: bold; font-size: 9pt; width: 20%; font-family: Arial; height: 20px; background-color: lightgrey; text-align: CENTER">OWNSER'S IMAGE</td>
                           </tr>
                            <tr>
                                <td style="border: 1px solid royalblue; vertical-align: top; " class="auto-style6">
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="column_RightBold">Owner's Name :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtOwner_Name" runat="server" CssClass="txtbox_Var" Enabled="false"></asp:TextBox></td>
                                            <td class="column_RightBold">&nbsp;Contact No. : </td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtContactOwner_ContactNo" runat="server" CssClass="txtbox_Var" Enabled="false"></asp:TextBox></td>
                                        </tr>
                                         <tr>
                                            <td class="column_RightBold">Owner&#39;s Address :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtOwner_Addresss" runat="server" CssClass="txtbox_Var" TextMode="MultiLine" Enabled="false"></asp:TextBox></td>
                                            <td class="column_RightBold">Email Address :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtOwner_EmailAddress" runat="server" CssClass="txtbox_Var" Enabled="false"></asp:TextBox></td>
                                                <asp:HiddenField ID="hndFileOwner" runat="server" />
                                             </tr>
                                    </table>
                                </td>
                                 <td align="center" style="border-right: royalblue 1px solid; border-top: royalblue 1px solid; vertical-align: top; border-left: royalblue 1px solid; width: 25%; border-bottom: royalblue 1px solid; height: 150PX">
                                 
                                    <table style="width:100px">
                                        <tbody>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Image ID="Image3" runat="server" Height="150PX" ImageUrl="~/images/noPicture.jpg" Width="150PX" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:FileUpload type="file" ID="FileUpload3" onchange="return ShowImageOwner(this)" align="right" runat="server" Enabled="false" Width="89px" style="margin-left: 30px" />
                                                    </td>
                                                </tr>
                                        </tbody>
                                    </table>
                                
                                </td>
                            </tr>
                           
                        </table>
                        <table style="width: 100%">
                                                   <tr>
                                                       <td style="font-weight: bold; font-size: 9pt; width: 85%; font-family: Arial; height: 20px; background-color: lightgrey; text-align: CENTER">CONTACT PERSON</td>
                                                       <td style="font-weight: bold; font-size: 9pt; width: 15%; font-family: Arial; height: 20px; background-color: lightgrey; text-align: CENTER">CONTACT IMAGE</td>
                                                   </tr>
                                                   <tr>
                                                       <td style="border: 1px solid royalblue; vertical-align: top; width: 12%; height: 100px">
                                                           <table style="width: 100%">
                                                               <tbody>
                                                                   <tr>
                                                                       <td class="column_RightBold" style="width: 10%">Full Name : </td>
                                                                       <td class="text5" style="width: 25%">
                                                                           <asp:TextBox ID="cFullName" runat="server" CssClass="txtboxinspection"  Width="77%"></asp:TextBox>
                                                                       </td>
                                                                        <td class="column_RightBold" style="width: 10%">&nbsp; Birth Date:
                                                                           
                                                                        </td>
                                                                        
                                                                       <td class="text5" style="width: 25%">
                                                                           <asp:TextBox ID="CBdate" runat="server" onchange="return getAge(this.value);" CssClass="txtboxinspection" ReadOnly="True" Width="71%" Height="26px" > </asp:TextBox>
                                                                            &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" Width="18px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton>
                                                                       </td>
                                                                        <cc1:calendarextender ID="CalendarExtender6" runat="server" PopupButtonID="ImageButton3" Enabled="True" TargetControlID="CBdate"></cc1:calendarextender>
                                                                   </tr>
                                                                   <tr>
                                                                       <td class="column_RightBold" style="width: 10%; height: 25px;">Address : </td>
                                                                       <td class="text5" style="width: 25%; height: 25px;">
                                                                           <asp:TextBox ID="cAddress" runat="server" CssClass="txtboxinspection" Height="53px" ReadOnly="True" TextMode="MultiLine" Width="77%"></asp:TextBox>
                                                                       </td>
                                                                       <td class="column_RightBold" style="width: 10%; height: 15px;">Age : </td>
                                                                       <td class="text5" style="width: 25%; height: 5px;">
                                                                           <asp:TextBox ID="CAge" runat="server" CssClass="txtboxinspection" Height="25px" ReadOnly="True"  Width="26%"></asp:TextBox>
                                                                       </td>
                                                                   </tr>
                                                                    <tr>
                                                                       <td class="column_RightBold" style="width: 10%; height: 26px;">Mobile Number: </td>
                                                                       <td class="text5" style="width: 25%; height: 26px;">
                                                                           <asp:TextBox ID="cMobileNum" runat="server" CssClass="txtboxinspection" Height="18px" ReadOnly="True"  Width="77%"></asp:TextBox>
                                                                       </td>
                                                                       <td class="column_RightBold" style="width: 10%; height: 26px;">Gender : </td>
                                                                       <td class="text5" style="width: 25%; height: 26px;">
                                                                           <asp:DropdownList ID="cGender" runat="server" CssClass="txtboxinspection" onchange="return myFunction(this.value);" Height="23px" ReadOnly="True"    Width="28%">
                                                                               <asp:ListItem Value="0">Select</asp:ListItem>
                                                                               <asp:ListItem Value="1">Male</asp:ListItem>
                                                                               <asp:ListItem Value="2">Female</asp:ListItem>
                                                                           </asp:DropdownList>

                                                                       </td>
                                                                   </tr>
                                                                   <tr>
                                                                       <td class="column_RightBold" style="width: 10%; height: 26px;">Email Address: </td>
                                                                       <td class="text5" style="width: 25%; height: 26px;">
                                                                           <asp:TextBox ID="CEmailAdd" runat="server" CssClass="txtboxinspection" Height="18px" ReadOnly="True"  Width="77%"></asp:TextBox>
                                                                       </td>
                                                                        <td class="column_RightBold" style="width: 10%; height: 26px;">Nationality: </td>
                                                                       <td class="text5" style="width: 25%; height: 26px;">
                                                                           <asp:TextBox ID="cNationality" runat="server" CssClass="txtboxinspection" Height="18px" ReadOnly="True"  Width="71%"></asp:TextBox>
                                                                       </td>
                                                                   </tr>
                                                                   <tr>
                                                                       <td class="column_RightBold" style="width: 10%; height: 26px;">Position: </td>
                                                                       <td class="text5" style="width: 25%; height: 26px;">
                                                                           <asp:TextBox ID="Position" runat="server" CssClass="txtboxinspection" Height="18px" ReadOnly="True"  Width="71%"></asp:TextBox>
                                                                       </td>
                                                                   </tr>
                                                               </tbody>
                                                           </table>
                                                       </td>
                                     <td align="center" style="border-right: royalblue 1px solid; border-top: royalblue 1px solid; vertical-align: top; border-left: royalblue 1px solid; width: 25%; border-bottom: royalblue 1px solid; height: 150PX">
                                        <table style="width: 100%">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:Image ID="Image1" runat="server" Height="150PX" ImageUrl="~/images/noPicture.jpg" Width="150PX" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:FileUpload type="file" ID="FileUpload2" onchange="return ShowImagePreviewContact(this)" align="right" runat="server" Enabled="false" Width="89px" style="margin-left: 30px" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>

                                                   </tr>
                             
                            
                                                   
                             </table>


                          <table style="width: 100%">
                                <tr>
                                <td style="font-weight: bold; font-size: 12pt; width: 100%; font-family: Arial; height: 20px; background-color: lightgrey; text-align: center">BUSINESS DOCUMENTS</td>
                            </tr>
                                
                                <tr>
                                     <td >
                                         <fieldset>
                                             <legend class="column_LeftBold">DTI Registration :</legend>
                                             <table>
                                                 <tr>
                                                     <td style="font-weight: bold; font-size: 9pt; padding-left:5px; font-family: Arial;">DTI Registration No. :
                                                                           <asp:TextBox ID="DTI_RegNo" runat="server"></asp:TextBox></td>

                                                     <td style="font-weight: bold; font-size: 9pt; padding-left:3px; font-family: Arial;">Issued At :
                                                                           <asp:TextBox ID="Iss_DTI" runat="server"></asp:TextBox></td>

                                                     <td style="font-weight: bold; font-size: 9pt;  padding-left:5px;  font-family: Arial;">Date Issued :
                                                                           <asp:TextBox ID="DI_DTI" runat="server"></asp:TextBox></td>
                                                     <td><asp:ImageButton ID="ImageButton10" runat="server" Width="18px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton></td>
                                                     <cc1:calendarextender ID="CalendarExtender10" runat="server" PopupButtonID="ImageButton10" Enabled="True" TargetControlID="DI_DTI"></cc1:calendarextender>
                                                     <td style="font-weight: bold; font-size: 9pt;  padding-left:5px; font-family: Arial;">Validity :
                                                                           <asp:TextBox ID="Val_DTI" runat="server"></asp:TextBox></td>
                                                     <td><asp:ImageButton ID="ImageButton11" runat="server" Width="18px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton></td>
                                                     <cc1:calendarextender ID="CalendarExtender11" runat="server" PopupButtonID="ImageButton11" Enabled="True" TargetControlID="Val_DTI"></cc1:calendarextender>
                                                 </tr>
                                             </table>
                                         </fieldset>


                                     </td>
                            </tr>
  <tr>
                                     <td >
                                         <fieldset>
                                             <legend class="column_LeftBold">Tax Clearance Cert :</legend>
                                             <table>
                                                 <tr>
                                                      <td style="font-weight: bold; font-size: 9pt; padding-left:5px; font-family: Arial;">Tax Clearance Cert No. :
                                                                           <asp:TextBox ID="Tax_No" runat="server"></asp:TextBox></td>


                                                     <td style="font-weight: bold; font-size: 9pt; padding-left:3px; font-family: Arial;">Issued At :
                                                                           <asp:TextBox ID="Iss_Tax" runat="server"></asp:TextBox></td>

                                                     <td style="font-weight: bold; font-size: 9pt; padding-left:5px; font-family: Arial;">Date Issued :
                                                                           <asp:TextBox ID="DI_Tax" runat="server"></asp:TextBox></td>
                                                     <td><asp:ImageButton ID="ImageButton13" runat="server" Width="18px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton></td>
                                                     <cc1:calendarextender ID="CalendarExtender1" runat="server" PopupButtonID="ImageButton13" Enabled="True" TargetControlID="DI_Tax"></cc1:calendarextender>
                                                     <td style="font-weight: bold; font-size: 9pt; padding-left:5px; font-family: Arial;">Validity :
                                                                           <asp:TextBox ID="Val_Tax" runat="server"></asp:TextBox></td>
                                                     <td><asp:ImageButton ID="ImageButton14" runat="server" Width="18px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton></td>
                                                     <cc1:calendarextender ID="CalendarExtender2" runat="server" PopupButtonID="ImageButton14" Enabled="True" TargetControlID="Val_Tax"></cc1:calendarextender>
                                                 </tr>
                                             </table>
                                         </fieldset>


                                     </td>
                            </tr>
  <tr>
                                     <td >
                                         <fieldset>
                                             <legend class="column_LeftBold">SEC Registration :</legend>
                                             <table>
                                                 <tr>
                                                      <td style="font-weight: bold; font-size: 9pt; padding-left:5px; font-family: Arial;">SEC Registration No. :
                                                                           <asp:TextBox ID="SEC_RegNo" runat="server"></asp:TextBox></td>


                                                     <td style="font-weight: bold; font-size: 9pt; padding-left:3px; font-family: Arial;">Issued At :
                                                                           <asp:TextBox ID="Iss_Sec" runat="server"></asp:TextBox></td>

                                                     <td style="font-weight: bold; font-size: 9pt; padding-left:5px; font-family: Arial;">Date Issued :
                                                                           <asp:TextBox ID="DI_Sec" runat="server"></asp:TextBox></td>
                                                     <td><asp:ImageButton ID="ImageButton15" runat="server" Width="18px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton></td>
                                                     <cc1:calendarextender ID="CalendarExtender3" runat="server" PopupButtonID="ImageButton15" Enabled="True" TargetControlID="DI_Sec"></cc1:calendarextender>
                                                     <td style="font-weight: bold; font-size: 9pt; padding-left:5px; font-family: Arial;">Validity :
                                                                           <asp:TextBox ID="Val_Sec" runat="server"></asp:TextBox></td>
                                                       <td>
                                                         <asp:ImageButton ID="ImageButton16" runat="server" Height="15px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="18px" />
                                                     </td>
                                                     <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" PopupButtonID="ImageButton16" TargetControlID="Val_Sec">
                                                     </cc1:CalendarExtender>
                                                 </tr>
                                               
                                             </table>
                                         </fieldset>


                                     </td>
                            </tr>
  <tr>
                                     <td >
                                         <fieldset>
                                             <legend class="column_LeftBold">PhilGEPS :</legend>
                                             <table>
                                                 <tr>

                                                      <td style="font-weight: bold; font-size: 9pt; padding-left:5px; font-family: Arial;">PhilGEPS No. :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                           <asp:TextBox ID="Phil_No" runat="server"></asp:TextBox></td>

                                                     <td style="font-weight: bold; font-size: 9pt; padding-left:3px; font-family: Arial;">Issued At  :
                                                                           <asp:TextBox ID="Iss_Phil" runat="server"></asp:TextBox></td>

                                                     <td style="font-weight: bold; font-size: 9pt; padding-left:5px; font-family: Arial;">Date Issued  :
                                                                           <asp:TextBox ID="DI_Phil" runat="server"></asp:TextBox></td>
                                                       <td>
                                                         <asp:ImageButton ID="ImageButton17" runat="server" Height="15px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="18px" />
                                                     </td>
                                                     <cc1:CalendarExtender ID="CalendarExtender8" runat="server" Enabled="True" PopupButtonID="ImageButton17" TargetControlID="DI_Phil">
                                                     </cc1:CalendarExtender>
                                                     <td style="font-weight: bold; font-size: 9pt; padding-left:5px; font-family: Arial;">Validity :
                                                                           <asp:TextBox ID="Val_Phil" runat="server"></asp:TextBox></td>
                                                       <td>
                                                         <asp:ImageButton ID="ImageButton18" runat="server" Height="15px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="18px" />
                                                     </td>
                                                     <cc1:CalendarExtender ID="CalendarExtender9" runat="server" Enabled="True" PopupButtonID="ImageButton18" TargetControlID="Val_Phil">
                                                     </cc1:CalendarExtender>
                                                 </tr>
                                             </table>
                                         </fieldset>


                                     </td>
                            </tr>
  <tr>
                                     <td >
                                         <fieldset>
                                             <legend class="column_LeftBold">Business Permit :</legend>
                                             <table>
                                                 <tr>
                                                      <td style="font-weight: bold; font-size: 9pt; padding-left:5px; font-family: Arial;">Business Permit No. :
                                                                           <asp:TextBox ID="BP_No" runat="server"></asp:TextBox></td>

                                                     <td style="font-weight: bold; font-size: 9pt; padding-left:3px; font-family: Arial;">Issued At :
                                                                           <asp:TextBox ID="Iss_BP" runat="server"></asp:TextBox></td>

                                                     <td style="font-weight: bold; font-size: 9pt; padding-left:5px; font-family: Arial;">Date Issued :
                                                                           <asp:TextBox ID="DI_BP" runat="server"></asp:TextBox></td>
                                                       <td>
                                                         <asp:ImageButton ID="ImageButton19" runat="server" Height="15px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="18px" />
                                                     </td>
                                                     <cc1:CalendarExtender ID="CalendarExtender12" runat="server" Enabled="True" PopupButtonID="ImageButton19" TargetControlID="DI_BP">
                                                     </cc1:CalendarExtender>
                                                     <td style="font-weight: bold; font-size: 9pt; padding-left:5px; font-family: Arial;">Validity :
                                                                           <asp:TextBox ID="Val_BP" runat="server"></asp:TextBox></td>
                                                      <td>
                                                         <asp:ImageButton ID="ImageButton20" runat="server" Height="15px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="18px" />
                                                     </td>
                                                     <cc1:CalendarExtender ID="CalendarExtender13" runat="server" Enabled="True" PopupButtonID="ImageButton20" TargetControlID="Val_BP">
                                                     </cc1:CalendarExtender>
                                                 </tr>  
                                                 
                                                    
                                                 
                                             </table>
                                         </fieldset>


                                     </td>
                            </tr>
  <tr>
                                     <td >
                                         <fieldset>
                                             <legend class="column_LeftBold">PCAB License :</legend>
                                             <table>
                                                 <tr>
                                                      <td style="font-weight: bold; font-size: 9pt; padding-left:5px; padding-right:35px; font-family: Arial;">PCAB No. :
                                                                           <asp:TextBox ID="PCAB_no" runat="server"></asp:TextBox></td>

                                                     <td style="font-weight: bold; font-size: 9pt; padding-left:3px; font-family: Arial;">&nbsp;Issued At :&nbsp;
                                                                           <asp:TextBox ID="Iss_PCAB" runat="server"></asp:TextBox></td>

                                                     <td style="font-weight: bold; font-size: 9pt; padding-left:5px; font-family: Arial;">Date Issued  :
                                                                           <asp:TextBox ID="DI_PCAB" runat="server"></asp:TextBox></td>
                                                       <td>
                                                         <asp:ImageButton ID="ImageButton21" runat="server" Height="15px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="18px" />
                                                     </td>
                                                     <cc1:CalendarExtender ID="CalendarExtender14" runat="server" Enabled="True" PopupButtonID="ImageButton21" TargetControlID="DI_PCAB">
                                                     </cc1:CalendarExtender>
                                                     <td style="font-weight: bold; font-size: 9pt; padding-left:5px; font-family: Arial;">Validity  :
                                                                           <asp:TextBox ID="Val_PCAB" runat="server"></asp:TextBox></td>
                                                       <td>
                                                         <asp:ImageButton ID="ImageButton22" runat="server" Height="15px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="18px" />
                                                     </td>
                                                     <cc1:CalendarExtender ID="CalendarExtender15" runat="server" Enabled="True" PopupButtonID="ImageButton22" TargetControlID="Val_PCAB">
                                                     </cc1:CalendarExtender>
                                                 </tr>
                                             </table>
                                         </fieldset>


                                     </td>
                            </tr>
                                 <tr>
                                     <td >
                                         <fieldset>
                                             <legend class="column_LeftBold">FDA Registration :</legend>
                                             <table>
                                                 <tr >

                                                      <td style="font-weight: bold; font-size: 9pt; padding-left:5px; font-family: Arial;">FDA Registration No. :
                                                                           <asp:TextBox ID="FDA_no" runat="server"></asp:TextBox></td>

                                                     <td style="font-weight: bold; font-size: 9pt; padding-left:3px; font-family: Arial;">Issued At :
                                                                           <asp:TextBox ID="Iss_FDA" runat="server"></asp:TextBox></td>

                                                     <td style="font-weight: bold; font-size: 9pt; font-family : Arial;">Date Issued:
                                                                           <asp:TextBox ID="DI_FDA" runat="server"></asp:TextBox></td>
                                                       <td>
                                                         <asp:ImageButton ID="ImageButton23" runat="server" Height="15px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="18px" />
                                                     </td>
                                                     <cc1:CalendarExtender ID="CalendarExtender16" runat="server" Enabled="True" PopupButtonID="ImageButton23" TargetControlID="DI_FDA">
                                                     </cc1:CalendarExtender>
                                                     <td  style="font-weight: bold; font-size: 9pt; padding-left:5px; font-family: Arial;">Validity :
                                                                           <asp:TextBox ID="Val_FDA" runat="server"></asp:TextBox></td>
                                                       <td>
                                                         <asp:ImageButton ID="ImageButton24" runat="server" Height="15px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="18px" />
                                                     </td>
                                                     <cc1:CalendarExtender ID="CalendarExtender17" runat="server" Enabled="True" PopupButtonID="ImageButton24" TargetControlID="Val_FDA">
                                                     </cc1:CalendarExtender>
                                                 </tr>
                                             </table>
                                         </fieldset>


                                     </td>
                            </tr>

                          </table>
                      



                         
                        
                                
                            </tr>
                <tr>
                                                       <td style="width: 1%"></td>
                                       
                                                       <td align="center" style="width: 88%">
                                                           <asp:Button ID="btnadd" CssClass="CSButton" runat="server" Text="ADD" Width="150px" />
                                                          &nbsp; <asp:Button ID="btnedit" runat="server" Enabled="False" Text="EDIT" Width="150px" CssClass="CSButton" />
                                                          &nbsp; <asp:Button ID="btnsave" runat="server" Enabled="False" OnClientClick="StartProgressBar();" Text="SAVE" ValidationGroup="save" Width="150px" CssClass="CSButton" />
                                                          &nbsp; <asp:Button ID="btnDelete" runat="server"  Enabled="False" OnClick="btnDelete_Click" Text="DELETE" ValidationGroup="save" Visible="False" Width="150px" />
                                                           <asp:HiddenField ID="hdnItemSubClass" runat="server" />
                                          
                                                <asp:TextBox ID="CPAttached" runat="server" Visible="false"></asp:TextBox>
                                                       </td>
                                       <td style="width: 1%"></td>
                                                   </tr>

               
                <table width="100%" >
               
  
                    <tr>
                          
                            <td align="center" class="DivTitle" colspan="6">LIST OF ITEMS</td>
                    </tr>
                 
                  <tr>
                      <td class="column_RightBold" style="width: 21%">Classification : </td>
                      <td class="column_Left" style="width: 20%">
                           <asp:HiddenField ID="HiddenField1" runat="server" />
                                            <asp:HiddenField ID="hdnGAId" runat="server" />
                          <asp:DropDownList ID="DrpCLass" runat="server" AutoPostBack="true" CssClass="drpdownCSS"  Width="97%" Height="24px" OnSelectedIndexChanged="DrpClass_SelectedIndexChanged">
                          </asp:DropDownList>
                        
                      </td>
                       <td style="width: 5%" class="column_RightBold">Sub Classification :</td>
                           <td class="column_Left" style="width: 23%">
                                                    <asp:DropDownList ID="DrpSubClass" runat="server" CssClass="drpdownCSS" Width="92%" AutoPostBack="true" Height="24px" OnSelectedIndexChanged="DrpSubClass_SelectedIndexChanged"></asp:DropDownList>
                                                 
                                                </td>
                        <td style="width: 5%" class="column_RightBold">General Account:</td>
                        <td style="width: 48%;" align="left">
                            <asp:HiddenField ID="HiddenField2" runat="server"></asp:HiddenField>
                                                    <asp:HiddenField ID="HiddenField3" runat="server"></asp:HiddenField>
                                                    <asp:HiddenField ID="HiddenField4" runat="server"></asp:HiddenField>
                                                    <asp:DropDownList ID="GenAccnt" runat="server" Width="190px" AutoPostBack="true" AppendDataBoundItems="false"  Style="margin-left: 0px" Height="24px" OnSelectedIndexChanged="GenAccnt_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                  </tr>
                     <tr>
                      <td class="column_RightBold" style="width: 21%">Category : </td>
                      <td class="column_Left" style="width: 20%">
                          <asp:DropDownList ID="ddParticular" runat="server" AutoPostBack="True" CssClass="drpdownCSS"  Width="97%" Height="24px" OnSelectedIndexChanged="ddParticular_SelectedIndexChanged">
                          </asp:DropDownList>
                        
                      </td>
                       <td style="width: 10%" class="column_RightBold">Sub Category :</td>
                           <td class="column_Left" style="width: 23%">
                                                    <asp:DropDownList ID="ddSubCategory" runat="server" CssClass="drpdownCSS" Width="94%" AutoPostBack="True" Height="24px" ></asp:DropDownList>
                                                 
                                                </td>
                  </tr>
                
                    <tr valign="middle">
                        <td style="width:21%"></td>
                        <td style="width:1%"></td>
                        <td  align="center">
                        <asp:Button ID="BtnViewList" runat="server" Font-Bold="true" ForeColor="blue" Height="25px"  Autopostback="true" OnClientClick="StartProgressBar();" Text="View List of Goods" Width="132px" OnClick="BtnViewList_Click" />
                            </td>
                    </tr>
                   
                </table>
              <%--  <table width="100%">
                    <tr>
                        <td>
                                <asp:GridView ID="gvstock" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="particulardesc,detail,UnitDesc,price1,Item_ID,item_particular_id,Unit_ID,itemdesc,SubCategoryID,SubCat_desc,isused,price2,price,Item_Code,Brand,Color,Size,SubClassificationName,SubClassificationID,GenericName" EmptyDataText="No Records Found" PageSize="20" Visible="true" SkinID="GridViewAA" Width="99%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Add" visible="false" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Font-Underline="False" Text="Select" Width="63px"></asp:LinkButton>
                                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Checked='<%# Bind("isUsed") %>'  />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="AccntCode" HeaderText="Account Code">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Item_Code" HeaderText="Item Code">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="particulardesc" HeaderText="ITEM DESCRIPTION">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Brand" HeaderText="Brand" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Color" HeaderText="Color" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Size" HeaderText="Size" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SubCat_Desc" HeaderText="SubClassification" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="unitdesc" HeaderText="UNIT">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="price1"  Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="price2" HeaderText="Price">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="PRICE 1" Visible="false">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("price1") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblPrevious" runat="server" Font-Bold="True"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("price1", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PRICE 2" Visible="false">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("price2") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblCurrent" runat="server" Font-Bold="True"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("price2", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DEL">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/delete.png" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton4" runat="server" CommandName="Select" Height="15px" ImageUrl="~/images/delete.png" OnClientClick="StartProgressBar();" />
                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to delete this item?" TargetControlID="ImageButton4">
                                            </cc1:ConfirmButtonExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="4%" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>--%>
                  <table width="100%">
                       <tr>
                       
                        <td style="width: 98%" align="center">
                            <asp:GridView runat="server" ID="grdItems_ForSupplier" SkinID="GridViewAA" Width="98%" ShowFooter="true"
                                DataKeyNames="Item_ID" OnSelectedIndexChanged="grdItems_ForSupplier_SelectedIndexChanged">
                                <Columns>
                                  <asp:BoundField ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left" DataField="AccntCode" HeaderText="Account Code" />
                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left" DataField="Item_Code" HeaderText="Item_Code" />
                                    <asp:BoundField ItemStyle-Width="50%" ItemStyle-HorizontalAlign="Left" DataField="Particulardesc" HeaderText="Item Description" />
                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="UnitDesc" HeaderText="Unit" />

                           

                                  
                                      <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkRemove" CssClass="LinkBtnCancel" Text="Remove" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                            <cc1:ConfirmButtonExtender runat="server" ID="ConfirmButtonExtender1" TargetControlID="lnkRemove" ConfirmText="Are your sure to remove this item?"></cc1:ConfirmButtonExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 
                                </Columns>
                            </asp:GridView>
                        </td>
                   
                    </tr>
                  </table>
                 
               <%-- MODAL POPUP--%>
                 <asp:Panel runat="server" ID="pnlItemList" Width="800px" CssClass="Panel_Popup">
                <div>
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">List of Items
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <span class="column_RightBold">Description :</span>
                                &nbsp;<asp:TextBox runat="server" ID="txtSearch_Item" CssClass="txtbox_Var" Text="" Width="40%"></asp:TextBox>
                                &nbsp;<asp:Button runat="server" ID="btnSearch_Item" CssClass="CSButton" Width="15%" Text="Search" OnClientClick="StartProgressBar();" />
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 5px">
                                <asp:GridView ID="grdSupplier_Items" runat="server" AllowPaging="true" DataKeyNames="Item_ID" 
                                    EmptyDataText="No Data Found." PageSize="8" SkinID="GridViewAA" Width="100%" AutoGenerateColumns="False">
                                    <Columns>
                                          
                                       
                                  
                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="cbAll_Item" runat="server" AutoPostBack="true" Checked="false"  />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbItem" runat="server" AutoPostBack="true" OnCheckedChanged="cbItem_CheckedChanged" Checked="false" ></asp:CheckBox>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ID" Visible="true" ItemStyle-CssClass="hiddencol" HeaderText="Description" HeaderStyle-CssClass="hiddencol" />
                                        <asp:BoundField ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left" DataField="AccntCode" HeaderText="Account Code" />
                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left" DataField="Item_Code" HeaderText="Item_Code" />
                                        <asp:BoundField DataField="Particulardesc" HeaderText="Description" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70%" />
                                        <asp:BoundField DataField="UnitDesc" HeaderText="Unit" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                        <asp:BoundField DataField="Price" DataFormatString="{0:N}" HeaderText="Price" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%" />
                                        <asp:BoundField DataField="AvailableQty" DataFormatString="{0:###,##0.##}" Visible="false" HeaderText="Available Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                        <asp:BoundField DataField="ID" Visible="false" />
                                        
                                        <asp:BoundField DataField="Item_ID" Visible="false" />
                                       
                                        
                                    </Columns>
                                </asp:GridView>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <asp:Panel runat="server" ID="pnlScroll" Width="98%" CssClass="PanelSize_Popup" ScrollBars="Vertical">
                                </asp:Panel>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <asp:Button runat="server" ID="btnLoad" CssClass="CSButton" Width="15%" Text="Load" OnClientClick="StartProgressBar();" />
                                &nbsp;<asp:Button runat="server" ID="btnClose" CssClass="CSButton" Width="15%" Text="Close" OnClientClick="StartProgressBar();" />
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px">
                                <asp:Label runat="server" ID="lblItem_PopUp"></asp:Label>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>

          </table>
           <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
          <%--<img src="../images/ajax-loader.gif" />--%>
            </asp:Panel>
               <cc1:ModalPopupExtender runat="server" ID="ModalPopupExtender1" TargetControlID="lblItem_PopUp" PopupControlID="pnlItemList" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
           <%-- <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>--%>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="33px" Enabled="False" Height="19px"></asp:Button> 
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

