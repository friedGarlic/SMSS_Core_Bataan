<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Infra_Abstract.aspx.vb"
    Inherits="bidding_Bidding_Infra_Infra_Abstract" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <script type="text/javascript">
        function formatCurrency(num) {
            num = num.toString().replace(/\$|\,/g, '');
            if (isNaN(num))
                num = "0";
            sign = (num == (num = Math.abs(num)));
            num = Math.floor(num * 100 + 0.50000000001);
            cents = num % 100;
            num = Math.floor(num / 100).toString();
            if (cents < 10)
                cents = "0" + cents;
            for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
                num = num.substring(0, num.length - (4 * i + 3)) + ',' +
                    num.substring(num.length - (4 * i + 3));
            return (((sign) ? '' : '-') + '' + num + '.' + cents);
        }
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">INFRA ABSTRACT OF BIDS
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <table width="100%">
                                <tr>
                                    <td style="width: 70%" align="center">
                                        <span class="column_RightBold">Search :</span>
                                        &nbsp;<asp:DropDownList runat="server" ID="drpSearch" Width="100px" CssClass="drpdownCSS">
                                            <asp:ListItem Value="1" Text="OBR No."></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Project Name"></asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;<asp:TextBox runat="server" ID="txtSearch" Width="250px" CssClass="txtbox_Var"></asp:TextBox>
                                        &nbsp;<asp:Button runat="server" ID="btnSearch" Width="100px" CssClass="CSButton" Text="Search" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 30%" align="right">
                                        <span class="column_RightBold">Date :</span>
                                        &nbsp;<asp:TextBox runat="server" ID="txtDate" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                    </td>
                                </tr>
                            </table>

                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView runat="server" ID="grdInfaOBR" Width="90%" SkinID="GridViewAA" EmptyDataText="No Data Found." AllowPaging="true" DataKeyNames="OBR_Hdr_ID,OBR_No,TotalAmount,RC_ID,Function_ID,Program_ID,Project_ID,PPA">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelect" Text="Select" Font-Underline="false" CssClass="LinkBtnSelect" CommandName="Select" OnClick="lnkSelect_OnClick" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" HeaderText="OBR Number" DataField="OBR_No" />
                                    <asp:BoundField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%" HeaderText="Amount" DataField="TotalAmount" DataFormatString="{0:N}" />
                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="55%" HeaderText="Project Name" DataField="PPA" />
                                    
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
                        <td style="width: 98%" class="DivTitle">Bidder Details
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 95%">
                                <tr>
                                    <td style="width: 18%" class="column_LeftBold">Time Duration CD</td>
                                    <td style="width: 2%" class="column_LeftBold">:</td>
                                    <td style="width: 30%" class="column_Left">
                                        <asp:TextBox ID="txtTimeDuration" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox></td>
                                    <td style="width: 18%" class="column_LeftBold">Bid Security Amount</td>
                                    <td style="width: 2%" class="column_LeftBold">:</td>
                                    <td style="width: 30%" class="column_Left">
                                        <asp:TextBox ID="txtBidSecurityAmt" runat="server" Width="50%" CssClass="txtbox_Amt">0.00</asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 18%" class="column_LeftBold">Form of Bid Security</td>
                                    <td style="width: 2%" class="column_LeftBold">:</td>
                                    <td style="width: 30%" class="column_Left">
                                        <asp:TextBox ID="txtBidSecurityForm" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox></td>
                                    <td style="width: 18%" class="column_LeftBold">Required Bid Security</td>
                                    <td style="width: 2%" class="column_LeftBold">:</td>
                                    <td style="width: 30%" class="column_Left">
                                        <asp:TextBox ID="txtRequiredBidSec" runat="server" Width="50%" CssClass="txtbox_Amt">0.00</asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 18%" class="column_LeftBold">Bank / Company</td>
                                    <td style="width: 2%" class="column_LeftBold">:</td>
                                    <td style="width: 30%" class="column_Left">
                                        <asp:TextBox ID="txtBankCampany" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox></td>
                                    <td style="width: 18%" class="column_LeftBold">Sufficient / Insufficient</td>
                                    <td style="width: 2%" class="column_LeftBold">:</td>
                                    <td style="width: 30%" class="column_Left">
                                        <asp:DropDownList ID="ddSufficient" runat="server" Width="92%" CssClass="drpdownCSS">
                                            <asp:ListItem Selected="True" Value="1">SUFFICIENT</asp:ListItem>
                                            <asp:ListItem Value="2">INSUFFICIENT</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 18%" class="column_LeftBold">Number</td>
                                    <td style="width: 2%" class="column_LeftBold">:</td>
                                    <td style="width: 30%" class="column_Left">
                                        <asp:TextBox ID="txtNumber" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox></td>
                                    <td style="width: 18%" class="column_LeftBold">Remarks</td>
                                    <td style="width: 2%" class="column_LeftBold">:</td>
                                    <td style="width: 30%" class="column_Left">
                                        <asp:TextBox ID="txtRemarks" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 18%" class="column_LeftBold">Validity Period</td>
                                    <td style="width: 2%" class="column_LeftBold">:</td>
                                    <td style="width: 30%" class="column_Left">
                                        <asp:TextBox ID="txtValidityPeriod" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox></td>
                                    <td style="width: 18%" class="column_LeftBold">Total Bid Amount</td>
                                    <td style="width: 2%" class="column_LeftBold">:</td>
                                    <td style="width: 30%" class="column_Left">
                                        <asp:TextBox ID="txtBidAmount" runat="server" Width="50%" CssClass="txtbox_Amt" Text="0.00"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
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
                            <span class="column_RightBold">Bidder :</span>
                            &nbsp;<asp:DropDownList runat="server" ID="drpBidders" Width="400px" CssClass="drpdownCSS">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:Button runat="server" ID="btnAddBidder" Width="150px" Enabled="false" CssClass="CSButton" Text="Add" OnClientClick="StartProgressBar();" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List of Bidders
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView runat="server" ID="grdBidders" Width="90%" SkinID="GridViewAA" EmptyDataText="No Data Found." DataKeyNames="Infra_Hdr_ID,Infra_Dtl_ID">
                                <Columns>
                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="46%" HeaderText="Bidder Name" DataField="SuppName" />
                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" HeaderText="Bid Amount" DataField="BidAmount" DataFormatString="{0:N}" />
                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" HeaderText="Winner" DataField="Winner" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelectBidder" Text="Update" Visible='<%# Bind("isVisible") %>' Font-Underline="false" CssClass="LinkBtnSelect" CommandName="Select" OnClick="lnkSelectBidder_OnClick" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkDeleteBidder" Text="Delete" Visible='<%# Bind("isVisible") %>' Font-Underline="false" CssClass="LinkBtnCancel" CommandName="Select" OnClick="lnkDeleteBidder_OnClick" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                            <cc1:ConfirmButtonExtender runat="server" ID="confirmDelete" TargetControlID="lnkDeleteBidder" ConfirmText="Are your sure you want to remove this bidder?"></cc1:ConfirmButtonExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkWinnerBidder" Text="Winner" Visible='<%# Bind("isVisible") %>' Font-Underline="false" CssClass="LinkBtnSelect" CommandName="Select" OnClick="lnkWinnerBidder_OnClick" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                            <cc1:ConfirmButtonExtender runat="server" ID="confirmWinner" TargetControlID="lnkWinnerBidder" ConfirmText="Are your sure you want to declare this bidder as a winner?"></cc1:ConfirmButtonExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:TemplateField>
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
                            <table width="90%">
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Project Location :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtProjectLocation" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Date of Bid :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtBidDate" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        <cc1:CalendarExtender runat="server" ID="CExtndrBidDate" TargetControlID="txtBidDate" PopupButtonID="txtBidDate"></cc1:CalendarExtender>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="width: 15%" class="column_RightBold">Place of Bid :</td>
                                    <td style="width: 35%" class="column_Left">
                                         <asp:TextBox runat="server" ID="txtBidPlace" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Time of Bid :</td>
                                    <td style="width: 35%" class="column_Left">
                                         <asp:TextBox runat="server" ID="txtBidTime" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                    </td>
                                </tr>                                 
                            </table>
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
                            <table width="90%">
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">BAC Member :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpBAC1" Width="95%" CssClass="drpdownCSS">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">BAC Vice Chairman :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpBACVC" Width="95%" CssClass="drpdownCSS">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">BAC Member :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpBAC2" Width="95%" CssClass="drpdownCSS">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">BAC Chairman :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpBACC" Width="95%" CssClass="drpdownCSS">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">BAC Member :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpBAC3" Width="95%" CssClass="drpdownCSS">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">BAC TWG :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpBAC_TWG" Width="95%" CssClass="drpdownCSS">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">BAC Member :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpBAC4" Width="95%" CssClass="drpdownCSS">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">End User :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpEndUser" Width="95%" CssClass="drpdownCSS">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
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
                            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="CSButton" Width="150px" OnClientClick="StartProgressBar();" Enabled="false" />
                            &nbsp;<asp:Button runat="server" ID="btnPreview" Text="Preview As Abstract" CssClass="CSButton" Width="150px" OnClientClick="StartProgressBar();" Enabled="false" />
                            <%--&nbsp;<asp:Button runat="server" ID="btnResolution" Text="BAC Resolution" CssClass="CSButton" Width="150px" OnClientClick="StartProgressBar();" Enabled="false" />--%>
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




         <%--   <asp:Panel runat="server" ID="pnlLocation" CssClass="Panel_Popup" Width="350px">
                <div>
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">Project Details</td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 30%" class="column_RightBold">Location :</td>
                                        <td style="width: 70%" class="column_Left">
                                            <asp:TextBox runat="server" ID="txtProjLocation" Text="" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30%" class="column_RightBold">Place of Bid :</td>
                                        <td style="width: 70%" class="column_Left">
                                            <asp:TextBox runat="server" ID="txtBidPlace" Text="" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30%" class="column_RightBold">Time of Bid :</td>
                                        <td style="width: 70%" class="column_Left">
                                            <asp:TextBox runat="server" ID="txtBidTime" Text="" Width="50%" CssClass="txtbox_Var"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
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
                                <asp:Button runat="server" ID="btnSaveLocation" Width="100px" CssClass="CSButton" Text="Save" OnClientClick="StartProgressBar();" />
                                &nbsp;<asp:Button runat="server" ID="btnCancel" Width="100px" CssClass="CSButton" Text="Cancel" OnClientClick="StartProgressBar();" />
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px">
                                <asp:Label runat="server" ID="lblAdd_Location"></asp:Label>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="MPE_ProjectLocation" runat="server" TargetControlID="lblAdd_Location" PopupControlID="pnlLocation" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>--%>



            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp; 
        



        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>

