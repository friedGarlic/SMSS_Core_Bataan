<%@ Page 
    Language="VB" 
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" 
    CodeFile="t_Drainage.aspx.vb" 
    Inherits="Inventory_t_Drainage"
    Title="Drainage" 
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <asp:UpdatePanel ID="upEmployeeDetail" runat="server">
            <ContentTemplate>
                <div>
                    <table width="100%">
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%">
                                <table>
                                    <tr>
                                        <td class="column_RightBold">Sub Classification :</td>
                                        <td class="column_Left">
                                            <asp:DropDownList ID="drpSubClassification" runat="server" CssClass="drpdownCSS" Width="200px"></asp:DropDownList></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" class="DivTitle">IDENTIFICATION AND LOCATION</td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%">
                                <table style="width:100%">
                                    <tr>
                                        <td class="column_LeftBold" style="width:7%">Drainage ID :</td>
                                        <td class="column_Left" style="width:80%"><asp:TextBox runat="server" ID="txtDrainageID" CssClass="txtbox_Var"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                       <td colspan="2" style="height: 30px" >
                                           <asp:Panel runat="server" ID="pnlLocationgDescription" GroupingText="Locationg and Description" CssClass="panel_border">
                                               <table>
                                                   <tr>
                                                       <td class="column_RightBold">Street Name :</td>
                                                       <td><asp:TextBox ID="txtLDStreetName" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                                       <td class="column_RightBold">Area :</td>
                                                       <td><asp:TextBox ID="txtLDArea" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                                       <td class="column_RightBold">Landmarks :</td>
                                                       <td><asp:TextBox ID="txtLDLandmarks" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                                   </tr>
                                               </table>
                                           </asp:Panel>
                                       </td>

                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                             <asp:Panel runat="server" ID="Panel1" GroupingText="GPS Coordinates" CssClass="panel_border">
                                                 <table>
                                                     <tr>
                                                         <td class="column_RightBold">Latitude :</td>
                                                         <td class="column_Left"><asp:TextBox ID="txtLatitude" runat="server"></asp:TextBox></td>
                                                         <td class="column_RightBold">Longlitude :</td>
                                                         <td class="column_Left"><asp:TextBox ID="txtLonglitude" runat="server"></asp:TextBox></td>
                                                     </tr>
                                                 </table>
                                             </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        
                        <tr>
                            <td style="width:1%"></td>
                            <td style="width:98%" class="DivTitle">DRAINAGE SYSTEM SPECIFICATION</td>
                            <td style="width:1%"></td>
                        </tr>
                        <tr>
                            <td style="width:1%"></td>
                            <td style="width:98%">
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="column_RightBold">Type of Drainage System :</td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox_Var"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="Button2" runat="server" CssClass="CSButton" Text="Button" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="DivTitle" colspan="3">Dimension</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <table>
                                                            <tr>
                                                                <td class="column_RightBold">Diameter/Size :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtDiameterSize" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td class="column_RightBold">Length :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtLength" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <table>
                                                            <tr>
                                                                <td class="column_RightBold">Depth :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtDepth" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td class="column_RightBold">Slope :</td>
                                                                <td class="column_Left">
                                                                    <asp:TextBox ID="txtSlope" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="pnlMaterial" runat="server" CssClass="panel_border">
                                                            <table>
                                                                <tr>
                                                                    <td class="column_RightBold">Material :</td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="txtbox_Var" Width="75px"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Quantity :</td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="txtbox_Var" Width="75px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnAddMaterial" runat="server" CssClass="CSButton" Text="ADD" Width="100px" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="5">
                                                                        <asp:GridView ID="grdMaterial" runat="server" EmptyDataText="No Data Found." SkinID="GridViewAA" Width="500px">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="Material" HeaderText="Material" />
                                                                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width:1%"></td>
                        </tr>


                        <tr>
                            <td style="width:1%"></td>
                            <td style="width:98%" class="DivTitle">INLET AND OUTLET</td>
                            <td style="width:1%"></td>
                        </tr>
                        <tr align="center">
                            <td style="width:1%"></td>
                            <td style="width:98%">
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="DivTitle" colspan="3" >INLET DETAILS</td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" >Intel Type : </td>
                                                    <td class="column_Left"><asp:DropDownList ID="drpIntelType" runat="server" CssClass="drpdownCSS" Width="200px"></asp:DropDownList></td>
                                                    <td><asp:Button ID="btnIntelType" CssClass="CSButton" runat="server" Text="Add New" /></td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold">If Other, specify : </td>
                                                    <td class="column_Left"><asp:TextBox runat="server" ID="txtIfOtherSpecify" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold">Street Name :</td>
                                                    <td class="column_Left"><asp:TextBox runat="server" ID="txtStreetName" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="DivTitle" colspan="3">GPS Coordinates</td>
                                                </tr>
                                                <tr>
                                                  <td colspan="4">
                                                      <table>
                                                          <tr>
                                                              <td class="column_RightBold">Latitude :</td>
                                                              <td class="column_Left"><asp:TextBox runat="server" ID="txtInletGPSLatitude" CssClass="txtbox_Var" Width="50px"></asp:TextBox>
                                                              </td>
                                                              <td class="column_RightBold">Longlitude :</td>
                                                              <td class="column_Left"><asp:TextBox runat="server" ID="txtInletGPSLonglitude" CssClass="txtbox_Var" Width="50px"></asp:TextBox></td>
                                                          </tr>
                                                      </table>
                                                  </td>
                                 
                                                </tr>
                                                 <tr>
                                                    <td class="column_LeftBold" colspan="4">Description :</td>
                                                </tr>
                                                <tr>
                                                    <td class="column_Left" colspan="4">
                                                        <asp:TextBox ID="txtDescriptionInletDetail" runat="server" CssClass="txtbox_Var" Height="30px" Width="400px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                   
                                                </tr>
                                             
                                            </table>
                                        </td>
                                        <td>
                                             <table>
                                                <tr>
                                                    <td class="DivTitle" colspan="3" >OUTLET DETAILS</td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" >Outlet Type : </td>
                                                    <td class="column_Left"><asp:DropDownList ID="drpOutletType" runat="server" CssClass="drpdownCSS" Width="200px"></asp:DropDownList></td>
                                                    <td><asp:Button ID="Button1" CssClass="CSButton" runat="server" Text="Add New" /></td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold">If Other, specify : </td>
                                                    <td class="column_Left"><asp:TextBox runat="server" ID="txtOutletIfOtherSpecify" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold">Street Name :</td>
                                                    <td class="column_Left"><asp:TextBox runat="server" ID="txtOutletStreetName" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="DivTitle" colspan="3">GPS Coordinates</td>
                                                </tr>
                                                <tr>
                                                  <td colspan="4">
                                                      <table>
                                                          <tr>
                                                              <td class="column_RightBold">Latitude :</td>
                                                              <td class="column_Left"><asp:TextBox runat="server" ID="txtOutletGSPLatitude" CssClass="txtbox_Var" Width="50px"></asp:TextBox>
                                                              </td>
                                                              <td class="column_RightBold">Longlitude :</td>
                                                              <td class="column_Left"><asp:TextBox runat="server" ID="txtOutletGSPLonglitude" CssClass="txtbox_Var" Width="50px"></asp:TextBox></td>
                                                          </tr>
                                                      </table>
                                                  </td>
                                 
                                                </tr>
                                                 <tr>
                                                    <td class="column_LeftBold" colspan="4">Description :</td>
                                                </tr>
                                                <tr>
                                                    <td class="column_Left" colspan="4">
                                                        <asp:TextBox ID="txtOutletDescription" runat="server" CssClass="txtbox_Var" Height="30px" Width="400px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                   
                                                </tr>
                                             
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width:1%"></td>
                        </tr>
                        <tr>
                            <td style="width:1%"></td>
                            <td style="width:98%" class="DivTitle">MAINTENANCE AND STATUS</td>
                            <td style="width:1%"></td>
                            
                        </tr>
                        <tr align="center">
                            <td style="width:1%"></td>
                            <td style="width:98%">
                                <table>
                                    <tr>
                                        <td class="column_RightBold">Condition Status :</td>
                                        <td class="column_Left"><asp:DropDownList ID="drpManitenanceConditionStatus" runat="server" Width="200px"></asp:DropDownList>&nbsp&nbsp&nbsp&nbsp</td>
                                        <td class="column_RightBold">Maintenance Schedule :</td>
                                        <td class="column_Left"><asp:TextBox runat="server" ID="txtMaintenanceSchedule" Width="200px"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width:1%"></td>
                        </tr>
                        <tr align="center">
                            <td style="width:1%"></td>
                            <td style="width:98%">
                               <table>
                                   <tr>
                                        <td class="column_RightBold">Last Maintenance :</td>
                                        <td class="column_Left"><asp:TextBox runat="server" ID="txtLastMaintenance"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp</td>
                                        <td class="column_RightBold">Responsible Entity :</td>
                                        <td class="column_Left"><asp:TextBox runat="server" ID="txtResponsibleEntity" Width="200px"></asp:TextBox></td>
                                   </tr>
                               </table>
                            </td>
                            <td style="width:1%"></td>
                        </tr>
                        <tr>
                          <td style="width:1%"></td>
                          <td style="width:98%" class="DivTitle">COMPLIANCE AND ENVIRONMENTAL IMPACT</td>
                          <td style="width:1%"></td>
                      </tr>
                        <tr>
                          <td style="width:1%"></td>
                          <td style="width:98%">
                              <table width="100%">
                                  <tr>
                                      <td class="column_RightBold" style="width: 20%">Regulatory Compliance :</td>
                                      <td class="column_Left"><asp:TextBox runat="server" ID="txtRegulatoryCompliance" CssClass="txtbox_Var" Width="80%" TextMode="MultiLine" Height="20px"></asp:TextBox></td>
                                  </tr>
                                  <tr>
                                      <td class="column_RightBold" style="width: 20%">Environmental Impact</td>
                                      <td class="column_Left"><asp:TextBox runat="server" ID="txtEnvironmentalImpact" CssClass="txtbox_Var" Width="80%" TextMode="MultiLine" Height="20px"></asp:TextBox></td>
                                  </tr>
                                  <tr>
                                      <td></td>
                                      <td class="column_Left"><asp:CheckBox runat="server" ID="cbFlood" Text="Floodrisk Area?" /></td>
                                  </tr>
                              </table>
                          </td>
                          <td style="width:1%"></td>
                      </tr>
                        <tr>
                         <td style="width:1%"></td>
                          <td style="width:98%" class="DivTitle">ADDITIONAL INFORMATION</td>
                          <td style="width:1%"></td>
                      </tr>
                        <tr>
                          <td style="width:1%"></td>
                          <td style="width:98%">
                              <table style="width:100%">
                                  <tr>
                                      <td class="column_RightBold" style="width:20%">Related Infastructure :</td>
                                      <td class="column_Left"><asp:TextBox runat="server" ID="txtRelatedIsfastructure" Width="80%" Height="30px" TextMode="MultiLine"></asp:TextBox></td>
                                  </tr>
                                  <tr>
                                      <td class="column_RightBold" style="width:20%">Commets/Notes: </td>
                                      <td class="column_Left"><asp:TextBox runat="server" ID="txtComments" Width="80%" Height="30px" TextMode="MultiLine"></asp:TextBox></td>
                                  </tr>
                                  <tr>
                                      <td class="column_RightBold">Cost: </td>
                                      <td class="column_Left"><asp:TextBox runat="server" ID="txtCost"></asp:TextBox></td>
                                  </tr>
                              </table>
                          </td>
                          <td style="width:1%"></td>
                      </tr>
                        <tr>
                          <td style="width:1%"></td>
                          <td style="width:98%" class="DivTitle">Date Construction/Finish</td>
                          <td style="width:1%"></td>
                      </tr>
                        <tr>
                          <td style="width:1%"></td>
                          <td style="width:98%">
                              <table>
                                  <tr>
                                        <td class="column_RightBold">Construction Start Date :</td>
                                        <td class="column_Left"><asp:TextBox ID="txtStartDate" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                        <td class="column_RightBold">Complete Date :</td>
                                        <td class="column_Left"><asp:TextBox ID="txtCompleteDate" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                  </tr>
                              </table>
                          </td>
                          <td style="width:1%"></td>
                            
                       </tr>
                        <tr align="center">
                          <td style="width:1%"></td>
                          <td style="width:98%">
                              <table>
                                  <tr>
                                      <td><asp:Button runat="server" ID="btnSave" Text="SAVE" Width="100px" CssClass="CSButton" /></td>
                                      <td><asp:Button runat="server" ID="btnCancel" Text="CANCEL" Width="100px" CssClass="CSButton" /></td>
                                  </tr>
                              </table>
                          </td>
                          <td style="width:1%"></td>
                        </tr>
                          <tr>
                                <td style="width:1%"></td>
                                <td style="width:98%">
                                    <asp:Panel ID="Panel2" runat="server" CssClass="PanelSize" ScrollBars="Vertical" Width="100%">
                                        <asp:GridView ID="grdLedger1" runat="server" Font-Size="8pt" HorizontalAlign="Center" OnDataBound="OnDataBound" OnRowDataBound="grdLedger1_RowDataBound" SkinID="GridViewAA" Width="100%">
                                            <%--OnSelectedIndexChanged="grdrepairsandmaintenance_SelectedIndexChanged"--%>
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
                                                <asp:BoundField DataField="BalanceUnit" HeaderText="Unit" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="UnitPrice" DataFormatString="{0:N}" HeaderText="Unit Price" Visible="false">
                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DebitQty" HeaderText="Debit Qty" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText="Debit Cost">
                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CreditQty" HeaderText="Credit Qty" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText="Credit Cost">
                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="BalQty" HeaderText="Bal Qty" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="BalCost" DataFormatString="{0:N}" HeaderText="Bal Cost">
                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                                <td style="width:1%"></td>
                            </tr>
                    </table>
                </div>
            </ContentTemplate>
      </asp:UpdatePanel>
</asp:Content>

