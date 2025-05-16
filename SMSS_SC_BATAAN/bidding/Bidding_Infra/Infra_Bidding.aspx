<%@ Page Title="Infra - Bidding" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Infra_Bidding.aspx.vb" Inherits="bidding_Bidding_Infra_Infra_Bidding" StylesheetTheme="SkinFile" %>

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

        function toPeso(objctrl) {
            //Get the Entered Value
            var number = objctrl.value.toString(),
                //Split the number between WholeNumber and Decimals
                php = number.split('.')[0], cents = (number.split('.')[1] || '') + '00';
            php = php.split('').reverse().join('').replace(/(\d{3}(?!$))/g, '$1,').split('').reverse().join('');
            //Concatenate the number 
            objctrl.value = php + '.' + cents.slice(0, 2);
        }

    </script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">INFRA - BIDDING</td>
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
                                        <asp:Button runat="server" ID="btnTab1_Opening" Width="100%" Text="Bid Opening" CssClass="TabButton_Active" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab2_Abstract" Width="100%" Text="Abstract" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab3_Evaluation" Width="100%" Text="Evaluation" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab4_PostQua" Width="100%" Text="Post Qualification" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="5" class="PanelTabs">
                                        <asp:MultiView runat="server" ID="mvTabs">


                                            <asp:View runat="server" ID="vwTab1_Opening">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Search by :</span>
                                                            &nbsp;<asp:DropDownList runat="server" ID="drpSearch_Opening" CssClass="drpdownCSS" Width="12%">
                                                                <asp:ListItem Value="1" Text="ITB Number" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Project Name"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:TextBox runat="server" ID="txtSearch_Opening" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                            &nbsp;<asp:Button runat="server" ID="btnSearch_Opening" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdOpening" SkinID="GridViewAA" Width="98%" AllowPaging="true" PageSize="12" EmptyDataText="No Data Found."
                                                                DataKeyNames="Infra_BidPrep_ID,BidDoc_Amt">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkSelect" Text="Select" CssClass="LinkBtnSelect" OnClick="lnkSelect_OnClick" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" DataField="BidOpen_Date" HeaderText="Bid Opening Date" DataFormatString="{0:d}" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" DataField="ITB_No" HeaderText="ITB Number" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="54%" DataField="PPA" HeaderText="Project Name" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="12%" DataField="Amount" HeaderText="ABC" DataFormatString="{0:N}" />

                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkDone" Text="Done" CssClass="LinkBtnSelect" OnClick="lnkDone_OnClick" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">

                                                            <table width="90%">
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Bidder :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList runat="server" ID="drpSupplier" CssClass="drpdownCSS" Width="95%"></asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                    <td style="width: 35%" class="column_Left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Form of Bid Security :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList runat="server" ID="drpBidSecurity1" CssClass="drpdownCSS" Width="50%"></asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">Form of Bid Security :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList runat="server" ID="drpBidSecurity2" CssClass="drpdownCSS" Width="50%"></asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Bank / Company</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtCompany" CssClass="txtbox_Var" Width="95%" Text=""></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                    <td style="width: 35%" class="column_Left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Number</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtNumber" CssClass="txtbox_Var" Width="50%" Text=""></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                    <td style="width: 35%" class="column_Left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">OR Number</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtOR" CssClass="txtbox_Var" Width="50%" Text=""></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                    <td style="width: 35%" class="column_Left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Validity Period </td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtValidity" CssClass="txtbox_Var" Width="50%" Text=""></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                    <td style="width: 35%" class="column_Left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Bid Security Amount :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtBidSec_Amt1" CssClass="txtbox_Amt" Width="30%" Text="0.00" onblur="toPeso(this)"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender" TargetControlID="txtBidSec_Amt1" ValidChars="1234567890.,"></cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">Bid Security Amount :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtBidSec_Amt2" CssClass="txtbox_Amt" Width="30%" Text="0.00" onblur="toPeso(this)"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtBidSec_Amt2" ValidChars="1234567890.,"></cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Req. Bid Security :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtBidSec_Req1" CssClass="txtbox_Amt" Width="30%" Text="0.00" onblur="toPeso(this)"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender2" TargetControlID="txtBidSec_Req1" ValidChars="1234567890.,"></cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">Req. Bid Security :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtBidSec_Req2" CssClass="txtbox_Amt" Width="30%" Text="0.00" onblur="toPeso(this)"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender3" TargetControlID="txtBidSec_Req2" ValidChars="1234567890.,"></cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Sufficient :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtSufficient" CssClass="txtbox_Var" Width="50%" Text="Sufficient"></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                    <td style="width: 35%" class="column_Left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Remarks</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtRemarks" CssClass="txtbox_Var" Width="95%" Text=""></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                    <td style="width: 35%" class="column_Left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100%; height: 20px" colspan="4" align="center"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_LeftBold"></td>
                                                                    <td style="width: 85%" colspan="3" class="column_LeftBold">
                                                                        <asp:CheckBox runat="server" ID="cbOmnibus" Text="Omnibus Sworn Statement" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_LeftBold"></td>
                                                                    <td style="width: 85%" colspan="3" class="column_LeftBold">
                                                                        <asp:CheckBox runat="server" ID="cbAuthorized" Text="The Signatory is the duly authorized representative of the prospective bidder" />
                                                                    </td>

                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100%; height: 10px" colspan="4" align="center"></td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="width: 100%" colspan="4" align="center">
                                                                        <asp:Button runat="server" ID="btnAdd_Supplier" CssClass="CSButton" Width="15%" Enabled="false" Text="Save Details" OnClientClick="StartProgressBar();" />
                                                                    </td>
                                                                </tr>
                                                            </table>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">List of Bidder
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdBidders" SkinID="GridViewAA" Width="90%" AllowPaging="false" EmptyDataText="No Data Found."
                                                                DataKeyNames="Infra_Bidders_ID,Suppier_ID,SuppName">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkPreview_OP" Text="Order of Payment" CssClass="LinkBtnSelect" OnClick="lnkPreview_OP_OnClick" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="35%" DataField="SuppName" HeaderText="Bidder Name" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="30%" DataField="Address1" HeaderText="Address" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="15%" DataField="ContactP" HeaderText="Contact Person" />

                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkRemove" Text="Remove" CssClass="LinkBtnCancel" OnClick="lnkRemove_OnClick" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                            <cc1:ConfirmButtonExtender runat="server" ID="ConfirmButtonExtender" TargetControlID="lnkRemove" ConfirmText="Are you sure to remove this bidder?"></cc1:ConfirmButtonExtender>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">Eligibility Documents
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdEqligibility" SkinID="GridViewAA" Width="98%" EmptyDataText="No Data Found." AllowPaging="false"
                                                                DataKeyNames="Supplier_ID">
                                                                <Columns>
                                                                    <asp:BoundField DataField="SuppName" HeaderText="Bidders">
                                                                        <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                                                    </asp:BoundField>

                                                                    <asp:TemplateField HeaderText="PHILGEPS Certificate - Plantinum Membership">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbPhilgeps" Checked='<%#Bind("PhilGEPS_Cert")%>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Statement of all Ongoing Government and Private Contracts">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbOngoing" Checked='<%#Bind("OnGoing")%>' />
                                                                            <br />
                                                                            <asp:TextBox runat="server" ID="txtOngoing" CssClass="txtbox_Var" Width="95%" Text='<%#Bind("OnGoing_Remarks")%>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Statement of Single Largest Completed Contract (SLCC)">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbSLCC" Checked='<%#Bind("SLCC")%>' />
                                                                            <br />
                                                                            <asp:TextBox runat="server" ID="txtSLCC" CssClass="txtbox_Var" Width="95%" Text='<%#Bind("SLCC_Remakrs")%>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="NFCC Computation or Committed Line of Credit">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbNFCC" Checked='<%#Bind("NFCC")%>' />
                                                                            <br />
                                                                            <asp:TextBox runat="server" ID="txtNFCC" CssClass="txtbox_Var" Width="95%" Text='<%#Bind("NFCC_Remarks")%>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Joint Venture Agreement (JVA)">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbJVA" Checked='<%#Bind("JVA")%>' />
                                                                            <br />
                                                                            <asp:TextBox runat="server" ID="txtJVA" CssClass="txtbox_Var" Width="95%" Text='<%#Bind("JVA_Remarks")%>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Supplier_ID" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="lblSupplier_ID" Text='<%#Bind("Supplier_ID")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
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
                                                            <asp:Button runat="server" ID="btnSave_Eligibility" CssClass="CSButton" Width="15%" Text="Save Eligibility" Enabled="false" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 30px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>



                                            <asp:View runat="server" ID="vwTab2_Abstract">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdAbstract" SkinID="GridViewAA" Width="90%" AllowPaging="true" PageSize="12" EmptyDataText="No Data Found."
                                                                DataKeyNames="Infra_BidPrep_ID,RC_ID,Function_ID">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkAbstract_Select" Text="Select" CssClass="LinkBtnSelect" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClick="lnkAbstract_Select_OnClick" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" DataField="ITB_No" HeaderText="ITB Number" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60%" DataField="PPA" HeaderText="Project Name" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%" DataField="Amount" HeaderText="ABC" DataFormatString="{0:N}" />

                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkAbstract_Back" Text="Back" CssClass="LinkBtnCancel" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClick="lnkAbstract_Back_OnClick" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">List of Bidders
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdAbstract_Bidders" SkinID="GridViewAA" Width="70%" AllowPaging="true" PageSize="12" EmptyDataText="No Data Found."
                                                                DataKeyNames="Supplier_ID">
                                                                <Columns>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="80%" DataField="SuppName" HeaderText="Bidder's Name" />

                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" HeaderText="Bid Amount">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox runat="server" ID="txtBidAmount" CssClass="txtbox_Amt" Text='<%#Bind("BidAmount", "{0:N}") %>' Width="90%" Visible='<%#Bind("isVisible") %>' OnTextChanged="txtBidAmount_OnTextChanged" AutoPostBack="true"></asp:TextBox>
                                                                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender" TargetControlID="txtBidAmount" ValidChars="1234567890.,"></cc1:FilteredTextBoxExtender>
                                                                        </ItemTemplate>
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
                                                            <table width="90%">
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Date :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtAbstract_Date" CssClass="txtbox_Date" Width="30%" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtAbstract_Date" PopupButtonID="txtAbstract_Date" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender4" TargetControlID="txtAbstract_Date" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>

                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                    <td style="width: 35%" class="column_Left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Time :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtAbstract_Time" CssClass="txtbox_Date" Width="20%" Text="8:30" MaxLength="5"></asp:TextBox>
                                                                        &nbsp;<span class="column_CenterBold"> : </span>
                                                                        &nbsp;<asp:DropDownList runat="server" ID="drpAbstract_Time" CssClass="drpdownCSS" Width="20%">
                                                                            <asp:ListItem Value="1" Text="A.M." Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="P.M."></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                    <td style="width: 35%" class="column_Left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%; height: 15px" class="column_RightBold"></td>
                                                                    <td style="width: 35%" class="column_Left"></td>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                    <td style="width: 35%" class="column_Left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">GSO : </td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList ID="drpGSO" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">BAC Vice Chairman : </td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList ID="drpBACVC" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Budget : </td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList ID="drpCBO" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">BAC Chairman : </td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList ID="drpBACC" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Engineering : </td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList ID="drpCEO" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">Requested by : </td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList ID="drpEndUser" runat="server" Width="95%" CssClass="drpdownCSS">
                                                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>

                                                            </table>


                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button runat="server" ID="btnAbstract_Save" CssClass="CSButton" Width="12%" Text="Save" Enabled="false" OnClientClick="StartProgressBar();" />
                                                            &nbsp;<asp:Button runat="server" ID="btnAbstract_Preview" CssClass="CSButton" Width="12%" Text="Preview" Enabled="false" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 30px" align="center"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>



                                            <asp:View runat="server" ID="vwTab3_Evaluation">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Search by :</span>
                                                            &nbsp;<asp:DropDownList runat="server" ID="drpEval_Search" CssClass="drpdownCSS" Width="12%">
                                                                <asp:ListItem Value="1" Text="ITB Number" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Project Name"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:TextBox runat="server" ID="txtEval_Search" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                            &nbsp;<asp:Button runat="server" ID="btnEval_Search" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdEvaluation" SkinID="GridViewAA" Width="90%" AllowPaging="true" PageSize="12" EmptyDataText="No Data Found."
                                                                DataKeyNames="Infra_BidPrep_ID,PPA,ITB_No">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkEval_Select" Text="Select" CssClass="LinkBtnSelect" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" DataField="ITB_No" HeaderText="ITB Number" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="65%" DataField="PPA" HeaderText="Project Name" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%" DataField="Amount" HeaderText="ABC" DataFormatString="{0:N}" />

                                                                    <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkEval_Back" Text="Back" CssClass="LinkBtnCancel" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClick="lnkEval_Back_OnClick" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">Details
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="98%">
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <div class="borderCSS_CurveEdge" style="width: 95%">
                                                                            <table width="90%">
                                                                                <tr>
                                                                                    <td style="width: 100%; height: 10px" colspan="2" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 100%" colspan="2" align="right">
                                                                                        <asp:Label runat="server" ID="lblEval_ITB1" CssClass="column_CenterBold" Text="ITB21-00-000"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 100%" colspan="2" align="right">
                                                                                        <span class="column_RightBold">Date Evaluated :</span>
                                                                                        <asp:Label runat="server" ID="lblEval_Date1" CssClass="column_CenterBold" Text=" - "></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%; height: 10px" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center">
                                                                                        <asp:Image runat="server" ID="imgLogo" ImageUrl="~/images/Logo/Pasay Logo.jpg" Width="100px" Height="100px" />
                                                                                    </td>
                                                                                    <td style="width: 70%" align="center">
                                                                                        <span class="ReportEncoding_Title">BID EVALUATION REPORT</span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center">
                                                                                        <span class="column_CenterBold">BIDS AND AWARDS COMMITTEE TECHNICAL WORKING GROUP</span>
                                                                                    </td>
                                                                                    <td style="width: 70%" align="left">
                                                                                        <span class="column_LeftBold">1.0 PROJECT IDENTIFICATION</span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%" align="center">
                                                                                        <asp:TextBox runat="server" ID="txtEval_1" Width="85%" Height="120px" CssClass="txtbox_Encoding" Text="" TextMode="MultiLine"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%; height: 10px" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%" align="center">
                                                                                        <span class="column_Center">Table 1. Identification</span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center" rowspan="6">
                                                                                        <table width="98%">
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">ATTY. RAY GLENN C. AGRANZAMENDEZ
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_Center">Chairman
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">MEMBERS
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">JULIUS V. GARACHICO
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_Center">Computer Programmer III
                                                                    <br>
                                                                                                    (Information & Communication Equipment)
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">ALTERNATIVE MEMBERS
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">DR. MA. AUREA A. LATON
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_Center">Medical Officer IV
                                                                    <br>
                                                                                                    City Health Office
                                                                    <br>
                                                                                                    (for procurement of Drugs & Medicine)
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">ENGR. PATRICIA C. ALMONEDA
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_Center">Engineer III
                                                                    <br>
                                                                                                    City Engineer's Office
                                                                    <br>
                                                                                                    (For infrastructure Project)
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold"></td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold"></td>
                                                                                            </tr>

                                                                                        </table>
                                                                                    </td>
                                                                                    <td style="width: 70%" align="center">
                                                                                        <table width="87%" style="border-style: solid; border-width: 1px; border-radius: 5px">
                                                                                            <tr>
                                                                                                <td style="width: 40%" class="column_Left">1.1 Purchaser (or Employer)</td>
                                                                                                <td style="width: 60%" class="column_Left"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 40%; text-indent: 40pt" class="column_Left">(a) Name</td>
                                                                                                <td style="width: 60%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt1_Name" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 40%; text-indent: 40pt" class="column_Left">(b) Address</td>
                                                                                                <td style="width: 60%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt1_Address" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 40%" class="column_Left">1.2 Name of the Project</td>
                                                                                                <td style="width: 60%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt1_ProjectName" CssClass="txtbox_Encoding" Height="60px" Width="90%" Text="" TextMode="MultiLine"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 40%" class="column_Left">1.3 Location of the Project</td>
                                                                                                <td style="width: 60%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt1_ProjectLoc" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 40%" class="column_Left">1.4 Approved Budget of Contract</td>
                                                                                                <td style="width: 60%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt1_ABC" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 40%" class="column_Left">1.5 Method of Procurement</td>
                                                                                                <td style="width: 60%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt1_MOP" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 70%; height: 10px" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 70%" align="left">
                                                                                        <span class="column_LeftBold">2.0 INITIAL STEPS IN THE BIDDING PROCESS</span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 70%" align="center">
                                                                                        <asp:TextBox runat="server" ID="txtEval_2" Width="85%" Height="220px" CssClass="txtbox_Encoding" Text="" TextMode="MultiLine"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 70%; height: 30px" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 70%" align="justify">
                                                                                        <asp:Label runat="server" ID="lblEval_Footer1" CssClass="column_LeftBold" Text=""></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%; height: 30px" align="center"></td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100%; height: 20px" align="center"></td>
                                                                </tr>



                                                                <%-- PAGE 2--%>
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <div class="borderCSS_CurveEdge" style="width: 95%">
                                                                            <table width="90%">
                                                                                <tr>
                                                                                    <td style="width: 100%; height: 10px" colspan="2" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 100%" colspan="2" align="right">
                                                                                        <asp:Label runat="server" ID="lblEval_ITB2" CssClass="column_CenterBold" Text="ITB21-00-000"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 100%" colspan="2" align="right">
                                                                                        <span class="column_RightBold">Date Evaluated :</span>
                                                                                        <asp:Label runat="server" ID="lblEval_Date2" CssClass="column_CenterBold" Text=" - "></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%; height: 10px" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center">
                                                                                        <asp:Image runat="server" ID="Image1" ImageUrl="~/images/Logo/Pasay Logo.jpg" Width="100px" Height="100px" />
                                                                                    </td>
                                                                                    <td style="width: 70%" align="center" rowspan="2">
                                                                                        <asp:TextBox runat="server" ID="txtEval_2B" Width="85%" Height="200px" CssClass="txtbox_Encoding" Text="" TextMode="MultiLine"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center">
                                                                                        <span class="column_CenterBold">BIDS AND AWARDS COMMITTEE TECHNICAL WORKING GROUP</span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%; height: 10px" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%" align="center">
                                                                                        <span class="column_Center">Table 2. Initial Steps in the Bidding Process</span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center" rowspan="6">
                                                                                        <table width="98%">
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">ATTY. RAY GLENN C. AGRANZAMENDEZ
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_Center">Chairman
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">MEMBERS
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">JULIUS V. GARACHICO
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_Center">Computer Programmer III
                                                                    <br>
                                                                                                    (Information & Communication Equipment)
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">ALTERNATIVE MEMBERS
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">DR. MA. AUREA A. LATON
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_Center">Medical Officer IV
                                                                    <br>
                                                                                                    City Health Office
                                                                    <br>
                                                                                                    (for procurement of Drugs & Medicine)
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">ENGR. PATRICIA C. ALMONEDA
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_Center">Engineer III
                                                                    <br>
                                                                                                    City Engineer's Office
                                                                    <br>
                                                                                                    (For infrastructure Project)
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold"></td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold"></td>
                                                                                            </tr>

                                                                                        </table>
                                                                                    </td>
                                                                                    <td style="width: 70%" align="center">
                                                                                        <table width="87%" style="border-style: solid; border-width: 1px; border-radius: 5px">
                                                                                            <tr>
                                                                                                <td style="width: 50%" class="column_Left">2.1 Pre-Procurement Conference</td>
                                                                                                <td style="width: 50%" class="column_Left"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%; text-indent: 20pt" class="column_Left">(a) Date of Conference</td>
                                                                                                <td style="width: 50%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt2_DateConf" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%" class="column_Left">2.2 Invitation to Apply for Eligibility and to Bid</td>
                                                                                                <td style="width: 50%" class="column_Center"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%; text-indent: 20pt" class="column_Left">(a) Date of publication/posting</td>
                                                                                                <td style="width: 50%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt2_DatePub" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%; text-indent: 20pt" class="column_Left">(b) Name of newspaper/website</td>
                                                                                                <td style="width: 50%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt2_Website" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%" class="column_Left">2.3 Eligibility Check</td>
                                                                                                <td style="width: 50%" class="column_Center"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%; text-indent: 20pt" class="column_Left">(a) Date of eligibility check</td>
                                                                                                <td style="width: 50%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt2_DateEligible" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%; text-indent: 10pt" class="column_Left">(b) Number of eligibility envelopes received</td>
                                                                                                <td style="width: 50%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt2_Envelop" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%; text-indent: 20pt" class="column_Left">(c) Date of Notices sent to bidders</td>
                                                                                                <td style="width: 50%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt2_DateNotice" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%; text-indent: 20pt" class="column_Left">(d) Motions for Reconsideration, if any</td>
                                                                                                <td style="width: 50%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt2_Motion" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%" class="column_Left">2.4 Issuance of Bidding Documents</td>
                                                                                                <td style="width: 50%" class="column_Center"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%; text-indent: 20pt" class="column_Left">(a) Period of availability of Bid Docs</td>
                                                                                                <td style="width: 50%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt2_Period" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%; text-indent: 20pt" class="column_Left">(b) Number of Bid Docs issued</td>
                                                                                                <td style="width: 50%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt2_BidDocsIssued" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%" class="column_Left">2.5 Amendment to Bidding docs, if any</td>
                                                                                                <td style="width: 50%" class="column_Center"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%; text-indent: 20pt" class="column_Left">(a) List all issue dates</td>
                                                                                                <td style="width: 50%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt2_ListDate" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%" class="column_Left">2.6 Pre-bid Conference, if any</td>
                                                                                                <td style="width: 50%" class="column_Center"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%; text-indent: 20pt" class="column_Left">(a) Date of Conference</td>
                                                                                                <td style="width: 50%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt2_DateConf2" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%; text-indent: 20pt" class="column_Left">(b) Date of Minutes sent to bidders</td>
                                                                                                <td style="width: 50%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt2_DateMinutes" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 70%; height: 30px" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 70%" align="justify">
                                                                                        <asp:Label runat="server" ID="lblEval_Footer2" CssClass="column_LeftBold" Text=""></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%; height: 30px" align="center"></td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100%; height: 20px" align="center"></td>
                                                                </tr>


                                                                <%-- PAGE 3--%>
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <div class="borderCSS_CurveEdge" style="width: 95%">
                                                                            <table width="90%">
                                                                                <tr>
                                                                                    <td style="width: 100%; height: 10px" colspan="2" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 100%" colspan="2" align="right">
                                                                                        <asp:Label runat="server" ID="lblEval_ITB3" CssClass="column_CenterBold" Text="ITB21-00-000"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 100%" colspan="2" align="right">
                                                                                        <span class="column_RightBold">Date Evaluated :</span>
                                                                                        <asp:Label runat="server" ID="lblEval_Date3" CssClass="column_CenterBold" Text=" - "></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%; height: 10px" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center">
                                                                                        <asp:Image runat="server" ID="Image2" ImageUrl="~/images/Logo/Pasay Logo.jpg" Width="100px" Height="100px" />
                                                                                    </td>
                                                                                    <td style="width: 70%" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center">
                                                                                        <span class="column_CenterBold">BIDS AND AWARDS COMMITTEE TECHNICAL WORKING GROUP</span>
                                                                                    </td>
                                                                                    <td style="width: 70%" align="left">
                                                                                        <span class="column_LeftBold">3.0 SUBMISSION AND OPENING OF BIDS AND PRELIMINARY EXAMINATION</span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%" align="center">
                                                                                        <asp:TextBox runat="server" ID="txtEval_3" Width="85%" Height="150px" CssClass="txtbox_Encoding" Text="" TextMode="MultiLine"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%; height: 10px" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%" align="center">
                                                                                        <span class="column_Center">Table 3. Bid Submission and Opening</span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center" rowspan="6">
                                                                                        <table width="98%">
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">ATTY. RAY GLENN C. AGRANZAMENDEZ
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_Center">Chairman
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">MEMBERS
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">JULIUS V. GARACHICO
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_Center">Computer Programmer III
                                                                    <br>
                                                                                                    (Information & Communication Equipment)
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">ALTERNATIVE MEMBERS
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">DR. MA. AUREA A. LATON
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_Center">Medical Officer IV
                                                                    <br>
                                                                                                    City Health Office
                                                                    <br>
                                                                                                    (for procurement of Drugs & Medicine)
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">ENGR. PATRICIA C. ALMONEDA
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_Center">Engineer III
                                                                    <br>
                                                                                                    City Engineer's Office
                                                                    <br>
                                                                                                    (For infrastructure Project)
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold"></td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold"></td>
                                                                                            </tr>

                                                                                        </table>
                                                                                    </td>
                                                                                    <td style="width: 70%" align="center">
                                                                                        <table width="87%" style="border-style: solid; border-width: 1px; border-radius: 5px">
                                                                                            <tr>
                                                                                                <td style="width: 60%" class="column_Left">3.1 Bid Submission Deadline</td>
                                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 60%; text-indent: 20pt" class="column_Left">(a) Original date, time</td>
                                                                                                <td style="width: 40%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt3_OriginalDate" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 60%; text-indent: 20pt" class="column_Left">(b) Extensions, if any</td>
                                                                                                <td style="width: 40%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt3_Extension" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 60%" class="column_Left">3.2 Bid Opening date, time</td>
                                                                                                <td style="width: 40%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt3_DateOpen" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 60%" class="column_Left">3.3 Minutes of Bid Opening, date sent to bidders</td>
                                                                                                <td style="width: 40%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt3_Minutes" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 60%" class="column_Left">3.4 Numbers of bids submitted</td>
                                                                                                <td style="width: 40%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt3_BidSubmitted" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 60%" class="column_Left">3.5 Bid validity period (days or weeks)</td>
                                                                                                <td style="width: 40%" class="column_Center"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 60%; text-indent: 20pt" class="column_Left">(a) Originally specified</td>
                                                                                                <td style="width: 40%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt3_OriginallySpec" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 60%; text-indent: 20pt" class="column_Left">(b) Extensions / Revisions, if any</td>
                                                                                                <td style="width: 40%" class="column_Center">
                                                                                                    <asp:TextBox runat="server" ID="txt3_Revisions" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 70%; height: 10px" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 70%" align="center">
                                                                                        <span class="column_Center">Table 4. Bid Prices (as Read Out)</span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 70%" align="center">
                                                                                        <asp:GridView runat="server" ID="grdEval_Read" SkinID="GridViewAA" Width="90%" AllowPaging="false" EmptyDataText="No Data Found.">
                                                                                            <Columns>
                                                                                                <asp:BoundField ItemStyle-Width="70%" ItemStyle-HorizontalAlign="Left" DataField="SuppName" HeaderText="Bidder Identification / Name" />
                                                                                                <asp:BoundField ItemStyle-Width="30%" ItemStyle-HorizontalAlign="Right" DataField="BidAmount" HeaderText="Bid as Read Amount" DataFormatString="{0:N}" />
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 70%; height: 30px" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 70%" align="justify">
                                                                                        <asp:Label runat="server" ID="lblEval_Footer3" CssClass="column_LeftBold" Text=""></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%; height: 30px" align="center"></td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100%; height: 20px" align="center"></td>
                                                                </tr>




                                                                <%--PAGE 4--%>
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <div class="borderCSS_CurveEdge" style="width: 95%">
                                                                            <table width="90%">
                                                                                <tr>
                                                                                    <td style="width: 100%; height: 10px" colspan="2" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 100%" colspan="2" align="right">
                                                                                        <asp:Label runat="server" ID="lblEval_ITB4" CssClass="column_CenterBold" Text="ITB21-00-000"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 100%" colspan="2" align="right">
                                                                                        <span class="column_RightBold">Date Evaluated :</span>
                                                                                        <asp:Label runat="server" ID="lblEval_Date4" CssClass="column_CenterBold" Text=" - "></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%; height: 10px" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center">
                                                                                        <asp:Image runat="server" ID="Image3" ImageUrl="~/images/Logo/Pasay Logo.jpg" Width="100px" Height="100px" />
                                                                                    </td>
                                                                                    <td style="width: 70%" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center">
                                                                                        <span class="column_CenterBold">BIDS AND AWARDS COMMITTEE TECHNICAL WORKING GROUP</span>
                                                                                    </td>
                                                                                    <td style="width: 70%" align="left">
                                                                                        <span class="column_LeftBold">4.0 BID EVALUATION</span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%" align="center">
                                                                                        <asp:TextBox runat="server" ID="txtEval_4" Width="85%" Height="250px" CssClass="txtbox_Encoding" Text="" TextMode="MultiLine"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%; height: 10px" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%" align="center">
                                                                                        <span class="column_Center">Table 5. Correction of Bids</span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center" rowspan="6">
                                                                                        <table width="98%">
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">ATTY. RAY GLENN C. AGRANZAMENDEZ
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_Center">Chairman
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">MEMBERS
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">JULIUS V. GARACHICO
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_Center">Computer Programmer III
                                                                    <br>
                                                                                                    (Information & Communication Equipment)
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">ALTERNATIVE MEMBERS
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">DR. MA. AUREA A. LATON
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_Center">Medical Officer IV
                                                                    <br>
                                                                                                    City Health Office
                                                                    <br>
                                                                                                    (for procurement of Drugs & Medicine)
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold">ENGR. PATRICIA C. ALMONEDA
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_Center">Engineer III
                                                                    <br>
                                                                                                    City Engineer's Office
                                                                    <br>
                                                                                                    (For infrastructure Project)
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%; height: 10px" class="column_CenterBold"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold"></td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td style="width: 100%" class="column_CenterBold"></td>
                                                                                            </tr>

                                                                                        </table>
                                                                                    </td>
                                                                                    <td style="width: 70%" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 70%" align="center">
                                                                                        <asp:GridView runat="server" ID="grdEval_Calculated" SkinID="GridViewAA" Width="90%" AllowPaging="false" EmptyDataText="No Data Found.">
                                                                                            <Columns>
                                                                                                <asp:BoundField ItemStyle-Width="70%" ItemStyle-HorizontalAlign="Left" DataField="SuppName" HeaderText="Bidder Identification / Name" />
                                                                                                <asp:BoundField ItemStyle-Width="30%" ItemStyle-HorizontalAlign="Right" DataField="BidAmount" HeaderText="Bid as Calculated" DataFormatString="{0:N}" />
                                                                                            </Columns>
                                                                                        </asp:GridView>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 70%; height: 30px" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 70%" align="right">
                                                                                        <table width="100%">
                                                                                            <tr>
                                                                                                <td style="width: 60%" class="column_Left">Prepared by :</td>
                                                                                                <td style="width: 40%" class="column_Center"></td>

                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 60%" class="column_Center">
                                                                                                    <asp:DropDownList runat="server" ID="drpTWGChairman" CssClass="drpdownCSS" Width="80%"></asp:DropDownList>
                                                                                                </td>
                                                                                                <td style="width: 40%" class="column_Center">
                                                                                                    <asp:DropDownList runat="server" ID="drpBACSecretariat" CssClass="drpdownCSS" Width="95%"></asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 60%" class="column_Center">TWG Chairman</td>
                                                                                                <td style="width: 40%" class="column_Center">BAC-Secretariat</td>

                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 60%; height: 10px" class="column_Left"></td>
                                                                                                <td style="width: 40%" class="column_Center"></td>

                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 60%" class="column_Left">Noted by :</td>
                                                                                                <td style="width: 40%" class="column_Center"></td>

                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 60%" class="column_Center">
                                                                                                    <asp:DropDownList runat="server" ID="drpEval_BACC" CssClass="drpdownCSS" Width="80%"></asp:DropDownList>
                                                                                                </td>
                                                                                                <td style="width: 40%" class="column_Center"></td>

                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 60%" class="column_Center">BAC Chairman</td>
                                                                                                <td style="width: 40%" class="column_Center"></td>

                                                                                            </tr>
                                                                                        </table>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td style="width: 70%; height: 30px" align="center"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 70%" align="justify">
                                                                                        <asp:Label runat="server" ID="lblEval_Footer4" CssClass="column_LeftBold" Text=""></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%" align="center"></td>
                                                                                    <td style="width: 70%; height: 30px" align="center"></td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                </tr>



                                                                <tr>
                                                                    <td style="width: 100%; height: 20px" align="center"></td>
                                                                </tr>




                                                                <%-- FOOTER--%>
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <table width="90%">
                                                                            <tr>
                                                                                <td style="width: 30%" class="column_RightBold">Footer :</td>
                                                                                <td style="width: 70%" class="column_Left">
                                                                                    <asp:TextBox runat="server" ID="txtEval_Footer" Width="95%" Height="80px" CssClass="txtbox_Encoding" Text="" TextMode="MultiLine"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <table width="90%">
                                                                            <tr>
                                                                                <td style="width: 30%" class="column_RightBold">Date Evaluated :</td>
                                                                                <td style="width: 70%" class="column_Left">
                                                                                    <asp:TextBox runat="server" ID="txtEval_Date" CssClass="txtbox_Date" Width="20%" Text="" MaxLength="10"></asp:TextBox>
                                                                                    &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                                    <cc1:CalendarExtender runat="server" ID="CalendarExtender_Eval" TargetControlID="txtEval_Date" PopupButtonID="txtEval_Date" PopupPosition="TopLeft"></cc1:CalendarExtender>

                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100%; height: 20px" align="center"></td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <asp:Button runat="server" ID="btnSave_BidEval" CssClass="CSButton" Width="15%" Text="Save" Enabled="false" OnClientClick="StartProgressBar();" />
                                                                        &nbsp;<asp:Button runat="server" ID="btnPreview_BidEval" CssClass="CSButton" Width="15%" Text="Preview" Enabled="false" OnClientClick="StartProgressBar();" />

                                                                    </td>
                                                                </tr>

                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 30px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>



                                            <asp:View runat="server" ID="vwTab4_PostQua">
                                                <table width="98%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Search by :</span>
                                                            &nbsp;<asp:DropDownList runat="server" ID="drpPostQua_Search" CssClass="drpdownCSS" Width="12%">
                                                                <asp:ListItem Value="1" Text="ITB Number" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Project Name"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:TextBox runat="server" ID="txtPostQua_Search" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                            &nbsp;<asp:Button runat="server" ID="btnPostQua_Search" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdPostQua" SkinID="GridViewAA" Width="90%" AllowPaging="true" PageSize="12" EmptyDataText="No Data Found."
                                                                DataKeyNames="Infra_BidPrep_ID,PPA,ITB_No">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkPostQua_Select" Text="Select" CssClass="LinkBtnSelect" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" DataField="ITB_No" HeaderText="ITB Number" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="65%" DataField="PPA" HeaderText="Project Name" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%" DataField="Amount" HeaderText="ABC" DataFormatString="{0:N}" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">List of Bidders
                                                        </td>
                                                    </tr>
                                                      <tr>
                                                        <td style="width: 100%" align="center">
                                                             <asp:GridView runat="server" ID="grdPostQua_Bidders" SkinID="GridViewAA" Width="70%" AllowPaging="true" PageSize="12" EmptyDataText="No Data Found."
                                                                DataKeyNames="Supplier_ID">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkPostQuaBidder_Select" Text="Select" CssClass="LinkBtnSelect" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75%" DataField="SuppName" HeaderText="Bidder's Name" />
                                                              
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">Details
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="80%">
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Date :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtDate_PostQua" CssClass="txtbox_Date" Width="15%" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtDate_PostQua" PopupButtonID="txtDate_PostQua" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender5" TargetControlID="txtDate_PostQua" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Date Docs. required :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtDate_DocsReq" CssClass="txtbox_Date" Width="15%" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender3" TargetControlID="txtDate_DocsReq" PopupButtonID="txtDate_DocsReq" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender6" TargetControlID="txtDate_DocsReq" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Period :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtDate_PeriodFrom" CssClass="txtbox_Date" Width="15%" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender4" TargetControlID="txtDate_PeriodFrom" PopupButtonID="txtDate_PeriodFrom" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender7" TargetControlID="txtDate_PeriodFrom" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>

                                                                        &nbsp;<span class="column_CenterBold">To :</span>

                                                                        &nbsp;<asp:TextBox runat="server" ID="txtDate_PeriodTo" CssClass="txtbox_Date" Width="15%" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender5" TargetControlID="txtDate_PeriodTo" PopupButtonID="txtDate_PeriodTo" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender8" TargetControlID="txtDate_PeriodTo" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Result :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtDate_Result" CssClass="txtbox_Date" Width="15%" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender6" TargetControlID="txtDate_Result" PopupButtonID="txtDate_Result" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender9" TargetControlID="txtDate_Result" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>


                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold"></td>
                                                                    <td style="width: 80%" class="column_Left"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="95%">
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_CenterBold">REQUIREMENTS</td>
                                                                                <td style="width: 40%" class="column_CenterBold">REMARKS</td>
                                                                                <td style="width: 20%" class="column_CenterBold">FINDINGS</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <table width="98%">
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">I. TECHNICAL DOCUMENTS</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">Class "A" Documents</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">Legal Documents</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">a. Philgeps Certificate - Platinum Membership; OR as per circular 03-2016</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksA" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsA" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">b. Registration cetificate from SEC</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksB" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsB" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">c. Mayor's Permit in the principal place of business - Makati</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksC" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsC" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">d. Tax clearance</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksD" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsD" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 15px" colspan="3"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">Technical Documents</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">f. Statement of all ongoing government and private contracts, including contracts awarded not yet started, if any</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksF" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsF" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">g. Statement of Single Largest Completed Contract which similar in nature</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksG" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsG" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">h. Bid Securing Declaration</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksH" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsH" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">i. Technical Specifications</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">1. Statement from the prospective bidder duly notarize that they will comply with the specification as provided for the procuring entity.</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksI1" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsI1" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">2. Sworn Statement from prospective bidder that they can deliver within 30 calendar days after the receipt of NTP</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksI2" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsI2" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">3. Sworn Statement from prospective bidder that they are authorized / exclusive dealer / reseller / distributor of branded products being offered.</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksI3" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsI3" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">4. Sworn Statement from prospective bidder that they all products being offer are all original / branded.</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksI4" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsI4" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">5. Manpower requirement or a list of personnel to be assigned for the contract to be bid.</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksI5" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsI5" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">6. Sworn Statement from prospective bidder duly notarized for the warranty and details of after sales service.</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksI6" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsI6" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">j. Omnibus Sworn Statement</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksJ1" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsJ1" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">Duly Authorized Representative / Signatory of the prospective bidder</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksJ2" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsJ2" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 15px" colspan="3"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">Financial Documents</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">k. Audited Financial Statements stamped received by BIR or its duly accredited and authorized institutions for the preceding calendar year which should not be earlier that 2 years from the date of bid submission.</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksK" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsK" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">l. Net Financial Contracting Capacity</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksL" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsL" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 15px" colspan="3"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">Class "B" Documents</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">Joint Venture Agreement</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <span class="column_Center">Not Applicable</span>
                                                                                </td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 15px" colspan="3"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">II. FINANCIAL COMPONENTS</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">a. Bid Form</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Remarks2A" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Findings2A" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">b. Proposal Sheet</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Remarks2B" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Findings2B" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">c. Price Schedule</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Remarks2C" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Findings2C" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 15px" colspan="3"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">III. POST QUALIFICATION DOCUMENTS</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">a. Latest income and business tax returns</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Remarks3A" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Findings3A" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">b. Other licenses and permits required Business Permit (Pasay City)</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Remarks3B" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Findings3B" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">c. BIR Certificate of Registration</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Remarks3C" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Findings3C" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 15px" colspan="3"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">IV. BID PRICE / AMOUNT EVALUATION</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%" colspan="3" align="center">
                                                                                    <table width="80%" style="border: solid 1px; border-collapse: collapse">
                                                                                        <tr>
                                                                                            <td style="width: 35%; border: solid 1px; border-collapse: collapse" class="column_CenterBold">Amount of Bid as Read</td>
                                                                                            <td style="width: 35%; border: solid 1px; border-collapse: collapse" class="column_CenterBold">Amount of Bid as Calculated</td>
                                                                                            <td style="width: 30%; border: solid 1px; border-collapse: collapse" class="column_CenterBold">Findings</td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 35%; height: 50px; border: solid 1px; border-collapse: collapse" class="column_CenterBold">
                                                                                                <asp:Label runat="server" ID="lblRead" Text="0.00"></asp:Label>
                                                                                            </td>
                                                                                            <td style="width: 35%; height: 50px; border: solid 1px; border-collapse: collapse" class="column_CenterBold">
                                                                                                <asp:Label runat="server" ID="lblCalculated" Text="0.00"></asp:Label>
                                                                                            </td>
                                                                                            <td style="width: 30%; height: 50px; border: solid 1px; border-collapse: collapse" class="column_CenterBold">
                                                                                                <asp:TextBox runat="server" ID="txtIV_Findings" CssClass="txtbox_Remarks" TextMode="MultiLine" Text="" Width="90%" Height="30px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 15px" colspan="3"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">V. FINDINGS</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%" colspan="3" align="center">
                                                                                    <table width="80%" style="border: solid 1px; border-collapse: collapse">
                                                                                        <tr>
                                                                                            <td style="width: 35%; border: solid 1px; border-collapse: collapse" class="column_CenterBold">Bidder's Name</td>
                                                                                            <td style="width: 35%; border: solid 1px; border-collapse: collapse" class="column_CenterBold">Amount of Bid as Calculated</td>
                                                                                            <td style="width: 30%; border: solid 1px; border-collapse: collapse" class="column_CenterBold">Findings</td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 35%; height: 50px; border: solid 1px; border-collapse: collapse" class="column_CenterBold">
                                                                                                <asp:Label runat="server" ID="lblV_Bidder" Text="Bidder's Name"></asp:Label>
                                                                                            </td>
                                                                                            <td style="width: 35%; height: 50px; border: solid 1px; border-collapse: collapse" class="column_CenterBold">
                                                                                                <asp:TextBox runat="server" ID="txtV_Findings" CssClass="txtbox_Remarks" TextMode="MultiLine" Text="" Width="90%" Height="30px"></asp:TextBox>

                                                                                            </td>
                                                                                            <td style="width: 30%; height: 50px; border: solid 1px; border-collapse: collapse" class="column_CenterBold">
                                                                                                <asp:TextBox runat="server" ID="txtV_Grounds" CssClass="txtbox_Remarks" TextMode="MultiLine" Text="" Width="90%" Height="30px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 10px" colspan="3" align="center"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%" colspan="3" align="center">
                                                                                    <asp:TextBox runat="server" ID="txtThereFore" CssClass="txtbox_Remarks" TextMode="MultiLine" Text="" Width="80%" Height="100px"></asp:TextBox>

                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%;height:20px" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button runat="server" ID="btnSave_PostQua" CssClass="CSButton" Width="15%" Text="Save" OnClientClick="StartProgressBar();"/>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 20px" align="center"></td>
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
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>

            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

