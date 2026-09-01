<%@ Page 
    Language="VB" 
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" 
    CodeFile="t_Slope_And_Protection.aspx.vb" 
    Inherits="Inventory_t_Slope_And_Protection"
    Title="Slope and Protection" 
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
             <div>
                    <table width="100%">
                        <tr>
                            <td style="width:1%"></td>
                            <td style="width:98%">
                                <table>
                                    <tr>
                                        <td class="column_RightBold">Sub Classification :</td>
                                        <td class="column_Left"><asp:DropDownList ID="drpSubClassification" runat="server" CssClass="drpdownCSS" Width="200px"></asp:DropDownList></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width:1%"></td>
                        </tr>
                        <tr>
                            <td style="width:1%"></td>
                            <td style="width:98%" class="DivTitle">SLOPE AND PROTECTION INFORMATION</td>
                            <td style="width:1%"></td>
                        </tr>
                        <tr align="center">
                            <td style="width:1%"></td>
                            <td style="width:98%">
                                <table>
                                   <tr>
                                       <td class="column_RightBold">Project Name :</td>
                                       <td class="column_Left" colspan="3"><asp:TextBox ID="txtProjectName" runat="server" CssClass="txtbox_Var" Width="292px"></asp:TextBox></td>
                                       <td class="column_RightBold">Project Description :</td>
                                       <td class="column_Left"><asp:TextBox ID="txtProjectDescription" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                   </tr>
                                    <tr>
                                        <td class="column_RightBold">Property No. :</td>
                                        <td class="column_Left"><asp:TextBox ID="txtProperty_No" runat="server" CssClass="txtbox_Var" Width="100px" AutoPostBack="true" OnTextChanged="txtProperty_No_TextChanged"></asp:TextBox></td>
                                        <td class="column_RightBold">Project Status :</td>
                                        <td class="column_Left"><asp:DropDownList ID="drpProjectStatus" runat="server" CssClass="drpdownCSS" Width="100px"></asp:DropDownList>&nbsp&nbsp</td>
                                        <td class="column_RightBold">Project Justification :</td>
                                        <td class="column_Left"><asp:TextBox ID="txtProjectJustification" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="column_RightBold">Alloted Budget :</td>
                                        <td colspan="3" class="column_Left">
                                            <asp:TextBox ID="txtAllotedBudge" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox>
                                        </td>
                                        <td class="column_RightBold" >Construction Cost :</td>
                                        <td class="column_Left">
                                            <asp:TextBox ID="txtConstructionCost" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                </table>
                            </td>
                            <td style="width:1%"></td>
                        </tr>
                        <tr>
                            <td style="width:1%"></td>
                            <td style="width:98%" class="DivTitle">LOCATION AND SITE DETAILS</td>
                            <td style="width:1%"></td>
                        </tr>
                        <tr align="center">
                           <td style="width:1%"></td>
                           <td style="width:98%">
                               <table>
                                   <tr>
                                       <td class="column_RightBold">Province : </td>
                                       <td class="column_Left"><asp:TextBox ID="txtProvince" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                       <td class="column_RightBold">Specific Site Location : </td>
                                       <td class="column_Left" colspan="3"><asp:TextBox ID="txtSpecificSiteLocation" runat="server" CssClass="txtbox_Var" Width="231px"></asp:TextBox></td>
                                   </tr>
                                   <tr>
                                       <td class="column_RightBold">City/Municipality :</td>
                                       <td class="column_Left"><asp:TextBox ID="txtCity" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                       <td class="column_RightBold">Latitude :</td>
                                       <td class="column_Left"><asp:TextBox ID="txtLatitude" runat="server" CssClass="txtbox_Var" Width="75px"></asp:TextBox></td>
                                       <td class="column_RightBold">Longlitude :</td>
                                       <td class="column_Left"><asp:TextBox ID="txtLonglitude" runat="server" CssClass="txtbox_Var" Width="75px"></asp:TextBox></td>
                                   </tr>
                                   <tr>
                                       <td class="column_RightBold">Barangay</td>
                                       <td class="column_Left"><asp:TextBox ID="txtBarangay" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                   </tr>
                               </table>
                           </td>
                           <td style="width:1%"></td>
                      
                        <tr align="center">
                            <td style="width:1%"></td>
                            <td style="width:98%" class="DivTitle">TECHNICAL SPECIFICATION</td>
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
                                                    <td class="column_RightBold" >Type of Slope and Protection : </td>
                                                    <td><asp:DropDownList ID="drpTypeofSlopeAndProtection" runat="server" CssClass="drpdownCSS" Width="150px"></asp:DropDownList>
                                                        <asp:TextBox ID="txtTypeofSlopAndProtection" Visible="false" CssClass="txtbox_Var" Width="150px" runat="server"></asp:TextBox>

                                                    </td>
                                                    <td><asp:Button ID="btnTypeOfSlopeAndProtection" CssClass="CSButton" runat="server" Text="Add New" OnClick="btnTypeOfSlopeAndProtection_Click" /></td>
                                                </tr>
                                                <tr>
                                                    <td class="column_LeftBold" colspan="3">Detail :</td>
                                                   
                                                </tr>
                                                <tr>
                                                    <td class="column_Left" colspan="3">
                                                        <asp:TextBox ID="txtDeitals" runat="server" CssClass="txtbox_Var" Height="30px" Width="400px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                   
                                                </tr>
                                                <tr>
                                                    <td class="column_LeftBold" colspan="3">Environmental Impact Assessment (EIA):</td>
                                                </tr>
                                                <tr>
                                                    <td class="column_Left" colspan="3">
                                                        <asp:TextBox ID="txtEIA" runat="server" CssClass="txtbox_Var" Height="30px" Width="400px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                   
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                             <table>
                                                 <tr>
                                                     <td>
                                                         <asp:Panel runat="server" ID="pnlMaterial" CssClass="panel_border">
                                                             <table>
                                                                <tr>
                                                                    <td class="column_RightBold">Material :</td>
                                                                    <td class="column_Left"><asp:TextBox ID="txtMaterial" runat="server" CssClass="txtbox_Var" Width="75px"></asp:TextBox></td>
                                                                    <td class="column_RightBold">Quantity :</td>
                                                                    <td class="column_Left"><asp:TextBox ID="txtMaterialQuantity" runat="server" CssClass="txtbox_Var" Width="75px"></asp:TextBox></td>
                                                                    <td><asp:Button runat="server" ID="btnAddMaterial" Text="ADD" Width="100px" CssClass="CSButton" OnClick="btnAddMaterial_Click"/></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="5">
                                                                        <asp:GridView ID="grdMaterial" runat="server" SkinID="GridViewAA" Width="500px" EmptyDataText="No Data Found.">
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
                            <td style="width: 1%"></td>
                            <td style="width: 98%" class="DivTitle">PROJECT MANAGEMENT AND IMPLEMENTATION</td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%">
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="DivTitle" colspan="4">Implementation Timeline</td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold">Start Date :</td>
                                                    <td class="column_Left"><asp:TextBox runat="server" ID="txtIIStartDate" CssClass="txtbox_Var"></asp:TextBox></td>
                                                    <td class="column_RightBold">End Date :</td>
                                                    <td class="column_left"><asp:TextBox runat="server" ID="txtIIEndDate" CssClass="txtbox_Var"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="column_LeftBold" colspan="4" >Major Milestone :</td>
                                                </tr>
                                                 <tr>
                                                    <td class="column_Left" colspan="4"><asp:TextBox runat="server" ID="txtMajorMilestone" CssClass="txtbox_Var" Width="98%" Height="30px" TextMode="MultiLine"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="DivTitle" colspan="4">Budget of Project</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <table>
                                                            <tr>
                                                                <td class="column_RightBold">Budget :</td>
                                                                <td class="column_Left"><asp:TextBox runat="server" ID="txtBudget" CssClass="txtbox_Var"></asp:TextBox></td>
                                                                <td class="column_RightBold">Total Cost :</td>
                                                                <td class="column_Left"><asp:TextBox runat="server" ID="txtTotalCost" CssClass="txtbox_Var"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                   <td class="DivTitle" colspan="4">Date of Construction/Finish</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <table>
                                                            <tr>
                                                                <td class="column_RightBold">Construction Start :</td>
                                                                <td class="column_Left"><asp:TextBox runat="server" ID="txtConstructionStart" CssClass="txtbox_Var"></asp:TextBox></td>
                                                                <td class="column_RightBold">Complete Date :</td>
                                                                <td class="column_Left"><asp:TextBox runat="server" ID="txtCompleteDate" CssClass="txtbox_Var"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                   <td class="DivTitle" colspan="4">Construction Information</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="column_RightBold" style="width:20%">Name :</td>
                                                                <td class="column_Left"><asp:TextBox runat="server" ID="txtName" CssClass="txtbox_Var" Width="98%"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="column_RightBold" style="width:20%">Contact Details :</td>
                                                                <td class="column_Left"><asp:TextBox runat="server" ID="txtContactDetails" CssClass="txtbox_Var" Width="98%"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="column_RightBold" style="width:20%">Qualification :</td>
                                                                <td class="column_Left"><asp:TextBox runat="server" ID="txtQualification" CssClass="txtbox_Var" Width="98%"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>

                                            </table>
                                        </td>
                                        <td style="vertical-align:top">
                                            <asp:Panel CssClass="panel_border" ID="pnlPLA" runat="server">
                                            <table>
                                                <tr>
                                                    <td class="DivTitle" colspan="4">Permit and License Acquired</td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold">Descripton :</td>
                                                    <td class="column_Left"><asp:TextBox runat="server" ID="txtPLADescription" CssClass="txtbox_Var" Width="150px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold">Permit/License No. :</td>
                                                    <td class="column_Left"><asp:TextBox runat="server" ID="txtPLAPermitLicenseNo" CssClass="txtbox_Var" Width="150px"></asp:TextBox></td>
                                                    <td class="column_Left"><asp:Button runat="server" ID="btnAddPLA" Text="ADD" CssClass="CSButton" Width="150px" OnClick="btnAddPLA_Click" /></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:GridView ID="grdPLA" runat="server" SkinID="GridViewAA" Width="500px" EmptyDataText="No Data Found.">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="Permit_License_Description" HeaderText="Permit License Description" />
                                                                                <asp:BoundField DataField="Permit_License_No" HeaderText="Permit License No" />
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
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" class="DivTitle">MONITORING, MAINTENANCE AND STAKEHOLDER ENGAGEMENT</td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 470px">
                                           <table width="470px">
                                               <tr>
                                                   <td class="DivTitle" colspan="2">Monitoring and Maintenance Plan</td>
                                               </tr>
                                               <tr>
                                                   <td class="column_RightBold" style="width:20%">Description :</td>
                                                   <td class="column_Left" style="width:80%"><asp:TextBox ID="txtMMDescription" runat="server" CssClass="txtbox_Var" Height="30px" Width="98%" TextMode="MultiLine"></asp:TextBox> </td>
                                                  
                                               </tr>
                                               <tr>
                                                   <td class="column_RightBold" colspan="3"><asp:Button Text="ADD" runat="server" ID="btnADDMM" Width="75px" CssClass="CSButton" OnClick="btnADDMM_Click" /></td>
                                               </tr>
                                               <tr>
                                                   <td colspan="3">
                                                       <asp:GridView ID="grdMM" runat="server" SkinID="GridViewAA" Width="100%" EmptyDataText="No Data Found.">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="MMP_Description" HeaderText="Monitoring and Maintenance Plan" />
                                                                            </Columns>
                                                        </asp:GridView>
                                                   </td>
                                               </tr>
                                           </table>
                                        </td>
                                        <td >
                                            <table width="470px" style="width: 499px">
                                                <tr>
                                                    <td class="DivTitle" colspan="3">Stakeholder Engagement</td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="width:20%">Description : </td>
                                                    <td class="column_Left" style="width:80%"><asp:TextBox runat="server" ID="txtSEDescription" CssClass="txtbox_Var" Height="30px" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                   <td class="column_RightBold" colspan="3"><asp:Button Text="ADD" runat="server" ID="btnSEAdd" Width="75px" CssClass="CSButton" OnClick="btnSEAdd_Click" /></td>
                                               </tr>
                                                 <tr>
                                                   <td colspan="3">
                                                       <asp:GridView ID="grdSE" runat="server" SkinID="GridViewAA" Width="100%" EmptyDataText="No Data Found.">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="SE_Description" HeaderText="Stakeholder Engagement" />
                                                                            </Columns>
                                                        </asp:GridView>
                                                   </td>
                                               </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width:1%"></td>
                            <td style="width:98%" class="DivTitle">CONTACT AND ADDITIONAL INFORMATION</td>
                            <td style="width:1%"></td>
                        </tr>
                        <tr>
                            <td style="width:1%"></td>
                            <td style="width:98%">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Panel runat="server" ID="pnlContact"  GroupingText="Contact Person" CssClass="panel_border">
                                                <table>
                                                    <tr >
                                                        <td class="column_RightBold">Name :</td>
                                                        <td class="column_Left"><asp:TextBox runat="server" ID="txtContactPersonName" CssClass="txtbox_Var" Width="250px"></asp:TextBox></td>
                                                        <td class="column_RightBold">Contact Details</td>
                                                        <td class="column_Left"><asp:TextBox runat="server" ID="txtContactPersonContactDetails" CssClass="txtbox_Var" Width="250px"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                             <asp:Panel runat="server" ID="Panel1"  GroupingText="Attachment" CssClass="panel_border">
                                                 <table>
                                                     <tr>
                                                         <td class="column_RightBold">Attachment :</td>
                                                         <td class="column_Left"><asp:TextBox runat="server" ID="txtAttachment" CssClass="txtbox_Var" Width="250px"></asp:TextBox></td>
                                                         <td><asp:Button ID="btnAttachmentUpdate" runat="server" Text="UPLOAD" CssClass="CSButton" Width="100px" /></td>
                                                         <td><asp:Button ID="btnAttachmentSave" runat="server" Text="SAVE" CssClass="CSButton" Width="100px" /></td>
                                                         <td rowspan="3" style="width:200px">

                                                             <asp:Image ID="Image3" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />

                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="4">
                                                             <asp:GridView ID="grdAFN" runat="server" SkinID="GridViewAA" Width="100%" EmptyDataText="No Data Found.">
                                                                 <Columns>
                                                                     <asp:BoundField DataField="AFN" HeaderText="Attached File Name" />
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
                            <td style="width:1%"></td>
                        </tr>
                        <tr align="center">
                            <td style="width:1%"></td>
                            <td style="width:98%">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSaveAFN" runat="server" Text="SAVE" CssClass="CSButton" Width="100px" OnClick="btnSaveAFN_Click" />
                                            <asp:Button ID="btnClearAFN" runat="server" Text="CLEAR" CssClass="CSButton" Width="100px" />
                                        </td>

                                    </tr>
                                </table>
                                
                            </td>
                            <tr>
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
                        </tr>
                        
                    </table>
             </div>
         </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>