<%@ Page Title="Disposal - ISSP" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Disposal_ISSP.aspx.vb"
    Inherits="Inventory_Disposal_Disposal_ISSP" StylesheetTheme="SkinFile" %>

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

    <script type="text/javascript">
        // It is important to place this JavaScript code after ScriptManager1
        var xPos, yPos;
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        function BeginRequestHandler(sender, args) {
            if ($get('<%=Panel1.ClientID%>') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPos = $get('<%=Panel1.ClientID%>').scrollLeft;
                yPos = $get('<%=Panel1.ClientID%>').scrollTop;
            }
        }


        function EndRequestHandler(sender, args) {
            if ($get('<%=Panel1.ClientID%>') != null) {
                // Set X and Y positions back to the scrollbar
                // after partial postback
                $get('<%=Panel1.ClientID%>').scrollLeft = xPos;
                $get('<%=Panel1.ClientID%>').scrollTop = yPos;
            }
        }

        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
    </script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">INVITATION TO SUBMIT SEALED PROPOSAL
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <span class="column_RightBold">Date :</span>
                            &nbsp;<asp:TextBox runat="server" ID="txtDate" CssClass="txtbox_Date" Width="12%" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Search IIRUP No. :</span>
                            &nbsp;<asp:TextBox runat="server" ID="txtSearch" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                            &nbsp;<asp:Button runat="server" ID="btnSearch" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel1" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical">

                                        <asp:GridView runat="server" ID="grdISSP" SkinID="GridViewAA" Width="100%" AllowPaging="false" EmptyDataText="No Data Found."
                                            DataKeyNames="IIRUPHdr_ID,isWMR">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox runat="server" ID="cbxSelect" CssClass="rbCS_Horizontal" AutoPostBack="true" OnCheckedChanged="cbItem_CheckedChanged" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:BoundField ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center" DataField="IIRUP_Date" DataFormatString="{0:d}" HeaderText="IIRUP Date / WMR Date" />
                                                <asp:BoundField ItemStyle-Width="12%" ItemStyle-HorizontalAlign="Center" DataField="IIRUP_No" HeaderText="IIRUP Number / WMR No." />
                                                <asp:BoundField ItemStyle-Width="30%" ItemStyle-HorizontalAlign="left" DataField="particulars" HeaderText="Particular" />
                                                <asp:BoundField ItemStyle-Width="30%" ItemStyle-HorizontalAlign="left" DataField="HRUnserviceable" HeaderText="How Rendered Unserviceable" />
                                                <asp:BoundField ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" DataField="PropCnt" HeaderText="No. of Properties" />
                                                <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Right" DataField="TotalAppraisedValue" DataFormatString="{0:N}" HeaderText="Total Appraised Value" />
                                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                            </Columns>
                                        </asp:GridView>

                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
                            <table width="98%">
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Deadline of Submission :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtDeadlineSub" CssClass="txtbox_Date" Width="30%"></asp:TextBox>
                                        <span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        &nbsp;                                        
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtDeadlineSub" PopupButtonID="txtDeadlineSub" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Inspection Date :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtInspectionDate" CssClass="txtbox_Date" Width="25%"></asp:TextBox>
                                        <span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtInspectionDate" PopupButtonID="txtInspectionDate" PopupPosition="TopLeft"></cc1:CalendarExtender>

                                        &nbsp;<span class="column_RightBold">| Time :</span>
                                        &nbsp;<asp:TextBox runat="server" ID="txtInspectionTime" CssClass="txtbox_Date" Width="25%" Text="8:00AM"></asp:TextBox>
                                      <%--  <asp:DropDownList runat="server" ID="drpInspectionTime" CssClass="drpdownCSS" Width="15%">
                                            <asp:ListItem Selected="True" Value="1" Text="A.M."></asp:ListItem>
                                            <asp:ListItem Value="2" Text="P.M."></asp:ListItem>
                                        </asp:DropDownList>
                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtInspectionTime" ValidChars="1234567890:"></cc1:FilteredTextBoxExtender>--%>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Time :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtDeadlineTime" CssClass="txtbox_Date" Width="30%" Text="8:00"></asp:TextBox>
                                        &nbsp;<asp:DropDownList runat="server" ID="drpDeadlineTime" CssClass="drpdownCSS" Width="15%">
                                            <asp:ListItem Selected="True" Value="1" Text="A.M."></asp:ListItem>
                                            <asp:ListItem Value="2" Text="P.M."></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Inspection Date :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtInspectionDate2" CssClass="txtbox_Date" Width="25%"></asp:TextBox>
                                        <span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender5" TargetControlID="txtInspectionDate2" PopupButtonID="txtInspectionDate2" PopupPosition="TopLeft"></cc1:CalendarExtender>

                                       <%-- &nbsp;<span class="column_RightBold">| Time :</span>
                                        &nbsp;<asp:TextBox runat="server" ID="txtInspectionTime2" CssClass="txtbox_Date" Width="15%" Text="8:00"></asp:TextBox>
                                        <asp:DropDownList runat="server" ID="drpInspectionTime2" CssClass="drpdownCSS" Width="15%">
                                            <asp:ListItem Selected="True" Value="1" Text="A.M."></asp:ListItem>
                                            <asp:ListItem Value="2" Text="P.M."></asp:ListItem>
                                        </asp:DropDownList>
                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender3" TargetControlID="txtInspectionTime2" ValidChars="1234567890:"></cc1:FilteredTextBoxExtender>--%>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Bid Docs Date :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtBidDate" CssClass="txtbox_Date" Width="30%"></asp:TextBox>
                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender3" TargetControlID="txtBidDate" PopupButtonID="txtBidDate" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left">
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Submission Location :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtSubmissionLocation" CssClass="txtbox_Var" Width="95%" Text=""></asp:TextBox>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                </tr>

                                <tr>
                                    <td style="width: 100%; height: 10px" colspan="4" align="center"></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Auction Date :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtAuctionDate" CssClass="txtbox_Date" Width="30%"></asp:TextBox>
                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender4" TargetControlID="txtAuctionDate" PopupButtonID="txtAuctionDate" PopupPosition="TopLeft"></cc1:CalendarExtender>

                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Publication Date :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtPublication_Date1" CssClass="txtbox_Date" Width="25%"></asp:TextBox>
                                        <span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender6" TargetControlID="txtPublication_Date1" PopupButtonID="txtPublication_Date1" PopupPosition="TopLeft"></cc1:CalendarExtender>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Auction Time :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtAuctionTime" CssClass="txtbox_Date" Width="30%" Text="8:00"></asp:TextBox>
                                        &nbsp;<asp:DropDownList runat="server" ID="drpAuctionTime" CssClass="drpdownCSS" Width="15%">
                                            <asp:ListItem Selected="True" Value="1" Text="A.M."></asp:ListItem>
                                            <asp:ListItem Value="2" Text="P.M."></asp:ListItem>
                                        </asp:DropDownList>
                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender2" TargetControlID="txtAuctionTime" ValidChars="1234567890:"></cc1:FilteredTextBoxExtender>

                                    </td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtPublication_Date2" CssClass="txtbox_Date" Width="25%"></asp:TextBox>
                                        <span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender7" TargetControlID="txtPublication_Date2" PopupButtonID="txtPublication_Date2" PopupPosition="TopLeft"></cc1:CalendarExtender>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Auction Location :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtAuctionLoc" CssClass="txtbox_Var" Width="95%"></asp:TextBox>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtPublication_Date3" CssClass="txtbox_Date" Width="25%"></asp:TextBox>
                                        <span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender8" TargetControlID="txtPublication_Date3" PopupButtonID="txtPublication_Date3" PopupPosition="TopLeft"></cc1:CalendarExtender>

                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 20px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Signatory :</span>
                            &nbsp;<asp:DropDownList runat="server" ID="drpSignatory" CssClass="drpdownCSS" Width="30%"></asp:DropDownList>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 20px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button runat="server" ID="btnSave" CssClass="CSButton" Width="15%" Text="Save" Enabled="false" OnClientClick="StartProgressBar();" />
                            &nbsp;<asp:Button runat="server" ID="btnPreview" CssClass="CSButton" Width="15%" Text="Preview" Enabled="false" OnClientClick="StartProgressBar();" />
                            &nbsp;<asp:Button ID="btnBidForm" OnClick="btnBidForm_Click" runat="server" Width="15%" CssClass="CSButton" Text="BID FORM" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnNotice" OnClick="btnNotice_Click" runat="server" Width="15%" CssClass="CSButton" Text="NOTICE" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnOP" runat="server" Width="15%" CssClass="CSButton" Text="Order of Payment" Visible="False" OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 30px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp; 
       


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

