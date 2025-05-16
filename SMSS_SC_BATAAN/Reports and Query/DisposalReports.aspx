<%@ Page Title="Disposal Reports" 
    Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    EnableEventValidation="false" 
    AutoEventWireup="false" 
    CodeFile="DisposalReports.aspx.vb"
    Inherits="Reports_and_Query_DisposalReports" 
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">









</script>



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
                        <td style="width: 98%" class="PageTitle">DISPOSAL REPORTS
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <span class="column_RightBold">Date :</span>
                            &nbsp;<asp:TextBox runat="server" ID="txtDate" CssClass="txtbox_Date" Width="10%" Text=""></asp:TextBox>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">

                            <table cellpadding="0px" cellspacing="0px" width="100%">
                                <tr>
                                    <td>
                                    <table width="100%">
                                    <tr>
                                  
                                    <td style="width: 10%" align="left">
                                        <asp:Button runat="server" ID="btnTab1_IIRUP" Width="100%" Text="IIRUP" CssClass="TabButton_Active" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 10%" align="left">
                                        <asp:Button runat="server" ID="btnTab7_Appraisal" Width="100%" Text="Appraisal" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" OnClick="btnTab7_Appraisal_Click" />
                                    </td>
                                    <td style="width: 10%" align="left">
                                        <asp:Button runat="server" ID="btnTab6_Donation" Width="100%" Text="Donation" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 10%; display:none" align="left">
                                        <asp:Button runat="server" ID="btnTab2_ISSP" Width="100%" Text="ISSP" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 10%" align="left">
                                        <asp:Button runat="server" ID="btnTab3_Abstract" Width="100%" Text="Abstract" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 10%" align="left">
                                        <asp:Button runat="server" ID="btnTab4_NOA" Width="100%" Text="NOA" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 10%" align="left">
                                        <asp:Button runat="server" ID="btnTab5_NTP" Width="100%" Text="NTP" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                     <td style="width: 10%" align="left">
                                        <asp:Button runat="server" ID="btnTab8_DFA" Width="100%" Text="DFA" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" OnClick="btnTab8_DFA_Click" />
                                    </td>
                                     <td style="width: 10%" align="left">
                                        <asp:Button runat="server" ID="btnTab9_AOA" Width="100%" Text="AOA" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" OnClick="btnTab9_AOA_Click" />
                                    </td>
                                    </tr>
                                    </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="7" class="PanelTabs">
                                        <asp:MultiView runat="server" ID="mvTabs">
                                            <asp:View runat="server" ID="vwTab1_IIRUP">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 40%" align="right">
                                                                        <span class="column_RightBold">Search By :</span>
                                                                        &nbsp;<asp:DropDownList runat="server" CssClass="drpdownCSS" ID="drpSearch_IIRUP" Width="40%" AutoPostBack="true">
                                                                            <asp:ListItem Value="1" Text="IIRUP No." Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="Department"></asp:ListItem>
                                                                            <asp:ListItem Value="3" Text="Date Duration"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 60%" align="left">
                                                                        <asp:Panel runat="server" ID="pnlDateSearch_IIRUP1" Visible="false">
                                                                            &nbsp;<asp:TextBox runat="server" CssClass="txtbox_Var" ID="txtSearch_IIRUP" Width="40%" Text=""></asp:TextBox>
                                                                            &nbsp;<asp:Button runat="server" CssClass="CSButton" ID="btnSearch_IIRUP" Width="15%" Text="Search" OnClientClick="StartProgressBar();" />
                                                                        </asp:Panel>
                                                                        <asp:Panel runat="server" ID="pnlDateSearch_IIRUP2" Visible="false">
                                                                            &nbsp;<span class="column_RightBold">Date From :</span>
                                                                            &nbsp;<asp:TextBox runat="server" CssClass="txtbox_Date" ID="txtDateFrom_IITUP" Width="12%"></asp:TextBox>
                                                                            &nbsp;<span class="column_RightBold">Date To :</span>
                                                                            &nbsp;<asp:TextBox runat="server" CssClass="txtbox_Date" ID="txtDateTo_IITUP" Width="12%"></asp:TextBox>
                                                                            &nbsp;<asp:Button runat="server" CssClass="CSButton" ID="btnSearch_IIRUPDate" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />

                                                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtDateFrom_IITUP" PopupButtonID="txtDateFrom_IITUP" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtDateTo_IITUP" PopupButtonID="txtDateTo_IITUP" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtDateFrom_IITUP" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender2" TargetControlID="txtDateTo_IITUP" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                        </asp:Panel>

                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdIIRUP" Width="95%" SkinID="GridViewAA" AllowPaging="true" PageSize="15"
                                                                EmptyDataText="No Data Found." DataKeyNames="IIRUPHdr_ID">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkSelect" CssClass="LinkBtnSelect" Font-Underline="false" Text="Preview" OnClientClick="StartProgressBar();" CommandName="Select"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="IIRUP_Date" DataFormatString="{0:d}" HeaderText="Date">
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="IIRUP_No" HeaderText="IIRUP Number">
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="RC_Name" HeaderText="Department">
                                                                        <ItemStyle HorizontalAlign="Left" Width="45%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="TotalAppraisedValue" HeaderText="Total Appraised Value" DataFormatString="{0:N}">
                                                                        <ItemStyle HorizontalAlign="Right" Width="15%" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>

                                            <asp:View runat="server" ID="vwTab2_ISSP">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 40%" align="right">
                                                                        <span class="column_RightBold">Search By :</span>
                                                                        &nbsp;<asp:DropDownList runat="server" CssClass="drpdownCSS" ID="drpSearch_ISSP" Width="40%" AutoPostBack="true">
                                                                            <asp:ListItem Value="1" Text="ISSP No." Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="Submission Location"></asp:ListItem>
                                                                            <asp:ListItem Value="3" Text="Date Duration (ISSP)"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 60%" align="left">
                                                                        <asp:Panel runat="server" ID="pnl_ISSP1" Visible="false">
                                                                            &nbsp;<asp:TextBox runat="server" CssClass="txtbox_Var" ID="txtSearch_ISSP" Width="40%" Text=""></asp:TextBox>
                                                                            &nbsp;<asp:Button runat="server" CssClass="CSButton" ID="btnSearch_ISSP" Width="15%" Text="Search" OnClientClick="StartProgressBar();" />
                                                                        </asp:Panel>
                                                                        <asp:Panel runat="server" ID="pnl_ISSP2" Visible="false">
                                                                            &nbsp;<span class="column_RightBold">Date From :</span>
                                                                            &nbsp;<asp:TextBox runat="server" CssClass="txtbox_Date" ID="txtDateFrom_ISSP" Width="12%"></asp:TextBox>
                                                                            &nbsp;<span class="column_RightBold">Date To :</span>
                                                                            &nbsp;<asp:TextBox runat="server" CssClass="txtbox_Date" ID="txtDateTo_ISSP" Width="12%"></asp:TextBox>
                                                                            &nbsp;<asp:Button runat="server" CssClass="CSButton" ID="btnSearchDate_ISSP" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />

                                                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender3" TargetControlID="txtDateFrom_ISSP" PopupButtonID="txtDateFrom_ISSP" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender4" TargetControlID="txtDateTo_ISSP" PopupButtonID="txtDateTo_ISSP" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender3" TargetControlID="txtDateFrom_ISSP" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender4" TargetControlID="txtDateTo_ISSP" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                        </asp:Panel>

                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdISSP" SkinID="GridViewAA" Width="80%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="12"
                                                                DataKeyNames="IsspHdr_ID,Issp_No">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkPreview" Text="Preview" CssClass="LinkBtnSelect" Font-Underline="false" Visible='<%#Bind("isVisible") %>' CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" DataField="BidType" HeaderText="Bid Type" />
                                                                    <asp:BoundField ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" DataField="Issp_Date" DataFormatString="{0:d}" HeaderText="ISSP Date" />
                                                                    <asp:BoundField ItemStyle-Width="30%" ItemStyle-HorizontalAlign="Center" DataField="Issp_No" HeaderText="ISSP Number" />
                                                                    <asp:BoundField ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Right" DataField="MinBid_Amt" DataFormatString="{0:N}" HeaderText="Min. Bid Amount" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>

                                            <asp:View runat="server" ID="vwTab3_Abstract">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 40%" align="right">
                                                                        <span class="column_RightBold">Search By :</span>
                                                                        &nbsp;<asp:DropDownList runat="server" CssClass="drpdownCSS" ID="drpSearch_Abstract" Width="40%" AutoPostBack="true">
                                                                            <asp:ListItem Value="1" Text="ISSP No." Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="Bidder Name"></asp:ListItem>
                                                                            <asp:ListItem Value="3" Text="Date Duration (Abstract)"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 60%" align="left">
                                                                        <asp:Panel runat="server" ID="pnl_Abstract1" Visible="false">
                                                                            &nbsp;<asp:TextBox runat="server" CssClass="txtbox_Var" ID="txtSearch_Abstract" Width="40%" Text=""></asp:TextBox>
                                                                            &nbsp;<asp:Button runat="server" CssClass="CSButton" ID="btnSearch_Abstract" Width="15%" Text="Search" OnClientClick="StartProgressBar();" />
                                                                        </asp:Panel>
                                                                        <asp:Panel runat="server" ID="pnl_Abstract2" Visible="false">
                                                                            &nbsp;<span class="column_RightBold">Date From :</span>
                                                                            &nbsp;<asp:TextBox runat="server" CssClass="txtbox_Date" ID="txtSearchDateFrom_Abstract" Width="12%"></asp:TextBox>
                                                                            &nbsp;<span class="column_RightBold">Date To :</span>
                                                                            &nbsp;<asp:TextBox runat="server" CssClass="txtbox_Date" ID="txtSearchDateTo_Abstract" Width="12%"></asp:TextBox>
                                                                            &nbsp;<asp:Button runat="server" CssClass="CSButton" ID="btnSearchDate_Abstract" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />

                                                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender5" TargetControlID="txtSearchDateFrom_Abstract" PopupButtonID="txtSearchDateFrom_Abstract" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender6" TargetControlID="txtSearchDateTo_Abstract" PopupButtonID="txtSearchDateTo_Abstract" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender5" TargetControlID="txtSearchDateFrom_Abstract" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender6" TargetControlID="txtSearchDateTo_Abstract" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                        </asp:Panel>

                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdAbstract" SkinID="GridViewAA" Width="95%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="12"
                                                                DataKeyNames="Disposal_Bid_hdr_id">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkPreview" Text="Preview" CssClass="LinkBtnSelect" Font-Underline="false" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="BidDate" DataFormatString="{0:d}" HeaderText="Bid Date" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="Description" HeaderText="Disposal Type" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="SuppName"  HeaderText="Bidder" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>

                                            <asp:View runat="server" ID="vwTab4_NOA">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 40%" align="right">
                                                                        <span class="column_RightBold">Search By :</span>
                                                                        &nbsp;<asp:DropDownList runat="server" CssClass="drpdownCSS" ID="drpSearch_NOA" Width="40%" AutoPostBack="true">
                                                                            <asp:ListItem Value="1" Text="ISSP No." Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="Bidder Name"></asp:ListItem>
                                                                            <asp:ListItem Value="3" Text="Date Duration (NOA)"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 60%" align="left">
                                                                        <asp:Panel runat="server" ID="pnl_NOA1" Visible="false">
                                                                            &nbsp;<asp:TextBox runat="server" CssClass="txtbox_Var" ID="txtSearch_NOA" Width="40%" Text=""></asp:TextBox>
                                                                            &nbsp;<asp:Button runat="server" CssClass="CSButton" ID="btnSearch_NOA" Width="15%" Text="Search" OnClientClick="StartProgressBar();" />
                                                                        </asp:Panel>
                                                                        <asp:Panel runat="server" ID="pnl_NOA2" Visible="false">
                                                                            &nbsp;<span class="column_RightBold">Date From :</span>
                                                                            &nbsp;<asp:TextBox runat="server" CssClass="txtbox_Date" ID="txtSearchDateFrom_NOA" Width="12%"></asp:TextBox>
                                                                            &nbsp;<span class="column_RightBold">Date To :</span>
                                                                            &nbsp;<asp:TextBox runat="server" CssClass="txtbox_Date" ID="txtSearchDateTo_NOA" Width="12%"></asp:TextBox>
                                                                            &nbsp;<asp:Button runat="server" CssClass="CSButton" ID="btnSearchDate_NOA" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />

                                                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender7" TargetControlID="txtSearchDateFrom_NOA" PopupButtonID="txtSearchDateFrom_NOA" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender8" TargetControlID="txtSearchDateTo_NOA" PopupButtonID="txtSearchDateTo_NOA" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender7" TargetControlID="txtSearchDateFrom_NOA" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender8" TargetControlID="txtSearchDateTo_NOA" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                        </asp:Panel>

                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdNOA" SkinID="GridViewAA" Width="95%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="12"
                                                                DataKeyNames="IsspHdr_ID,QuotationHdr_ID,Supplier_ID,Issp_No">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkPreview" Text="Preview" CssClass="LinkBtnSelect"  Visible='<%#Bind("isVisible") %>' CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="NOA_Date" DataFormatString="{0:d}" HeaderText="NOA Date" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="BidType" HeaderText="Bid Type" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="Issp_No" HeaderText="ISSP Number" />
                                                                    <asp:BoundField ItemStyle-Width="50%" ItemStyle-HorizontalAlign="left" DataField="SuppName" HeaderText="Bidder Name" />
                                                                    <asp:BoundField ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Right" DataField="TotalBidAmt" DataFormatString="{0:N}" HeaderText="Total Bid Amount" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>

                                            <asp:View runat="server" ID="vwTab5_NTP">
                                                  <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                      <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">ISSP No. :</span>
                                                            &nbsp;<asp:TextBox runat="server" ID="txtNTP_Search" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                            &nbsp;<asp:Button runat="server" ID="btnNTP_Search" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdNTP" SkinID="GridViewAA" Width="95%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="12"
                                                                DataKeyNames="IsspHdr_ID">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkPreview" Text="Preview" CssClass="LinkBtnSelect"  Visible='<%#Bind("isVisible") %>' CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="NTP_Date" DataFormatString="{0:d}" HeaderText="NTP Date" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="BidType" HeaderText="Bid Type" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="Issp_No" HeaderText="ISSP Number" />
                                                                    <asp:BoundField ItemStyle-Width="50%" ItemStyle-HorizontalAlign="left" DataField="SuppName" HeaderText="Bidder Name" />
                                                                    <asp:BoundField ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Right" DataField="TotalBidAmt" DataFormatString="{0:N}" HeaderText="Total Bid Amount" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>

                                            <asp:View runat="server" ID="vwTab6_Donation">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>

                                                        <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 40%" align="right">
                                                                        <span class="column_RightBold">Search By :</span>
                                                                        &nbsp;<asp:DropDownList runat="server" CssClass="drpdownCSS" ID="drpSearch_Donation" Width="40%" AutoPostBack="true">
                                                                            <asp:ListItem Value="1" Text="IIRUP No." Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="Autorzed By"></asp:ListItem>
                                                                            <asp:ListItem Value="3" Text="Date Duration (Donation)"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 60%" align="left">
                                                                        <asp:Panel runat="server" ID="pnl_Donation1" Visible="false">
                                                                            &nbsp;<asp:TextBox runat="server" CssClass="txtbox_Var" ID="txtSearch_Donation" Width="40%" Text=""></asp:TextBox>
                                                                            &nbsp;<asp:Button runat="server" CssClass="CSButton" ID="btnSearch_Donation" Width="15%" Text="Search" OnClientClick="StartProgressBar();" />
                                                                        </asp:Panel>
                                                                        <asp:Panel runat="server" ID="pnl_Donation2" Visible="false">
                                                                            &nbsp;<span class="column_RightBold">Date From :</span>
                                                                            &nbsp;<asp:TextBox runat="server" CssClass="txtbox_Date" ID="txtSearchDateFrom_Donation" Width="12%"></asp:TextBox>
                                                                            &nbsp;<span class="column_RightBold">Date To :</span>
                                                                            &nbsp;<asp:TextBox runat="server" CssClass="txtbox_Date" ID="txtSearchDateTo_Donation" Width="12%"></asp:TextBox>
                                                                            &nbsp;<asp:Button runat="server" CssClass="CSButton" ID="btnSearchDate_Donation" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />

                                                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender9" TargetControlID="txtSearchDateFrom_Donation" PopupButtonID="txtSearchDateFrom_Donation" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender10" TargetControlID="txtSearchDateTo_Donation" PopupButtonID="txtSearchDateTo_Donation" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender9" TargetControlID="txtSearchDateFrom_Donation" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender10" TargetControlID="txtSearchDateTo_Donation" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                        </asp:Panel>

                                                                    </td>
                                                                </tr>
                                                            </table>

                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdDonation" SkinID="GridViewAA" Width="95%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="12"
                                                                DataKeyNames="IIRUPHdr_ID,Disposal_Donation_hdr_id">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkPreview" Text="Preview" CssClass="LinkBtnSelect" Font-Underline="false" Visible='<%#Bind("isVisible") %>' CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="IIRUP_Date" HeaderText="IIRUP Date" DataFormatString="{0:d}" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="IIRUP_No" HeaderText="IIRUP Number" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="Disposa_date" HeaderText="Donation Date" DataFormatString="{0:d}" />
                                                                    <asp:BoundField ItemStyle-Width="30%" ItemStyle-HorizontalAlign="left" DataField="AuthorizedBy" HeaderText="Authorized By" />
                                                                    <asp:BoundField ItemStyle-Width="35%" ItemStyle-HorizontalAlign="left" DataField="TransTo" HeaderText="Receiving Agency" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                     
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>

                                            <asp:View runat="server" ID="vwTab7_Appraisal">
                                                   <table width="100%">
                                                       <tr>
                                                           <td style="width: 100%; height: 10px"></td>
                                                       </tr>
                                                       <tr>
                                                            <td style="width: 100%" align="center">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 40%" align="right">
                                                                        <span class="column_RightBold">Search By :</span>
                                                                        &nbsp;<asp:DropDownList runat="server" CssClass="drpdownCSS" ID="DropDownList1" Width="40%" AutoPostBack="true">
                                                                            <asp:ListItem Value="1" Text="IIRUP No." Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="Department"></asp:ListItem>
                                                                            <asp:ListItem Value="3" Text="Date Duration"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 60%" align="left">
                                                                        <asp:Panel runat="server" ID="pn_Apprailsal1" Visible="false">
                                                                            &nbsp;<asp:TextBox runat="server" CssClass="txtbox_Var" ID="txtSearchApprailsal" Width="40%" Text=""></asp:TextBox>
                                                                            &nbsp;<asp:Button runat="server" CssClass="CSButton" ID="Button1" Width="15%" Text="Search" OnClientClick="StartProgressBar();" />
                                                                        </asp:Panel>
                                                                        <asp:Panel runat="server" ID="pn_Apprailsal2" Visible="false">
                                                                            &nbsp;<span class="column_RightBold">Date From :</span>
                                                                            &nbsp;<asp:TextBox runat="server" CssClass="txtbox_Date" ID="TextBox2" Width="12%"></asp:TextBox>
                                                                            &nbsp;<span class="column_RightBold">Date To :</span>
                                                                            &nbsp;<asp:TextBox runat="server" CssClass="txtbox_Date" ID="TextBox3" Width="12%"></asp:TextBox>
                                                                            &nbsp;<asp:Button runat="server" CssClass="CSButton" ID="Button2" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />

                                                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender11" TargetControlID="txtDateFrom_IITUP" PopupButtonID="txtDateFrom_IITUP" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender12" TargetControlID="txtDateTo_IITUP" PopupButtonID="txtDateTo_IITUP" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender11" TargetControlID="txtDateFrom_IITUP" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender12" TargetControlID="txtDateTo_IITUP" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                        </asp:Panel>

                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                       </tr>
                                                       <tr>
                                                           <td style="width: 100%" align="center">
                                                               <table style="width: 100%" align="center">
                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:GridView runat="server" ID="grdDisposalAppraisal" Width="85%" SkinID="GridViewAA" AllowPaging="true" PageSize="10" EmptyDataText="No Data Found."
                                                                                DataKeyNames="IIRUPHdr_ID,WMHdr_ID" OnSelectedIndexChanged="grdDisposalAppraisal_SelectedIndexChanged">
                                                                                <Columns>
                                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton runat="server" ID="lnkSelect_Appraisal" CssClass="LinkBtnSelect" Text="Preview" Visible='<%# Bind("isVisible") %>' CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <asp:BoundField DataField="IIRUP_Date" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" HeaderText="IIRUP Date / WMR Date" />
                                                                                    <asp:BoundField DataField="IIRUP_No" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" HeaderText="IIRUP No. / WMR No." />
                                                                                    <asp:BoundField DataField="particulars" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50%" HeaderText="Particulars" />
                                                                                    <asp:BoundField DataField="AppraisedVal" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%" HeaderText="Appraised Value" />
                                                                                </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                  
                                                               </table>  
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                             <td style="width: 100%; height: 10px"></td>
                                                       </tr>
                                                   </table>
                                            </asp:View>

                                            <asp:View runat="server" ID="vwTab8_DFA">
                                                <table width="100%"  >
                                                    <tr>
                                                        <td align="center">
                                                            <table width="100%" >
                                                                <tr>
                                                                    <td align="center">

                                                                        <asp:GridView ID="grdDFA" runat="server" AllowPaging="True" DataKeyNames="IsspHdr_ID,AuctionDate" 
                                                                            EmptyDataText="No Data Found." PageSize="15" SkinID="GridViewAA" Width="65%" 
                                                                            OnRowDataBound="grdDFA_RowDataBound"
                                                                            OnSelectedIndexChanged="grdDFA_SelectedIndexChanged" OnPageIndexChanging="grdDFA_PageIndexChanging">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="ISSP_Date" DataFormatString="{0:d}" HeaderText="ISSP Date" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="18%" />
                                                                                <asp:BoundField DataField="ISSP_No" HeaderText="ISSP No." ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" />
                                                                                <asp:BoundField DataField="MinBid_Amt" DataFormatString="{0:N}" HeaderText="Minimum Bid Amount" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="18%" />
                                                                                <asp:BoundField DataField="AuctionDate" DataFormatString="{0:d}" HeaderText="Auction Date" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="18%" />
                                                                                
                                                                            </Columns>
                                                                        </asp:GridView>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td align="center">

                                                                                    <asp:Button ID="btnPreview_InterestedBidder" runat="server" CssClass="CSButton" Enabled="false" OnClientClick="StartProgressBar();" Text="List of Interested Bidder" Width="99%" OnClick="btnPreview_InterestedBidder_Click" />

                                                                                </td>
                                                                                 <td align="center">

                                                                                     <asp:Button ID="btnPreview_Abstract" runat="server" CssClass="CSButton" Enabled="false" OnClientClick="StartProgressBar();" Text="Abstract of Proposal" Width="99%" OnClick="btnPreview_Abstract_Click" />

                                                                                </td>
                                                                                 <td align="center">

                                                                                     <asp:Button ID="btnNotice_COA" runat="server" CssClass="CSButton" Enabled="false" OnClientClick="StartProgressBar();" Text="Notice to COA" Width="99%" OnClick="btnNotice_COA_Click" />

                                                                                </td>
                                                                                 <td align="center">

                                                                                     <asp:Button ID="btnNotice_Conspicuous" runat="server" CssClass="CSButton" Enabled="false" OnClientClick="StartProgressBar();" Text="Notice to Conspicuous" Width="99%" OnClick="btnNotice_Conspicuous_Click" />

                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>

                                            <asp:View runat="server" ID="vwTab9_AOA"> 
                                                <table width="100%">
                                                    <tr>
                                                        <td align="center">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="center">

                                                                        <asp:GridView ID="grdAOA" runat="server" AllowPaging="true" DataKeyNames="IsspHdr_ID,Issp_No" EmptyDataText="No Data Found." PageSize="12" SkinID="GridViewAA" Width="80%" OnSelectedIndexChanged="grdAOA_SelectedIndexChanged" OnRowDataBound="grdAOA_RowDataBound">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="BidType" HeaderText="Bid Type" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" />
                                                                                <asp:BoundField DataField="Issp_Date" DataFormatString="{0:d}" HeaderText="ISSP Date" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" />
                                                                                <asp:BoundField DataField="Issp_No" HeaderText="ISSP Number" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30%" />
                                                                                <asp:BoundField DataField="MinBid_Amt" DataFormatString="{0:N}" HeaderText="Min. Bid Amount" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="25%" />
                                                                            </Columns>
                                                                        </asp:GridView>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Button runat="server" ID="btnPreview" CssClass="CSButton" Width="35%" Text="Preview Abstract" OnClientClick="StartProgressBar();" Enabled="false" OnClick="btnPreview_Click" />
                            
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Button runat="server" ID="btnPreview_OP" CssClass="CSButton" Width="35%" Text="Order of Payment" OnClientClick="StartProgressBar();" Enabled="false" OnClick="btnPreview_OP_Click" />
                        
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
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
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp; 
       



        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

