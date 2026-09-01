<%@ Page 
    Language="VB" 
    Title="Eligibility Requirements"
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false"
    CodeFile="eligibility_Limited.aspx.vb" 
    Inherits="bidding_eligibility_Limited"
    StylesheetTheme="SkinFile"
    EnableEventValidation="false" %>



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
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">BID OPENING</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">

                            <asp:GridView runat="server" ID="grdProjects" SkinID="GridViewAA" Width="100%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="10"
                                DataKeyNames="pre_procurement_hdr_id,ABC">
                                <Columns>
                                    <asp:BoundField DataField="project_reference_no" HeaderText="Reference Number">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="project_name" HeaderText="Project Name">
                                        <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BidOpening_Place" HeaderText="Bid Location">
                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="Total ABC">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FundDesc" HeaderText="Fund Source">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BidCategory" HeaderText="Bidding Category">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
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
                            <table cellpadding="0px" cellspacing="0px" width="100%">
                                <tr>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab1_Eligibility" Width="100%" Text="Eligibility Documents" CssClass="TabButton_Active" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab2_Technical" Width="100%" Text="Technical Documents" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab3_Summary" Width="100%" Text="Summary" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 40%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="4" class="PanelTabs">
                                        <asp:MultiView runat="server" ID="mvTabs">

                                            <asp:View runat="server" ID="vwTab1_Eligibility">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdEqligibility" SkinID="GridViewAA" Width="100%" EmptyDataText="No Data Found." AllowPaging="false"
                                                                DataKeyNames="Supplier_ID">
                                                                <Columns>
                                                                    <asp:BoundField DataField="SuppName" HeaderText="Bidders">
                                                                        <ItemStyle HorizontalAlign="Left" Width="12%"></ItemStyle>
                                                                    </asp:BoundField>

                                                                    <asp:TemplateField HeaderText="PHILGEPS Certificate - Plantinum Membership">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbPhilgeps" Checked='<%#Bind("Philgeps")%>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Statement of all Ongoing Government and Private Contracts">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbOngoing" Checked='<%#Bind("isOngoing")%>' />
                                                                            <br />
                                                                            <asp:TextBox runat="server" ID="txtOngoing" CssClass="txtbox_Var" Width="95%" Text='<%#Bind("OngoingContracts")%>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Statement of Single Largest Completed Contract (SLCC)">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbSLCC" Checked='<%#Bind("isSLCC")%>' />
                                                                            <br />
                                                                            <asp:TextBox runat="server" ID="txtSLCC" CssClass="txtbox_Var" Width="95%" Text='<%#Bind("SLCC")%>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="NFCC Computation or Committed Line of Credit">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbNFCC" Checked='<%#Bind("isNFCC")%>' />
                                                                            <br />
                                                                            <asp:TextBox runat="server" ID="txtNFCC" CssClass="txtbox_Var" Width="95%" Text='<%#Bind("NFCC")%>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Joint Venture Agreement (JVA)">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbJVA" Checked='<%#Bind("isJVA")%>' />
                                                                            <br />
                                                                            <asp:TextBox runat="server" ID="txtJVA" CssClass="txtbox_Var" Width="95%" Text='<%#Bind("JVA")%>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Supplier_ID" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="lblSupplier_ID" Text='<%#Bind("Supplier_ID")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 15px" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button runat="server" ID="btnSaveEligibility" CssClass="CSButton" Enabled="false" Width="15%" Text="Save" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 15px" align="center"></td>
                                                    </tr>
                                                </table>
                                                <asp:HiddenField ID="hndBid_security" runat="server" />
                                            </asp:View>



                                            <asp:View runat="server" ID="vwTab2_Technical">
                                                <table width="100%">
                                                   <tr>
                                                        <td style="width: 100%; height: 5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">Project Requirements
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdProjectRequirements" SkinID="GridViewAA" Width="98%" EmptyDataText="No Data Found." AllowPaging="false"
                                                                DataKeyNames="reqID" AutoGenerateColumns="false">
                                                                <Columns>

                                                                    <asp:TemplateField HeaderText="Criteria">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox runat="server" ID="txtCriteria" CssClass="txtbox_Var" Width="95%" Text='<%#Bind("Criteria") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="40%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:Label runat="server" ID="BidderA" Text="BidderA"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbA" Checked='<%#Bind("Supp1_isPass") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:Label runat="server" ID="BidderB" Text="BidderB"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbB" Checked='<%#Bind("Supp2_isPass") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:Label runat="server" ID="BidderC" Text="BidderC"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbC" Checked='<%#Bind("Supp3_isPass") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:Label runat="server" ID="BidderD" Text="BidderD"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbD" Checked='<%#Bind("Supp4_isPass") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:Label runat="server" ID="BidderE" Text="BidderE"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbE" Checked='<%#Bind("Supp5_isPass") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Criteria :</span>
                                                            &nbsp;<asp:TextBox runat="server" ID="txtCriteria" CssClass="txtbox_Var" Width="40%"></asp:TextBox>
                                                            &nbsp;<asp:Button runat="server" ID="btnAddCriteria" CssClass="CSButton" Width="12%" Text="Add Criteria" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">Bid Security Details
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Panel ID="Panel2" runat="server" Width="98%" Font-Bold="True" CssClass="PanelSize" HorizontalAlign="Center" ScrollBars="Vertical">
                                                                        <asp:GridView ID="grdBidderList" runat="server" Width="100%" DataKeyNames="Supplier_Id"
                                                                            SkinID="GridViewAA" EmptyDataText="No Data Found.">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Bid Security Details">
                                                                                    <ItemTemplate>
                                                                                        <table width="100%">
                                                                                            <tr>
                                                                                                <td style="width: 100%" colspan="2" align="center">
                                                                                                    <span class="column_RightBold">Bidder Name :</span>
                                                                                                    &nbsp;<asp:Label ID="lblBidder" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="11pt" Text='<%#Bind("SuppName") %>'></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%" align="center">
                                                                                                    <table width="100%">

                                                                                                        <tr>
                                                                                                            <td style="width: 100%; height: 15px" colspan="2"></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 30%" class="column_RightBold">Form of Bid Security :</td>
                                                                                                            <td style="width: 70%" class="column_Left">
                                                                                                                <asp:DropDownList ID="drpForm1" runat="server" Width="40%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="drpForm1_SelectedIndexChanged"></asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 30%" class="column_RightBold">Required Bid Security :</td>
                                                                                                            <td style="width: 70%" class="column_Left">
                                                                                                                <asp:TextBox ID="txtBidSecAmt_1" runat="server" Width="40%" CssClass="txtbox_Amt" Text="0.00" ReadOnly="True"></asp:TextBox>

                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 30%" class="column_RightBold">Total Bid Amount :</td>
                                                                                                            <td style="width: 70%" class="column_Left">
                                                                                                                <asp:TextBox ID="txtReqBidSec_1" runat="server" Width="40%" CssClass="txtbox_Amt" Text="0.00" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789.," TargetControlID="txtReqBidSec_1">
                                                                                                                 </cc1:FilteredTextBoxExtender>
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr>
                                                                                                            <td style="width: 30%" class="column_RightBold">Bank / Company :</td>
                                                                                                            <td style="width: 70%" class="column_Left">
                                                                                                                <asp:TextBox ID="txtBankName_1" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 30%" class="column_RightBold">OR / Bank Number :</td>
                                                                                                            <td style="width: 70%" class="column_Left">
                                                                                                                <asp:TextBox ID="txtNumber_1" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 30%" class="column_RightBold">Validity Period :</td>
                                                                                                            <td style="width: 70%" class="column_Left">
                                                                                                                <asp:TextBox ID="txtValidityPeriod1" runat="server" Width="20%" CssClass="txtbox_Amt" Text="0"></asp:TextBox>
                                                                                                                &nbsp;<span class="column_RightBold">Days</span>
                                                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtValidityPeriod1" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>

                                                                                                </td>
                                                                                                <td style="width: 50%" align="center">
                                                                                                    <table width="100%">

                                                                                                        <tr>
                                                                                                            <td style="width: 100%; height: 15px" colspan="2"></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 30%" class="column_RightBold">Form of Bid Security :</td>
                                                                                                            <td style="width: 70%" class="column_Left">
                                                                                                                <asp:DropDownList ID="drpForm2" runat="server" Width="40%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="drpForm2_SelectedIndexChanged"></asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 30%" class="column_RightBold">Required Bid Security :</td>
                                                                                                            <td style="width: 70%" class="column_Left">
                                                                                                                <asp:TextBox ID="txtBidSecAmt_2" runat="server" Width="40%" CssClass="txtbox_Amt" Text="0.00" ReadOnly="True"></asp:TextBox>
                                                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtBidSecAmt_2" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 30%" class="column_RightBold">Total Bid Amount :</td>
                                                                                                            <td style="width: 70%" class="column_Left">
                                                                                                                <asp:TextBox ID="txtReqBidSec_2" runat="server" Width="40%" CssClass="txtbox_Amt" Text="0.00" ReadOnly="True"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 30%" class="column_RightBold">Bank / Company :</td>
                                                                                                            <td style="width: 70%" class="column_Left">
                                                                                                                <asp:TextBox ID="txtBankName_2" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 30%" class="column_RightBold">OR / Bank Number :</td>
                                                                                                            <td style="width: 70%" class="column_Left">
                                                                                                                <asp:TextBox ID="txtNumber_2" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 30%" class="column_RightBold">Validity Period :</td>
                                                                                                            <td style="width: 70%" class="column_Left">
                                                                                                                <asp:TextBox ID="txtValidityPeriod2" runat="server" Width="20%" CssClass="txtbox_Amt" Text="0"></asp:TextBox>
                                                                                                                &nbsp;<span class="column_RightBold">Days</span>
                                                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtValidityPeriod2" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 15px" colspan="2" align="center">
                                                                                                    <asp:Label runat="server" ID="lblBorder" BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" Width="95%"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" colspan="2" align="center">
                                                                                                    <table width="100%">
                                                                                                        <tr>
                                                                                                            <td style="width: 30%" align="center"></td>
                                                                                                            <td style="width: 30%" align="center">
                                                                                                                <span class="column_RightBold">Status :</span>
                                                                                                                &nbsp;<asp:Label ID="lblStatus" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="11pt"></asp:Label>

                                                                                                            </td>
                                                                                                            <td style="width: 40%" align="center">
                                                                                                                <span class="column_RightBold">Remarks :</span>
                                                                                                                &nbsp;<asp:TextBox ID="txtRemarks" runat="server" Width="70%" CssClass="txtbox_Var" Visible='<%#Bind("isVisible") %>'></asp:TextBox>

                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>

                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        <br />
                                                                                        <br />
                                                                                    </ItemTemplate>

                                                                                    <ItemStyle Width="50%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="Status" HeaderText="Status" Visible="False">
                                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="12%"></ItemStyle>
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                            <FooterStyle BackColor="#2977DC"></FooterStyle>
                                                                            <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                                                                        </asp:GridView>
                                                                    </asp:Panel>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td style="width: 100%; height: 5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">Other Criteria
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdOtherCriteria" SkinID="GridViewAA" Width="98%" EmptyDataText="No Data Found." AllowPaging="false"
                                                                DataKeyNames="" AutoGenerateColumns="false">
                                                                <Columns>
                                                                    <asp:BoundField DataField="SuppName" ItemStyle-Width="60%" ItemStyle-HorizontalAlign="Left" HeaderText="Bidder's Name" />

                                                                    <asp:TemplateField HeaderText="Omnibus Sworn Statement">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbOmnibus" Checked='<%#Bind("omnibus") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="The Signatory is the duly authorized representative of the prospective bidder">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbauthorized" Checked='<%#Bind("authorized_rep") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button runat="server" ID="btnSaveTechDocs" CssClass="CSButton" Enabled="false" Width="15%" Text="Save" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 15px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>



                                            <asp:View runat="server" ID="vwTab3_Summary">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdSummary" SkinID="GridViewAA" Width="90%" EmptyDataText="No Data Found." AllowPaging="false"
                                                                DataKeyNames="Supplier_ID" AutoGenerateColumns="false">
                                                                <Columns>
                                                                    <asp:BoundField DataField="SuppName" ItemStyle-Width="65%" ItemStyle-HorizontalAlign="Left" HeaderText="Bidder's Name" />

                                                                    <asp:TemplateField HeaderText="Total Amount">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox runat="server" ID="txtTotalAmt" CssClass="txtbox_Amt" Width="95%" text='<%#Bind("calculatedAmount", "{0:N}") %>' AutoPostBack="true" OnTextChanged="txtTotalAmt_OnTextChanged" Enabled="false"></asp:TextBox>
                                                                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtTotalAmt" ValidChars="1234567890.,"></cc1:FilteredTextBoxExtender>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Remarks">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbRemarks" Checked='<%#Bind("isPass") %>'/>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                    </asp:TemplateField>

                                                                     <asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="lblSupplier_ID" text='<%#Bind("Supplier_ID") %>'> </asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button runat="server" ID="btnSaveSummary" CssClass="CSButton" Enabled="false" Width="15%" Text="Save" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 15px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>

                                        </asp:MultiView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                  
                </table>
            </div>



            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


