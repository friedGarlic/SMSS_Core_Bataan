<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false"
    CodeFile="t_DonationList.aspx.vb" Inherits="Records_t_DonationList" Title="List of Donations" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript"> 

        function stopRKey(evt) {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type == "text")) {
                return false;
            }
        }

        document.onkeypress = stopRKey;

    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table width="100%">
                    <tr>
                        <td></td>
                        <td style="text-align:center">
                            <asp:Button ID="btnDTL"  runat="server" Width="250px" Text="Donation To L.G.U" CssClass="Initial"></asp:Button>
                            <asp:Button ID="btnLTL"  runat="server" Width="250px" Text="L.G.U To L.G.U" CssClass="Initial"></asp:Button>
                        </td>
                        <td></td>
                    </tr>
                </table>
            </div>
            <asp:MultiView ID="mvDonation" runat="server">
                <asp:View ID="vwDonationToLGU" runat="server">
                  <table width="100%">
                    <tbody>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">LIST OF DONATIONS
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Search :</span>
                            &nbsp;<asp:DropDownList ID="ddSearch" runat="server" Width="15%" CssClass="drpdownCSS">
                                <asp:ListItem Value="0">ALL</asp:ListItem>
                                <asp:ListItem Value="1">Reference Number</asp:ListItem>
                                <asp:ListItem Value="2">Property Number</asp:ListItem>
                                <asp:ListItem Value="3">Item Description</asp:ListItem>
                                <asp:ListItem Value="4">Donors</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:TextBox ID="txtSearch" runat="server" Width="30%" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnSearch" runat="server" Width="12%" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>                   
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdDonationDtl" runat="server" Width="98%" SkinID="GridViewAA" EmptyDataText="No Records Found" AllowPaging="True" PageSize="15"
                                DataKeyNames="Item_Desc,Property_ID,Item_ID,PropertyDetai_ID,GA_ID">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelect" CssClass="LinkBtnSelect" Text="Preview" Visible='<%#Bind("isVisible") %>' CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="ReferenceNo" HeaderText="Ref No." ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DonorName" HeaderText="Donor Name.">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                     <asp:BoundField DataField="Address" HeaderText="Donor Address.">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="PropertyNo" HeaderText="Property No.">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                        <ItemStyle HorizontalAlign="Left" Width="42%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UnitDesc" HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cost" DataFormatString="{0:N}" HeaderText="Unit Price">
                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Prop_Status" HeaderText="Status" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="5%"></ItemStyle>
                                    </asp:BoundField>

                                </Columns>

                                <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                       <td>

                       </td>
                       <td>
                           <asp:Button runat="server" ID="btnPreview" CssClass="CSButton" Width="15%" Text="Preview All" OnClientClick="StartProgressBar();" />
                       </td>
                   </tr>
                    <tr>
                       <td>

                       </td>
                       <td>
                         
                       </td>
                   </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="100%">
                                <tr>
                                    <td style="width: 75%; vertical-align: top" align="center">
                                        <table width="100%">
                                            <tr style="display:none">
                                                <td style="width: 15%" class="column_RightBold">Brand Name :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtPPE_BrandName" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td style="width: 15%" class="column_RightBold">Warranty :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtPPE_Warranty" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display:none">
                                                <td style="width: 15%" class="column_RightBold">Model :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtPPE_Model" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td style="width: 15%" class="column_RightBold">Salvage Value :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtPPE_SalvageValue" CssClass="txtbox_Amt" Width="50%" Text="0.00" Enabled="false"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtenderSV" TargetControlID="txtPPE_SalvageValue" ValidChars="1234567890,."></cc1:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr style="display:none">
                                                <td style="width: 15%" class="column_RightBold">Serial Number :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtPPE_SerialNo" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td style="width: 15%" class="column_RightBold">Dep. Rate :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtPPE_DepRate" CssClass="txtbox_Amt" Width="50%" Text="0.00" Enabled="false"></asp:TextBox>
                                                    &nbsp;<span class="column_LeftBold">Percent (%)</span>
                                                    <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtenderDR" TargetControlID="txtPPE_DepRate" ValidChars="1234567890,."></cc1:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr style="display:none">
                                                <td style="width: 15%" class="column_RightBold">Power Input :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtPPE_Powerinput" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td style="width: 15%" class="column_RightBold">Dep. Value :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtPPE_DepValue" CssClass="txtbox_Amt" Width="50%" Text="0.00" Enabled="false"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtenderDV" TargetControlID="txtPPE_DepValue" ValidChars="1234567890,."></cc1:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 10px" colspan="4"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" colspan="4">
                                                    <asp:MultiView runat="server" ID="mvPPE_Details">

                                                        <asp:View runat="server" ID="vwMotorVechicle">
                                                            <table width="100%" style="display:none">
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Plate Number :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtMV_PlateNo" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">MV File Number :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtMV_FileNo" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Chasis Number :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtMV_ChasisNo" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">Con. Sticker :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtMV_ConductionSticker" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Engine Number :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtMV_EngineNo" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">Registration Date :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtMV_RegistrationDate" CssClass="txtbox_Date" Width="40%" MaxLength="10" Enabled="false"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtenderRD" TargetControlID="txtMV_RegistrationDate" PopupButtonID="txtMV_RegistrationDate" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtenderRD" TargetControlID="txtMV_RegistrationDate" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Color :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtMV_Color" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                    <td style="width: 35%" class="column_Left"></td>
                                                                </tr>
                                                            </table>
                                                        </asp:View>

                                                        <asp:View runat="server" ID="vwMachinery">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Engine Number :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtMA_EngineNo" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">Service Floor :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtMA_ServiceFloor" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Permit Number :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtMA_PermitNo" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">Dimention :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtMA_Dimension" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Working Load :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtMA_WorkingLoad" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">Location :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtMA_Location" CssClass="txtbox_Var" Width="95%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:View>

                                                    </asp:MultiView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; display:none" colspan="4" align="center">
                                                    <span class="column_RightBold">Specifications :</span>
                                                    &nbsp;<asp:TextBox runat="server" ID="txtPPE_Specifications" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="60%" Height="100px" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                           
                                            <tr>
                                                <td style="width: 100%; display:none;" colspan="4" align="center">
                                                    <asp:Button runat="server" ID="btnEdit_PPEDetails" Text="Edit" Width="15%" CssClass="CSButton" OnClientClick="StartProgressBar();" Enabled="false" />
                                                    &nbsp;<asp:Button runat="server" ID="btnSave_PPEDetails" Text="Save" Width="15%" CssClass="CSButton" OnClientClick="StartProgressBar();" Enabled="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>

                                    <td style="width: 25%; vertical-align: top" align="center">

                                        <table style="width: 100%">
                                            <tr style="display:none">
                                                <td style="width: 20%" class="column_RightBold">Type : </td>
                                                <td style="width: 80%" class="column_Left">
                                                    <asp:TextBox ID="txtDonationType" runat="server" Width="95%" CssClass="txtbox_Var" ReadOnly="true"></asp:TextBox></td>
                                            </tr>
                                            <tr style="display:none">
                                                <td style="width: 20%" class="column_RightBold">Name : </td>
                                                <td style="width: 80%" class="column_Left">
                                                    <asp:TextBox ID="txtDonatedBy" runat="server" Width="95%" CssClass="txtbox_Var" ReadOnly="true"></asp:TextBox></td>
                                            </tr>
                                            <tr style="display:none">
                                                <td style="width: 20%" class="column_RightBold">Address:</td>
                                                <td style="width: 80%" class="column_Left">
                                                    <asp:TextBox ID="txtAddress" runat="server" Width="95%" CssClass="txtbox_Var" ReadOnly="true"></asp:TextBox></td>
                                            </tr>
                                            <tr style="display:none">
                                                <td style="width: 20%" class="column_RightBold">Tel. No : </td>
                                                <td style="width: 80%" class="column_Left">
                                                    <asp:TextBox ID="txtTelephone" runat="server" Width="50%" CssClass="txtbox_Var" ReadOnly="true"></asp:TextBox></td>
                                            </tr>
                                            <tr style="display:none">
                                                <td style="width: 20%" class="column_RightBold">Email : </td>
                                                <td style="width: 80%" class="column_Left">
                                                    <asp:TextBox ID="txtEmail" runat="server" Width="50%" CssClass="txtbox_Var" ReadOnly="true"></asp:TextBox></td>
                                            </tr>
                                        </table>

                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr style="display:none">
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Panel ID="Panel1" runat="server" CssClass="PanelSize" ScrollBars="Vertical" Width="100%">
                                <asp:GridView ID="grdLedger" runat="server" Width="100%" SkinID="GridViewAA">
                                    <Columns>
                                        <asp:BoundField DataField="Trans_Date" DataFormatString="{0:d}" HeaderText="Date">
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Prop_Transaction" HeaderText="Transaction Type">
                                            <ItemStyle HorizontalAlign="Left" Width="8%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Trans_Reference" HeaderText="Reference No.">
                                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Accountable_Person" HeaderText="Accountable Person">
                                            <ItemStyle HorizontalAlign="Left" Width="8%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RC_Name" HeaderText="Office">
                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Accountable_Person" HeaderText="Accepted by">
                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Inspected by">
                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UnitDesc" HeaderText="Unit">
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Debit" HeaderText="Debit Qty">
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DebitAmt" DataFormatString="{0:N}" HeaderText="Debit Cost">
                                            <ItemStyle HorizontalAlign="Right" Width="7%" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Credit" HeaderText="Credit Qty">
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CreditAmt" DataFormatString="{0:N}" HeaderText="Credit Cost">
                                            <ItemStyle HorizontalAlign="Right" Width="7%" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Balance" HeaderText="Balance Qty">
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BalanceAmt" DataFormatString="{0:N}" HeaderText="Balance Cost">
                                            <ItemStyle HorizontalAlign="Right" Width="7%" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
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
                            
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 30px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                        </tbody>
                </table>
                </asp:View>
                 <asp:View ID="vwLGUToLGU" runat="server">
                     <table width="1020px">
                         <tbody>
                             <tr>
                                 <td></td>
                                 <td style="width: 98%" class="PageTitle">L.G.U To L.G.U Report</td>
                                 <td></td>
                             </tr>
                              <tr>
                                 <td></td>
                                 <td class="column_RightBold"></td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td></td>
                                 <td>
                                     <asp:GridView ID="grLGUToLGU" runat="server" AutoGenerateColumns="False" SkinID="GridViewAA" DataKeyNames="DonationLGUtoLGU_ID,Date_Issued,LGU_Department,Remarks">
                                        <Columns>
                                            <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkPreview" OnClick="lnkPreview_Click"  runat="server" Text="Preview" CssClass="LinkBtnPreview" CausesValidation="False" CommandName="Select"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Date_Issued" HeaderText="Date Issued" />
                                            <asp:BoundField DataField="LGU_Department" HeaderText="Department" />
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                             <asp:BoundField DataField="Item_Description" HeaderText="Description" />
                                             <asp:BoundField DataField="Description" HeaderText="Unit" />
                                             <asp:BoundField DataField="Qty" HeaderText="Quantity" />
                                             <asp:BoundField DataField="Cost" HeaderText="Amount" />
                                        </Columns>
                                          <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
                                    </asp:GridView>
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                  <td></td>
                                  <td align="center"><asp:Button ID="btnPreviewAllLGUToLGU" runat="server" Text="Preview All" CssClass="CSButton" Width="150px" /></td>
                                  <td></td>
                             </tr>
                         </tbody>
                     </table>
                </asp:View>
            </asp:MultiView>
            <div>
               
            </div>


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

