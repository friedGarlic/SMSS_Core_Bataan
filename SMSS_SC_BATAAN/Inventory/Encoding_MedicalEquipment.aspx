<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Encoding_MedicalEquipment.aspx.vb" Inherits="Inventory_Encoding_MedicalEquipment" 
          StylesheetTheme="SkinFile"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
            <div>
                 <table width="100%">
                      <tr>
                        <td colspan="7" class="PageTitle" style="width: 98%">
                            <%--STOCK CARD--%><strong>
                                <asp:Label ID="lblClass" runat="server" Text="Encoding of Medical Equipment"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                     <tr style="display: none;">
                        <td colspan="7" class="column_RightBold" style="width: 98%; text-align: right;"><%--STOCK CARD--%>Date :
                                 <asp:TextBox ID="txtDate" runat="server" CssClass="txtbox_Date" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td align="center" style="width: 100%">
                            <asp:HiddenField ID="hdnItemNo" runat="server" /><asp:HiddenField ID="hdnGAId" runat="server" />

                        </td>

                    
                      </tr>
                      <tr>
                        <td align="center" class="DivTitle" style="width: 100%"><asp:Label ID="lblSubClass" runat="server" Text="MEDICAL EQUIPMENT INFORMATION"></asp:Label>

                        </td>
                    </tr>
                      <tr>
                         <td colspan="7" style="width: 98%">
                             <table style="width: 100%;">
                                  <tr>
                                    <td class="column_RightBold" style="width: 10%">
                                        Name :

                                    </td>
                                    <td class="column_Left" style="width: 30%">

                                        <asp:Label ID="lblequipmentname" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="drpName" AutoPostBack ="true" runat="server" Width="91%" ></asp:DropDownList>
                                                          
                                        <asp:TextBox ID="txtName" runat="server" Width="89%"  CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                    </td>
                                    <td class="column_RightBold" style="width: 10%">Unit :

                                    </td>
                                    <td class="column_Left" style="width: 30%">

                                        <asp:Label ID="Label4" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="drpUnit" AutoPostBack ="true" runat="server" Width="100px" CssClass="drpdownCSS" ></asp:DropDownList>
                                                                   <span class="column_RightBold">Quantity :</span>
                                                                    <asp:TextBox ID="txtEquipmentQuantity" runat="server" Width="100px" CssClass="txtbox_Var" ></asp:TextBox>
                                                                 
                                        <asp:TextBox ID="TextBox1" runat="server" Width="89%"  CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                    </td>
                                    <td align="center" rowspan="6" style="width: 20%" valign="middle">
                                        <asp:Image ID="Image3" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                        <br />
                                               <asp:Button ID="btnupload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>
                                
                                    </td>
                                  </tr>
                                    <tr>
                                    <td class="column_RightBold" style="width: 10%">Description :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentdesciption" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtequipmentdesciption" runat="server" Width="89%"  CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                      <td class="column_RightBold" style="width: 10%">Warranty :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentwaranty" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtequipmentwaranty" runat="server" Width="89%"  CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">Power Input :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentpowerinput" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtequipmentpowerinput" runat="server" Width="89%"  CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                     <td class="column_RightBold">
                                                                  Installed At :
                                                              </td>
                                                              <td class="column_Left">
                                                                     <asp:DropDownList ID="drpInstalledAtBuilding" runat="server" Width="75%" CssClass="drpdownCSS" ></asp:DropDownList>
                                                            
                                                              </td>
                                   
                                </tr>
                                <tr>
                                     <td class="column_RightBold" style="width: 10%">Model :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentmodel" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtequipmentmodel" runat="server" Width="89%"  CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                  
                                    <td class="column_RightBold" style="width: 10%">Dimension :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentdimension" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtequipmentdimension" runat="server" Width="89%"  CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                   
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">Serial Number :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="Label5" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtequipmentSerialNo" runat="server" Width="89%"  CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    <td></td>
                                   <td class="column_Left" >
                                                                    <asp:linkbutton ID="btnaddpropertyinfo" runat="server"  Text ="Add Property Information" OnClick="btnaddpropertyinfo_Click"></asp:linkbutton>
                                  
                                   </td>
                                   
                                </tr>
                                <tr style="display:none">
                                     <td class="column_RightBold" style="width: 10%;">Area Capacity :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentareacapacity" runat="server" Width="290px" SkinID="Label" Font-Italic="False" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtequipmentareacapacity" runat="server" Width="89%"  CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                               </tr>
                                <tr>
                                                  <td colspan="4">
                                                      <fieldset style="width:93%">
                                                           <legend class="column_LeftBold">Maintenance</legend>
                                                      <table width="100%">
                                                          <tr>
                                                              <td class="column_RightBold">
                                                                    Contractor : 
                                                              </td>
                                                              <td class="column_Left">
                                                                 <asp:TextBox ID="txtContractor" runat="server" Width="75%" CssClass="txtbox_Var" ></asp:TextBox>
                                                              </td>
                                                              <td class="column_RightBold">
                                                                  Contact Person : 
                                                              </td>
                                                              <td class="column_Left">
                                                                 <asp:TextBox ID="txtContactPerson" runat="server" Width="75%" CssClass="txtbox_Var" ></asp:TextBox>
                                                              </td>
                                                              <td class="column_RightBold">
                                                                    Cellphone No. : 
                                                              </td>
                                                              <td class="column_Left">
                                                                 <asp:TextBox ID="txtCellphoneNo" runat="server" Width="75%" CssClass="txtbox_Var" ></asp:TextBox>
                                                              </td>
                                                          </tr>
                                                      </table>
                                                      </fieldset>
                                                  </td>
                                              </tr>
                                <tr>
                                    <td colspan ="4">
                                        <fieldset style="width:93%;">
                                            <legend class="column_LeftBold">Acquisition :</legend>
                                        <table >
 <tr>
                                     <td  class="column_RightBold">Acquisition Date :
                                    </td>
                                    <td class="column_Left" style="width:100px;">
                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtEAcqDate" runat="server"   CssClass="txtbox_Var" ></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEAcqDate" PopupButtonID="txtEAcqDate"></cc1:CalendarExtender>


                                        &nbsp;(MM/DD/YYYY)</td>
                                   <td class="column_RightBold" >Market Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtEMarketValue" runat="server"   CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                    
                                    
                                </tr>
                                <tr>
                                    
                                    <td class="column_RightBold" >Acquisition Cost :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="Label2" runat="server" ></asp:Label>
                                        <asp:TextBox ID="txtEAcqCost" runat="server"  CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    
                                    <td class="column_RightBold" >No. of Years :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="lblNoYears" runat="server" ></asp:Label>
                                        <asp:TextBox ID="txtNoYears" runat="server"  CssClass="txtbox_Var"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    
                                    <td class="column_RightBold">Dep. Rate :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="lblequipmentdepreciatedRate" runat="server" Width="100px"  CssClass="txtboxAmount" MaxLength="5" ReadOnly="True"></asp:TextBox>&nbsp;(%) Percent</td>

                                    
                                    <td class="column_RightBold">Useful Life :
                                    </td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblUsefulLife" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtUsefulLife" runat="server" Width="100px"  CssClass="txtbox_Var" ></asp:TextBox>

                                        &nbsp;(Years)</td>

                                </tr>


                                <tr>
                                    
                                    <td class="column_RightBold" >Dep. Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="lblequipmentdepreciatedvalue" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtequipmentdepreciatedvalue" runat="server" Width="100px" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    
                                   <td class="column_RightBold">Salvage Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:TextBox ID="txtSalvageValue" runat="server" Width="85%" CssClass="txtboxAmount" >0.00</asp:TextBox></td>


                                </tr>
                               
                                        </table>
                                        </fieldset>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                    <td class="column_RightBold" colspan="3"></td>
                                    <td>
                                          <asp:Button ID="btnSave" runat="server" Width="48%" CssClass="CSButton" Text="SAVE" Enabled="false" OnClick="btnSave_Click" OnClientClick="StartProgressBar();"></asp:Button>
                                      <asp:Button ID="btnCancel" runat="server" Width="48%" CssClass="CSButton" Text="CANCEL" Enabled="false"></asp:Button>
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
                        <td colspan="7" style="width: 98%">
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
                                                    <asp:GridView ID="grdLedger1" runat="server" Width="100%" SkinID="GridViewAA" HorizontalAlign="Center" Font-Size="8pt">
                                                        <%--OnSelectedIndexChanged="grdrepairsandmaintenance_SelectedIndexChanged"--%>
                                                        <Columns>
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
                                        <tr>
                                            <td align="center" colspan="4">
                                                <asp:Button ID="btnPreview" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW"></asp:Button></td>
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
                           <asp:GridView ID="grdPropertyInfo" runat="server" SkinID="gvnew" AutoGenerateColumns="false"
                            EmptyDataText="No records has been added." OnRowDataBound="grdPropertyInfo_RowDataBound">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width ="50px">
                                        <ItemTemplate>
                                            
                                            <asp:CheckBox id="cbPI" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Property Number" >
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtPropertyNo" runat ="server" Width ="200px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width ="19%" HeaderText="Department">
                                        <ItemTemplate>
                                            
                                       <asp:DropDownList ID="drpDepartment" runat="server" Width ="300px" ></asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width ="19%" HeaderText="Accountable Person">
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtAccountablePerson" runat ="server"  Width ="200px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width ="19%" HeaderText="Floor Location">
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtPIFloorLocation" runat ="server"  Width ="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width ="50%" HeaderText="Room">
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
                                <asp:Button ID="btnProceedEdit"  runat="server" Width="150px" CssClass="CSButton" Text="PROCEED" OnClick="btnProceedEdit_Click"></asp:Button>
                    
                        <asp:Button ID="btnAuthCancel"  runat="server" Width="150px" CssClass="CSButton" Text="CANCEL"></asp:Button>
                    </td>
                      </tr>
                  </table>
                  
                  </asp:Panel> 
       </ContentTemplate>
   </asp:UpdatePanel>
</asp:Content>

